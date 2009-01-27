<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	CodeBehind="Edit.aspx.cs" Inherits="CHSNS.Web.Views.Album.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<fieldset>
		<legend>新建相册</legend>
		<form class="formset" method="post" action="" onclick="return sub();">
		<p>
			<label>
				相册名称:</label><%=Html.TextBox("a.Name")%></p>
		<p>
			<label>
				拍摄地点:</label><%=Html.TextBox("a.Location") %></p>
		<p>
			<label>
				相册说明:</label>
			<%=Html.TextArea("a.Description")%></p>
		<p>
			<label>
				访问权限:</label>
			<% Html.RenderPartial("ShowLevel",
		  new ShowLevelOption("a.ShowLevel", ViewData.Model != null ? ViewData.Model.ShowLevel : (byte)0)); %>
		</p>
		<p>
			<input type="submit" value="确认提交" class="subbutton" />
			<input type="button" value="取消" class="subbutton" onclick="pCancle();" />
		</p>
		</form>
	</fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
<script type="text/javascript">
	function sub() {
		return true;
	}
</script>
</asp:Content>
