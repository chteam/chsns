<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	CodeBehind="Index.aspx.cs" Inherits="CHSNS.Web.Views.Note.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
<%=Html.Script("PageSet") %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<fieldset>
		<legend>
			<%=ViewData["username"] %>的日志</legend>
			<%=ViewData["UserID"].ToString()==CHUser.UserID.ToString()? Html.ActionLink("发布新日志","Edit","Note") :""%>
		<div class="ch_content">
			<div id="PageUp" class="page">
			</div>
			<ol id="NoteItems" class="userlist">
				<%
					Html.RenderPartial("NoteList", ViewData.Model); %>
			</ol>
			<div id="PageDown" class="page">
			</div>
		</div>
	</fieldset>
	<%=Html.Hidden("PageCount")%>
	<%=Html.Hidden("NowPage") %>
	<%=Html.Hidden("EveryPage","10") %>
<%--	
#* 前端 UILE:2007 10 6 *#
2008 9 7
--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">

	<script type="text/javascript">
		var setpage = function(p) {
			$h("#NoteItems", 'Loading...');
			$.post('<%=Url.Action("NoteList") %>', { "p": p, 'ep': $v('#EveryPage'), "userid": '<%=ViewData["UserID"] %>' }, function(r) {
				$h("#NoteItems", r);
				pagefun();
			});
		};
		pagefun();
	</script>

</asp:Content>
