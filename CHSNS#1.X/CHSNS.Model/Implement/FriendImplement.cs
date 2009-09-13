namespace CHSNS.Model
{
    public class FriendImplement:IFriend
    {
        public long Id { get; set; }
        public long FromId { get; set; }
        public long ToId { get; set; }
        public bool IsTrue { get; set; }
        public bool IsCommon { get; set; }
        public int FriendType { get; set; }
    }
}