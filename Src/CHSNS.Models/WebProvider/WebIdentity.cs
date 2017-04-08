namespace CHSNS
{
    using System.Collections.Generic;
    using System.Security.Principal;

    public class WebIdentity : IIdentity, IUser
    {
        #region IIdentity Members

        public string AuthenticationType
        {
            get { return "WebIdentity"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Name { get; set; }

        #endregion

        #region IUser Members

        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public long UserId { get; set; }
        public byte Status { get; set; }

        #endregion
    }
}