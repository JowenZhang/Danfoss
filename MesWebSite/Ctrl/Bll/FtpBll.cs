using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Ctrl.Bll
{
    /// <summary>
    /// Ftp文件操作类
    /// </summary>
    public class FtpBll
    {
        /// <summary>
        /// FTP文件添加操作
        /// </summary>
        /// <param name="msFile">内存流中的文件</param>
        /// <param name="ftpRelativePath">ftp的相对目标路径</param>
        /// <param name="hostIp">ftp主机IP</param>
        /// <param name="userNo">ftp用户名</param>
        /// <param name="userPwd">ftp用户密码</param>
        /// <param name="viewModel">文件视图对象</param>
        /// <returns>操作结果</returns>
        public string FtpAdd(MemoryStream msFile, string ftpRelativePath, string hostIp, string userNo, string userPwd, ModelView.DmsFileView viewModel)
        {
            if (viewModel == null)
            {
                return "操作对象不能为空！";
            }
            //生成文件md5值
            viewModel.file_md5 = Common.Md5Operate.GetMD5FromMemoryStream(msFile);
            string fileExtension = System.IO.Path.GetExtension(viewModel.file_info);
            string fileOperateName =viewModel.file_md5+"_"+ System.IO.Path.GetFileNameWithoutExtension(viewModel.file_info) + fileExtension;
            if (viewModel.file_type_no.ToLower() == "08" || viewModel.file_type_no.ToLower() == "09")//bom和pms
            {
                if (!(fileExtension.ToLower() == ".xls" || fileExtension.ToLower() == ".xlsx"))
                {
                    return "文件格式不正确！";
                }
            }
            //文件格式校验
            List<string> exts = new List<string>();
            exts.Add(".doc");
            exts.Add(".docx");
            exts.Add(".xls");
            exts.Add(".xlsx");
            exts.Add(".ppt");
            exts.Add(".ppts");
            if (!exts.Contains(fileExtension.ToLower()))
            {
                return "文件格式不正确！";
            }

            //校验文件是否存在
            if (Common.FTPStreamHelper.FtpExistFile(ftpRelativePath, fileOperateName, hostIp, userNo, userPwd))
            {
                return "不能上传已存在的文件！";
            }

            if (Common.FTPStreamHelper.UploadFile(msFile, fileOperateName, ftpRelativePath, hostIp, userNo, userPwd))
            {
                Ctrl.DmsFileCtrl dfc = new DmsFileCtrl();
                if (dfc.Insert(viewModel) > 0)
                {
                    return "success";
                }
                else
                {
                    Common.FTPStreamHelper.DelFile(fileOperateName, ftpRelativePath, hostIp, userNo, userPwd);
                    return "数据写入失败！";
                }
            }
            else
            {
                return "Ftp文件上传失败！";
            }
        }

        /// <summary>
        /// FTP文件添加操作
        /// </summary>
        /// <param name="msFile">内存流中的文件</param>
        /// <param name="ftpRelativePath">ftp的相对目标路径</param>
        /// <param name="hostIp">ftp主机IP</param>
        /// <param name="userNo">ftp用户名</param>
        /// <param name="userPwd">ftp用户密码</param>
        /// <param name="viewModel">文件信息</param>
        /// <param name="fileInfo">附件信息（名称+拓展名）</param>
        /// <returns>操作结果</returns>
        public string FtpAdd(MemoryStream msFile, string ftpRelativePath, string hostIp, string userNo, string userPwd,ModelView.DmsFileView viewModel, string fileInfo)
        {
            if (string.IsNullOrEmpty(fileInfo))
            {
                return "目标文件信息无法读取！";
            }
            string fileExtension = System.IO.Path.GetExtension(fileInfo);
            string fileOperateName = fileInfo;
            //文件格式校验
            List<string> exts = new List<string>();
            exts.Add(".doc");
            exts.Add(".docx");
            exts.Add(".xls");
            exts.Add(".xlsx");
            exts.Add(".ppt");
            exts.Add(".ppts");
            if (!exts.Contains(fileExtension.ToLower()))
            {
                return "文件格式不正确！";
            }

            //校验文件是否存在
            if (Common.FTPStreamHelper.FtpExistFile(ftpRelativePath, fileOperateName, hostIp, userNo, userPwd))
            {
                return "不能上传已存在的文件！";
            }
            if (Common.FTPStreamHelper.UploadFile(msFile, fileOperateName, ftpRelativePath, hostIp, userNo, userPwd))
            {
                viewModel.ralate_file_name = fileInfo;
                Ctrl.DmsFileCtrl dfc = new DmsFileCtrl();
                if (dfc.Update(viewModel) > 0)
                {
                    return "success";
                }
                else
                {
                    Common.FTPStreamHelper.DelFile(fileOperateName, ftpRelativePath, hostIp, userNo, userPwd);
                    return "数据写入失败！";
                }
            }
            else
            {
                return "Ftp文件上传失败！";
            }
        }

        /// <summary>
        /// Ftp文件删除操作
        /// </summary>
        /// <param name="ftpRelativePath">ftp的相对目标路径</param>
        /// <param name="hostIp">ftp主机IP</param>
        /// <param name="userNo">ftp用户名</param>
        /// <param name="userPwd">ftp用户密码</param>
        /// <param name="viewModel">文件视图对象</param>
        /// <returns>操作结果</returns>
        public string FtpDelete(string ftpRelativePath, string hostIp, string userNo, string userPwd, ModelView.DmsFileView viewModel)
        {
            if (viewModel == null)
            {
                return "操作对象不能为空！";
            }
            string msg = "success";
            string fileOperateName = viewModel.file_md5 + "_"+System.IO.Path.GetFileNameWithoutExtension(viewModel.file_info) + System.IO.Path.GetExtension(viewModel.file_info);
            msg = Common.FTPStreamHelper.DelFile(fileOperateName, ftpRelativePath, hostIp, userNo, userPwd) ? "success" : "Ftp删除文件失败！";
            return msg;
        }

        /// <summary>
        /// ftp文件移动操作
        /// </summary>
        /// <param name="ftpSourcePath">Ftp文件原始路径</param>
        /// <param name="destinyPath">Ftp文件目标路径</param>
        /// <param name="fullTmpPath">Ftp文件中转路径</param>
        /// <param name="hostIp">ftp主机IP</param>
        /// <param name="userNo">ftp用户名</param>
        /// <param name="userPwd">ftp用户密码</param>
        /// <param name="viewModel">文件视图对象</param>
        /// <returns>操作结果</returns>
        public string FtpRemove(string ftpSourcePath, string destinyPath, string fullTmpPath, string hostIp, string userNo, string userPwd, ModelView.DmsFileView viewModel)
        {
            if (viewModel == null)
            {
                return "操作对象不能为空！";
            }
            string msg = "success";
            string filefullPath = string.Empty;
            string fileOperateName = viewModel.file_md5 + "_" + System.IO.Path.GetFileNameWithoutExtension(viewModel.file_info) + System.IO.Path.GetExtension(viewModel.file_info);
            filefullPath = fullTmpPath.EndsWith("\\") ? fullTmpPath + fileOperateName : fullTmpPath + "\\" + fileOperateName;
            File.Delete(filefullPath);
            if (!Common.FTPStreamHelper.DownloadFile(fullTmpPath, ftpSourcePath, fileOperateName, hostIp, userNo, userPwd))
            {
                return "Ftp故障，文件移动失败！";
            }
            if (!Common.FTPStreamHelper.DelFile(fileOperateName, ftpSourcePath, hostIp, userNo, userPwd))
            {
                return "Ftp故障，文件移动失败！";
            }
            MemoryStream ms = Common.MemeoryOperater.File2MemoryStream(filefullPath);
            msg = FtpAdd(ms, ftpSourcePath, hostIp, userNo, userPwd, viewModel);
            msg = msg == "success" ? msg : "文件移动：" + msg;
            File.Delete(filefullPath);
            return msg;
        }

        /// <summary>
        /// ftp文件下载操作
        /// </summary>
        /// <param name="destinyPath">ftp下载路径</param>
        /// <param name="currentPath">ftp相对路径</param>
        /// <param name="hostIp">主机IP</param>
        /// <param name="userNo">ftp用户名</param>
        /// <param name="userPwd">ftp密码</param>
        /// <param name="fileName">文件名</param>
        /// <returns>结果消息</returns>
        public string FtpDownload(string destinyPath, string currentPath, string hostIp, string userNo, string userPwd, string fileName) 
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return "文件名不能为空！";
            }
            string fileFullPath = destinyPath.EndsWith("\\") ? destinyPath + fileName : destinyPath + "\\" + fileName;
            if (!System.IO.File.Exists(fileFullPath))
            {
                 if (!Common.FTPStreamHelper.DownloadFile(destinyPath, currentPath, fileName, hostIp, userNo, userPwd))
            {
                return "Ftp故障，文件移动失败！";
            }
            }
            return "success";
        }



        /// <summary>
        /// ftp文件下载操作
        /// </summary>
        /// <param name="destinyPath">ftp下载路径</param>
        /// <param name="currentPath">ftp相对路径</param>
        /// <param name="hostIp">主机IP</param>
        /// <param name="userNo">ftp用户名</param>
        /// <param name="userPwd">ftp密码</param>
        /// <param name="viewModel">文件类型</param>
        /// <returns>结果消息</returns>
        public string FtpDownload(string destinyPath, string currentPath, string hostIp, string userNo, string userPwd, ModelView.DmsFileView viewModel)
        {
            if (viewModel == null)
            {
                return "操作对象不能为空！";
            }
            string fileOperateName = viewModel.file_md5 + "_" + System.IO.Path.GetFileNameWithoutExtension(viewModel.file_info) + System.IO.Path.GetExtension(viewModel.file_info);
            string fileFullPath = destinyPath.EndsWith("\\") ? destinyPath + fileOperateName : destinyPath + "\\" + fileOperateName;
            System.IO.File.Delete(fileFullPath);
            if (!Common.FTPStreamHelper.DownloadFile(destinyPath, currentPath, fileOperateName, hostIp, userNo, userPwd))
            {
                return "Ftp故障，文件移动失败！";
            }
            string fileNameNew = System.IO.Path.GetFileNameWithoutExtension(viewModel.file_info) + System.IO.Path.GetExtension(viewModel.file_info);
            string fileFullPathNew = destinyPath.EndsWith("\\") ? destinyPath + fileNameNew : destinyPath + "\\" + fileNameNew;
            System.IO.File.Copy(fileFullPath, fileFullPathNew, true);
            System.IO.File.Delete(fileFullPath);
            return "success";
        }
    }
}
