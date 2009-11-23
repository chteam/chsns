using System;

namespace Chsword {

	public enum PageType { 
		//以下为群编辑功能
		Setting,
		Member,
		Photo,
		Disallow,
		//以下为用户编辑功能
		Basic,
		School,
		Contact,
		Personal,
		MagicBox,
		UpLoad,
		//,附加内部功能
		Membermaster,
		Memberlist,
		//以下为群操作功能
		Deletemember
		,//以下为站内小条操作
		Inbox,Sent,Read,Edit
	}
	public enum OptionType {
		Add,
		Delete,
		Push,
		Update
	}
	//public enum LogBookType{
	//UserLogBook,
	//GroupLogBook
	//}
	public enum GroupUserType {
		Join,
		Leave,
		Takein,
		Takeout,
		JoinClass//加入班级的特殊处理
		,ApplyMaster//申请做管理员
	   , AllowMember,DisallowMember,AllowMaster, DisallowMaster
		//对管理员的操作
		,TurnCreater
		,TurnMember
	}
}
