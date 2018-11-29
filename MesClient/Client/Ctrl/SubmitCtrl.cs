using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Client.Ctrl
{
    /// <summary>
    /// 报工类
    /// </summary>
    public class SubmitCtrl
    {
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

        /// <summary>
        /// 私有的Access数据库引擎
        /// </summary>
        private DAO.AccessDbHelper DbAccessEngine
        {
            get
            {
                Ctrl.DbConStrFactory conFactory = Ctrl.DbConStrFactory.CreateInstance();
                return DAO.AccessDbHelper.CreateInstance(conFactory.GetAccessConStr("defaultAccessDb"));
            }
        }

        /// <summary>
        /// 查询历史报工中最大的Access报工ID
        /// </summary>
        /// <param name="eqmNo"></param>
        /// <returns>MaxId</returns>
        public long GetMaxId(string eqmNo)
        {
            string sql = "select Max(in_id) from mes_fb_item where eqm_no=@eqm_no;";
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@eqm_no", eqmNo);
            string tmp = (DbEngine.QueryObj(sql, pms) ?? "-1").ToString();
            long longTmp = -1L;
            return long.TryParse(tmp, out longTmp) ? longTmp : -1L;
        }

        /// <summary>
        /// 查询待报工记录中最大的报工ID
        /// </summary>
        /// <returns>MaxId</returns>
        public long GetMaxId()
        {
            Ctrl.DbConStrFactory conFactory = Ctrl.DbConStrFactory.CreateInstance();
            DAO.AccessDbHelper dbAccessEngine = DAO.AccessDbHelper.CreateInstance(conFactory.GetAccessConStr("dataAccessDb"));
            string sql = "select Max(ID) from data;";
            string tmp = (dbAccessEngine.QueryObj(sql) ?? "-1").ToString();
            long longTmp = -1L;
            return long.TryParse(tmp, out longTmp) ? longTmp : -1L;
        }

        /// <summary>
        /// 获取当前编号及报工信息
        /// </summary>
        /// <param name="lastId">sql表内最后报工记录</param>
        /// <param name="maxId">access表内最大的报工ID</param>
        /// <param name="eqmNo">设备ID</param>
        /// <returns>报工信息</returns>
        public Model.ProductBarcode GetCurrentSubmitRecord(long lastId, long maxId, string eqmNo)
        {
            Ctrl.DbConStrFactory conFactory = Ctrl.DbConStrFactory.CreateInstance();
            DAO.AccessDbHelper dbAccessEngine = DAO.AccessDbHelper.CreateInstance(conFactory.GetAccessConStr("dataAccessDb"));
            DataTable dt = new DataTable();
            string sqlStr = "select * from Data where ID=(select min(ID) from Data where ID>@ID);";
            Dictionary<string, object> pms = new Dictionary<string, object>();
            while (dt.Rows.Count != 1)
            {
                pms.Add("@ID", lastId);
                dt = dbAccessEngine.QueryTable(sqlStr, pms);
                if (lastId >= maxId)
                {
                    if (dt.Rows.Count <= 0)
                    {
                        sqlStr = "select * from Data where ID=(select Max(ID) from Data);";
                        dt = dbAccessEngine.QueryTable(sqlStr);
                    }
                    break;
                }
                lastId++;
            }
            DataRow dr = dt.Rows[0];
            return ChangeDataRowToObject(dr, eqmNo);
        }

        /// <summary>
        /// 将数据行转换为序列号实体类
        /// </summary>
        /// <param name="dr">数据行</param>
        /// <param name="eqmNo">设备编号</param>
        /// <returns>报工信息</returns>
        public Model.ProductBarcode ChangeDataRowToObject(DataRow dr, string eqmNo)
        {            
            Model.ProductBarcode barcode = new Model.ProductBarcode();
            barcode.SubmitInfo = new List<Model.TableModel.Mes_fb_info>();
            DataTable dt = dr.Table;            
            for (int i = 0; i < dr.ItemArray.Count(); i++)
            {
                switch (dt.Columns[i].ColumnName)
                {
                    case "ID":
                        barcode.ID = long.Parse((dr["ID"] ?? "0").ToString());
                        break;
                    case "生产日期":
                        barcode.ProductDate = (dr["生产日期"] ?? DateTime.Now.Date).ToString(); ;
                        break;
                    case "生产时间":
                        barcode.ProductTime = (dr["生产时间"] ?? "00:00:00").ToString();
                        break;
                    case "产品型号":
                        barcode.ProductTypeNo = (dr["产品型号"] ?? "TypeNo").ToString();
                        break;
                    case "产品序列号":
                        barcode.ProductSerialNo = (dr["产品序列号"] ?? "VirtualSerialNo").ToString();
                        string mpoNo = DataLoadCtrl.LoadFieldByColumn("mpo_no", "serial_no", barcode.ProductSerialNo, "mpo_item");
                        barcode.MpoNo = mpoNo == "UNKNOWN" ? "VirtualMpoNo" : mpoNo;
                        break;
                    case "操作者":
                        barcode.User = (dr["操作者"] ?? "Server").ToString();
                        break;
                    case "判定":
                        barcode.Result = (dr["判定"] ?? "NG").ToString().ToLower() == "ok" ? "OK" : "NG";
                        break;
                    default:
                        Model.TableModel.Mes_fb_info model = new Model.TableModel.Mes_fb_info();
                        model.id = Common.Md5Operate.CreateGuidId();
                        model.serial_no = string.IsNullOrEmpty(barcode.ProductSerialNo) ? "VirtualSerialNo" : barcode.ProductSerialNo;
                        model.eqm_no = eqmNo;
                        model.part_no = barcode.ProductTypeNo;
                        model.information = dt.Columns[i].ColumnName;
                        model.information_value = (dr[dt.Columns[i].ColumnName] ?? string.Empty).ToString();
                        DateTime dtTmp = DateTime.Now;
                        model.create_time = string.IsNullOrEmpty(barcode.ProductDate + " " + barcode.ProductTime) ? DateTime.Now : DateTime.TryParse(barcode.ProductDate + " " + barcode.ProductTime, out dtTmp) ? dtTmp : DateTime.Now;
                        barcode.SubmitInfo.Add(model);
                        break;
                }
            }
            if (string.IsNullOrEmpty(barcode.ProductSerialNo))
            {
                barcode.ProductSerialNo = "VirtualSerialNo";
            }
            long serialId = GetLastInId4SerialNo(string.IsNullOrEmpty(barcode.ProductSerialNo) ? "SerialNo" : barcode.ProductSerialNo, eqmNo);
            barcode.SerialNoExist = serialId > 0;
            barcode.IsLastSubmit = serialId == barcode.ID;
            barcode.User = string.IsNullOrEmpty(barcode.User) ? "Server" : barcode.User;
            barcode.MpoNo = string.IsNullOrEmpty(barcode.MpoNo) ? "VirtualMpoNo" : barcode.MpoNo;
            return barcode;
        }

        /// <summary>
        /// 判定列是否存在
        /// </summary>
        /// <param name="dr">数据行</param>
        /// <param name="colName">列名</param>
        /// <returns>判定结果</returns>
        public bool ColumnExist(DataRow dr, string colName)
        {
            DataTable dt = dr.Table;
            foreach (DataColumn dc in dt.Columns)
            {
                if (dc.ColumnName == colName)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取这一序列号中的最后一条报工记录的ID
        /// </summary>
        /// <param name="serialNo">序列号</param>
        /// <param name="eqmNo">设备编号</param>
        /// <returns>这一序列号中的最后一条报工记录的ID，若不存在为-1</returns>
        public long GetLastInId4SerialNo(string serialNo, string eqmNo)
        {
            string sql = "select in_id from mes_fb_item where serial_no=@serial_no and eqm_no=@eqm_no";
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@serial_no", serialNo);
            pms.Add("@eqm_no", eqmNo);
            string tmpStr = (DbEngine.QueryObj(sql, pms) ?? "-1").ToString();
            long count = -1;
            long.TryParse(tmpStr, out count);
            return count;
        }

        /// <summary>
        /// 报工记录提交并将新提交的报工记录返回
        /// </summary>
        /// <param name="barcode">记录信息</param>
        /// <param name="eqmNo">设备编号</param>
        /// <returns>报工记录</returns>
        public Model.TableModel.Mes_fb SubmitMesFb(Model.ProductBarcode barcode, string eqmNo)
        {
            if (barcode==null)
            {
                return null;
            }
            //如果上次报过工，就不报了
            if (barcode.IsLastSubmit)
            {
                return null;
            }//一定不是上一次报工的记录
            DateTime actTime=DateTime.Now;
            actTime=DateTime.TryParse(barcode.ProductDate+" "+barcode.ProductTime,out actTime)?actTime:DateTime.Now;
            string userNo = barcode.User;
            string tmpUser = DataLoadCtrl.LoadFieldByColumn("worker_no", "worker_name", barcode.User, "mes_worker");
            userNo=tmpUser == "UNKNOWN" ? userNo : tmpUser;
            if (barcode.SerialNoExist)//该序列号存在，这个序列号必定存在报工记录
            {
                Model.TableModel.Mes_fb_item mesFbItem = GetMesFbItem(barcode.ProductSerialNo, eqmNo);
                Model.TableModel.Mes_fb mesFb = GetMesFb(barcode.MpoNo, eqmNo);
                Model.TableModel.Mpo mpo = GetMpo(barcode.MpoNo);
                if (mesFbItem==null||mesFb==null||mpo==null)
                {
                    return null;    
                }
                string result = mesFbItem.quality_no == "QA01" ? "OK" : "NG";
                if (result != barcode.Result)
                {
                    if (barcode.Result == "OK")
                    {
                        mesFb.fb_end_qty_ok += 1;
                        mesFb.fb_end_qty_ng -= 1;                        
                        mesFbItem.quality_no = "QA01";
                        if (IsLastEqm(eqmNo))
                        {
                            mpo.procedure_finished_qty += 1;
                        }
                    }
                    else
                    {
                        mesFb.fb_end_qty_ok -= 1;
                        mesFb.fb_end_qty_ng += 1;
                        mesFbItem.quality_no = "QA04";
                        if (IsLastEqm(eqmNo))
                        {
                            mpo.procedure_finished_qty -= 1;
                        }
                    }
                    if (mpo.mpo_qty<=mpo.procedure_finished_qty)
                    {
                        mpo.procedure_status_name = "已完工";
                    }                    
                }
                mesFb.upd_time = actTime;
                mesFb.upd_user_name = barcode.User;
                mesFb.upd_user_no = userNo;
                mesFb.fb_end_datetime = actTime;
                mesFb.worker_no = userNo;
                mesFb.worker_name = barcode.User;
                mesFb.fb_time = actTime;
                mesFbItem.upd_time = actTime;
                mesFbItem.upd_user_name = barcode.User;
                mesFbItem.upd_user_no = userNo;
                mesFbItem.fb_datetime = actTime;
                mesFbItem.worker_no = userNo;
                mesFbItem.worker_name = barcode.User;
                mesFbItem.in_id = barcode.ID;
                int b=DbEngine.QueryInt<Model.TableModel.Mes_fb>("update", new List<Model.TableModel.Mes_fb>() { mesFb });
                if (b>0)
                {
                    b = DbEngine.QueryInt<Model.TableModel.Mes_fb_item>("update", new List<Model.TableModel.Mes_fb_item>() { mesFbItem });
                    if (b>0)
                    {
                        b=DbEngine.QueryInt<Model.TableModel.Mes_fb_info>("insert", barcode.SubmitInfo);
                        if (b>0)
                        {
                            DbEngine.QueryInt<Model.TableModel.Mpo>("update", new List<Model.TableModel.Mpo>() { mpo });
                        }
                    }
                }
            }
            else //序列号不存在，则一定不存在报工记录
            {
                bool isNeedUpdateMpo = true;
                //检测生产订单号
                Model.TableModel.Mpo mpo = GetMpo(barcode.MpoNo);
                if (mpo == null)
                {
                    isNeedUpdateMpo = false;
                    mpo = new Model.TableModel.Mpo();
                    mpo.id = "virtualMpo";
                    mpo.mpo_no = barcode.MpoNo;
                    mpo.part_no = barcode.ProductTypeNo;
                    mpo.mpo_qty = 0;
                    mpo.mpo_hope_start_datetime = DateTime.Now;
                    mpo.mpo_hope_end_datetime = DateTime.Now;
                    mpo.commit_status_no = "310";
                    mpo.commit_status_name = "已下发";
                    mpo.procedure_finished_qty = 0;
                    mpo.procedure_status_name = "已开工";
                }
                Model.TableModel.Mes_fb mesFb = new Model.TableModel.Mes_fb();
                mesFb.id = Common.Md5Operate.CreateGuidId();
                mesFb.status_no = "310";
                mesFb.status_name = "已确认";
                mesFb.crt_time = actTime;
                mesFb.crt_user_name = barcode.User;
                mesFb.crt_user_no = userNo;
                mesFb.upd_time = actTime;
                mesFb.upd_user_name = barcode.User;
                mesFb.upd_user_no = userNo;
                mesFb.fb_no = DataBllCtrl.GetNextNoByTblName("mes_fb");
                mesFb.mpo_no = mpo.mpo_no;
                mesFb.part_no = barcode.ProductTypeNo;
                mesFb.fb_start_datetime = actTime;
                mesFb.fb_end_datetime = actTime;
                if (barcode.Result == "OK")
                {
                    mesFb.fb_end_qty_ok = 1;
                    if (IsLastEqm(eqmNo))
                    {
                        mpo.procedure_finished_qty += 1;
                    }
                }
                else
                {
                    mesFb.fb_end_qty_ng = 1;
                }
                mesFb.worker_no = userNo;
                mesFb.worker_name = barcode.User;
                mesFb.fb_time = actTime;
                mesFb.eqm_no = eqmNo;
                mesFb.eqm_name = DataLoadCtrl.LoadFieldByColumn("eqm_name", "eqm_no", eqmNo, "pdm_eqm");
                mesFb.factory_no = "dfs_f";
                Model.TableModel.Mes_fb_item mesFbItem = new Model.TableModel.Mes_fb_item();
                mesFbItem.id = Common.Md5Operate.CreateGuidId();
                mesFbItem.status_no = "310";
                mesFbItem.status_name = "已确认";
                mesFbItem.crt_time = actTime;
                mesFbItem.crt_user_name = barcode.User;
                mesFbItem.crt_user_no = userNo;
                mesFbItem.upd_time = actTime;
                mesFbItem.upd_user_name = barcode.User;
                mesFbItem.upd_user_no = userNo;
                mesFbItem.fb_item_no = DataBllCtrl.GetNextNoByTblName("mes_fb_item");
                mesFbItem.serial_no = barcode.ProductSerialNo;
                mesFbItem.fb_no = mesFb.fb_no;
                mesFbItem.mpo_no = mpo.mpo_no;
                mesFbItem.part_no = barcode.ProductTypeNo;
                mesFbItem.fb_datetime = actTime;
                mesFbItem.quality_no = barcode.Result == "OK" ? "QA01" : "QA04";
                mesFbItem.worker_no = userNo;
                mesFbItem.worker_name = barcode.User;
                mesFbItem.eqm_no = eqmNo;
                mesFbItem.eqm_name = mesFb.eqm_name;
                mesFbItem.wkc_no = "PSH On BYD";
                mesFbItem.wkc_name = "PSH On BYD生产线";
                mesFbItem.in_id = barcode.ID;
                int b = DbEngine.QueryInt<Model.TableModel.Mes_fb>("insert", new List<Model.TableModel.Mes_fb>() { mesFb });
                if (b > 0)
                {
                    b = DbEngine.QueryInt<Model.TableModel.Mes_fb_item>("insert", new List<Model.TableModel.Mes_fb_item>() { mesFbItem });
                    if (b > 0)
                    {
                        b = DbEngine.QueryInt<Model.TableModel.Mes_fb_info>("insert", barcode.SubmitInfo);
                        if (b > 0 && isNeedUpdateMpo)
                        {
                            DbEngine.QueryInt<Model.TableModel.Mpo>("update", new List<Model.TableModel.Mpo>() { mpo });
                        }
                    }
                }
            }
            return null;
        }

        

        /// <summary>
        /// 报工
        /// </summary>
        /// <param name="eqmNo">设备编号</param>
        /// <returns>报工信息</returns>
        public Model.ProductBarcode Submit(string eqmNo)
        {
            long sqlLast = GetMaxId(eqmNo);
            long accessLast = GetMaxId();
            Model.ProductBarcode barcode = GetCurrentSubmitRecord(sqlLast, accessLast, eqmNo);
            SubmitMesFb(barcode, eqmNo);
            return barcode;
        }

        /// <summary>
        /// 根据生产单号获取报工的生产订单
        /// </summary>
        /// <param name="mpoNo">生产单号</param>
        /// <param name="eqmNo">设备编号</param>
        /// <returns>报工记录主单</returns>
        public Model.TableModel.Mes_fb GetMesFb(string mpoNo,string eqmNo)
        {
            List<Model.TableModel.Mes_fb> list = DbEngine.QueryList<Model.TableModel.Mes_fb>(string.Format("mpo_no='{0}' and eqm_no='{1}'", mpoNo,eqmNo));
            if (list == null)
            {
                return null;
            }
            if (list.Count <= 0)
            {
                return null;
            }
            return list[0];
        }

        /// <summary>
        /// 根据序列号获取报工的生产单序列详情
        /// </summary>
        /// <param name="serialNo">生产单号</param>
        /// <param name="eqmNo">设备编号</param>
        /// <returns>报工记录主单</returns>
        public Model.TableModel.Mes_fb_item GetMesFbItem(string serialNo,string eqmNo)
        {
            List<Model.TableModel.Mes_fb_item> list = DbEngine.QueryList<Model.TableModel.Mes_fb_item>(string.Format("serial_no='{0}' and eqm_no='{1}'", serialNo,eqmNo));
            if (list == null)
            {
                return null;
            }
            if (list.Count <= 0)
            {
                return null;
            }
            return list[0];
        }

        /// <summary>
        /// 根据生产单号获取生产单信息
        /// </summary>
        /// <param name="mpoNo">生产单号</param>
        /// <returns>生产订单</returns>
        public Model.TableModel.Mpo GetMpo(string mpoNo)
        {
            List<Model.TableModel.Mpo> list = DbEngine.QueryList<Model.TableModel.Mpo>(string.Format("mpo_no='{0}'", mpoNo));
            if (list == null)
            {
                return null;
            }
            if (list.Count <= 0)
            {
                return null;
            }
            return list[0];
        }

        /// <summary>
        /// 私有函数，判断给定工位是否为最后一个工位
        /// </summary>
        /// <param name="eqmNo">给定工位</param>
        /// <returns>是否为最后工位</returns>
        private bool IsLastEqm(string eqmNo)
        {
            string sql = "select eqm_no from pdm_eqm where eqm_index=(select max(eqm_index) from pdm_eqm);";
            return (DbEngine.QueryObj(sql) ?? string.Empty).ToString() == eqmNo;
        }
    }
}
