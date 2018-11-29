using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 系统用户权限组控制类
    /// </summary>
    public class SysUserAuthGroupCtrl:ICtrlOperate
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
            ModelView.SysUserAuthGroupView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.SysUserAuthGroupView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.SysUserAuthGroupView newValue)
        {
            Model.TableModel.Sys_user_auth_group model = View2Model(newValue);
            List<Model.TableModel.Sys_user_auth_group> modelList = new List<Model.TableModel.Sys_user_auth_group>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_user_auth_group>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.SysUserAuthGroupView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.SysUserAuthGroupView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.SysUserAuthGroupView newValue)
        {
            Model.TableModel.Sys_user_auth_group model = View2Model(newValue);
            List<Model.TableModel.Sys_user_auth_group> modelList = new List<Model.TableModel.Sys_user_auth_group>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_user_auth_group>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.SysUserAuthGroupView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.SysUserAuthGroupView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.SysUserAuthGroupView oldValue)
        {
            Model.TableModel.Sys_user_auth_group model = View2Model(oldValue);
            List<Model.TableModel.Sys_user_auth_group> modelList = new List<Model.TableModel.Sys_user_auth_group>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_user_auth_group>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.SysUserAuthGroupView> oldValues)
        {
            List<Model.TableModel.Sys_user_auth_group> modelList = new List<Model.TableModel.Sys_user_auth_group>();
            foreach (ModelView.SysUserAuthGroupView item in oldValues)
            {
                Model.TableModel.Sys_user_auth_group model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Sys_user_auth_group>("Delete", modelList);
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
            List<Model.TableModel.Sys_user_auth_group> list = DbEngine.QueryPage<Model.TableModel.Sys_user_auth_group>("sys_user_auth_group", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.SysUserAuthGroupView> res = new List<ModelView.SysUserAuthGroupView>();
            foreach (Model.TableModel.Sys_user_auth_group item in list)
            {
                ModelView.SysUserAuthGroupView model = Model2View(item);
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
        public List<ModelView.SysUserAuthGroupView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Sys_user_auth_group> list = DbEngine.QueryPage<Model.TableModel.Sys_user_auth_group>("sys_user_auth_group", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.SysUserAuthGroupView> res = new List<ModelView.SysUserAuthGroupView>();
            foreach (Model.TableModel.Sys_user_auth_group item in list)
            {
                ModelView.SysUserAuthGroupView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Sys_user_auth_group View2Model(ModelView.SysUserAuthGroupView view)
        {
            Model.TableModel.Sys_user_auth_group model = new Model.TableModel.Sys_user_auth_group();
            if (string.IsNullOrEmpty(view.id))
            {
                model.id = Common.Md5Operate.CreateGuidId();
            }
            else
            {
                model.id = view.id;
            }
            model.status_name = view.status_name;
            model.status_no = string.IsNullOrEmpty(view.status_no) ? "310" : view.status_no;
            model.user_name = view.user_name;
            model.user_no = string.IsNullOrEmpty(view.user_no) ? "Server" : view.user_no;
            model.auth_group_name = view.auth_group_name;
            model.auth_group_no = string.IsNullOrEmpty(view.user_no) ? "Default" : view.user_no;
            return model;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="model">视图类</param>
        /// <returns>实体类</returns>
        private ModelView.SysUserAuthGroupView Model2View(Model.TableModel.Sys_user_auth_group model)
        {
            ModelView.SysUserAuthGroupView view = new ModelView.SysUserAuthGroupView();
            view.id = model.id;
            view.auth_group_name = model.auth_group_name;
            view.auth_group_no = model.auth_group_no;
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            view.user_name = model.user_name;
            view.user_no = model.user_no;
            return view;
        }
    }
}
