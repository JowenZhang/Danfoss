/**  版本信息模板在安装目录下，可自行修改。
* Dms_file_act.cs
*
* 功 能： N/A
* 类 名： Dms_file_act
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/24 10:26:40   N/A    初版
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
	/// Dms_file_act:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Dms_file_act
	{
		public Dms_file_act()
		{}
		#region Model
		private string _id;
		private string _act_no;
		private string _act_name;
		private string _status_no;
		private string _status_name;
		private string _act_desc;
		private string _act_user_no;
		private string _act_user_name;
		private DateTime _act_time;
		private string _file_no;
		private int _act_index=1;
		private string _next_user_dept_no;
		private string _next_user_no;
		private string _next_user_name;
		private string _file_type_no;
		private bool _is_finished;
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
		public string act_no
		{
			set{ _act_no=value;}
			get{return _act_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string act_name
		{
			set{ _act_name=value;}
			get{return _act_name;}
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
		public string act_desc
		{
			set{ _act_desc=value;}
			get{return _act_desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string act_user_no
		{
			set{ _act_user_no=value;}
			get{return _act_user_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string act_user_name
		{
			set{ _act_user_name=value;}
			get{return _act_user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime act_time
		{
			set{ _act_time=value;}
			get{return _act_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string file_no
		{
			set{ _file_no=value;}
			get{return _file_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int act_index
		{
			set{ _act_index=value;}
			get{return _act_index;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string next_user_dept_no
		{
			set{ _next_user_dept_no=value;}
			get{return _next_user_dept_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string next_user_no
		{
			set{ _next_user_no=value;}
			get{return _next_user_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string next_user_name
		{
			set{ _next_user_name=value;}
			get{return _next_user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string file_type_no
		{
			set{ _file_type_no=value;}
			get{return _file_type_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool is_finished
		{
			set{ _is_finished=value;}
			get{return _is_finished;}
		}
		#endregion Model

	}
}

