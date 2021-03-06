﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebUI.BackgroundProgram
{
    /// <summary>
    /// AttachFile 的摘要说明
    /// </summary>
    public class AttachFile : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string msg = "success";
            string rowStr = context.Request["row"] ?? string.Empty;
            if (string.IsNullOrEmpty(rowStr))
            {
                ResOutput(context, "操作对象为空，请重试！");

            }
            ModelView.DmsFileView fileView = Common.JsonHelper.DeserializeJsonToObject<ModelView.DmsFileView>(rowStr);
            HttpCookie cookies = context.Request.Cookies["MesCookie"];
            string cookieStr = string.Empty;
            if (cookies == null || string.IsNullOrEmpty(cookies.Value))
            {
                //context.Response.Redirect("/LoginForm.aspx");
            }
            else
            {
                cookieStr = cookies.Value;
            }
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(cookieStr) as JToken;
            //fileView.login_user_no = obj["userNo"].ToString();
            //fileView.login_user_name = obj["userName"].ToString();
            Ctrl.GlobalDataCtrl gdc = new Ctrl.GlobalDataCtrl();
 
            string fileInfo = context.Request["fileInfo"] ?? string.Empty;
            if (string.IsNullOrEmpty(fileInfo))
            {
                ResOutput(context, "无法读取目标文件信息！");
            }
            //获取客户端上传的文件集合
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            if (files.Count != 1)
            {
                ResOutput(context, "只能上传单一文件，请确认文件数量！");
            }

            try
            {
                MemoryStream ms = new MemoryStream(files[0].ContentLength);
                ms.Write(Common.MemeoryOperater.Stream2Byte(files[0].InputStream), 0, files[0].ContentLength);
                //配置信息读取
                string ftpHostIp = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "ftpHost", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml");
                string ftpRelativePath = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "mainFtpPath", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml");
                string ftpBackupPath = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "backupFtpPath", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml");
                string writeUserNo = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "writeUserNo", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml");
                string writeUserPwd = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "writeUserPwd", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml");
                string readUserNo = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "readUserNo", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml");
                string readUserPwd = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "readUserPwd", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml");
                string tmpPath = AppDomain.CurrentDomain.BaseDirectory + "Tmp";
                Ctrl.Bll.FtpBll ftp = new Ctrl.Bll.FtpBll();
                msg = ftp.FtpAdd(ms, ftpRelativePath, ftpHostIp, writeUserNo, writeUserPwd, fileView, fileInfo);
            }
            catch (Exception)
            {
                ResOutput(context, "传入数据有误！");
            }
            ResOutput(context, msg);
        }

        private static void ResOutput(HttpContext context, string msg)
        {
            context.Response.Write(Common.JsonHelper.SerializeObject(new { msg = msg }));
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