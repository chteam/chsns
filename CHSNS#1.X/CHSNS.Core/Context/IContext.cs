using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS {
    public interface IContext {
        ICache Cache { get; set; }
    }
}
