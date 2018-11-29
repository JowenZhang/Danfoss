using System;
namespace Model.TableModel
{
	/// <summary>
	/// Pdm_eqm:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Pdm_eqm
	{
		public Pdm_eqm()
		{}
		#region Model
		private string _id;
		private string _status_no;
		private string _status_name;
		private string _eqm_no;
		private string _eqm_name;
		private string _eqm_desc;
		private int _eqm_index;
		private string _wkc_no;
		private string _eqm_status="正常";
        private string _eqm_lock;

        
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
		public string eqm_desc
		{
			set{ _eqm_desc=value;}
			get{return _eqm_desc;}
		}
		/// <summary>
		/// 
		/// </summary>
        public int eqm_index
		{
			set{ _eqm_index=value;}
			get{return _eqm_index;}
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
		public string eqm_status
		{
			set{ _eqm_status=value;}
			get{return _eqm_status;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string eqm_lock
        {
            get { return _eqm_lock; }
            set { _eqm_lock = value; }
        }
		#endregion Model

	}
}

