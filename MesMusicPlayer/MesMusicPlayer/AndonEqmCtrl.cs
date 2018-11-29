using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MesMusicPlayer
{
    /// <summary>
    /// 安灯呼叫的控制类
    /// </summary>
    public class AndonEqmCtrl
    {
        /// <summary>
        /// 私有构造函数
        /// </summary>
        private AndonEqmCtrl() { }

        /// <summary>
        /// 私有单例字段
        /// </summary>
        private static AndonEqmCtrl _andonEqmCtrl = null;

        /// <summary>
        /// 线程同步标识
        /// </summary>
        private static readonly object _locker = new object();


        /// <summary>
        /// 类的单例创建函数
        /// </summary>
        /// <param name="playerIndex">音乐播放器的序号</param>
        /// <param name="andonType">需要变动的安灯类型</param>
        /// <param name="conStr">Sql连接字符串</param>
        /// <returns></returns>
        public static AndonEqmCtrl CreateInstance(string conStr)
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (_andonEqmCtrl == null)
            {
                lock (_locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (_andonEqmCtrl == null)
                    {
                        _andonEqmCtrl = new AndonEqmCtrl();
                    }
                }
            }
            _andonEqmCtrl.SqlConStr = conStr;
            return _andonEqmCtrl;
        }

        /// <summary>
        /// 公有属性，Sql连接字符串
        /// </summary>
        public string SqlConStr { get; set; }

        /// <summary>
        /// 私有属性，sql数据库引擎
        /// </summary>
        private DAO.SqlServerHelper DbEngine
        {
            get
            {
                return DAO.SqlServerHelper.CreateInstance(SqlConStr);
            }
        }

        /// <summary>
        /// 更新现有安灯的播放器安排序号
        /// </summary>
        /// <param name="playerIndex">安灯播放器序号</param>
        /// <param name="andonTypeNo">安灯类型</param>
        /// <param name="ZeroOrOne">安灯播放器是否启用的描述,真1假0</param>
        /// <returns>更新是否成功</returns>
        public bool Update(int playerIndex,string andonTypeNo,bool zeroOrOne)
        {
            if (playerIndex>10)
            {
                return false;
            }
            string where = string.Format(" andon_type_no='{0}'", andonTypeNo);
            List<Model.TableModel.Adn_type> listAdnType=DbEngine.QueryList<Model.TableModel.Adn_type>(where);
            if (listAdnType==null)
            {
                return false;
            }
            if (listAdnType.Count!=1)
            {
                return false;
            }
            string newAndonPlayEqm = CaclNewPlayEqm(listAdnType[0].andon_play_eqm,playerIndex,zeroOrOne);
            listAdnType[0].andon_play_eqm = newAndonPlayEqm;
            return DbEngine.QueryInt<Model.TableModel.Adn_type>("Update", listAdnType)>0;
        }

        /// <summary>
        /// 计算新的安灯播放器安排列表
        /// </summary>
        /// <param name="oldPlayEqm">更新前的列表</param>
        /// <param name="playerIndex">播放器序列号</param>
        /// <param name="ZeroOrOne">安灯播放器是否启用的描述,真1假0</param>
        /// <returns>新的安灯播放器安排列表</returns>
        private string CaclNewPlayEqm(string oldPlayEqm, int playerIndex,bool zeroOrOne)
        {
            char[] ch = new char[Math.Max(oldPlayEqm.Length, playerIndex)];
            if (oldPlayEqm.Length>=playerIndex)
            {
                for (int i = 0; i < oldPlayEqm.Length; i++)
                {
                    if (i + 1 == playerIndex)
                    {
                        ch[i] = zeroOrOne?'1':'0';
                    }
                    else
                    {
                        ch[i] = oldPlayEqm[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < playerIndex; i++)
                {
                    if (i<oldPlayEqm.Length)
                    {
                        ch[i] = oldPlayEqm[i];    
                    }
                    else if (i + 1 != playerIndex)
                    {
                        ch[i] = '0';
                    }
                    else
                    {
                        ch[i] = '1';
                    }
                }
            }
            return new string(ch);
        }

        /// <summary>
        /// 加载并初始化播放器配置
        /// </summary>
        /// <param name="playerIndex">播放器列表</param>
        /// <returns>播放器配置</returns>
        public Dictionary<string, bool> LoadAndonEqmStatus(int playerIndex)
        {
            if (playerIndex<=0 || playerIndex>10)
            {
                return new Dictionary<string, bool>();
            }
            List<Model.TableModel.Adn_type> listAdnType= DbEngine.QueryList<Model.TableModel.Adn_type>();
            foreach (Model.TableModel.Adn_type item in listAdnType)
            {
                if (item.andon_play_eqm.Length<playerIndex)
                {
                    Update(playerIndex, item.andon_type_no, false);
                }
            }
            listAdnType.Clear();
            listAdnType = DbEngine.QueryList<Model.TableModel.Adn_type>();
            Dictionary<string, bool> res = new Dictionary<string, bool>();
            foreach (Model.TableModel.Adn_type item in listAdnType)
            {
                res.Add(item.andon_type_no, item.andon_play_eqm[playerIndex - 1] == '1');
            }
            return res;
        }

        /// <summary>
        /// 更新历史安灯记录
        /// </summary>
        /// <param name="openSftwTime">首次打开软件的时间</param>
        /// <param name="playerIndex">播放器序列号</param>
        /// <returns>受影响记录条数</returns>
        public int UpdateHistroyAdn(DateTime openSftwTime, int playerIndex)
        {
            string where = string.Format(" call_time<='{0}' and SUBSTRING(play_record,{1},1)='1' order by call_time desc", openSftwTime.ToString("yyyy-MM-dd HH:mm:ss.fff"), playerIndex);
            DAO.SqlServerHelper dbEngine = DAO.SqlServerHelper.CreateInstance(SqlConStr);
            List<Model.TableModel.Adn> listAnd= dbEngine.QueryList<Model.TableModel.Adn>(where);
            foreach (Model.TableModel.Adn item in listAnd)
            {
                string newPlayRecord = CaclNewPlayRecord(item.play_record, playerIndex);
                item.play_record = newPlayRecord;
            }
            return dbEngine.QueryInt<Model.TableModel.Adn>("Update",listAnd);
        }

        /// <summary>
        /// 计算新的安灯播放记录
        /// </summary>
        /// <param name="oldPlayRecord">旧播放记录</param>
        /// <param name="adnEqmIndex">安灯设备列表</param>
        /// <returns>新的安灯描述</returns>
        private string CaclNewPlayRecord(string oldPlayRecord,int adnEqmIndex)
        {
            char[] ch=new char[oldPlayRecord.Length];
            if (adnEqmIndex>oldPlayRecord.Length)
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
