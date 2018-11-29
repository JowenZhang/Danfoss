using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAO
{
    public class SqlServerHelper
    {
        /// <summary>
        /// 私有构造函数
        /// </summary>
        private SqlServerHelper()
        { }

        /// <summary>
        /// 私有单例字段
        /// </summary>
        private static SqlServerHelper _sqlServerHelper = null;

        /// <summary>
        /// 线程同步标识
        /// </summary>
        private static readonly object _locker = new object();

        /// <summary>
        /// 类的单例创建函数
        /// </summary>
        /// <param name="conStr"></param>
        /// <returns></returns>
        public static SqlServerHelper CreateInstance(string conStr)
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (_sqlServerHelper == null)
            {
                lock (_locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (_sqlServerHelper == null)
                    {
                        _sqlServerHelper = new SqlServerHelper();
                    }
                }
            }
            _sqlServerHelper.ConStr = conStr;
            GC.Collect(1);
            return _sqlServerHelper;
        }

        /// <summary>
        /// 公有属性，连接字符串
        /// </summary>
        public string ConStr { get; set; }

        /// <summary>
        /// 准备Access数据库连接
        /// </summary>
        /// <returns>Access数据库连接</returns>
        private SqlConnection PrepareConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConStr);
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    conn.Dispose();
                    GC.Collect(1);
                    conn = new SqlConnection(ConStr);

                }
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 数据库是否可用
        /// </summary>
        /// <returns>是否可用的判定值</returns>
        public bool IsUseable()
        {
            using (SqlConnection con=PrepareConnection())
            {
                try
                {
                    if (con != null)
                    {
                        if (con.State == ConnectionState.Open)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception)
                {
                    con.Dispose();
                    GC.Collect();
                }
            }
            return false;
        }

        /// <summary>
        /// 查询操作泛型方法,目标为单表
        /// </summary>
        /// <param name="where">where过滤条件字符串</param>
        public List<T> QueryList<T>(string where = null)
        {
            List<T> res = new List<T>();
            SqlFactory sqlMaker = SqlFactory.CreateInstance();
            using (IDbConnection conn = PrepareConnection())
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(sqlMaker.SqlCreater<T>("Select"));
                if (!string.IsNullOrEmpty(where))
                {
                    sql.AppendFormat(" where {0}", where);
                }
                try
                {
                    res = Dapper.SqlMapper.Query<T>(conn, sql.ToString(), null).ToList();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
            return res;
        }


        /// <summary>
        /// 插入、更新、删除对象列表操作泛型方法,目标为单表
        /// </summary>
        /// <returns>受影响行数</returns>
        public int QueryInt<T>(string dbOperate, List<T> modelList)
        {
            if (!Illegal(dbOperate))
            {
                throw new Exception("数据库操作类型非法，请查证后重试！");
            }
            int res = 0;
            SqlFactory sqlMaker = SqlFactory.CreateInstance();
            using (IDbConnection conn = PrepareConnection())
            {
                try
                {
                    res = Dapper.SqlMapper.Execute(conn, sqlMaker.SqlCreater<T>(dbOperate), modelList);
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
            return res;
        }

        /// <summary>
        /// 数据库操作是否合法校验类
        /// </summary>
        /// <param name="dbOperate"></param>
        /// <returns>校验结果，合法为真，非法为假</returns>
        private bool Illegal(string dbOperate)
        {
            if (dbOperate.ToLower() == "select" || dbOperate.ToLower() == "insert" || dbOperate.ToLower() == "update" || dbOperate.ToLower() == "delete")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 私有方法，处理Sql变量键值对集合，将其处理为Sql变量List集合
        /// </summary>
        /// <param name="prePms">预处理变量列表集合</param>
        /// <returns>Sql变量List集合</returns>
        private List<SqlParameter> ProcessPms(Dictionary<string, object> prePms)
        {
            List<SqlParameter> pms = new List<SqlParameter>();
            if (prePms != null)
            {
                try
                {
                    foreach (var item in prePms.Keys)
                    {
                        object obj = prePms[item];
                        Type type = obj.GetType();
                        if (type == typeof(bool) || type == typeof(Boolean))
                        {
                            pms.Add(new SqlParameter(item, SqlDbType.Bit) { Value = bool.Parse(string.Format((obj ?? "false").ToString(), type)) });
                        }
                        else if (type == typeof(string) || type == typeof(String) || type == typeof(Char) || type == typeof(char))
                        {
                            pms.Add(new SqlParameter(item, SqlDbType.VarChar) { Value = (obj ?? "").ToString() });
                        }
                        else if (type == typeof(int) || type == typeof(Int32) || type == typeof(Int16))
                        {
                            pms.Add(new SqlParameter(item, SqlDbType.Int) { Value = int.Parse(string.Format((obj ?? "0").ToString(), type)) });
                        }
                        else if (type == typeof(float) || type == typeof(double) || type == typeof(Double) || type == typeof(Decimal) || type == typeof(decimal))
                        {
                            pms.Add(new SqlParameter(item, SqlDbType.Decimal) { Value = decimal.Parse(string.Format((obj ?? "0").ToString(), type)) });
                        }
                        else if (type == typeof(DateTime))
                        {
                            pms.Add(new SqlParameter(item, SqlDbType.DateTime) { Value = DateTime.Parse(string.Format((obj ?? "1900-01-01 00:00:00.000").ToString(), type)) });
                        }
                        else if (type == typeof(long) || type == typeof(Int64))
                        {
                            pms.Add(new SqlParameter(item, SqlDbType.BigInt) { Value = int.Parse(string.Format((obj ?? "0").ToString(), type)) });
                        }
                        else
                        {

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return pms;
        }

        /// <summary>
        /// 执行一般sql语句，返回数据记录表
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <param name="prePms">变量的键值对集合</param>
        /// <returns>数据记录表</returns>
        public DataTable QueryTable(string sqlStr, Dictionary<string, object> prePms = null)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = PrepareConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = sqlStr;
                    cmd.CommandType = CommandType.Text;
                    if (prePms != null && prePms.Count > 0)
                    {
                        cmd.Parameters.AddRange(ProcessPms(prePms).ToArray());
                    }
                    try
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(ds, "result");
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 执行一般sql语句，返回受影响的记录行数
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <param name="prePms">变量的键值对集合</param>
        /// <returns>受影响的记录行数</returns>
        public int QueryInt(string sqlStr, Dictionary<string, object> prePms = null)
        {
            int res = -1;
            using (SqlConnection conn = PrepareConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = sqlStr;
                    cmd.CommandType = CommandType.Text;
                    if (prePms != null && prePms.Count > 0)
                    {
                        cmd.Parameters.AddRange(ProcessPms(prePms).ToArray());
                    }
                    try
                    {
                        res = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// 执行一般sql语句，返回查询到的对象
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <param name="prePms">变量的键值对集合</param>
        /// <returns>查询到的对象</returns>
        public object QueryObj(string sqlStr, Dictionary<string, object> prePms = null)
        {
            object res = new object();
            using (SqlConnection conn = PrepareConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = sqlStr;
                    cmd.CommandType = CommandType.Text;
                    if (prePms != null && prePms.Count > 0)
                    {
                        cmd.Parameters.AddRange(ProcessPms(prePms).ToArray());
                    }
                    try
                    {
                        res = cmd.ExecuteScalar();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// 批量插入数据到指定的数据表
        /// </summary>
        /// <param name="tblName">目标数据表</param>
        /// <param name="dtData">要插入的数据</param>
        /// <returns></returns>
        public int InsertBulk(string tblName, DataTable dtData)
        {
            if (dtData == null || dtData.Rows.Count <= 0)
            {
                return 0;
            }
            using (SqlBulkCopy sqlBulk = new SqlBulkCopy(ConStr, SqlBulkCopyOptions.UseInternalTransaction))
            {
                sqlBulk.DestinationTableName = tblName;
                sqlBulk.BatchSize = dtData.Rows.Count;
                try
                {
                    for (int i = 0; i < dtData.Columns.Count; i++)
                    {
                        sqlBulk.ColumnMappings.Add(dtData.Columns[i].ColumnName, dtData.Columns[i].ColumnName);
                    }
                    sqlBulk.WriteToServer(dtData);
                    return dtData.Rows.Count;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="tblName">表名</param>
        /// <param name="startIndex">开始索引</param>
        /// <param name="endIndex">结束索引</param>
        /// <param name="where">where过滤条件</param>
        /// <param name="orderBy">排序的集合，默认id升序</param>
        /// <param name="rowCount">总行数</param>
        /// <returns>结果集合</returns>
        public DataTable QueryPage(string tblName, int startIndex, int endIndex, string where, Dictionary<string, string> orderBy, out int rowCount)
        {
            DataTable dtRes = new DataTable();
            SqlFactory sqlMaker = SqlFactory.CreateInstance(); 
            string sqlCount = sqlMaker.SqlCountMake(tblName, where);
            string sqlPage = sqlMaker.SqlPageMake(tblName, where, orderBy);
            if (string.IsNullOrEmpty(sqlCount) || string.IsNullOrEmpty(sqlPage))
            {
                rowCount = 0;
                return dtRes;
            }
            object obj = null;
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@startIndex", startIndex);
            pms.Add("@endIndex", endIndex);
            obj = QueryObj(sqlCount, pms);
            DataTable dt = QueryTable(sqlPage,pms);
            dtRes = dt;
            rowCount = int.Parse((obj ?? "0").ToString());
            return dtRes;
        }



        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="tblName">表名</param>

        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页记录条数</param>
        /// <param name="where">where过滤条件</param>
        /// <param name="orderBy">排序的集合，默认id升序</param>
        /// <param name="rowCount">总行数</param>
        /// <returns>结果集合</returns>
        public List<T> QueryPage<T>(string tblName, int pageIndex, int pageSize, string where, Dictionary<string, string> orderBy, out int rowCount)
        {
            List<T> res = null;
            SqlFactory sqlMaker = SqlFactory.CreateInstance();
            string sqlCount = sqlMaker.SqlCountMake(tblName, where);
            string sqlPage = sqlMaker.SqlPageMake(tblName, where, orderBy);
            if (string.IsNullOrEmpty(sqlCount) || string.IsNullOrEmpty(sqlPage))
            {
                rowCount = 0;
                return new List<T>();
            }
            object obj = null;
            Dictionary<string, object> pms = new Dictionary<string, object>();
            int startIndex = (pageIndex - 1) * pageSize+1;
            int endIndex = pageIndex*pageSize;
            pms.Add("@startIndex", startIndex);
            pms.Add("@endIndex", endIndex);
            obj = QueryObj(sqlCount, pms);
            using (IDbConnection conn = PrepareConnection())
            {
                try
                {
                    res = Dapper.SqlMapper.Query<T>(conn, sqlPage,new{startIndex=startIndex,endIndex=endIndex}).ToList();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
            rowCount = int.Parse((obj ?? "0").ToString());
            return res;
        }
    }
}
