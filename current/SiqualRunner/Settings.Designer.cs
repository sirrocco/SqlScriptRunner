namespace SiqualRunner
{
	partial class FrmProjectSettings
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btnDeleteServer = new System.Windows.Forms.Button();
			this.btnAddSever = new System.Windows.Forms.Button();
			this.btnMakeDefaultServer = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.lstAvaialableServers = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnChooseFolderPath = new System.Windows.Forms.Button();
			this.txtFolderPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtProjectName = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.btnEdit = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Location = new System.Drawing.Point(1, 1);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(321, 222);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.btnEdit);
			this.tabPage1.Controls.Add(this.btnDeleteServer);
			this.tabPage1.Controls.Add(this.btnAddSever);
			this.tabPage1.Controls.Add(this.btnMakeDefaultServer);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.lstAvaialableServers);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.btnChooseFolderPath);
			this.tabPage1.Controls.Add(this.txtFolderPath);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.txtProjectName);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(313, 196);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Project";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// btnDeleteServer
			// 
			this.btnDeleteServer.Location = new System.Drawing.Point(256, 167);
			this.btnDeleteServer.Name = "btnDeleteServer";
			this.btnDeleteServer.Size = new System.Drawing.Size(51, 23);
			this.btnDeleteServer.TabIndex = 9;
			this.btnDeleteServer.Text = "Delete";
			this.btnDeleteServer.UseVisualStyleBackColor = true;
			this.btnDeleteServer.Click += new System.EventHandler(this.btnDeleteServer_Click);
			// 
			// btnAddSever
			// 
			this.btnAddSever.Location = new System.Drawing.Point(256, 109);
			this.btnAddSever.Name = "btnAddSever";
			this.btnAddSever.Size = new System.Drawing.Size(51, 23);
			this.btnAddSever.TabIndex = 8;
			this.btnAddSever.Text = "Add";
			this.btnAddSever.UseVisualStyleBackColor = true;
			this.btnAddSever.Click += new System.EventHandler(this.btnAddSever_Click);
			// 
			// btnMakeDefaultServer
			// 
			this.btnMakeDefaultServer.Location = new System.Drawing.Point(256, 80);
			this.btnMakeDefaultServer.Name = "btnMakeDefaultServer";
			this.btnMakeDefaultServer.Size = new System.Drawing.Size(51, 23);
			this.btnMakeDefaultServer.TabIndex = 7;
			this.btnMakeDefaultServer.Text = "Default";
			this.btnMakeDefaultServer.UseVisualStyleBackColor = true;
			this.btnMakeDefaultServer.Click += new System.EventHandler(this.btnMakeDefaultServer_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(122, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Available SQL Servers : ";
			// 
			// lstAvaialableServers
			// 
			this.lstAvaialableServers.FormattingEnabled = true;
			this.lstAvaialableServers.Location = new System.Drawing.Point(6, 83);
			this.lstAvaialableServers.Name = "lstAvaialableServers";
			this.lstAvaialableServers.Size = new System.Drawing.Size(244, 108);
			this.lstAvaialableServers.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Folder Path: ";
			// 
			// btnChooseFolderPath
			// 
			this.btnChooseFolderPath.Location = new System.Drawing.Point(284, 32);
			this.btnChooseFolderPath.Name = "btnChooseFolderPath";
			this.btnChooseFolderPath.Size = new System.Drawing.Size(26, 23);
			this.btnChooseFolderPath.TabIndex = 3;
			this.btnChooseFolderPath.Text = "...";
			this.btnChooseFolderPath.UseVisualStyleBackColor = true;
			this.btnChooseFolderPath.Click += new System.EventHandler(this.btnChooseFolderPath_Click);
			// 
			// txtFolderPath
			// 
			this.txtFolderPath.Location = new System.Drawing.Point(80, 33);
			this.txtFolderPath.Name = "txtFolderPath";
			this.txtFolderPath.Size = new System.Drawing.Size(198, 20);
			this.txtFolderPath.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Project Name: ";
			// 
			// txtProjectName
			// 
			this.txtProjectName.Location = new System.Drawing.Point(80, 6);
			this.txtProjectName.MaxLength = 150;
			this.txtProjectName.Name = "txtProjectName";
			this.txtProjectName.Size = new System.Drawing.Size(230, 20);
			this.txtProjectName.TabIndex = 0;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(247, 225);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(166, 225);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(256, 138);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(51, 23);
			this.btnEdit.TabIndex = 10;
			this.btnEdit.Text = "Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// FrmProjectSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(325, 250);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.tabControl1);
			this.Name = "FrmProjectSettings";
			this.Text = "Project Settings";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtProjectName;
		private System.Windows.Forms.Button btnChooseFolderPath;
		private System.Windows.Forms.TextBox txtFolderPath;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnMakeDefaultServer;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox lstAvaialableServers;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnDeleteServer;
		private System.Windows.Forms.Button btnAddSever;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button btnEdit;
	}
}