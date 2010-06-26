<%@ Control Language="C#" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewUserControl<UserIndexViewModel>" %>
<% UserIndexViewModel up = ViewData.Model;%>
<a href='#' class="accordionHeader" id="accont-header">账号 Account </a>
<%--<div class="" id="accont-header">
	</div>--%>
<div id="accont-content" class="accordionContent">
	<ul>
		<li><span>注册ＩＤ：</span><%=up.OwnerId  %></li>
		<li><span>注册时间：</span><%=up.Profile.RegTime.ToString("yyyy-MM-dd")%></li>
		<li><span>上线时间：</span><%=up.Profile.LoginTime.ToString("yyyy-MM-dd HH:mm")%></li>
		<li><span>可用积分：</span><%=up.Profile.Score%></li>
		<%if (up.IsMe) {%>
		<li>
			<%=Html.UserEditLink("", "[编辑]")%></li>
				<li><span>性 别：</span><%=up.Basic.Sex.HasValue&&up.Basic.Sex.Value ? "男生" : "女生"%></li>
		<%
			}
	if (0 == up.Basic.ShowLevel || Context.User.IsInRole("admin")) {
		%>
	
		<%if (up.Basic.Birthday.HasValue) { %>
		<li><span>出生日期：</span><%=up.Basic.Birthday.Value.ToString("yyyy-MM-dd")%></li>
		<%--	<li><span>家　　乡：</span><%=up.User["ProvinceName"]%>-<%=up.User["cityname"]%></li>
--%>
		<%} %>
		<%} %>
	</ul>
</div>
