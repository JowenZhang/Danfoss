/**  版本信息模板在安装目录下，可自行修改。
* Mes_worker.cs
*
* 功 能： N/A
* 类 名： Mes_worker
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/24 10:26:42   N/A    初版
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
	/// Mes_worker:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Mes_worker
	{
		public Mes_worker()
		{}
		#region Model.TableModel
		private string _id;
		private string _status_no;
		private string _status_name;
		private string _worker_no;
		private string _worker_name;
		private string _worker_card_no;
		private string _worker_card_id;
		private string _factory_no;
		private string _workshop_no;
		private string _line_no;
		private string _job_no;
		private string _shift_no;
		private string _worker_mobile;
		private string _worker_email;
		private decimal? _worker_rate;
		private string _worker_group_no;
		private DateTime? _in_date;
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
		public string worker_no
		{
			set{ _worker_no=value;}
			get{return _worker_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string worker_name
		{
			set{ _worker_name=value;}
			get{return _worker_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string worker_card_no
		{
			set{ _worker_card_no=value;}
			get{return _worker_card_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string worker_card_id
		{
			set{ _worker_card_id=value;}
			get{return _worker_card_id;}
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
		/// <summary>
		/// 
		/// </summary>
		public string job_no
		{
			set{ _job_no=value;}
			get{return _job_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string shift_no
		{
			set{ _shift_no=value;}
			get{return _shift_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string worker_mobile
		{
			set{ _worker_mobile=value;}
			get{return _worker_mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string worker_email
		{
			set{ _worker_email=value;}
			get{return _worker_email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? worker_rate
		{
			set{ _worker_rate=value;}
			get{return _worker_rate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string worker_group_no
		{
			set{ _worker_group_no=value;}
			get{return _worker_group_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? in_date
		{
			set{ _in_date=value;}
			get{return _in_date;}
		}
		#endregion Model.TableModel

	}
}

