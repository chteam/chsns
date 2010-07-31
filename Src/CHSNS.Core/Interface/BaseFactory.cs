using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS
{
    public class BaseFactory<T>
    {
        public static T Instance { get; private set; }
        public static void Register(T cache)
        {
            Instance = cache;
        }
    }
}
