<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Index_Account.ascx.cs"
	Inherits="CHSNS.Web.Views.User.Index_Account" %>
<% UserPas up = ViewData.Model;%>
<a href='#' class="accordionHeader" id="accont-header">账号 Account </a>
<%--<div class="" id="accont-header">
	</div>--%>
<div id="accont-content" class="accordionContent">
	<ul>
		<li><span>注册ＩＤ：</span><%=up.OwnerID %></li>
		<li><span>注册时间：</span><%=Convert.ToDateTime(up.User["RegTime"]).ToString("yyyy-MM-dd")%></li>
		<li><span>上线时间：</span><%=Convert.ToDateTime(up.User["LoginTime"]).ToString("yyyy-MM-dd HH:mm")%></li>
		<li><span>可用积分：</span><%=up.User["Score"] %></li>
	<%if (up.IsMe) {%>
	<li><a href="/EditMyInfo.aspx?mode=Basic" class="edit">[编辑]</a></li>
	<%
		}
   if (Convert.ToInt16(up.User["Relation"]) >= Convert.ToInt16(up.User["BasicInfoShowLevel"]) || CHUser.IsAdmin) {
	%>
		<li><span>性　　别：</span><%=Convert.ToBoolean(up.User["sex"]) ? "男生" : "女生"%></li>
		<%if (!up.User.IsNull("Birthday")) { %>
		<li><span>出生日期：</span><%=Convert.ToDateTime(up.User["Birthday"]).ToString("yyyy-MM-dd")%></li>
	<%--	<li><span>家　　乡：</span><%=up.User["ProvinceName"]%>-<%=up.User["cityname"]%></li>
--%>		<%} %>

	<%} %>
		</ul>
</div>
