<%@ Control Language="C#" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="toc">
	<ul>
		<li class="manage">
			<%=Html.ActionLink("群设置","Manage","Group",new{id=this.Request.QueryString["id"]},null) %></li>
		<li class="manageuser">
			<%=Html.ActionLink("成员管理", "ManageUser", "Group", new { id = this.Request.QueryString["id"] }, null)%></li>
<%--		<li><a href="#">群图片</a> </li>
		<li><a href="#">黑名单</a> </li>--%>
		<li>
		<a href="<%=Url.LinkGroupIndex(long.Parse(this.Request.QueryString["id"]))%>">返回群</a>
		</li>
	</ul>
</div>

<script type="text/javascript">
	$(function() {
	$('.toc .<%=ViewContext.RouteData.Values["action"].ToString().ToLower() %>').addClass("active");
	});
</script>

