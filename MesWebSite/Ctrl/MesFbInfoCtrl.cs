using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 记录信息视图操作类
    /// </summary>
    public class MesFbInfoCtrl:ICtrlOperate
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
            ModelView.MesFbInfoView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.MesFbInfoView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.MesFbInfoView newValue)
        {
            Model.TableModel.Mes_fb_info model = View2Model(newValue);
            List<Model.TableModel.Mes_fb_info> modelList = new List<Model.TableModel.Mes_fb_info>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Mes_fb_info>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.MesFbInfoView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.MesFbInfoView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="listNewValue">更新后的视图模板类的集合</param>
        /// <returns>影响记录条数</returns>
        public int Update(List<ModelView.MesFbInfoView> listNewValue)
        {
            List<Model.TableModel.Mes_fb_info> modelList = new List<Model.TableModel.Mes_fb_info>();
            foreach (ModelView.MesFbInfoView item in listNewValue)
            {
                Model.TableModel.Mes_fb_info model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Mes_fb_info>("update", modelList);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.MesFbInfoView newValue)
        {
            Model.TableModel.Mes_fb_info model = View2Model(newValue);
            List<Model.TableModel.Mes_fb_info> modelList = new List<Model.TableModel.Mes_fb_info>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Mes_fb_info>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.MesFbInfoView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.MesFbInfoView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.MesFbInfoView oldValue)
        {
            Model.TableModel.Mes_fb_info model = View2Model(oldValue);
            List<Model.TableModel.Mes_fb_info> modelList = new List<Model.TableModel.Mes_fb_info>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Mes_fb_info>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.MesFbInfoView> oldValues)
        {
            List<Model.TableModel.Mes_fb_info> modelList = new List<Model.TableModel.Mes_fb_info>();
            foreach (ModelView.MesFbInfoView item in oldValues)
            {
                Model.TableModel.Mes_fb_info model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Mes_fb_info>("Delete", modelList);
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
            List<Model.TableModel.Mes_fb_info> list = DbEngine.QueryPage<Model.TableModel.Mes_fb_info>("mes_fb_info", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.MesFbInfoView> res = new List<ModelView.MesFbInfoView>();
            foreach (Model.TableModel.Mes_fb_info item in list)
            {
                ModelView.MesFbInfoView model = Model2View(item);
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
        public List<ModelView.MesFbInfoView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Mes_fb_info> list = DbEngine.QueryPage<Model.TableModel.Mes_fb_info>("mes_fb_info", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.MesFbInfoView> res = new List<ModelView.MesFbInfoView>();
            foreach (Model.TableModel.Mes_fb_info item in list)
            {
                ModelView.MesFbInfoView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// SPC查询
        /// </summary>
        /// <param name="eqmNo">工站名称</param>
        /// <param name="information">查询的信息</param>
        /// <param name="partNo">型号</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>查询的视图列表</returns>
        public List<ModelView.MesFbInfoView> GetList4Spc(string eqmNo, string information, string partNo,DateTime startTime, DateTime endTime)
        {
            string where = string.Format("eqm_no= '{0}' and information='{1}' and (create_time between '{2}' and '{3}') and part_no like '%{4}%';", eqmNo, information, startTime.ToString("yyyy-MM-dd HH:mm:ss"), endTime.ToString("yyyy-MM-dd HH:mm:ss"),partNo);
            List<Model.TableModel.Mes_fb_info> list = DbEngine.QueryList<Model.TableModel.Mes_fb_info>(where);
            return list.Select(a => Model2View(a)).ToList();
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Mes_fb_info View2Model(ModelView.MesFbInfoView view)
        {
            Model.TableModel.Mes_fb_info model = new Model.TableModel.Mes_fb_info();
            if (string.IsNullOrEmpty(view.id))
            {
                model.id = Common.Md5Operate.CreateGuidId();
            }
            else
            {
                model.id = view.id;
            }
            model.serial_no = string.IsNullOrEmpty(view.serial_no) ? null : view.serial_no;
            model.eqm_no = string.IsNullOrEmpty(view.eqm_no) ? null : view.eqm_no;
            model.information = string.IsNullOrEmpty(view.information) ? null : view.information;
            model.information_value = string.IsNullOrEmpty(view.information_value) ? null : view.information_value;
            model.part_no = view.part_no;
            DateTime dt = DateTime.Now;
            model.create_time = string.IsNullOrEmpty(view.create_time) ? DateTime.Now : DateTime.TryParse(view.create_time, out dt) ? dt.Date : DateTime.Now;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.MesFbInfoView Model2View(Model.TableModel.Mes_fb_info model)
        {
            ModelView.MesFbInfoView view = new ModelView.MesFbInfoView();
            view.id = model.id;
            view.serial_no = model.serial_no;
            view.eqm_no = model.eqm_no;
            view.part_no = model.part_no;
            view.information = model.information;
            view.information_value = model.information_value;
            view.create_time=model.create_time.HasValue?((DateTime)model.create_time).ToString("yyyy-MM-dd HH:mm:ss.fff"):string.Empty;
            return view;
        }
    }
}
