using System;
namespace Model.TableModel
{
	/// <summary>
	/// Adn:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Adn
	{
		public Adn()
		{}
		#region Model
		private string _id;
		private string _status_no;
		private string _status_name;
		private string _andon_no;
		private string _andon_type_no;
		private string _andon_type_name;
		private string _andon_desc;
		private string _dept_no;
		private string _andon_music_no;
		private string _eqm_no;
		private string _call_user_no;
		private string _call_user_name;
		private DateTime _call_time;
		private string _reply_user_no;
		private string _reply_user_name;
		private DateTime? _reply_time;
		private string _ralate_no;
        private string _play_record;
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
		public string andon_no
		{
			set{ _andon_no=value;}
			get{return _andon_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string andon_type_no
		{
			set{ _andon_type_no=value;}
			get{return _andon_type_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string andon_type_name
		{
			set{ _andon_type_name=value;}
			get{return _andon_type_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string andon_desc
		{
			set{ _andon_desc=value;}
			get{return _andon_desc;}
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
		public string andon_music_no
		{
			set{ _andon_music_no=value;}
			get{return _andon_music_no;}
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
		public string call_user_no
		{
			set{ _call_user_no=value;}
			get{return _call_user_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string call_user_name
		{
			set{ _call_user_name=value;}
			get{return _call_user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime call_time
		{
			set{ _call_time=value;}
			get{return _call_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string reply_user_no
		{
			set{ _reply_user_no=value;}
			get{return _reply_user_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string reply_user_name
		{
			set{ _reply_user_name=value;}
			get{return _reply_user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? reply_time
		{
			set{ _reply_time=value;}
			get{return _reply_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ralate_no
		{
			set{ _ralate_no=value;}
			get{return _ralate_no;}
		}

        /// <summary>
        /// 
        /// </summary>
        public string play_record
        {
            get { return _play_record; }
            set { _play_record = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool is_finished
        {
            get { return _is_finished; }
            set { _is_finished = value; }
        }
		#endregion Model

	}
}

