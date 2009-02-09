using System;
namespace CHSNS
{
    public interface IOnline
    {
        IContext Context { get; set; }
        System.Collections.Generic.Dictionary<long, DateTime> Items { get; }
        void Update();
        bool IsOnline(long userid);
    }
}