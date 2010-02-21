using CHSNS.Model;
using CHSNS.Models;

namespace CHSNS.ViewModel
{
    public class FriendRequest
    {
        public Profile Profile { get; set; }
        public PagedList<UserItemPas> Items { get; set; }
    }
}