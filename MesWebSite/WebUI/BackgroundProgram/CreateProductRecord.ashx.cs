using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.BackgroundProgram
{
    /// <summary>
    /// CreateProductRecord 的摘要说明
    /// </summary>
    public class CreateProductRecord : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string serialNo=context.Request["serialNo"]??"serialNo";
            if (string.IsNullOrEmpty(serialNo))
	        {
                context.Response.Write("序列号不可以为空！");
                context.Response.End();
	        }
            if (serialNo=="serialNo")
            {
                context.Response.Write("序列号有误！");
                context.Response.End();
            }
            Ctrl.Bll.ProductRecordBll bll = new Ctrl.Bll.ProductRecordBll();
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
            string fullPath = tmpPath + @"\记录跟踪卡模板.xls";
            string msg = "success";
            string fileName = string.Empty;
            if (!System.IO.File.Exists(fullPath))
            {
                msg = ftp.FtpDownload(tmpPath, ftpRelativePath, ftpHostIp, readUserNo, readUserPwd, "记录跟踪卡模板.xls");
            }
            
            if (msg.ToLower()=="success")
            {                
                msg=bll.WriteProductInfoIntoExcel(serialNo, fullPath,out fileName);
            }
            context.Response.Write(Common.JsonHelper.SerializeObject(new { msg = msg ,fileName = fileName }));
            context.Response.End();
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