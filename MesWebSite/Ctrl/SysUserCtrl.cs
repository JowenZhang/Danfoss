using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 系统用户控制类
    /// </summary>
    public class SysUserCtrl:ICtrlOperate
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
            ModelView.SysUserView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.SysUserView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.SysUserView newValue)
        {
            Model.TableModel.Sys_user model = View2Model(newValue);
            List<Model.TableModel.Sys_user> modelList = new List<Model.TableModel.Sys_user>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_user>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.SysUserView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.SysUserView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.SysUserView newValue)
        {
            Model.TableModel.Sys_user model = View2Model(newValue);
            List<Model.TableModel.Sys_user> modelList = new List<Model.TableModel.Sys_user>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_user>("update", modelList);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="userModel">数据库实体</param>
        /// <returns>影响记录条数</returns>
        public int Update(Model.TableModel.Sys_user userModel)
        {
            return DbEngine.QueryInt<Model.TableModel.Sys_user>("update", new List<Model.TableModel.Sys_user>(){userModel});
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.SysUserView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.SysUserView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.SysUserView oldValue)
        {
            Model.TableModel.Sys_user model = View2Model(oldValue);
            List<Model.TableModel.Sys_user> modelList = new List<Model.TableModel.Sys_user>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Sys_user>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.SysUserView> oldValues)
        {
            List<Model.TableModel.Sys_user> modelList = new List<Model.TableModel.Sys_user>();
            foreach (ModelView.SysUserView item in oldValues)
            {
                Model.TableModel.Sys_user model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Sys_user>("Delete", modelList);
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
            List<Model.TableModel.Sys_user> list = DbEngine.QueryPage<Model.TableModel.Sys_user>("sys_user", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.SysUserView> res = new List<ModelView.SysUserView>();
            foreach (Model.TableModel.Sys_user item in list)
            {
                ModelView.SysUserView model = Model2View(item);
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
        public List<ModelView.SysUserView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Sys_user> list = DbEngine.QueryPage<Model.TableModel.Sys_user>("sys_user", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.SysUserView> res = new List<ModelView.SysUserView>();
            foreach (Model.TableModel.Sys_user item in list)
            {
                ModelView.SysUserView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Sys_user View2Model(ModelView.SysUserView view)
        {
            Model.TableModel.Sys_user model = new Model.TableModel.Sys_user();
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
            model.user_no = string.IsNullOrEmpty(view.user_no) ? globalDataCtrl.GetNextNoByTblName("sys_user") : view.user_no;
            model.user_name = view.user_name;
            model.user_card_id = view.user_card_id;
            model.user_card_no = view.user_card_no;
            model.user_pwd = string.IsNullOrEmpty(view.user_pwd) ? Common.Md5Operate.GetMD5String("123456") : Common.Md5Operate.GetMD5String(view.user_pwd);
            switch (view.user_gender)
            {
                case "男":
                    model.user_gender = "男";
                    break;
                case "女":
                    model.user_gender = "女";
                    break;
                default:
                    model.user_gender = "未知";
                    break;
            }
            if (view.loginable == "是")
            {
                model.loginable = true;
            }
            else
            {
                model.loginable = false;
            }
            if (view.pwd_changeable == "是")
            {
                model.pwd_changeable = true;
            }
            else
            {
                model.pwd_changeable = false;            
            }
            DateTime dt = DateTime.Now;
            if (string.IsNullOrEmpty(view.valid_start_time))
            {
                model.valid_start_time = null;   
            }
            else
            {
                model.valid_start_time = DateTime.TryParse(view.valid_start_time, out dt) ?  dt:(DateTime?)null ;
            }
            if (string.IsNullOrEmpty(view.valid_stop_time))
            {
                model.valid_stop_time = null;
            }
            else
            {
                model.valid_stop_time = DateTime.TryParse(view.valid_stop_time, out dt) ? dt : (DateTime?)null;
            }
            model.user_position = view.user_position;
            model.user_email = view.user_email;
            model.user_phone = view.user_phone;
            model.user_mobile = view.user_mobile;
            model.user_address = view.user_address;
            model.company_no = string.IsNullOrEmpty(view.company_no) ? "dfs_c" : view.company_no;
            model.dept_no = string.IsNullOrEmpty(view.dept_no) ? "01" : view.dept_no;
            model.factory_no = string.IsNullOrEmpty(view.factory_no) ? "dfs_f" : view.factory_no;
            model.workshop_no = string.IsNullOrEmpty(view.workshop_no) ? "ws01" : view.workshop_no;
            model.line_no = string.IsNullOrEmpty(view.line_no) ? "line01" : view.line_no;
            if (view.pwd_changeable == "是")
            {
                model.pwd_changeable = true;
            }
            else
            {
                model.pwd_changeable = false;
            }            
            return model;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="model">视图类</param>
        /// <returns>实体类</returns>
        private ModelView.SysUserView Model2View(Model.TableModel.Sys_user model)
        {
            ModelView.SysUserView view = new ModelView.SysUserView();
            view.id = model.id;
            view.company_no = model.company_no;
            view.dept_no = model.dept_no;
            view.factory_no = model.factory_no;
            view.is_worker = model.is_worker ? "是" : "否";
            view.line_no = model.line_no;
            view.loginable = model.loginable ? "是" : "否";
            view.pwd_changeable = model.pwd_changeable ? "是" : "否";
            view.status_name = model.status_name;
            view.status_no = model.status_no;
            view.user_address = model.user_address;
            view.user_card_id = model.user_card_id;
            view.user_card_no = model.user_card_no;
            view.user_email = model.user_email;
            view.user_gender = model.user_gender;
            view.user_mobile = model.user_mobile;
            view.user_name = model.user_name;
            view.user_no = model.user_no;
            view.user_phone = model.user_phone;
            view.user_position = model.user_position;
            view.user_pwd = "******";
            view.valid_start_time = model.valid_start_time.HasValue ? ((DateTime)model.valid_start_time).ToString("yyyy-MM-dd HH:mm:ss.fff") : string.Empty;
            view.valid_stop_time = model.valid_stop_time.HasValue ? ((DateTime)model.valid_stop_time).ToString("yyyy-MM-dd HH:mm:ss.fff") : string.Empty;
            view.workshop_no = model.workshop_no;
            return view;
        }

        /// <summary>
        /// 根据用户编号获取用户视图
        /// </summary>
        /// <param name="userNo">用户编号</param>
        /// <returns>用户视图</returns>
        public ModelView.SysUserView GetUserView(string userNo)
        {
            List<Model.TableModel.Sys_user> list=DbEngine.QueryList<Model.TableModel.Sys_user>(string.Format("user_no='{0}'",userNo));
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
        /// 根据用户编号获取用户实体
        /// </summary>
        /// <param name="userNo">用户编号</param>
        /// <returns>用户视图</returns>
        public Model.TableModel.Sys_user GetUserModel(string userNo)
        {
            List<Model.TableModel.Sys_user> list = DbEngine.QueryList<Model.TableModel.Sys_user>(string.Format("user_no='{0}'", userNo));
            if (list == null)
            {
                return null;
            }
            if (list.Count != 1)
            {
                return null;
            }
            return list[0];
        }

        
    }
}
