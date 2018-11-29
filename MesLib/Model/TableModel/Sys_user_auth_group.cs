using System;
namespace Model.TableModel
{
	/// <summary>
	/// Sys_user_auth_group:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sys_user_auth_group
	{
		public Sys_user_auth_group()
		{}
		#region Model
		private string _id;
		private string _status_no;
		private string _status_name;
		private string _user_no;
		private string _user_name;
		private string _auth_group_no;
		private string _auth_group_name;
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
		public string auth_group_no
		{
			set{ _auth_group_no=value;}
			get{return _auth_group_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string auth_group_name
		{
			set{ _auth_group_name=value;}
			get{return _auth_group_name;}
		}
		#endregion Model

	}
}

