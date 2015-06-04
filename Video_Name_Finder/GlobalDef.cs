using System;
using System.Text;

public class Global_Def
{
    /// <summary>
    /// Global Variable Definition
    /// </summary>
    public static string VERSION = "1.0";

    public static string PATH_DATABASE = "All_Actors_Name.txt";
    public static int WEB_SLEEP_TIME = 500;

    public static class _VIDEO_INFO{
        public static string File_Name;
        public static string File_Ext_Name;
        public static string Actor_Name;
        public static string Video_ID;
        public static string Video_Name;
        public static string Rename;

        public static void Clear()
        {
            File_Name = "";
            File_Ext_Name = "";
            Actor_Name = "";
            Video_ID = "";
            Video_Name = "";
            Rename = "";
        }
    };
}
