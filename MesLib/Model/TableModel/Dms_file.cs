/**  版本信息模板在安装目录下，可自行修改。
* Dms_file.cs
*
* 功 能： N/A
* 类 名： Dms_file
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
	/// Dms_file:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Dms_file
	{
		public Dms_file()
		{}
		#region Model
		private string _id;
		private string _file_no;
		private string _file_name;
		private string _file_extension;
		private string _file_type_no;
        private string _file_type_name;
		private string _file_version;
		private string _file_desc;
		private string _eqm_no;
		private string _file_md5;
		private bool _is_passed;
        private string _file_status;
        private string _ralate_file_name;
        private DateTime? _valid_date_start;        
        private DateTime? _valid_date_end;

        

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
		public string file_no
		{
			set{ _file_no=value;}
			get{return _file_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string file_name
		{
			set{ _file_name=value;}
			get{return _file_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string file_extension
		{
			set{ _file_extension=value;}
			get{return _file_extension;}
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
            set { _file_type_name = value; }
            get { return _file_type_name; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string file_version
		{
			set{ _file_version=value;}
			get{return _file_version;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string file_desc
		{
			set{ _file_desc=value;}
			get{return _file_desc;}
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
		public string file_md5
		{
			set{ _file_md5=value;}
			get{return _file_md5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool is_passed
		{
			set{ _is_passed=value;}
			get{return _is_passed;}
		}
        
        /// <summary>
        /// 
        /// </summary>
        public string ralate_file_name
        {
            set { _ralate_file_name = value; }
            get { return _ralate_file_name; }
        
        }

        /// <summary>
        /// 
        /// </summary>
        public string file_status
        {
            set { _file_status = value; }
            get { return _file_status; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? valid_date_end
        {
            get { return _valid_date_end; }
            set { _valid_date_end = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? valid_date_start
        {
            get { return _valid_date_start; }
            set { _valid_date_start = value; }
        }
		#endregion Model

	}
}

