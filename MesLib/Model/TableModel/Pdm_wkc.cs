/**  版本信息模板在安装目录下，可自行修改。
* Pdm_wkc.cs
*
* 功 能： N/A
* 类 名： Pdm_wkc
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/24 10:26:48   N/A    初版
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
	/// Pdm_wkc:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Pdm_wkc
	{
		public Pdm_wkc()
		{}
		#region Model
		private string _id;
		private string _status_no;
		private string _status_name;
		private string _wkc_no;
		private string _wkc_name;
		private string _wkc_card_no;
		private string _wkc_type;
		private string _factory_no;
		private string _workshop_no;
		private string _line_no;
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
		public string wkc_card_no
		{
			set{ _wkc_card_no=value;}
			get{return _wkc_card_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string wkc_type
		{
			set{ _wkc_type=value;}
			get{return _wkc_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string factory_no
		{
			set{ _factory_no=value;}
			get{return _factory_no;}
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
		public string line_no
		{
			set{ _line_no=value;}
			get{return _line_no;}
		}
		#endregion Model

	}
}

