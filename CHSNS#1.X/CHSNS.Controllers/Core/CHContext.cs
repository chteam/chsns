using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CHSNS.Config;

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

        public IUser User
        {
            get
            {
                return new CHUser();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public ICookies Cookies
        {
            get
            {
                return new CHCookies(this);
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public CHSNS.Config.SiteConfig Site
        {
            get
            {
                return (new SiteConfig(new ConfigSerializer(this))).Current;
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        public IOnline Online
        {
            get
            {
                return new Online(this);
            }
            set
            {
                throw new NotImplementedException();
            }
        }

    }
}
