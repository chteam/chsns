namespace CHSNS.Model
{
    public interface IFriend
    {
        long Id { get; set; }
        long FromId { get; set; }
        long ToId { get; set; }
        bool IsTrue { get; set; }
        bool IsCommon { get; set; }
        int FriendType { get; set; }


    }
}