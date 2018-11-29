/**  版本信息模板在安装目录下，可自行修改。
* Pdm_pe_item.cs
*
* 功 能： N/A
* 类 名： Pdm_pe_item
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/24 10:26:47   N/A    初版
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
	/// Pdm_pe_item:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Pdm_pe_item
	{
		public Pdm_pe_item()
		{}
		#region Model
		private string _id;
		private string _status_no;
		private string _status_name;
		private string _pe_no;
		private string _pe_item_no;
		private string _next_item_no;
		private string _eqm_no;
		private string _eqm_name;
		private string _wkc_no;
		private string _wkc_name;
		private int _pe_item_index=1;
		private int _pe_next_index=-1;
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
		public string pe_no
		{
			set{ _pe_no=value;}
			get{return _pe_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pe_item_no
		{
			set{ _pe_item_no=value;}
			get{return _pe_item_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string next_item_no
		{
			set{ _next_item_no=value;}
			get{return _next_item_no;}
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
		public string wkc_no
		{
			set{ _wkc_no=value;}
			get{return _wkc_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string wkc_name
		{
			set{ _wkc_name=value;}
			get{return _wkc_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int pe_item_index
		{
			set{ _pe_item_index=value;}
			get{return _pe_item_index;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int pe_next_index
		{
			set{ _pe_next_index=value;}
			get{return _pe_next_index;}
		}
		#endregion Model

	}
}

