<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	CodeBehind="Write.aspx.cs" Inherits="CHSNS.Web.Views.Message.Write" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<fieldset>
		<legend>发送邮件</legend>收件人:<%=Html.UserPageLink(ViewData.Model.UserID, ViewData.Model.Name)%><br />
		<form action="<%=Url.Action("Save","Message") %>" method="post" onsubmit="sub(this);return false;">
		标题:<input id="Title" name="Title" value="" type="text" /><br />
		内容:<textarea cols="60" id="Body" name="Body" rows="12"></textarea>
		<%=Html.Hidden("ToID", ViewData.Model.UserID.ToString())%>
		<input class="subbutton" value="发送" type="submit" />
		</form>
	</fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
<script type="text/javascript">	function sub(t) {
if(v_empty("#Title","标题不能为空")&&v_empty("#Body","内容不能为空"))
	t.submit();
}</script>
</asp:Content>
