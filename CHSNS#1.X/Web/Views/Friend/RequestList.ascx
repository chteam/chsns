<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RequestList.ascx.cs"
	Inherits="CHSNS.Web.Views.Friend.RequestList" %>
<%if (ViewData.Model != null)
	  foreach (UserItemPas p in ViewData.Model as IEnumerable<UserItemPas>) { %>
<li id="Items<%=p.ID %>" class="useritem">
	<div class="face face-middle">
		<a href="<%=Url.UserPage(p.ID) %>" title="<%=p.Name %>" style="background-image: url(<%=Path.GetFace(p.ID,ThumbType.Middle) %>);"></a>
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
		<li><a href="javascript:AgreeFriend(<%=p.ID %>)">接受请求</a></li>
		<li><a href="javascript:IgnoreFriend(<%=p.ID %>)">忽略请求</a></li>
		<li>
			<%=Html.WriteMessage(p.ID,p.Name)%></li>
	</ul>
</li>
<%} %>