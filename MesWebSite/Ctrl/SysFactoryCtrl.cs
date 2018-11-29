using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 工厂视图控制类
    /// </summary>
    public class SysFactoryCtrl : ICtrlOperate
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
            ModelView.SysFactoryView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.SysFactoryView>(jsonStr);
            try
            {
                return Insert(model);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.SysFactoryView newValue)
        {
            Model.TableModel.Sys_factory model = View2Model(newValue);
            List<Model.TableModel.Sys_factory> modelList = new List<Model.TableModel.Sys_factory>();
            try
            {
                modelList.Add(model);
                return DbEngine.QueryInt<Model.TableModel.Sys_factory>("Insert", modelList);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.SysFactoryView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.SysFactoryView>(jsonStr);
            try
            {
                return Update(model);
            }
            catch (Exception)
            {
                return -1;
            }


        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.SysFactoryView newValue)
        {
            Model.TableModel.Sys_factory model = View2Model(newValue);
            List<Model.TableModel.Sys_factory> modelList = new List<Model.TableModel.Sys_factory>();
            modelList.Add(model);
            try
            {
                return DbEngine.QueryInt<Model.TableModel.Sys_factory>("update", modelList);
            }
            catch (Exception)
            {
                return -1;
            }
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.SysFactoryView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.SysFactoryView>(jsonStr);
            try
            {
                return Delete(list);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.SysFactoryView oldValue)
        {
            Model.TableModel.Sys_factory model = View2Model(oldValue);
            List<Model.TableModel.Sys_factory> modelList = new List<Model.TableModel.Sys_factory>();
            modelList.Add(model);
            try
            {
                return DbEngine.QueryInt<Model.TableModel.Sys_factory>("Delete", modelList);
            }
            catch (Exception)
            {
                return -1;
            }            
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.SysFactoryView> oldValues)
        {
            List<Model.TableModel.Sys_factory> modelList = new List<Model.TableModel.Sys_factory>();
            foreach (ModelView.SysFactoryView item in oldValues)
            {
                Model.TableModel.Sys_factory model = View2Model(item);
                modelList.Add(model);
            }
            try
            {
                return DbEngine.QueryInt<Model.TableModel.Sys_factory>("Delete", modelList);
            }
            catch (Exception)
            {
                return -1;
            }
            
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
            List<Model.TableModel.Sys_factory> list = DbEngine.QueryPage<Model.TableModel.Sys_factory>("sys_factory", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.SysFactoryView> res = new List<ModelView.SysFactoryView>();
            foreach (Model.TableModel.Sys_factory item in list)
            {
                ModelView.SysFactoryView model = Model2View(item);
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
        public List<ModelView.SysFactoryView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Sys_factory> list = DbEngine.QueryPage<Model.TableModel.Sys_factory>("sys_factory", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.SysFactoryView> res = new List<ModelView.SysFactoryView>();
            foreach (Model.TableModel.Sys_factory item in list)
            {
                ModelView.SysFactoryView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Sys_factory View2Model(ModelView.SysFactoryView view)
        {
            Model.TableModel.Sys_factory model = new Model.TableModel.Sys_factory();
            if (string.IsNullOrEmpty(view.id))
            {
                model.id = Common.Md5Operate.CreateGuidId();
            }
            else
            {
                model.id = view.id;
            }
            model.status_no = string.IsNullOrEmpty(view.status_no) ? "310" : view.status_no;
            model.status_name = view.status_no;
            GlobalDataCtrl globalDataCtrl = new GlobalDataCtrl();
            model.factory_no = string.IsNullOrEmpty(view.factory_no) ? globalDataCtrl.GetNextNoByTblName("sys_factory") : view.factory_no;
            model.factory_name = view.factory_name;
            model.factory_name_py = view.factory_name_py;
            model.factory_type = view.factory_type;
            model.company_no = view.company_no;
            model.company_name = view.company_name;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.SysFactoryView Model2View(Model.TableModel.Sys_factory model)
        {
            ModelView.SysFactoryView view = new ModelView.SysFactoryView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            view.factory_no = model.factory_no;
            view.factory_name = model.factory_name;
            view.factory_name_py = model.factory_name_py;
            view.factory_type = model.factory_type;
            view.company_no = model.company_no;
            view.company_name = model.company_name;
            return view;
        }
    }
}
