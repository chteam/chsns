<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Request.aspx.cs" Inherits="CHSNS.Web.Views.Friend.Request" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
	<%=Html.Script("PageSet") %>
	<%=Html.Script("friend")%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div id="UserListMsg">
	</div>
	<h2>
		<%=ViewData["Name"]%>的好友</h2>

	(有<span class="count" id="FriendCount"><%=ViewData["PageCount"]%></span>个人请求加你为好友)
<a href="javascript:IgnoreAllFriend();">忽略所有请求，慎用</a>

	<div class="ch_content">
		<div id="PageUp" class="page">
		</div>
		<ol id="UserListItems" class="userlist">
			<%Html.RenderAction<FriendController>(c => c.RequestList(Convert.ToInt32(ViewData["NowPage"]), ViewData.Model.UserID)); %>
		</ol>
		<div id="PageDown" class="page">
		</div>
	</div>
	<%=Html.Hidden("PageCount")%>
	<%=Html.Hidden("NowPage") %>
	<%=Html.Hidden("EveryPage","10") %>

	<script type="text/javascript">
		var setpage = function(p) {
			$.post("<%=Url.Action("RequestList") %>", {"p":p,"userid":<%=ViewData.Model.UserID %>}, function(r) {
				$h("#UserListItems",r);
				pagefun();
			});
		};
		pagefun();
	</script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
