using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 部门视图控制类
    /// </summary>
    public class SysDeptCtrl:ICtrlOperate
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
            ModelView.SysDeptView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.SysDeptView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.SysDeptView newValue)
        {
            Model.TableModel.Sys_dept model = View2Model(newValue);
            List<Model.TableModel.Sys_dept> modelList = new List<Model.TableModel.Sys_dept>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_dept>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.SysDeptView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.SysDeptView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.SysDeptView newValue)
        {
            Model.TableModel.Sys_dept model = View2Model(newValue);
            List<Model.TableModel.Sys_dept> modelList = new List<Model.TableModel.Sys_dept>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_dept>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.SysDeptView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.SysDeptView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.SysDeptView oldValue)
        {
            Model.TableModel.Sys_dept model = View2Model(oldValue);
            List<Model.TableModel.Sys_dept> modelList = new List<Model.TableModel.Sys_dept>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_dept>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.SysDeptView> oldValues)
        {
            List<Model.TableModel.Sys_dept> modelList = new List<Model.TableModel.Sys_dept>();
            foreach (ModelView.SysDeptView item in oldValues)
            {
                Model.TableModel.Sys_dept model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Sys_dept>("Delete", modelList);
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
            List<Model.TableModel.Sys_dept> list = DbEngine.QueryPage<Model.TableModel.Sys_dept>("sys_dept", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.SysDeptView> res = new List<ModelView.SysDeptView>();
            foreach (Model.TableModel.Sys_dept item in list)
            {
                ModelView.SysDeptView model = Model2View(item);
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
        public List<ModelView.SysDeptView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Sys_dept> list = DbEngine.QueryPage<Model.TableModel.Sys_dept>("sys_dept", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.SysDeptView> res = new List<ModelView.SysDeptView>();
            foreach (Model.TableModel.Sys_dept item in list)
            {
                ModelView.SysDeptView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Sys_dept View2Model(ModelView.SysDeptView view)
        {
            Model.TableModel.Sys_dept model = new Model.TableModel.Sys_dept();
            if (string.IsNullOrEmpty(view.id))
            {
                model.id = Common.Md5Operate.CreateGuidId();
            }
            else
            {
                model.id = view.id;
            }
            GlobalDataCtrl globalDataCtrl = new GlobalDataCtrl();
            model.dept_no = string.IsNullOrEmpty(view.dept_no) ? globalDataCtrl.GetNextNoByTblName("sys_dept") : view.dept_no;
            model.dept_name = view.dept_name;
            model.status_name = view.status_name;
            model.status_no = string.IsNullOrEmpty(view.status_no) ? "310" : view.status_no;
            model.dept_no = string.IsNullOrEmpty(view.dept_no) ? "01" : view.dept_no;
            model.dept_name_py = view.dept_name_py;
            model.company_no = string.IsNullOrEmpty(view.company_no) ? "dfs_c" : view.company_no;
            model.company_name = view.company_name;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.SysDeptView Model2View(Model.TableModel.Sys_dept model)
        {
            ModelView.SysDeptView view = new ModelView.SysDeptView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            view.dept_no = model.dept_no;
            view.dept_name = model.dept_name;
            view.dept_name_py = model.dept_name_py;
            view.dept_type = model.dept_type;
            view.company_no = model.company_no;
            view.company_name = model.company_name;
            return view;
        }
    }
}
