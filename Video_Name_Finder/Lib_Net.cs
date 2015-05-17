using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

public class Net
{
    /// <summary>
    /// Get website content
    /// </summary>
    /// <param name="website_address">Website address</param>
    /// <returns>Website content</returns>
    public static string GetWebsiteContent(string website_address)
    {
        string result = "";

        //將要取得HTML原如碼的網頁放在WebRequest.Create(@”網址” )
        HttpWebRequest myRequest = WebRequest.CreateHttp(website_address);

        /* Sart browser signature */
        myRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:31.0) Gecko/20100101 Firefox/31.0";
        myRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
        myRequest.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-us,en;q=0.5");
        /* Sart browser signature */

        //Method選擇GET
        myRequest.Method = "GET";

        //取得WebRequest的回覆
        WebResponse myResponse = myRequest.GetResponse();

        //Streamreader讀取回覆
        StreamReader sr = new StreamReader(myResponse.GetResponseStream());

        //將全文轉成string
        result = sr.ReadToEnd();

        //關掉WebResponse
        myResponse.Close(); 
        
        return result;
    }

    /// <summary>
    /// File stream for Read actor name to memory
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static int Process_File_Read_All_Actor_Name(string path)
    {
        try
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line = sr.ReadToEnd();

                sr.Close();
            }
        }
        catch (Exception e_sr)
        {
            MessageBox.Show(e_sr.Message + "\nCreating " + path + " in folder.");
        }
        finally
        {
            //Pass the filepath and filename to the StreamWriter Constructor
            StreamWriter sw = new StreamWriter(path);
            int page_number = 1;
            string result = "";

            do
            {
                //
                // Todo: Find a way to call main form rtc member
                //
                //richTextBox_Status_Information.AppendText("Process: " + "http://www.avsow.com/tw/actresses/currentPage/" + page_number.ToString() + "/" + "\n");
                
                result = GetWebsiteContent(@"http://www.avsow.com/tw/actresses/currentPage/" + page_number.ToString() + "/");

                //搜尋關鍵字
                int start = result.IndexOf("<div id=\"waterfall\">");
                result = result.Substring(start);

                //減去不要的字元. 
                string[] split = result.Split(new string[] { "<b>" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string s_name in split)
                {
                    if (s_name.IndexOf("</b>") > 0)
                    {
                        string ss_name = s_name.Remove(s_name.IndexOf("</b>"));
                        sw.WriteLine(ss_name);
                    }
                }

                page_number++;
            } while (result.IndexOf("下一頁") > 0);

            //
            //Close the file
            //
            sw.Close();
        }

        return ErrorDef.EFI_SUCCESS;
    }

    /// <summary>
    /// Retireve video name from web
    /// </summary>
    /// <param name="Video_ID"></param>
    /// <returns>
    /// Video name
    /// </returns>
    public static string Process_Web_Read_Video_Name(string Video_ID)
    {
        string result = "";
        string temp = "";
        int start = 0;

        temp = GetWebsiteContent(@"http://www.avsow.net/tw/search/" + Video_ID);

        //搜尋關鍵字
        start = temp.IndexOf("border-top");
        temp = temp.Substring(start);
        start = temp.IndexOf("target=\"_blank\">");
        temp = temp.Substring(start + 16);
        result = temp.Remove(temp.IndexOf("</a>"));

        return result;
    }
}
