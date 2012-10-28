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
		private List<string> _selectedFilePaths = new List<string>();
		#endregion

		#region Constructor
		public FrmJpegRenamer()
		{
			InitializeComponent();

			grdSelectedFolders.DataSource = _selectedDirectories;
			cmbAvailableProperties.DataSource = new List<string>(new Exif.ExifProperties().Values);

			SetDefaults();
		}
		#endregion

		#region Private Methods
		private void AddDirectory(string folder, bool includeSubfolders)
		{
			var di = new DirectoryInfo(folder);
			if (!_selectedDirectories.Any(d => d.FullName == di.FullName))
			{
				_selectedDirectories.Add(di);
				_selectedFilePaths.AddRange(di.GetFiles(SEARCH_PATTERN).Select(fi => fi.FullName));
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
			txtTotalFiles.Text = _selectedFilePaths.Count.ToString();
			ShowExampleFileName();
		}

		private void ShowExampleFileName()
		{
			if (string.IsNullOrEmpty(txtFormat.Text)) return;
			if (_selectedFilePaths.Count == 0) return;

			string firstJpeg = _selectedFilePaths.First();

			txtExample.Text = JpegMetadataReader.BuildFilenameFromMetadata(firstJpeg, txtFormat.Text,
				JpegMetadataReader.GetMetadataForJpeg(firstJpeg), false);
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
			_selectedFilePaths.Clear();
			RefreshDirectoryList();
			txtTotalFiles.Text = _selectedFilePaths.Count.ToString();
		}

		private void btnAddProperty_Click(object sender, EventArgs e)
		{
			txtFormat.Text += (string.IsNullOrEmpty(txtFormat.Text) ? "" : txtSeparator.Text) + "[" + cmbAvailableProperties.Text + "]";
		}

		private void btnRenameFiles_Click(object sender, EventArgs e)
		{

		}

		private void txtFormat_TextChanged(object sender, EventArgs e)
		{
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
		#endregion
	}
}
