using System;
namespace Model.TableModel
{
	/// <summary>
	/// Qcm_qa_cause:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Qcm_qa_cause
	{
		public Qcm_qa_cause()
		{}
		#region Model
		private string _id;
		private string _status_no;
		private string _status_name;
		private string _qa_cause_no;
		private string _qa_cause_name;
		private string _qa_cause_py;
		private bool _qa_cause_is_default= false;
		private string _factory_no;
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
		public string qa_cause_py
		{
			set{ _qa_cause_py=value;}
			get{return _qa_cause_py;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool qa_cause_is_default
		{
            set { _qa_cause_is_default = value; }
            get { return _qa_cause_is_default; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string factory_no
		{
			set{ _factory_no=value;}
			get{return _factory_no;}
		}
		#endregion Model

	}
}

