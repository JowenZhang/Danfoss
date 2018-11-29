using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MesMusicPlayer
{
    /// <summary>
    /// 安灯声音播放器
    /// </summary>
    public class AndonPlayer
    {
        /// <summary>
        /// 私有构造函数
        /// </summary>
        private AndonPlayer() { }

        /// <summary>
        /// 私有单例字段
        /// </summary>
        private static AndonPlayer _andonPlayer = null;

        /// <summary>
        /// 线程同步标识
        /// </summary>
        private static readonly object _locker = new object();

        /// <summary>
        /// 类的单例创建函数
        /// </summary>
        /// <returns>创建类的构造函数</returns>
        public static AndonPlayer CreateInstance(string sqlConStr, string andonType, string andonFilePath)
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (_andonPlayer == null)
            {
                lock (_locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (_andonPlayer == null)
                    {
                        _andonPlayer = new AndonPlayer();
                    }
                }
            }
            _andonPlayer.SqlConStr = sqlConStr;
            _andonPlayer.AndonType = andonType;
            _andonPlayer.AndonFilePath = andonFilePath;
            return _andonPlayer;
        }

        /// <summary>
        /// 公有属性，Sql连接字符串
        /// </summary>
        public string SqlConStr { get; set; }

        /// <summary>
        /// 公有属性，安灯类型
        /// </summary>
        public string AndonType { set; get; }
        
        /// <summary>
        /// 公有属性，安灯文件路径
        /// </summary>
        public string AndonFilePath { set; get; }

        /// <summary>
        /// 公有属性，安灯播放器是否运行，真：运行中，假：已停止
        /// </summary>
        public bool AndonPlayerIsRun { set; get; }

        /// <summary>
        /// 私有字段，MP3播放器
        /// </summary>
        private MP3Player _mp3 = MP3Player.CreateInstance();

        /// <summary>
        /// 播放安灯呼叫
        /// </summary>
        /// <param name="dtOpenSftwDateTime">初次打开软件的事件</param>
        /// <param name="andonEqmIndex">安灯播放器编号</param>
        internal void Play(DateTime dtOpenSftwDateTime,int andonEqmIndex)
        {
            AndonPlayerIsRun = false;
            DAO.SqlServerHelper dbEngine = DAO.SqlServerHelper.CreateInstance(SqlConStr);
            string where = string.Format(" call_time>'{0}' and SUBSTRING(play_record,{1},1)='1' and is_finished='false' and andon_type_no in ({2}) order by call_time desc", dtOpenSftwDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"), andonEqmIndex,AndonType);
            List<Model.TableModel.Adn> listAdn = dbEngine.QueryList<Model.TableModel.Adn>(where);
            if (listAdn.Count<=0)
            {
                return;
            }
            string musicName = listAdn[0].andon_music_no;
            _mp3.Play(AndonFilePath + "\\" + musicName, 5);
            int tim = _mp3.GetTimeLong();
            List<Model.TableModel.Adn> newListAdn = new List<Model.TableModel.Adn>();
            string newPlayRecord = CaclNewPlayRecord(listAdn[0].play_record, andonEqmIndex);
            listAdn[0].play_record = newPlayRecord;
            newListAdn.Add(listAdn[0]);
            dbEngine.QueryInt<Model.TableModel.Adn>("Update", newListAdn);
        }

        /// <summary>
        /// 计算新的安灯播放记录
        /// </summary>
        /// <param name="oldPlayRecord">旧播放记录</param>
        /// <param name="adnEqmIndex">安灯设备列表</param>
        /// <returns>新的安灯描述</returns>
        private string CaclNewPlayRecord(string oldPlayRecord, int adnEqmIndex)
        {
            char[] ch = new char[oldPlayRecord.Length];
            if (adnEqmIndex > oldPlayRecord.Length)
            {
                return oldPlayRecord;
            }
            for (int i = 0; i < oldPlayRecord.Length; i++)
            {
                if (i + 1 == adnEqmIndex)
                {
                    ch[i] = '0';
                }
                else
                {
                    ch[i] = oldPlayRecord[i];
                }
            }
            return new string(ch);
        }
    }
}
