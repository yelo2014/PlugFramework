using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;
using Plugin.Framework.Entity;

namespace Plugin.Framework.Utils
{
    /// <summary>
    /// 配置文件管理器
    /// </summary>
    public class CfgManager
    {
        XDocument _docCfg;
        List<XElement> _instances;
        /// <summary>
        /// 配置文件管理器
        /// </summary>
        /// <param name="filePath">文件路径</param>
        public CfgManager(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("配置文件不存在！");
            }
            try
            {
                _docCfg = XDocument.Load(filePath);
                _instances = _docCfg.XPathSelectElements("//instance").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取指定节点值
        /// </summary>
        /// <param name="nodeName">节点名称</param>
        /// <returns></returns>
        public string GetValue(string nodeName)
        { 
            var node=_instances.FirstOrDefault(p=>nodeName==p.Attribute("key").Value);
            if (null != node) {
                return node.Attribute("value").Value;
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取所有节点
        /// </summary>
        /// <returns>所有节点</returns>
        public List<Config> GetAllAppSettings()
        {
            List<Config> configs = new List<Config>();
            string[,] appSettings = new string[_instances.Count,2];
            for (int i = 0; i < _instances.Count; i++) {
                configs.Add(new Config(_instances[i].Attribute("key").Value, _instances[i].Attribute("class").Value, _instances[i].Attribute("dll").Value));
            }
            return configs;
        }
    }
}
