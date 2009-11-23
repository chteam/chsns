namespace CHSNS.Model
{
    public interface IAccount
    {
        long UserId { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        long? Code { get; set; }
    }
}