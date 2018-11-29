using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 设备状态控制类
    /// </summary>
    public class PdmEqmCtrl:ICtrlOperate
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
            ModelView.PdmEqmView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.PdmEqmView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.PdmEqmView newValue)
        {
            Model.TableModel.Pdm_eqm model = View2Model(newValue);
            List<Model.TableModel.Pdm_eqm> modelList = new List<Model.TableModel.Pdm_eqm>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Pdm_eqm>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.PdmEqmView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.PdmEqmView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.PdmEqmView newValue)
        {
            Model.TableModel.Pdm_eqm model = View2Model(newValue);
            List<Model.TableModel.Pdm_eqm> modelList = new List<Model.TableModel.Pdm_eqm>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Pdm_eqm>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.PdmEqmView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.PdmEqmView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.PdmEqmView oldValue)
        {
            Model.TableModel.Pdm_eqm model = View2Model(oldValue);
            List<Model.TableModel.Pdm_eqm> modelList = new List<Model.TableModel.Pdm_eqm>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Pdm_eqm>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.PdmEqmView> oldValues)
        {
            List<Model.TableModel.Pdm_eqm> modelList = new List<Model.TableModel.Pdm_eqm>();
            foreach (ModelView.PdmEqmView item in oldValues)
            {
                Model.TableModel.Pdm_eqm model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Pdm_eqm>("Delete", modelList);
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
            List<Model.TableModel.Pdm_eqm> list = DbEngine.QueryPage<Model.TableModel.Pdm_eqm>("pdm_eqm", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.PdmEqmView> res = new List<ModelView.PdmEqmView>();
            foreach (Model.TableModel.Pdm_eqm item in list)
            {
                ModelView.PdmEqmView model = Model2View(item);
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
        public List<ModelView.PdmEqmView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Pdm_eqm> list = DbEngine.QueryPage<Model.TableModel.Pdm_eqm>("pdm_eqm", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.PdmEqmView> res = new List<ModelView.PdmEqmView>();
            foreach (Model.TableModel.Pdm_eqm item in list)
            {
                ModelView.PdmEqmView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Pdm_eqm View2Model(ModelView.PdmEqmView view)
        {
            Model.TableModel.Pdm_eqm model = new Model.TableModel.Pdm_eqm();
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
            model.eqm_no = string.IsNullOrEmpty(view.eqm_no)?globalDataCtrl.GetNextNoByTblName("pdm_eqm"):view.eqm_no;
            model.eqm_name = view.eqm_name;
            model.eqm_desc = view.eqm_desc;
            int tmp=0;
            int.TryParse(view.eqm_index,out tmp);
            model.eqm_index = tmp;
            model.wkc_no =  view.wkc_no;
            model.eqm_status = string.IsNullOrEmpty(view.eqm_status) ? "正常" : view.eqm_status;
            model.eqm_lock = view.eqm_lock=="无锁定"?null:view.eqm_lock;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.PdmEqmView Model2View(Model.TableModel.Pdm_eqm model)
        {
            ModelView.PdmEqmView view = new ModelView.PdmEqmView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;            
            view.eqm_no = model.eqm_no;
            view.eqm_name = model.eqm_name;
            view.eqm_desc = model.eqm_desc;
            view.eqm_index = model.eqm_index.ToString();            
            view.wkc_no = model.wkc_no;
            view.eqm_status = model.eqm_status;
            view.eqm_lock = string.IsNullOrEmpty(model.eqm_lock)?"无锁定":model.eqm_lock;
            return view;
        }
    }
}
