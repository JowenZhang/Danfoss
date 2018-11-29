using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 质量异常原因视图控制类
    /// </summary>
    public class QcmQaCauseCtrl:ICtrlOperate
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
            ModelView.QcmQaCauseView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.QcmQaCauseView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.QcmQaCauseView newValue)
        {
            Model.TableModel.Qcm_qa_cause model = View2Model(newValue);
            List<Model.TableModel.Qcm_qa_cause> modelList = new List<Model.TableModel.Qcm_qa_cause>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Qcm_qa_cause>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.QcmQaCauseView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.QcmQaCauseView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.QcmQaCauseView newValue)
        {
            Model.TableModel.Qcm_qa_cause model = View2Model(newValue);
            List<Model.TableModel.Qcm_qa_cause> modelList = new List<Model.TableModel.Qcm_qa_cause>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Qcm_qa_cause>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.QcmQaCauseView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.QcmQaCauseView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.QcmQaCauseView oldValue)
        {
            Model.TableModel.Qcm_qa_cause model = View2Model(oldValue);
            List<Model.TableModel.Qcm_qa_cause> modelList = new List<Model.TableModel.Qcm_qa_cause>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Qcm_qa_cause>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.QcmQaCauseView> oldValues)
        {
            List<Model.TableModel.Qcm_qa_cause> modelList = new List<Model.TableModel.Qcm_qa_cause>();
            foreach (ModelView.QcmQaCauseView item in oldValues)
            {
                Model.TableModel.Qcm_qa_cause model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Qcm_qa_cause>("Delete", modelList);
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
            List<Model.TableModel.Qcm_qa_cause> list = DbEngine.QueryPage<Model.TableModel.Qcm_qa_cause>("qcm_qa_cause", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.QcmQaCauseView> res = new List<ModelView.QcmQaCauseView>();
            foreach (Model.TableModel.Qcm_qa_cause item in list)
            {
                ModelView.QcmQaCauseView model = Model2View(item);
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
        public List<ModelView.QcmQaCauseView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Qcm_qa_cause> list = DbEngine.QueryPage<Model.TableModel.Qcm_qa_cause>("qcm_qa_cause", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.QcmQaCauseView> res = new List<ModelView.QcmQaCauseView>();
            foreach (Model.TableModel.Qcm_qa_cause item in list)
            {
                ModelView.QcmQaCauseView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Qcm_qa_cause View2Model(ModelView.QcmQaCauseView view)
        {
            Model.TableModel.Qcm_qa_cause model = new Model.TableModel.Qcm_qa_cause();
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
            model.qa_cause_no = string.IsNullOrEmpty(view.qa_cause_no) ? globalDataCtrl.GetNextNoByTblName("qcm_qa_quality") : view.qa_cause_no;
            model.qa_cause_name = view.qa_cause_name;
            model.qa_cause_py = view.qa_cause_py;
            model.qa_cause_is_default = !string.IsNullOrEmpty(view.qa_cause_is_default) && view.qa_cause_is_default == "是";
            model.factory_no = view.factory_no;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.QcmQaCauseView Model2View(Model.TableModel.Qcm_qa_cause model)
        {
            ModelView.QcmQaCauseView view = new ModelView.QcmQaCauseView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            view.qa_cause_no = model.qa_cause_no;
            view.qa_cause_name = model.qa_cause_name;
            view.qa_cause_py = model.qa_cause_py;
            view.qa_cause_is_default = model.qa_cause_is_default?"是":"否";
            view.factory_no = model.factory_no;
            return view;
        }
    }
}
