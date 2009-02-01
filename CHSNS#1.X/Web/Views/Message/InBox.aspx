<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewUserControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
	<%=Html.Script("PageSet") %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<fieldset>
		<legend>收件箱</legend>
		<%=Html.ActionLink("去发件箱","Outbox","Message") %>
		共(<%=ViewData["PageCount"]%>)封
		<div class="page" id="PageUp">
		</div>
		<div class="ch_content">
			<ul class="userlist" id="InboxList">
				<%
					Html.RenderPartial("InboxList", ViewData.Model);%>
			</ul>
		</div>
	</fieldset>
	<%=Html.Hidden("PageCount")%>
	<%=Html.Hidden("NowPage") %>
	<%=Html.Hidden("EveryPage","10") %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">

	<script type="text/javascript">
		var Delete = function(id) {
			$.post('<%=Url.Action("Delete") %>', { "id": id, "t": 1 }, function(r) {
				$("#Items" + id).hide();
				alertEx("删除成功");
			});
		};
		var setpage = function(p) {
			$.post('<%=Url.Action("InBoxList") %>', { "p": p }, function(r) {
				$h("#InboxList", r);
				pagefun();
			});
		};
		pagefun();
	</script>

</asp:Content>
