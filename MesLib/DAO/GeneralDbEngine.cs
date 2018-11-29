using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;

namespace DAO
{
    /// <summary>
    /// 通用数据库引擎类，用来隔离本地Access数据库和远程Sql数据库
    /// </summary>
    public class GeneralDbEngine
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        private GeneralDbEngine() { }

        /// <summary>
        /// 私有单例字段
        /// </summary>
        private static GeneralDbEngine _generalDbEngine = null;

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
        public static GeneralDbEngine CreateInstance(string sqlConStr, string accessConStr)
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (_generalDbEngine == null)
            {
                lock (_locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (_generalDbEngine == null)
                    {
                        _generalDbEngine = new GeneralDbEngine();
                    }
                }
            }
            _generalDbEngine.SqlConStr = sqlConStr;
            _generalDbEngine.AccessConStr = accessConStr;
            return _generalDbEngine;
        }

        /// <summary>
        /// 公有属性，Sql连接字符串
        /// </summary>
        public string SqlConStr { get; set; }

        /// <summary>
        /// 公有属性，Access连接字符串
        /// </summary>
        public string AccessConStr { get; set; }

        /// <summary>
        /// 执行一般sql语句，返回受影响的记录行数
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="prePms">变量的键值对集合</param>
        /// <returns>受影响的记录行数</returns>
        public int QueryInt(string sql, Dictionary<string, object> prePms = null)
        {
            SqlServerHelper _sqlServer = SqlServerHelper.CreateInstance(SqlConStr);
            int i = 0;
            while (i <= 2)
            {
                try
                {
                    return _sqlServer.QueryInt(sql, prePms);
                }
                catch (Exception ex)
                {
                    i++;
                    Thread.Sleep(500);
                    continue;
                    throw ex;
                }
            }
            AccessDbHelper _accessSever = AccessDbHelper.CreateInstance(AccessConStr);
            return _accessSever.QueryInt(sql, prePms);
        }

        /// <summary>
        /// 执行一般sql语句，返回数据记录表
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="prePms">变量的键值对集合</param>
        /// <returns>数据记录表</returns>
        public DataTable QueryTable(string sql, Dictionary<string, object> prePms = null)
        {
            SqlServerHelper _sqlServer = SqlServerHelper.CreateInstance(SqlConStr);
            int i = 0;
            while (i <= 2)
            {
                try
                {
                    return _sqlServer.QueryTable(sql, prePms);
                }
                catch (Exception exc)
                {
                    i++;
                    Thread.Sleep(500);
                    continue;
                    throw exc;
                }
            }
            AccessDbHelper _accessSever = AccessDbHelper.CreateInstance(AccessConStr);
            return _accessSever.QueryTable(sql, prePms);
        }

        /// <summary>
        /// 执行一般sql语句，返回查询到的对象
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="prePms">变量的键值对集合</param>
        /// <returns>查询到的对象</returns>
        public object QueryObj(string sql, Dictionary<string, object> prePms = null)
        {
            SqlServerHelper _sqlServer = SqlServerHelper.CreateInstance(SqlConStr);
            int i = 0;
            while (i <= 2)
            {
                try
                {
                    return _sqlServer.QueryObj(sql, prePms);
                }
                catch (Exception exc)
                {
                    i++;
                    Thread.Sleep(500);
                    continue;
                    throw exc;
                }
            }
            AccessDbHelper _accessSever = AccessDbHelper.CreateInstance(AccessConStr);
            return _accessSever.QueryObj(sql, prePms);
        }

        /// <summary>
        /// 泛型方法，根据对应操作和泛型列表执行对应数据库操作，返回对应操作影响的行数
        /// </summary>
        /// <typeparam name="T">泛型，Model中数据表的对应类</typeparam>
        /// <param name="opration">数据操作：Insert、Update、Delete忽略大小写</param>
        /// <param name="modelList">泛型列表</param>
        /// <returns>影响的行数</returns>
        public int QueryInt<T>(string opration, List<T> modelList)
        {
            SqlServerHelper _sqlServer = SqlServerHelper.CreateInstance(SqlConStr);
            int i = 0;
            while (i <= 2)
            {
                try
                {
                    return _sqlServer.QueryInt<T>(opration, modelList);
                }
                catch (Exception exc)
                {
                    i++;
                    Thread.Sleep(500);
                    continue;
                    throw exc;
                }
            }
            AccessDbHelper _accessSever = AccessDbHelper.CreateInstance(AccessConStr);
            return _accessSever.QueryInt<T>(opration, modelList);
        }

        /// <summary>
        /// 泛型方法，根据where条件查询对应泛型的表中记录，并返回泛型列表
        /// </summary>
        /// <typeparam name="T">泛型，Model中数据表的对应类</typeparam>
        /// <param name="where">where条件</param>
        /// <returns>泛型列表</returns>
        public List<T> QueryList<T>(string where = null)
        {
            SqlServerHelper _sqlServer = SqlServerHelper.CreateInstance(SqlConStr);
            int i = 0;
            while (i <= 2)
            {
                try
                {
                    return _sqlServer.QueryList<T>(where);
                }
                catch (Exception exc)
                {
                    i++;
                    Thread.Sleep(500);
                    continue;
                    throw exc;
                }
            }
            AccessDbHelper _accessSever = AccessDbHelper.CreateInstance(AccessConStr);
            return _accessSever.QueryList<T>(where);
        }

        /// <summary>
        /// 批量插入数据到数据库中
        /// </summary>
        /// <param name="tblName">对象表名</param>
        /// <param name="dt">要插入的数据列表</param>
        /// <returns>成功插入的行数</returns>
        public int InsertBulk(string tblName, DataTable dt)
        {
            SqlServerHelper _sqlServer = SqlServerHelper.CreateInstance(SqlConStr);
            try
            {
                return _sqlServer.InsertBulk(tblName, dt);
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }
    }
}
