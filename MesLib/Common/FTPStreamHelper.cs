using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Common
{
    public static class FTPStreamHelper
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="memFile">需要上传的文件内存流</param>
        /// <param name="fileName">需要上传的文件名称</param>
        /// <param name="subDir">要访问的ftp子级目录</param>
        /// <param name="hostIP">ftp主机IP</param>
        /// <param name="username">ftp用户名</param>
        /// <param name="password">ftp密码</param>
        /// <returns>上传结果</returns>
        public static bool UploadFile(MemoryStream memFile, string fileName, string subDir, string hostIP, string username, string password)
        {
            bool res = false;
            //1.校验参数是否正确
            if (memFile.Length <= 0)
            {
                return res;
            }
            if (string.IsNullOrEmpty(subDir))
            {
                return res;
            }
            if (subDir.Trim() == "")
            {
                return res;
            }
            if (string.IsNullOrEmpty(fileName))
            {
                return res;
            }
            if (fileName.Trim() == "")
            {
                return res;
            }
            //2.检验文件是否存在
            string basePath = "FTP://" + hostIP + "/";
            List<string> fileList = GetDirctory(basePath, subDir.Trim(), username, password);
            if (fileList.Contains(fileName))
            {
                return res;
            }

            //3.传入文件
            string URI = basePath + subDir.Trim() + "/" + fileName;
            FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(URI);//GetRequest(URI, username, password);
            ftp.Credentials = new System.Net.NetworkCredential(username, password);
            //设置FTP命令 设置所要执行的FTP命令
            ftp.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
            //指定文件传输的数据类型
            ftp.UseBinary = true;
            ftp.KeepAlive = true;
            ftp.UsePassive = false; //告诉ftp文件大小
            ftp.ContentLength = memFile.Length;
            //缓冲大小设置为2KB
            const int BufferSize = 2047;//bufferint
            byte[] content = new byte[BufferSize];//buffer
            int dataRead;//bytes				memStream.Seek(0, SeekOrigin.Begin);
            memFile.Seek(0, SeekOrigin.Begin);
            try
            { 
                //把上传的文件写入流
                using (Stream rs = ftp.GetRequestStream())
                {
                    do
                    { //每次读文件流的2KB
                        dataRead = memFile.Read(content, 0, BufferSize); 
                        rs.Write(content, 0, dataRead);
                    } while (!(dataRead < BufferSize));                    
                }
                //rs.Close();
                FtpWebResponse uploadResponse=(FtpWebResponse)ftp.GetResponse();
                uploadResponse.Close();
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
                throw ex;
            }
            ftp = null; //设置FTP命令
            return res;
        }

        /// 下载文件
        /// </summary>
        /// <param name="localDir">下载至本地路径</param>
        /// <param name="ftpDir">ftp目标文件路径</param>
        /// <param name="fileName">从ftp要下载的文件名</param>
        /// <param name="hostIP">ftp主机IP</param>
        /// <param name="username">ftp用户名</param>
        /// <param name="password">ftp密码</param>
        /// <returns>下载结果</returns>
        public static bool DownloadFile(string localDir, string ftpDir, string fileName, string hostIP, string username, string password)
        {
            bool res = false;
            string URI = "FTP://" + hostIP + "/" + ftpDir + "/" + fileName;
            string localfile = localDir + @"\" + fileName;
            System.Net.FtpWebRequest ftp = GetRequest(URI, username, password);
            ftp.Method = System.Net.WebRequestMethods.Ftp.DownloadFile;
            ftp.UseBinary = true;
            ftp.KeepAlive = true;
            ftp.UsePassive = false;
            using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    //loop to read & write to file
                    using (FileStream fs = new FileStream(localfile, FileMode.CreateNew))
                    {
                        try
                        {
                            byte[] buffer = new byte[2048];
                            int read = 0;
                            do
                            {
                                read = responseStream.Read(buffer, 0, buffer.Length);
                                fs.Write(buffer, 0, read);
                            } while (!(read == 0));
                            responseStream.Close();
                            fs.Flush();
                            fs.Close();
                        }
                        catch (Exception ex)
                        {
                            //catch error and delete file only partially downloaded
                            fs.Close();
                            //delete target file as it's incomplete
                            File.Delete(localfile);
                            res = false; ;
                            throw ex;
                        }
                    }
                    responseStream.Close();
                }
                response.Close();
                res = true;
            }
            
            ftp = null;
            return res;
        }

        /// <summary>
        /// 搜索远程文件
        /// </summary>
        /// <param name="targetDir"></param>
        /// <param name="hostname"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="SearchPattern"></param>
        /// <returns></returns>
        public static List<string> ListDirectory(string targetDir, string hostname, string username, string password, string SearchPattern)
        {
            List<string> result = new List<string>();
            try
            {
                string URI = "FTP://" + hostname + "/" + targetDir + "/" + SearchPattern;

                System.Net.FtpWebRequest ftp = GetRequest(URI, username, password);
                ftp.Method = System.Net.WebRequestMethods.Ftp.ListDirectory;
                ftp.UsePassive = false;
                ftp.UseBinary = true;
                ftp.KeepAlive = true;

                string str = GetStringResponse(ftp);
                str = str.Replace("\r\n", "\r").TrimEnd('\r');
                str = str.Replace("\n", "\r");
                if (str != string.Empty)
                    result.AddRange(str.Split('\r'));

                return result;
            }
            catch { }
            return null;
        }

        private static string GetStringResponse(FtpWebRequest ftp)
        {
            //Get the result, streaming to a string
            string result = "";
            ftp.KeepAlive = true;
            ftp.UsePassive = false;
            using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
            {
                long size = response.ContentLength;
                using (Stream datastream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(datastream, System.Text.Encoding.Default))
                    {
                        result = sr.ReadToEnd();
                        sr.Close();
                    }

                    datastream.Close();
                }

                response.Close();
            }

            return result;
        }

        /// 在ftp服务器上创建目录
        /// </summary>
        /// <param name="dirName">创建的目录名称</param>
        /// <param name="ftpHostIP">ftp地址</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        ///<returns>目录创建结果</returns>
        public static bool MakeDir(string dirName, string ftpHostIP, string username, string password)
        {
            bool res = false ;
            try
            {
                string uri = "ftp://" + ftpHostIP + "/" + dirName;
                System.Net.FtpWebRequest ftp = GetRequest(uri, username, password);
                ftp.Method = WebRequestMethods.Ftp.MakeDirectory;
                ftp.KeepAlive = true;
                ftp.UsePassive = false;
                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
                response.Close();
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
                throw ex;
            }
            return res;
        }

        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="dirName">创建的目录名称</param>
        /// <param name="ftpHostIP">ftp地址</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>目录删除结果</returns>
        public static bool DelDir(string dirName, string ftpHostIP, string username, string password)
        {
            bool res = false;
            try
            {
                string uri = "ftp://" + ftpHostIP + "/" + dirName;
                System.Net.FtpWebRequest ftp = GetRequest(uri, username, password);
                ftp.Method = WebRequestMethods.Ftp.RemoveDirectory;
                ftp.KeepAlive = true;
                ftp.UsePassive = false;
                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
                response.Close();
                res = true; 
            }
            catch (Exception ex)
            {
                res = false;
                throw ex;
            }
            return res;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileDir">ftp文件相对ftp根目录的多级目录</param>
        /// <param name="ftpHostIP">ftp的IP地址</param>
        /// <param name="username">ftp用户名</param>
        /// <param name="password">ftp密码</param>
        /// <param name="fileName">要删除的文件名，不含路径，含拓展名</param>
        /// 
        public static bool DelFile(string fileName,string fileDir, string ftpHostIP, string username, string password)
        {
            bool res = false;
            try
            {
                string uri = "ftp://" + ftpHostIP + "/" + fileDir + "/" + fileName;
                FtpWebRequest reqFTP;
                reqFTP = GetRequest(uri, username, password);//(FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

                reqFTP.Credentials = new NetworkCredential(username, password);
                reqFTP.KeepAlive = true;
                reqFTP.UsePassive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;

                string result = String.Empty;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                long size = response.ContentLength;
                Stream datastream = response.GetResponseStream();
                StreamReader sr = new StreamReader(datastream);
                result = sr.ReadToEnd();
                sr.Close();
                datastream.Close();
                response.Close();
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
                throw ex;
            }
            return res;
        }

        /// <summary>
        /// 文件重命名
        /// </summary>
        /// <param name="currentFilename">当前目录名称</param>
        /// <param name="newFilename">重命名目录名称</param>
        /// <param name="ftpServerIP">ftp地址</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// 
        public static bool Rename(string currentFilename, string newFilename, string ftpServerIP, string username, string password)
        {
            bool res = false;
            try
            {

                FileInfo fileInf = new FileInfo(currentFilename);
                string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;
                System.Net.FtpWebRequest ftp = GetRequest(uri, username, password);
                ftp.Method = WebRequestMethods.Ftp.Rename;
                ftp.KeepAlive = true;
                ftp.UsePassive = false;
                ftp.RenameTo = newFilename;
                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();

                response.Close();
                res = true;
            }
            catch (Exception ex) { res = false; throw ex; }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="URI"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private static FtpWebRequest GetRequest(string URI, string username, string password)
        {
            //根据服务器信息FtpWebRequest创建类的对象
            FtpWebRequest result = (FtpWebRequest)FtpWebRequest.Create(URI);
            //提供身份验证信息
            result.Credentials = new System.Net.NetworkCredential(username, password);
            //设置请求完成之后是否保持到FTP服务器的控制连接，默认值为true
            result.KeepAlive = false;
            return result;
        }

        /// <summary>
        /// 判断ftp服务器上该目录是否存在
        /// </summary>
        /// <param name="dirName">目标目录</param>
        /// <param name="fileFullName">带有拓展名的文件名称</param>
        /// <param name="ftpHostIP">ftp主机Ip</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>返回判定结果</returns>
        public static bool FtpExistFile(string dirName,string fileFullName, string ftpHostIP, string username, string password)
        {
            bool success = false;          
            StreamReader reader = null;
            FtpWebResponse response=null;
            try
            {
                string uri = "ftp://" + ftpHostIP + "/" + dirName;
                System.Net.FtpWebRequest ftp = GetRequest(uri, username, password);
                ftp.Method = WebRequestMethods.Ftp.ListDirectory;
                ftp.KeepAlive = true;
                ftp.UsePassive = false;
                response = (FtpWebResponse)ftp.GetResponse();
                reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (line == fileFullName)
                    {
                        success = true;
                        break;
                    }
                    line = reader.ReadLine();
                }
            }
            catch (Exception)
            {
                success = false;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
            }
            return success;
        }

        /// <summary>
        /// 从请求的ftp路径下获取当前的所有文件名
        /// </summary>
        /// <param name="RequestPath">ftp服务器IP地址</param>
        /// <param name="path">ftp服务器子级目录</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>文件名列表</returns>
        public static List<string> GetDirctory(string RequestPath, string path, string userName, string password)
        {
            List<string> strs = new List<string>();
            try
            {
                string uri = RequestPath + path;   //目标路径 path为服务器地址
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
                // ftp用户名和密码
                reqFTP.Credentials = new NetworkCredential(userName, password);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFTP.KeepAlive = true;
                reqFTP.UsePassive = false;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());//中文文件名
                //current/PSH MES Weekly follow status.xlsx
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (!line.Contains("<DIR>"))
                    {
                        string msg = line.Split(new char[] {'/'})[1];
                        strs.Add(msg);
                    }
                    line = reader.ReadLine();
                }
                reader.Close();
                response.Close();
                return strs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        //-------------old-------------------
        //public static bool FTPUpload(string ftpServerIp,string ftpDir,string fileName,string ftpUserName,string ftpUserPwd,MemoryStream msFile)
        //{
        //    bool res = false;
        //    //1.校验参数是否正确
        //    if (msFile.Length <= 0)
        //    {
        //        return res;
        //    }
        //    if (string.IsNullOrEmpty(ftpDir))
        //    {
        //        return res;
        //    }
        //    if (ftpDir.Trim() == "")
        //    {
        //        return res;
        //    }
        //    if (string.IsNullOrEmpty(fileName))
        //    {
        //        return res;
        //    }
        //    if (fileName.Trim() == "")
        //    {
        //        return res;
        //    }
        //    string basePath = "FTP://" + ftpServerIp + "/";
        //    FtpWebRequest reqFTP;
        //    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(basePath + "/" + ftpDir + "/" + fileName));
        //    reqFTP.Credentials = new NetworkCredential(ftpUserName, ftpUserPwd);
        //    reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
        //    reqFTP.KeepAlive = false;
        //    reqFTP.UseBinary = true;
        //    reqFTP.UsePassive = false;
        //    reqFTP.ContentLength = msFile.Length;
        //    int buffLength = 2048;
        //    byte[] buff = new byte[buffLength];
        //    int contentLen;
        //    msFile.Seek(0, SeekOrigin.Begin);
        //    try
        //    {
        //        Stream strm = reqFTP.GetRequestStream();
        //        contentLen = msFile.Read(buff, 0, buffLength);
        //        while (contentLen != 0)
        //        {
        //            strm.Write(buff, 0, contentLen);
        //            contentLen = msFile.Read(buff, 0, buffLength);
        //        }
        //        strm.Close();
        //        msFile.Close();
        //        //msFile.Flush();
        //        //msFile.Dispose();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
