/**  版本信息模板在安装目录下，可自行修改。
* Dms_file_type.cs
*
* 功 能： N/A
* 类 名： Dms_file_type
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/24 10:26:40   N/A    初版
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
	/// Dms_file_type:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Dms_file_type
	{
		public Dms_file_type()
		{}
		#region Model
		private string _id;
		private string _file_type_no;
		private string _file_type_name;
		private string _file_type_desc;
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
		public string file_type_no
		{
			set{ _file_type_no=value;}
			get{return _file_type_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string file_type_name
		{
			set{ _file_type_name=value;}
			get{return _file_type_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string file_type_desc
		{
			set{ _file_type_desc=value;}
			get{return _file_type_desc;}
		}
		#endregion Model

	}
}

