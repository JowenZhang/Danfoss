using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace WebUI.BackgroundProgram
{
    /// <summary>
    /// BindData 的摘要说明
    /// </summary>
    public class BindData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string fields = context.Request["fields"]??"FIELDS";
            string table = context.Request["table"]??"TABLE";
            string where = context.Request["where"] ?? "WHERE";
            Ctrl.Bll.BindDataBll bdb = new Ctrl.Bll.BindDataBll();
            DataTable dt = bdb.BindData(fields, table, where);
            context.Response.Write(Common.JsonHelper.SerializeObject(dt));
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