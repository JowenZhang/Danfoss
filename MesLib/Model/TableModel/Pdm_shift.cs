using System;
namespace Model.TableModel
{
	/// <summary>
	/// Pdm_shift:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Pdm_shift
	{
		public Pdm_shift()
		{}
		#region Model
		private string _id;
		private string _status_no;
		private string _status_name;
		private string _shift_no;
		private string _shift_name;
		private DateTime _shift_start_time;
		private DateTime _shift_stop_time;
		private int? _shift_length;
		private bool? _shift_1day_ahead;
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
		public DateTime shift_start_time
		{
			set{ _shift_start_time=value;}
			get{return _shift_start_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime shift_stop_time
		{
			set{ _shift_stop_time=value;}
			get{return _shift_stop_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? shift_length
		{
			set{ _shift_length=value;}
			get{return _shift_length;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? shift_1day_ahead
		{
			set{ _shift_1day_ahead=value;}
			get{return _shift_1day_ahead;}
		}
		#endregion Model

	}
}

