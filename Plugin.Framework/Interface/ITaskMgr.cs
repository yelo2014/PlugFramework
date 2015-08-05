using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin.Framework.Interface
{
    public delegate void OnWorkCompltedCallBack(object returnValue);
    public delegate void DelegateWork(OnWorkCompltedCallBack workCompeltedCallBack);
    /// <summary>
    /// 线程任务管理器
    /// </summary>
    public interface ITaskMgr
    {
        /// <summary>
        /// 初始化
        /// </summary>
        void Initlize();
        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="work">任务委托</param>
        /// <param name="onWorkCompltedCallBack">完成任务委托</param>
        void AddWork(DelegateWork work, OnWorkCompltedCallBack onWorkCompltedCallBack);

        /// <summary>
        /// 开始任务
        /// </summary>
        void Start();

        /// <summary>
        /// 终止任务
        /// </summary>
        void Stop();
    }
}
