using System;
namespace CHSNS
{
    public interface IOnline
    {
  
        System.Collections.Generic.Dictionary<long, DateTime> Items { get; }
        void Update();
        bool IsOnline(long userid);
    }
}