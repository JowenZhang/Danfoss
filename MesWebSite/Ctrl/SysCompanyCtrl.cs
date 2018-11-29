using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 公司视图控制类
    /// </summary>
    public class SysCompanyCtrl:ICtrlOperate
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
            ModelView.SysCompanyView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.SysCompanyView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.SysCompanyView newValue)
        {
            Model.TableModel.Sys_company model = View2Model(newValue);
            List<Model.TableModel.Sys_company> modelList = new List<Model.TableModel.Sys_company>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_company>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.SysCompanyView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.SysCompanyView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.SysCompanyView newValue)
        {
            Model.TableModel.Sys_company model = View2Model(newValue);
            List<Model.TableModel.Sys_company> modelList = new List<Model.TableModel.Sys_company>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_company>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.SysCompanyView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.SysCompanyView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.SysCompanyView oldValue)
        {
            Model.TableModel.Sys_company model = View2Model(oldValue);
            List<Model.TableModel.Sys_company> modelList = new List<Model.TableModel.Sys_company>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_company>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.SysCompanyView> oldValues)
        {
            List<Model.TableModel.Sys_company> modelList = new List<Model.TableModel.Sys_company>();
            foreach (ModelView.SysCompanyView item in oldValues)
            {
                Model.TableModel.Sys_company model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Sys_company>("Delete", modelList);
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
            List<Model.TableModel.Sys_company> list = DbEngine.QueryPage<Model.TableModel.Sys_company>("sys_company", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.SysCompanyView> res = new List<ModelView.SysCompanyView>();
            foreach (Model.TableModel.Sys_company item in list)
            {
                ModelView.SysCompanyView model = Model2View(item);
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
        public List<ModelView.SysCompanyView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Sys_company> list = DbEngine.QueryPage<Model.TableModel.Sys_company>("sys_company", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.SysCompanyView> res = new List<ModelView.SysCompanyView>();
            foreach (Model.TableModel.Sys_company item in list)
            {
                ModelView.SysCompanyView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Sys_company View2Model(ModelView.SysCompanyView view)
        {
            Model.TableModel.Sys_company model = new Model.TableModel.Sys_company();
            if (string.IsNullOrEmpty(view.id))
            {
                model.id = Common.Md5Operate.CreateGuidId();
            }
            else
            {
                model.id = view.id;
            }
            GlobalDataCtrl globalDataCtrl = new GlobalDataCtrl();
            model.company_no = string.IsNullOrEmpty(view.company_no) ? globalDataCtrl.GetNextNoByTblName("sys_company") : view.company_no;
            model.company_name = view.company_name;
            model.status_name = view.status_name;
            model.status_no = string.IsNullOrEmpty(view.status_no) ? "310" : view.status_no;
            model.group_no = string.IsNullOrEmpty(view.group_no) ? "dfs" : view.group_no;
            model.group_name = view.group_name;
            model.company_py = view.company_py;
            model.company_type = view.company_type;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.SysCompanyView Model2View(Model.TableModel.Sys_company model)
        {
            ModelView.SysCompanyView view = new ModelView.SysCompanyView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            view.company_no = model.company_no;
            view.company_name = model.company_name;
            view.company_py = model.company_py;
            view.company_type = model.company_type;            
            view.group_no = model.group_no;
            view.group_name = model.group_name;
            return view;
        }
    }
}
