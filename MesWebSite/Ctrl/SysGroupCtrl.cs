using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 集团视图控制类
    /// </summary>
    public class SysGroupCtrl:ICtrlOperate
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
            ModelView.SysGroupView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.SysGroupView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.SysGroupView newValue)
        {
            Model.TableModel.Sys_group model = View2Model(newValue);
            List<Model.TableModel.Sys_group> modelList = new List<Model.TableModel.Sys_group>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_group>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.SysGroupView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.SysGroupView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.SysGroupView newValue)
        {
            Model.TableModel.Sys_group model = View2Model(newValue);
            List<Model.TableModel.Sys_group> modelList = new List<Model.TableModel.Sys_group>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_group>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.SysGroupView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.SysGroupView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.SysGroupView oldValue)
        {
            Model.TableModel.Sys_group model = View2Model(oldValue);
            List<Model.TableModel.Sys_group> modelList = new List<Model.TableModel.Sys_group>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_group>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.SysGroupView> oldValues)
        {
            List<Model.TableModel.Sys_group> modelList = new List<Model.TableModel.Sys_group>();
            foreach (ModelView.SysGroupView item in oldValues)
            {
                Model.TableModel.Sys_group model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Sys_group>("Delete", modelList);
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
            List<Model.TableModel.Sys_group> list = DbEngine.QueryPage<Model.TableModel.Sys_group>("sys_group", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.SysGroupView> res = new List<ModelView.SysGroupView>();
            foreach (Model.TableModel.Sys_group item in list)
            {
                ModelView.SysGroupView model = Model2View(item);
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
        public List<ModelView.SysGroupView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Sys_group> list = DbEngine.QueryPage<Model.TableModel.Sys_group>("sys_group", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.SysGroupView> res = new List<ModelView.SysGroupView>();
            foreach (Model.TableModel.Sys_group item in list)
            {
                ModelView.SysGroupView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Sys_group View2Model(ModelView.SysGroupView view)
        {
            Model.TableModel.Sys_group model = new Model.TableModel.Sys_group();
            if (string.IsNullOrEmpty(view.id))
            {
                model.id = Common.Md5Operate.CreateGuidId();
            }
            else
            {
                model.id = view.id;
            }
            GlobalDataCtrl globalDataCtrl = new GlobalDataCtrl();
            model.group_no = string.IsNullOrEmpty(view.group_no)?globalDataCtrl.GetNextNoByTblName("sys_group"):view.group_no;
            model.group_name = view.group_name;
            model.status_name = view.status_name;
            model.status_no = string.IsNullOrEmpty(view.status_no) ? "310" : view.status_no;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.SysGroupView Model2View(Model.TableModel.Sys_group model)
        {
            ModelView.SysGroupView view = new ModelView.SysGroupView();
            view.id = model.id;
            view.group_no = model.group_no;
            view.group_name = model.group_name;
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            return view;
        }
    }
}
