/**  版本信息模板在安装目录下，可自行修改。
* Pdm_part.cs
*
* 功 能： N/A
* 类 名： Pdm_part
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/24 10:26:46   N/A    初版
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
	/// Pdm_part:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Pdm_part
	{
		public Pdm_part()
		{}
		#region Model
		private string _id;
		private string _status_no;
		private string _status_name;
		private string _part_no;
		private string _part_name;
		private string _part_spec;
		private string _part_unit;
		private string _part_type_no;
		private bool _is_speical;
		private int? _valid_day=0;
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
		public string part_spec
		{
			set{ _part_spec=value;}
			get{return _part_spec;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string part_unit
		{
			set{ _part_unit=value;}
			get{return _part_unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string part_type_no
		{
			set{ _part_type_no=value;}
			get{return _part_type_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool is_speical
		{
			set{ _is_speical=value;}
			get{return _is_speical;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? valid_day
		{
			set{ _valid_day=value;}
			get{return _valid_day;}
		}
		#endregion Model

	}
}

