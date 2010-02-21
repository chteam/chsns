using CHSNS.Model;
using CHSNS.Operator;

namespace CHSNS.Service
{
    public class ViewService {
                static readonly ViewService _instance = new ViewService();
                private readonly IViewOperator View;
        public ViewService() {
                    View = new ViewOperator();
        }

        public static ViewService GetInstance() {
            return _instance;
        }
        public ViewListPas ViewList(byte type, int everyrow, long ownerid, int count)
        {
            return View.ViewList(type, everyrow, ownerid, count);
        }

        public void Update(byte type, long ownerid,IUser user)
        {
            View.Update(type, ownerid, user.UserId);
        }
    }
}
