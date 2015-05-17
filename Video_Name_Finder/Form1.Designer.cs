namespace Video_Name_Finder
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Find_All_Actors_Name = new System.Windows.Forms.Button();
            this.button_AnalyzeFileName = new System.Windows.Forms.Button();
            this.textBox_File_Name = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.richTextBox_Status_Information = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Rename_Before = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Rename_After = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Find_All_Actors_Name
            // 
            this.button_Find_All_Actors_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_Find_All_Actors_Name.Location = new System.Drawing.Point(12, 419);
            this.button_Find_All_Actors_Name.Name = "button_Find_All_Actors_Name";
            this.button_Find_All_Actors_Name.Size = new System.Drawing.Size(120, 30);
            this.button_Find_All_Actors_Name.TabIndex = 0;
            this.button_Find_All_Actors_Name.Text = "Find all actors name";
            this.button_Find_All_Actors_Name.UseVisualStyleBackColor = false;
            this.button_Find_All_Actors_Name.Click += new System.EventHandler(this.button_Find_All_Actors_Name_Click);
            // 
            // button_AnalyzeFileName
            // 
            this.button_AnalyzeFileName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button_AnalyzeFileName.Location = new System.Drawing.Point(586, 6);
            this.button_AnalyzeFileName.Name = "button_AnalyzeFileName";
            this.button_AnalyzeFileName.Size = new System.Drawing.Size(90, 30);
            this.button_AnalyzeFileName.TabIndex = 1;
            this.button_AnalyzeFileName.Text = "Folder rename!";
            this.button_AnalyzeFileName.UseVisualStyleBackColor = false;
            this.button_AnalyzeFileName.Click += new System.EventHandler(this.button_AnalyzeFileName_Click);
            // 
            // textBox_File_Name
            // 
            this.textBox_File_Name.Location = new System.Drawing.Point(12, 12);
            this.textBox_File_Name.Name = "textBox_File_Name";
            this.textBox_File_Name.Size = new System.Drawing.Size(563, 22);
            this.textBox_File_Name.TabIndex = 2;
            // 
            // richTextBox_Status_Information
            // 
            this.richTextBox_Status_Information.Location = new System.Drawing.Point(12, 453);
            this.richTextBox_Status_Information.Name = "richTextBox_Status_Information";
            this.richTextBox_Status_Information.ReadOnly = true;
            this.richTextBox_Status_Information.Size = new System.Drawing.Size(760, 96);
            this.richTextBox_Status_Information.TabIndex = 3;
            this.richTextBox_Status_Information.Text = "";
            // 
            // richTextBox_Rename_Before
            // 
            this.richTextBox_Rename_Before.Location = new System.Drawing.Point(12, 40);
            this.richTextBox_Rename_Before.Name = "richTextBox_Rename_Before";
            this.richTextBox_Rename_Before.Size = new System.Drawing.Size(380, 373);
            this.richTextBox_Rename_Before.TabIndex = 4;
            this.richTextBox_Rename_Before.Text = "";
            // 
            // richTextBox_Rename_After
            // 
            this.richTextBox_Rename_After.Location = new System.Drawing.Point(392, 40);
            this.richTextBox_Rename_After.Name = "richTextBox_Rename_After";
            this.richTextBox_Rename_After.Size = new System.Drawing.Size(380, 373);
            this.richTextBox_Rename_After.TabIndex = 5;
            this.richTextBox_Rename_After.Text = "";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(682, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "File rename!";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox_Rename_After);
            this.Controls.Add(this.richTextBox_Rename_Before);
            this.Controls.Add(this.richTextBox_Status_Information);
            this.Controls.Add(this.textBox_File_Name);
            this.Controls.Add(this.button_AnalyzeFileName);
            this.Controls.Add(this.button_Find_All_Actors_Name);
            this.Name = "Form1";
            this.Text = "Video Name Finder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Find_All_Actors_Name;
        private System.Windows.Forms.Button button_AnalyzeFileName;
        private System.Windows.Forms.TextBox textBox_File_Name;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        public System.Windows.Forms.RichTextBox richTextBox_Status_Information;
        private System.Windows.Forms.RichTextBox richTextBox_Rename_Before;
        private System.Windows.Forms.RichTextBox richTextBox_Rename_After;
        private System.Windows.Forms.Button button1;
    }
}

