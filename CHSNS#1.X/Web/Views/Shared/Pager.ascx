<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl<IPagedList>" %>
 <div class="page">
<%
	if (ViewData.Model.TotalPages > 1) {
		if (ViewData.Model.HasPreviousPage) { %>
<a href="?wd=<%=ViewData["wd"] %>&p=<%=ViewData.Model.CurrentPage - 1%>">上一页</a>
<% } else { %>
上一页
<% }
		for (int i = 2; i <= 6; i++)
			if ((ViewData.Model.CurrentPage + i - 4) >= 1 && (ViewData.Model.CurrentPage + i - 4) <= ViewData.Model.TotalPages)
				if (4 == i) {
%>
[<%=ViewData.Model.CurrentPage%>]
<% } else {%>
<a href="?wd=<%=ViewData["wd"] %>&p=<%=ViewData.Model.CurrentPage + i - 4%>">
	<%=ViewData.Model.CurrentPage + i - 4%></a>
<%} if (ViewData.Model.HasNextPage) { %>
<a href="?wd=<%=ViewData["wd"] %>&p=<%= ViewData.Model.CurrentPage + 1%>">下一页</a>
<% } else { %>
下一页
<% }
	}
%>
</div>