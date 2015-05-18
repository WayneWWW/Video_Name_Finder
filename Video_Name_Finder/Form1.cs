using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Name_Finder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button_Find_All_Actors_Name_Click(object sender, EventArgs e)
        {
            Net.Process_File_Read_All_Actor_Name(Global_Def.PATH_DATABASE);
        }

        /// <summary>
        /// A video data that has already finished
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public int Process_A_Data(string Path)
        {
            int Status = ErrorDef.EFI_SUCCESS;

            //
            // Fill data into structure
            //
            Global_Def._VIDEO_INFO.File_Name = Path;
            Global_Def._VIDEO_INFO.Video_ID = Str.Analyze_Video_ID(Path);
            if (Global_Def._VIDEO_INFO.Video_ID.Length > 0)
            {
                Global_Def._VIDEO_INFO.Video_Name = Net.Process_Web_Read_Video_Name(Global_Def._VIDEO_INFO.Video_ID);
                Global_Def._VIDEO_INFO.Actor_Name = Str.Find_Actor_Name(Global_Def._VIDEO_INFO.Video_Name);
                if (Global_Def._VIDEO_INFO.Video_Name.Length > 0 && Global_Def._VIDEO_INFO.Actor_Name.Length > 0)
                {
                    Global_Def._VIDEO_INFO.Rename = Global_Def._VIDEO_INFO.Actor_Name + " - " + Global_Def._VIDEO_INFO.Video_Name + " ( " + Global_Def._VIDEO_INFO.Video_ID + " )";
                }
                else if (Global_Def._VIDEO_INFO.Video_Name.Length > 0)
                {
                    Global_Def._VIDEO_INFO.Rename = Global_Def._VIDEO_INFO.Video_Name + " ( " + Global_Def._VIDEO_INFO.Video_ID + " )";
                }
                else
                {
                    Global_Def._VIDEO_INFO.Rename = "";
                }

                try
                {
                    Global_Def._VIDEO_INFO.File_Ext_Name = Path.Substring(Path.LastIndexOf("."));
                }
                catch (Exception e)
                {
                }

                //
                // Rename
                //
                if (Global_Def._VIDEO_INFO.Rename.Length > 0)
                {
                    Global_Def._VIDEO_INFO.Rename = Global_Def._VIDEO_INFO.Rename + Global_Def._VIDEO_INFO.File_Ext_Name;
                    //Str.Process_Video_Rename(Global_Def._VIDEO_INFO.File_Name, Global_Def._VIDEO_INFO.Rename);
                }


                //
                // Print status
                //
                richTextBox_Status_Information.AppendText("File_Name: " + Global_Def._VIDEO_INFO.File_Name + "\n");
                richTextBox_Status_Information.AppendText("File_Ext_Name: " + Global_Def._VIDEO_INFO.File_Ext_Name + "\n");
                richTextBox_Status_Information.AppendText("Actor_Name: " + Global_Def._VIDEO_INFO.Actor_Name + "\n");
                richTextBox_Status_Information.AppendText("Video_ID: " + Global_Def._VIDEO_INFO.Video_ID + "\n");
                richTextBox_Status_Information.AppendText("Video_Name: " + Global_Def._VIDEO_INFO.Video_Name + "\n");
                richTextBox_Status_Information.AppendText("Rename: " + Global_Def._VIDEO_INFO.Rename + "\n");
                richTextBox_Status_Information.AppendText("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------" + "\n");
            }

            return Status;
        }

        private void button_Process_Folder_Name_Click(object sender, EventArgs e)
        {
            //
            // Clear all rich text box
            //
            richTextBox_Status_Information.Clear();
            richTextBox_Rename_Before.Clear();
            richTextBox_Rename_After.Clear();

            //
            // Open folder diag box
            //
            if (textBox_File_Name.Text == "")
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox_File_Name.Text = folderBrowserDialog.SelectedPath;
                }
            }

            //
            // Parsing folder
            //
            string temp_folder = Str.Find_Folder_Recursive(textBox_File_Name.Text, true);
            string[] split = temp_folder.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            //
            // Output to rich text box
            //
            foreach (string s_name in split)
            {
                richTextBox_Rename_Before.AppendText(s_name + "\n");
                Process_A_Data(s_name);
                richTextBox_Status_Information.SelectionStart = richTextBox_Status_Information.Text.Length;
                richTextBox_Status_Information.ScrollToCaret();
            }

            richTextBox_Status_Information.AppendText("Done!\n");
        }

        private void button_Process_File_Name_Click(object sender, EventArgs e)
        {
            //
            // Clear all rich text box
            //
            richTextBox_Status_Information.Clear();
            richTextBox_Rename_Before.Clear();
            richTextBox_Rename_After.Clear();

            //
            // Open folder diag box
            //
            if (textBox_File_Name.Text == "")
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox_File_Name.Text = folderBrowserDialog.SelectedPath;
                }
            }

            //
            // Parsing file
            //
            string temp_folder = Str.Find_Folder_Recursive(textBox_File_Name.Text, false);
            string[] split = temp_folder.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            //
            // Output to rich text box
            //
            foreach (string s_name in split)
            {
                richTextBox_Rename_Before.AppendText(s_name + "\n");
                Process_A_Data(s_name);
                richTextBox_Status_Information.SelectionStart = richTextBox_Status_Information.Text.Length;
                richTextBox_Status_Information.ScrollToCaret();
            }

            richTextBox_Status_Information.AppendText("Done!\n");
        }
    }
}
