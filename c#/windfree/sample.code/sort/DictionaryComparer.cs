using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample.sort
{
    class DictionaryComparer : IComparer<KeyValuePair<int, string>>
    {
        public int Compare(KeyValuePair<int, string> x, KeyValuePair<int, string> y)
        {
            if(x.Value.CompareTo(y.Value) == 0)
            {
                return (x.Key.CompareTo(y.Key));
            } else
            {
                return x.Value.CompareTo(y.Value);
            }
        }
    }



}



