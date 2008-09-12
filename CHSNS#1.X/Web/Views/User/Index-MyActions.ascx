<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Index_MyActions.ascx.cs"
	Inherits="CHSNS.Web.Views.User.Index_MyActions" %>
<%UserPas up = ViewData.Model;%>
<ul id="userActions">
	<%if (up.IsMe) { %>
	<li>
		<%=Html.UserEditLink("upload", "更换头像")%>
	</li>
	<li>
		<%=Html.UserEditLink("", "编辑我的资料")%></li>
	<li>
		<%=Html.UserEditLink("magicbox", "编辑我魔法盒")%></li>
	<%} else {
	%>
	<li>
		<%=Html.WriteMessage(up.OwnerID ,up.Profile.Name) %></li>
	<%
		}
   if (up.Relation == 150) { //好友%>
	<li><a href="javascript:void(0);" onclick="$.post('<%=Url.Action("Delete","Friend") %>',{'toid':<%=up.OwnerID%>},function(r){alertEx(r);});return false;">
		解除好友关系</a></li>
	<%} else {%>
	<li><a href="javascript:void(0);" onclick="$.post('<%=Url.Action("Add","Friend") %>', { 'toid':<%=up.OwnerID%>}, function(r) { alertEx(r); });return false;">
		加为好友</a></li>
	<%
		}%>
</ul>
