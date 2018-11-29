using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 设备停机视图管理类
    /// </summary>
    public class EqmJamCauseCtrl:ICtrlOperate
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
            ModelView.EqmJamCauseView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.EqmJamCauseView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.EqmJamCauseView newValue)
        {
            Model.TableModel.Eqm_jam_cause model = View2Model(newValue);
            List<Model.TableModel.Eqm_jam_cause> modelList = new List<Model.TableModel.Eqm_jam_cause>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Eqm_jam_cause>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.EqmJamCauseView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.EqmJamCauseView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.EqmJamCauseView newValue)
        {
            Model.TableModel.Eqm_jam_cause model = View2Model(newValue);
            List<Model.TableModel.Eqm_jam_cause> modelList = new List<Model.TableModel.Eqm_jam_cause>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Eqm_jam_cause>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.EqmJamCauseView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.EqmJamCauseView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.EqmJamCauseView oldValue)
        {
            Model.TableModel.Eqm_jam_cause model = View2Model(oldValue);
            List<Model.TableModel.Eqm_jam_cause> modelList = new List<Model.TableModel.Eqm_jam_cause>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Eqm_jam_cause>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.EqmJamCauseView> oldValues)
        {
            List<Model.TableModel.Eqm_jam_cause> modelList = new List<Model.TableModel.Eqm_jam_cause>();
            foreach (ModelView.EqmJamCauseView item in oldValues)
            {
                Model.TableModel.Eqm_jam_cause model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Eqm_jam_cause>("Delete", modelList);
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
            List<Model.TableModel.Eqm_jam_cause> list = DbEngine.QueryPage<Model.TableModel.Eqm_jam_cause>("eqm_jam_cause", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.EqmJamCauseView> res = new List<ModelView.EqmJamCauseView>();
            foreach (Model.TableModel.Eqm_jam_cause item in list)
            {
                ModelView.EqmJamCauseView model = Model2View(item);
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
        public List<ModelView.EqmJamCauseView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Eqm_jam_cause> list = DbEngine.QueryPage<Model.TableModel.Eqm_jam_cause>("eqm_jam_cause", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.EqmJamCauseView> res = new List<ModelView.EqmJamCauseView>();
            foreach (Model.TableModel.Eqm_jam_cause item in list)
            {
                ModelView.EqmJamCauseView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>Model.TableModel.Eqm_jam_cause
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Eqm_jam_cause View2Model(ModelView.EqmJamCauseView view)
        {
            Model.TableModel.Eqm_jam_cause model = new Model.TableModel.Eqm_jam_cause();
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
            model.upd_user_no = string.IsNullOrEmpty(view.upd_user_no) ? "Server" : view.upd_user_no;
            model.upd_user_name = string.IsNullOrEmpty(view.upd_user_name) ? "Server" : view.upd_user_name;
            dt = DateTime.Now;
            model.upd_time = DateTime.TryParse(view.upd_time, out dt)?dt:DateTime.Now;
            GlobalDataCtrl globalDataCtrl = new GlobalDataCtrl();
            model.jam_cause_no = string.IsNullOrEmpty(view.jam_cause_no) ? globalDataCtrl.GetNextNoByTblName("jam_cause_no") : view.jam_cause_no;
            model.jam_cause_name = view.jam_cause_name;
            model.jam_cause_py = view.jam_cause_py;
            model.jam_cause_type_no = view.jam_cause_type_no;
            model.jam_cause_is_default = view.jam_cause_is_default =="是"?true : false;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.EqmJamCauseView Model2View(Model.TableModel.Eqm_jam_cause model)
        {
            ModelView.EqmJamCauseView view = new ModelView.EqmJamCauseView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            view.crt_user_no = model.crt_user_no;
            view.crt_user_name = model.crt_user_name;
            view.crt_time = model.crt_time.ToString("yyyy-MM-dd HH:mm:ss.fff");
            view.upd_user_no = model.upd_user_no;
            view.upd_user_name = model.upd_user_name;
            view.upd_time = model.upd_time.ToString("yyyy-MM-dd HH:mm:ss.fff");
            view.jam_cause_no = model.jam_cause_no;
            view.jam_cause_name = model.jam_cause_name;
            view.jam_cause_py = model.jam_cause_py;
            view.jam_cause_type_no = model.jam_cause_type_no;
            view.jam_cause_is_default = model.jam_cause_is_default?"是":"否";
            return view;
        }
    }
}
