using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 质检评定结果控制类
    /// </summary>
    public class QcmQaResultCtrl:ICtrlOperate
    {/// <summary>
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
            ModelView.QcmQaResultView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.QcmQaResultView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.QcmQaResultView newValue)
        {
            Model.TableModel.Qcm_qa_result model = View2Model(newValue);
            List<Model.TableModel.Qcm_qa_result> modelList = new List<Model.TableModel.Qcm_qa_result>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Qcm_qa_result>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.QcmQaResultView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.QcmQaResultView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.QcmQaResultView newValue)
        {
            Model.TableModel.Qcm_qa_result model = View2Model(newValue);
            List<Model.TableModel.Qcm_qa_result> modelList = new List<Model.TableModel.Qcm_qa_result>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Qcm_qa_result>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.QcmQaResultView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.QcmQaResultView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.QcmQaResultView oldValue)
        {
            Model.TableModel.Qcm_qa_result model = View2Model(oldValue);
            List<Model.TableModel.Qcm_qa_result> modelList = new List<Model.TableModel.Qcm_qa_result>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Qcm_qa_result>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.QcmQaResultView> oldValues)
        {
            List<Model.TableModel.Qcm_qa_result> modelList = new List<Model.TableModel.Qcm_qa_result>();
            foreach (ModelView.QcmQaResultView item in oldValues)
            {
                Model.TableModel.Qcm_qa_result model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Qcm_qa_result>("Delete", modelList);
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
            List<Model.TableModel.Qcm_qa_result> list = DbEngine.QueryPage<Model.TableModel.Qcm_qa_result>("qcm_qa_result", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.QcmQaResultView> res = new List<ModelView.QcmQaResultView>();
            foreach (Model.TableModel.Qcm_qa_result item in list)
            {
                ModelView.QcmQaResultView model = Model2View(item);
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
        public List<ModelView.QcmQaResultView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Qcm_qa_result> list = DbEngine.QueryPage<Model.TableModel.Qcm_qa_result>("qcm_qa_result", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.QcmQaResultView> res = new List<ModelView.QcmQaResultView>();
            foreach (Model.TableModel.Qcm_qa_result item in list)
            {
                ModelView.QcmQaResultView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Qcm_qa_result View2Model(ModelView.QcmQaResultView view)
        {
            Model.TableModel.Qcm_qa_result model = new Model.TableModel.Qcm_qa_result();
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
            model.result_no = string.IsNullOrEmpty(view.result_no) ? globalDataCtrl.GetNextNoByTblName("qcm_qa_result") : view.result_no;
            model.result_name = view.result_name;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.QcmQaResultView Model2View(Model.TableModel.Qcm_qa_result model)
        {
            ModelView.QcmQaResultView view = new ModelView.QcmQaResultView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            view.result_no = model.result_no;
            view.result_name = model.result_name;
            return view;
        }
    }
}
