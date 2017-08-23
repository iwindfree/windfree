using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample.sort
{
    class DictionarySort
    {
        private Dictionary<int, string> dicValue;
        public DictionarySort()
        {

            init();
        }

        private void init()
        {
            dicValue = new Dictionary<int, string>();
            dicValue.Add(1, "test1");
            dicValue.Add(3, "testValue");
            dicValue.Add(2, "testValue");
            dicValue.Add(7, "my test value");
            dicValue.Add(4, "korea");
            dicValue.Add(6, "gmail.com");
        }

        public void Sort1()
        {
            var value = from v in dicValue
                        orderby v.Value, v.Key ascending
                        select v;

            foreach (KeyValuePair<int, string> pair in value)
            {
                Console.Out.WriteLine("key: {0},  value: {1}", pair.Key, pair.Value);
            }
        }

        public void Sort2()
        {
            List<KeyValuePair<int,string>> list = dicValue.ToList<KeyValuePair<int, string>>();
            list.Sort(new DictionaryComparer());
            foreach(KeyValuePair<int,string> v in list) {
                Console.WriteLine("key : {0}   value: {1}", v.Key, v.Value);
            }
        }
    }
}
