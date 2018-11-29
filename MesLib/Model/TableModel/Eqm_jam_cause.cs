/**  版本信息模板在安装目录下，可自行修改。
* Eqm_jam_cause.cs
*
* 功 能： N/A
* 类 名： Eqm_jam_cause
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/24 10:26:41   N/A    初版
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
	/// Eqm_jam_cause:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Eqm_jam_cause
	{
		public Eqm_jam_cause()
		{}
		#region Model
		private string _id;
		private string _status_no;
		private string _status_name;
		private string _crt_user_no;
		private string _crt_user_name;
		private DateTime _crt_time;
		private string _upd_user_no;
		private string _upd_user_name;
		private DateTime _upd_time;
		private string _jam_cause_no;
		private string _jam_cause_name;
		private string _jam_cause_py;
		private string _jam_cause_type_no;
		private bool _jam_cause_is_default;
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
		public string crt_user_no
		{
			set{ _crt_user_no=value;}
			get{return _crt_user_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string crt_user_name
		{
			set{ _crt_user_name=value;}
			get{return _crt_user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime crt_time
		{
			set{ _crt_time=value;}
			get{return _crt_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string upd_user_no
		{
			set{ _upd_user_no=value;}
			get{return _upd_user_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string upd_user_name
		{
			set{ _upd_user_name=value;}
			get{return _upd_user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime upd_time
		{
			set{ _upd_time=value;}
			get{return _upd_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string jam_cause_no
		{
			set{ _jam_cause_no=value;}
			get{return _jam_cause_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string jam_cause_name
		{
			set{ _jam_cause_name=value;}
			get{return _jam_cause_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string jam_cause_py
		{
			set{ _jam_cause_py=value;}
			get{return _jam_cause_py;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string jam_cause_type_no
		{
			set{ _jam_cause_type_no=value;}
			get{return _jam_cause_type_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool jam_cause_is_default
		{
			set{ _jam_cause_is_default=value;}
			get{return _jam_cause_is_default;}
		}
		#endregion Model

	}
}

