using System;

namespace Common
{
    /// <summary>
    /// web.config操作类
    /// </summary>
    public sealed class ConfigHelper
    {
        /// <summary>
        /// 获取程序配置文件中对应配置节的值
        /// </summary>
        /// <param name="appKey">配置节的Key值</param>
        /// <returns>返回Key对应的值</returns>
        //public static string GetConfigValueFromXml(string SecondNode, string appKey, string fullPath)
        //{
        //    System.Xml.XmlDocument document = new System.Xml.XmlDocument();
        //    try
        //    {
        //        document.Load(fullPath);
        //        System.Xml.XmlElement element = (System.Xml.XmlElement)document.SelectSingleNode("//appSettings").SelectSingleNode(string.Format("//{0}", SecondNode)).SelectSingleNode("//add[@key='" + appKey + "']");
        //        if (element != null)
        //        {
        //            return element.GetAttribute("value");
        //        }
        //        return "";
        //    }
        //    catch
        //    {
        //        throw new Exception("该文件目录下不存在配置字节");
        //    }
        //}

        /// <summary>
        /// 获取程序配置文件中对应配置节的值
        /// </summary>
        /// <param name="SecondNode">二级配置节</param>
        /// <param name="appKey">叶子配置节</param>
        /// <param name="fullPath">配置文件所在的全路径</param>
        /// <param name="useCache">是否启用缓存，默认启用</param>
        /// <returns>返回配置的字符串</returns>
        public static string GetConfigValueFromXml(string SecondNode, string appKey, string fullPath,bool useCache=true)
        {
            string res = string.Empty;
            if (useCache)
            {
                string key = SecondNode + "-" + appKey;
                object objModel = DataCache.GetCache(key);
                if (objModel == null)
                {
                    System.Xml.XmlDocument document = new System.Xml.XmlDocument();
                    try
                    {
                        document.Load(fullPath);
                        System.Xml.XmlElement element = (System.Xml.XmlElement)document.SelectSingleNode("//appSettings").SelectSingleNode(string.Format("//{0}", SecondNode)).SelectSingleNode("//add[@key='" + appKey + "']");
                        if (element != null)
                        {
                            string tmp = element.GetAttribute("value");
                            if (string.IsNullOrEmpty(tmp))
                            {
                                res = "UNKNOWN";
                            }
                            else
                            {
                                res = tmp;
                            }
                            objModel = res;
                        }
                        else
                        {
                            res = "UNKNOWN";
                        }
                        DataCache.SetCache(key, objModel, DateTime.Now.AddMinutes(180), TimeSpan.Zero);
                    }
                    catch
                    {
                        throw new Exception("该文件目录下不存在配置节");
                    }
                }
                else
                {
                    res = objModel.ToString();
                }
            }
            else
            {
                System.Xml.XmlDocument document = new System.Xml.XmlDocument();
                try
                {
                    document.Load(fullPath);
                    System.Xml.XmlElement element = (System.Xml.XmlElement)document.SelectSingleNode("//appSettings").SelectSingleNode(string.Format("//{0}", SecondNode)).SelectSingleNode("//add[@key='" + appKey + "']");
                    if (element != null)
                    {
                        string tmp = element.GetAttribute("value");
                        if (string.IsNullOrEmpty(tmp))
                        {
                            res = "UNKNOWN";
                        }
                        else
                        {
                            res = tmp;
                        }
                    }
                    else
                    {
                        res = "UNKNOWN";
                    }
                }
                catch
                {
                    throw new Exception("该文件目录下不存在配置节");
                }
            }
            return res;
        }
    }
}