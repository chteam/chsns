<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RequestList.ascx.cs" Inherits="CHSNS.Web.Views.Friend.RequestList" %>
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
			<li><a href="javascript:AgreeFriend(<%=p.UserID %>)">接受请求</a></li>
			<li><a href="javascript:IgnoreFriend(<%=p.UserID %>)">忽略请求</a></li>
			<li><%=Html.WriteMessage(p.UserID,p.Name)%></li>
		</ul>
</li>
<%} %>