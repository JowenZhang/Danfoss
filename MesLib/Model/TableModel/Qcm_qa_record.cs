/**  版本信息模板在安装目录下，可自行修改。
* Qcm_qa_record.cs
*
* 功 能： N/A
* 类 名： Qcm_qa_record
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/24 10:26:49   N/A    初版
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
	/// Qcm_qa_record:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Qcm_qa_record
	{
		public Qcm_qa_record()
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
		private string _qa_record_no;
		private string _qa_cause_no;
		private string _qa_cause_name;
		private string _part_no;
		private string _eqm_no;
		private string _mpo_no;
		private string _mpo_item_no;
		private string _serial_no;
		private string _factory_no;
		private string _submit_user_no;
		private string _submit_user_name;
		private DateTime _submit_time;
		private string _qa_result_no;
		private string _qa_result_name;
		private string _solve_user_no;
		private string _solve_user_name;
		private DateTime? _solve_time;
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
		public string qa_record_no
		{
			set{ _qa_record_no=value;}
			get{return _qa_record_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qa_cause_no
		{
			set{ _qa_cause_no=value;}
			get{return _qa_cause_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qa_cause_name
		{
			set{ _qa_cause_name=value;}
			get{return _qa_cause_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string part_no
		{
			set{ _part_no=value;}
			get{return _part_no;}
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
		public string mpo_no
		{
			set{ _mpo_no=value;}
			get{return _mpo_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mpo_item_no
		{
			set{ _mpo_item_no=value;}
			get{return _mpo_item_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string serial_no
		{
			set{ _serial_no=value;}
			get{return _serial_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string factory_no
		{
			set{ _factory_no=value;}
			get{return _factory_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string submit_user_no
		{
			set{ _submit_user_no=value;}
			get{return _submit_user_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string submit_user_name
		{
			set{ _submit_user_name=value;}
			get{return _submit_user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime submit_time
		{
			set{ _submit_time=value;}
			get{return _submit_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qa_result_no
		{
			set{ _qa_result_no=value;}
			get{return _qa_result_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qa_result_name
		{
			set{ _qa_result_name=value;}
			get{return _qa_result_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string solve_user_no
		{
			set{ _solve_user_no=value;}
			get{return _solve_user_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string solve_user_name
		{
			set{ _solve_user_name=value;}
			get{return _solve_user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? solve_time
		{
			set{ _solve_time=value;}
			get{return _solve_time;}
		}
		#endregion Model

	}
}

