using CHSNS.Model;

namespace CHSNS.ViewModel
{
    public class FriendRequest
    {
        public IProfile Profile { get; set; }
        public PagedList<UserItemPas> Items { get; set; }
    }
}