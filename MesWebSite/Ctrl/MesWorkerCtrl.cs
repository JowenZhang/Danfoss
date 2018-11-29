using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 作业员视图控制类
    /// </summary>
    public class MesWorkerCtrl:ICtrlOperate
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
            ModelView.MesWorkerView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.MesWorkerView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.MesWorkerView newValue)
        {
            Model.TableModel.Mes_worker model = View2Model(newValue);
            List<Model.TableModel.Mes_worker> modelList = new List<Model.TableModel.Mes_worker>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Mes_worker>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.MesWorkerView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.MesWorkerView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.MesWorkerView newValue)
        {
            Model.TableModel.Mes_worker model = View2Model(newValue);
            List<Model.TableModel.Mes_worker> modelList = new List<Model.TableModel.Mes_worker>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Mes_worker>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.MesWorkerView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.MesWorkerView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.MesWorkerView oldValue)
        {
            Model.TableModel.Mes_worker model = View2Model(oldValue);
            List<Model.TableModel.Mes_worker> modelList = new List<Model.TableModel.Mes_worker>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Mes_worker>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.MesWorkerView> oldValues)
        {
            List<Model.TableModel.Mes_worker> modelList = new List<Model.TableModel.Mes_worker>();
            foreach (ModelView.MesWorkerView item in oldValues)
            {
                Model.TableModel.Mes_worker model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Mes_worker>("Delete", modelList);
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
            List<Model.TableModel.Mes_worker> list = DbEngine.QueryPage<Model.TableModel.Mes_worker>("mes_worker", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.MesWorkerView> res = new List<ModelView.MesWorkerView>();
            foreach (Model.TableModel.Mes_worker item in list)
            {
                ModelView.MesWorkerView model = Model2View(item);
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
        public List<ModelView.MesWorkerView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Mes_worker> list = DbEngine.QueryPage<Model.TableModel.Mes_worker>("mes_worker", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.MesWorkerView> res = new List<ModelView.MesWorkerView>();
            foreach (Model.TableModel.Mes_worker item in list)
            {
                ModelView.MesWorkerView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Mes_worker View2Model(ModelView.MesWorkerView view)
        {
            Model.TableModel.Mes_worker model = new Model.TableModel.Mes_worker();
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
            model.worker_no = string.IsNullOrEmpty(view.worker_no) ? globalDataCtrl.GetNextNoByTblName("mes_worker") : view.worker_no;
            model.worker_name = view.worker_name;
            model.worker_card_no = view.worker_card_no;
            model.worker_card_id = view.worker_card_id;
            model.factory_no = string.IsNullOrEmpty(view.factory_no)?"dfs_f":view.factory_no;
            model.workshop_no = view.workshop_no; 
            model.line_no = view.line_no;
            model.job_no = view.job_no;
            model.shift_no = view.shift_no;
            model.worker_mobile = view.worker_mobile;
            model.worker_email = view.worker_email;
            decimal rate = 0.0M;
            decimal.TryParse(view.worker_rate, out rate);
            model.worker_rate = decimal.Round(rate, 4,MidpointRounding.AwayFromZero);
            model.worker_group_no = view.worker_group_no;
            DateTime dt;
            model.in_date = DateTime.TryParse(view.in_date_attach, out dt) ? dt : (DateTime?)null;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.MesWorkerView Model2View(Model.TableModel.Mes_worker model)
        {
            ModelView.MesWorkerView view = new ModelView.MesWorkerView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            view.worker_no = model.worker_no;
            view.worker_name = model.worker_name;
            view.worker_card_no = model.worker_card_no;
            view.worker_card_id = model.worker_card_id;
            view.factory_no = model.factory_no;
            view.workshop_no = model.workshop_no;
            view.line_no = model.line_no;
            view.job_no = model.job_no;
            view.shift_no = model.shift_no;
            view.worker_mobile = model.worker_mobile;
            view.worker_email = model.worker_email;
            view.worker_rate = model.worker_rate.ToString();
            view.worker_group_no = model.worker_group_no;
            view.in_date = model.in_date.HasValue?((DateTime)model.in_date).ToString("yyyy-MM-dd"):string.Empty;
            view.in_date_attach=model.in_date.HasValue?((DateTime)model.in_date).ToString("M/d/yyyy"):DateTime.Now.ToString("M/d/yyyy");
            view.workshop_no = model.workshop_no;
            return view;
        }
    }
}
