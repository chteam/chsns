using System.Collections.Generic;
namespace CHSNS
{
    public interface IUser
    {
        //void Clear();
        //string Email { get; set; }
        //void InitStatus(object status);
        //bool IsAdmin { get; }
        //bool IsLogin { get; }
        //Role Status { get; }
        //long UserId { get; set; }
        //string NickName { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        List<string> Roles { get; }
        long UserId { get; set; }
        byte Status { get; set; }
    }
}
