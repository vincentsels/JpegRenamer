using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileRenamer
{
	public partial class FrmJpegRenamer : Form
	{
		#region Constants
		private const string SEARCH_PATTERN = "*.jp*g";
		#endregion

		#region Fields
		private BindingList<DirectoryInfo> _selectedDirectories = new BindingList<DirectoryInfo>();
		private List<FileInfo> _selectedFiles = new List<FileInfo>();
		#endregion

		#region Constructor
		public FrmJpegRenamer()
		{
			InitializeComponent();

			grdSelectedFolders.DataSource = _selectedDirectories;

			FillComboboxes();
			SetDefaults();
		}
		#endregion

		#region Private Methods
		private void FillComboboxes()
		{
			cmbJpegProperties.DataSource = new List<string>(new Exif.ExifProperties().Values);
			cmbFileProperties.DataSource = new List<string>(new[] { FileProperties.FILENAME,
				FileProperties.CREATION_DATE, FileProperties.MODFICIATION_DATE });
		}

		private void AddDirectory(string folder, bool includeSubfolders)
		{
			var di = new DirectoryInfo(folder);
			if (!_selectedDirectories.Any(d => d.FullName == di.FullName))
			{
				_selectedDirectories.Add(di);
				_selectedFiles.AddRange(di.GetFiles(SEARCH_PATTERN));
			}

			// Recursively add all subdirectories and their files
			if (includeSubfolders)
				foreach (DirectoryInfo subFolder in di.GetDirectories())
					AddDirectory(subFolder.FullName, includeSubfolders);
		}

		private void RefreshDirectoryList()
		{
			foreach (DataGridViewColumn col in grdSelectedFolders.Columns)
				if (col.Name != "Name")
					col.Visible = false;
		}

		private void SetDefaults()
		{
			txtFormat.Text = Properties.Settings.Default.DefaultFormat;
		}

		private void AddFolder()
		{
			if (!string.IsNullOrEmpty(txtFolder.Text) && Directory.Exists(txtFolder.Text))
			{
				AddDirectory(txtFolder.Text, chkIncludeSubfolders.Checked);
			}
			else
			{
				using (FolderBrowserDialog fbd = new FolderBrowserDialog())
				{
					fbd.ShowNewFolderButton = false;
					var result = fbd.ShowDialog();
					if (result == System.Windows.Forms.DialogResult.OK)
						AddDirectory(fbd.SelectedPath, chkIncludeSubfolders.Checked);
				}
			}

			RefreshDirectoryList();
			txtTotalFiles.Text = _selectedFiles.Count.ToString();
			ShowExampleFileName();
			EnableOrDisableRenameButton();
		}

		private void ShowExampleFileName()
		{
			if (string.IsNullOrEmpty(txtFormat.Text)) return;
			if (_selectedFiles.Count == 0) return;

			txtExample.Text = JpegMetadataReader.BuildFilenameFromMetadata(
				_selectedFiles.First(), txtFormat.Text, chkReplaceSpacesWith.Checked, 
				txtReplaceSpacesWith.Text, chkToLowerCase.Checked);
		}

		private void EnableOrDisableRenameButton()
		{
			if (_selectedFiles.Count() > 0 && !string.IsNullOrEmpty(txtFormat.Text)) 
				btnRenameFiles.Enabled = true;
			else if (btnRenameFiles.Enabled == true) 
				btnRenameFiles.Enabled = false;
		}
		#endregion

		#region Event Handlers
		private void btnAddFolder_Click(object sender, EventArgs e)
		{
			AddFolder();
		}

		private void btnClearFolders_Click(object sender, EventArgs e)
		{
			_selectedDirectories.Clear();
			_selectedFiles.Clear();
			RefreshDirectoryList();
			txtTotalFiles.Text = _selectedFiles.Count.ToString();
		}

		private void btnAddFileProperty_Click(object sender, EventArgs e)
		{
			txtFormat.Text += (string.IsNullOrEmpty(txtFormat.Text) ? "" : txtSeparator.Text) + "[" + cmbFileProperties.Text + "]";
		}

		private void btnAddJpegProperty_Click(object sender, EventArgs e)
		{
			txtFormat.Text += (string.IsNullOrEmpty(txtFormat.Text) ? "" : txtSeparator.Text) + "[" + cmbJpegProperties.Text + "]";
		}

		private void btnRenameFiles_Click(object sender, EventArgs e)
		{
			pbProgress.Minimum = 0;
			pbProgress.Maximum = _selectedFiles.Count();
			foreach (var file in _selectedFiles)
			{
				pbProgress.PerformStep();
				string newName = JpegMetadataReader.BuildFilenameFromMetadata(
					file, txtFormat.Text, chkReplaceSpacesWith.Checked, txtReplaceSpacesWith.Text, chkToLowerCase.Checked);
				File.Move(file.FullName, Path.Combine(file.Directory.ToString(), newName));
			}
		}

		private void txtFormat_TextChanged(object sender, EventArgs e)
		{
			EnableOrDisableRenameButton();

			ShowExampleFileName();
		}

		private void txtFormat_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '[' || e.KeyChar == ']') e.Handled = true;
		}

		private void txtFolder_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				AddFolder();
		}

		private void FrmJpegRenamer_Load(object sender, EventArgs e)
		{
			EnableOrDisableRenameButton();
		}

		private void RefreshExampleName(object sender, EventArgs e)
		{
			ShowExampleFileName();
		}
		#endregion
	}
}
