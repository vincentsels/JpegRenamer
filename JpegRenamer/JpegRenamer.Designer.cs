namespace FileRenamer
{
	partial class FrmJpegRenamer
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnAddFolder = new System.Windows.Forms.Button();
			this.grpSelectedFolders = new System.Windows.Forms.GroupBox();
			this.txtFolder = new System.Windows.Forms.TextBox();
			this.lblFolder = new System.Windows.Forms.Label();
			this.chkIncludeSubfolders = new System.Windows.Forms.CheckBox();
			this.txtTotalFiles = new System.Windows.Forms.TextBox();
			this.lblTotalFiles = new System.Windows.Forms.Label();
			this.btnClearFolders = new System.Windows.Forms.Button();
			this.grdSelectedFolders = new System.Windows.Forms.DataGridView();
			this.grpActions = new System.Windows.Forms.GroupBox();
			this.txtSeparator = new System.Windows.Forms.TextBox();
			this.lblSeparator = new System.Windows.Forms.Label();
			this.btnAddProperty = new System.Windows.Forms.Button();
			this.cmbAvailableProperties = new System.Windows.Forms.ComboBox();
			this.lblAvailableProperties = new System.Windows.Forms.Label();
			this.txtExample = new System.Windows.Forms.TextBox();
			this.lblExample = new System.Windows.Forms.Label();
			this.txtFormat = new System.Windows.Forms.TextBox();
			this.lblFormat = new System.Windows.Forms.Label();
			this.pbProgress = new System.Windows.Forms.ProgressBar();
			this.btnRenameFiles = new System.Windows.Forms.Button();
			this.grpSelectedFolders.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdSelectedFolders)).BeginInit();
			this.grpActions.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnAddFolder
			// 
			this.btnAddFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddFolder.Location = new System.Drawing.Point(6, 144);
			this.btnAddFolder.Name = "btnAddFolder";
			this.btnAddFolder.Size = new System.Drawing.Size(255, 23);
			this.btnAddFolder.TabIndex = 1;
			this.btnAddFolder.Text = "Add folder";
			this.btnAddFolder.UseVisualStyleBackColor = true;
			this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
			// 
			// grpSelectedFolders
			// 
			this.grpSelectedFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grpSelectedFolders.Controls.Add(this.txtFolder);
			this.grpSelectedFolders.Controls.Add(this.lblFolder);
			this.grpSelectedFolders.Controls.Add(this.chkIncludeSubfolders);
			this.grpSelectedFolders.Controls.Add(this.txtTotalFiles);
			this.grpSelectedFolders.Controls.Add(this.lblTotalFiles);
			this.grpSelectedFolders.Controls.Add(this.btnClearFolders);
			this.grpSelectedFolders.Controls.Add(this.grdSelectedFolders);
			this.grpSelectedFolders.Controls.Add(this.btnAddFolder);
			this.grpSelectedFolders.Location = new System.Drawing.Point(12, 12);
			this.grpSelectedFolders.Name = "grpSelectedFolders";
			this.grpSelectedFolders.Size = new System.Drawing.Size(445, 173);
			this.grpSelectedFolders.TabIndex = 2;
			this.grpSelectedFolders.TabStop = false;
			this.grpSelectedFolders.Text = "Selected folders";
			// 
			// txtFolder
			// 
			this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFolder.Location = new System.Drawing.Point(48, 118);
			this.txtFolder.Name = "txtFolder";
			this.txtFolder.Size = new System.Drawing.Size(273, 20);
			this.txtFolder.TabIndex = 9;
			this.txtFolder.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtFolder_PreviewKeyDown);
			// 
			// lblFolder
			// 
			this.lblFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblFolder.AutoSize = true;
			this.lblFolder.Location = new System.Drawing.Point(6, 121);
			this.lblFolder.Name = "lblFolder";
			this.lblFolder.Size = new System.Drawing.Size(36, 13);
			this.lblFolder.TabIndex = 8;
			this.lblFolder.Text = "Folder";
			// 
			// chkIncludeSubfolders
			// 
			this.chkIncludeSubfolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.chkIncludeSubfolders.AutoSize = true;
			this.chkIncludeSubfolders.Checked = true;
			this.chkIncludeSubfolders.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkIncludeSubfolders.Location = new System.Drawing.Point(327, 120);
			this.chkIncludeSubfolders.Name = "chkIncludeSubfolders";
			this.chkIncludeSubfolders.Size = new System.Drawing.Size(112, 17);
			this.chkIncludeSubfolders.TabIndex = 7;
			this.chkIncludeSubfolders.Text = "Include subfolders";
			this.chkIncludeSubfolders.UseVisualStyleBackColor = true;
			// 
			// txtTotalFiles
			// 
			this.txtTotalFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTotalFiles.Location = new System.Drawing.Point(388, 147);
			this.txtTotalFiles.Name = "txtTotalFiles";
			this.txtTotalFiles.ReadOnly = true;
			this.txtTotalFiles.Size = new System.Drawing.Size(51, 20);
			this.txtTotalFiles.TabIndex = 6;
			// 
			// lblTotalFiles
			// 
			this.lblTotalFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTotalFiles.AutoSize = true;
			this.lblTotalFiles.Location = new System.Drawing.Point(327, 149);
			this.lblTotalFiles.Name = "lblTotalFiles";
			this.lblTotalFiles.Size = new System.Drawing.Size(55, 13);
			this.lblTotalFiles.TabIndex = 5;
			this.lblTotalFiles.Text = "Total files:";
			// 
			// btnClearFolders
			// 
			this.btnClearFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClearFolders.Location = new System.Drawing.Point(267, 144);
			this.btnClearFolders.Name = "btnClearFolders";
			this.btnClearFolders.Size = new System.Drawing.Size(54, 23);
			this.btnClearFolders.TabIndex = 4;
			this.btnClearFolders.Text = "Clear all";
			this.btnClearFolders.UseVisualStyleBackColor = true;
			this.btnClearFolders.Click += new System.EventHandler(this.btnClearFolders_Click);
			// 
			// grdSelectedFolders
			// 
			this.grdSelectedFolders.AllowUserToAddRows = false;
			this.grdSelectedFolders.AllowUserToDeleteRows = false;
			this.grdSelectedFolders.AllowUserToResizeColumns = false;
			this.grdSelectedFolders.AllowUserToResizeRows = false;
			this.grdSelectedFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grdSelectedFolders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.grdSelectedFolders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdSelectedFolders.ColumnHeadersVisible = false;
			this.grdSelectedFolders.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.grdSelectedFolders.Location = new System.Drawing.Point(6, 19);
			this.grdSelectedFolders.Name = "grdSelectedFolders";
			this.grdSelectedFolders.RowHeadersVisible = false;
			this.grdSelectedFolders.Size = new System.Drawing.Size(433, 93);
			this.grdSelectedFolders.TabIndex = 0;
			// 
			// grpActions
			// 
			this.grpActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grpActions.Controls.Add(this.txtSeparator);
			this.grpActions.Controls.Add(this.lblSeparator);
			this.grpActions.Controls.Add(this.btnAddProperty);
			this.grpActions.Controls.Add(this.cmbAvailableProperties);
			this.grpActions.Controls.Add(this.lblAvailableProperties);
			this.grpActions.Controls.Add(this.txtExample);
			this.grpActions.Controls.Add(this.lblExample);
			this.grpActions.Controls.Add(this.txtFormat);
			this.grpActions.Controls.Add(this.lblFormat);
			this.grpActions.Controls.Add(this.pbProgress);
			this.grpActions.Controls.Add(this.btnRenameFiles);
			this.grpActions.Location = new System.Drawing.Point(12, 191);
			this.grpActions.Name = "grpActions";
			this.grpActions.Size = new System.Drawing.Size(445, 128);
			this.grpActions.TabIndex = 3;
			this.grpActions.TabStop = false;
			this.grpActions.Text = "Actions";
			// 
			// txtSeparator
			// 
			this.txtSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSeparator.Location = new System.Drawing.Point(419, 20);
			this.txtSeparator.Name = "txtSeparator";
			this.txtSeparator.Size = new System.Drawing.Size(20, 20);
			this.txtSeparator.TabIndex = 10;
			this.txtSeparator.Text = "_";
			// 
			// lblSeparator
			// 
			this.lblSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSeparator.AutoSize = true;
			this.lblSeparator.Location = new System.Drawing.Point(360, 23);
			this.lblSeparator.Name = "lblSeparator";
			this.lblSeparator.Size = new System.Drawing.Size(53, 13);
			this.lblSeparator.TabIndex = 9;
			this.lblSeparator.Text = "Separator";
			// 
			// btnAddProperty
			// 
			this.btnAddProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddProperty.Location = new System.Drawing.Point(298, 18);
			this.btnAddProperty.Name = "btnAddProperty";
			this.btnAddProperty.Size = new System.Drawing.Size(56, 23);
			this.btnAddProperty.TabIndex = 8;
			this.btnAddProperty.Text = "Add";
			this.btnAddProperty.UseVisualStyleBackColor = true;
			this.btnAddProperty.Click += new System.EventHandler(this.btnAddProperty_Click);
			// 
			// cmbAvailableProperties
			// 
			this.cmbAvailableProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbAvailableProperties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAvailableProperties.FormattingEnabled = true;
			this.cmbAvailableProperties.Location = new System.Drawing.Point(111, 20);
			this.cmbAvailableProperties.Name = "cmbAvailableProperties";
			this.cmbAvailableProperties.Size = new System.Drawing.Size(181, 21);
			this.cmbAvailableProperties.TabIndex = 7;
			// 
			// lblAvailableProperties
			// 
			this.lblAvailableProperties.AutoSize = true;
			this.lblAvailableProperties.Location = new System.Drawing.Point(6, 23);
			this.lblAvailableProperties.Name = "lblAvailableProperties";
			this.lblAvailableProperties.Size = new System.Drawing.Size(99, 13);
			this.lblAvailableProperties.TabIndex = 6;
			this.lblAvailableProperties.Text = "Available properties";
			// 
			// txtExample
			// 
			this.txtExample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtExample.Location = new System.Drawing.Point(111, 73);
			this.txtExample.Name = "txtExample";
			this.txtExample.ReadOnly = true;
			this.txtExample.Size = new System.Drawing.Size(328, 20);
			this.txtExample.TabIndex = 5;
			// 
			// lblExample
			// 
			this.lblExample.AutoSize = true;
			this.lblExample.Location = new System.Drawing.Point(6, 76);
			this.lblExample.Name = "lblExample";
			this.lblExample.Size = new System.Drawing.Size(47, 13);
			this.lblExample.TabIndex = 4;
			this.lblExample.Text = "Example";
			// 
			// txtFormat
			// 
			this.txtFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFormat.Location = new System.Drawing.Point(111, 47);
			this.txtFormat.Name = "txtFormat";
			this.txtFormat.Size = new System.Drawing.Size(328, 20);
			this.txtFormat.TabIndex = 3;
			this.txtFormat.TextChanged += new System.EventHandler(this.txtFormat_TextChanged);
			this.txtFormat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFormat_KeyPress);
			// 
			// lblFormat
			// 
			this.lblFormat.AutoSize = true;
			this.lblFormat.Location = new System.Drawing.Point(6, 50);
			this.lblFormat.Name = "lblFormat";
			this.lblFormat.Size = new System.Drawing.Size(39, 13);
			this.lblFormat.TabIndex = 2;
			this.lblFormat.Text = "Format";
			// 
			// pbProgress
			// 
			this.pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pbProgress.Location = new System.Drawing.Point(111, 99);
			this.pbProgress.Name = "pbProgress";
			this.pbProgress.Size = new System.Drawing.Size(328, 23);
			this.pbProgress.TabIndex = 1;
			// 
			// btnRenameFiles
			// 
			this.btnRenameFiles.Location = new System.Drawing.Point(6, 99);
			this.btnRenameFiles.Name = "btnRenameFiles";
			this.btnRenameFiles.Size = new System.Drawing.Size(99, 23);
			this.btnRenameFiles.TabIndex = 0;
			this.btnRenameFiles.Text = "Rename files";
			this.btnRenameFiles.UseVisualStyleBackColor = true;
			this.btnRenameFiles.Click += new System.EventHandler(this.btnRenameFiles_Click);
			// 
			// FrmJpegRenamer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(469, 331);
			this.Controls.Add(this.grpActions);
			this.Controls.Add(this.grpSelectedFolders);
			this.MinimumSize = new System.Drawing.Size(485, 367);
			this.Name = "FrmJpegRenamer";
			this.Text = "JPEG Renamer";
			this.grpSelectedFolders.ResumeLayout(false);
			this.grpSelectedFolders.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdSelectedFolders)).EndInit();
			this.grpActions.ResumeLayout(false);
			this.grpActions.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnAddFolder;
		private System.Windows.Forms.GroupBox grpSelectedFolders;
		private System.Windows.Forms.DataGridView grdSelectedFolders;
		private System.Windows.Forms.GroupBox grpActions;
		private System.Windows.Forms.ProgressBar pbProgress;
		private System.Windows.Forms.Button btnRenameFiles;
		private System.Windows.Forms.TextBox txtExample;
		private System.Windows.Forms.Label lblExample;
		private System.Windows.Forms.TextBox txtFormat;
		private System.Windows.Forms.Label lblFormat;
		private System.Windows.Forms.Label lblAvailableProperties;
		private System.Windows.Forms.ComboBox cmbAvailableProperties;
		private System.Windows.Forms.TextBox txtSeparator;
		private System.Windows.Forms.Label lblSeparator;
		private System.Windows.Forms.Button btnAddProperty;
		private System.Windows.Forms.Button btnClearFolders;
		private System.Windows.Forms.Label lblTotalFiles;
		private System.Windows.Forms.TextBox txtTotalFiles;
		private System.Windows.Forms.CheckBox chkIncludeSubfolders;
		private System.Windows.Forms.Label lblFolder;
		private System.Windows.Forms.TextBox txtFolder;
	}
}

