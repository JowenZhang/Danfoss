using System;
namespace Model.TableModel
{
	/// <summary>
	/// Pdm_line:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Pdm_line
	{
		public Pdm_line()
		{}
		#region Model
		private string _id;
		private string _status_no;
		private string _status_name;
		private string _line_no;
		private string _line_name;
		private string _line_desc;
		private string _workshop_no;
		private string _workshop_name;
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
		public string line_no
		{
			set{ _line_no=value;}
			get{return _line_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string line_name
		{
			set{ _line_name=value;}
			get{return _line_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string line_desc
		{
			set{ _line_desc=value;}
			get{return _line_desc;}
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
		public string workshop_name
		{
			set{ _workshop_name=value;}
			get{return _workshop_name;}
		}
		#endregion Model

	}
}

