/**  版本信息模板在安装目录下，可自行修改。
* Mpo_pe_item.cs
*
* 功 能： N/A
* 类 名： Mpo_pe_item
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/24 10:26:44   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Model.TableModel
{
	/// <summary>
	/// Mpo_pe_item:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Mpo_pe_item
	{
		public Mpo_pe_item()
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
		private string _item_no;
		private string _item_pe_no;
		private string _part_no;
		private string _part_name;
		private string _wkc_no;
		private string _next_wkc_no;
		private string _eqm_no;
		private string _next_eqm_no;
		private int _mpo_item_pe_index=0;
		private int _item_pe_next_index=-1;
		private int _mpo_pe_item_version=1;
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
		public string item_no
		{
			set{ _item_no=value;}
			get{return _item_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string item_pe_no
		{
			set{ _item_pe_no=value;}
			get{return _item_pe_no;}
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
		public string part_name
		{
			set{ _part_name=value;}
			get{return _part_name;}
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
		public string next_wkc_no
		{
			set{ _next_wkc_no=value;}
			get{return _next_wkc_no;}
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
		public string next_eqm_no
		{
			set{ _next_eqm_no=value;}
			get{return _next_eqm_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int mpo_item_pe_index
		{
			set{ _mpo_item_pe_index=value;}
			get{return _mpo_item_pe_index;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int item_pe_next_index
		{
			set{ _item_pe_next_index=value;}
			get{return _item_pe_next_index;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int mpo_pe_item_version
		{
			set{ _mpo_pe_item_version=value;}
			get{return _mpo_pe_item_version;}
		}
		#endregion Model

	}
}

