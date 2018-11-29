using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 班次视图控制类
    /// </summary>
    public class PdmShiftCtrl:ICtrlOperate
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
            ModelView.PdmShiftView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.PdmShiftView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.PdmShiftView newValue)
        {
            Model.TableModel.Pdm_shift model = View2Model(newValue);
            List<Model.TableModel.Pdm_shift> modelList = new List<Model.TableModel.Pdm_shift>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Pdm_shift>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.PdmShiftView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.PdmShiftView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.PdmShiftView newValue)
        {
            Model.TableModel.Pdm_shift model = View2Model(newValue);
            List<Model.TableModel.Pdm_shift> modelList = new List<Model.TableModel.Pdm_shift>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Pdm_shift>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.PdmShiftView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.PdmShiftView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.PdmShiftView oldValue)
        {
            Model.TableModel.Pdm_shift model = View2Model(oldValue);
            List<Model.TableModel.Pdm_shift> modelList = new List<Model.TableModel.Pdm_shift>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Pdm_shift>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.PdmShiftView> oldValues)
        {
            List<Model.TableModel.Pdm_shift> modelList = new List<Model.TableModel.Pdm_shift>();
            foreach (ModelView.PdmShiftView item in oldValues)
            {
                Model.TableModel.Pdm_shift model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Pdm_shift>("Delete", modelList);
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
            List<Model.TableModel.Pdm_shift> list = DbEngine.QueryPage<Model.TableModel.Pdm_shift>("pdm_shift", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.PdmShiftView> res = new List<ModelView.PdmShiftView>();
            foreach (Model.TableModel.Pdm_shift item in list)
            {
                ModelView.PdmShiftView model = Model2View(item);
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
        public List<ModelView.PdmShiftView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Pdm_shift> list = DbEngine.QueryPage<Model.TableModel.Pdm_shift>("pdm_shift", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.PdmShiftView> res = new List<ModelView.PdmShiftView>();
            foreach (Model.TableModel.Pdm_shift item in list)
            {
                ModelView.PdmShiftView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Pdm_shift View2Model(ModelView.PdmShiftView view)
        {
            Model.TableModel.Pdm_shift model = new Model.TableModel.Pdm_shift();
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
            GlobalDataCtrl globalDataCtrl = new GlobalDataCtrl();
            model.shift_no = string.IsNullOrEmpty(view.shift_no) ? globalDataCtrl.GetNextNoByTblName("pdm_shift") : view.shift_no;
            model.shift_name = view.shift_name;
            if (string.IsNullOrEmpty(view.shift_start_time))
            {
                model.shift_start_time = new DateTime(1900, 1, 1, 0, 0, 0);
            }
            else
            {
                DateTime dt = new DateTime(1900, 1, 1, 0, 0, 0);
                model.shift_start_time = DateTime.TryParse(string.Format("1900-01-01 {0}:00.000", view.shift_start_time), out dt) ? dt : new DateTime(1900, 1, 1, 0, 0, 0);
            }
            if (string.IsNullOrEmpty(view.shift_stop_time))
            {
                model.shift_stop_time = new DateTime(1900, 1, 1, 0, 0, 0);
            }
            else
            {
                DateTime dt = new DateTime(1900, 1, 1, 0, 0, 0);
                model.shift_stop_time = DateTime.TryParse(string.Format("1900-01-01 {0}:00.000", view.shift_stop_time), out dt) ? dt : new DateTime(1900, 1, 1, 0, 0, 0);
            }
            int startHour = model.shift_start_time.Hour;
            int startMinute = model.shift_start_time.Minute;
            int stopHour = model.shift_stop_time.Hour;
            int stopMinute = model.shift_stop_time.Minute;
            int minute =  stopHour * 60 + stopMinute-startHour * 60 - startMinute;
            model.shift_length = minute >= 0 ? minute : 0;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.PdmShiftView Model2View(Model.TableModel.Pdm_shift model)
        {
            ModelView.PdmShiftView view = new ModelView.PdmShiftView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            view.shift_no = model.shift_no;
            view.shift_name = model.shift_name;
            view.shift_start_time = model.shift_start_time.ToString("HH:mm");
            view.shift_stop_time = model.shift_stop_time.ToString("HH:mm");
            view.shift_1day_ahead = model.shift_1day_ahead.HasValue ? ((bool)model.shift_1day_ahead ? "是" : "否") : string.Empty;
            int startHour = model.shift_start_time.Hour;
            int startMinute = model.shift_start_time.Minute;
            int stopHour = model.shift_stop_time.Hour;
            int stopMinute = model.shift_stop_time.Minute;
            int minute = stopHour * 60 + stopMinute - startHour * 60 - startMinute;
            view.shift_length = (minute >= 0 ? minute : (24 * 60 + minute)).ToString();
            return view;
        }
    }
}
