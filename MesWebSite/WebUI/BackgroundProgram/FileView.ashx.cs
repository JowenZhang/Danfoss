using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.BackgroundProgram
{
    /// <summary>
    /// FileView 的摘要说明
    /// </summary>
    public class FileView : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string objNeedOperate = context.Request["objNeedOperate"] ?? "OBJECT";
            if (!string.IsNullOrEmpty(objNeedOperate) && objNeedOperate != "OBJECT")
            {
                ModelView.DmsFileView dmsFileView=Common.JsonHelper.DeserializeJsonToObject<ModelView.DmsFileView>(objNeedOperate);
                Ctrl.Bll.FtpBll ftp = new Ctrl.Bll.FtpBll();
                //配置信息读取
                string ftpHostIp = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "ftpHost", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml");
                string ftpRelativePath = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "mainFtpPath", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml");
                string ftpBackupPath = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "backupFtpPath", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml");
                string writeUserNo = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "writeUserNo", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml");
                string writeUserPwd = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "writeUserPwd", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml");
                string readUserNo = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "readUserNo", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml");
                string readUserPwd = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "readUserPwd", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml");
                string tmpPath = AppDomain.CurrentDomain.BaseDirectory + "Tmp";
                string msg=ftp.FtpDownload(tmpPath, ftpRelativePath, ftpHostIp, readUserNo, readUserPwd, dmsFileView);
                context.Response.Write(Common.JsonHelper.SerializeObject(new { msg = msg }));
            }
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}