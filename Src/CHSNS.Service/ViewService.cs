using CHSNS.Model;
using CHSNS.Operator;

namespace CHSNS.Service
{
    public class ViewService {
                static readonly ViewService Instance = new ViewService();
                private readonly ViewOperator _view;
        public ViewService() {
                    _view = new ViewOperator();
        }

        public static ViewService GetInstance() {
            return Instance;
        }
        public ViewListPas ViewList(byte type, int everyrow, long ownerid, int count)
        {
            return _view.ViewList(type, everyrow, ownerid, count);
        }

        public void Update(byte type, long ownerid,IUser user)
        {
            _view.Update(type, ownerid, user.UserId);
        }
    }
}
