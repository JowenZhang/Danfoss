/**  版本信息模板在安装目录下，可自行修改。
* Pdm_pe.cs
*
* 功 能： N/A
* 类 名： Pdm_pe
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
	/// Pdm_pe:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Pdm_pe
	{
		public Pdm_pe()
		{}
		#region Model
		private string _id;
		private string _status_no;
		private string _status_name;
		private string _pe_no;
		private string _part_no;
		private int? _pe_main_version;
		private int _pe_sub_version=1;
		private string _part_name;
		private bool _is_default= false;
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
		public string pe_no
		{
			set{ _pe_no=value;}
			get{return _pe_no;}
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
		public int? pe_main_version
		{
			set{ _pe_main_version=value;}
			get{return _pe_main_version;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int pe_sub_version
		{
			set{ _pe_sub_version=value;}
			get{return _pe_sub_version;}
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
		public bool is_default
		{
			set{ _is_default=value;}
			get{return _is_default;}
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

