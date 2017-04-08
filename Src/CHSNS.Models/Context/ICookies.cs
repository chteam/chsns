using System;
namespace CHSNS
{
    public interface ICookies
    {
        IContext Context { get; set; }
        string Apps { get; set; }
        long[] AppsArray { get; }
        void Clear();
        DateTime Expires { set; }
        bool IsAutoLogin { get; set; }
        bool IsExists { get; }
        long UserID { get; set; }
        string UserPassword { get; set; }
    }
}
