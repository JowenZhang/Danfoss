using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 系统设定控制类
    /// </summary>
    public class SysSettingCtrl:ICtrlOperate
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
            ModelView.SysSettingView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.SysSettingView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.SysSettingView newValue)
        {
            Model.TableModel.Sys_setting model = View2Model(newValue);
            List<Model.TableModel.Sys_setting> modelList = new List<Model.TableModel.Sys_setting>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_setting>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.SysSettingView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.SysSettingView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.SysSettingView newValue)
        {
            Model.TableModel.Sys_setting model = View2Model(newValue);
            List<Model.TableModel.Sys_setting> modelList = new List<Model.TableModel.Sys_setting>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_setting>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.SysSettingView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.SysSettingView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.SysSettingView oldValue)
        {
            Model.TableModel.Sys_setting model = View2Model(oldValue);
            List<Model.TableModel.Sys_setting> modelList = new List<Model.TableModel.Sys_setting>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_setting>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.SysSettingView> oldValues)
        {
            List<Model.TableModel.Sys_setting> modelList = new List<Model.TableModel.Sys_setting>();
            foreach (ModelView.SysSettingView item in oldValues)
            {
                Model.TableModel.Sys_setting model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Sys_setting>("Delete", modelList);
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
            List<Model.TableModel.Sys_setting> list = DbEngine.QueryPage<Model.TableModel.Sys_setting>("sys_setting", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.SysSettingView> res = new List<ModelView.SysSettingView>();
            foreach (Model.TableModel.Sys_setting item in list)
            {
                ModelView.SysSettingView model = Model2View(item);
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
        public List<ModelView.SysSettingView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Sys_setting> list = DbEngine.QueryPage<Model.TableModel.Sys_setting>("sys_setting", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.SysSettingView> res = new List<ModelView.SysSettingView>();
            foreach (Model.TableModel.Sys_setting item in list)
            {
                ModelView.SysSettingView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Sys_setting View2Model(ModelView.SysSettingView view)
        {
            Model.TableModel.Sys_setting model = new Model.TableModel.Sys_setting();
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
            DateTime dt=DateTime.Now;
            model.crt_time=DateTime.TryParse(view.crt_time,out dt)?dt:DateTime.Now;
            model.crt_user_no = string.IsNullOrEmpty(view.crt_user_no) ? "Server" : view.crt_user_no;
            model.crt_user_name = view.crt_user_name;
            GlobalDataCtrl globalDataCtrl = new GlobalDataCtrl();
            model.setting_no = string.IsNullOrEmpty(view.setting_no) ? globalDataCtrl.GetNextNoByTblName("sys_setting") : view.setting_no;
            model.setting_name = view.setting_name;
            model.setting_display_name = view.setting_display_name;
            model.setting_value = view.setting_value;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.SysSettingView Model2View(Model.TableModel.Sys_setting model)
        {
            ModelView.SysSettingView view = new ModelView.SysSettingView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            view.crt_time = model.crt_time.ToString("yyyy-MM-dd HH:mm:ss.fff") ;
            view.crt_user_no = model.crt_user_no;
            view.crt_user_name = model.crt_user_name;
            view.setting_no = model.setting_no;
            view.setting_name = model.setting_name;
            view.setting_display_name = model.setting_display_name;
            view.setting_value = model.setting_value;
            return view;
        }
    }
}
