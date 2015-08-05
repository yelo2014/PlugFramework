using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin.Framework.Entity
{
    public class Logger
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public EnumLoggerType LoggerType { get; private set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// 消息
        /// </summary>
        /// <param name="loggerType">消息类型</param>
        /// <param name="content">消息内容</param>
        public Logger(EnumLoggerType loggerType, string content)
        {
            this.LoggerType = loggerType;
            Content = content;
        }
    }
}
