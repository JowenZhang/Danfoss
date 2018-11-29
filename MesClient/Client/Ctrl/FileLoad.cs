using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Client.Ctrl
{
    public class FileLoad
    {
        private string _host = string.Empty;
        private string _readUser = string.Empty;
        private string _readPwd = string.Empty;
        private string _writeUser = string.Empty;
        private string _writePwd = string.Empty;
        private string _localDirectory = string.Empty;
        public FileLoad() 
        {
            _host=Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "host", @"Config\mesClientConfig.xml");
            _readUser = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "readPwd", @"Config\mesClientConfig.xml");
            _writeUser = Common.ConfigHelper.GetConfigValueFromXml("ftpSet","writeUser",@"Config\mesClientConfig.xml");
            _readPwd = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "readPwd", @"Config\mesClientConfig.xml");
            _writePwd = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "writePwd", @"Config\mesClientConfig.xml");
            _localDirectory = Common.ConfigHelper.GetConfigValueFromXml("generalSet", "fileDirectory", @"Config\mesClientConfig.xml");
        }

        public void FileShow(string fileName, string fileNo)
        {
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(fileNo))
            {
                return;
            }
            string path = _localDirectory + @"\current\" + fileName;
            Ctrl.DbConStrFactory conFactory = Ctrl.DbConStrFactory.CreateInstance();
            Ctrl.DataLoadCtrl dataLoadCtrl = DataLoadCtrl.CreateInstance(conFactory.GetSqlConStr("defaultSqlDb"), conFactory.GetAccessConStr("defaultAccessDb"));
            Model.TableModel.Dms_file model = dataLoadCtrl.GetDmsFile(fileNo);
            if (model == null)
            {
                return;
            }
            if (!System.IO.File.Exists(path))
            {
                string ftpFileName = model.file_md5 + "_" + fileName;
                string newPath = _localDirectory + @"\current\" + ftpFileName;
                if (!System.IO.File.Exists(newPath))
                {
                    Common.FTPStreamHelper.DownloadFile(_localDirectory + @"\current", "current", ftpFileName, _host, _writeUser, _writePwd);
                }
                System.IO.File.Copy(newPath, path, true);
                System.IO.File.Delete(newPath);
            }            
            Process proc = new Process();
            proc.StartInfo.FileName = _localDirectory + @"\current\" + fileName;
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }
    }
}
