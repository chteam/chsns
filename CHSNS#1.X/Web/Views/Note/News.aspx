<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="CHSNS.Web.Views.Note.News" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<fieldset>
		<legend>
			最新日志</legend>
		
			<ol id="NoteItems" class="userlist">
				<%
					Html.RenderPartial("NoteList", ViewData.Model); %>
			</ol>
	</fieldset>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
