using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll
{
    /// <summary>
    /// 数据库字符串连接构造工厂类
    /// </summary>
    public class DbConStrFactory
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        private DbConStrFactory() { }

        /// <summary>
        /// 私有单例字段
        /// </summary>
        private static DbConStrFactory _dbConStrFactory = null;

        /// <summary>
        /// 线程同步标识
        /// </summary>
        private static readonly object _locker = new object();


        /// <summary>
        /// 类的单例创建函数
        /// </summary>
        /// <param name="sqlConStr">sqlServer连接字符串</param>
        /// <param name="accessConStr">access连接字符串</param>
        /// <returns>创建类的构造函数</returns>
        public static DbConStrFactory CreateInstance()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (_dbConStrFactory == null)
            {
                lock (_locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (_dbConStrFactory == null)
                    {
                        _dbConStrFactory = new DbConStrFactory();
                    }
                }
            }
            return _dbConStrFactory;
        }

        /// <summary>
        /// 获取Sql连接字符串并启用缓存
        /// </summary>
        /// <param name="dbConfig">Sql数据库的配置头</param>
        /// <returns>Sql连接字符串</returns>
        public string GetSqlConStr(string dbConfig)
        {
            string res = string.Empty;
            object obj = Common.DataCache.GetCache(dbConfig);
            if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
            {
                res = obj.ToString();
            }
            else
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"Config\mesServiceConfig.xml";
                //string host = Common.ConfigHelper.GetConfigValueFromXml(dbConfig, "host", path);
                //string database = Common.ConfigHelper.GetConfigValueFromXml(dbConfig, "database", path);
                //string user = Common.ConfigHelper.GetConfigValueFromXml(dbConfig, "user", path);
                //string password = Common.ConfigHelper.GetConfigValueFromXml(dbConfig, "password", path);
                //StringBuilder conStr = new StringBuilder();
                //conStr.Append("Data Source=");
                //conStr.Append(host);
                //conStr.Append("; Initial Catalog=");
                //conStr.Append(database);
                //conStr.Append("; User Id=");
                //conStr.Append(user);
                //conStr.Append("; Password=");
                //conStr.Append(password);
                //conStr.Append(";");
                res = Common.ConfigHelper.GetConfigValueFromXml("connectionStr", dbConfig, path);
                Common.DataCache.SetCache(dbConfig, res, DateTime.Now.AddMinutes(10), new TimeSpan(0));
            }
            return res;
        }

        /// <summary>
        /// 获取Access连接字符串并启用缓存
        /// </summary>
        /// <param name="dbConfig">Sql数据库的配置头</param>
        /// <returns>Access连接字符串</returns>
        public string GetAccessConStr(string dbConfig)
        {
            string res = string.Empty;
            object obj = Common.DataCache.GetCache(dbConfig);
            if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
            {
                res = obj.ToString();
            }
            else
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"Config\mesServiceConfig.xml";
                //string dataSource = Common.ConfigHelper.GetConfigValueFromXml(dbConfig, "dataSource", path);
                //StringBuilder conStr = new StringBuilder();
                //conStr.Append("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=");
                //conStr.Append(dataSource);
                //conStr.Append(";");
                res = Common.ConfigHelper.GetConfigValueFromXml("connectionStr", dbConfig, path); //conStr.ToString();
                Common.DataCache.SetCache(dbConfig, res, DateTime.Now.AddMinutes(10), new TimeSpan(0));
            }
            return res;
        }
    }
}
