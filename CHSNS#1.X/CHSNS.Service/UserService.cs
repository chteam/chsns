using System.Data;
using System.Linq;
using CHSNS.Models;
using System;
using CHSNS.Model;
using CHSNS.Models.Abstractions;
using CHSNS.Operator;

namespace CHSNS.Service {
	public class UserService{
                static readonly UserService _instance = new UserService();
                private readonly IUserOperator User;
                private readonly IEventOperator Event;
        public UserService() {
                    User = new UserOperator();
            Event = new EventOperator();
        }

        public static UserService GetInstance(){
            return _instance;
        }

	    public UserPas UserInformation(long userid) {
	        return User.UserInformation(userid);
		}

		public int Relation(long OwnerID, long ViewerID) {
		    return User.Relation(OwnerID, ViewerID);
		}

		#region BasicInfo
		public IBasicInformation GetBaseInfo(long UserID) {
		    return User.GetBaseInfo(UserID);
		}
        public void SaveBaseInfo(IBasicInformation b,IContext context)
        {
            if (b.UserID == 0) b.UserID = context.User.UserID;
            User.SaveBaseInfo(b);
        }

	    #endregion

		#region Magicbox
		public string GetMagicBox(long UserID) {
		    return User.GetMagicBox(UserID);
		}
		public void SaveMagicBox(string magicbox, long uid) {
		    User.SaveMagicBox(magicbox, uid);
		}
		public void MagicBoxBackup() {
		    User.MagicBoxBackup();
		}



		#endregion
		#region face
		public void DeleteFace(long userid) {
			System.IO.Directory.Delete(Path.FaceMapPath(userid), true);
		}
		#endregion

		public IProfile GetUser(long userid) {
			return GetUser(userid, c => new ProfileImplement {
				Name = c.Name
			});
		}

        public T GetUser<T>(long userid, System.Linq.Expressions.Expression<Func<IProfile, T>> x) {
		    return User.GetUser(userid, x);
		}
		#region profile
        public void SaveText(long uid, string text,IContext context)
        {
            User.SaveText(uid, text);
            Event.Add(new EventImplement
                                {
                                    OwnerID = context.User.UserID,
                                    TemplateName = "ProText",
                                    AddTime = DateTime.Now,
                                    ShowLevel = 0,
                                    Json = Dictionary.CreateFromArgs("name", context.User.Username,
                                                                     "text", text).ToJsonString()
                                });
        }

	    #endregion


		public string GetUserName(long uid) {
		    return User.GetUserName(uid);
		}
	}
}
