using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Framework.Entity;

namespace Plugin.Framework.Utils
{
    public abstract class ConfigBase
    {
        private List<Config> _configs;
        CfgManager _cfgManager;
        /// <summary>
        /// 获取所有配置节点信息
        /// </summary>
        /// <returns></returns>
        public List<Config> GetAllConfigs()
        {
            if (null == _configs)
            {
                string fileName = AppDomain.CurrentDomain.BaseDirectory.ToString() + DllName;
                _cfgManager = new CfgManager(fileName);
            }
            if (_configs == null)
            {
                _configs = _cfgManager.GetAllAppSettings();
            }
            return _configs;
        }

        public string DllName
        {
            get;
            protected set;
        }

        protected abstract void DoSetDllName();

        /// <summary>
        /// 获取指定KEY的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetAppSettingValue(string key) {
            return _cfgManager.GetValue(key);
        }


        public ConfigBase() {
            DoSetDllName();
        }
    }
}
