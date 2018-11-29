/**  版本信息模板在安装目录下，可自行修改。
* Mpo.cs
*
* 功 能： N/A
* 类 名： Mpo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/24 10:26:43   N/A    初版
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
	/// Mpo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Mpo
	{
		public Mpo()
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
		private string _mpo_no;
		private string _mpo_type_no;
		private string _mpo_type_name;
		private string _part_no;
		private string _part_name;
		private string _part_spec;
		private string _part_unit;
		private decimal _mpo_qty=0M;
		private DateTime? _mpo_hope_start_datetime;
		private DateTime? _mpo_hope_end_datetime;
		private string _workshop_no;
		private string _factory_no;
		private string _line_no;
		private string _job_no;
		private string _shift_no;
		private string _client_no;
		private string _client_name;
		private string _commit_status_no;
		private string _commit_status_name;
        private decimal _procedure_finished_qty;
        private string _procedure_status_name;

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
		public string mpo_no
		{
			set{ _mpo_no=value;}
			get{return _mpo_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mpo_type_no
		{
			set{ _mpo_type_no=value;}
			get{return _mpo_type_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mpo_type_name
		{
			set{ _mpo_type_name=value;}
			get{return _mpo_type_name;}
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
		public string part_name
		{
			set{ _part_name=value;}
			get{return _part_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string part_spec
		{
			set{ _part_spec=value;}
			get{return _part_spec;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string part_unit
		{
			set{ _part_unit=value;}
			get{return _part_unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal mpo_qty
		{
			set{ _mpo_qty=value;}
			get{return _mpo_qty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? mpo_hope_start_datetime
		{
			set{ _mpo_hope_start_datetime=value;}
			get{return _mpo_hope_start_datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? mpo_hope_end_datetime
		{
			set{ _mpo_hope_end_datetime=value;}
			get{return _mpo_hope_end_datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string workshop_no
		{
			set{ _workshop_no=value;}
			get{return _workshop_no;}
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
		public string line_no
		{
			set{ _line_no=value;}
			get{return _line_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string job_no
		{
			set{ _job_no=value;}
			get{return _job_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string shift_no
		{
			set{ _shift_no=value;}
			get{return _shift_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string client_no
		{
			set{ _client_no=value;}
			get{return _client_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string client_name
		{
			set{ _client_name=value;}
			get{return _client_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string commit_status_no
		{
			set{ _commit_status_no=value;}
			get{return _commit_status_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string commit_status_name
		{
			set{ _commit_status_name=value;}
			get{return _commit_status_name;}
		}

        /// <summary>
        /// 
        /// </summary>
        public decimal procedure_finished_qty
        {
            set { _procedure_finished_qty = value; }
            get { return _procedure_finished_qty; }
        }

        public string procedure_status_name
        {
            set { _procedure_status_name=value; }
            get { return _procedure_status_name; }
        }
		#endregion Model

	}
}

