
namespace CHSNS.Models
{
    using System.ComponentModel;

    public enum WikiStatus
    {
        [Description("待审核")]
        Wait = 0,

        [Description("一般")]
        Common = 1,
        
        [Description("锁定")]
        Lock = 2
    }
}
