<%@ Control Language="C#" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewUserControl" %> 
<%if (ViewData.Model != null)
	  foreach (UserItemPas p in ViewData.Model.ToNotNull<UserItemPas>()) { %>
<li id="Items<%=p.Id %>" class="useritem">
		<div class="face face-middle"> 
		<a href="<%=Url.UserPage(p.Id) %>" title="<%=p.Name %>" 
		style="background-image: url(<%=Path.GetFace(p.Id,ThumbType.Middle) %>);"></a>
		</div>
		<div class="info">
			<strong>
				<%=Html.UserPageLink(p.Id,p.Name) %></strong>
			<ul>
				<li>浏览：
					<%=Html.FriendLink(p.Id) %>
					|
					<%=Html.BlogLink(p.Id) %>
					|
					<%=Html.AlbumLink(p.Id) %>
				</li>
			</ul>
		</div>
		<ul class="actions">
			<li>
			<%=Html.WriteMessage(p.Id,p.Name)%></li>
			<li><a href="javascript:DeleteFriend(<%=p.Id %>)">解除好友关系</a></li>
		</ul>
</li>
<%} %>
