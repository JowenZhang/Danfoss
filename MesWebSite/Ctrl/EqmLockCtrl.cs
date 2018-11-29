using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 设备锁定视图操作类
    /// </summary>
    public class EqmLockCtrl:ICtrlOperate
    {
        /// <summary>
        /// 私有字段，数据库引擎
        /// </summary>
        private DAO.SqlServerHelper _dbEngine = DAO.SqlServerHelper.CreateInstance(Common.ConfigHelper.GetConfigValueFromXml("connectionStr", "dfsDb", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml"));

        /// <summary>
        /// 私有属性，数据库引擎
        /// </summary>
        private DAO.SqlServerHelper DbEngine
        {
            get
            {
                return _dbEngine;
            }
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="jsonStr">新插入的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Insert(string jsonStr)
        {
            ModelView.EqmLockView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.EqmLockView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.EqmLockView newValue)
        {
            Model.TableModel.Pdm_eqm model = View2Model(newValue);
            List<Model.TableModel.Pdm_eqm> modelList = new List<Model.TableModel.Pdm_eqm>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Pdm_eqm>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.EqmLockView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.EqmLockView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.EqmLockView newValue)
        {
            Model.TableModel.Pdm_eqm model = View2Model(newValue);
            List<Model.TableModel.Pdm_eqm> modelList = new List<Model.TableModel.Pdm_eqm>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Pdm_eqm>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.EqmLockView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.EqmLockView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.EqmLockView oldValue)
        {
            Model.TableModel.Pdm_eqm model = View2Model(oldValue);
            List<Model.TableModel.Pdm_eqm> modelList = new List<Model.TableModel.Pdm_eqm>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Pdm_eqm>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.EqmLockView> oldValues)
        {
            List<Model.TableModel.Pdm_eqm> modelList = new List<Model.TableModel.Pdm_eqm>();
            foreach (ModelView.EqmLockView item in oldValues)
            {
                Model.TableModel.Pdm_eqm model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Pdm_eqm>("Delete", modelList);
        }


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="where">where子句</param>
        /// <param name="orderBy">排序子句</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">页面索引</param>
        /// <returns>最终结果字符串</returns>
        public string GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex)
        {
            int total = 0;
            List<Model.TableModel.Pdm_eqm> list = DbEngine.QueryPage<Model.TableModel.Pdm_eqm>("pdm_eqm", pageIndex, pageSize, where, orderBy, out total);
            List<string> eqmNos = list.Select<Model.TableModel.Pdm_eqm, string>(Select).ToList();
            Dictionary<string, string> tmpLock = new Dictionary<string, string>();
            List<ModelView.EqmLockView> res = new List<ModelView.EqmLockView>();
            foreach (Model.TableModel.Pdm_eqm item in list)
            {
                if (!string.IsNullOrEmpty(item.eqm_lock))
                {
                    if (eqmNos.Contains(item.eqm_lock))
                    {
                        if (!tmpLock.Keys.Contains(item.eqm_lock))
                        {
                            tmpLock.Add(item.eqm_lock, item.eqm_no);
                        }
                    }

                }
                if (tmpLock.Keys.Contains(item.eqm_no))
                {
                    item.eqm_lock = tmpLock[item.eqm_no];
                }
                ModelView.EqmLockView model = Model2View(item);
                res.Add(model);
            }
            return Common.JsonHelper.SerializeObject(new { total = total, rows = res });
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="where">where子句</param>
        /// <param name="orderBy">排序子句</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">页面索引</param>
        /// <param name="total">out参数，返回总记录条数</param>
        /// <returns>视图对象列表</returns>
        public List<ModelView.EqmLockView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Pdm_eqm> list = DbEngine.QueryPage<Model.TableModel.Pdm_eqm>("pdm_eqm", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.EqmLockView> res = new List<ModelView.EqmLockView>();
            List<string> eqmNos =list.Select<Model.TableModel.Pdm_eqm,string>(Select).ToList();
            Dictionary<string,string> tmpLock = new Dictionary<string,string>();
            foreach (Model.TableModel.Pdm_eqm item in list)
            {
                if (!string.IsNullOrEmpty(item.eqm_lock))
                {
                    if (eqmNos.Contains(item.eqm_lock))
                    {
                        if (!tmpLock.Keys.Contains(item.eqm_lock))
                        {
                            tmpLock.Add(item.eqm_lock, item.eqm_no);
                        }
                    }
                        
                }
                if (tmpLock.Keys.Contains(item.eqm_no))
                {
                    item.eqm_lock = tmpLock[item.eqm_no];
                }
                ModelView.EqmLockView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        private string Select(Model.TableModel.Pdm_eqm model)
        {
            if (model.status_no=="310")
            {
                return model.eqm_no;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Pdm_eqm View2Model(ModelView.EqmLockView view)
        {
            Model.TableModel.Pdm_eqm model = new Model.TableModel.Pdm_eqm();
            if (string.IsNullOrEmpty(view.id))
            {
                model.id = Common.Md5Operate.CreateGuidId();
            }
            else
            {
                model.id = view.id;
            }

            model.status_name = "已确认";
            model.status_no = "310";
            model.eqm_no = string.IsNullOrEmpty(view.eqm_no) ? string.Empty : view.eqm_no;
            model.eqm_name = view.eqm_name;
            model.eqm_desc = string.Empty;
            int tmp = 0;
            int.TryParse(view.eqm_index, out tmp);
            model.eqm_index = tmp;
            model.wkc_no = "PSH On BYD";
            model.eqm_status = "正常";
            model.eqm_lock = view.eqm_lock == "无锁定" ? null : view.eqm_lock;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.EqmLockView Model2View(Model.TableModel.Pdm_eqm model)
        {
            ModelView.EqmLockView view = new ModelView.EqmLockView();
            view.id = model.id;
            view.eqm_no = model.eqm_no;
            view.eqm_name = model.eqm_name;
            view.eqm_index = model.eqm_index.ToString();
            view.eqm_lock = string.IsNullOrEmpty(model.eqm_lock) ? "无锁定" : model.eqm_lock;
            return view;
        }
    }
}
