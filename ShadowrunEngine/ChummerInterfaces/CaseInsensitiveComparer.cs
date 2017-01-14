using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowrunEngine.ChummerInterfaces
{
    public enum enSortOrder
    {
        None,
        Ascending,
        Descending
    }

    class CaseInsensitiveComparer
    {
        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }

        public int Compare(string x, string y)
        {
            return x.ToLower().CompareTo(y.ToLower());
        }
    }
}
