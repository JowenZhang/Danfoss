using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// 字节数组、内存、图片操作类
    /// </summary>
    public static class MemeoryOperater
    {
        /// <summary>
        /// 字节数组转图片
        /// </summary>
        /// <param name="buffer">字节数组</param>
        /// <returns>Image图片</returns>
        public static Image Byte2Img(byte[] buffer)
        {
            Image img = null;
            using (MemoryStream ms = new MemoryStream(buffer))
            {
                ms.Position = 0;
                try
                {
                    img = Image.FromStream(ms);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return img;
        }

        /// <summary>
        /// 位图转为字节数组
        /// </summary>
        /// <param name="Bit">Bitmap位图</param>
        /// <returns>字节数组</returns>
        public static byte[] Img2Array(Bitmap Bit)
        {
            byte[] back = null;
            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    Bit.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    back = ms.GetBuffer();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return back;
        }

        /// <summary>
        /// 字符串转UTF8字节数组
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>UTF8字节数组</returns>
        public static byte[] Str2Byte(string str)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
            return data;
        }

        /// <summary>
        /// UTF8字节数组转字符串
        /// </summary>
        /// <param name="data">UTF8字节数组</param>
        /// <returns>字符串</returns>
        public static string str2byte(byte[] data)
        {
            string str = System.Text.Encoding.UTF8.GetString(data);
            return str;
        }

        /// <summary>
        /// 字节数组转化为内存流
        /// </summary>
        /// <param name="data">字节数组</param>
        /// <returns>内存流</returns>
        public static MemoryStream Byte2MemoryStream(byte[] data)
        {
            MemoryStream inputStream = new MemoryStream(data);
            return inputStream;
        }

        /// <summary>
        /// 内存流转化为字节数组
        /// </summary>
        /// <param name="outStream">内存流</param>
        /// <returns>字节数组</returns>
        public static byte[] MemoryStream2Byte(MemoryStream outStream)
        {
            return outStream.ToArray();
        }

        /// <summary>
        /// 流转化为字节数组
        /// </summary>
        /// <param name="stream">流</param>
        /// <returns>字节数组</returns>
        public static byte[] Stream2Byte(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }

        /// <summary>
        /// 字节数组转化为流
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns>流</returns>
        public static Stream Byte2Stream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        /// <summary>
        /// 流写入到文件
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="fileName">含有绝对路径的文件名</param>
        public static void Stream2File(Stream stream, string fileName)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    try
                    {
                        bw.Write(bytes);

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// 文件读取到流中
        /// </summary>
        /// <param name="fileName">含有绝对路径的文件名</param>
        /// <returns>流</returns>
        public static Stream File2Stream(string fileName)
        {
            Stream stream=null;
            // 打开文件
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                byte[] bytes = new byte[fileStream.Length];
                fileStream.Read(bytes, 0, bytes.Length);
                stream = new MemoryStream(bytes);
            }
            return stream;
        }

        /// <summary>
        /// 文件读取到内存流中
        /// </summary>
        /// <param name="fileName">含有绝对路径的文件名</param>
        /// <returns>内存流</returns>
        public static MemoryStream File2MemoryStream(string fileName)
        {
            MemoryStream stream = null;
            // 打开文件
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                byte[] bytes = new byte[fileStream.Length];
                fileStream.Read(bytes, 0, bytes.Length);
                stream = new MemoryStream(bytes);
            }
            return stream;
        }

        /// <summary>
        /// 内存流保存到文件
        /// </summary>
        /// <param name="fileName">含有绝对路径的文件名</param>
        /// <param name="inStream">传入的内存流</param>
        public static void MemoryStream2File(MemoryStream inStream,string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate,FileAccess.Write))
            {
                byte[] buffer = new byte[2048];
                int read = 0;
                inStream.Seek(0, SeekOrigin.Begin);
                do
                {
                    read = inStream.Read(buffer, 0, buffer.Length);
                    fileStream.Write(buffer, 0, read);
                } while (!(read == 0));

            }

            //Stream2File(inStream, fileName);
        }

    }
}
