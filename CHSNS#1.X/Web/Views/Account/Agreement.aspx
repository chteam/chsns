<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Single.Master" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<fieldset class="regagreement">
		<legend>注册协议</legend>
		<div class="regtext">
			<br />
		</div>
	</fieldset>
	<div class="regagreementsub">
	
		<input type="button" class="subbutton" value="我同意" onclick="javascript:location='<%=Url.Action("RegPage") %>'" />
		<input type="button" value="不同意" onclick="javascript:window.location = '/';" class="subbutton" />
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
