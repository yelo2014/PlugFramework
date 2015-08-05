using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Framework.Interface;
using Plugin.PlatForm.Entity;
using Plugin.Framework.Utils;
using System.Reflection;
using Plugin.Framework.Instance;

namespace Plugin.PlatForm.Core
{
    /// <summary>
    /// 实例管理器
    /// </summary>
    internal class InstanceMgr
    {
        //实例容器
        List<InstanceEntity> _dicInstances;
        ConfigBase _InstanceConfig = new InstanceConfig();
        internal InstanceMgr()
        {
        }

        /// <summary>
        /// 初始化实例
        /// </summary>
        internal void InitInstance()
        {
            if (null == _dicInstances)
            {
                _dicInstances = new List<InstanceEntity>();

                var configs = _InstanceConfig.GetAllConfigs();
                for (int i = 0; i < configs.Count; i++)
                {
                    var instance = InstanceLoader<IInstance>.GetInstance().GeneralTargetInstance((configs[i]));
                    _dicInstances.Add(new InstanceEntity(configs[i].Key, instance));
                }
            }
        }

        /// <summary>
        /// 移除实例
        /// </summary>
        /// <param name="key">实例key，唯一标识</param>
        /// <returns>操作结果</returns>
        internal bool RemoveInstance(string key)
        {
            var instance = _dicInstances.FirstOrDefault(p => p.Key == key);
            if (null == instance)
            {
                return false;
            }
            instance.Instance.Destory();
            _dicInstances.Remove(instance);
            GC.WaitForPendingFinalizers();
            GC.Collect();
            return true;
        }

        /// <summary>
        /// 加载所有实例
        /// </summary>
        internal void RunInstance()
        {
            for (int i = 0; i < _dicInstances.Count; i++)
            {
                if (!_dicInstances[i].IsRunning)
                {
                    _dicInstances[i].Instance.Run();
                    _dicInstances[i].IsRunning = true;
                }
            }
        }

        /// <summary>
        /// 卸载所有实例
        /// </summary>
        internal void DesctoryInstance() {
            for (int i = _dicInstances.Count-1; i >=0; i++)
            {
                if (_dicInstances[i].IsRunning)
                {
                    _dicInstances[i].Instance.Destory();
                    _dicInstances.RemoveAt(i);
                }
            }
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
