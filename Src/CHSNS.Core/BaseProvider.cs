﻿namespace CHSNS
{
    public class BaseProvider<T>
    {
        public static T Instance { get; private set; }
        public static void Register(T cache)
        {
            Instance = cache;
        }
    }
}
