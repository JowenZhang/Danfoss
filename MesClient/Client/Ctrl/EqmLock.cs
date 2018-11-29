using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Ctrl
{
    public class EqmLock
    {
        private DAO.AccessDbHelper LocalDbEngine 
        {
            get 
            {
                Ctrl.DbConStrFactory conFactory = Ctrl.DbConStrFactory.CreateInstance();
                return DAO.AccessDbHelper.CreateInstance(conFactory.GetAccessConStr("pmsAccessDb"));
            }
        }

        /// <summary>
        /// 私有的数据库基础数据引擎
        /// </summary>
        private DAO.GeneralDbEngine DbEngine
        {
            get
            {
                Ctrl.DbConStrFactory conFactory = Ctrl.DbConStrFactory.CreateInstance();
                return DAO.GeneralDbEngine.CreateInstance(conFactory.GetSqlConStr("defaultSqlDb"), conFactory.GetAccessConStr("defaultAccessDb"));
            }
        }

        public void GetEqmLock(string eqmNo)
        {
            string sql = "select 互锁设备 from 互锁设备 where 互锁状态='开启' and 本站设备=@eqmNo;";
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@eqmNo", eqmNo);
            string res = string.Empty;
            try
            {
                object obj=LocalDbEngine.QueryObj(sql, pms);
                res = (obj??string.Empty).ToString();
            }
            catch (Exception)
            {
                res = string.Empty;
            }
            try
            {
                if (!string.IsNullOrEmpty(res))
                {
                    List<Model.TableModel.Pdm_eqm> list = DbEngine.QueryList<Model.TableModel.Pdm_eqm>(string.Format("eqm_no='{0}'", res));
                    if (list == null)
                    {
                        UpdateEqmLock(eqmNo, string.Empty);
                        return;
                    }
                    if (list.Count != 1)
                    {
                        UpdateEqmLock(eqmNo, string.Empty);
                        return;
                    }
                    UpdateEqmLock(eqmNo, res);
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void UpdateEqmLock(string eqmNo,  string res)
        {
            string sql = "update pdm_eqm set eqm_lock=@eqm_lock where eqm_no=@eqm_no;";
            Dictionary<string, object> pms=new Dictionary<string,object>();
            pms.Add("@eqm_no", eqmNo);
            pms.Add("@eqm_lock", res);
            DbEngine.QueryInt(sql, pms);
        }
    }
}
