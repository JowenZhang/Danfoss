using System;
namespace Model.TableModel
{
	/// <summary>
    /// DStbl_Part:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DStbl_Part
	{
		public DStbl_Part()
		{}
		#region Model
		private string _danfossno;
		private string _partname;
		private string _description;
		private string _partsmanufacturer;
		private string _supplierref;
		private string _positions;
		private string _unitprice;
		private string _accountno;
		private int? _qty;
		private string _model;
		private string _sizes;
		private int? _maxstockpile;
		private int? _minstockpile;
		private string _remark;
		private string _makedate;
		private string _employee;
		private string _pictrue;
		private string _equipmentsupplier;
		private bool _disclaim;
		private string _sapno;
		private string _remark1;
		/// <summary>
		/// 
		/// </summary>
		public string DanfossNo
		{
			set{ _danfossno=value;}
			get{return _danfossno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PartName
		{
			set{ _partname=value;}
			get{return _partname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PartsManufacturer
		{
			set{ _partsmanufacturer=value;}
			get{return _partsmanufacturer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SupplierRef
		{
			set{ _supplierref=value;}
			get{return _supplierref;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Positions
		{
			set{ _positions=value;}
			get{return _positions;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UnitPrice
		{
			set{ _unitprice=value;}
			get{return _unitprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AccountNo
		{
			set{ _accountno=value;}
			get{return _accountno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Qty
		{
			set{ _qty=value;}
			get{return _qty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Model
		{
			set{ _model=value;}
			get{return _model;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Sizes
		{
			set{ _sizes=value;}
			get{return _sizes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MaxStockpile
		{
			set{ _maxstockpile=value;}
			get{return _maxstockpile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MinStockpile
		{
			set{ _minstockpile=value;}
			get{return _minstockpile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MakeDate
		{
			set{ _makedate=value;}
			get{return _makedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Employee
		{
			set{ _employee=value;}
			get{return _employee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pictrue
		{
			set{ _pictrue=value;}
			get{return _pictrue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EquipmentSupplier
		{
			set{ _equipmentsupplier=value;}
			get{return _equipmentsupplier;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Disclaim
		{
			set{ _disclaim=value;}
			get{return _disclaim;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SAPNO
		{
			set{ _sapno=value;}
			get{return _sapno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark1
		{
			set{ _remark1=value;}
			get{return _remark1;}
		}
		#endregion Model

	}
}

