using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CHSNS.Models
{
    [Flags]
    public enum ShowLevel
    {
        [Description("公开(任何人都可以看贴和发贴)")]
        Public = 0,
        [Description("半公开(任何人可以看贴，成员可以发贴)")]
        Protected = 4,
        [Description("私有(只有成员才能看贴，发贴)")]
        Private = 8,
    }
}
