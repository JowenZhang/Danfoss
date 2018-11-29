using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 用户权限视图控制类
    /// </summary>
    public class SysAuthCtrl:ICtrlOperate
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
            ModelView.SysAuthView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.SysAuthView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.SysAuthView newValue)
        {
            Model.TableModel.Sys_auth model = View2Model(newValue);
            List<Model.TableModel.Sys_auth> modelList = new List<Model.TableModel.Sys_auth>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_auth>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.SysAuthView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.SysAuthView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.SysAuthView newValue)
        {
            Model.TableModel.Sys_auth model = View2Model(newValue);
            List<Model.TableModel.Sys_auth> modelList = new List<Model.TableModel.Sys_auth>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_auth>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.SysAuthView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.SysAuthView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.SysAuthView oldValue)
        {
            Model.TableModel.Sys_auth model = View2Model(oldValue) ;
            List<Model.TableModel.Sys_auth> modelList = new List<Model.TableModel.Sys_auth>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_auth>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.SysAuthView> oldValues)
        {
            List<Model.TableModel.Sys_auth> modelList = new List<Model.TableModel.Sys_auth>();
            foreach (ModelView.SysAuthView item in oldValues)
            {
                Model.TableModel.Sys_auth model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Sys_auth>("Delete", modelList);
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
            List<Model.TableModel.Sys_auth> list = DbEngine.QueryPage<Model.TableModel.Sys_auth>("sys_auth", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.SysAuthView> res = new List<ModelView.SysAuthView>();
            foreach (Model.TableModel.Sys_auth item in list)
            {
                ModelView.SysAuthView model = Model2View(item);
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
        public List<ModelView.SysAuthView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Sys_auth> list = DbEngine.QueryPage<Model.TableModel.Sys_auth>("sys_auth", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.SysAuthView> res = new List<ModelView.SysAuthView>();
            foreach (Model.TableModel.Sys_auth item in list)
            {
                ModelView.SysAuthView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Sys_auth View2Model(ModelView.SysAuthView view)
        {
            Model.TableModel.Sys_auth model = new Model.TableModel.Sys_auth();
            if (string.IsNullOrEmpty(view.id))
            {
                model.id = Common.Md5Operate.CreateGuidId();
            }
            else
            {
                model.id = view.id;
            }
            model.auth_group_name = view.auth_group_name;
            model.auth_group_no = view.auth_group_no;
            model.auth_name = view.auth_name;
            model.auth_no = view.auth_no;
            model.menu_no = view.menu_no;
            model.status_name = view.status_name;
            model.status_no = view.status_no;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.SysAuthView Model2View(Model.TableModel.Sys_auth model)
        {
            ModelView.SysAuthView view = new ModelView.SysAuthView();
            view.id = model.id;
            view.auth_group_name = model.auth_group_name;
            view.auth_group_no = model.auth_group_no;
            view.auth_name = model.auth_name;
            view.auth_no = model.auth_no;
            view.menu_no = model.menu_no;
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            return view;
        }
    }
}
