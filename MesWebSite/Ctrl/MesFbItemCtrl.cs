using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 报工详情视图控制类
    /// </summary>
    public class MesFbItemCtrl:ICtrlOperate
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
            ModelView.MesFbItemView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.MesFbItemView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.MesFbItemView newValue)
        {
            Model.TableModel.Mes_fb_item model = View2Model(newValue);
            List<Model.TableModel.Mes_fb_item> modelList = new List<Model.TableModel.Mes_fb_item>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Mes_fb_item>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            List<ModelView.MesFbItemView> models = Common.JsonHelper.DeserializeJsonToList<ModelView.MesFbItemView>(jsonStr);
            return Update(models);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="listNewValue">更新后的视图模板类的集合</param>
        /// <returns>影响记录条数</returns>
        public int Update(List<ModelView.MesFbItemView> listNewValue)
        {
            List<Model.TableModel.Mes_fb_item> modelList = new List<Model.TableModel.Mes_fb_item>();
            foreach (ModelView.MesFbItemView item in listNewValue)
            {
                Model.TableModel.Mes_fb_item model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Mes_fb_item>("update", modelList);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.MesFbItemView newValue)
        {
            Model.TableModel.Mes_fb_item model = View2Model(newValue);
            List<Model.TableModel.Mes_fb_item> modelList = new List<Model.TableModel.Mes_fb_item>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Mes_fb_item>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.MesFbItemView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.MesFbItemView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.MesFbItemView oldValue)
        {
            Model.TableModel.Mes_fb_item model = View2Model(oldValue);
            List<Model.TableModel.Mes_fb_item> modelList = new List<Model.TableModel.Mes_fb_item>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Mes_fb_item>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.MesFbItemView> oldValues)
        {
            List<Model.TableModel.Mes_fb_item> modelList = new List<Model.TableModel.Mes_fb_item>();
            foreach (ModelView.MesFbItemView item in oldValues)
            {
                Model.TableModel.Mes_fb_item model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Mes_fb_item>("Delete", modelList);
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
            List<Model.TableModel.Mes_fb_item> list = DbEngine.QueryPage<Model.TableModel.Mes_fb_item>("mes_fb_item", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.MesFbItemView> res = new List<ModelView.MesFbItemView>();
            foreach (Model.TableModel.Mes_fb_item item in list)
            {
                ModelView.MesFbItemView model = Model2View(item);
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
        public List<ModelView.MesFbItemView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Mes_fb_item> list = DbEngine.QueryPage<Model.TableModel.Mes_fb_item>("mes_fb_item", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.MesFbItemView> res = new List<ModelView.MesFbItemView>();
            foreach (Model.TableModel.Mes_fb_item item in list)
            {
                ModelView.MesFbItemView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Mes_fb_item View2Model(ModelView.MesFbItemView view)
        {
            Model.TableModel.Mes_fb_item model = new Model.TableModel.Mes_fb_item();
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
            model.fb_item_no = string.IsNullOrEmpty(view.fb_item_no) ? globalDataCtrl.GetNextNoByTblName("mes_fb_item") : view.fb_item_no;
            
            model.fb_no = string.IsNullOrEmpty(view.fb_no) ? "FbNo" : view.fb_no;
            model.serial_no = string.IsNullOrEmpty(view.serial_no) ? "SerialNO" : view.serial_no;

            model.mpo_no = string.IsNullOrEmpty(view.mpo_no) ? "MpoNo" : view.mpo_no;
            model.part_no = view.part_no;
            DateTime tmpDt = DateTime.Now;
            model.fb_datetime = string.IsNullOrEmpty(view.fb_datetime) ? (DateTime?)null : (DateTime.TryParse(view.fb_datetime, out tmpDt) ? tmpDt : (DateTime?)null);
            model.quality_no = string.IsNullOrEmpty(view.quality_no) ? "QA01" : view.quality_no;
            model.worker_no = string.IsNullOrEmpty(view.worker_no) ? "Worker" : view.worker_no;
            model.worker_name = string.IsNullOrEmpty(view.worker_name) ? "Worker" : view.worker_name;
            model.eqm_no=string.IsNullOrEmpty(view.eqm_no)?"EqmNo":view.eqm_no;
            model.eqm_name = view.eqm_name;
            model.wkc_no = string.IsNullOrEmpty(view.wkc_no) ? "WkcNo" : view.wkc_no;
            model.wkc_name = view.wkc_name;
            model.shift_no = view.shift_no;
            model.shift_name = view.shift_name;
            model.cfm_user_no = string.IsNullOrEmpty(view.cfm_user_no) ? "Server" : view.cfm_user_no;
            model.cfm_user_name = string.IsNullOrEmpty(view.cfm_user_name) ? "Server" : view.cfm_user_name;
            model.cfm_time = string.IsNullOrEmpty(view.cfm_time) ? (DateTime?)null : (DateTime.TryParse(view.cfm_time, out tmpDt) ? tmpDt : (DateTime?)null);
            long tmpLong;
            model.in_id = string.IsNullOrEmpty(view.in_id) ? 0L : (long.TryParse(view.in_id, out tmpLong) ? tmpLong : 0L);
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.MesFbItemView Model2View(Model.TableModel.Mes_fb_item model)
        {
            ModelView.MesFbItemView view = new ModelView.MesFbItemView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;

            view.crt_user_no = model.crt_user_no;
            view.crt_user_name = model.crt_user_name;
            view.crt_time = model.crt_time.ToString("yyyy-MM-dd HH:mm:ss.fff");
            view.upd_user_no = model.upd_user_no;
            view.upd_user_name = model.upd_user_name;
            view.upd_time = model.upd_time.ToString("yyyy-MM-dd HH:mm:ss.fff");
            view.fb_item_no = model.fb_item_no;
            view.fb_no = model.fb_no;
            view.mpo_no = model.mpo_no;
            view.part_no = model.part_no;
            view.serial_no = model.serial_no;
            view.fb_datetime = model.fb_datetime.HasValue ? ((DateTime)model.fb_datetime).ToString("yyyy-MM-dd HH:mm:ss.fff") : string.Empty;
            view.quality_no = model.quality_no;
            view.worker_no = model.worker_no;
            view.worker_name = model.worker_name;           
            view.eqm_no = model.eqm_no;
            view.eqm_name = model.eqm_name;
            view.shift_no = model.shift_no;
            view.shift_name = model.shift_name;            
            view.cfm_user_no = model.cfm_user_no;
            view.cfm_user_name = model.cfm_user_name;
            view.cfm_time = model.cfm_time.HasValue ? ((DateTime)model.cfm_time).ToString("yyyy-MM-dd HH:mm:ss.fff") : string.Empty;
            view.in_id = model.in_id.HasValue ? model.in_id.ToString() : string.Empty;
            return view;
        }
    }
}
