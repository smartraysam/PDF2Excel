namespace PDF2Excel
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.exportName = new System.Windows.Forms.TextBox();
            this.file_out = new System.Windows.Forms.TextBox();
            this.BrowseFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.but_del = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pdfFile = new System.Windows.Forms.ListBox();
            this.convertedFile = new System.Windows.Forms.ListBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.clear_list = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(603, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(292, 351);
            this.dataGridView1.TabIndex = 13;
            // 
            // exportName
            // 
            this.exportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exportName.Location = new System.Drawing.Point(23, 15);
            this.exportName.Name = "exportName";
            this.exportName.ReadOnly = true;
            this.exportName.Size = new System.Drawing.Size(557, 20);
            this.exportName.TabIndex = 12;
            // 
            // file_out
            // 
            this.file_out.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.file_out.Location = new System.Drawing.Point(603, 56);
            this.file_out.Multiline = true;
            this.file_out.Name = "file_out";
            this.file_out.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.file_out.Size = new System.Drawing.Size(292, 351);
            this.file_out.TabIndex = 9;
            // 
            // BrowseFile
            // 
            this.BrowseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseFile.AutoSize = true;
            this.BrowseFile.Location = new System.Drawing.Point(603, 12);
            this.BrowseFile.Name = "BrowseFile";
            this.BrowseFile.Size = new System.Drawing.Size(84, 23);
            this.BrowseFile.TabIndex = 7;
            this.BrowseFile.Text = "Browse file";
            this.BrowseFile.UseVisualStyleBackColor = true;
            this.BrowseFile.Click += new System.EventHandler(this.BrowseFile_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Multiselect = true;
            // 
            // but_del
            // 
            this.but_del.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_del.AutoSize = true;
            this.but_del.Location = new System.Drawing.Point(714, 12);
            this.but_del.Name = "but_del";
            this.but_del.Size = new System.Drawing.Size(80, 23);
            this.but_del.TabIndex = 16;
            this.but_del.Text = "Delete file";
            this.but_del.UseVisualStyleBackColor = true;
            this.but_del.Click += new System.EventHandler(this.but_del_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Browsed file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Converted file";
            // 
            // pdfFile
            // 
            this.pdfFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfFile.FormattingEnabled = true;
            this.pdfFile.Location = new System.Drawing.Point(22, 56);
            this.pdfFile.Name = "pdfFile";
            this.pdfFile.Size = new System.Drawing.Size(556, 160);
            this.pdfFile.TabIndex = 19;
            // 
            // convertedFile
            // 
            this.convertedFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.convertedFile.FormattingEnabled = true;
            this.convertedFile.Location = new System.Drawing.Point(23, 237);
            this.convertedFile.Name = "convertedFile";
            this.convertedFile.Size = new System.Drawing.Size(556, 160);
            this.convertedFile.TabIndex = 20;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(23, 419);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(872, 23);
            this.progressBar.TabIndex = 22;
            // 
            // clear_list
            // 
            this.clear_list.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clear_list.AutoSize = true;
            this.clear_list.Location = new System.Drawing.Point(817, 12);
            this.clear_list.Name = "clear_list";
            this.clear_list.Size = new System.Drawing.Size(78, 23);
            this.clear_list.TabIndex = 23;
            this.clear_list.Text = "Clear List";
            this.clear_list.UseVisualStyleBackColor = true;
            this.clear_list.Click += new System.EventHandler(this.clear_list_Click);
            // 
            // exit
            // 
            this.exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exit.AutoSize = true;
            this.exit.Location = new System.Drawing.Point(817, 450);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(78, 23);
            this.exit.TabIndex = 24;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 477);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.clear_list);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.convertedFile);
            this.Controls.Add(this.pdfFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.but_del);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.exportName);
            this.Controls.Add(this.file_out);
            this.Controls.Add(this.BrowseFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PDF TO EXCEL CONVERTER";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox exportName;
        private System.Windows.Forms.TextBox file_out;
        private System.Windows.Forms.Button BrowseFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button but_del;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox pdfFile;
        private System.Windows.Forms.ListBox convertedFile;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button clear_list;
        private System.Windows.Forms.Button exit;
    }
}

