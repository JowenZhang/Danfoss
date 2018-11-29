using System;
namespace Model.TableModel
{
	/// <summary>
	/// Mes_fb_item:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Mes_fb_item
	{
		public Mes_fb_item()
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
		private string _fb_item_no;
		private string _serial_no="";
		private string _fb_no;
		private string _mpo_no;
        private string _part_no;
		private DateTime? _fb_datetime;
		private string _quality_no;
		private string _worker_no;
		private string _worker_name;
		private string _eqm_no;
		private string _eqm_name;
		private string _wkc_no;
		private string _wkc_name;
		private string _shift_no;
		private string _shift_name;
		private string _cfm_user_no;
		private string _cfm_user_name;
		private DateTime? _cfm_time;
        private long? _in_id;
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
		public string fb_item_no
		{
			set{ _fb_item_no=value;}
			get{return _fb_item_no;}
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
		public string fb_no
		{
			set{ _fb_no=value;}
			get{return _fb_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mpo_no
		{
			set{ _mpo_no=value;}
			get{return _mpo_no;}
		}
        public string part_no
        {
            set { _part_no = value; }
            get { return _part_no; }
        }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? fb_datetime
		{
			set{ _fb_datetime=value;}
			get{return _fb_datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string quality_no
		{
			set{ _quality_no=value;}
			get{return _quality_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string worker_no
		{
			set{ _worker_no=value;}
			get{return _worker_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string worker_name
		{
			set{ _worker_name=value;}
			get{return _worker_name;}
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
		public string wkc_no
		{
			set{ _wkc_no=value;}
			get{return _wkc_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string wkc_name
		{
			set{ _wkc_name=value;}
			get{return _wkc_name;}
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
		public string shift_name
		{
			set{ _shift_name=value;}
			get{return _shift_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cfm_user_no
		{
			set{ _cfm_user_no=value;}
			get{return _cfm_user_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cfm_user_name
		{
			set{ _cfm_user_name=value;}
			get{return _cfm_user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? cfm_time
		{
			set{ _cfm_time=value;}
			get{return _cfm_time;}
		}

        /// <summary>
        /// 
        /// </summary>
        public long? in_id 
        {
            set { _in_id = value; }
            get { return _in_id; }
        }
		#endregion Model

	}
}

