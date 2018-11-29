using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// CRUD通用接口
    /// </summary>
    public interface ICtrlOperate
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="where">条件子句</param>
        /// <param name="orderBy">排序子句</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <returns>分页结果序列化结果</returns>
        string GetListPage(string where, Dictionary<string, string> orderBy, int pageSize, int pageIndex);

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="jsonStr">对象的json字符串</param>
        /// <returns>受影响的记录数</returns>
        int Update(string jsonStr);

        /// <summary>
        /// 插入操作
        /// </summary>
        /// <param name="jsonStr">对象的json字符串</param>
        /// <returns>受影响的记录数</returns>
        int Insert(string jsonStr);

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="jsonStr">对象的json字符串</param>
        /// <returns>受影响的记录数</returns>
        int Delete(string jsonStr);
    }
}
