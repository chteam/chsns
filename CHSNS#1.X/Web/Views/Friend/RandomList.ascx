<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RandomList.ascx.cs" Inherits="CHSNS.Web.Views.Friend.RandomList" %>
<%if (ViewData.Model != null)
	  foreach (UserItemPas p in ViewData.Model as IEnumerable<UserItemPas>) { %>
<li id="Items<%=p.UserID %>" class="useritem">
		<p class="image">
			<a href="<%=Url.UserPage(p.UserID) %>">
				<%=Html.Image(Url.CH().Path.GetFace_Middle(p.UserID),p.Name ) %></a>
		</p>
		<div class="info">
			<strong>
				<%=Html.UserPageLink(p.UserID,p.Name) %></strong>
			<ul>
				<li>浏览：
					<%=Html.FriendLink(p.UserID) %>
					|
					<%=Html.BlogLink(p.UserID) %>
					|
					<%=Html.AlbumLink(p.UserID) %>
				</li>
			</ul>
		</div>
		<ul class="actions">
			<li><a href="/Message.aspx?mode=compose&ToId=userid&Toname=name">发小条</a></li>
			<li><a href="javascript:AddFriend(<%=p.UserID %>)">加为好友</a></li>
		</ul>
</li>
<%} %>