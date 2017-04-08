namespace CHSNS
{
    using System.Security.Principal;

    public class WebPrincipal : IPrincipal
    {
        public WebIdentity WebIdentity { get { return Identity as WebIdentity; } }

        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            role = role.ToLower();
            return WebIdentity.Roles.Exists(c => c.ToLower() == role);
        }
    }
}
