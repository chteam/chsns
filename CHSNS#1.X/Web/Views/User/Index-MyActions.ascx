﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Index_MyActions.ascx.cs"
	Inherits="CHSNS.Web.Views.User.Index_MyActions" %>
<%UserPas up = ViewData.Model;%>
<ul id="userActions">
	<%if (up.User["Relation"].ToString() == "200") { %>
	<li><a href="/EditMyInfo.aspx?mode=upload">更换头像</a></li>
	<li><a href="/EditMyInfo.aspx">编辑我的资料</a></li>
	<li><a href="/EditMyInfo.aspx?mode=magicbox">编辑我魔法盒</a></li>
	<%} else if (up.User["Relation"].ToString() == "150") { %>
	<li><a href="/Message.aspx?mode=compose&ToId=<%=up.OwnerID%>&Toname=<%=up.OwnerName%>&">
		发小条</a></li>
	<li><a href="javascript:DeleteFriend(<%=up.OwnerID%>)">解除好友关系</a></li>
	<%} else {%>
	<li><a href="/Message.aspx?mode=compose&ToId=<%=up.OwnerID%>&Toname=<%=up.OwnerName%>&">
		发小条</a></li>
	<li><a href="javascript:AddFriend(<%=up.OwnerID%>)">加为好友</a></li>
	<%} %>
</ul>