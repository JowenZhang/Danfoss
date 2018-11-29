using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Ctrl
{
    /// <summary>
    /// 安灯处理类
    /// </summary>
    internal class Andon
    {
        #region -- 字段 --

        /// <summary>
        /// 私有的安灯模板属性
        /// </summary>
        private Model.TableModel.Adn _adn = null;

        /// <summary>
        /// 私有的数据库基础数据引擎
        /// </summary>
        private DataLoadCtrl DataLoadCtrl
        {
            get 
            {
                Ctrl.DbConStrFactory conFactory = Ctrl.DbConStrFactory.CreateInstance();
                return Ctrl.DataLoadCtrl.CreateInstance(conFactory.GetSqlConStr("defaultSqlDb"), conFactory.GetAccessConStr("defaultAccessDb"));
            }
        }

        /// <summary>
        /// 私有的数据库业务数据引擎
        /// </summary>
        private DataBllCtrl DataBllCtrl
        {
            get            
            {
                Ctrl.DbConStrFactory conFactory = Ctrl.DbConStrFactory.CreateInstance();
                return Ctrl.DataBllCtrl.CreateInstance(conFactory.GetSqlConStr("defaultSqlDb"), conFactory.GetAccessConStr("defaultAccessDb"));
            }
        }

        /// <summary>
        /// 私有的通用数据库引擎
        /// </summary>
        private DAO.GeneralDbEngine DbEngine
        {
            get 
            {
                Ctrl.DbConStrFactory conFactory = Ctrl.DbConStrFactory.CreateInstance();
                return DAO.GeneralDbEngine.CreateInstance(conFactory.GetSqlConStr("defaultSqlDb"), conFactory.GetAccessConStr("defaultAccessDb"));
            }
        }

        #endregion

        #region -- 属性 --

        /// <summary>
        /// 安灯类
        /// </summary>
        public Model.TableModel.Adn Adn
        {
            get { return _adn; }
            set { _adn = value; }
        }

        #endregion

        #region -- 构造函数 --

        /// <summary>
        /// 构造函数
        /// </summary>
        public Andon() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="andonNo">安灯编号</param>
        /// <param name="andonTypeNo">安灯类型编号</param>
        /// <param name="deptNo">部门编号</param>
        /// <param name="eqmNo">设备编号</param>
        /// <param name="callerNo">呼叫者</param>
        public Andon(string andonNo, string andonTypeNo, string deptNo, string eqmNo, string callerNo)
        {
            Adn = new Model.TableModel.Adn();
            //500--未处理510--已处理520处理中
            Adn.id = Common.Md5Operate.CreateGuidId();
            Adn.status_no = "500";
            Adn.status_name = "待处理";
            if (string.IsNullOrEmpty(andonNo))
            {
                Adn.andon_no = DataBllCtrl.GetNextNoByTblName("adn");
            }
            else
            {
                Adn.andon_no = andonNo;
            }
            Adn.andon_type_no = andonTypeNo;
            Adn.andon_type_name = DataLoadCtrl.LoadFieldByColumn("andon_type_name", "andon_type_no", andonTypeNo, "andon_type");
            Adn.andon_desc = string.Empty;
            Adn.dept_no = deptNo;
            Adn.andon_music_no = deptNo + "_" + eqmNo + "_" + ".mp3";
            Adn.eqm_no = eqmNo;
            Adn.call_user_no = callerNo;
            Adn.call_user_name = DataLoadCtrl.LoadFieldByColumn("user_name", "user_no", callerNo, "sys_user");
            Adn.call_time = DateTime.Now;
            Adn.reply_user_no = null;
            Adn.reply_user_name = null;
            Adn.reply_time = null;
            Adn.ralate_no = string.Empty;
            Adn.is_finished = false;
            Adn.play_record = DataLoadCtrl.LoadFieldByColumn("andon_play_eqm", "andon_type_no", andonTypeNo, "adn_type");
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="andonNo">安灯编号</param>
        /// <param name="andonTypeNo">安灯类型编号</param>
        /// <param name="deptNo">部门编号</param>
        /// <param name="eqmNo">工站编号</param>
        /// <param name="callerNo">呼叫者</param>
        /// <param name="ralateNo">关联编号</param>
        public Andon(string andonNo, string andonTypeNo, string deptNo, string eqmNo, string callerNo, string ralateNo)
        {
            Adn = new Model.TableModel.Adn();
            //500--未处理510--已处理520处理中
            Adn.id = Common.Md5Operate.CreateGuid();
            Adn.status_no = "500";
            Adn.status_name = "待处理";
            if (string.IsNullOrEmpty(andonNo))
            {
                Adn.andon_no = DataBllCtrl.GetNextNoByTblName("adn");
            }
            else
            {
                Adn.andon_no = andonNo;
            }
            Adn.andon_type_no = andonTypeNo;
            Adn.andon_type_name = DataLoadCtrl.LoadFieldByColumn("andon_type_name", "andon_type_no", andonTypeNo, "andon_type");
            Adn.andon_desc = string.Empty;
            Adn.dept_no = deptNo;
            Adn.andon_music_no = deptNo + "_" + eqmNo + "_" + ".mp3";
            Adn.eqm_no = eqmNo;
            Adn.call_user_no = callerNo;
            Adn.call_user_name = DataLoadCtrl.LoadFieldByColumn("user_name", "user_no", callerNo, "sys_user");
            Adn.call_time = DateTime.Now;
            Adn.reply_user_no = null;
            Adn.reply_user_name = null;
            Adn.reply_time = null;
            Adn.ralate_no = ralateNo;
            Adn.is_finished = false;
            Adn.play_record = DataLoadCtrl.LoadFieldByColumn("andon_play_eqm", "andon_type_no", andonTypeNo, "adn_type");
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="andonNo">安灯编号</param>
        /// <param name="andonTypeNo">安灯类型编号</param>
        /// <param name="deptNo">部门编号</param>
        /// <param name="eqmNo">工站编号</param>
        /// <param name="caller">呼叫者</param>
        /// <param name="ralateNo">关联编号</param>
        public Andon(string andonNo, string andonTypeNo, string deptNo, string eqmNo, Model.User_P caller, string ralateNo)
        {
            Adn = new Model.TableModel.Adn();
            Adn.id = Common.Md5Operate.CreateGuidId();
            Adn.status_no = "500";
            Adn.status_name = "待处理";
            if (string.IsNullOrEmpty(andonNo))
            {
                Adn.andon_no = DataBllCtrl.GetNextNoByTblName("adn");
            }
            else
            {
                Adn.andon_no = andonNo;
            }
            Adn.andon_type_no = andonTypeNo;
            Adn.andon_type_name = DataLoadCtrl.LoadFieldByColumn("andon_type_name", "andon_type_no", andonTypeNo, "andon_type");
            Adn.andon_desc = string.Empty;
            Adn.dept_no = deptNo;
            Adn.andon_music_no = deptNo + "_" + eqmNo + "_" + ".mp3";
            Adn.eqm_no = eqmNo;
            Adn.call_user_no = caller.UserNo;
            Adn.call_user_name = caller.UserName;
            Adn.call_time = DateTime.Now;
            Adn.reply_user_no = null;
            Adn.reply_user_name = null;
            Adn.reply_time = null;
            Adn.ralate_no = ralateNo;
            Adn.is_finished = false;
            Adn.play_record = DataLoadCtrl.LoadFieldByColumn("andon_play_eqm", "andon_type_no", andonTypeNo, "adn_type");
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="andonNo">安灯编号</param>
        /// <param name="andonTypeNo">安灯类型编号</param>
        /// <param name="deptNo">部门编号</param>
        /// <param name="eqmNo">工站编号</param>
        /// <param name="caller">呼叫者</param>
        public Andon(string andonNo, string andonTypeNo, string deptNo, string eqmNo, Model.User_P caller)
        {
            Adn = new Model.TableModel.Adn();
            Adn.id = Common.Md5Operate.CreateGuidId();
            Adn.status_no = "500";
            Adn.status_name = "待处理";
            if (string.IsNullOrEmpty(andonNo))
            {
                Adn.andon_no = DataBllCtrl.GetNextNoByTblName("adn");
            }
            else
            {
                Adn.andon_no = andonNo;
            }
            Adn.andon_type_no = andonTypeNo;
            Adn.andon_type_name = DataLoadCtrl.LoadFieldByColumn("andon_type_name", "andon_type_no", andonTypeNo, "adn_type");
            Adn.andon_desc = string.Empty;
            Adn.dept_no = deptNo;
            Adn.andon_music_no = FormatFileName(deptNo + "_" + eqmNo + ".mp3");
            Adn.eqm_no = eqmNo;
            Adn.call_user_no = "Server";//caller.UserNo;
            Adn.call_user_name = "Server"; //caller.UserName;
            Adn.call_time = DateTime.Now;
            Adn.reply_user_no = null;
            Adn.reply_user_name = null;
            Adn.reply_time = null;
            Adn.ralate_no = string.Empty;
            Adn.is_finished = false;
            Adn.play_record = DataLoadCtrl.LoadFieldByColumn("andon_play_eqm", "andon_type_no", andonTypeNo, "adn_type");
        }
        #endregion

        /// <summary>
        /// 通过工站获取安灯编号
        /// </summary>
        /// <param name="eqmNo">工位编号</param>
        public void GetAdn(string eqmNo)
        {
            List<Model.TableModel.Adn> List = DataLoadCtrl.LoadAdn(string.Format("eqm_no='{0}' and is_finished='false' order by call_time asc;", eqmNo));
            if (List != null && List.Count > 0)
            {
                Adn = List[0];
            }
            else
            {
                Adn = new Model.TableModel.Adn();
            }
        }

        /// <summary>
        /// 通过编号获取安灯编号
        /// </summary>
        /// <param name="andonNo">安灯编号</param>
        public void GetAdnByNo(string andonNo)
        {
            List<Model.TableModel.Adn> List = DataLoadCtrl.LoadAdn(string.Format("andon_no='{0}';", andonNo));
            if (List != null && List.Count > 0)
            {
                Adn = List[0];
            }
            else
            {
                Adn = new Model.TableModel.Adn();
            }
        }

        /// <summary>
        /// 安灯下一步
        /// </summary>
        /// <param name="userNo">用户编号</param>
        /// <param name="eqmNo">设备编号</param>
        /// <param name="andonNo">安灯编号</param>
        /// <returns>返回状态</returns>
        public string NextStep(string userNo, string eqmNo, string andonNo = "")
        {
            string status = string.Empty;
            if (string.IsNullOrEmpty(andonNo))
            {
                GetAdn(eqmNo);
            }
            GetAdnByNo(andonNo);
            if (Adn.status_no == "510")
            {
                status = Adn.status_no;
            }
            else
            {                
                if (string.IsNullOrEmpty(userNo))
                {
                    Adn.reply_user_no = "Server";
                    Adn.reply_user_name = "Server";
                }
                else
                {
                    string userName = DataLoadCtrl.LoadFieldByColumn("user_name", "user_no", userNo, "sys_user");
                    Adn.reply_user_no = userNo;
                    Adn.reply_user_name = userName;
                }
                ProcessEqmAndQC(Adn.status_no, Adn.andon_type_no, Adn.eqm_no, Adn.reply_user_no, Adn.reply_user_name, DateTime.Now);
                switch (Adn.status_no)
                {
                    case "500":
                        Adn.status_no = "520";
                        Adn.status_name = "处理中";
                        status = "520";                        
                        break;
                    case "520":
                        Adn.reply_time = DateTime.Now;
                        Adn.is_finished = true;
                        Adn.status_no = "510";
                        Adn.status_name = "已处理";
                        status = "510";
                        break;
                    default:
                        status = "510";
                        break;
                }
                List<Model.TableModel.Adn> list = new List<Model.TableModel.Adn>() { Adn };
                int t = DbEngine.QueryInt<Model.TableModel.Adn>("Update", list);
                if (t <= 0)
                {
                    status = "510";
                }
            }
            return status;
        }

        /// <summary>
        /// 新增安灯
        /// </summary>
        /// <returns></returns>
        public string NewAndon()
        {
            string res = "510";
            if (Adn != null)
            {
                List<Model.TableModel.Adn> list = new List<Model.TableModel.Adn>() { Adn };
                int t = DbEngine.QueryInt<Model.TableModel.Adn>("Insert", list);
                if (t > 0)
                {
                    res = Adn.status_no;
                }
                if (Adn.andon_type_no=="01")
                {
                    string sqlEqm = string.Format("update pdm_eqm set eqm_status='故障' where eqm_no='{0}'", Adn.eqm_no);
                    DbEngine.QueryInt(sqlEqm);
                }
                return Adn.status_no;
            }
            return res;
        }

        /// <summary>
        /// 文件名格式化:剔除? * : " < > \ / |
        /// </summary>
        /// <param name="fileName">不规范的文件名</param>
        /// <returns>规范文件名</returns>
        private string FormatFileName(string fileName)
        {
            return fileName.Replace("?", "").Replace("*", "").Replace(":", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("/", "").Replace("\\", "").Replace("|", "");
        }

        /// <summary>
        /// 安灯推进
        /// </summary>
        /// <param name="adnStatus">安灯状态</param>
        /// <param name="adnType">安灯类型</param>
        /// <param name="eqmNo">设备编号</param>
        /// <param name="userNo">用户编号</param>
        /// <param name="userName">用户姓名</param>
        /// <param name="dateTime">时间</param>
        private void ProcessEqmAndQC(string adnStatus, string adnType, string eqmNo, string userNo, string userName, DateTime? dateTime)
        {
            string sqlAdn = string.Empty;
            string sqlEqm = string.Empty;
            string replyTime = (dateTime ?? DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss.fff");
            switch (adnStatus)
            {
                case "500":
                    if (adnType == "01")
                    {                         //设备
                        sqlAdn = string.Format("update eqm_jam_record set status_no='520',status_name='处理中',reply_user_no='{0}',reply_user_name='{1}',reply_time='{2}' where status_no ='500' and eqm_no='{3}' and submit_time=(select min(submit_time) from eqm_jam_record where status_no ='500' and eqm_no='{3}');", userNo, userName, replyTime, eqmNo);
                        sqlEqm = string.Format("update pdm_eqm set eqm_status='维修' where eqm_no='{0}'", eqmNo);
                    }
                    if (adnType == "04")
                    {    //质量
                        sqlAdn = string.Format("update qcm_qa_record set status_no='520',status_name='处理中',solve_user_no='{0}', solve_user_name='{1}',solve_time='{2}' where eqm_no='{3}' and submit_time=(select min(submit_time) from qcm_qa_record where status_no='500' and eqm_no='{3}') and status_no='500';", userNo, userName, replyTime, eqmNo);
                    }
                    break;
                case "520":
                    if (adnType == "01")
                    {                         //设备
                        sqlAdn = string.Format("update eqm_jam_record set status_no='510',status_name='已处理',reply_user_no='{0}',reply_user_name='{1}',reply_time='{2}' where status_no ='520' and eqm_no='{3}' and submit_time=(select min(submit_time) from eqm_jam_record where status_no ='520' and eqm_no='{3}');", userNo, userName, replyTime, eqmNo);
                        sqlEqm = string.Format("update pdm_eqm set eqm_status='正常' where eqm_no='{0}'", eqmNo);
                    }
                    if (adnType == "04")
                    {    //质量
                        sqlAdn = string.Format("update qcm_qa_record set status_no='510',status_name='已处理',solve_user_no='{0}', solve_user_name='{1}',solve_time='{2}' where eqm_no='{3}' and submit_time=(select min(submit_time) from qcm_qa_record where status_no='520' and eqm_no='{3}') and status_no='520';", userNo, userName, replyTime, eqmNo);
                    }
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(sqlAdn))
            {
                DbEngine.QueryInt(sqlAdn);
            }
            if (!string.IsNullOrEmpty(sqlEqm))
            {
                DbEngine.QueryInt(sqlEqm);
            }
            return;
        }
    }
}
