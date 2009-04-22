﻿using System;
namespace CHSNS
{
    public interface IUser
    {
        void Clear();
        string Email { get; set; }
        void InitStatus(object status);
        bool IsAdmin { get; }
        bool IsLogin { get; }
        Role Status { get; }
        long UserID { get; set; }
        string Username { get; set; }
    }
}