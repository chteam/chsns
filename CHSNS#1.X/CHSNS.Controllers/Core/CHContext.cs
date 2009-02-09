using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS
{
    public class CHContext : IContext
    {

        public ICache Cache
        {
            get
            {
                return new CHCache();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
