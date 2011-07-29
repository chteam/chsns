<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content> 
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<%
   var entry = ViewData["entry"] as Wiki;
  var version = ViewData["version"] as WikiVersion;
  var ext = ViewData["ext"] as EntryExt;
  if (ext == null) ext = new EntryExt {Tags = new List<string>()};
     %>

      

<div class="left">
		<span class="title">
<%=version.Title%>(历史版本: <%=version.AddTime.ToString("yyyy-MM-dd hh:mm:ss")%>)</span>
		<div class="body">
			<p>
				<%=version.Description %></p>
		</div>
	</div>
	<div class="right">
		<ul>
		<li><%=Html.ActionLink("当前版本", "Index", new { url = entry.Url.Trim() })%></li>
			<li>
				<%=Html.ActionLink("历史版本","Historylist", new { id=entry.Id})%>
				<span>(<%=entry.EditCount %>)</span></li>
			<%if (User.IsInRole("admin")) { %>
			<li>
				<%=Html.ActionLink("编辑词条", "Edit", new { id = entry.Id })%>
			</li>
			<li><a href="#">新建词条</a></li>
			<%} %>
		</ul>
		<ul>
			<li><span>标签：</span><%=string.Join(",", ext.Tags.ToArray()) %>
			</li>
		</ul>
	</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FootPlaceHolder" runat="server">
 <script type="text/javascript">
       $(function(){//制定标签块的宽度随着文字变化而变化
          var width1=$(".tag li").eq(0).width();
          var width2=$(".tag li").eq(1).width();
          if(width1>width2){
             $(".tag").width(width1);
          }else{
             $(".tag").width(width2);
          }
       });
    </script>

</asp:Content>