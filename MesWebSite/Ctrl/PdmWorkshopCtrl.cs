using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 车间视图控制类
    /// </summary>
    public class PdmWorkshopCtrl:ICtrlOperate
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
            ModelView.PdmWorkshopView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.PdmWorkshopView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.PdmWorkshopView newValue)
        {
            Model.TableModel.Pdm_workshop model = View2Model(newValue);
            List<Model.TableModel.Pdm_workshop> modelList = new List<Model.TableModel.Pdm_workshop>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Pdm_workshop>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.PdmWorkshopView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.PdmWorkshopView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.PdmWorkshopView newValue)
        {
            Model.TableModel.Pdm_workshop model = View2Model(newValue);
            List<Model.TableModel.Pdm_workshop> modelList = new List<Model.TableModel.Pdm_workshop>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Pdm_workshop>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.PdmWorkshopView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.PdmWorkshopView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.PdmWorkshopView oldValue)
        {
            Model.TableModel.Pdm_workshop model = View2Model(oldValue);
            List<Model.TableModel.Pdm_workshop> modelList = new List<Model.TableModel.Pdm_workshop>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Pdm_workshop>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.PdmWorkshopView> oldValues)
        {
            List<Model.TableModel.Pdm_workshop> modelList = new List<Model.TableModel.Pdm_workshop>();
            foreach (ModelView.PdmWorkshopView item in oldValues)
            {
                Model.TableModel.Pdm_workshop model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Pdm_workshop>("Delete", modelList);
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
            List<Model.TableModel.Pdm_workshop> list = DbEngine.QueryPage<Model.TableModel.Pdm_workshop>("pdm_workshop", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.PdmWorkshopView> res = new List<ModelView.PdmWorkshopView>();
            foreach (Model.TableModel.Pdm_workshop item in list)
            {
                ModelView.PdmWorkshopView model = Model2View(item);
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
        public List<ModelView.PdmWorkshopView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Pdm_workshop> list = DbEngine.QueryPage<Model.TableModel.Pdm_workshop>("pdm_workshop", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.PdmWorkshopView> res = new List<ModelView.PdmWorkshopView>();
            foreach (Model.TableModel.Pdm_workshop item in list)
            {
                ModelView.PdmWorkshopView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Pdm_workshop View2Model(ModelView.PdmWorkshopView view)
        {
            Model.TableModel.Pdm_workshop model = new Model.TableModel.Pdm_workshop();
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
            model.workshop_no = string.IsNullOrEmpty(view.workshop_no) ? globalDataCtrl.GetNextNoByTblName("pdm_workshop") : view.workshop_no;
            model.workshop_name = view.workshop_name;
            model.factory_no = string.IsNullOrEmpty(view.factory_no) ? "dfs_f" : view.factory_no;
            model.factory_name = view.factory_name;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.PdmWorkshopView Model2View(Model.TableModel.Pdm_workshop model)
        {
            ModelView.PdmWorkshopView view = new ModelView.PdmWorkshopView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            view.workshop_name = model.workshop_name;
            view.workshop_no = model.workshop_no;
            view.factory_no = model.factory_no;
            view.factory_name = model.factory_name;
            return view;
        }
    }
}
