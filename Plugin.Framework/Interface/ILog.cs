using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Framework.Entity;

namespace Plugin.Framework.Interface
{
    public interface ILog
    {
        void Notify(Logger logger);
    }
}
