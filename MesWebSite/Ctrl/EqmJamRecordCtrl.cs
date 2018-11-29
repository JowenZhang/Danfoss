using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 停机记录视图操作类
    /// </summary>
    public class EqmJamRecordCtrl:ICtrlOperate
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
            ModelView.EqmJamRecordView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.EqmJamRecordView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.EqmJamRecordView newValue)
        {
            Model.TableModel.Eqm_jam_record model = View2Model(newValue);
            List<Model.TableModel.Eqm_jam_record> modelList = new List<Model.TableModel.Eqm_jam_record>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Eqm_jam_record>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.EqmJamRecordView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.EqmJamRecordView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.EqmJamRecordView newValue)
        {
            Model.TableModel.Eqm_jam_record model = View2Model(newValue);
            List<Model.TableModel.Eqm_jam_record> modelList = new List<Model.TableModel.Eqm_jam_record>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Eqm_jam_record>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.EqmJamRecordView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.EqmJamRecordView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.EqmJamRecordView oldValue)
        {
            Model.TableModel.Eqm_jam_record model = View2Model(oldValue);
            List<Model.TableModel.Eqm_jam_record> modelList = new List<Model.TableModel.Eqm_jam_record>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Eqm_jam_record>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.EqmJamRecordView> oldValues)
        {
            List<Model.TableModel.Eqm_jam_record> modelList = new List<Model.TableModel.Eqm_jam_record>();
            foreach (ModelView.EqmJamRecordView item in oldValues)
            {
                Model.TableModel.Eqm_jam_record model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Eqm_jam_record>("Delete", modelList);
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
            List<Model.TableModel.Eqm_jam_record> list = DbEngine.QueryPage<Model.TableModel.Eqm_jam_record>("eqm_jam_record", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.EqmJamRecordView> res = new List<ModelView.EqmJamRecordView>();
            foreach (Model.TableModel.Eqm_jam_record item in list)
            {
                ModelView.EqmJamRecordView model = Model2View(item);
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
        public List<ModelView.EqmJamRecordView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Eqm_jam_record> list = DbEngine.QueryPage<Model.TableModel.Eqm_jam_record>("eqm_jam_record", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.EqmJamRecordView> res = new List<ModelView.EqmJamRecordView>();
            foreach (Model.TableModel.Eqm_jam_record item in list)
            {
                ModelView.EqmJamRecordView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Eqm_jam_record View2Model(ModelView.EqmJamRecordView view)
        {
            Model.TableModel.Eqm_jam_record model = new Model.TableModel.Eqm_jam_record();
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
            model.upd_time = DateTime.TryParse(view.upd_time, out dt) ? dt : DateTime.Now;
            GlobalDataCtrl globalDataCtrl = new GlobalDataCtrl();
            model.jam_record_no = string.IsNullOrEmpty(view.jam_record_no) ? globalDataCtrl.GetNextNoByTblName("eqm_jam_record") : view.jam_record_no;
            model.jam_cause_no = view.jam_cause_no;
            model.jam_cause_name = view.jam_cause_name;
            model.eqm_no = string.IsNullOrEmpty(view.eqm_no) ? "EqmNo" : view.eqm_no;
            model.wkc_no = string.IsNullOrEmpty(view.wkc_no) ? "WkcNo" : view.wkc_no;
            model.submit_user_no = string.IsNullOrEmpty(view.submit_user_no) ? "Server" : view.submit_user_no;
            model.submit_user_name = string.IsNullOrEmpty(view.submit_user_name) ? "Server" : view.submit_user_name;
            dt = DateTime.Now;
            model.submit_time = DateTime.TryParse(view.submit_time, out dt) ? dt : DateTime.Now;
            model.reply_user_no = string.IsNullOrEmpty(view.reply_user_no) ? "Server" : view.reply_user_no;
            model.reply_user_name = string.IsNullOrEmpty(view.reply_user_name) ? "Server" : view.reply_user_name;
            dt = DateTime.Now;
            model.reply_time = DateTime.TryParse(view.reply_time, out dt) ? dt : DateTime.Now;
            model.ralate_no = view.ralate_no;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.EqmJamRecordView Model2View(Model.TableModel.Eqm_jam_record model)
        {
            ModelView.EqmJamRecordView view = new ModelView.EqmJamRecordView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            view.crt_user_no = model.crt_user_no;
            view.crt_user_name = model.crt_user_name;
            view.crt_time = model.crt_time.ToString("yyyy-MM-dd HH:mm:ss.fff");
            view.upd_user_no = model.upd_user_no;
            view.upd_user_name = model.upd_user_name;
            view.upd_time = model.upd_time.ToString("yyyy-MM-dd HH:mm:ss.fff");
            view.jam_record_no = model.jam_record_no;
            view.jam_cause_no = model.jam_cause_no;
            view.jam_cause_name = model.jam_cause_name;
            view.eqm_no = model.eqm_no;
            view.wkc_no = model.wkc_no;
            view.submit_user_no = model.submit_user_no;
            view.submit_user_name = model.submit_user_name;
            view.submit_time = model.submit_time.ToString("yyyy-MM-dd HH:mm:ss.fff");
            view.reply_user_no = model.reply_user_no;
            view.reply_user_name = model.reply_user_name;
            view.reply_time = model.reply_time.HasValue?((DateTime)model.reply_time).ToString("yyyy-MM-dd HH:mm:ss.fff"):string.Empty;
            view.ralate_no = model.ralate_no;
            return view;
        }
    }
}
