using Memcached.ClientLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuFinanced.Common.MemcacheHelper
{
    public static class MemcacheHelper
    {
        private static MemcachedClient mc;

        static MemcacheHelper()
        {
            String[] serverlist = { "192.168.0.17:11200", "192.168.0.18:11200" };
            //String[] serverlist = { "106.3.45.241:11200" };
            SockIOPool pool = SockIOPool.GetInstance("test");
            pool.SetServers(serverlist);
            pool.Initialize();
            mc = new MemcachedClient();
            mc.PoolName = "test";
            mc.EnableCompression = false;

        }

        public static bool Set(string key, object value, DateTime expiry)
        {
            return mc.Set(key, value, expiry);
        }
        public static bool Set(string key, object value, TimeSpan Interval)
        {
            return mc.Set(key, value, DateTime.Now.Add(Interval));
        }

        public static object Get(string key)
        {
            return mc.Get(key);
        }

        public static bool Delete(string key)
        {
            return mc.Delete(key);
        }
    }
}
