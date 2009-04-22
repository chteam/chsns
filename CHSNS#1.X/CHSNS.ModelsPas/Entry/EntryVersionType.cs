using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS
{
    public enum EntryVersionType
    {   
        /// <summary>
        /// 待审
        /// </summary>
        Wait = 0,
        /// <summary>
        /// 一般    
        /// </summary>
        Common = 1,
        /// <summary>
        /// 锁定
        /// </summary>
        Lock = 2
    }
}
