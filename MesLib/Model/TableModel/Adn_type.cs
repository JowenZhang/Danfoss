using System;
namespace Model.TableModel
{
	/// <summary>
	/// Adn_type:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Adn_type
	{
		public Adn_type()
		{}
		#region Model
		private string _id;
		private string _andon_type_no;
		private string _andon_type_name;
        private string _andon_play_eqm;
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
		public string andon_type_no
		{
			set{ _andon_type_no=value;}
			get{return _andon_type_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string andon_type_name
		{
			set{ _andon_type_name=value;}
			get{return _andon_type_name;}
		}

        /// <summary>
        /// 
        /// </summary>
        public string andon_play_eqm 
        {
            set {_andon_play_eqm=value; }
            get { return _andon_play_eqm; }
        }
		#endregion Model
	}
}

