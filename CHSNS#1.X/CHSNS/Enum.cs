using System;

namespace Chsword {

	public enum PageType { 
		//����ΪȺ�༭����
		Setting,
		Member,
		Photo,
		Disallow,
		//����Ϊ�û��༭����
		Basic,
		School,
		Contact,
		Personal,
		MagicBox,
		UpLoad,
		//,�����ڲ�����
		Membermaster,
		Memberlist,
		//����ΪȺ��������
		Deletemember
		,//����Ϊվ��С������
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
		JoinClass//����༶�����⴦��
		,ApplyMaster//����������Ա
	   , AllowMember,DisallowMember,AllowMaster, DisallowMaster
		//�Թ���Ա�Ĳ���
		,TurnCreater
		,TurnMember
	}
}
