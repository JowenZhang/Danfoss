﻿/**  版本信息模板在安装目录下，可自行修改。
* Sys_auth.cs
*
* 功 能： N/A
* 类 名： Sys_auth
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/24 10:26:50   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Model.TableModel
{
	/// <summary>
	/// Sys_auth:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sys_auth
	{
		public Sys_auth()
		{}
		#region Model
		private string _id;
		private string _status_no;
		private string _status_name;
		private string _auth_no;
		private string _auth_name;
		private string _auth_group_no;
		private string _auth_group_name;
        private string _menu_no;
		/// <summary>
		/// 
		/// </summary>
		public string id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string status_no
		{
			set{ _status_no=value;}
			get{return _status_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string status_name
		{
			set{ _status_name=value;}
			get{return _status_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string auth_no
		{
			set{ _auth_no=value;}
			get{return _auth_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string auth_name
		{
			set{ _auth_name=value;}
			get{return _auth_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string auth_group_no
		{
			set{ _auth_group_no=value;}
			get{return _auth_group_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string auth_group_name
		{
			set{ _auth_group_name=value;}
			get{return _auth_group_name;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string menu_no
        {
            get { return _menu_no; }
            set { _menu_no = value; }
        }
		#endregion Model

	}
}

