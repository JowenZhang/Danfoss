using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Client.Ctrl
{
    /// <summary>
    /// 业务数据获取类
    /// </summary>
    public class DataBllCtrl
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        private DataBllCtrl() { }

        /// <summary>
        /// 私有单例字段
        /// </summary>
        private static DataBllCtrl _dataBllCtrl = null;

        /// <summary>
        /// 线程同步标识
        /// </summary>
        private static readonly object _locker = new object();


        /// <summary>
        /// 类的单例创建函数
        /// </summary>
        /// <param name="sqlConStr">sqlServer连接字符串</param>
        /// <param name="accessConStr">access连接字符串</param>
        /// <returns>创建类的构造函数</returns>
        public static DataBllCtrl CreateInstance(string sqlConStr, string accessConStr)
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (_dataBllCtrl == null)
            {
                lock (_locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (_dataBllCtrl == null)
                    {
                        _dataBllCtrl = new DataBllCtrl();
                    }
                }
            }
            _dataBllCtrl.SqlConStr = sqlConStr;
            _dataBllCtrl.AccessConStr = accessConStr;
            return _dataBllCtrl;
        }

        /// <summary>
        /// 公有属性，Sql连接字符串
        /// </summary>
        public string SqlConStr { get; set; }

        /// <summary>
        /// 公有属性，Access连接字符串
        /// </summary>
        public string AccessConStr { get; set; }

        /// <summary>
        /// 私有属性，数据库引擎
        /// </summary>
        private DAO.GeneralDbEngine DbEngine 
        {
            get 
            {
                return DAO.GeneralDbEngine.CreateInstance(SqlConStr, AccessConStr);
            }
        }

        /// <summary>
        /// 添加质量不良记录
        /// </summary>
        /// <param name="qaRecord">要添加的质量模型</param>
        /// <returns>是否添加成功</returns>
        public bool AddQcmQaRecord(Model.TableModel.Qcm_qa_record qaRecord)
        {
            List<Model.TableModel.Qcm_qa_record> modelList = new List<Model.TableModel.Qcm_qa_record>();
            modelList.Add(qaRecord);
            return DbEngine.QueryInt<Model.TableModel.Qcm_qa_record>("Insert", modelList) > 0;
        }

        /// <summary>
        /// 添加设备停机记录
        /// </summary>
        /// <param name="dateTime">设备停机时间点</param>
        /// <param name="eqmNo">设备编号</param>
        /// <returns>添加结果</returns>
        public bool AddJamRecord(Model.TableModel.Eqm_jam_cause jamCause, string eqmNo)
        {

            DateTime dateTime = DateTime.Now;
            Model.TableModel.Eqm_jam_record jamRecord = new Model.TableModel.Eqm_jam_record();
            jamRecord.id = Common.Md5Operate.CreateGuidId();
            jamRecord.jam_cause_no = jamCause.jam_cause_no;
            jamRecord.jam_cause_name = jamCause.jam_cause_name;
            jamRecord.jam_record_no = GetNextNoByTblName("eqm_jam_record");
            jamRecord.status_name = "待处理";
            jamRecord.status_no = "500";
            jamRecord.submit_time = dateTime;
            jamRecord.submit_user_no = "worker";
            jamRecord.submit_user_name = "worker";
            jamRecord.eqm_no = eqmNo;
            jamRecord.crt_time = dateTime;
            jamRecord.crt_user_name = "worker";
            jamRecord.crt_user_no = "worker";
            jamRecord.upd_time = dateTime;
            jamRecord.upd_user_name = "worker";
            jamRecord.upd_user_no = "worker";
            List<Model.TableModel.Eqm_jam_record> modelList = new List<Model.TableModel.Eqm_jam_record>();
            modelList.Add(jamRecord);
            return DbEngine.QueryInt<Model.TableModel.Eqm_jam_record>("Insert", modelList) > 0;
        }

        /// <summary>
        /// 根据表名记录表No
        /// </summary>
        /// <param name="tblName"></param>
        /// <returns></returns>
        public string GetNextNoByTblName(string tblName)
        {
            string sqlExistTblNo = "select * from sys_tbl_no where tbl_name=@tbl_name";
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@tbl_name",tblName);
            DataTable dt = DbEngine.QueryTable(sqlExistTblNo, pms);
            int tblNo = 0;
            if (dt == null)
            {
                sqlExistTblNo = "insert into sys_tbl_no values (@id,@tbl_name,@tbl_no,@last_write_date)";
                pms.Clear();
                pms.Add("@id", Common.Md5Operate.CreateGuidId());
                pms.Add("@tbl_name", tblName);
                pms.Add("@tbl_no", "1");
                pms.Add("@last_write_date", DateTime.Now.Date);
                DbEngine.QueryInt(sqlExistTblNo, pms);
                tblNo = 1;
            }
            else 
            {
                if (dt.Rows.Count != 1)
                {
                    sqlExistTblNo = "delete from sys_tbl_no where tbl_name=@tbl_name";
                    DbEngine.QueryInt(sqlExistTblNo, pms);
                    sqlExistTblNo = "insert into sys_tbl_no values (@id,@tbl_name,@tbl_no,@last_write_date)";
                    pms.Clear();
                    pms.Add("@id", Common.Md5Operate.CreateGuidId());
                    pms.Add("@tbl_name", tblName);
                    pms.Add("@tbl_no", "1");
                    pms.Add("@last_write_date", DateTime.Now.Date);
                    DbEngine.QueryInt(sqlExistTblNo, pms);
                    tblNo = 1;
                }
                else
                {
                    string tmpNo = dt.Rows[0].Field<string>("tbl_no");
                    DateTime dtLastDate = dt.Rows[0].Field<DateTime>("last_write_date");
                    string id = dt.Rows[0].Field<string>("id");
                    if (dtLastDate.Date!=DateTime.Now.Date)
                    {
                        sqlExistTblNo = "update sys_tbl_no set tbl_no=@tbl_no,last_write_date=@last_write_date where id=@id;";
                        pms.Clear();
                        pms.Add("@id",id);
                        pms.Add("@tbl_no", "1");
                        pms.Add("@last_write_date", DateTime.Now.Date);
                        DbEngine.QueryInt(sqlExistTblNo, pms);
                        tblNo = 1;
                    }
                    else
                    {
                        sqlExistTblNo = "update sys_tbl_no set tbl_no=@tbl_no where id=@id;";
                        pms.Clear();
                        tblNo = int.TryParse(tmpNo, out tblNo) ? tblNo : 0;
                        tblNo = tblNo + 1;
                        pms.Add("@id", id);
                        pms.Add("@tbl_no", tblNo.ToString());
                        DbEngine.QueryInt(sqlExistTblNo, pms);
                    }
                }
            }
            string res = DateTime.Now.ToString("yyyyMMdd") + tblNo.ToString().PadLeft(8,'0');
            return res;
        }
    }
}
