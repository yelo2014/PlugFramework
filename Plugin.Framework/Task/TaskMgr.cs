using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Framework.Interface;
using System.Threading;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Plugin.Framework.Task
{
    public class TaskMgr : ITaskMgr
    {
        List<Thread> _runningThreads = new List<Thread>();
        List<Thread> _readyThreads = new List<Thread>();
        const int MAX_RUNNING_COUNT = 120;

        static object lck4Instance = new object();
        object lck4RunningThreads = new object();
        object lck4ReadyThreads = new object();

        Thread _thread4StartThreadRead;

        public bool IsRunning { get; private set; }

        static ITaskMgr _Instance;
        private TaskMgr() { }


        public static ITaskMgr GetInstance()
        {
            lock (lck4Instance)
            {
                if (null == _Instance)
                {
                    _Instance = new TaskMgr();
                    _Instance.Initlize();
                }
                return _Instance;
            }
        }

        public void Initlize()
        {
            lock (lck4RunningThreads)
                _runningThreads.Clear();
            lock (lck4ReadyThreads)
                _readyThreads.Clear();
            _thread4StartThreadRead = new Thread(() => StartThreadRead());
            ThreadPool.QueueUserWorkItem((state) => {
                while (true) {
                    lock (lck4RunningThreads)
                    {
                        for (int i = _runningThreads.Count - 1; i >= 0; i--)
                        {
                            if (ThreadState.Stopped == _runningThreads[i].ThreadState)
                            {
                                _runningThreads.RemoveAt(i);
                                GC.Collect();
                                Console.WriteLine("==============");
                            }
                        }
                    }
                    Thread.Sleep(100);
                }
            });
        }

        void StartThreadRead()
        {
            while (true)
            {
                do
                {
                    lock (lck4RunningThreads)
                    {
                        if (_runningThreads.Count < MAX_RUNNING_COUNT)
                        {
                            if (_readyThreads.Count <= 0)
                                continue;
                            lock (lck4ReadyThreads)
                            {
                                var thread = _readyThreads[0];
                                _runningThreads.Add(thread);
                                _readyThreads.RemoveAt(0);
                                thread.Start();
                                Console.WriteLine("线程运行队列线程任务+1");
                            }
                        }
                        else {
                            //Console.WriteLine("线程运行队列线程任务已满");
                        }
                    }
                }
                while (_readyThreads.Count > 0);
                Thread.Sleep(100);
            }
        }

        public void Start()
        {
            if (!IsRunning)
            {
                IsRunning = !IsRunning;
                _thread4StartThreadRead.Start();
            }
        }

        public void Stop()
        {
            if (IsRunning)
            {
                IsRunning = !IsRunning;
                _thread4StartThreadRead.Abort();
                //todo:终止所有线程
                try
                {
                    Parallel.ForEach(_runningThreads, (thread) =>
                    {
                        thread.Abort();
                    });
                }
                catch { }
            }
        }

        public void AddWork(DelegateWork work, OnWorkCompltedCallBack onWorkCompltedCallBack)
        {
            Thread thread = new Thread(() => { work(onWorkCompltedCallBack); });
            lock (lck4ReadyThreads)
            {
                _readyThreads.Add(thread);
            }
        }



    }
}
