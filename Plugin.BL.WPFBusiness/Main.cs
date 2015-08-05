using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Framework.Interface;
using System.Threading;
using Plugin.Framework.Utils;
using Plugin.Framework.Entity;
using Plugin.Framework.Task;

namespace Plugin.BL.WPFBusiness
{
    class Main : IInstance
    {
        public void Destory()
        {
            throw new NotImplementedException();
        }

        public void Initlize()
        {
            //throw new NotImplementedException();
        }

        public void Run()
        {
            //new Thread(() =>
            //{
            //    Random rnd = new Random();
            //    do
            //    {
            //        LoggerMgr.GetInstance().Notify(new Logger(EnumLoggerType.Normal, rnd.Next(10, 99).ToString()));
            //        Thread.Sleep(500);
            //    }
            //    while (true);
            //}).Start();
            //ITaskMgr taskMgr = TaskMgr.GetInstance();
            //taskMgr.Start();
            ////taskMgr.AddWork(Work, OnWorkCompltedCallBack);
            int i = 0;
            int j = 500;
            new Thread(() =>
            {
                ITaskMgr taskMgr = TaskMgr.GetInstance();
                taskMgr.Start();
                while (i<j)
                {
                    taskMgr.AddWork(Work, OnWorkCompltedCallBack);
                    Thread.Sleep(10);
                    i++;
                }
                taskMgr.Stop();
            }).Start();
        }

        int count = 0;
        public void OnWorkCompltedCallBack(object returnValue)
        {
           // Console.WriteLine("Completed:{0}", returnValue);
            LoggerMgr.GetInstance().Notify(new Logger(EnumLoggerType.Normal, string.Format("线程:{0}  已完成",++count)));
        }

        public void Work(OnWorkCompltedCallBack workCompeltedCallBack)
        {
            int i = 0;
            int j = 50;
            int result = 0;
            do
            {
                result += ++i;
                Thread.Sleep(10);
            } while (i < j);
            if (null != workCompeltedCallBack)
            {
                workCompeltedCallBack(result);
                
            }
        }
    }
}
