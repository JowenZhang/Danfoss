using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 审核流程视图控制类
    /// </summary>
    public class ApoItemCtrl : ICtrlOperate
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
            ModelView.ApoItemView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.ApoItemView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.ApoItemView newValue)
        {
            Model.TableModel.Apo_item model = View2Model(newValue);
            List<Model.TableModel.Apo_item> modelList = new List<Model.TableModel.Apo_item>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Apo_item>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.ApoItemView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.ApoItemView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.ApoItemView newValue)
        {
            Model.TableModel.Apo_item model = View2Model(newValue);
            List<Model.TableModel.Apo_item> modelList = new List<Model.TableModel.Apo_item>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Apo_item>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.ApoItemView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.ApoItemView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.ApoItemView oldValue)
        {
            Model.TableModel.Apo_item model = View2Model(oldValue);
            List<Model.TableModel.Apo_item> modelList = new List<Model.TableModel.Apo_item>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Apo_item>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.ApoItemView> oldValues)
        {
            List<Model.TableModel.Apo_item> modelList = new List<Model.TableModel.Apo_item>();
            foreach (ModelView.ApoItemView item in oldValues)
            {
                Model.TableModel.Apo_item model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Apo_item>("Delete", modelList);
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
            List<Model.TableModel.Apo_item> list = DbEngine.QueryPage<Model.TableModel.Apo_item>("apo_item", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.ApoItemView> res = new List<ModelView.ApoItemView>();
            foreach (Model.TableModel.Apo_item item in list)
            {
                ModelView.ApoItemView model = Model2View(item);
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
        public List<ModelView.ApoItemView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Apo_item> list = DbEngine.QueryPage<Model.TableModel.Apo_item>("apo_item", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.ApoItemView> res = new List<ModelView.ApoItemView>();
            foreach (Model.TableModel.Apo_item item in list)
            {
                ModelView.ApoItemView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 获取特定条件列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns>视图对象列表</returns>
        public List<ModelView.ApoItemView> GetList(string where)
        {
            List<Model.TableModel.Apo_item> list = DbEngine.QueryList<Model.TableModel.Apo_item>(where);
            List<ModelView.ApoItemView> res = new List<ModelView.ApoItemView>();
            foreach (Model.TableModel.Apo_item item in list)
            {
                ModelView.ApoItemView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 获取审批流实体中的第一个审批视图
        /// </summary>
        /// <param name="apoNo">审批类型</param>
        /// <returns>审批视图</returns>
        public ModelView.ApoItemView GetFirst(string apoNo)
        {
            List<Model.TableModel.Apo_item> list = DbEngine.QueryList<Model.TableModel.Apo_item>(string.Format("apo_no='{0}' and apo_index=0", apoNo));
            if (list == null)
            {
                return null;
            }
            if (list.Count != 1)
            {
                return null;
            }
            return Model2View(list[0]);
        }

        /// <summary>
        /// 获取审批流实体中的最后一个审批视图
        /// </summary>
        /// <param name="apoNo">审批类型</param>
        /// <returns>审批视图</returns>
        public ModelView.ApoItemView GetLast(string apoNo)
        {
            List<Model.TableModel.Apo_item> list = DbEngine.QueryList<Model.TableModel.Apo_item>(string.Format("apo_no='{0}' and next_item_no='-1'", apoNo));
            if (list == null)
            {
                return null;
            }
            if (list.Count != 1)
            {
                return null;
            }
            return Model2View(list[0]);
        }

        /// <summary>
        /// 获取下一审批实体
        /// </summary>
        /// <param name="apoNo">审核流程</param>
        /// <param name="apoItemNo">当前审批实体流程编号</param>
        /// <returns>审批实体</returns>
        public ModelView.ApoItemView GetNext(string apoNo, string apoItemNo)
        {
            GlobalDataCtrl gdc = new GlobalDataCtrl();
            string nextApoItemNo = gdc.GetStrByField("next_item_no", "apo_item", string.Format("apo_no='{0}' and apo_item_no='{1}'", apoNo, apoItemNo));
            List<Model.TableModel.Apo_item> list = DbEngine.QueryList<Model.TableModel.Apo_item>(string.Format("apo_no='{0}' and apo_item_no='{1}'", apoNo, nextApoItemNo));
            if (list == null)
            {
                return null;
            }
            if (list.Count != 1)
            {
                return null;
            }
            return Model2View(list[0]);
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Apo_item View2Model(ModelView.ApoItemView view)
        {
            Model.TableModel.Apo_item model = new Model.TableModel.Apo_item();
            if (string.IsNullOrEmpty(view.id))
            {
                model.id = Common.Md5Operate.CreateGuidId();
            }
            else
            {
                model.id = view.id;
            }
            string tmp=string.IsNullOrEmpty(view.apo_index)?"1":view.apo_index;
            model.apo_index = int.Parse(tmp);
            model.apo_item_name = view.apo_item_name;
            model.apo_item_no = view.apo_item_no;
            model.apo_no = string.IsNullOrEmpty(view.apo_no)?"UNKNOWN":view.apo_no;
            GlobalDataCtrl globalDataCtrl = new GlobalDataCtrl();
            model.apo_item_no = string.IsNullOrEmpty(view.apo_item_no)?globalDataCtrl.GetNextNoByTblName("apo_item"):view.apo_item_no;
            DateTime dt=DateTime.Now;
            DateTime.TryParse(view.crt_time, out dt);
            model.crt_time =   dt;
            model.crt_user_name = string.IsNullOrEmpty(view.crt_user_name) ? "Server" : view.crt_user_name;
            model.crt_user_no = string.IsNullOrEmpty(view.crt_user_no) ? "Server" : view.crt_user_no;
            DateTime.TryParse(view.upd_time, out dt);
            model.upd_time = dt;
            model.upd_user_name = string.IsNullOrEmpty(view.upd_user_name) ? "Server" : view.upd_user_name;
            model.upd_user_no = string.IsNullOrEmpty(view.upd_user_no) ? "Server" : view.upd_user_no;
            model.status_name = view.status_name;
            model.status_no = string.IsNullOrEmpty(view.status_no)?"310":view.status_no;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.ApoItemView Model2View(Model.TableModel.Apo_item model)
        {
            ModelView.ApoItemView view = new ModelView.ApoItemView();
            view.id = model.id;
            view.apo_index=model.apo_index.ToString();
            view.apo_item_name = model.apo_item_name;
            view.apo_item_no = model.apo_item_no;
            view.apo_no = model.apo_no;
            view.apo_user_name = model.apo_user_name;
            view.apo_user_no = model.apo_user_no;
            view.crt_time = model.crt_time.ToString("yyyy-MM-dd HH:mm:ss.fff");
            view.crt_user_name = model.crt_user_name;
            view.crt_user_no = model.crt_user_no;
            view.next_item_no = model.next_item_no;
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            view.upd_time = model.upd_time.HasValue?((DateTime)model.upd_time).ToString("yyyy-MM-dd HH:mm:ss.fff"):string.Empty;
            view.upd_user_name = model.upd_user_name;
            view.upd_user_no = model.upd_user_no;
            return view;
        }
    }
}
