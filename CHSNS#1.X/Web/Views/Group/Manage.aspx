<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	CodeBehind="Manage.aspx.cs" Inherits="CHSNS.Web.Views.Group.Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="toc">
		<ul>
			<li><a href="#">订阅</a> </li>
			<li><a href="#">我加入的群</a> </li>
			<li><a href="#">所有群</a> </li>
			<li class="active"><a href="#">新建群</a> </li>
		</ul>
	</div>
	<form action="" method="post" class="ch_content">
		<div>
			<label for="Groupname">
				群 名 称：</label>
			<%=Html.TextBox("Name") %>
		</div>
		<div>
			<label for="Publish">
				群公告栏：</label><br />
			<%=Html.TextArea("Summary", new {rows="10", cols="45" , @class="textarea"})%>
		</div>
		<div>
			<label>
				群 权 限：</label><span class="select"><select id="Showlevel">
					<option value="0">公开(任何人都可以看贴和发贴)</option>
					<option selected="selected" value="4">半公开(任何人可以看贴，成员可以发贴)</option>
					<option value="8">私有(只有成员才能看贴，发贴)</option>
				</select></span>
		</div>
		<div>
			<label>
				成员加入：</label><span class="select"><select id="Joinlevel">
					<option value="0">无需批准</option>
					<option selected="selected" value="4">需要管理员批准</option>
					<option value="8">只能由管理员邀请</option>
				</select></span>
		</div>
		<div class="operation">
			<input type="button" value="保存设置" onclick="SetGroup($t.Setting);" />
		</div>
	</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
