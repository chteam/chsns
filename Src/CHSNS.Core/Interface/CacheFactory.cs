using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS
{
    public class CacheFactory
    {
        public static ICache Instance { get;private set; }
        public static void Register(ICache cache) {
            Instance = cache;
        }
    }
}
