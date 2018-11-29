using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 子生产订单视图控制类
    /// </summary>
    public class MpoItemCtrl:ICtrlOperate
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
            ModelView.MpoItemView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.MpoItemView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.MpoItemView newValue)
        {
            Model.TableModel.Mpo_item model = View2Model(newValue);
            List<Model.TableModel.Mpo_item> modelList = new List<Model.TableModel.Mpo_item>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Mpo_item>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.MpoItemView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.MpoItemView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="listNewValue">更新后的视图模板类的集合</param>
        /// <returns>影响记录条数</returns>
        public int Update(List<ModelView.MpoItemView> listNewValue) 
        {
            List<Model.TableModel.Mpo_item> modelList = new List<Model.TableModel.Mpo_item>();
            foreach (ModelView.MpoItemView item in listNewValue)
            {
                Model.TableModel.Mpo_item model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Mpo_item>("update", modelList);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.MpoItemView newValue)
        {
            Model.TableModel.Mpo_item model = View2Model(newValue);
            List<Model.TableModel.Mpo_item> modelList = new List<Model.TableModel.Mpo_item>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Mpo_item>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.MpoItemView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.MpoItemView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.MpoItemView oldValue)
        {
            Model.TableModel.Mpo_item model = View2Model(oldValue);
            List<Model.TableModel.Mpo_item> modelList = new List<Model.TableModel.Mpo_item>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Mpo_item>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.MpoItemView> oldValues)
        {
            List<Model.TableModel.Mpo_item> modelList = new List<Model.TableModel.Mpo_item>();
            foreach (ModelView.MpoItemView item in oldValues)
            {
                Model.TableModel.Mpo_item model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Mpo_item>("Delete", modelList);
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
            List<Model.TableModel.Mpo_item> list = DbEngine.QueryPage<Model.TableModel.Mpo_item>("mpo_item", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.MpoItemView> res = new List<ModelView.MpoItemView>();
            foreach (Model.TableModel.Mpo_item item in list)
            {
                ModelView.MpoItemView model = Model2View(item);
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
        public List<ModelView.MpoItemView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Mpo_item> list = DbEngine.QueryPage<Model.TableModel.Mpo_item>("mpo_item", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.MpoItemView> res = new List<ModelView.MpoItemView>();
            foreach (Model.TableModel.Mpo_item item in list)
            {
                ModelView.MpoItemView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Mpo_item View2Model(ModelView.MpoItemView view)
        {
            Model.TableModel.Mpo_item model = new Model.TableModel.Mpo_item();
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
            model.serial_no = string.IsNullOrEmpty(view.serial_no) ? globalDataCtrl.GetNextNoByTblName("mpo_item") : view.serial_no;
            model.item_no = model.serial_no;
            model.part_no = string.IsNullOrEmpty(view.part_no) ? "PartNo" : view.part_no;
            model.mpo_no = string.IsNullOrEmpty(view.mpo_no) ? "MpoNo" : view.mpo_no;
            decimal tmpDecimal = 0;
            model.item_qty = string.IsNullOrEmpty(view.item_qty) ? 1.0M : (decimal.TryParse(view.item_qty, out tmpDecimal) ? tmpDecimal : 1.0M);
            DateTime tmpDt = DateTime.Now;
            model.hope_product_time = string.IsNullOrEmpty(view.hope_product_time) ? (DateTime?)null : (DateTime.TryParse(view.hope_product_time, out tmpDt) ? tmpDt : (DateTime?)null);
            model.print_time = string.IsNullOrEmpty(view.print_time) ? model.hope_product_time : (DateTime.TryParse(view.hope_product_time, out tmpDt) ? tmpDt : model.hope_product_time);

            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.MpoItemView Model2View(Model.TableModel.Mpo_item model)
        {
            ModelView.MpoItemView view = new ModelView.MpoItemView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            view.item_qty = decimal.Round(model.item_qty, MidpointRounding.AwayFromZero).ToString();
            view.mpo_no = model.mpo_no;
            view.item_no = model.item_no;
            view.serial_no = model.serial_no;
            view.part_no = model.part_no;
            view.hope_product_time=model.hope_product_time.HasValue?((DateTime)model.hope_product_time).ToString("yyyy-MM-dd HH:mm:ss.fff"):string.Empty;
            view.print_time = model.print_time.HasValue ? ((DateTime)model.print_time).ToString("yyyy-MM-dd HH:mm:ss.fff") : string.Empty;
            return view;
        }
    }
}
