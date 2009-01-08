<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	CodeBehind="Manage.aspx.cs" Inherits="CHSNS.Web.Views.Group.Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<%Html.RenderPartial("Toc");
      
		 %>
	<form action="" method="post" class="ch_content formset">
		<p>
			<label>群名称：</label>
			<%=Html.TextBox("group.Name") %>
		</p>
		<p>
			<label>群公告栏：</label>
			<%=Html.TextArea("group.Summary", new { rows = "10", cols = "45", @class = "textarea" })%>
		</p>
		<p>
			<label>群权限：</label>
			<span class="select"><%=Html.DropDownList("group.ShowLevel")%></span>
		</p>
		<p>
			<label>成员加入：</label><%=Html.DropDownList("group.JoinLevel")%></span>
		</p>
		<p class="operation">
			<input type="submit" value="保存设置" />
		</p>
	</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
