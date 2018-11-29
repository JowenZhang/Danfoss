using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.BackgroundProgram
{
    /// <summary>
    /// SetValidDate 的摘要说明
    /// </summary>
    public class SetValidDate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string rowStr = context.Request["row"] ?? string.Empty;
            string validStartDate = context.Request["validStartDate"] ?? string.Empty;
            if (string.IsNullOrEmpty(rowStr)) 
            {
                ResOutput(context, "不能设定目标为空文件的生效日期！");
            }
            if (string.IsNullOrEmpty(validStartDate))
            {
                ResOutput(context, "时间值设定有误！");
            }
            ModelView.DmsFileView dmsFileView = null;
            try
            {
                dmsFileView = Common.JsonHelper.DeserializeJsonToObject<ModelView.DmsFileView>(rowStr);
            }
            catch (Exception )
            {
                dmsFileView = null;
            }
            if (dmsFileView==null)
            {
                ResOutput(context, "不能设定目标为空文件的生效日期！");
            }
            Ctrl.Bll.DmsFileBll dmsFileBll = new Ctrl.Bll.DmsFileBll();
            ResOutput(context,dmsFileBll.SetValidDate(dmsFileView,validStartDate));
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