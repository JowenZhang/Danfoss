using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 生产线视图控制类
    /// </summary>
    public class PdmLineCtrl:ICtrlOperate
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
            ModelView.PdmLineView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.PdmLineView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.PdmLineView newValue)
        {
            Model.TableModel.Pdm_line model = View2Model(newValue);
            List<Model.TableModel.Pdm_line> modelList = new List<Model.TableModel.Pdm_line>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Pdm_line>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.PdmLineView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.PdmLineView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.PdmLineView newValue)
        {
            Model.TableModel.Pdm_line model = View2Model(newValue);
            List<Model.TableModel.Pdm_line> modelList = new List<Model.TableModel.Pdm_line>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Pdm_line>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.PdmLineView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.PdmLineView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.PdmLineView oldValue)
        {
            Model.TableModel.Pdm_line model = View2Model(oldValue);
            List<Model.TableModel.Pdm_line> modelList = new List<Model.TableModel.Pdm_line>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Pdm_line>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.PdmLineView> oldValues)
        {
            List<Model.TableModel.Pdm_line> modelList = new List<Model.TableModel.Pdm_line>();
            foreach (ModelView.PdmLineView item in oldValues)
            {
                Model.TableModel.Pdm_line model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Pdm_line>("Delete", modelList);
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
            List<Model.TableModel.Pdm_line> list = DbEngine.QueryPage<Model.TableModel.Pdm_line>("pdm_line", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.PdmLineView> res = new List<ModelView.PdmLineView>();
            foreach (Model.TableModel.Pdm_line item in list)
            {
                ModelView.PdmLineView model = Model2View(item);
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
        public List<ModelView.PdmLineView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Pdm_line> list = DbEngine.QueryPage<Model.TableModel.Pdm_line>("pdm_line", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.PdmLineView> res = new List<ModelView.PdmLineView>();
            foreach (Model.TableModel.Pdm_line item in list)
            {
                ModelView.PdmLineView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Pdm_line View2Model(ModelView.PdmLineView view)
        {
            Model.TableModel.Pdm_line model = new Model.TableModel.Pdm_line();
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
            model.line_no = string.IsNullOrEmpty(view.line_no) ? globalDataCtrl.GetNextNoByTblName("pdm_line") : view.line_no;
            model.line_name = view.line_name;
            model.line_desc = view.line_desc;
            model.workshop_no = string.IsNullOrEmpty(view.workshop_no) ? "ws01" : view.workshop_no;
            model.workshop_name = view.workshop_name;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.PdmLineView Model2View(Model.TableModel.Pdm_line model)
        {
            ModelView.PdmLineView view = new ModelView.PdmLineView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            view.line_no = model.line_no;
            view.line_name = model.line_name;
            view.line_desc = model.line_desc;
            view.workshop_name = model.workshop_name;
            view.workshop_no = model.workshop_no;            
            return view;
        }
    }
}
