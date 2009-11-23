<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl<UserIndexViewModel>" %>
<% UserIndexViewModel up = ViewData.Model; %>
<div id="UserListMsg">
</div>
<div style="height: 100%">
	<div id="toc">
		<ul id="tabs">
			<li class="status"><a href="/search.aspx">查找</a> </li>
			<li class="toptitle">由于对方的隐私设置，你没有权限执行该操作。</li>
		</ul>
	</div>
	<div class="ch_content">
		<div class="notes">
			提示：想了解对方信息吗？那就加对方好友吧...</div>
		<ol id="UserListItems" class="peoplelist infolist">
			<li id="Items<%=up.OwnerId %>">
				<div class="people">
					<p class="image">
					
						<a href="/User.aspx?userid=<%=up.OwnerId %>" target="_blank">
							<%=Html.Image(CHSNS.Path.GetFace(up.OwnerId,ThumbType.Middle),"") %>
						</a>
					</p>
					<div class="info">
						<strong><a href="/User.aspx?userid=<%=up.OwnerId %>" target="_blank">
							<%--<%=up.Profile.Name%>--%></a> </strong>
						<ul>
							<li></li>
						</ul>
					</div>
					<ul class="actions">
						<li><a href="javascript:void(0);" onclick="$.post('<%=Url.Action("Add","Friend") %>', { 'toid':<%=up.OwnerId%>}, function(r) { alertEx(r); });return false;">
							加为好友</a></li>
						<li>
							<%--<%=Html.WriteMessage(up.OwnerID ,up.Profile.Name) %>--%></li>
					</ul>
				</div>
			</li>
		</ol>
	</div>
</div>
