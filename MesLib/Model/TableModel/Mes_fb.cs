using System;
namespace Model.TableModel
{
	/// <summary>
	/// Mes_fb:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Mes_fb
	{
		public Mes_fb()
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
		private string _fb_no;
		private string _mpo_no;
        private string _part_no;
		private DateTime? _fb_start_datetime;
		private DateTime? _fb_end_datetime;
		private decimal? _fb_end_qty_ok=0M;
		private decimal? _fb_end_qty_ng=0M;
		private decimal? _fb_end_qty_scrap=0M;
		private decimal? _fb_end_qty_other=0M;
		private string _worker_no;
		private string _worker_name;
		private DateTime? _fb_time;
		private string _eqm_no;
		private string _eqm_name;
		private string _shift_no;
		private string _factory_no;
		private decimal? _fb_cfm_end_qty_ok=0M;
		private decimal? _fb_cfm_end_qty_ng=0M;
		private decimal? _fb_cfm_end_qty_scrap=0M;
		private decimal? _fb_cfm_end_qty_other=0M;
		private string _cfm_user_no;
		private string _cfm_user_name;
		private DateTime? _cfm_time;
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
        /// <summary>
        /// 
        /// </summary>
        public string part_no
        {
            set { _part_no = value; }
            get { return _part_no; }
        }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? fb_start_datetime
		{
			set{ _fb_start_datetime=value;}
			get{return _fb_start_datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? fb_end_datetime
		{
			set{ _fb_end_datetime=value;}
			get{return _fb_end_datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fb_end_qty_ok
		{
			set{ _fb_end_qty_ok=value;}
			get{return _fb_end_qty_ok;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fb_end_qty_ng
		{
			set{ _fb_end_qty_ng=value;}
			get{return _fb_end_qty_ng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fb_end_qty_scrap
		{
			set{ _fb_end_qty_scrap=value;}
			get{return _fb_end_qty_scrap;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fb_end_qty_other
		{
			set{ _fb_end_qty_other=value;}
			get{return _fb_end_qty_other;}
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
		public DateTime? fb_time
		{
			set{ _fb_time=value;}
			get{return _fb_time;}
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
		public string shift_no
		{
			set{ _shift_no=value;}
			get{return _shift_no;}
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
		public decimal? fb_cfm_end_qty_ok
		{
			set{ _fb_cfm_end_qty_ok=value;}
			get{return _fb_cfm_end_qty_ok;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fb_cfm_end_qty_ng
		{
			set{ _fb_cfm_end_qty_ng=value;}
			get{return _fb_cfm_end_qty_ng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fb_cfm_end_qty_scrap
		{
			set{ _fb_cfm_end_qty_scrap=value;}
			get{return _fb_cfm_end_qty_scrap;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fb_cfm_end_qty_other
		{
			set{ _fb_cfm_end_qty_other=value;}
			get{return _fb_cfm_end_qty_other;}
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
		#endregion Model

	}
}

