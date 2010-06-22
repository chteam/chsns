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
        long UserId { get; set; }
        string NickName { get; set; }
    }
}
