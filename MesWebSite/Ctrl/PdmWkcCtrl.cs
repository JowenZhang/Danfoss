using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 工作中心视图控制类
    /// </summary>
    public class PdmWkcCtrl:ICtrlOperate
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
            ModelView.PdmWkcView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.PdmWkcView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.PdmWkcView newValue)
        {
            Model.TableModel.Pdm_wkc model = View2Model(newValue);
            List<Model.TableModel.Pdm_wkc> modelList = new List<Model.TableModel.Pdm_wkc>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Pdm_wkc>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.PdmWkcView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.PdmWkcView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.PdmWkcView newValue)
        {
            Model.TableModel.Pdm_wkc model = View2Model(newValue);
            List<Model.TableModel.Pdm_wkc> modelList = new List<Model.TableModel.Pdm_wkc>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Pdm_wkc>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.PdmWkcView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.PdmWkcView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.PdmWkcView oldValue)
        {
            Model.TableModel.Pdm_wkc model = View2Model(oldValue);
            List<Model.TableModel.Pdm_wkc> modelList = new List<Model.TableModel.Pdm_wkc>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Pdm_wkc>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.PdmWkcView> oldValues)
        {
            List<Model.TableModel.Pdm_wkc> modelList = new List<Model.TableModel.Pdm_wkc>();
            foreach (ModelView.PdmWkcView item in oldValues)
            {
                Model.TableModel.Pdm_wkc model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Pdm_wkc>("Delete", modelList);
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
            List<Model.TableModel.Pdm_wkc> list = DbEngine.QueryPage<Model.TableModel.Pdm_wkc>("pdm_wkc", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.PdmWkcView> res = new List<ModelView.PdmWkcView>();
            foreach (Model.TableModel.Pdm_wkc item in list)
            {
                ModelView.PdmWkcView model = Model2View(item);
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
        public List<ModelView.PdmWkcView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Pdm_wkc> list = DbEngine.QueryPage<Model.TableModel.Pdm_wkc>("pdm_wkc", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.PdmWkcView> res = new List<ModelView.PdmWkcView>();
            foreach (Model.TableModel.Pdm_wkc item in list)
            {
                ModelView.PdmWkcView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Pdm_wkc View2Model(ModelView.PdmWkcView view)
        {
            Model.TableModel.Pdm_wkc model = new Model.TableModel.Pdm_wkc();
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
            model.wkc_no = string.IsNullOrEmpty(view.wkc_no) ? globalDataCtrl.GetNextNoByTblName("pdm_wkc") : view.wkc_no;
            model.wkc_name = view.wkc_name;
            model.wkc_card_no = view.wkc_card_no;
            model.wkc_type = view.wkc_type;
            model.factory_no=string.IsNullOrEmpty(view.factory_no)?"dfs_f":view.factory_no;
            model.workshop_no = string.IsNullOrEmpty(view.workshop_no) ? "ws01" : view.workshop_no;
            model.line_no = string.IsNullOrEmpty(view.line_no) ? "line01" : view.line_no;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.PdmWkcView Model2View(Model.TableModel.Pdm_wkc model)
        {
            ModelView.PdmWkcView view = new ModelView.PdmWkcView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            view.wkc_no = model.wkc_no;
            view.wkc_name = model.wkc_name;
            view.wkc_card_no = model.wkc_card_no;
            view.wkc_type = model.wkc_type;
            view.factory_no = model.factory_no;
            view.workshop_no = model.workshop_no;
            view.line_no = model.line_no;
            return view;
        }
    }
}
