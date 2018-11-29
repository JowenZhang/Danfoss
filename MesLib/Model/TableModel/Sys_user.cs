using System;
namespace Model.TableModel
{
	/// <summary>
	/// Sys_user:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sys_user
	{
		public Sys_user()
		{}
		#region Model
		private string _id;
		private string _status_no;
		private string _status_name;
		private string _user_no;
		private string _user_name;
		private string _user_card_id;
		private string _user_card_no;
		private string _user_pwd;
		private string _user_gender="未知";
		private bool _loginable= false;
		private bool _pwd_changeable= false;
		private DateTime? _valid_start_time;
		private DateTime? _valid_stop_time;
		private string _user_position;
		private string _user_email;
		private string _user_phone;
		private string _user_mobile;
		private string _user_address;
		private string _company_no;
		private string _dept_no;
		private string _factory_no;
		private string _workshop_no;
		private string _line_no;
		private bool _is_worker= false;
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
		public string user_no
		{
			set{ _user_no=value;}
			get{return _user_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_name
		{
			set{ _user_name=value;}
			get{return _user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_card_id
		{
			set{ _user_card_id=value;}
			get{return _user_card_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_card_no
		{
			set{ _user_card_no=value;}
			get{return _user_card_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_pwd
		{
			set{ _user_pwd=value;}
			get{return _user_pwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_gender
		{
			set{ _user_gender=value;}
			get{return _user_gender;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool loginable
		{
			set{ _loginable=value;}
			get{return _loginable;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool pwd_changeable
		{
			set{ _pwd_changeable=value;}
			get{return _pwd_changeable;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? valid_start_time
		{
			set{ _valid_start_time=value;}
			get{return _valid_start_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? valid_stop_time
		{
			set{ _valid_stop_time=value;}
			get{return _valid_stop_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_position
		{
			set{ _user_position=value;}
			get{return _user_position;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_email
		{
			set{ _user_email=value;}
			get{return _user_email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_phone
		{
			set{ _user_phone=value;}
			get{return _user_phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_mobile
		{
			set{ _user_mobile=value;}
			get{return _user_mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_address
		{
			set{ _user_address=value;}
			get{return _user_address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string company_no
		{
			set{ _company_no=value;}
			get{return _company_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dept_no
		{
			set{ _dept_no=value;}
			get{return _dept_no;}
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
		public string workshop_no
		{
			set{ _workshop_no=value;}
			get{return _workshop_no;}
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
		public bool is_worker
		{
			set{ _is_worker=value;}
			get{return _is_worker;}
		}
		#endregion Model

	}
}

