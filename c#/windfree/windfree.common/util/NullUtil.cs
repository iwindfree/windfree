using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace windfree.common.windfree.util
{
    class NullUtil
    {
        public static object IsDBNull(object o, object def)
        {
            return Convert.IsDBNull(o) ? def : o;
        }
    }
}
