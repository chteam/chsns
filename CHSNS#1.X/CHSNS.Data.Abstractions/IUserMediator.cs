using System;
namespace CHSNS.Data {
	public interface IUserService {
		void DeleteFace(long userid);
		CHSNS.Models.BasicInformation GetBaseInfo(long UserID);
		System.Data.DataRowCollection GetContactInfo(long UserID);
		string GetMagicBox(long UserID);
		System.Data.DataRowCollection GetPersonalInfo(long UserID);
		System.Data.DataRowCollection GetSchoolInfo(long UserID);
		Models.Profile GetUser(long userid);
		T GetUser<T>(long userid, System.Linq.Expressions.Expression<Func<CHSNS.Models.Profile, T>> x);
		void MagicBoxBackup();
		int Relation(long OwnerID, long ViewerID);
		void SaveBaseInfo(CHSNS.Models.BasicInformation bi);
		void SaveMagicBox(string magicbox, long UserID);
		void SaveText(long userid, string text);
		CHSNS.ModelPas.UserPas UserInformation(long userid);
		string GetUserName(long uid);
	}
}
