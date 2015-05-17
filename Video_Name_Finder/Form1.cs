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

        private void button_AnalyzeFileName_Click(object sender, EventArgs e)
        {
            if (textBox_File_Name.Text == "")
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox_File_Name.Text = folderBrowserDialog.SelectedPath;
                }
            }
            Global_Def._VIDEO_INFO.File_Name = textBox_File_Name.Text;
            Global_Def._VIDEO_INFO.Video_ID = Str.AnalyzeFileName(textBox_File_Name.Text);
            Global_Def._VIDEO_INFO.Video_Name = Net.Process_Web_Read_Video_Name(Global_Def._VIDEO_INFO.Video_ID);
            Global_Def._VIDEO_INFO.Actor_Name = Str.Find_Actor_Name(Global_Def._VIDEO_INFO.Video_Name);
            if (Global_Def._VIDEO_INFO.Actor_Name.Length > 0)
            {
                Global_Def._VIDEO_INFO.Rename = Global_Def._VIDEO_INFO.Actor_Name + " - " + Global_Def._VIDEO_INFO.Video_Name + " (" + Global_Def._VIDEO_INFO.Video_ID + ")";
            }
            else 
            {
                Global_Def._VIDEO_INFO.Rename = Global_Def._VIDEO_INFO.Video_Name + " (" + Global_Def._VIDEO_INFO.Video_ID + ")";
            }
            Str.Process_Video_Rename(Global_Def._VIDEO_INFO.File_Name, Global_Def._VIDEO_INFO.Rename);

            richTextBox_Status_Information.AppendText("File_Name: " + Global_Def._VIDEO_INFO.File_Name + "\n");
            richTextBox_Status_Information.AppendText("Actor_Name: " + Global_Def._VIDEO_INFO.Actor_Name + "\n");
            richTextBox_Status_Information.AppendText("Video_ID: " + Global_Def._VIDEO_INFO.Video_ID + "\n");
            richTextBox_Status_Information.AppendText("Video_Name: " + Global_Def._VIDEO_INFO.Video_Name + "\n");
            richTextBox_Status_Information.AppendText("Rename: " + Global_Def._VIDEO_INFO.Rename + "\n");

        }
    }
}
