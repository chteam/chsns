using System;
using System.Collections.Generic;
using System.Text;
using ChAlumna;
using System.Web.UI;
namespace Chsword.Web.UI {
	public class PrivateMaster : MasterPage {
		override protected void OnInit(EventArgs e) {
			if (!(Request.Path == "/Default.aspx")) {
				if (Session["userid"] == null) Response.Redirect("/");
				if (string.IsNullOrEmpty(Session["username"].ToString())) {
					if (!(Path.urlFilename == "editmyinfo")) {
						Response.Redirect("/EditMyInfo.aspx");
					}
				}
			}
			byte status = ChSession.Status;
			if (Path.urlFilename == "message") {//MessageË­¶¼ÄÜ¿´
				return;
			}
			if (status < 2) {
				if (Path.urlFilename != "registrator") {
					Response.Redirect("/Registrator.aspx");
				}
			}
			if (status < 5) {
				if (Path.urlFilename != "editmyinfo") {
					if (status == 3) {
						Response.Redirect("/EditMyInfo.aspx?tabs=1");
					}else
						Response.Redirect("/EditMyInfo.aspx");
				}
			}
			/*if (status <6) {
				if (Path.urlFilename!="classlist"
				    && Path.urlFilename!="editmyinfo"
				    && Path.urlFilename!="createclass"
				   ) {
					Response.Redirect("/ClassList.aspx");
				}
			}
			if (status < 8) { 
				if (Path.urlFilename!="classlist"
				    && Path.urlFilename!="editmyinfo"
				    && Path.urlFilename!="createclass"
					 && Path.urlFilename != "grouplist"
				   ) {
					Response.Redirect("/GroupList.aspx?class=1");
				}
				
			}*/
			base.OnInit(e);
		}
	}
}
