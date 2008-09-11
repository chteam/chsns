<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FriendList.ascx.cs"
	Inherits="CHSNS.Web.Views.Friend.FriendList" %>
<%if (ViewData.Model != null)
	  foreach (UserItemPas p in ViewData.Model as IEnumerable<UserItemPas>) { %>
<li id="Items<%=p.ID %>" class="useritem">
		<p class="image"> 
			<a href="<%=Url.UserPage(p.ID) %>">
				<%=Html.Image(Url.CH().Path.GetFace_Middle(p.ID),p.Name ) %></a>
		</p>
		<div class="info">
			<strong>
				<%=Html.UserPageLink(p.ID,p.Name) %></strong>
			<ul>
				<li>浏览：
					<%=Html.FriendLink(p.ID) %>
					|
					<%=Html.BlogLink(p.ID) %>
					|
					<%=Html.AlbumLink(p.ID) %>
				</li>
			</ul>
		</div>
		<ul class="actions">
			<li>
			<%=Html.WriteMessage(p.ID,p.Name)%></li>
			<li><a href="javascript:DeleteFriend(<%=p.ID %>)">解除好友关系</a></li>
		</ul>
</li>
<%} %>
