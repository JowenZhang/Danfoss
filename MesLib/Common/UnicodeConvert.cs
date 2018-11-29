using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    public static class UnicodeConvert
    {
        /// <summary>
        /// 字符串转Unicode
        /// </summary>
        /// <param name="source">原始字符串</param>
        /// <returns>Unicode编码后的字符串</returns>
        public static string String2Unicode(string source) 
        {
            byte[] bytes = Encoding.Unicode.GetBytes(source);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i+=2)
            {
                sb.AppendFormat("\\u{0}{1}", bytes[i + 1].ToString("x").PadLeft(2, '0'), bytes[i].ToString("x").PadLeft(2, '0'));             
            }
            return sb.ToString();
        }

        /// <summary>
        /// Unicode转字符串
        /// </summary>
        /// <param name="source">Unicode编码后的字符串</param>
        /// <returns>原始字符串</returns>
        public static string Unicode2String(string source)
        {
            return new Regex(@"\\u[0-9A-F]{4})", RegexOptions.IgnoreCase | RegexOptions.Compiled).Replace(source, x => string.Empty + Convert.ToChar(Convert.ToUInt16(x.Result("$1"), 16)));
        }
    }
}
