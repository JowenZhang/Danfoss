using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    //计划数量视图操作类
    public class MpoPlanCtrl:ICtrlOperate
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
            ModelView.MpoPlanView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.MpoPlanView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.MpoPlanView newValue)
        {
            Model.TableModel.Mpo_plan model = View2Model(newValue);
            List<Model.TableModel.Mpo_plan> modelList = new List<Model.TableModel.Mpo_plan>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Mpo_plan>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.MpoPlanView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.MpoPlanView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="listNewValue">更新后的视图模板类的集合</param>
        /// <returns>影响记录条数</returns>
        public int Update(List<ModelView.MpoPlanView> listNewValue)
        {
            List<Model.TableModel.Mpo_plan> modelList = new List<Model.TableModel.Mpo_plan>();
            foreach (ModelView.MpoPlanView item in listNewValue)
            {
                Model.TableModel.Mpo_plan model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Mpo_plan>("update", modelList);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.MpoPlanView newValue)
        {
            Model.TableModel.Mpo_plan model = View2Model(newValue);
            List<Model.TableModel.Mpo_plan> modelList = new List<Model.TableModel.Mpo_plan>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Mpo_plan>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.MpoPlanView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.MpoPlanView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.MpoPlanView oldValue)
        {
            Model.TableModel.Mpo_plan model = View2Model(oldValue);
            List<Model.TableModel.Mpo_plan> modelList = new List<Model.TableModel.Mpo_plan>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Mpo_plan>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.MpoPlanView> oldValues)
        {
            List<Model.TableModel.Mpo_plan> modelList = new List<Model.TableModel.Mpo_plan>();
            foreach (ModelView.MpoPlanView item in oldValues)
            {
                Model.TableModel.Mpo_plan model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Mpo_plan>("Delete", modelList);
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
            List<Model.TableModel.Mpo_plan> list = DbEngine.QueryPage<Model.TableModel.Mpo_plan>("mpo_plan", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.MpoPlanView> res = new List<ModelView.MpoPlanView>();
            foreach (Model.TableModel.Mpo_plan item in list)
            {
                ModelView.MpoPlanView model = Model2View(item);
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
        public List<ModelView.MpoPlanView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Mpo_plan> list = DbEngine.QueryPage<Model.TableModel.Mpo_plan>("mpo_plan", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.MpoPlanView> res = new List<ModelView.MpoPlanView>();
            foreach (Model.TableModel.Mpo_plan item in list)
            {
                ModelView.MpoPlanView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

       

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Mpo_plan View2Model(ModelView.MpoPlanView view)
        {
            Model.TableModel.Mpo_plan model = new Model.TableModel.Mpo_plan();
            if (string.IsNullOrEmpty(view.id))
            {
                model.id = Common.Md5Operate.CreateGuidId();
            }
            else
            {
                model.id = view.id;
            }
            DateTime dt = DateTime.Now.Date;
            model.plan_date = string.IsNullOrEmpty(view.plan_date) ? DateTime.Now.Date : DateTime.TryParse(view.plan_date, out dt) ? dt.Date : DateTime.Now.Date;
            decimal tmpDec = 0;
            model.plan_qty = string.IsNullOrEmpty(view.plan_qty) ? 0 : (decimal.TryParse(view.plan_qty, out tmpDec) ? tmpDec : 0);
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.MpoPlanView Model2View(Model.TableModel.Mpo_plan model)
        {
            ModelView.MpoPlanView view = new ModelView.MpoPlanView();
            view.id = model.id;
            view.plan_date = model.plan_date.HasValue ? ((DateTime)model.plan_date).Date.ToString("yyyy-MM-dd") : string.Empty;
            view.plan_date_value = model.plan_date.HasValue ? ((DateTime)model.plan_date).Date.ToString("yyyy-MM-dd") : DateTime.Now.Date.ToString("M/d/yyyy");
            view.plan_qty = model.plan_qty.HasValue ? decimal.Round((decimal)model.plan_qty).ToString(): string.Empty;
            return view;
        }
    }
}
