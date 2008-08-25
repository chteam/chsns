<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Index_NoRight.ascx.cs" Inherits="CHSNS.Web.Views.User.Index_NoRight" %>
<% UserPas up = ViewData.Model;%>
<div id="UserListMsg"></div>
<div style="height: 100%">
<div id="toc">
<ul id="tabs">
<li class="status">
<a href="/search.aspx">查找</a>
</li>
<li class="toptitle">由于对方的隐私设置，你没有权限执行该操作。</li>
</ul>
</div>
<div class="ch_content">
<div class="notes">提示：想了解对方信息吗？那就加对方好友吧...</div>
<ol id="UserListItems" class="peoplelist infolist">
<li id="Items<%=up.OwnerID %>">
	<div class="people">
		<p class="image">
			<a href="/User.aspx?userid=<%=up.OwnerID %>" target="_blank">
<%=Html.Image(Url.CH().Path.GetFace_Middle(up.OwnerID),up.OwnerName) %>
</a>
		</p>
		<div class="info">
			<strong><a href="/User.aspx?userid=<%=up.OwnerID %>" target="_blank"><%=up.OwnerName %></a> </strong>
			<ul>
				<li>大学：<a href="/Search.aspx?action=show&amp;uid=<%=up.User["University_id"] %>&amp;">
<%=up.User["University"] %></a> <span class="pipe">
				</li>
			</ul>
		</div>
		<ul class="actions">
			<li><a href="javascript:AddFriend(<%=up.OwnerID %>)">加为好友</a></li>
			<li><a href="/Message.aspx?mode=compose&Toname=<%=Url.Encode(up.OwnerName) %>&ToId=<%=up.OwnerID %>" target="_blank">发小条</a></li>
		</ul>
	</div>
</li>

</ol>
</div>
</div>
