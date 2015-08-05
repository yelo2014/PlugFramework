using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Framework.Entity;
using System.Reflection;

namespace Plugin.Framework.Instance
{
    public class InstanceLoader<T>
    {
        static object lck4Instance = new object();
        static InstanceLoader<T> _Instance;
        public static InstanceLoader<T> GetInstance()
        {
            lock (lck4Instance)
            {
                if (null == _Instance)
                    _Instance = new InstanceLoader<T>();
                return _Instance;
            }
        }

        Dictionary<string, T> _dicInstance = new Dictionary<string, T>();

        public T GeneralTargetInstance(Config cfg)
        {
            Assembly assembly = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory.ToString() + cfg.Dll);
            T instance = (T)assembly.CreateInstance(cfg.Class);
            if (null != instance)
            {
                _dicInstance[cfg.Key] = instance;
            }
            return instance;
        }

        public T GetTargetInstance(string key) { 
            if(_dicInstance.ContainsKey(key)){
                return _dicInstance[key];
            }
            return default(T);
        }
    }
}
