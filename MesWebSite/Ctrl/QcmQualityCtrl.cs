using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 质量不良结果视图控制类
    /// </summary>
    public class QcmQualityCtrl:ICtrlOperate
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
            ModelView.QcmQualityView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.QcmQualityView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.QcmQualityView newValue)
        {
            Model.TableModel.Qcm_quality model = View2Model(newValue);
            List<Model.TableModel.Qcm_quality> modelList = new List<Model.TableModel.Qcm_quality>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Qcm_quality>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.QcmQualityView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.QcmQualityView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.QcmQualityView newValue)
        {
            Model.TableModel.Qcm_quality model = View2Model(newValue);
            List<Model.TableModel.Qcm_quality> modelList = new List<Model.TableModel.Qcm_quality>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Qcm_quality>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.QcmQualityView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.QcmQualityView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.QcmQualityView oldValue)
        {
            Model.TableModel.Qcm_quality model = View2Model(oldValue);
            List<Model.TableModel.Qcm_quality> modelList = new List<Model.TableModel.Qcm_quality>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Qcm_quality>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.QcmQualityView> oldValues)
        {
            List<Model.TableModel.Qcm_quality> modelList = new List<Model.TableModel.Qcm_quality>();
            foreach (ModelView.QcmQualityView item in oldValues)
            {
                Model.TableModel.Qcm_quality model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Qcm_quality>("Delete", modelList);
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
            List<Model.TableModel.Qcm_quality> list = DbEngine.QueryPage<Model.TableModel.Qcm_quality>("qcm_quality", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.QcmQualityView> res = new List<ModelView.QcmQualityView>();
            foreach (Model.TableModel.Qcm_quality item in list)
            {
                ModelView.QcmQualityView model = Model2View(item);
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
        public List<ModelView.QcmQualityView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Qcm_quality> list = DbEngine.QueryPage<Model.TableModel.Qcm_quality>("qcm_quality", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.QcmQualityView> res = new List<ModelView.QcmQualityView>();
            foreach (Model.TableModel.Qcm_quality item in list)
            {
                ModelView.QcmQualityView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Qcm_quality View2Model(ModelView.QcmQualityView view)
        {
            Model.TableModel.Qcm_quality model = new Model.TableModel.Qcm_quality();
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
            model.quality_no = string.IsNullOrEmpty(view.quality_no) ? globalDataCtrl.GetNextNoByTblName("qcm_quality") : view.quality_no;
            model.quality_name = view.quality_name;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.QcmQualityView Model2View(Model.TableModel.Qcm_quality model)
        {
            ModelView.QcmQualityView view = new ModelView.QcmQualityView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            view.quality_no = model.quality_no;
            view.quality_name = model.quality_name;
            return view;
        }
    }
}
