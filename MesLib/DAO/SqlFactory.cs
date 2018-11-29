using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DAO
{
    /// <summary>
    /// sql语句自动生成类
    /// </summary>
    public class SqlFactory
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        private SqlFactory() { }

        /// <summary>
        /// 私有单例字段
        /// </summary>
        private static SqlFactory _sqlFactory = null;

        /// <summary>
        /// 线程同步标识
        /// </summary>
        private static readonly object _locker = new object();

        /// <summary>
        /// 类的单例创建函数
        /// </summary>
        /// <returns>创建类的构造函数</returns>
        public static SqlFactory CreateInstance()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (_sqlFactory == null)
            {
                lock (_locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (_sqlFactory == null)
                    {
                        _sqlFactory = new SqlFactory();
                    }
                }
            }
            return _sqlFactory;
        }


        /// <summary>
        /// 反射获取model信息
        /// </summary>
        /// <typeparam name="T">model类型</typeparam>
        /// <param name="tblName">model名称</param>
        /// <returns>model属性列表</returns>
        public List<string> GetModelInfo<T>(out string tblName)
        {
            Type t = typeof(T);
            tblName = t.Name.ToLower();//t.Name.Substring(t.Name.LastIndexOf("."), t.Name.Length - t.Name.LastIndexOf("."));
            List<string> res = new List<string>();
            PropertyInfo[] PropertyList = t.GetProperties();
            foreach (PropertyInfo item in PropertyList)
            {
                res.Add(item.Name);
            }
            return res;
        }

        /// <summary>
        /// 根据model返回sql字符串
        /// </summary>
        /// <typeparam name="T">model类型</typeparam>
        /// <param name="action">sql动作</param>
        /// <returns>sql字符串</returns>
        public string SqlCreater<T>(string action)
        {
            string res = string.Empty;
            string tblName = string.Empty;
            List<string> cols = GetModelInfo<T>(out tblName);
            StringBuilder sql = new StringBuilder();
            if (!string.IsNullOrEmpty(tblName) && cols.Count > 0)
            {
                //若是插入操作
                if (action.ToLower() == "insert")
                {
                    StringBuilder tblStr = new StringBuilder();
                    StringBuilder pmsStr = new StringBuilder();
                    foreach (var item in cols)
                    {
                        tblStr.Append(item);
                        tblStr.Append(",");
                        pmsStr.Append("@");
                        pmsStr.Append(item);
                        pmsStr.Append(",");
                    }
                    tblStr.Remove(tblStr.Length - 1, 1);
                    pmsStr.Remove(pmsStr.Length - 1, 1);
                    sql.Append("insert into ");
                    sql.Append(tblName);
                    sql.Append(" (");
                    sql.Append(tblStr);
                    sql.Append(") values (");
                    sql.Append(pmsStr);
                    sql.Append(");");
                    res = sql.ToString();

                }
                //若是更新操作
                else if (action.ToLower() == "update")
                {
                    sql.Append("update ");
                    sql.Append(tblName);
                    sql.Append(" set ");
                    foreach (var item in cols)
                    {
                        sql.Append(item);
                        sql.Append("=@");
                        sql.Append(item);
                        sql.Append(",");
                    }
                    sql.Remove(sql.Length - 1, 1);
                    sql.Append(" where id=@id;");
                    res = sql.ToString();
                }
                //若是查询操作
                else if (action.ToLower() == "select")
                {
                    sql.Append("select * from ");
                    sql.Append(tblName);
                    res = sql.ToString();
                }
                //若是删除操作
                else if (action.ToLower() == "delete")
                {
                    sql.Append("delete from ");
                    sql.Append(tblName);
                    sql.Append(" where id=@id;");
                    res = sql.ToString();
                }
            }
            return res;
        }

        /// <summary>
        /// 构造分页统计sql语句
        /// </summary>
        /// <param name="tblName">表名</param>
        /// <param name="where">where过滤条件</param>
        /// <returns>sql统计语句</returns>
        public string SqlCountMake(string tblName, string where)
        {
            string res = string.Empty;
            if (string.IsNullOrEmpty(tblName))
            {
                return res;
            }
            StringBuilder sql = new StringBuilder();
            sql.Append(" select count(1) from ");
            sql.Append(tblName);
            if (!string.IsNullOrEmpty(where))
            {
                sql.Append(" where ");
                sql.Append(where);
            }
            res = sql.ToString();
            return res;
        }


        /// <summary>
        /// sql分页语句的构造
        /// </summary>
        /// <param name="tblName">表名</param>
        /// <param name="where">where过滤子句</param>
        /// <param name="orderBy">字符串排序集合，默认为id升序</param>
        /// <returns>sql分页语句</returns>
        public string SqlPageMake(string tblName, string where, Dictionary<string, string> orderBy)
        {
            string res = string.Empty;
            if (string.IsNullOrEmpty(tblName))
            {
                return res;
            }
            //select * from (select row_number() over(order by bom_no desc) as row_num,* from bom) TT where TT.row between @startIndex and @endIndex
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from (");
            sql.Append("select row_number() over");
            sql.Append("(order by ");
            //如果排序条件存在
            if (orderBy != null && orderBy.Count() > 0)
            {
                foreach (var item in orderBy.Keys)
                {
                    sql.Append(item);
                    sql.Append(" ");
                    sql.Append(orderBy[item]);
                    sql.Append(",");
                }
                sql.Remove(sql.Length - 1, 1);
                sql.Append(")");
            }
            //排序条件不存在
            else
            {
                sql.Append("id asc)");
            }
            sql.Append(" as row_num,* from ");
            sql.Append(tblName);
            if (!string.IsNullOrEmpty(where))
            {
                sql.Append(" where ");
                sql.Append(where);
            }
            sql.Append(" ) as T");
            sql.Append(" where T.row_num between @startIndex and @endIndex;");
            res = sql.ToString();
            return res;
        }
    }
}
