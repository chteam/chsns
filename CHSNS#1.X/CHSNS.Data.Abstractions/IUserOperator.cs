using System;
using CHSNS.Models.Abstractions;

namespace CHSNS.Operator {
	public interface IUserOperator {
		void DeleteFace(long userid);
		IBasicInformation GetBaseInfo(long UserID);
		string GetMagicBox(long UserID);
		IProfile GetUser(long userid);
		T GetUser<T>(long userid, System.Linq.Expressions.Expression<Func<IProfile, T>> x);
		void MagicBoxBackup();
		int Relation(long OwnerID, long ViewerID);
		void SaveBaseInfo(IBasicInformation bi);
		void SaveMagicBox(string magicbox, long uid);
		void SaveText(long userid, string text);
		Model.UserPas UserInformation(long userid);
		string GetUserName(long uid);
	}
}
