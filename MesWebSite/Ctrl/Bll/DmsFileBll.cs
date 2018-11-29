using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl.Bll
{
    /// <summary>
    /// 文件业务类
    /// </summary>
    public class DmsFileBll
    {
        /// <summary>
        /// 设定文件生效日期
        /// </summary>
        /// <param name="fileView"></param>
        /// <param name="dateStr">生效起始日期字符串</param>
        /// <returns></returns>
        public string SetValidDate(ModelView.DmsFileView fileView, string dateStr)
        {
            if (fileView == null)
            {
                return "无法设定目标文件为空的文件生效日期";
            }
            DmsFileCtrl dmsFileCtrl = new DmsFileCtrl();
            List<ModelView.DmsFileView> list = dmsFileCtrl.GetList(fileView.file_no, fileView.eqm_no, fileView.file_type_no);
            DateTime dtTmp = DateTime.Now;
            DateTime dtStart = (DateTime.TryParse(dateStr, out dtTmp) ? dtTmp : DateTime.Now).Date;
            DateTime dtStop = dtStart - new TimeSpan(0, 0, 1);
            string validDateStart = dtStart.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string validDateEnd = dtStop.ToString("yyyy-MM-dd HH:mm:ss.fff");
            List<ModelView.DmsFileView> list2Update = new List<ModelView.DmsFileView>();
            foreach (ModelView.DmsFileView item in list)
            {
                item.valid_date_end = validDateEnd;
                list2Update.Add(item);
            }
            fileView.valid_date_start = validDateStart;
            list2Update.Add(fileView);
            return dmsFileCtrl.Update(list2Update) > 0 ? "success" : "生效日期数据写入失败！";
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileView">文件视图</param>
        /// <returns>删除结果</returns>
        public string DeleteFile(ModelView.DmsFileView fileView)
        {
            if (fileView == null)
            {
                return "操作目标对象为空！";
            }
            ApoActCtrl apoActCtrl = new ApoActCtrl();
            bool b = apoActCtrl.DeleteByRalate(fileView.file_no) > 0;
            if (b)
            {
                DmsFileCtrl dmsFileCtrl = new DmsFileCtrl();
                b = dmsFileCtrl.Delete(fileView) > 0;
                if (b)
                {
                    FtpBll ftpBll = new FtpBll();
                    //配置信息读取
                    string ftpHostIp = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "ftpHost", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml");
                    string ftpRelativePath = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "mainFtpPath", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml");
                    string ftpBackupPath = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "backupFtpPath", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml");
                    string writeUserNo = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "writeUserNo", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml");
                    string writeUserPwd = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "writeUserPwd", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml");
                    string readUserNo = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "readUserNo", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml");
                    string readUserPwd = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "readUserPwd", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml");
                    string tmpPath = AppDomain.CurrentDomain.BaseDirectory + "Tmp";
                    string res = ftpBll.FtpDelete(ftpRelativePath, ftpHostIp, writeUserNo, writeUserPwd, fileView);
                    return res;
                }
                else
                {
                    return "文件记录删除失败！";
                }
            }
            else
            {
                return "删除动作记录失败！";
            }
        }
    }
}
