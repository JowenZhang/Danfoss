using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.BackgroundProgram
{
    /// <summary>
    /// DeleteFile 的摘要说明
    /// </summary>
    public class DeleteFile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string msg = "success";
            string dmsFile = context.Request["dmsFile"] ?? "OBJECT";
            if ( !string.IsNullOrEmpty(dmsFile) && dmsFile != "OBJECT")
            {
                ModelView.DmsFileView dmsFileView = Common.JsonHelper.DeserializeJsonToObject<ModelView.DmsFileView>(dmsFile);
                Ctrl.Bll.DmsFileBll dmsFileBll = new Ctrl.Bll.DmsFileBll();
                msg = dmsFileBll.DeleteFile(dmsFileView);
            }
            else 
            {
                msg = "要删除的文件目标不存在";
            }
            context.Response.Write(Common.JsonHelper.SerializeObject(new { msg = msg }));
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