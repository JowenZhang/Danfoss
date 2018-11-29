using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl.Bll
{
    /// <summary>
    /// 审核动作业务
    /// </summary>
    public class ApoActBll
    {
        /// <summary>
        /// 审核流程的建立
        /// </summary>
        /// <param name="dfv">要发起审核流程的文件信息</param>
        /// <param name="userNo">用户名</param>
        /// <returns>处理结果</returns>
        public string CreateApprove(ModelView.DmsFileView dfv, string userNo)
        {
            if (dfv==null)
            {
                return "文件不存在！";
            }
            //获取第一个审核流程视图
            ApoItemCtrl aic = new ApoItemCtrl();
            ModelView.ApoItemView aiv = aic.GetFirst(dfv.file_type_name);
            if (aiv==null)
            {
                return "未找到审核流程！";
            }
            //获取下一个审核流程视图
            ModelView.ApoItemView aivNext = aic.GetNext(aiv.apo_no, aiv.apo_item_no);
            if (aivNext==null)
            {
                return "该审核流程有误！";
            }
            //用户构建
            GlobalDataCtrl gdc = new GlobalDataCtrl();
            string userName = gdc.GetStrByField("user_name", "sys_user", "user_no", userNo);
            //文件视图及审核流程视图创建Act视图并处理
            ModelView.ApoActView aav = new ModelView.ApoActView();
            aav.id = string.Empty;
            aav.status_no = "310";
            aav.status_name = "已确认";
            aav.act_no = string.Empty;
            aav.apo_no = aiv.apo_no;
            aav.apo_item_no = aiv.apo_item_no;
            aav.apo_item_name = aiv.apo_item_name;
            aav.apo_index = aiv.apo_index;
            aav.next_item_no = aiv.next_item_no;
            aav.next_item_name = aivNext.apo_item_name;
            aav.next_user_name = aivNext.apo_user_name;
            aav.act_desc = dfv.file_desc;
            aav.act_result = "通过";
            aav.act_step = "0";
            aav.act_user_no = userNo;
            aav.act_user_name = userName;
            aav.act_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            aav.ralate_no = dfv.file_no;
            aav.ralate_file_name = dfv.file_name;
            aav.ralate_file_extension = dfv.file_extension;
            aav.ralate_type_no = dfv.file_type_no;
            aav.step_finished = "否";
            aav.apo_finished = "否";
            aav.dept_no = string.Empty;
            aav.dept_name = string.Empty;
            //数据写入
            ApoActCtrl aac = new ApoActCtrl();
            return aac.Insert(aav) > 0 ? "success" : "数据写入失败！";
        }

        /// <summary>
        /// 审核通过
        /// </summary>
        /// <param name="lastApoActView">前一审核动作视图</param>
        /// <param name="dmsFileView">要发起审核流程的文件信息</param>
        /// <param name="userNo">用户名</param>
        /// <returns>处理结果</returns>
        public string PassApprove(ModelView.ApoActView lastApoActView, ModelView.DmsFileView dmsFileView, string userNo)//文件类型对应审核类型编号
        {
            string res = "success";
            //获取下一个处理的流程视图
            ApoItemCtrl apoItemCtrl = new ApoItemCtrl();
            ModelView.ApoItemView nextApoItemView = apoItemCtrl.GetNext(lastApoActView.apo_no, lastApoActView.apo_item_no);
            if (nextApoItemView==null)
            {
                return "文件审核流程设定有误！";
            }
            if (nextApoItemView.apo_user_no.ToLower() != userNo.ToLower())
            {
                return "您无权审核此文件！";
            }
            if (lastApoActView.act_result == "驳回")
            {
                return "无法通过已驳回的文件，请重传！";
            }
            //获取最后一个处理的流程视图
            ModelView.ApoItemView lastApoItemView = apoItemCtrl.GetLast(lastApoActView.apo_no);
            //确认上一流程
            lastApoActView.step_finished="是";
            ApoActCtrl apoActCtrl = new ApoActCtrl();
            apoActCtrl.Update(lastApoActView);
            //按照结束流程构造当前动作
            lastApoActView.id = string.Empty;
            lastApoActView.status_name = "已确认";
            lastApoActView.status_no = "310";
            lastApoActView.act_no = string.Empty;
            lastApoActView.apo_item_no = nextApoItemView.apo_item_no;
            lastApoActView.apo_item_name = nextApoItemView.apo_item_name;
            lastApoActView.apo_index = nextApoItemView.apo_index;
            lastApoActView.next_item_no = nextApoItemView.next_item_no;
            lastApoActView.next_item_name = string.Empty;
            lastApoActView.next_user_name = string.Empty;
            lastApoActView.act_result = "通过";
            int intTmp = 1;
            lastApoActView.act_step = (int.TryParse(lastApoActView.act_step, out intTmp) ? intTmp + 1 : 1).ToString();
            lastApoActView.act_user_no = userNo;
            GlobalDataCtrl gdc = new GlobalDataCtrl();
            lastApoActView.act_user_name = gdc.GetStrByField("user_name", "sys_user", "user_no", userNo);
            lastApoActView.act_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            lastApoActView.step_finished = "是";
            lastApoActView.apo_finished = "是";
           
            ////如果是最后一个，同意的同时添加流程结束处理，即更新现有流程，同时更新文件状态
            if (nextApoItemView.apo_item_no == lastApoItemView.apo_item_no)
            {
                res = FinishApprove(lastApoActView);
                if (res=="success")
                {
                    dmsFileView.is_passed = "是";
                    dmsFileView.file_status = "使用中";
                    res=UpdateFile(dmsFileView);
                }
            }
            else
            {
                ModelView.ApoItemView nextLowerApoItemView = apoItemCtrl.GetNext(lastApoActView.apo_no, lastApoActView.apo_item_no);
                if (nextLowerApoItemView == null)
                {
                    return "文件审核流程设定有误！";
                }
                lastApoActView.next_item_name = nextLowerApoItemView.apo_item_name;
                lastApoActView.next_user_name = nextLowerApoItemView.apo_user_name;
                lastApoActView.step_finished = "否";
                lastApoActView.apo_finished = "否";
                res = Move2NextApprove(lastApoActView);
            }
            return res;
        }

        /// <summary>
        /// 文件信息的审核通过的写入
        /// </summary>
        /// <param name="dmsFileView">要更新的文件视图</param>
        /// <returns>更新的消息</returns>
        private string UpdateFile(ModelView.DmsFileView dmsFileView)
        {
            DmsFileCtrl dmsfileCtrl = new DmsFileCtrl();
            return dmsfileCtrl.Update(dmsFileView)>0?"success":"文件信息写入失败！";
        }

        /// <summary>
        /// 审核驳回
        /// </summary>
        /// <param name="lastApoActView">前一审核动作视图</param>
        /// <param name="dmsFileView">要驳回审核的文件信息</param>
        /// <param name="userNo">用户名</param>
        /// <returns>处理结果</returns>
        public string RejectApprove(ModelView.ApoActView lastApoActView, ModelView.DmsFileView dmsFileView, string userNo)
        {
            string res = string.Empty;
            //获取下一个处理的流程视图
            ApoItemCtrl apoItemCtrl = new ApoItemCtrl();
            ModelView.ApoItemView nextApoItemView = apoItemCtrl.GetNext(lastApoActView.apo_no, lastApoActView.apo_item_no);
            if (nextApoItemView == null)
            {
                return "文件审核流程设定有误！";
            }
            if (nextApoItemView.apo_user_no.ToLower() != userNo.ToLower())
            {
                return "您无权审核此文件！";
            }
            if (lastApoActView.act_result=="驳回")
            {
                return "无法驳回已驳回的文件，请重传！";
            }
            //获取第一次发起的审核动作
            ApoActCtrl apoActCtrl = new ApoActCtrl();
            ModelView.ApoActView firstApoActView = apoActCtrl.GetFirst(dmsFileView.file_no);
            if (firstApoActView == null)
            {
                return "不存在对应的审核发起记录！";
            }
            //确认上一流程
            lastApoActView.step_finished = "是";
            apoActCtrl.Update(lastApoActView);
            //按照驳回流程构造当前动作
            lastApoActView.id = string.Empty;
            lastApoActView.status_name = "已确认";
            lastApoActView.status_no = "310";
            lastApoActView.act_no = string.Empty;
            lastApoActView.apo_item_no = nextApoItemView.apo_item_no;
            lastApoActView.apo_item_name = nextApoItemView.apo_item_name;
            lastApoActView.apo_index = nextApoItemView.apo_index;
            lastApoActView.next_item_no = firstApoActView.apo_item_no;
            lastApoActView.next_item_name = firstApoActView.apo_item_name;
            lastApoActView.next_user_name = firstApoActView.act_user_name;
            lastApoActView.act_result = "驳回";
            int intTmp = 1;
            lastApoActView.act_step = (int.TryParse(lastApoActView.act_step, out intTmp) ? intTmp + 1 : 1).ToString();
            lastApoActView.act_user_no = userNo;
            GlobalDataCtrl gdc = new GlobalDataCtrl();
            lastApoActView.act_user_name = gdc.GetStrByField("user_name", "sys_user", "user_no", userNo);
            lastApoActView.act_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            lastApoActView.step_finished = "是";
            lastApoActView.apo_finished = "否";
            //数据写入
            return FinishApprove(lastApoActView);
        }

        /// <summary>
        /// 结束当前审核流程
        /// </summary>
        /// <param name="currentApoActView"></param>
        /// <returns></returns>
        public string FinishApprove(ModelView.ApoActView currentApoActView)
        {
            string msg=UpdateApprove(currentApoActView.ralate_no);
            if (msg=="success")
            {
                ApoActCtrl apoActCtrl = new ApoActCtrl();
                msg=apoActCtrl.Insert(currentApoActView)>0?"success":"结束流程数据写入失败！";                
            }
            return msg;
        }

        /// <summary>
        /// 写入并移动向下一审核流程
        /// </summary>
        /// <param name="currentApoActView"></param>
        /// <returns></returns>
        private string Move2NextApprove(ModelView.ApoActView currentApoActView)
        {
            ApoActCtrl apoActCtrl = new ApoActCtrl();
            return apoActCtrl.Insert(currentApoActView) > 0 ? "success" : "审核通过数据写入失败！";
        }
        

        /// <summary>
        /// 更新审核流程
        /// </summary>
        /// <param name="ralateNo">要跟新的文件编号，关联号</param>
        /// <returns>处理结果</returns>
        public string UpdateApprove(string ralateNo)
        {
            //获取需要更新流程的所有动作数据
            ApoActCtrl apoActCtrl = new ApoActCtrl();
            List<ModelView.ApoActView> list =apoActCtrl.GetUpdate(ralateNo);
            //更新处理
            List<ModelView.ApoActView> list2Update = list.Select<ModelView.ApoActView, ModelView.ApoActView>(UpdateData).ToList();
            //数据写入
            return apoActCtrl.Update(list2Update)>0?"success":"数据更新失败！";          
        }

        /// <summary>
        /// 私有方法，视图数据更新
        /// </summary>
        /// <param name="data">初始视图</param>
        /// <returns>更新后的视图</returns>
        private ModelView.ApoActView UpdateData(ModelView.ApoActView data)
        {
            if (data.act_result!="驳回")
            {
                data.apo_finished = "是";
                data.step_finished = "是";
            }
            return data;
        }
    }
}
