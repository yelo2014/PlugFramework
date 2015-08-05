using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Framework.Interface;
using Plugin.Framework.Entity;

namespace Plugin.Framework.Utils
{
    public class LoggerMgr
    {
        List<ILog> _logs = new List<ILog>();

        private LoggerMgr() { }

        private static LoggerMgr _Instance;

        private readonly static object lck4Instance = new object();

        public static LoggerMgr GetInstance() {
            lock (lck4Instance) {
                if (null == _Instance) {
                    _Instance = new LoggerMgr();
                }
                return _Instance;
            }
        }

        /// <summary>
        /// 注册监听接口
        /// </summary>
        /// <param name="log"></param>
        public void Regist(ILog log)
        {
            if (!_logs.Contains(log))
                _logs.Add(log);
        }

        /// <summary>
        /// 反注册监听接口
        /// </summary>
        /// <param name="log"></param>
        public void ReRegist(ILog log)
        {
            if (_logs.Contains(log))
            {
                _logs.Remove(log);
            }
        }

        /// <summary>
        /// 通知
        /// </summary>
        /// <param name="logger">消息内容</param>
        public void Notify(Logger logger)
        {
            foreach (var log in _logs)
            {
                log.Notify(logger);
            }
        }
    }
}
