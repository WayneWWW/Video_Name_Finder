using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Text.RegularExpressions;

public class Str
{
    /// <summary>
    /// Analyze word is digit and char or not
    /// </summary>
    /// <param name="word"></param>
    /// <returns>
    /// TRUE    = Digit and char
    /// FALSE   = Others
    /// </returns>
    public static bool IsNumandEG(string word)
    {
        Regex NumandEG = new Regex("[^A-Za-z0-9]");
        return !NumandEG.IsMatch(word);
    }

    /// <summary>
    /// Analyze file name to fit video name rule.
    /// 
    /// There are many bugs and need to repair later...
    /// </summary>
    /// <param name="file_name"></param>
    /// <returns>Video ID</returns>
    public static string AnalyzeFileName(string file_name)
    {
        string result = "";
        int p_string = 0;
        int p_digit = 0;
        int p_char = 0;
        int n_char = 0;
        int i_temp = 0;

        if (file_name.Length == 0)
        {
            return "";
        }

        //
        // First time to analyze, include "-", ex: "IPZ-559"
        //
        for (p_string = (file_name.Length - 3); (p_string - 3) > 0; p_string--)
        {
            result = file_name.Substring(p_string, 3);
            if (int.TryParse(result, out i_temp))
            {
                p_digit = p_string;
                break;
            }
        }

        if (file_name.Substring(p_string - 1, 1) == "-")
        {
            p_string -= 2;

            for (; p_string >= 0; p_string--)
            {
                n_char++;
                p_char = p_string;
                if (!IsNumandEG(file_name.Substring(p_string, 1)))
                {
                    p_char ++;
                    n_char--;
                    break;
                }
            }

            //
            // Process result
            //
            result = file_name.Substring(p_char, n_char) + "-" + file_name.Substring(p_digit, 3);
            return result;
        }

        //
        // If first time failed, second time to analyze, remove "-", ex: "IPZ559"
        //
        for (; p_string >= 0; p_string--)
        {
            n_char++;
            p_char = p_string;
            if (!IsNumandEG(file_name.Substring(p_string, 1)))
            {
                p_char++;
                n_char--;
                break;
            }
        }
        n_char --;

        //
        // Process result
        //
        result = file_name.Substring(p_char, n_char) + "-" + file_name.Substring(p_digit, 3);
        return result;
    }

    /// <summary>
    /// Read actors name from file and compare with video name, to check who is the main actor in this video
    /// </summary>
    /// <param name="Video_name"></param>
    /// <returns>
    /// Actor name
    /// </returns>
    public static string Find_Actor_Name(string Video_name)
    {
        string result = "";
        string read_text = "";

        if (Video_name.Length == 0)
        {
            return "";
        }

        try
        {
            using (StreamReader sr = new StreamReader(Global_Def.PATH_DATABASE))
            {
                read_text = sr.ReadToEnd();

                sr.Close();
            }
        }
        catch (Exception e_sr)
        {
            MessageBox.Show(e_sr.Message + "\nFile is not exist, please check it.");
        }
        finally
        {
            string[] split = read_text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s_name in split)
            {
                if (Video_name.IndexOf(s_name) > 0)
                {
                    result = s_name;
                    break;
                }
            }
        }

        return result;
    }

    /// <summary>
    /// Rename folder
    /// </summary>
    /// <param name="old_name"></param>
    /// <param name="new_name"></param>
    /// <returns></returns>
    public static int Process_Video_Rename(string old_name, string new_name)
    {
        int Status = ErrorDef.EFI_SUCCESS;
        string temp = "";

        temp = old_name.Remove(old_name.LastIndexOf("\\"));
        new_name = temp + "\\" +  new_name;

        try
        {
            System.IO.Directory.Move(old_name, new_name);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        return Status;
    }

}