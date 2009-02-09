using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS
{
    public static class CH
    {
        public static IContext Context { get { return new CHContext(); } }
    }
}
