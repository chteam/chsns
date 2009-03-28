using System;
namespace CHSNS.Service {
	public interface IUserService {
		void DeleteFace(long userid);
		Models.BasicInformation GetBaseInfo(long UserID);
		string GetMagicBox(long UserID);
		Models.Profile GetUser(long userid);
		T GetUser<T>(long userid, System.Linq.Expressions.Expression<Func<Models.Profile, T>> x);
		void MagicBoxBackup();
		int Relation(long OwnerID, long ViewerID);
		void SaveBaseInfo(Models.BasicInformation bi);
		void SaveMagicBox(string magicbox, long uid);
		void SaveText(long userid, string text);
		Model.UserPas UserInformation(long userid);
		string GetUserName(long uid);
	}
}
