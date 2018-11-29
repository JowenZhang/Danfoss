using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// Json帮助类
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// 将对象序列化为JSON格式
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns>json字符串</returns>
        public static string SerializeObject(object o)
        {
            string json = JsonConvert.SerializeObject(o);
            return json;
        }

        /// <summary>
        /// 解析JSON字符串生成对象实体
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json字符串(eg.{"ID":"112","Name":"石子儿"})</param>
        /// <returns>对象实体</returns>
        public static T DeserializeJsonToObject<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(T));
            T t = o as T;
            return t;
        }

        /// <summary>
        /// 解析JSON数组生成对象实体集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json数组字符串(eg.[{"ID":"112","Name":"石子儿"}])</param>
        /// <returns>对象实体集合</returns>
        public static List<T> DeserializeJsonToList<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(List<T>));
            List<T> list = o as List<T>;
            return list;
        }

        /// <summary>
        /// 反序列化JSON到给定的匿名对象.
        /// </summary>
        /// <typeparam name="T">匿名对象类型</typeparam>
        /// <param name="json">json字符串</param>
        /// <param name="anonymousTypeObject">匿名对象</param>
        /// <returns>匿名对象</returns>
        public static T DeserializeAnonymousType<T>(string json, T anonymousTypeObject)
        {
            T t = JsonConvert.DeserializeAnonymousType(json, anonymousTypeObject);
            return t;
        }

        public static string SerializeJsonList<T>(List<T> pms)
        {
            return JsonConvert.SerializeObject(pms);
        }

        public static List<T> DeSerializeJsonList<T>(string json)
        {
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        /// <summary>
        /// DataReader转换为Json
        /// </summary>
        /// <param name="dataReader">DataReader对象</param>
        /// <returns>Json字符串(数组）</returns>
        ///
        public static string DataReaderToJson(System.Data.SqlClient.SqlDataReader dataReader)
        {
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("[");
            while (dataReader.Read())
            {
                jsonString.Append("{");
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    Type type = dataReader.GetFieldType(i);
                    string strKey = dataReader.GetName(i);
                    string strValue = dataReader[i].ToString();
                    jsonString.Append("\"" + strKey + "\":");
                    strValue = String.Format(strValue, type);
                    //datetime不能出现为空的情况,所以将其转换成字符串来进行处理。
                    //需要加""的
                    if (type == typeof(string) || type == typeof(DateTime))
                    {
                        if (i <= dataReader.FieldCount - 1)
                        {
                            jsonString.Append("\"" + strValue + "\",");
                        }
                        else
                        {
                            jsonString.Append(strValue);
                        }
                    }
                    //不需要加""的
                    else
                    {
                        if (i <= dataReader.FieldCount - 1)
                        {
                            jsonString.Append("" + strValue + ",");
                        }
                        else
                        {
                            jsonString.Append(strValue);
                        }
                    }
                }

                jsonString.Append("},");
            }
            dataReader.Close();
            jsonString.Remove(jsonString.Length - 3, 3);
            jsonString.Append("}");
            jsonString.Append("]");
            return jsonString.ToString();
        }

        /// <summary>
        /// DataReader转换为Json
        /// </summary>
        /// <param name="dataReader">DataReader对象</param>
        /// <returns>Json字符串(数组）</returns>
        ///
        public static string DataTableToJson(System.Data.DataTable dataTable)
        {
            if (dataTable.Rows.Count <= 0)
            {
                return string.Empty;
            }
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("[");
            foreach (System.Data.DataRow item in dataTable.Rows)
            {
                jsonString.Append("{");
                for (int i = 0; i < item.ItemArray.Count(); i++)
                {
                    if (dataTable.Columns[i].ColumnName == "row")
                    {
                        continue;
                    }
                    Type type = item[i].GetType();
                    string strKey = dataTable.Columns[i].ColumnName;
                    string strValue = item.ItemArray[i].ToString() ?? null;
                    jsonString.Append("\"" + strKey + "\":");
                    if (type == typeof(bool) || type == typeof(Boolean))
                    {
                        strValue = String.Format(strValue, type).ToLower();
                    }
                    else
                    {
                        strValue = String.Format(strValue, type);
                    }
                    //datetime不能出现为空的情况,所以将其转换成字符串来进行处理。
                    if (string.IsNullOrEmpty(strValue))
                    {
                        if (i < item.ItemArray.Count() - 1)
                        {
                            jsonString.Append("null,");
                        }
                        else
                        {
                            jsonString.Append("null");
                        }
                    }
                    else
                    {
                        //需要加""的
                        if (type == typeof(string) || type == typeof(DateTime))
                        {
                            if (i < item.ItemArray.Count() - 1)
                            {
                                jsonString.Append("\"" + strValue + "\",");
                            }
                            else
                            {
                                jsonString.Append("\"" + strValue + "\"");
                            }
                        }
                        //不需要加""的
                        else
                        {
                            if (i < item.ItemArray.Count() - 1)
                            {
                                jsonString.Append(strValue + ",");
                            }
                            else
                            {
                                jsonString.Append(strValue);
                            }
                        }
                    }
                }
                jsonString.Append("},");
            }
            jsonString.Remove(jsonString.Length - 2, 2);
            jsonString.Append("}");
            jsonString.Append("]");
            return jsonString.ToString();
        }
    }
}