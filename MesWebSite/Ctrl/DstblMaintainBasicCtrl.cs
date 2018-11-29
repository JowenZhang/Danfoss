using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 设备保养视图控制类
    /// </summary>
    public class DstblMaintainBasicCtrl:ICtrlOperate
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
            ModelView.DstblMaintainBasicView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.DstblMaintainBasicView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.DstblMaintainBasicView newValue)
        {
            Model.TableModel.DStbl_Maintain_Basic model = View2Model(newValue);
            List<Model.TableModel.DStbl_Maintain_Basic> modelList = new List<Model.TableModel.DStbl_Maintain_Basic>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.DStbl_Maintain_Basic>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.DstblMaintainBasicView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.DstblMaintainBasicView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.DstblMaintainBasicView newValue)
        {
            Model.TableModel.DStbl_Maintain_Basic model = View2Model(newValue);
            List<Model.TableModel.DStbl_Maintain_Basic> modelList = new List<Model.TableModel.DStbl_Maintain_Basic>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.DStbl_Maintain_Basic>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.DstblMaintainBasicView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.DstblMaintainBasicView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.DstblMaintainBasicView oldValue)
        {
            Model.TableModel.DStbl_Maintain_Basic model = View2Model(oldValue);
            List<Model.TableModel.DStbl_Maintain_Basic> modelList = new List<Model.TableModel.DStbl_Maintain_Basic>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.DStbl_Maintain_Basic>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.DstblMaintainBasicView> oldValues)
        {
            List<Model.TableModel.DStbl_Maintain_Basic> modelList = new List<Model.TableModel.DStbl_Maintain_Basic>();
            foreach (ModelView.DstblMaintainBasicView item in oldValues)
            {
                Model.TableModel.DStbl_Maintain_Basic model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.DStbl_Maintain_Basic>("Delete", modelList);
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
            List<Model.TableModel.DStbl_Maintain_Basic> list = DbEngine.QueryPage<Model.TableModel.DStbl_Maintain_Basic>("DStbl_Maintain_Basic", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.DstblMaintainBasicView> res = new List<ModelView.DstblMaintainBasicView>();
            foreach (Model.TableModel.DStbl_Maintain_Basic item in list)
            {
                ModelView.DstblMaintainBasicView model = Model2View(item);
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
        public List<ModelView.DstblMaintainBasicView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.DStbl_Maintain_Basic> list = DbEngine.QueryPage<Model.TableModel.DStbl_Maintain_Basic>("DStbl_Maintain_Basic", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.DstblMaintainBasicView> res = new List<ModelView.DstblMaintainBasicView>();
            foreach (Model.TableModel.DStbl_Maintain_Basic item in list)
            {
                ModelView.DstblMaintainBasicView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>Model.TableModel.DStbl_Maintain_Basic
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.DStbl_Maintain_Basic View2Model(ModelView.DstblMaintainBasicView view)
        {
            Model.TableModel.DStbl_Maintain_Basic model = new Model.TableModel.DStbl_Maintain_Basic();
                long res=0;
                long.TryParse(view.AutoID,out res);
                model.AutoID = res;
            model.Workshop = view.Workshop;
            model.SubLine = view.SubLine;
            model.DeviceName = view.DeviceName;
            int tmpInt=0;
            int.TryParse(view.DeviceXh, out tmpInt);               
            model.DeviceXh =  tmpInt;
            model.Part = view.Part;
            model.Item = view.Item;
            model.PartCode = view.PartCode;
            model.Taskinformation = view.Taskinfomation;
            model.Basicrequest = view.Basicrequest;
            model.Notice = view.Notice;
            model.Detectcondition = view.Detectcondition;
            model.Beginmonth = view.Beginmonth;
            tmpInt = 0;
            int.TryParse(view.Period, out tmpInt); 
            model.Period = tmpInt;
            model.Aftermaintain=view.Aftermaintain;
            tmpInt = 0;
            int.TryParse(view.compel, out tmpInt);
            model.compel=tmpInt;
            model.make_date=view.make_date;
            tmpInt = 0;
            int.TryParse(view.w_man_hour, out tmpInt);
            model.w_man_hour=tmpInt;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.DstblMaintainBasicView Model2View(Model.TableModel.DStbl_Maintain_Basic model)
        {
            ModelView.DstblMaintainBasicView view = new ModelView.DstblMaintainBasicView();
            view.AutoID = model.AutoID.ToString();
            view.Workshop = model.Workshop;
            view.SubLine = model.SubLine;
            view.DeviceName = model.DeviceName;
            view.DeviceXh = model.DeviceXh.ToString();
            view.Part = model.Part;
            view.Taskinfomation = model.Taskinformation;
            view.Basicrequest = model.Basicrequest;
            view.Notice = model.Notice;
            view.Detectcondition = model.Detectcondition;
            view.Beginmonth = model.Beginmonth;
            view.Period = model.Period.ToString();
            view.Aftermaintain = model.Aftermaintain;
            view.compel = model.compel.ToString();
            view.make_date = model.make_date;
            view.w_man_hour = model.w_man_hour.ToString();
            return view;
        }
    }
}
