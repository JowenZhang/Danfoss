using System;
namespace Model.TableModel
{
	/// <summary>
	/// Mpo_item:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Mpo_item
	{
		public Mpo_item()
		{}
		#region Model
		private string _id;
		private string _status_no;
		private string _status_name;
		private string _mpo_no;
		private string _item_no;
		private string _serial_no;
		private decimal _item_qty=1M;
		private string _part_no;
		private DateTime? _hope_product_time;
        private DateTime? _print_time;

        
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
		public string mpo_no
		{
			set{ _mpo_no=value;}
			get{return _mpo_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string item_no
		{
			set{ _item_no=value;}
			get{return _item_no;}
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
		public decimal item_qty
		{
			set{ _item_qty=value;}
			get{return _item_qty;}
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
		public DateTime? hope_product_time
		{
			set{ _hope_product_time=value;}
			get{return _hope_product_time;}
		}

        /// <summary>
        /// 
        /// </summary>


        public DateTime? print_time
        {

            get { return _print_time; }
            set { _print_time = value; }
        }
		#endregion Model

	}
}

