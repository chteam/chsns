<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FriendList.ascx.cs"
	Inherits="CHSNS.Web.Views.Friend.FriendList" %>
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
			<li>
			<%=Html.WriteMessage(p.UserID,p.Name)%></li>
			<li><a href="javascript:DeleteFriend(<%=p.UserID %>)">解除好友关系</a></li>
		</ul>
</li>
<%} %>
