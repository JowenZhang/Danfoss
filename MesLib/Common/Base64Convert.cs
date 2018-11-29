using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public static class Base64Convert
    {
        /// <summary>
        /// Base64解密，采用utf8编码方式解密
        /// </summary>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string Base64Decode(string result)
        {
            return Base64Decode(Encoding.UTF8, result);
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="encodeType">解密采用的编码方式，注意和加密时采用的方式一致</param>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string Base64Decode(Encoding encodeType, string result)
        {
            string decode = string.Empty;
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                decode = encodeType.GetString(bytes);
            }
            catch
            {
                decode = result;
            }
            return decode;
        }

        /// <summary>
        /// Base64加密，采用utf8编码方式解密
        /// </summary>
        /// <param name="orignal">待加密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string Base64Encode(string orignal)
        {
            return Base64Encode(Encoding.UTF8, orignal);
        }

        /// <summary>
        /// Base64加密密
        /// </summary>
        /// <param name="encodeType">解密采用的编码方式，注意和加密时采用的方式一致</param>
        /// <param name="orignal">待加密的原文</param>
        /// <returns>加密后的字符串</returns>
        public static string Base64Encode(Encoding encodeType, string orignal)
        {
            string decode = string.Empty;
            byte[] bytes = encodeType.GetBytes(orignal);
            try
            {
                decode = Convert.ToBase64String(bytes);
            }
            catch
            {
                decode = orignal;
            }
            return decode;
        }
    }
}
