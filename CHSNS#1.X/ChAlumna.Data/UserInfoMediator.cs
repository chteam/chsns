using System.Data;
using System.Linq;
using CHSNS.Models;
using CHSNS;
namespace CHSNS.Data {
	public class UserInfoMediator : BaseMediator {
		public UserInfoMediator(DBExt id) : base(id) { }
		#region BasicInfo
		public BasicInformation GetBaseInfo(long UserID) {
			return DBExt.DB.BasicInformation.Where(c => c.UserID == UserID).FirstOrDefault();
		}
		public void SaveBaseInfo(BasicInformation bi)
		{
			DataBaseExecutor.Execute(
				@"UPDATE [BasicInformation]
   SET [Name] = @Name
      ,[Sex] = @Sex
      ,[Birthday] = @Birthday
      ,[ProvinceID] = @ProvinceID
      ,[CityID] = @CityID
      ,[ShowLevel] = @ShowLevel
 WHERE UserID=@UserID"
				, "@Name", bi.Name
				, "@Sex", bi.Sex
				, "@Birthday", bi.Birthday
				, "@ProvinceID", bi.ProvinceID
				, "@CityID", bi.CityID
				, "@ShowLevel", bi.ShowLevel
				, "@UserID", bi.UserID);
		}
		#endregion
		public DataRowCollection GetSchoolInfo(long UserID) {
			return DataBaseExecutor.GetRows("MySchoolSelect", "@userid", UserID);
		}
		public DataRowCollection GetContactInfo(long UserID) {
			return DataBaseExecutor.GetRows("MyContactSelect", "@userid", UserID);
		}
		public DataRowCollection GetPersonalInfo(long UserID) {
			return DataBaseExecutor.GetRows("MyPersonalSelect", "@userid", UserID);
		}
		#region Magicbox
		public string GetMagicBox(long UserID) {
			var magicbox = (from p in DBExt.DB.Profile
			                where p.UserId == UserID
			                select p.MagicBox).Single();
			return magicbox;
		}
		public void SaveMagicBox(string magicbox,long UserID)
		{
			DataBaseExecutor.Execute(@"Update [profile]
set Magicbox=@magicbox where UserID=@UserID"
			                         , "@magicbox", magicbox
			                         , "@UserID", UserID);
		}
		public void MagicBoxBackup()
		{
		}



		#endregion

		public void DeleteFace(long userid) {
			System.IO.Directory.Delete(Path.FaceMapPath(userid), true);
		}

		public byte Relation(long ownerid,long viewerid)
		{
			return 200;
		}
	}
}
