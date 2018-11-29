using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 顶级菜单操作类
    /// </summary>
    public class TopMenuCtrl
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
        /// 获取所有菜单列表
        /// </summary>
        /// <param name="currentUserNo">当前登陆的用户</param>
        public List<ModelView.TopMenuView> GetList(string currentUserNo= null)
        {
            List<ModelView.TopMenuView> res = new List<ModelView.TopMenuView>();
            try
            {
                string where = string.Empty;
                if (string.IsNullOrEmpty(currentUserNo))
                {
                    where = @"menu_parent_no='0' order by menu_parent_no,menu_level_index";
                }
                else
                {
                    where = string.Format("menu_parent_no='0' and  menu_no in (select distinct menu_no from sys_auth where auth_group_no in (select distinct auth_group_no from sys_user_auth_group where user_no='{0}')) order by menu_parent_no,menu_level_index", currentUserNo);
                }
                List<Model.TableModel.Sys_menu> listMenu = DbEngine.QueryList<Model.TableModel.Sys_menu>(where);
                foreach (Model.TableModel.Sys_menu item in listMenu)
                {
                    ModelView.TopMenuView model = new ModelView.TopMenuView();
                    model.id = item.menu_no;
                    model.title = item.menu_name;
                    model.selected = false;
                    model.content = GetContent(item.menu_no, currentUserNo);
                    res.Add(model);
                }
                if (res.Count > 0)
                {
                    res[0].selected = true;
                }
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 私有方法，构建子级菜单内容
        /// </summary>
        /// <param name="menuNo">主菜单编号</param>
        /// <param name="currentUserNo">当前登陆者</param>
        /// <returns>子级菜单字符串</returns>
        private string GetContent(string menuNo, string currentUserNo)
        {
            SubMenuCtrl smc = new SubMenuCtrl();
            List<ModelView.SubMenuView> listModels = new List<ModelView.SubMenuView>();
            if (string.IsNullOrEmpty(currentUserNo))
            {
                listModels = smc.GetList(menuNo);
            }
            else
            {
                listModels=smc.GetList(menuNo, currentUserNo);
            }
            StringBuilder res = new StringBuilder();
            bool flag = false;
            res.Append("<div style=\"padding:0;margin:0;\">");
            foreach (ModelView.SubMenuView item in listModels)
            {
                flag = true;
                res.Append("<a id=\"btn_");
                res.Append(item.id);
                res.Append("\" href=\"");
                res.Append(item.href);
                res.Append("\" class=\"easyui-linkbutton\" style=\"margin:0;padding:0;width:100%;background-color:");
                res.Append(item.backgroundColor);
                res.Append(";\" onclick=\"return sendClick(this);\">");
                res.Append(item.htmlText);
                res.Append("</a>");
            }
            if (flag)
            {
                res.Append("</div>");
                return res.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
