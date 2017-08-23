using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace windfree.common.windfree.configure
{
    class Configure
    {
        
        static Configure instance;
        static object obj = new object();
        private ConcurrentDictionary<string, string> confDictionary;
        // private File configFile; 

        private Configure()
        {
            confDictionary = new ConcurrentDictionary<string, string>();
            readConfig();
        }
        public static Configure getInstance()
        {
            if (instance == null)
            {
                lock (obj)
                {
                    if (instance == null)
                    {
                        instance = new Configure();
                    }
                }
            }
            return instance;
        }

        public string getConfigValue(string key)
        {
            try
            {
                if (confDictionary.ContainsKey(key))
                {
                    return confDictionary[key];
                }
                else
                {
                    return "none";
                }
            }
            catch (Exception e)
            {

                return "none";
            }
        }

        private void readConfig()
        {
            ///todo: read config file
            confDictionary["server"] = "6EF7\\WINDFREE";
            confDictionary["database"] = "ssi_dev";
            confDictionary["userid"] = "sa";
            confDictionary["password"] = "tlawkd";
        }

    }
    



}
