using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 子级菜单操作类
    /// </summary>
    public class SubMenuCtrl
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
        /// 获取子菜单列表
        /// </summary>
        /// <param name="id">子菜单对应的父级菜单编号</param>
        /// <param name="currentUser">当前登陆的人员</param>
        /// <returns>父级菜单下的子级菜单</returns>
        public List<ModelView.SubMenuView> GetList(string id, string currentUserNo = null)
        {
            List<ModelView.SubMenuView> res = new List<ModelView.SubMenuView>();
            try
            {
                //检测当前用户是否有需要检验的文件
                bool hasAction = HasAction2User(currentUserNo);
                string where = string.Empty;
                if (string.IsNullOrEmpty(currentUserNo))
                {
                    where = string.Format("menu_parent_no='{0}' order by menu_parent_no,menu_level_index asc", id);
                }
                else
                {
                    where = string.Format("menu_parent_no='{0}' and  menu_no in (select distinct menu_no from sys_auth where auth_group_no in (select distinct auth_group_no from sys_user_auth_group where user_no='{1}'))  order by menu_parent_no,menu_level_index asc", id,currentUserNo);
                }
                List<Model.TableModel.Sys_menu> listMenu = DbEngine.QueryList<Model.TableModel.Sys_menu>(where);
                foreach (Model.TableModel.Sys_menu item in listMenu)
                {
                    ModelView.SubMenuView model = new ModelView.SubMenuView();
                    if (hasAction && item.menu_no == "24010")
                    {

                        model.backgroundColor = "lightblue";
                    }
                    else
                    {
                        model.backgroundColor = "none";
                    }
                    model.id = item.menu_no;
                    model.htmlText = item.menu_name;
                    model.href = string.IsNullOrEmpty(item.menu_link) ? "#" : item.menu_link;
                    res.Add(model);
                }
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据当前登陆人员的编号，获取是否存在需要当前用户处理的动作
        /// </summary>
        /// <param name="currentUserNo">当前用户编号</param>
        /// <returns>是否存在需要处理的动作</returns>
        private bool HasAction2User(string currentUserNo)
        {
            if (string.IsNullOrEmpty(currentUserNo))
            {
                return false;
            }
            GlobalDataCtrl globalDataCtrl = new GlobalDataCtrl();
            string userName=globalDataCtrl.GetStrByField("user_name", "sys_user", "user_no", currentUserNo);
            List<Model.TableModel.Apo_act> list = DbEngine.QueryList<Model.TableModel.Apo_act>(string.Format("next_user_name='{0}' and step_finished='0' and apo_finished='0'", userName));
            if (list==null)
            {
                return false;
            }
            return list.Count>0;
        }
    }
}
