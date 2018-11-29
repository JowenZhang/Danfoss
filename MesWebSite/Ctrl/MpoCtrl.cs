using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 生产订单视图类
    /// </summary>
    public class MpoCtrl:ICtrlOperate
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
            ModelView.MpoView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.MpoView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.MpoView newValue)
        {
            Model.TableModel.Mpo model = View2Model(newValue);
            List<Model.TableModel.Mpo> modelList = new List<Model.TableModel.Mpo>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Mpo>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            List<ModelView.MpoView> models = Common.JsonHelper.DeserializeJsonToList<ModelView.MpoView>(jsonStr);
            return Update(models);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="listNewValue">更新后的视图模板类的集合</param>
        /// <returns>影响记录条数</returns>
        public int Update(List<ModelView.MpoView> listNewValue)
        {
            List<Model.TableModel.Mpo> modelList = new List<Model.TableModel.Mpo>();
            foreach (ModelView.MpoView item in listNewValue)
            {
                Model.TableModel.Mpo model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Mpo>("update", modelList);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.MpoView newValue)
        {
            Model.TableModel.Mpo model = View2Model(newValue);
            List<Model.TableModel.Mpo> modelList = new List<Model.TableModel.Mpo>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Mpo>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.MpoView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.MpoView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.MpoView oldValue)
        {
            Model.TableModel.Mpo model = View2Model(oldValue);
            List<Model.TableModel.Mpo> modelList = new List<Model.TableModel.Mpo>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Mpo>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.MpoView> oldValues)
        {
            List<Model.TableModel.Mpo> modelList = new List<Model.TableModel.Mpo>();
            foreach (ModelView.MpoView item in oldValues)
            {
                Model.TableModel.Mpo model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Mpo>("Delete", modelList);
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
            List<Model.TableModel.Mpo> list = DbEngine.QueryPage<Model.TableModel.Mpo>("mpo", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.MpoView> res = new List<ModelView.MpoView>();
            foreach (Model.TableModel.Mpo item in list)
            {
                ModelView.MpoView model = Model2View(item);
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
        public List<ModelView.MpoView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Mpo> list = DbEngine.QueryPage<Model.TableModel.Mpo>("mpo", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.MpoView> res = new List<ModelView.MpoView>();
            foreach (Model.TableModel.Mpo item in list)
            {
                ModelView.MpoView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Mpo View2Model(ModelView.MpoView view)
        {
            Model.TableModel.Mpo model = new Model.TableModel.Mpo();
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
            model.mpo_no = string.IsNullOrEmpty(view.mpo_no) ? globalDataCtrl.GetNextNoByTblName("mpo") : view.mpo_no;
            model.mpo_type_no = view.mpo_type_no;
            model.mpo_type_name = view.mpo_type_name;
            model.part_no = string.IsNullOrEmpty(view.part_no)?"PartNo":view.part_no;
            model.part_name = view.part_name;
            model.part_spec = view.part_spec;
            model.part_unit = view.part_unit;
            decimal tmpDecimal = 0;
            model.mpo_qty = string.IsNullOrEmpty(view.mpo_qty) ? 0.0M : (decimal.TryParse(view.mpo_qty,out tmpDecimal)?tmpDecimal:0.0M);
            DateTime tmpDt=DateTime.Now;
            model.mpo_hope_start_datetime = string.IsNullOrEmpty(view.mpo_hope_start_datetime) ? (DateTime?)null : (DateTime.TryParse(view.mpo_hope_start_datetime, out tmpDt) ? tmpDt : (DateTime?)null);
            model.mpo_hope_end_datetime = string.IsNullOrEmpty(view.mpo_hope_end_datetime) ? (DateTime?)null : (DateTime.TryParse(view.mpo_hope_end_datetime, out tmpDt) ? tmpDt : (DateTime?)null);
           
            model.workshop_no = view.workshop_no;
            model.factory_no = view.factory_no;
            model.line_no = view.line_no;
            model.job_no = view.job_no;
            model.shift_no = view.shift_no;
            model.client_no = view.client_no;
            model.client_name = view.client_name;
            model.commit_status_no = string.IsNullOrEmpty(view.commit_status_no) ? "400" : view.commit_status_no;
            model.commit_status_name = string.IsNullOrEmpty(view.commit_status_name) ? "未下发" : view.commit_status_name;
            model.procedure_finished_qty = string.IsNullOrEmpty(view.procedure_finished_qty) ? 0.0M : (decimal.TryParse(view.procedure_finished_qty, out tmpDecimal) ? tmpDecimal : 0.0M);
            model.procedure_status_name = string.IsNullOrEmpty(view.procedure_status_name) ? "未开工" : view.procedure_status_name;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.MpoView Model2View(Model.TableModel.Mpo model)
        {
            ModelView.MpoView view = new ModelView.MpoView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;

            view.crt_user_no = model.crt_user_no;
            view.crt_user_name = model.crt_user_name;
            view.crt_time = model.crt_time.ToString("yyyy-MM-dd HH:mm:ss.fff");
            view.upd_user_no = model.upd_user_no;
            view.upd_user_name = model.upd_user_name;
            view.upd_time = model.upd_time.ToString("yyyy-MM-dd HH:mm:ss.fff");

            view.mpo_no = model.mpo_no;
            view.mpo_type_no = model.mpo_type_no;
            view.mpo_type_name = model.mpo_type_name;
            view.part_no = model.part_no;
            view.part_name = model.part_name;
            view.part_spec = model.part_spec;
            view.part_unit = model.part_unit;

            view.mpo_qty = decimal.Round(model.mpo_qty,MidpointRounding.AwayFromZero).ToString();
            view.mpo_hope_start_datetime = model.mpo_hope_start_datetime.HasValue?((DateTime)model.mpo_hope_start_datetime).ToString("yyyy-MM-dd"):string.Empty;
            view.mpo_hope_end_datetime = model.mpo_hope_end_datetime.HasValue ? ((DateTime)model.mpo_hope_end_datetime).ToString("yyyy-MM-dd") : string.Empty;
            view.workshop_no = model.workshop_no;
            view.factory_no = model.factory_no;
            view.line_no = model.line_no;
            view.job_no = model.job_no;
            view.shift_no = model.shift_no;
            view.client_no = model.client_no;
            view.client_name = model.client_name;
            view.commit_status_no = model.commit_status_no;
            view.commit_status_name = model.commit_status_name;
            view.procedure_finished_qty = decimal.Round(model.procedure_finished_qty, MidpointRounding.AwayFromZero).ToString();
            view.procedure_status_name = model.procedure_status_name;
            return view;
        }
    }
}
