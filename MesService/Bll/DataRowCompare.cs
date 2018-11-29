using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Bll
{
    /// <summary>
    /// 数据行比较类
    /// </summary>
    public class DataRowCompare:IEqualityComparer<DataRow>
    {
        public bool Equals(DataRow x, DataRow y)
        {
            string xValue = x.Field<string>("SerialNo");
            string yValue = y.Field<string>("SerialNo");
            if (string.IsNullOrEmpty(xValue)&&string.IsNullOrEmpty(yValue))
            {
                return false;
            }
            else
            {
                return xValue == yValue;
            }
        }

        public int GetHashCode(DataRow obj)
        {
            int res = 0;
            try
            {
                res = obj.Field<string>("SerialNo").GetHashCode();
            }
            catch (Exception)
            {
                res = 0;
            }
            return res;
        }
    }
}
