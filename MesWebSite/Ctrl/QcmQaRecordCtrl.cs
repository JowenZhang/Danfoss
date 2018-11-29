using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 质检结果控制类
    /// </summary>
    public class QcmQaRecordCtrl:ICtrlOperate
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
            ModelView.QcmQaRecordView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.QcmQaRecordView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.QcmQaRecordView newValue)
        {
            Model.TableModel.Qcm_qa_record model = View2Model(newValue);
            List<Model.TableModel.Qcm_qa_record> modelList = new List<Model.TableModel.Qcm_qa_record>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Qcm_qa_record>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.QcmQaRecordView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.QcmQaRecordView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.QcmQaRecordView newValue)
        {
            Model.TableModel.Qcm_qa_record model = View2Model(newValue);
            List<Model.TableModel.Qcm_qa_record> modelList = new List<Model.TableModel.Qcm_qa_record>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Qcm_qa_record>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.QcmQaRecordView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.QcmQaRecordView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.QcmQaRecordView oldValue)
        {
            Model.TableModel.Qcm_qa_record model = View2Model(oldValue);
            List<Model.TableModel.Qcm_qa_record> modelList = new List<Model.TableModel.Qcm_qa_record>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Qcm_qa_record>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.QcmQaRecordView> oldValues)
        {
            List<Model.TableModel.Qcm_qa_record> modelList = new List<Model.TableModel.Qcm_qa_record>();
            foreach (ModelView.QcmQaRecordView item in oldValues)
            {
                Model.TableModel.Qcm_qa_record model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Qcm_qa_record>("Delete", modelList);
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
            List<Model.TableModel.Qcm_qa_record> list = DbEngine.QueryPage<Model.TableModel.Qcm_qa_record>("qcm_qa_record", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.QcmQaRecordView> res = new List<ModelView.QcmQaRecordView>();
            foreach (Model.TableModel.Qcm_qa_record item in list)
            {
                ModelView.QcmQaRecordView model = Model2View(item);
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
        public List<ModelView.QcmQaRecordView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Qcm_qa_record> list = DbEngine.QueryPage<Model.TableModel.Qcm_qa_record>("qcm_qa_record", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.QcmQaRecordView> res = new List<ModelView.QcmQaRecordView>();
            foreach (Model.TableModel.Qcm_qa_record item in list)
            {
                ModelView.QcmQaRecordView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Qcm_qa_record View2Model(ModelView.QcmQaRecordView view)
        {
            Model.TableModel.Qcm_qa_record model = new Model.TableModel.Qcm_qa_record();
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
            model.qa_record_no = string.IsNullOrEmpty(view.qa_record_no) ? globalDataCtrl.GetNextNoByTblName("qcm_qa_record") : view.qa_record_no;
            model.qa_cause_no = string.IsNullOrEmpty(view.qa_cause_no) ? "00" : view.qa_cause_no;
            model.qa_cause_name = view.qa_cause_name;
            model.part_no = view.part_no;
            model.eqm_no = view.eqm_no;
            model.mpo_no = view.mpo_no;
            model.mpo_item_no = view.mpo_item_no;
            model.serial_no = view.serial_no;
            model.factory_no = view.factory_no;
            model.submit_user_no = string.IsNullOrEmpty(view.submit_user_no) ? "Server" : view.submit_user_no;
            model.submit_user_name = string.IsNullOrEmpty(view.submit_user_name) ? "Server" : view.submit_user_name; 
            dt = DateTime.Now;
            model.submit_time = DateTime.TryParse(view.submit_time, out dt) ? dt : DateTime.Now;
            model.qa_result_no = view.qa_result_no;
            model.qa_result_name = view.qa_result_name;
            model.solve_user_no = view.solve_user_no;
            model.solve_user_name = view.solve_user_name;
            dt = DateTime.Now;
            model.solve_time = string.IsNullOrEmpty(view.solve_time) ? (DateTime?)null : (DateTime.TryParse(view.solve_time, out dt) ? dt : DateTime.Now);
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.QcmQaRecordView Model2View(Model.TableModel.Qcm_qa_record model)
        {
            ModelView.QcmQaRecordView view = new ModelView.QcmQaRecordView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;

            view.crt_user_no = model.crt_user_no;
            view.crt_user_name = model.crt_user_name;
            view.crt_time = model.crt_time.ToString("yyyy-MM-dd HH:mm:ss.fff");
            view.upd_user_no = model.upd_user_no;
            view.upd_user_name = model.upd_user_name;
            view.upd_time = model.upd_time.ToString("yyyy-MM-dd HH:mm:ss.fff");

            view.qa_record_no = model.qa_record_no;
            view.qa_cause_no = model.qa_cause_no;
            view.qa_cause_name = model.qa_cause_name;
            view.part_no = model.part_no;
            view.eqm_no = model.eqm_no;
            view.mpo_no = model.mpo_no;
            view.mpo_item_no = model.mpo_item_no;
            view.serial_no = model.serial_no;
            view.factory_no = model.factory_no;

            view.submit_user_no = model.submit_user_no;
            view.submit_user_name = model.submit_user_name;
            view.submit_time = model.submit_time.ToString("yyyy-MM-dd HH:mm:ss.fff");
            view.qa_result_no = model.qa_result_no;
            view.qa_result_name = model.qa_result_name;

            view.solve_user_no = model.solve_user_no;
            view.solve_user_name = model.solve_user_name;
            view.solve_time = model.solve_time.HasValue?((DateTime)model.solve_time).ToString("yyyy-MM-dd HH:mm:ss.fff"):string.Empty;

            return view;
        }
    }
}
