using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Client.Ctrl
{
    /// <summary>
    /// 数据加载类的控制
    /// </summary>
    public class DataLoadCtrl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        private DataLoadCtrl() { }

        /// <summary>
        /// 私有单例字段
        /// </summary>
        private static DataLoadCtrl _dataLoadCtrl = null;

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
        public static DataLoadCtrl CreateInstance(string sqlConStr, string accessConStr)
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (_dataLoadCtrl == null)
            {
                lock (_locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (_dataLoadCtrl == null)
                    {
                        _dataLoadCtrl = new DataLoadCtrl();
                    }
                }
            }
            _dataLoadCtrl.SqlConStr = sqlConStr;
            _dataLoadCtrl.AccessConStr = accessConStr;
            return _dataLoadCtrl;
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
        /// 获取设备停机原因
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<Model.TableModel.Eqm_jam_cause> GetEqmJamCause(string where = null)
        {
            return DbEngine.QueryList<Model.TableModel.Eqm_jam_cause>(where);
        }

        /// <summary>
        /// 获取质量异常原因
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<Model.TableModel.Qcm_qa_cause> GetQcmQaCause(string where = null)
        {
            return DbEngine.QueryList<Model.TableModel.Qcm_qa_cause>(where);
        }

        /// <summary>
        /// 根据表的列值获取对应目标字段值
        /// </summary>
        /// <param name="field">目标字段</param>
        /// <param name="colName">列名</param>
        /// <param name="value">参数值</param>
        /// <param name="tblName">表名</param>
        /// <returns>目标字段值</returns>
        public string LoadFieldByColumn(string field, string colName, object value, string tblName)
        {
            if (value == null)
            {
                return "UNKNOWN";
            }
            StringBuilder sql = new StringBuilder();
            sql.Append("select top 1 ");
            sql.Append(field);
            sql.Append(" from ");
            sql.Append(tblName);
            sql.Append(" where ");
            sql.Append(colName);
            sql.Append(" =@");
            sql.Append(colName);
            sql.Append(";");
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@" + colName, value);
            return (DbEngine.QueryObj(sql.ToString(), pms) ?? "UNKNOWN").ToString();
        }

        /// <summary>
        /// 加载故障记录//新界面
        /// </summary>
        /// <param name="where">where条件</param>
        /// <returns>设备故障记录列表</returns>
        public List<Model.TableModel.Eqm_jam_record> LoadEqmJamRecordNew(string where)
        {
            return DbEngine.QueryList<Model.TableModel.Eqm_jam_record>(where);
        }

        /// <summary>
        /// 获取维修保养记录
        /// </summary>
        /// <param name="where">过滤条件</param>
        /// <returns>查询到保养记录列表</returns>
        public List<Model.TableModel.DStbl_Maintain_Basic> LoadMaintainInfo(string where)
        {
            return DbEngine.QueryList<Model.TableModel.DStbl_Maintain_Basic>(where);
        }

        /// <summary>
        /// 获取质量不良原因记录
        /// </summary>
        /// <param name="eqmNo">工位编号</param>
        /// <returns>不良原因记录表</returns>
        public DataTable LoadQcmRecordAll(string eqmNo)
        {
            string sql = string.Format("select mpo_no,serial_no,qa_cause_name,qa_record_no from qcm_qa_record where status_no='510' and eqm_no='{0}'", eqmNo);
            return DbEngine.QueryTable(sql);
        }

        /// <summary>
        /// 加载生产备件
        /// </summary>
        /// <param name="where">过滤条件</param>
        /// <returns>生产备件信息表</returns>
        public DataTable LoadPartBackup(string where)
        {
            string sql = "select DanfossNo, PartName, Description,Qty,UnitPrice, PartsManufacturer,Sizes, MakeDate,Remark from DStbl_Part ";
            if (!string.IsNullOrEmpty(where))
            {
                sql += where;
            }
            return DbEngine.QueryTable(sql);
        }

        /// <summary>
        /// 加载设备信息
        /// </summary>
        /// <returns>设备信息表</returns>
        public DataTable LoadEqm()
        {
            string sql = "select eqm_no,eqm_name from pdm_eqm order by eqm_index asc";
            return DbEngine.QueryTable(sql);
        }

        /// <summary>
        /// 加载安灯状态
        /// </summary>
        /// <param name="eqm_no">工位编号</param>
        /// <returns>安灯状态值</returns>
        public string LoadAdnStatus(string eqm_no)
        {
            string sql = string.Format("select top 1 status_no from adn where eqm_no='{0}' and is_finished='false' order by call_time;", eqm_no);
            return (DbEngine.QueryObj(sql) ?? "510").ToString();
        }

        /// <summary>
        /// 加载安灯列表
        /// </summary>
        /// <param name="where">where条件</param>
        /// <returns>返回安灯列表</returns>
        public List<Model.TableModel.Adn> LoadAdn(string where)
        {
            return DbEngine.QueryList<Model.TableModel.Adn>(where);
        }

        public Model.TableModel.Dms_file GetDmsFile(string fileNo)
        {
            if (string.IsNullOrEmpty(fileNo))
            {
                return null;
            }
            List<Model.TableModel.Dms_file> list = DbEngine.QueryList<Model.TableModel.Dms_file>(string.Format("file_no='{0}'", fileNo));
            if (list == null)
            {
                return null;
            }
            if (list.Count != 1)
            {
                return null;
            }
            return list[0];
        }
    }
}
