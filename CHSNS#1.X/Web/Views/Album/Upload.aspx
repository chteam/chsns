<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>上传图片</h2>
	<form id="form1" action="<%=Url.Action("UploadPhoto","Album") %>" enctype="multipart/form-data" method="post">
	<%=Html.Hidden("id") %>
	<p>你要上传的图片</p>
	<fieldset class="formset">
		<legend>Submit your Application</legend>
		<p>
			<label>图片介绍:</label>
			<input name="lastname" id="lastname" type="text" style="width: 200px" />
		</p>
		<p>
			<label>
				图片:</label>
				<input type="file" id="txtFileName" name="file" />
				<span>(2 MB ，png/gif/jpg/jpeg)</span>
		</p>
		<p>
		<input type="submit" value="Submit Application" /></p>
	</fieldset>
	</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
