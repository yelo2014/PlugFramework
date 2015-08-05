using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Framework.Interface;

namespace Plugin.PlatForm.Entity
{
    /// <summary>
    /// 实例对象
    /// </summary>
    internal class InstanceEntity
    {
        /// <summary>
        /// 实例唯一key
        /// </summary>
        public string Key { get; private set; }
        /// <summary>
        /// 实例对象
        /// </summary>
        public IInstance Instance { get; private set; }
        /// <summary>
        /// 实例是否正在运行
        /// </summary>
        public bool IsRunning { get; set; }

        /// <summary>
        /// 实例实体对象
        /// </summary>
        /// <param name="key">实例唯一key</param>
        /// <param name="instance">实例对象</param>
        internal InstanceEntity(string key, IInstance instance)
        {
            Key = key;
            Instance = instance;
            IsRunning = false;
        }
    }
}
