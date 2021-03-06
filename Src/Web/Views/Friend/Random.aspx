﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewPage" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
	<%=Html.Script("PageSet") %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div id="UserListMsg">
	</div>
	<h2>
		随便看看</h2>
	<a href="/Invite.aspx">邀请朋友加入</a><a href="javascript:frush()">刷新列表</a>
	<div class="ch_content">
		<div id="PageUp" class="page">
		</div>
		<ol id="UserListItems" class="userlist">
			<%
				Html.RenderPartial("RandomList", ViewData["source"]); %>
		</ol>
		<div id="PageDown" class="page">
		</div>
	</div>


	<script type="text/javascript">
		var frush = function() {
		$h("#UserListItems","载入中...");
			$.post('<%=Url.Action("RandomList") %>', {}, function(r) {
				$h("#UserListItems",r);
			});
		};
	</script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
