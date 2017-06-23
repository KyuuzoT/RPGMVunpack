namespace RPGMVunpack
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSystemjsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadFilesStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileList = new System.Windows.Forms.CheckedListBox();
            this.KeyField = new System.Windows.Forms.TextBox();
            this.KeyLabel = new System.Windows.Forms.Label();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelImagesEncrypted = new System.Windows.Forms.Label();
            this.labelAudioEncrypted = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(452, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSystemjsonToolStripMenuItem,
            this.LoadFilesStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadSystemjsonToolStripMenuItem
            // 
            this.loadSystemjsonToolStripMenuItem.Name = "loadSystemjsonToolStripMenuItem";
            this.loadSystemjsonToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.loadSystemjsonToolStripMenuItem.Text = "Load System.json";
            this.loadSystemjsonToolStripMenuItem.Click += new System.EventHandler(this.loadSystemjsonToolStripMenuItem_Click);
            // 
            // LoadFilesStripMenuItem
            // 
            this.LoadFilesStripMenuItem.Name = "LoadFilesStripMenuItem";
            this.LoadFilesStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.LoadFilesStripMenuItem.Text = "Load Files";
            this.LoadFilesStripMenuItem.Click += new System.EventHandler(this.LoadFilesStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // FileList
            // 
            this.FileList.AllowDrop = true;
            this.FileList.FormattingEnabled = true;
            this.FileList.Location = new System.Drawing.Point(226, 28);
            this.FileList.Name = "FileList";
            this.FileList.ScrollAlwaysVisible = true;
            this.FileList.Size = new System.Drawing.Size(214, 349);
            this.FileList.TabIndex = 2;
            // 
            // KeyField
            // 
            this.KeyField.Location = new System.Drawing.Point(12, 82);
            this.KeyField.MaxLength = 300;
            this.KeyField.Multiline = true;
            this.KeyField.Name = "KeyField";
            this.KeyField.Size = new System.Drawing.Size(208, 77);
            this.KeyField.TabIndex = 3;
            this.KeyField.TextChanged += new System.EventHandler(this.KeyField_TextChanged);
            // 
            // KeyLabel
            // 
            this.KeyLabel.AutoSize = true;
            this.KeyLabel.Location = new System.Drawing.Point(13, 63);
            this.KeyLabel.Name = "KeyLabel";
            this.KeyLabel.Size = new System.Drawing.Size(75, 13);
            this.KeyLabel.TabIndex = 4;
            this.KeyLabel.Text = "Encryptor key:";
            // 
            // DecryptButton
            // 
            this.DecryptButton.Location = new System.Drawing.Point(48, 338);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(111, 39);
            this.DecryptButton.TabIndex = 5;
            this.DecryptButton.Text = "Decrypt";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Images:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Audio";
            // 
            // labelImagesEncrypted
            // 
            this.labelImagesEncrypted.AutoSize = true;
            this.labelImagesEncrypted.Location = new System.Drawing.Point(91, 177);
            this.labelImagesEncrypted.Name = "labelImagesEncrypted";
            this.labelImagesEncrypted.Size = new System.Drawing.Size(47, 13);
            this.labelImagesEncrypted.TabIndex = 8;
            this.labelImagesEncrypted.Text = "Uknown";
            this.labelImagesEncrypted.Click += new System.EventHandler(this.labelImagesEncrypted_Click);
            // 
            // labelAudioEncrypted
            // 
            this.labelAudioEncrypted.AutoSize = true;
            this.labelAudioEncrypted.Location = new System.Drawing.Point(91, 204);
            this.labelAudioEncrypted.Name = "labelAudioEncrypted";
            this.labelAudioEncrypted.Size = new System.Drawing.Size(47, 13);
            this.labelAudioEncrypted.TabIndex = 9;
            this.labelAudioEncrypted.Text = "Uknown";
            this.labelAudioEncrypted.Click += new System.EventHandler(this.labelAudioEncrypted_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 392);
            this.Controls.Add(this.labelAudioEncrypted);
            this.Controls.Add(this.labelImagesEncrypted);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DecryptButton);
            this.Controls.Add(this.KeyLabel);
            this.Controls.Add(this.KeyField);
            this.Controls.Add(this.FileList);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "RPG MV Unpacker";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSystemjsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadFilesStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox FileList;
        private System.Windows.Forms.TextBox KeyField;
        private System.Windows.Forms.Label KeyLabel;
        private System.Windows.Forms.Button DecryptButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelImagesEncrypted;
        private System.Windows.Forms.Label labelAudioEncrypted;
    }
}

