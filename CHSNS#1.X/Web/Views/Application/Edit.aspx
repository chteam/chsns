<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" AutoEventWireup="true"
	CodeBehind="Edit.aspx.cs" Inherits="CHSNS.Web.Views.Application.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
	<style type="text/css">
		b
		{
			width: 200px;
			display: block;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
	</h2>
	<fieldset>
		<legend>new Application</legend>
		<form action="" method="post">
		<b>标识</b><%=Html.TextBox("app.ID") %><br />
		<b>Controller</b><%=Html.TextBox("app.Controller")%><br />
		<b>Action</b><%=Html.TextBox("app.Action")%><br />
		<b>FullName</b><%=Html.TextBox("app.FullName")%><br />
		<b>ShortName</b><%=Html.TextBox("app.ShortName")%><br />
		<b>Version</b><%=Html.TextBox("app.Version")%><br />
		<b>Icon</b><%=Html.TextBox("app.Icon")%><br />
		<b>CssName</b><%=Html.TextBox("app.CssName")%><br />
		<b>Summary</b><%=Html.TextArea("app.Summary")%><br />
		<b>Url</b><%=Html.TextBox("app.Url")%><br />
		<input type="submit" value="提 交" />
		</form>
	</fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
