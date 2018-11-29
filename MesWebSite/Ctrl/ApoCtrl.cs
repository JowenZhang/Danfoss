using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 审核类型视图控制类
    /// </summary>
    public class ApoCtrl : ICtrlOperate
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
            ModelView.ApoView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.ApoView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.ApoView newValue)
        {
            Model.TableModel.Apo model = View2Model(newValue);
            List<Model.TableModel.Apo> modelList = new List<Model.TableModel.Apo>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Apo>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.ApoView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.ApoView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.ApoView newValue)
        {
            Model.TableModel.Apo model = View2Model(newValue);
            List<Model.TableModel.Apo> modelList = new List<Model.TableModel.Apo>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Apo>("update", modelList);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象列表</param>
        /// <returns>影响记录条数</returns>
        public int Update(List<ModelView.ApoView> newValue)
        {
            List<Model.TableModel.Apo> modelList = newValue.Select<ModelView.ApoView,Model.TableModel.Apo>(a=>View2Model(a)).ToList();
            return DbEngine.QueryInt<Model.TableModel.Apo>("update", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.ApoView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.ApoView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.ApoView oldValue)
        {
            Model.TableModel.Apo model = View2Model(oldValue);
            List<Model.TableModel.Apo> modelList = new List<Model.TableModel.Apo>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Apo>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.ApoView> oldValues)
        {
            List<Model.TableModel.Apo> modelList = new List<Model.TableModel.Apo>();
            foreach (ModelView.ApoView item in oldValues)
            {
                Model.TableModel.Apo model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Apo>("Delete", modelList);
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
            List<Model.TableModel.Apo> list = DbEngine.QueryPage<Model.TableModel.Apo>("apo", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.ApoView> res = new List<ModelView.ApoView>();
            foreach (Model.TableModel.Apo item in list)
            {
                ModelView.ApoView model = Model2View(item);
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
        public List<ModelView.ApoView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Apo> list = DbEngine.QueryPage<Model.TableModel.Apo>("apo", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.ApoView> res = new List<ModelView.ApoView>();
            foreach (Model.TableModel.Apo item in list)
            {
                ModelView.ApoView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 获取特定条件列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns>视图对象列表</returns>
        public List<ModelView.ApoView> GetList(string where)
        {
            List<Model.TableModel.Apo> list = DbEngine.QueryList<Model.TableModel.Apo>(where);
            List<ModelView.ApoView> res = new List<ModelView.ApoView>();
            foreach (Model.TableModel.Apo item in list)
            {
                ModelView.ApoView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Apo View2Model(ModelView.ApoView view)
        {
            Model.TableModel.Apo model = new Model.TableModel.Apo();
            if (string.IsNullOrEmpty(view.id))
            {
                model.id = Common.Md5Operate.CreateGuidId();
            }
            else
            {
                model.id = view.id;
            }
            GlobalDataCtrl globalDataCtrl = new GlobalDataCtrl();
            model.apo_no = string.IsNullOrEmpty(view.apo_no) ? globalDataCtrl.GetNextNoByTblName("apo") : view.apo_no;
            model.apo_name = view.apo_name;
            DateTime dt = DateTime.Now;
            model.crt_time = DateTime.TryParse(view.crt_time, out dt) ? dt : DateTime.Now;
            model.crt_user_name = string.IsNullOrEmpty(view.crt_user_name) ? "Server" : view.crt_user_name;
            model.crt_user_no = string.IsNullOrEmpty(view.crt_user_no) ? "Server" : view.crt_user_no;
            model.upd_time = DateTime.TryParse(view.upd_time, out dt) ? dt : DateTime.Now;
            model.upd_user_name = string.IsNullOrEmpty(view.upd_user_name) ? "Server" : view.upd_user_name;
            model.upd_user_no = string.IsNullOrEmpty(view.upd_user_no) ? "Server" : view.upd_user_no;
            model.status_name = view.status_name;
            model.status_no = string.IsNullOrEmpty(view.status_no) ? "310" : view.status_no;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.ApoView Model2View(Model.TableModel.Apo model)
        {
            ModelView.ApoView view = new ModelView.ApoView();
            view.id = model.id;
            view.apo_no = model.apo_no;
            view.apo_name = model.apo_name;
            view.crt_time = model.crt_time.ToString("yyyy-MM-dd HH:mm:ss.fff");
            view.crt_user_name = model.crt_user_name;
            view.crt_user_no = model.crt_user_no;            
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            view.upd_time = model.upd_time.HasValue ? ((DateTime)model.upd_time).ToString("yyyy-MM-dd HH:mm:ss.fff") : string.Empty;
            view.upd_user_name = model.upd_user_name;
            view.upd_user_no = model.upd_user_no;
            return view;
        }
    }
}
