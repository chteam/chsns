﻿using System;
using System.Security.Principal;

namespace CHSNS
{
    public class CHPrincipal : IPrincipal
    {

        public CHIdentity CHIdentity
        {
            get
            {
                return Identity as CHIdentity;
            }
        }
        public CHPrincipal()
        {

        }
        public IIdentity Identity { get; set; }
        public bool IsInRole(string role)
        {
            role = role.ToLower();
            return CHIdentity.Roles.Exists(c => c == role);
        }
    }
}