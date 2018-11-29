using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// SPC设定视图控制类
    /// </summary>
    public class SysSpcSettingCtrl:ICtrlOperate
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
            ModelView.SysSpcSettingView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.SysSpcSettingView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.SysSpcSettingView newValue)
        {
            Model.TableModel.Sys_spc_setting model = View2Model(newValue);
            List<Model.TableModel.Sys_spc_setting> modelList = new List<Model.TableModel.Sys_spc_setting>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_spc_setting>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            List<ModelView.SysSpcSettingView> models = Common.JsonHelper.DeserializeJsonToList<ModelView.SysSpcSettingView>(jsonStr);
            return Update(models);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="listNewValue">更新后的视图模板类的集合</param>
        /// <returns>影响记录条数</returns>
        public int Update(List<ModelView.SysSpcSettingView> listNewValue)
        {
            List<Model.TableModel.Sys_spc_setting> modelList = new List<Model.TableModel.Sys_spc_setting>();
            foreach (ModelView.SysSpcSettingView item in listNewValue)
            {
                Model.TableModel.Sys_spc_setting model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Sys_spc_setting>("update", modelList);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.SysSpcSettingView newValue)
        {
            Model.TableModel.Sys_spc_setting model = View2Model(newValue);
            List<Model.TableModel.Sys_spc_setting> modelList = new List<Model.TableModel.Sys_spc_setting>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_spc_setting>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.SysSpcSettingView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.SysSpcSettingView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.SysSpcSettingView oldValue)
        {
            Model.TableModel.Sys_spc_setting model = View2Model(oldValue);
            List<Model.TableModel.Sys_spc_setting> modelList = new List<Model.TableModel.Sys_spc_setting>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_spc_setting>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.SysSpcSettingView> oldValues)
        {
            List<Model.TableModel.Sys_spc_setting> modelList = new List<Model.TableModel.Sys_spc_setting>();
            foreach (ModelView.SysSpcSettingView item in oldValues)
            {
                Model.TableModel.Sys_spc_setting model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Sys_spc_setting>("Delete", modelList);
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
            List<Model.TableModel.Sys_spc_setting> list = DbEngine.QueryPage<Model.TableModel.Sys_spc_setting>("mes_fb", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.SysSpcSettingView> res = new List<ModelView.SysSpcSettingView>();
            foreach (Model.TableModel.Sys_spc_setting item in list)
            {
                ModelView.SysSpcSettingView model = Model2View(item);
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
        public List<ModelView.SysSpcSettingView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Sys_spc_setting> list = DbEngine.QueryPage<Model.TableModel.Sys_spc_setting>("mes_fb", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.SysSpcSettingView> res = new List<ModelView.SysSpcSettingView>();
            foreach (Model.TableModel.Sys_spc_setting item in list)
            {
                ModelView.SysSpcSettingView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Sys_spc_setting View2Model(ModelView.SysSpcSettingView view)
        {
            Model.TableModel.Sys_spc_setting model = new Model.TableModel.Sys_spc_setting();
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
            model.crt_user_no = string.IsNullOrEmpty(view.crt_user_no) ? "Server" : view.crt_user_no;
            model.crt_user_name = string.IsNullOrEmpty(view.crt_user_name) ? "Server" : view.crt_user_name;
            DateTime dt = DateTime.Now;
            model.crt_time = DateTime.TryParse(view.crt_time, out dt) ? dt : DateTime.Now;
            GlobalDataCtrl globalDataCtrl = new GlobalDataCtrl();
            model.spc_setting_no = string.IsNullOrEmpty(view.spc_setting_no) ? globalDataCtrl.GetNextNoByTblName("mes_fb") : view.spc_setting_no;
            model.eqm_no = string.IsNullOrEmpty(view.eqm_no) ? "EqmNo" : view.eqm_no;
            model.spc_setting_name = string.IsNullOrEmpty(view.spc_setting_name) ? "SettingName" : view.spc_setting_name;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.SysSpcSettingView Model2View(Model.TableModel.Sys_spc_setting model)
        {
            ModelView.SysSpcSettingView view = new ModelView.SysSpcSettingView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;

            view.crt_user_no = model.crt_user_no;
            view.crt_user_name = model.crt_user_name;
            view.crt_time = model.crt_time.ToString("yyyy-MM-dd HH:mm:ss.fff");
            view.spc_setting_no = model.spc_setting_no;
            view.eqm_no = model.eqm_no;
            view.spc_setting_name = model.spc_setting_name;
            return view;
        }
    }
}
