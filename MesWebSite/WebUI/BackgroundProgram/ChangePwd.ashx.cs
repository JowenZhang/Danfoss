using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.BackgroundProgram
{
    /// <summary>
    /// ChangePwd 的摘要说明
    /// </summary>
    public class ChangePwd : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //userNo: userNo, oldPwd: oldPwd, newPwd: newPwd
            string userNo = context.Request["userNo"] ?? "UNKNOWN";
            string oldPwd = context.Request["oldPwd"] ?? "UNKNOWN";
            string newPwd = context.Request["newPwd"] ?? "UNKNOWN";
            if (string.IsNullOrEmpty(userNo)&&userNo=="UNKNOWN")
            {
                context.Response.Write("用户名不可为空！");
                context.Response.End();
            }
            if (string.IsNullOrEmpty(oldPwd) && oldPwd == "UNKNOWN")
            {
                context.Response.Write("原密码不可为空！");
                context.Response.End();
            }
            if (string.IsNullOrEmpty(newPwd) && newPwd == "UNKNOWN")
            {
                context.Response.Write("新密码不可为空！");
                context.Response.End();
            }
            Ctrl.Bll.SysUserBll sysUserBll = new Ctrl.Bll.SysUserBll();
            if (sysUserBll.ChangePwd(userNo,oldPwd,newPwd))
            {
                context.Response.Write("success");
                context.Response.End();
            }
            else
            {
                context.Response.Write("密码修改失败！");
                context.Response.End();
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