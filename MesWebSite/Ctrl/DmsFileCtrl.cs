using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 文件视图控制类
    /// </summary>
    public class DmsFileCtrl:ICtrlOperate
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
            ModelView.DmsFileView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.DmsFileView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.DmsFileView newValue)
        {
            try
            {
                Model.TableModel.Dms_file model = View2Model(newValue);
                Ctrl.Bll.ApoActBll apoActBll = new Bll.ApoActBll();
                apoActBll.CreateApprove(Model2View(model), newValue.login_user_no);
                List<Model.TableModel.Dms_file> modelList = new List<Model.TableModel.Dms_file>();
                modelList.Add(model);
                return DbEngine.QueryInt<Model.TableModel.Dms_file>("Insert", modelList);
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.DmsFileView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.DmsFileView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="listNewValue">更新后的视图模板类的集合</param>
        /// <returns>影响记录条数</returns>
        public int Update(List<ModelView.DmsFileView> listNewValue)
        {
            List<Model.TableModel.Dms_file> modelList = new List<Model.TableModel.Dms_file>();
            foreach (ModelView.DmsFileView item in listNewValue)
            {
                Model.TableModel.Dms_file model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Dms_file>("update", modelList);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.DmsFileView newValue)
        {
            Model.TableModel.Dms_file model = View2Model(newValue);
            List<Model.TableModel.Dms_file> modelList = new List<Model.TableModel.Dms_file>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Dms_file>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.DmsFileView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.DmsFileView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.DmsFileView oldValue)
        {
            Model.TableModel.Dms_file model = View2Model(oldValue);
            List<Model.TableModel.Dms_file> modelList = new List<Model.TableModel.Dms_file>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Dms_file>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.DmsFileView> oldValues)
        {
            List<Model.TableModel.Dms_file> modelList = new List<Model.TableModel.Dms_file>();
            foreach (ModelView.DmsFileView item in oldValues)
            {
                Model.TableModel.Dms_file model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Dms_file>("Delete", modelList);
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
            List<Model.TableModel.Dms_file> list = DbEngine.QueryPage<Model.TableModel.Dms_file>("dms_file", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.DmsFileView> res = new List<ModelView.DmsFileView>();
            foreach (Model.TableModel.Dms_file item in list)
            {
                ModelView.DmsFileView model = Model2View(item);
                res.Add(model);
            }
            return Common.JsonHelper.SerializeObject(new { total = total, rows = res });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileNo"></param>
        /// <param name="fileTypeNo"></param>
        /// <param name="eqmNo"></param>
        /// <returns>需要更新日期的文件列表</returns>
        public List<ModelView.DmsFileView> GetList(string fileNo, string eqmNo, string fileTypeNo)
        {
            List<Model.TableModel.Dms_file> list = DbEngine.QueryList<Model.TableModel.Dms_file>(string.Format(" file_type_no='{0}' and eqm_no='{1}' and file_no<>'{2}' and valid_date_end is null",fileTypeNo,eqmNo,fileNo));
            return list.Select<Model.TableModel.Dms_file,ModelView.DmsFileView>(Model2View).ToList();
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
        public List<ModelView.DmsFileView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Dms_file> list = DbEngine.QueryPage<Model.TableModel.Dms_file>("dms_file", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.DmsFileView> res = new List<ModelView.DmsFileView>();
            foreach (Model.TableModel.Dms_file item in list)
            {
                ModelView.DmsFileView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 根据条件获取视图
        /// </summary>
        /// <param name="where">where条件</param>
        /// <returns>结果视图</returns>
        public ModelView.DmsFileView GetView(string where=null)
        {
            if (string.IsNullOrEmpty(where))
            {
                return null;
            }
            List<Model.TableModel.Dms_file> list=DbEngine.QueryList<Model.TableModel.Dms_file>(where);
            if (list==null)
            {
                return null;
            }
            if (list.Count!=1)
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
        private Model.TableModel.Dms_file View2Model(ModelView.DmsFileView view)
        {
            Model.TableModel.Dms_file model = new Model.TableModel.Dms_file();
            if (string.IsNullOrEmpty(view.id))
            {
                model.id = Common.Md5Operate.CreateGuidId();
            }
            else
            {
                model.id = view.id;
            }
            GlobalDataCtrl globalDataCtrl = new GlobalDataCtrl();
            
            model.file_no = string.IsNullOrEmpty(view.file_no) ? globalDataCtrl.GetNextNoByTblName("mpo_item") : view.file_no;
            model.file_name = System.IO.Path.GetFileNameWithoutExtension(view.file_info);
            model.file_extension = System.IO.Path.GetExtension(view.file_info);
            model.file_type_no = string.IsNullOrEmpty(view.file_type_no) ? "01" : view.file_type_no;
            model.file_type_name = view.file_type_name;

            model.file_version = string.IsNullOrEmpty(view.file_version) ? "1" : view.file_version;
            model.file_desc = view.file_desc;
            model.eqm_no = string.IsNullOrEmpty(view.eqm_no) ? "EqmNo" : view.eqm_no;
            model.file_md5 = string.IsNullOrEmpty(view.file_md5) ? "FileMd5" : view.file_md5;
            model.is_passed = string.IsNullOrEmpty(view.is_passed) ? false : (view.is_passed=="是"?true:false);
            model.file_status = string.IsNullOrEmpty(view.file_status) ? "未确认" : view.file_status;
            model.ralate_file_name =view.ralate_file_name;

            DateTime tmpDt = DateTime.Now;
            model.valid_date_start = string.IsNullOrEmpty(view.valid_date_start) ? (DateTime?)null : (DateTime.TryParse(view.valid_date_start, out tmpDt) ? tmpDt : (DateTime?)null);
            model.valid_date_end = string.IsNullOrEmpty(view.valid_date_end) ? (DateTime?)null : (DateTime.TryParse(view.valid_date_end, out tmpDt) ? tmpDt : (DateTime?)null);

            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.DmsFileView Model2View(Model.TableModel.Dms_file model)
        {
            ModelView.DmsFileView view = new ModelView.DmsFileView();
            view.id = model.id;
            view.file_no = model.file_no;
            view.file_name = model.file_name;
            view.file_extension = model.file_extension;
            view.file_info = model.file_name + model.file_extension;
            view.file_type_no = model.file_type_no;
            view.file_type_name = model.file_type_name;
            view.file_version = model.file_version;
            view.file_desc = model.file_desc;

            view.eqm_no = model.eqm_no;
            view.file_md5 = model.file_md5;
            view.is_passed = model.is_passed?"是":"否";
            view.file_status = model.file_status;
            view.ralate_file_name = model.ralate_file_name;


            view.valid_date_start = model.valid_date_start.HasValue ? ((DateTime)model.valid_date_start).ToString("yyyy-MM-dd") : string.Empty;
            view.valid_date_end = model.valid_date_end.HasValue ? ((DateTime)model.valid_date_end).ToString("yyyy-MM-dd HH:mm:ss.fff") : string.Empty;
            return view;
        }

        
    }
}
