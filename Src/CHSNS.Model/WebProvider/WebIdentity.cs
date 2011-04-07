using System.Security.Principal;
using System.Collections.Generic;

namespace CHSNS
{
    public class WebIdentity : IIdentity,IUser
    {
        public string AuthenticationType { get { return "WebIdentity"; } }
        public bool IsAuthenticated { get { return true; } }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public long UserId { get; set; }
        public byte Status { get; set; }
    }
}
