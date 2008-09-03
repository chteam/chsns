/*
 * Created by 邹健
 * Date: 2007-12-3
 * Time: 11:45
 * 
 * 
 */

using System;
using System.Web.Services;
using System.ComponentModel;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Services;
using System.Web.UI;
using Chsword.Datamodel;
using Chsword.Execute;
using Chsword.Interface;
using Chsword.Reader;
using CHSNS;
using Chsword;
using CHSNS.Data;
using CHSNS.Models;
	/// <summary>
	/// Description of PageMethods
	/// </summary>
	[WebService
 	 (	Name = "Invite",
  		Description = "Invite",
  		Namespace = "http://www.Invite.example"
 	 )
	]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	[System.Web.Script.Services.ScriptService()]
	[System.Web.Script.Services.GenerateScriptType(typeof(ServerResponse))]
	//[System.Web.Script.Services.GenerateScriptType(typeof(LogBookModel))]
	[System.Web.Script.Services.GenerateScriptType(typeof(GroupUserType))]
	[System.Web.Script.Services.GenerateScriptType(typeof(PageType))]
	public class PageMethods : WebServices
	{
	#region 群功能
	
		[WebMethod(EnableSession=true)]
		public ServerResponse GetGroupList(int nowpage,int everypage,byte type) {
			long userid = 0;
			if (!long.TryParse(HttpContext.Current.Session["userid"].ToString(), out userid)) {
				throw new Exception("非法操作.");
			}
			
			GroupList nr = new GroupList();
			nr.Userid = userid;
			nr.Nowpage = nowpage;
			nr.Everypage = everypage;
			nr.Groupclass = 0;
			nr.Type = type;
			return nr.GetServerResponse();
		}

		[WebMethod(EnableSession=true)]
		public string GetNewGroupPage() {
			NewGroup ng = new NewGroup();
			//ng.Userid = userid;
			return ng.ShowAll("", 1);
		}
		#endregion
		#region 搜索功能
		[WebMethod(EnableSession=true)]
		public ServerResponse SearchUser(Dictionary<string,object> dict, int nowpage, int everypage, string mode) {
			Chsword.Reader.Search ds = new Chsword.Reader.Search(dict, "");
			ds.Template = CHUser.UserID == 0 ? "SearchUserListSample" : "UserList";
			ds.Nowpage = nowpage;
			ds.Everypage = everypage;
			return ds.GetMember();
		}
		[WebMethod(EnableSession=true)]
		public ServerResponse SearchGroup(string groupname, int nowpage, int everypage) {
			long userid = 0;
			if (!long.TryParse(HttpContext.Current.Session["userid"].ToString(), out userid)) {
				throw new Exception("非法操作.");
			}
			Chsword.Reader.SearchGroup ds = new Chsword.Reader.SearchGroup();
			ds.Nowpage = nowpage;
			ds.Everypage = everypage;
			ds.Groupname = groupname;
			return ds.GetMember();
		}
		#endregion
		#region 好友



		#endregion
		#region 留言回复
		//////////////////////////////////////////////////////////////////////////////////////////////////////
		// 留言回复啥的
		//
		//////////////////////////////////////////////////////////////////////////////////////////////////////
		[WebMethod(EnableSession=true)]
		public string DeleteReply(long Commentid) {//删除留言
			//IDataBase idb = new DBExt(new Dictionary());
			DBExt.Comment_Remove(Commentid);
			return "";
		}
		[WebMethod(EnableSession=true)]
		public string GetReplyList(long nowpage, long everypage, long Ownerid, short type) {
			long Viewerid = new long();
			if (!long.TryParse(HttpContext.Current.Session["userid"].ToString(), out Viewerid)) {
				return "undefine";
			}
			Chsword.Reader.Comment dc = new Chsword.Reader.Comment();
			dc.Viewerid = CHUser.UserID;
			if(type==0)
				dc.Ownerid=Ownerid;
			else
				dc.Logid=Ownerid;
			dc.Everypage=everypage;
			dc.Nowpage=nowpage;
			dc.Type=type;
			dc.GetReplyList();
			return dc.ShowPage();
		}
		//[WebMethod(EnableSession = true)]
		//public ChAlumna.Models.Comment ReplyReply(long logid, string Tbody, long Replyid,bool isReply, string requestid, byte type) {
		//    #region old
		//    //long Ownerid;
		//    //if (!long.TryParse(requestid, out Ownerid)) {
		//    //    return "undefine";
		//    //}
		//    //CommentItem dci = new CommentItem();
		//    //dci.Body = Tbody;
		//    //dci.Senderid = ChSession.Userid;
		//    //dci.IsReply = isReply;
		//    //dci.Logid = logid;
		//    //dci.Type = type;
		//    //if (isReply && (Replyid != 0)) {
		//    //    if (dci.Senderid == Ownerid) {
		//    //        dci.Ownerid = Replyid;
		//    //        dci.IsonMyPage = true;
		//    //    } else {
		//    //        dci.Ownerid = Ownerid;
		//    //        dci.IsonMyPage = false;
		//    //    }
		//    //} else {
		//    //    dci.Ownerid = Ownerid;
		//    //    dci.IsonMyPage = true;
		//    //}
		//    //IItems ecm = new Chsword.Execute.CommentExecuter(dci);
		//    //return ecm.Add();
		//    #endregion
		//    long Ownerid;
		//    if (!long.TryParse(requestid, out Ownerid)) {
		//        return "undefine";
		//    }

		//    ChAlumna.Models.Comment cmt = new ChAlumna.Models.Comment();
		//    cmt.body = CHServer.HtmlEncode(Tbody).Replace("\n", "<br />");
		//    cmt.addtime = DateTime.Now;
		//    cmt.senderid = ChUser.Current.Userid;
		//    cmt.IsReply = isReply;
		//    cmt.Logid = logid;
		//    cmt.type = type;
		//    //new 
		//    bool IsonMyPage;
		//    //new 
		//    if (isReply && (Replyid != 0)) {
		//        if (cmt.senderid == Ownerid) {
		//            cmt.ownerid = Replyid;
		//            IsonMyPage = true;
		//        } else {
		//            cmt.ownerid = Ownerid;
		//            IsonMyPage = false;
		//        }
		//    } else {
		//        cmt.ownerid = Ownerid;
		//        IsonMyPage = true;
		//    }

		//    ChAlumnaDBDataContext db = new ChAlumnaDBDataContext();

		//    if (isReply && IsonMyPage && type == 0) {
		//        //INSERT INTO Comment
		//        // (Logid, ownerid, senderid, body,isreply)
		//        //VALUES    (@Logid, @senderid, @senderid, @body,@isreply)
		//        ChAlumna.Models.Comment cmt1 = new ChAlumna.Models.Comment()
		//        {
		//            body = CHServer.HtmlEncode(Tbody).Replace("\n", "<br />"),
		//            addtime = DateTime.Now,
		//            senderid = ChUser.Current.Userid,
		//            ownerid = ChUser.Current.Userid,
		//            IsReply = isReply,
		//            Logid = logid,
		//            type = 0
		//        };
		//        db.Comment.InsertOnSubmit(cmt1);				
		//    }
		//    //INSERT INTO Comment
		//    //                      (Logid, ownerid, senderid, body,isreply,[type])
		//    //VALUES    (@Logid, @ownerid, @senderid, @body,@isreply,@type)
		//    db.Comment.InsertOnSubmit(cmt);
		//    db.SubmitChanges();
		//    return cmt;
		//    //Chsword.Reader.Comment dc = new Chsword.Reader.Comment();
		//    //dc.Viewerid = cmt.senderid;
		//    //dc.Type = cmt.type;//类型0为回复1为日志2为班级
		//    //dc.CommonRows = DataBaseExecutor;
		//    //dc.ShowPage();

		//    //IItems ecm = new Chsword.Execute.CommentExecuter(dci);
		//    //return ecm.Add();
		//}
		#endregion
		#region 用户设置 setting 安全设置
		[WebMethod(EnableSession = true)]
		public string ChangeShowLevel(byte PersonalInfoShowLevel, byte FaceShowLevel, byte AllShowLevel) {
			if (!CHSNSUser.Current.isLogined) {
				throw new Exception("非法操作.");
			}
			Dictionary dict = new Dictionary();
			dict.Add("@Userid", CHSNSUser.Current.UserID);
			dict.Add("@PersonalInfoShowLevel", PersonalInfoShowLevel);
			dict.Add("@FaceShowLevel", FaceShowLevel);
			dict.Add("@AllShowLevel", AllShowLevel);

			DataBaseExecutor.Execute("ChangeShowLevelUpdate", dict);
				return "";
		}
		[WebMethod(EnableSession = true)]
		public string ChangePassword(string oldpassword, string password) {
			if (!CHSNSUser.Current.isLogined) {
				throw new Exception("非法操作.");
			}
			Encrypt en = new Encrypt();

			Dictionary dict = new Dictionary();
			dict.Add("@Oldpwd", en.MD5Encrypt(oldpassword.Trim(), 32));
			dict.Add("@Newpwd", en.MD5Encrypt(password.Trim(), 32));
			dict.Add("@Userid", CHSNSUser.Current.UserID);

			DataBaseExecutor.Execute("ChangePassword", dict);
				return "";
		}
		#endregion
		#region 班级
		//////////////////////////////////////////////////////////////////////////////////////////////////////
		//班级设置
		//
		//////////////////////////////////////////////////////////////////////////////////////////////////////

		[WebMethod(EnableSession=true)]
		public string CreateClass(string classname) {
			long userid = 0;
			if (!long.TryParse(HttpContext.Current.Session["userid"].ToString(), out userid)) {
				throw new Exception("非法操作.");
			}
			GroupModel gm = new GroupModel();
			gm.Groupname = classname;
			gm.CreateUserid = CHUser.UserID;
			gm.GroupClass = 1;//班级
			GroupExecuter ge = new GroupExecuter(gm);
			string ret = ge.Add();
			if (CHUser.Status==5)
				HttpContext.Current.Session["status"] = 6;
			return ret;
		}
		//////////////////////////////////////////////////////////////////////////////////////////////////////
		//个人信息设置EditMyInfo
		//
		//////////////////////////////////////////////////////////////////////////////////////////////////////

		[WebMethod(EnableSession=true)]
		public string GetCityList(int Province) {
			long userid = 0;
			if (!long.TryParse(HttpContext.Current.Session["userid"].ToString(), out userid)) {
				throw new Exception("非法操作.");
			}
			DataSetCache dsc = new DataSetCache();
			return dsc.CityOptionList(Province);
		}
		#endregion
		#region 日志
		//////////////////////////////////////////////////////////////////////////////////////////////////////
		// 日志
		//
		//////////////////////////////////////////////////////////////////////////////////////////////////////

		[WebMethod(EnableSession=true)]
		public string GetNewLogBookItem(byte type) {
			long Viewerid = 0;
			if (!long.TryParse(HttpContext.Current.Session["userid"].ToString(), out Viewerid)) {
				throw new Exception("非法操作.");
			}
			Chsword.Reader.LogBook ul = new Chsword.Reader.LogBook("LogBook",0,Viewerid);
			return ul.ShowPage(
				ul.GetLogBookTable(
					1, type)
			);
		}
		///// <summary>
		///// 对日志的操作
		///// </summary>
		///// <param name="lm"></param>
		///// <param name="lo"></param>
		///// <returns></returns>
		//[WebMethod(EnableSession=true)]
		//public string OptionLogBook(LogBookModel lm,OptionType lo) {
		//    long userid = 0;
		//    if (!long.TryParse(HttpContext.Current.Session["userid"].ToString(), out userid)) {
		//        throw new Exception("非法操作.");
		//    }
		//    LogBookExecuter dol = new Chsword.Execute.LogBookExecuter();
		//    dol.LogBookModel = lm;
		//    dol.Viewerid = userid;
		//    switch (lo) {
		//        case OptionType.Add:
		//            return "";//dol.Add();
		//        case OptionType.Delete:
		//            return "";// dol.Remove();
		//        case OptionType.Push:
		//            return "";//dol.Update2();//Push日志
		//        case OptionType.Update:
		//            return "";// dol.Update();
		//            default :
		//                return "unknow";
		//    }
		//}

		//[WebMethod(EnableSession=true)]
		//public string LogBookList(long Groupid, int nowpage, Chsword.LogBookType lbt) {
		////	long userid = 0;
		//    if (!ChUser.Current.isLogined) {
		//        throw new Exception("非法操作.");
		//    }
		//    switch (lbt) {
		//        case LogBookType.GroupLogBook:
		//            Chsword.Reader.PostList pl = new Chsword.Reader.PostList();
		//            pl.Groupid = Groupid;
		//            pl.Nowpage = nowpage;
		//            pl.Everypage = 20;
		//            return pl.ShowAll(pl.ShowPage(pl.GetPostList()), nowpage);
		//        case LogBookType.UserLogBook:
		//            return "";
		//        default:
		//            return Debug.TraceBack(" LogBookList 意外的参数传入 ");
		//    }
		//}
		#endregion
		#region GroupUser 群用户管理
	
		[WebMethod(EnableSession=true)]
		public string OptionGroupUser(long groupid,long buser,GroupUserType ut) {//退出群
			long userid = 0;
			if (!long.TryParse(HttpContext.Current.Session["userid"].ToString(), out userid)) {
				throw new Exception("非法操作.");
			}
			GroupUserExecuter gue = new GroupUserExecuter();
			gue.Groupid = groupid;
			gue.Userid = userid;
			gue.Executerid = userid;
			switch (ut) {
				case GroupUserType.Join:
					return gue.Add();
				case GroupUserType.Leave:
					return gue.Remove();
				case GroupUserType.Takein:
					return gue.Update();
				case GroupUserType.Takeout:
					return gue.Update2();
				case GroupUserType.JoinClass:
					string ret = gue.Add();
					Identity identity = new Identity();
					int status = identity.GetUserStatus(userid);
					//HttpContext.Current.Session["status"] =
					CHUser.InitStatus(status);
				//	ChCookies.Status = status;
					//HttpContext.Current.Response.Cookies[ChSite.Currect.CookieName]
					//    ["userstatus"]
					//    = HttpContext.Current.Session["status"].ToString();
				
					if (ret == "您已经成功加入该群")
						return "您已经成功加入此班级";
					else
						return ret;
				case GroupUserType.ApplyMaster://申请管理员
					return gue.ApplyMaster();
				case GroupUserType.AllowMember://同意加入
					gue.Userid = buser;
					return gue.AllowMember();
				case GroupUserType.DisallowMember://不同意加入
					gue.Userid = buser;
					return gue.DisallowMember();
				case GroupUserType.AllowMaster://加为管理员
					gue.Userid = buser;
					return gue.AllowMaster();
				case GroupUserType.DisallowMaster://不加为管理员
					gue.Userid = buser;
					return gue.DisallowMaster();
				case GroupUserType.TurnCreater:
					gue.Userid = buser;
					return gue.TurnCreater();
				case GroupUserType.TurnMember:
					gue.Userid = buser;
					return gue.TurnMember();
				default:
					return Debug.TraceBack(" OptionGroupUser 意外的参数传入 ");
			}
		}
		#endregion
		#region 管理，Manage Group
		//[WebMethod(EnableSession=true)]
		//public string SaveMyInfo(Dictionary<string, object> dict,string mode){
		//    if (CHUser.UserID==0) {
		//        return "非法操作.";
		//    }
		//    UserSettingExecuter ui = new UserSettingExecuter();
		//    switch (mode.ToLower()) {
		//        case "school":
		//            return ui.SetUserSchoolInfo(dict);
		//        case "contact":
		//            return ui.SetUserContactInfo(dict);
		//        case "personal":
		//            return ui.SetUserPersonalInfo(dict);
		//        case "magicbox":
		//            return ui.SetUserMagicBoxInfo(dict);
		//        case "magicboxupback":
		//            ui.SetUserMagicBoxUpBack();
		//            return "已经将您的MagicBox保存至信箱.";
		//        case "magicboxclear":
		//            ui.SetUserMagicBoxClear();
		//            return "已经将您的MagicBox清理干净.";
		//        case "deleteface":
		//            return ui.DeleteUserface();
		//        default://basic
		//            return ui.SetUserBaseInfo(dict);
		//    }
		//}
		[WebMethod(EnableSession=true)]
		public string SetGroup(GroupModel g,PageType t) {
			long userid = 0;
			if (!long.TryParse(HttpContext.Current.Session["userid"].ToString(), out userid)) {
				throw new Exception("非法操作.");
			}
			GroupSettingExecuter se = new GroupSettingExecuter();
			switch (t) {
				case PageType.Setting:
					g.ViewUserid = userid;
					return se.SettingUpdate(g);
				case PageType.Deletemember:
					return se.DeleteMember(g, userid);
				default:
					break;
			}
			return "";
		}
		#endregion
		#region Message 站内小条
		[WebMethod(EnableSession=true)]
		public ServerResponse ResponsePage(int nowpage, int everypage, PageType type) {
			long userid = 0;
			if (!long.TryParse(HttpContext.Current.Session["userid"].ToString(), out userid)) {
				throw new Exception(Debug.TraceBack("非法操作."));
			}
			switch (type) {
				case PageType.Inbox:
				case PageType.Sent:
					#region Message 站内小条
					Chsword.Reader.Message m = new Chsword.Reader.Message();
					m.Nowpage = nowpage;
					m.Everypage = everypage;
					m.Userid = userid;
					m.Type = type;
					return m.GetServerResponse();
					#endregion
				default:
					throw new Exception(Debug.TraceBack(" LogBookList 意外的参数传入 "));

			}
		}
		[WebMethod(EnableSession=true)]
		public MessageModel ReadMessage(long Messageid,bool isowner) {
			Chsword.Reader.Message rm = new Chsword.Reader.Message();
			rm.Userid = CHUser.UserID;
			rm.Isinboxer = isowner;
			rm.Messageid = Messageid;
			CHCache.Remove(string.Format("unReadMessage.{0}", CHUser.UserID));
			return rm.GetSingle();
		}
		[WebMethod(EnableSession=true)]
		public string OptionMessage(MessageModel mm, OptionType lo) {
			long userid = 0;
			if (!long.TryParse(HttpContext.Current.Session["userid"].ToString(), out userid)) {
				throw new Exception("非法操作.");
			}
			mm.Fromid = userid;
			MessageExecuter dol = new MessageExecuter();
			dol.MessageModel = mm;
			switch (lo) {
				case OptionType.Add:
					return dol.Add();
				case OptionType.Delete:
					return dol.Remove();
					default :
						return "unknow";
			}
		}
		#endregion
		
	
	}
