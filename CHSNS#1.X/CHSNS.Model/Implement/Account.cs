namespace CHSNS.Model
{
    public class Account:IAccount
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public long? Code { get; set; }
    }
}