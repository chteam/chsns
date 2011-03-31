namespace CHSNS.Interface
{
    using System;

    public interface IOnline
    {
  
        System.Collections.Generic.Dictionary<long, DateTime> Items { get; }
        void Update();
        bool IsOnline(long userid);
    }
}