using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin.Framework.Entity
{
    public class Config
    {
        public string Key { get; private set; }
        public string Class { get; private set; }
        public string Dll { get; private set; }

        public Config(string key,string _class,string dll){
            this.Key = key;
            this.Class = _class;
            this.Dll = dll;
        }
    }
}
