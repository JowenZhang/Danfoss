using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 审核动作视图控制类
    /// </summary>
    public class ApoActCtrl:ICtrlOperate
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
            ModelView.ApoActView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.ApoActView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.ApoActView newValue)
        {
            Model.TableModel.Apo_act model = View2Model(newValue);
            List<Model.TableModel.Apo_act> modelList = new List<Model.TableModel.Apo_act>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Apo_act>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.ApoActView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.ApoActView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="listNewValue">更新后的视图模板类的集合</param>
        /// <returns>影响记录条数</returns>
        public int Update(List<ModelView.ApoActView> listNewValue)
        {
            List<Model.TableModel.Apo_act> modelList = new List<Model.TableModel.Apo_act>();
            foreach (ModelView.ApoActView item in listNewValue)
            {
                Model.TableModel.Apo_act model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Apo_act>("update", modelList);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.ApoActView newValue)
        {
            Model.TableModel.Apo_act model = View2Model(newValue);
            List<Model.TableModel.Apo_act> modelList = new List<Model.TableModel.Apo_act>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Apo_act>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.ApoActView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.ApoActView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.ApoActView oldValue)
        {
            Model.TableModel.Apo_act model = View2Model(oldValue);
            List<Model.TableModel.Apo_act> modelList = new List<Model.TableModel.Apo_act>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Apo_act>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.ApoActView> oldValues)
        {
            List<Model.TableModel.Apo_act> modelList = new List<Model.TableModel.Apo_act>();
            foreach (ModelView.ApoActView item in oldValues)
            {
                Model.TableModel.Apo_act model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Apo_act>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="ralateNo">关联编号</param>
        /// <returns>影响记录条数</returns>
        public int DeleteByRalate(string ralateNo)
        {
            string sql="delete from apo_act where ralate_no=@ralate_no";
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@ralate_no", ralateNo);
            return DbEngine.QueryInt(sql, pms);
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
            List<Model.TableModel.Apo_act> list = DbEngine.QueryPage<Model.TableModel.Apo_act>("apo_act", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.ApoActView> res = new List<ModelView.ApoActView>();
            foreach (Model.TableModel.Apo_act item in list)
            {
                ModelView.ApoActView model = Model2View(item);
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
        public List<ModelView.ApoActView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Apo_act> list = DbEngine.QueryPage<Model.TableModel.Apo_act>("apo_act", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.ApoActView> res = new List<ModelView.ApoActView>();
            foreach (Model.TableModel.Apo_act item in list)
            {
                ModelView.ApoActView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 获取第一个审核流程视图
        /// </summary>
        /// <param name="ralateNo">关联数据</param>
        /// <returns>返回第一个结果视图</returns>
        public ModelView.ApoActView GetFirst(string ralateNo)//fileNo
        {
            return GetView(string.Format("ralate_no='{0}' and act_step=0", ralateNo));
        }

        /// <summary>
        /// 获取所有未结束审核流程视图
        /// </summary>
        /// <param name="ralateNo">关联数据</param>
        /// <returns>返回所有未结束审核流程结果视图</returns>
        public List<ModelView.ApoActView> GetUpdate(string ralateNo)//fileNo
        {
            return GetList(string.Format("ralate_no='{0}' and apo_finished='0'", ralateNo));
        }

        /// <summary>
        /// 根据条件获取视图
        /// </summary>
        /// <param name="where">where条件</param>
        /// <returns>结果视图</returns>
        public ModelView.ApoActView GetView(string where=null)
        {
            List<ModelView.ApoActView> list = GetList(where);
            if (list==null)
            {
                return null;
            }
            if (list.Count!=1)
            {
                return null;
            }
            return list[0];
        }

        /// <summary>
        /// 根据条件获取所有的动作视图列表
        /// </summary>
        /// <param name="where">where条件</param>
        /// <returns>结果视图列表</returns>
        public List<ModelView.ApoActView> GetList(string where = null)
        { 
            List<Model.TableModel.Apo_act> list = DbEngine.QueryList<Model.TableModel.Apo_act>(where);
            return list.Select<Model.TableModel.Apo_act, ModelView.ApoActView>(a => Model2View(a)).ToList();
        }



        /// <summary>
        /// 获取审核路径
        /// </summary>
        /// <param name="apoCode">审核类型编码</param>
        /// <param name="ralateFileNo">审核的文件编号</param>
        /// <returns>标准审核流程列表</returns>
        public List<ModelView.ApoActView> GetList(string apoCode, string ralateFileNo)
        {
            List<ModelView.ApoActView> res = new List<ModelView.ApoActView>();
            GlobalDataCtrl gdc = new GlobalDataCtrl();
            string apoNo = gdc.GetStrByField("file_type_name", "dms_file_type", "file_type_no", apoCode);
            List<Model.TableModel.Apo_item> list = DbEngine.QueryList<Model.TableModel.Apo_item>(string.Format("apo_no='{0}' order by apo_index asc", apoNo));
            if (list == null || list.Count <= 0)
            {
                return res;
            }
            string lastApoItemNo = gdc.GetStrByField("apo_item_no", "apo_item", string.Format("next_item_no='-1' and apo_no='{0}'", apoNo));
            List<Model.TableModel.Apo_act> listApoActAll = DbEngine.QueryList<Model.TableModel.Apo_act>(string.Format("ralate_no='{0}' and apo_finished='0'", ralateFileNo));
            List<Model.TableModel.Apo_act> listApoAct = listApoActAll.FindAll(a =>  a.apo_item_no == lastApoItemNo);
            DateTime timeLine = DateTime.Now;
            List<DateTime> tmpTims = listApoAct.Select<Model.TableModel.Apo_act, DateTime>(a => a.act_time).ToList();
            bool isBigAndEqual = false;
            if (tmpTims.Count > 0)
            {
                timeLine = tmpTims.Max();
                isBigAndEqual = false;
            }
            else
            {
                List<DateTime> tmpTims2 = listApoActAll.Select<Model.TableModel.Apo_act, DateTime>(a => a.act_time).ToList();
                timeLine = tmpTims2.Min();
                isBigAndEqual = true;
            }
            List<Model.TableModel.Apo_act> listApoActStep = isBigAndEqual ? listApoActAll.FindAll(a => a.act_time >= timeLine) : listApoActAll.FindAll(a => a.act_time > timeLine);
            foreach (Model.TableModel.Apo_item item in list)
            {
                Model.TableModel.Apo_act modelApoAct = listApoActStep.Find(a => a.apo_no == item.apo_no && a.apo_index == item.apo_index);
                if (modelApoAct != null)
                {
                    res.Add(Model2View(modelApoAct));
                }
                else
                {
                    res.Add(Model2View(item));
                }                
            }
            return res;
        }










        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Apo_act View2Model(ModelView.ApoActView view)
        {
            Model.TableModel.Apo_act model = new Model.TableModel.Apo_act();
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
            model.act_no = string.IsNullOrEmpty(view.act_no) ? globalDataCtrl.GetNextNoByTblName("apo_act") : view.act_no;
            model.apo_no = string.IsNullOrEmpty(view.apo_no)?"ApoNo":view.apo_no;
            model.apo_item_no = string.IsNullOrEmpty(view.apo_item_no) ? "ApoItemNo" : view.apo_item_no;
            model.apo_item_name = string.IsNullOrEmpty(view.apo_item_name) ? "ApoItemName" : view.apo_item_name;
            int tmpInt = 0;
            model.apo_index = string.IsNullOrEmpty(view.apo_index) ? 0 : (int.TryParse(view.apo_index,out tmpInt)?tmpInt:0);
            model.next_item_no = string.IsNullOrEmpty(view.next_item_no) ? "NextItemNo" : view.next_item_no;
            model.next_item_name = string.IsNullOrEmpty(view.next_item_name) ? "NextItemName" : view.next_item_name;
            model.next_user_name = string.IsNullOrEmpty(view.next_user_name) ? "NextUserName" : view.next_user_name;
            model.act_desc = view.act_desc;
            model.act_result = view.act_result == "通过" ? true : false;
            model.act_step = string.IsNullOrEmpty(view.act_step) ? 0 : (int.TryParse(view.act_step, out tmpInt) ? tmpInt : 0);
            model.act_user_no = string.IsNullOrEmpty(view.act_user_no) ? "ActUserNo" : view.act_user_no;
            model.act_user_name = string.IsNullOrEmpty(view.act_user_name) ? "ActUserName" : view.act_user_name;
            DateTime dt=DateTime.Now;
            model.act_time = string.IsNullOrEmpty(view.act_time) ? DateTime.Now : DateTime.TryParse(view.act_time,out dt)?dt:DateTime.Now;
            model.ralate_no = string.IsNullOrEmpty(view.ralate_no) ? "RalateNo" : view.ralate_no;
            model.ralate_file_name = string.IsNullOrEmpty(view.ralate_file_name) ? "RalateFileName" : view.ralate_file_name;
            model.ralate_file_extension = string.IsNullOrEmpty(view.ralate_file_extension) ?"RalateFileExtension": view.ralate_file_extension;
            model.ralate_type_no = string.IsNullOrEmpty(view.ralate_type_no) ? "RalateTypeNo" : view.ralate_type_no;
            model.step_finished = view.step_finished == "是" ? true : false;
            model.apo_finished = view.apo_finished == "是" ? true : false;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.ApoActView Model2View(Model.TableModel.Apo_act model)
        {
            ModelView.ApoActView view = new ModelView.ApoActView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            view.act_no = model.act_no;
            view.apo_no = model.apo_no;
            view.apo_item_no = model.apo_item_no;
            view.apo_item_name = model.apo_item_name;
            view.apo_index = model.apo_index.ToString();
            view.next_item_no = model.next_item_no;
            view.next_item_name = model.next_item_name;
            view.next_user_name = model.next_user_name;
            view.act_desc = model.act_desc;
            view.act_result = model.act_result?"通过":"驳回";
            view.act_step = model.act_step.ToString();
            view.act_user_no = model.act_user_no;
            view.act_user_name = model.act_user_name;
            view.act_time = model.act_time.ToString("yyyy-MM-dd HH:mm:ss.fff");
            view.ralate_no = model.ralate_no;
            view.ralate_file_name = model.ralate_file_name;
            view.ralate_file_extension = model.ralate_file_extension;
            view.ralate_type_no = model.ralate_type_no;
            view.step_finished = model.step_finished ? "是" : "否";
            view.apo_finished = model.apo_finished ? "是" : "否";
            Ctrl.GlobalDataCtrl gdc=new GlobalDataCtrl();
            view.dept_no = gdc.GetStrByField("dept_no", "sys_user", "user_no", view.act_user_no);
            view.dept_name = gdc.GetStrByField("dept_name", "sys_dept", "dept_no", view.act_user_no);
            return view;
        }


        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">标准流程实体类</param>
        /// <returns>视图类</returns>
        private ModelView.ApoActView Model2View(Model.TableModel.Apo_item model)
        {
            ModelView.ApoActView view = new ModelView.ApoActView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            view.act_no = string.Empty;
            view.apo_no = model.apo_no;
            view.apo_item_no = model.apo_item_no;
            view.apo_item_name = model.apo_item_name;
            view.apo_index = model.apo_index.ToString();
            view.next_item_no = model.next_item_no;
            view.next_item_name = string.Empty;
            view.next_user_name = string.Empty;
            view.act_desc = string.Empty;
            view.act_result = string.Empty;
            view.act_step = string.Empty;
            view.act_user_no = string.Empty;
            view.act_user_name = string.Empty;
            view.act_time = string.Empty;
            view.ralate_no = string.Empty;
            view.ralate_file_name = string.Empty;
            view.ralate_file_extension = string.Empty;
            view.ralate_type_no = string.Empty;
            view.step_finished = string.Empty;
            view.apo_finished = string.Empty;
            view.dept_no = string.Empty;
            view.dept_name = string.Empty;
            return view;
        }
    }
}
