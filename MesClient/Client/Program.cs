using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            System.IO.Directory.SetCurrentDirectory(Application.StartupPath);
            try
            {
                //if (args != null && args.Length > 0)
                //{
                string server = "127.0.0.1";
                string userNo = "Server";
                string userTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                AnalyzeArgs(args, ref server, ref userNo,ref userTime);
                //Application.Run(new frmMain(userNo, server, userTime));
                Application.Run(new frmBaseMaster());
                 // }
            }
            catch(Exception ex)
            {
                frmMsgBox frm = new frmMsgBox("登录失败!"+ex.ToString());
                frm.ShowDialog();
            }
        }
        
        private static void AnalyzeArgs(string[] args, ref string hostName, ref string userNo,ref string userTime)
        {
            foreach (string text in args)
            {
                string text2 = text.ToLower();
                if (text2.StartsWith("-hn"))
                {
                    hostName = text.Substring(3, text.Length - 3);
                }
                else if (text2.StartsWith("-un"))
                {
                    userNo = text.Substring(3, text.Length - 3);
                }
                else if (text2.StartsWith("-ut"))
                {
                    userTime = text.Substring(3, text.Length - 3);
                }
            }
        }
    }

    
}
