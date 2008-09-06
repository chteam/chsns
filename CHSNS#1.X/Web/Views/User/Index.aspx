<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	CodeBehind="Index.aspx.cs" Inherits="CHSNS.Web.Views.User.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
	<%=Html.CSSLink("Reply")%>
	<%=Html.CSSLink("mypage")%>
	<%=Html.CSSLink("home")%>
	<%--<%=Html.Script("/WebServices/Profile.asmx/js")%>--%>
	<%=Html.Script("Profile")%>
	<%=Html.Script("Reply")%>

	<%=Html.Script("LogBook")%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<% 
		UserPas up = ViewData.Model;
		if (up.User != null && up.IsMagicBox && !Url.CH().User.isAdmin) {%>
	<%="<style type=\"text/css\">" + up.User["MagicBox"] + "</style>"%>
	<%
		}
		if (!(up.HasRight && up.Exists)) {
	   if (!up.HasRight)
	   {
	   	Html.RenderPartial("index-noRigh", ViewData.Model);
	   }
	   else { %> 
	<div class="notes">
		<%if (up.IsMe) {%>
		您尚未设置个人自信,请点击 [设置]->[基本设置] 进行完善
		<%} else { %>
		该用户信息不存在
		<%} %>
	</div>
	<%
		}
   } else { %>
<%--	#macro(EditInfo $id)
	<%if (up.IsMe) {%>
	<a href="/EditMyInfo.aspx?mode=$id" class="edit">[编辑]</a>
	<%} %>
	#end--%>
	<div id="userUpdates">
		<div id="userStatus">
			<div class="mypage_name">
				<h2>
					<%=up.OwnerName%>
					
				</h2>
				<% Html.RenderPartial("index-isstar", ViewData.Model);/*实名*/%>
			</div>
			<div class="mypage_sta">
				<% Html.RenderPartial("index-mystatus", ViewData.Model);/*状态*/%>
			</div>
		</div>
		<div id="userAccount">
			<div class="box" id="UserInformation">
				<ul id="Profile_Accordion">
					<li><%
   	Html.RenderPartial("index-account", ViewData.Model);%></li>
					<li><%
   	Html.RenderPartial("index-school", ViewData.Model);%></li>
					<li><%
   	Html.RenderPartial("index-contact", ViewData.Model);%></li>
					<li><%
   	Html.RenderPartial("index-personal", ViewData.Model);%></li>
				</ul>
				<script type="text/javascript">
					$("#Profile_Accordion").accordion();
				//	new Accordian().Show('#Profile_Accordion', 3, 'accordionHeaderSelected');
				</script>

				<div>
					<div>
						<h4>
							<%=up.OwnerName%>的动向</h4>
						<ul id="Profile_Event">
						<% Html.RenderAction<EventController>(c => c.Show(up.OwnerID, 0)); %>
						</ul>
					</div>
				</div>
				<%if (up.IsMagicBox && up.IsMe) { Html.RenderPartial("EmptyMagicBox");} %>
			</div>
		</div>
	<%--	<div class="box" id="userBlog">
			<h3>
				<%=up.OwnerName%>的日志</h3>
			<div class="boxcont">
				<ol id="blog">
					##<日志>
					#component(NoteList with "source=$log1source" "template=First") #component(NoteList
					with "source=$log2source" "template=Second")
				</ol>
			</div>
			<p class="more">
				<%if (up.IsMe) {%>
				<a href="/Notebook.aspx?mode=write">写新日志</a>
				<%} %>
				<a href="/Notebook.aspx?userid=<%=up.OwnerID%>">所有日志</a>
			</p>
		</div>--%>
		<div class="box" id="userTalk">
			<h3>
				<%=up.OwnerName%>的留言板</h3>
			<div class="boxcont">
				<div id="leaveWordForm">
					<p id="starttalk">
						<input id="starttalkBtn" class="subbutton" value="我要留言" onclick="iwillReply();" type="button" />
						<span id="ReplyMsg"></span>
					</p>
					<div id="starttalkForm" style="display: none;">
						<p>
							<input id="Bup" type="button" value="留言" onclick="ReplyReply(<%=up.OwnerID%>);" class="subbutton"
								tabindex="2" />
							<span class="discription">(每条最多2000字)</span>
							<input value="取消" class="inputbutton" onclick="cancelLeaveWord();" tabindex="3" type="button" />
						</p>
						<textarea id="TBody" cols="70" rows="7" onkeydown="CtrlEnterReplyUser(<%=up.OwnerID%>,event);"
							tabindex="1" class="cmtbody"></textarea>
					</div>
				</div>
				<% Html.RenderAction<CommentController>(c => c.ShowList(0, 1, 10, 0, up.OwnerID, "")); %>
			</div>
			<p class="more">
				<a href="/ReplyList.aspx?userid=<%=up.OwnerID%>">所有留言</a></p>
		</div>
	</div>
	<div id="userRelations">
		<div class="box" id="userInfo">
			<div id="userPicture">
				<div id="userFace">
					<ul>
						<li><a href="#<%=up.OwnerID%>">
							<%
								if (Convert.ToInt16(up.User["Relation"]) >= Convert.ToInt16(up.User["FaceShowLevel"]) || CHUser.IsAdmin) {
							%>
							<%=Html.Image(Url.CH().Path.GetFace_Big(up.OwnerID),up.OwnerName) %>
							<%} else { %>
							<%=Html.Image(Url.CH().Path.GetFace_Big(0), up.OwnerName)%>
							>
							<%} %>
						</a></li>
					</ul>
				</div>
			</div>
			<%
   	Html.RenderPartial("index-Myactions", ViewData.Model);%>
		</div>
		<div class="box">
			<h3>
				用户相关</h3>
			<div class="mypadding">
				<a href="/SuperNote.aspx?userid=<%=up.OwnerID%>">视频</a> <a href="/NoteBook.aspx?userid=<%=up.OwnerID%>">
					日志</a> <a href="/Photos.aspx?userid=<%=up.OwnerID%>">相册</a>
			</div>
		</div>
		<div id="userVisitor" class="box">
			<div id="userViewer">
				<h3>
					最近访问<span class="stat">(共<span class="count"><%=up.User["ViewCount"]%></span>人看过)</span></h3>
						<%
					Html.RenderPartial("ViewList", ViewData["lastview"]); %>
			</div>
		</div>
		<div class="box" id="userFriend">
			<h3>
				<%=up.OwnerName%>最近登录的好友</h3>
					<%
					Html.RenderPartial("ViewList", ViewData["lastfriend"]); %>
			<span class="more">
				<a href="/friend.aspx?userid=<%=up.OwnerID%>">more</a></span>
		</div>
		<div class="box">
			<h3>
				<%=up.OwnerName%>加入的群</h3>
			<div class="mypadding">
				<% Html.RenderAction<GroupController>(c => c.ShowGroupList("ShowProfileLinks", up.OwnerID
		   , 0, 1, 100, 0)); %>
			</div>
		</div>
	</div>

	<script type="text/javascript">
		ShoworHide("userBlog", "blog");
	</script>

	<%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
