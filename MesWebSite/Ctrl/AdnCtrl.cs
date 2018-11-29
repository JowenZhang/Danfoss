using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 安灯呼叫视图控制类
    /// </summary>
    public class AdnCtrl:ICtrlOperate
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
            ModelView.AdnView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.AdnView>(jsonStr);
            return Insert(model);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="newValue">新插入的值</param>
        /// <returns>影响记录条数</returns>
        public int Insert(ModelView.AdnView newValue)
        {
            Model.TableModel.Adn model = View2Model(newValue);
            List<Model.TableModel.Adn> modelList = new List<Model.TableModel.Adn>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Adn>("Insert", modelList);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">更新后对象的json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Update(string jsonStr)
        {
            ModelView.AdnView model = Common.JsonHelper.DeserializeJsonToObject<ModelView.AdnView>(jsonStr);
            return Update(model);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="newValue">更新后对象</param>
        /// <returns>影响记录条数</returns>
        public int Update(ModelView.AdnView newValue)
        {
            Model.TableModel.Adn model = View2Model(newValue);
            List<Model.TableModel.Adn> modelList = new List<Model.TableModel.Adn>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Adn>("update", modelList);
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">要删除的对象json序列化字符串</param>
        /// <returns>影响记录条数</returns>
        public int Delete(string jsonStr)
        {
            List<ModelView.AdnView> list = Common.JsonHelper.DeserializeJsonToList<ModelView.AdnView>(jsonStr);
            return Delete(list);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValue">要删除的值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(ModelView.AdnView oldValue)
        {
            Model.TableModel.Adn model = View2Model(oldValue);
            List<Model.TableModel.Adn> modelList = new List<Model.TableModel.Adn>();
            modelList.Add(model);
            return DbEngine.QueryInt<Model.TableModel.Adn>("Delete", modelList);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="oldValues">要删除的多个值</param>
        /// <returns>影响记录条数</returns>
        public int Delete(List<ModelView.AdnView> oldValues)
        {
            List<Model.TableModel.Adn> modelList = new List<Model.TableModel.Adn>();
            foreach (ModelView.AdnView item in oldValues)
            {
                Model.TableModel.Adn model = View2Model(item);
                modelList.Add(model);
            }
            return DbEngine.QueryInt<Model.TableModel.Adn>("Delete", modelList);
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
            List<Model.TableModel.Adn> list = DbEngine.QueryPage<Model.TableModel.Adn>("adn", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.AdnView> res = new List<ModelView.AdnView>();
            foreach (Model.TableModel.Adn item in list)
            {
                ModelView.AdnView model = Model2View(item);
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
        public List<ModelView.AdnView> GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex, out int total)
        {
            List<Model.TableModel.Adn> list = DbEngine.QueryPage<Model.TableModel.Adn>("adn", pageIndex, pageSize, where, orderBy, out total);
            List<ModelView.AdnView> res = new List<ModelView.AdnView>();
            foreach (Model.TableModel.Adn item in list)
            {
                ModelView.AdnView model = Model2View(item);
                res.Add(model);
            }
            return res;
        }

        /// <summary>
        /// 视图类转实体类
        /// </summary>
        /// <param name="view">视图类</param>
        /// <returns>实体类</returns>
        private Model.TableModel.Adn View2Model(ModelView.AdnView view)
        {
            Model.TableModel.Adn model = new Model.TableModel.Adn();
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
            model.andon_no = string.IsNullOrEmpty(view.andon_no) ? globalDataCtrl.GetNextNoByTblName("adn") : view.andon_no;
            model.andon_type_no = string.IsNullOrEmpty(view.andon_type_no) ? "01" : view.andon_type_no;
            model.andon_type_name = view.andon_type_name;
            model.andon_desc = view.andon_desc;
            model.dept_no = view.dept_no;
            model.eqm_no = string.IsNullOrEmpty(view.eqm_no)?"Default":view.eqm_no;
            model.andon_music_no = (model.dept_no + "_" + model.eqm_no + ".mp3").Replace("?", "").Replace("*", "").Replace(":", "\"").Replace("<", "").Replace(">", "").Replace("\\", "").Replace("/", "").Replace("|", "");

            model.call_user_no = string.IsNullOrEmpty(view.call_user_no) ? "Server" : view.call_user_no;
            model.call_user_name = string.IsNullOrEmpty(view.call_user_name) ? "Server" : view.call_user_name;
            DateTime dt = DateTime.Now;
            model.call_time = DateTime.TryParse(view.call_time, out dt) ? dt : DateTime.Now;

            model.reply_user_no = string.IsNullOrEmpty(view.call_user_no) ? "Server" : view.call_user_no;
            model.reply_user_name = string.IsNullOrEmpty(view.call_user_name) ? "Server" : view.call_user_name;
            dt = DateTime.Now;
            model.reply_time = string.IsNullOrEmpty(view.reply_time) ? (DateTime?)null : (DateTime.TryParse(view.reply_time, out dt) ? dt : DateTime.Now);
            model.ralate_no = view.ralate_no;
            model.is_finished = string.IsNullOrEmpty(view.is_finished)?false:(view.is_finished == "是" ? true : false);
            GlobalDataCtrl gdc=new GlobalDataCtrl();
            string tmp = gdc.GetStrByField("andon_play_eqm", "adn_type", "andon_type_no", model.andon_type_no);
            model.play_record = string.IsNullOrEmpty(tmp)?"0":tmp;
            return model;
        }

        /// <summary>
        /// 实体类转视图类
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>视图类</returns>
        private ModelView.AdnView Model2View(Model.TableModel.Adn model)
        {
            ModelView.AdnView view = new ModelView.AdnView();
            view.id = model.id;
            view.status_name = model.status_name;
            view.status_no = model.status_no;

            view.andon_no = model.andon_no;
            view.andon_type_no = model.andon_type_no;
            view.andon_type_name = model.andon_type_name;
            view.andon_desc = model.andon_desc;
            view.dept_no = model.dept_no;
            view.andon_music_no = model.andon_music_no;
            view.eqm_no = model.eqm_no;

            view.call_user_no = model.call_user_no;
            view.call_user_name = model.call_user_name;
            view.call_time = model.call_time.ToString("yyyy-MM-dd HH:mm:ss.fff");
            view.reply_user_no = model.reply_user_no;
            view.reply_user_name = model.reply_user_name;
            view.reply_time = model.reply_time.HasValue?((DateTime)model.reply_time).ToString("yyyy-MM-dd HH:mm:ss.fff"):string.Empty;
            view.ralate_no = model.ralate_no;
            view.is_finished = model.is_finished?"是":"否";
            view.play_record = model.play_record;
            return view;
        }
    }
}
