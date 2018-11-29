/**  版本信息模板在安装目录下，可自行修改。
* Sys_factory.cs
*
* 功 能： N/A
* 类 名： Sys_factory
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/24 10:26:53   N/A    初版
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
	/// Sys_factory:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sys_factory
	{
		public Sys_factory()
		{}
		#region Model
		private string _id;
		private string _status_no;
		private string _status_name;
		private string _factory_no;
		private string _factory_name;
		private string _factory_name_py;
		private string _factory_type;
		private string _company_no;
		private string _company_name;
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
		public string factory_no
		{
			set{ _factory_no=value;}
			get{return _factory_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string factory_name
		{
			set{ _factory_name=value;}
			get{return _factory_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string factory_name_py
		{
			set{ _factory_name_py=value;}
			get{return _factory_name_py;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string factory_type
		{
			set{ _factory_type=value;}
			get{return _factory_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string company_no
		{
			set{ _company_no=value;}
			get{return _company_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string company_name
		{
			set{ _company_name=value;}
			get{return _company_name;}
		}
		#endregion Model

	}
}

