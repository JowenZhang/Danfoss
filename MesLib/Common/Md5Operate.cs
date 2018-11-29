using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public static class Md5Operate
    {
        /// <summary>
        /// 按时间Tick生成MD5
        /// </summary>
        /// <returns>MD5序列小写字符串</returns>
        public static string CreateMd5Id()
        {
            MD5 md5 = MD5.Create();
            byte[] data = Encoding.UTF8.GetBytes(((DateTime.Now.Ticks) + new Random().Next()).ToString());
            byte[] data2 = md5.ComputeHash(data);

            return GetbyteToString(data2).Replace("-", "").ToLower();
            //return BitConverter.ToString(data2).Replace("-", "").ToLower();
        }

        /// <summary>
        /// 生成真GUID
        /// </summary>
        /// <returns>GUID小写字符串</returns>
        public static string CreateGuid()
        {
            byte[] guidArray = Guid.NewGuid().ToByteArray();
            return new Guid(guidArray).ToString().Replace("-", string.Empty);
        }

        /// <summary>
        /// 生成时间序列的GUID
        /// </summary>
        /// <returns>时间序列的GUID小写字符串</returns>
        public static string CreateGuidId()
        {
            byte[] guidArray = Guid.NewGuid().ToByteArray();
            var baseDate = new DateTime(1900, 1, 1);
            DateTime now = DateTime.Now;
            var days = new TimeSpan(now.Ticks - baseDate.Ticks);
            TimeSpan msecs = now.TimeOfDay;
            byte[] daysArray = BitConverter.GetBytes(days.Days);
            byte[] msecsArray = BitConverter.GetBytes((long)(msecs.TotalMilliseconds / 3.333333));
            Array.Reverse(daysArray);
            Array.Reverse(msecsArray);
            Array.Copy(daysArray, daysArray.Length - 2, guidArray, guidArray.Length - 6, 2);
            Array.Copy(msecsArray, msecsArray.Length - 4, guidArray, guidArray.Length - 4, 4);
            return new Guid(guidArray).ToString().Replace("-", string.Empty);
        }

        /// <summary>
        /// 通过字符串获取MD5值，返回32位小写字符串。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMD5String(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] data = Encoding.UTF8.GetBytes(str);
            byte[] data2 = md5.ComputeHash(data);
            return GetbyteToString(data2);
            //return BitConverter.ToString(data2).Replace("-", "").ToLower();
        }

        /// <summary>
        /// 获取MD5值。HashAlgorithm.Create("MD5") 或 MD5.Create() HashAlgorithm.Create("SHA256") 或 SHA256.Create()
        /// </summary>
        /// <param name="str"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static string GetMD5String(string str, HashAlgorithm hash)
        {
            byte[] data = Encoding.UTF8.GetBytes(str);
            byte[] data2 = hash.ComputeHash(data);
            return GetbyteToString(data2);
            //return BitConverter.ToString(data2).Replace("-", "").ToLower();
        }

        /// <summary>
        /// 获取MemoryStream的MD5值
        /// </summary>
        /// <param name="memStream">内存流</param>
        /// <returns>MD5的32位小写字符串</returns>
        public static string GetMD5FromMemoryStream(MemoryStream memStream)
        {
            MD5 md5 = MD5.Create();
            byte[] data1 = MemeoryOperater.MemoryStream2Byte(memStream);
            byte[] data2 = md5.ComputeHash(data1);                
            return GetbyteToString(data2);
        }

        /// <summary>
        /// 获取文件的MD5值
        /// </summary>
        /// <param name="path">含路径的文件名称</param>
        /// <returns>MD5的32位小写字符串</returns>
        public static string GetMD5FromFile(string path)
        {
            MD5 md5 = MD5.Create();
            if (!File.Exists(path))
            {
                return "";
            }
            List<byte> data2=null;
            using (FileStream stream = File.OpenRead(path))
            {
                data2 = new List<byte>();
                foreach (var item in md5.ComputeHash(stream))
                {
                    data2.Add(item);
                }
            }
            return GetbyteToString(data2.ToArray());
            //return BitConverter.ToString(data2).Replace("-", "").ToLower();
        }

        private static string GetbyteToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString().ToLower();
        }

        /// <summary>
        /// 根据当前关键字创建序列号：年月日8位顺序号
        /// </summary>
        /// <param name="keyWord">关键字</param>
        /// <param name="relativePath">相对于当前目录的下级目录，不用加斜线</param>
        /// <returns>序列号</returns>
        public static string CreateNo(string keyWord, string relativePath)
        {
            string file = relativePath + @"\Sequence.data";
            //[{"1号":"15","2号":"18"}]
            if (!File.Exists(file))
            {
                File.Create(file);
            }
            string[] lines = File.ReadAllLines(file);
            if (lines.Length <= 0)
            {
                lines = new string[1];
            }
            if (string.IsNullOrEmpty(lines[0]))
            {
                lines[0] = "[{\"" + keyWord + "\":0}]";
            }
            System.Data.DataTable dt = Common.JsonHelper.DeserializeJsonToObject<System.Data.DataTable>(lines[0]);
            if (dt.Rows.Count < 1)
            {
                return CreateGuidId();
            }
            foreach (System.Data.DataColumn item in dt.Columns)
            {
                if (item.ColumnName == keyWord)
                {
                    string str = dt.Rows[0][keyWord].ToString();
                    dt.Rows[0][keyWord] = int.Parse(str) + 1;
                    lines[0] = Common.JsonHelper.SerializeObject(dt);
                    File.WriteAllLines(file, lines, Encoding.Default);
                    return DateTime.Now.Date.ToString("yyyyMMdd") + (int.Parse(str) + 1).ToString("00000000");
                }
            }
            dt.Columns.Add(new System.Data.DataColumn(keyWord));
            dt.Rows[0][keyWord] = 1;
            lines[0] = Common.JsonHelper.SerializeObject(dt);
            File.WriteAllLines(file, lines, Encoding.Default);
            return DateTime.Now.Date.ToString("yyyyMMdd") + (1).ToString("00000000");
        }

        /// <summary>
        /// 在相对路径下创建序列号：年月日8位顺序号
        /// </summary>
        /// <param name="keyWord">关键字</param>
        /// <returns>序列号</returns>
        public static string CreateNo(string keyWord)
        {
            //[{"1号":"15","2号":"18"}]
            if (!File.Exists("Sequence.data"))
            {
                File.Create("Sequence.data");
            }
            string[] lines = File.ReadAllLines("Sequence.data");
            if (lines.Length <= 0)
            {
                lines = new string[1];
            }
            if (string.IsNullOrEmpty(lines[0]))
            {
                lines[0] = "[{\"" + keyWord + "\":0}]";
            }
            System.Data.DataTable dt = Common.JsonHelper.DeserializeJsonToObject<System.Data.DataTable>(lines[0]);
            if (dt.Rows.Count < 1)
            {
                return CreateGuidId();
            }
            foreach (System.Data.DataColumn item in dt.Columns)
            {
                if (item.ColumnName == keyWord)
                {
                    string str = dt.Rows[0][keyWord].ToString();
                    dt.Rows[0][keyWord] = int.Parse(str) + 1;
                    lines[0] = Common.JsonHelper.SerializeObject(dt);
                    File.WriteAllLines("Sequence.data", lines, Encoding.Default);
                    return DateTime.Now.Date.ToString("yyyyMMdd") + (int.Parse(str) + 1).ToString("00000000");
                }
            }
            dt.Columns.Add(new System.Data.DataColumn(keyWord));
            dt.Rows[0][keyWord] = 1;
            lines[0] = Common.JsonHelper.SerializeObject(dt);
            File.WriteAllLines("Sequence.data", lines, Encoding.Default);
            return DateTime.Now.Date.ToString("yyyyMMdd") + (1).ToString("00000000");
        }
    }
}