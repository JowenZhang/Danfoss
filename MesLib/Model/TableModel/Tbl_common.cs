/**  版本信息模板在安装目录下，可自行修改。
* Tbl_common.cs
*
* 功 能： N/A
* 类 名： Tbl_common
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/24 10:26:55   N/A    初版
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
	/// Tbl_common:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Tbl_common
	{
		public Tbl_common()
		{}
		#region Model
		private string _id;
		private string _status_no;
		private string _status_name;
		private string _remark01;
		private string _remark02;
		private string _remark03;
		private string _remark04;
		private string _remark05;
		private string _remark06;
		private string _crt_user_id;
		private string _crt_user_no;
		private string _crt_user_name;
		private string _crt_host;
		private DateTime _crt_time;
		private string _upd_user_id;
		private string _upd_user_no;
		private string _upd_user_name;
		private string _upd_host;
		private DateTime _upd_time;
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
		public string remark01
		{
			set{ _remark01=value;}
			get{return _remark01;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark02
		{
			set{ _remark02=value;}
			get{return _remark02;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark03
		{
			set{ _remark03=value;}
			get{return _remark03;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark04
		{
			set{ _remark04=value;}
			get{return _remark04;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark05
		{
			set{ _remark05=value;}
			get{return _remark05;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark06
		{
			set{ _remark06=value;}
			get{return _remark06;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string crt_user_id
		{
			set{ _crt_user_id=value;}
			get{return _crt_user_id;}
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
		public string crt_host
		{
			set{ _crt_host=value;}
			get{return _crt_host;}
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
		public string upd_user_id
		{
			set{ _upd_user_id=value;}
			get{return _upd_user_id;}
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
		public string upd_host
		{
			set{ _upd_host=value;}
			get{return _upd_host;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime upd_time
		{
			set{ _upd_time=value;}
			get{return _upd_time;}
		}
		#endregion Model

	}
}

