using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.BackgroundProgram
{
    /// <summary>
    /// Approve 的摘要说明
    /// </summary>
    public class Approve : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string msg = "success";
            //获取传入的参数及校验
            string approveResult = context.Request["approveResult"] ?? "APPROVERESULT";
            if (string.IsNullOrEmpty(approveResult) || approveResult == "APPROVERESULT")
            {
                ResOutPut(context, "审核结果不合法！");
            }
            string rowFile = context.Request["rowFile"] ?? "ROWFILE";
            if (string.IsNullOrEmpty(rowFile) && rowFile == "ROWFILE")
            {
                ResOutPut(context, "文件信息有误！");
            }
            string rowApoAct = context.Request["rowApoAct"] ?? "ROWAPPROVE";
            if (string.IsNullOrEmpty(rowApoAct) && rowApoAct == "ROWAPPROVE")
            {
                ResOutPut(context, "审核信息有误！");
            }
            //获取当前用户
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
            string userNo = obj == null ? string.Empty : ((obj["userNo"] ?? string.Empty).ToString());

            //类构建
            ModelView.DmsFileView dmsFileView = Common.JsonHelper.DeserializeJsonToObject<ModelView.DmsFileView>(rowFile);
            ModelView.ApoActView apoActView = Common.JsonHelper.DeserializeJsonToObject<ModelView.ApoActView>(rowApoAct);
            //dfv.login_user_no = obj["userNo"].ToString();
            //dfv.login_user_name = obj["userName"].ToString();
            Ctrl.Bll.ApoActBll apoActBll = new Ctrl.Bll.ApoActBll();
            if (approveResult=="通过")
            {
                try
                {
                    msg = apoActBll.PassApprove(apoActView, dmsFileView, userNo);
                }
                catch (Exception)
                {
                    ResOutPut(context, "审核通过失败");
                }
            }
            else if (approveResult == "驳回")
            {
                try
                {
                    msg = apoActBll.RejectApprove(apoActView, dmsFileView, userNo);
                }
                catch (Exception)
                {
                    ResOutPut(context, "审核驳回失败");
                }                
            }
            else
            {
                ResOutPut(context, "审核结果不合法！");
            }
            ResOutPut(context, msg);
        }

        private static void ResOutPut(HttpContext context, string msg)
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