<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CHSNS.Web.Views.Group.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
<%=Html.CSSLink("group") %>
<%=Html.CSSLink("wysiwyg")%>
<%=Html.Script("wysiwyg")%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%
	var g = ViewData.Model;
	var guser = ViewData["guser"] as GroupUser;
	if (g == null||guser==null) { %>
<div class="notes">您所访问的群不存在</div>
<%} else {
		bool IsAdmin = guser.Status.Equals(GroupUserStatus.Admin) || guser.Status.Equals(GroupUserStatus.Ceater) ||
		               CHUser.IsAdmin;
%>
<div class="groupFirstly">
	<div>
		<div id="groupPicture">
		
			<img src="<%=Path.GetGroupImg(g.ID,ThumbType.Big) %>" alt="css" />
		</div>
		<ul class="adminActions">
<%if (IsAdmin) {%>
<li><a href="<%=Url.LinkGroupManage(g.ID)%>">管理员工具箱</a></li>
<%}
  if (guser.Status.Equals(GroupUserStatus.Common)) {%>
<li><a href="javascript:ApplyAdmin($group.id)">申请做管理员</a></li>
<%} if (guser.Status.Equals(GroupUserStatus.Ceater)) { %>
			#if ($group.UserCount <= 1)
<li><a href="javascript:DeleteGroup($group.id);">删除本群</a></li>
			#end
<%} if (guser.Status.Equals(GroupUserStatus.Common) || guser.Status.Equals(GroupUserStatus.Admin)) { %>
<li><a href="javascript:Leave($group.id)">退出</a></li>
<%} if (!guser.Status.Equals(GroupUserStatus.Lock)) {%>
<li><a href="/Invite.aspx?id=$group.id&">邀请朋友加入</a></li>
	#if ($user.IsRss)
<li><a id="RssTake" href="javascript:Takeout($group.id);">取消订阅</a></li>
	#else
<li><a id="RssTake" href="javascript:Takein($group.id);">订阅本群</a></li>
	#end
<%} if (guser.Status.Equals(GroupUserStatus.Lock) && g.JoinLevel == 8) {//不是成员且，可自行申请加入%>
<li><a href="javascript:Joinin($group.id);">加入本群</a></li>
<%} %>
		</ul>
	</div>
	<div>
		<ul>
		    <li>&nbsp;</li>
			<li>群管理员：</li>
<%foreach (UserItemPas u in (ViewData["adminlist"] as IEnumerable<UserItemPas>).ToNotNull()) {%>
<%=Html.UserPageLink(u.ID,u.Name) %> 
<%}%>
			<li>&nbsp;</li>
		</ul>
	</div>
	<div class="box" id="Div1">
	<h4>群成员</h4>
	<%Html.RenderPartial("ViewList", ViewData["MemberList"]); %>
	</div>
</div>
<div class="groupSecondary">
	<div>
		<h4 class="announce">
		<%=g.Name%>(共<span class="count"><%=g.UserCount%></span>人)</h4>
	</div>
	<div class="div2">
		<h4>
			群公告栏</h4>
		<div class="notes">

<%if (IsAdmin) {%>
##处理加入请求以及申请管理员请求
		#if ($ApplyMember > 0)
有$ApplyMember位成员等待加入 <a href="/ManageGroup.aspx?id=$group.id&mode=member&">去处理</a><br />
		#end
		#if ($ApplyMaster > 0)
有$ApplyMaster位成员,申请成为管理员 <a href="/ManageGroup.aspx?id=$group.id&mode=member&">去处理</a><br />
		#end
<%	}%>
<%=g.Summary %>
		</div>
	</div>
	<div class="box" id="groupVisitor">
		<h4>
			最近访客</h4>
<%Html.RenderPartial("ViewList", ViewData["viewlist"]); %>

	</div>
	<div>
		<h4>
			群论坛</h4>
		<div>
			<div class="page" id="PageUp">
			</div>
			<div id="Loglist">
			<%--##<帖子列表>--%>
#if ($right != 8 || $ChHelper.ChUser.isAdmin) ## 为8时不可读
#component(PostList with "Groupid=$group.id" "EveryPage=20" "nowpage=$nowpage")
#else
<div class="note">
<%=g.Name %> 是私人群，非成员不能阅读群主题。<a href="javascript:Joinin($group.id);">申请加入群</a>
</div>
#end
			<%--##帖子列表--%>
			</div>
			<div class="page" id="PageDown">
			</div>
		</div>
	</div>
	<div id="sendsubject">
#if ($right ==0 || $ChHelper.ChUser.isAdmin)
<h4><a href="#sendsubject">发表新主题</a></h4>
<ul>
	<li>
		<label for="subject">
			新主题：</label>
		<input id="subject" class="inputtext subject" type="text" /><span id="Alert"></span>
	</li>
	<li>
		<textarea cols="2" rows="20" id="tbody"></textarea>
		<input type="hidden" id="Hdisrich" value="$ChHelper.ChUser.isAdmin" />
		<div>
			<a href="javascript:set_Size(50);">
				<img src="/Images/Editor/plus.gif" alt="+" /></a> <a href="javascript:set_Size(-50);">
					<img src="/Images/Editor/minus.gif" alt="-" /></a></div>
	</li>
	<li>
		<input id="PostSubject" type="button" value="发表" class="subbutton" onclick="PublishLog($group.id);" />
	</li>
</ul>
#else
	#if ($right == 4)## //可读
<div class="note">
<%=g.Name %>是半公开群，非成员可以阅读群主题但不能发表和回复。你可以
<a href="javascript:Joinin($group.id);">申请加入群</a>
</div>
	#end
#end
	</div>
</div>

<script type="text/javascript">

</script>
<%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
