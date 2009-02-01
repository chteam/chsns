<%@ Control Language="C#" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewUserControl" %>
<%if (ViewData.Model != null)
	  foreach (UserItemPas p in ViewData.Model as IEnumerable<UserItemPas>) { %>
<li id="Items<%=p.ID %>" class="useritem">
		<div class="face face-middle"> 
		<a href="<%=Url.UserPage(p.ID) %>" title="<%=p.Name %>" 
		style="background-image: url(<%=Path.GetFace(p.ID,ThumbType.Middle) %>);"></a>
		</div>
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
