/**  版本信息模板在安装目录下，可自行修改。
* Pdm_eqm_maintain.cs
*
* 功 能： N/A
* 类 名： Pdm_eqm_maintain
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/24 10:26:45   N/A    初版
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
	/// Pdm_eqm_maintain:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Pdm_eqm_maintain
	{
		public Pdm_eqm_maintain()
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
		private string _eqm_no;
		private string _eqm_name;
		private string _maintain_no;
		private string _maintain_content;
		private string _maintain_standard;
		private string _maintain_exam_info;
		private bool _maintain_isolation= false;
		private DateTime? _maintain_deadline;
		private string _maintain_user_no;
		private string _maintain_user_name;
		private DateTime? _maintain_datetime;
		private string _exam_user_no;
		private string _exam_user_name;
		private DateTime? _exam_time;
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
		public string eqm_no
		{
			set{ _eqm_no=value;}
			get{return _eqm_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string eqm_name
		{
			set{ _eqm_name=value;}
			get{return _eqm_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string maintain_no
		{
			set{ _maintain_no=value;}
			get{return _maintain_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string maintain_content
		{
			set{ _maintain_content=value;}
			get{return _maintain_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string maintain_standard
		{
			set{ _maintain_standard=value;}
			get{return _maintain_standard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string maintain_exam_info
		{
			set{ _maintain_exam_info=value;}
			get{return _maintain_exam_info;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool maintain_isolation
		{
			set{ _maintain_isolation=value;}
			get{return _maintain_isolation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? maintain_deadline
		{
			set{ _maintain_deadline=value;}
			get{return _maintain_deadline;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string maintain_user_no
		{
			set{ _maintain_user_no=value;}
			get{return _maintain_user_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string maintain_user_name
		{
			set{ _maintain_user_name=value;}
			get{return _maintain_user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? maintain_datetime
		{
			set{ _maintain_datetime=value;}
			get{return _maintain_datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string exam_user_no
		{
			set{ _exam_user_no=value;}
			get{return _exam_user_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string exam_user_name
		{
			set{ _exam_user_name=value;}
			get{return _exam_user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? exam_time
		{
			set{ _exam_time=value;}
			get{return _exam_time;}
		}
		#endregion Model

	}
}

