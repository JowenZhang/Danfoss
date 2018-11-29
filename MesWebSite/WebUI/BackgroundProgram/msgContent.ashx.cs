using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;

namespace WebUI.BackgroundProgram
{
    /// <summary>
    /// msgContent 的摘要说明
    /// </summary>
    public class msgContent : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {/*
            context.Response.ContentType = "text/plain";
            DataEngine.DbEngine dbServer = new DataEngine.DbEngine();
            //获取登陆用户
            string loginUserNo=context.Request["loginUserNo"] == null ? "Server" : context.Request["loginUserNo"].ToString();
            ////获取用户信息
            //string sqlUserName = "select user_name from sys_user where user_no=@user_no;";
            //string sqlUserDeptNo = "select dept_no from sys_user where user_no=@user_no;";
            //Dictionary<string, object> pms = new Dictionary<string, object>();
            //pms.Add("@user_no", loginUserNo);

            //string loginUserName = (dbServer.QueryObject(sqlUserName,pms)??"Server").ToString();
            //string loginUserDeptNo = (dbServer.QueryObject(sqlUserDeptNo, pms) ?? "Server").ToString();
            //int i = 1;
            //List<Model.Msg> msgs = new List<Model.Msg>();
            ////获取用户文件审核信息
            //StringBuilder sql = new StringBuilder();
            //sql.AppendFormat("select a.* from apo_act as a left join apo_item as b on a.next_item_no=b.apo_item_no where step_finished ='false' and (b.apo_user_no='{0}' or b.apo_user_no is null);", loginUserNo);
            //DataTable dt=dbServer.QueryRecord(sql.ToString());
            //string tmp = string.Empty;
            //string result=string.Empty;
            //if (dt == null)
            //{
            //    result = CreateResult(i, msgs);
            //}
            //else
            //{
            //    foreach (DataRow item in dt.Rows)
            //    {
            //        string ralateNo = (item["ralate_no"] == null ? string.Empty : item["ralate_no"].ToString());
            //        string apoNo = (item["apo_no"] == null ? string.Empty : item["apo_no"].ToString());
            //        string actResult = (item["act_result"] == null ? string.Empty : item["act_result"].ToString());
            //        if (string.IsNullOrEmpty(ralateNo))
            //        {
            //            continue;
            //        }
            //        Model.Msg msg = new Model.Msg();
            //        msg.No = i;
            //        if (apoNo.ToLower() == "bom")
            //        {
            //            if (actResult.ToLower() == "true")
            //            {
            //                msg.MsgTxt = string.Format("您有编号为\"{0}\"的Bom待审核，请处理！", ralateNo);
            //            }
            //            else
            //            {
            //                msg.MsgTxt = string.Format("您有编号为\"{0}\"的Bom被驳回，请处理！", ralateNo);
            //            }
            //        }
            //        else if (apoNo.ToLower() == "plm_pms")
            //        {
            //            if (actResult.ToLower() == "true")
            //            {
            //                msg.MsgTxt = string.Format("您有编号为\"{0}\"的工艺参数待审核，请处理！", ralateNo);
            //            }
            //            else
            //            {
            //                msg.MsgTxt = string.Format("您有编号为\"{0}\"的工艺参数被驳回，请处理！", ralateNo);
            //            }
            //        }
            //        else
            //        {
            //            if (actResult.ToLower() == "true")
            //            {
            //                msg.MsgTxt = string.Format("您有编号为\"{0}\"的工艺文件待审核，请处理！", ralateNo);
            //            }
            //            else
            //            {
            //                msg.MsgTxt = string.Format("您有编号为\"{0}\"的工艺文件被驳回，请处理！", ralateNo);
            //            }
            //        }
            //        msgs.Add(msg);
            //        i++;
            //    }
            //    //获取工艺参数审核信息
            //    //将信息转化为json返回给前台
            //    var datas = Common.JsonHelper.SerializeJsonList<Model.Msg>(msgs);
            //    result = CreateResult(i, msgs);
            //}
            Ctrl.MsgCtrl msgCtrl=new Ctrl.MsgCtrl(loginUserNo);
            List<Model.Msg> datas = msgCtrl.GetMsgs();
            int i = datas.Count + 1;
            string result = CreateResult(i, datas);
            context.Response.Write(result);*/
            context.Response.Write("Hello World");
        }

        //private static string CreateResult(int i, List<Model.Msg> datas)
        //{
        //    var res = new { total = i - 1, rows = datas };
        //    string result = Common.JsonHelper.SerializeObject(res);
        //    return result;
        //}

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}