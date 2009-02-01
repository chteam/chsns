<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
	<%=Html.Script("PageSet") %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<fieldset>
	<legend><%=ViewData["Name"]%>的好友</legend>
	
	<div id="UserListMsg">
	</div>
	<a href="/Invite.aspx">邀请朋友加入</a> 
	
	(共有<span id="FriendCount" class="count"><%=ViewData["PageCount"]%></span>个好友)
	<div class="ch_content">
		<div id="PageUp" class="page">
		</div>
		<ol id="UserListItems" class="userlist">
			<%
				Html.RenderPartial("FriendList", ViewData.Model); %>
		</ol>
		<div id="PageDown" class="page">
		</div>
	</div>
	<%=Html.Hidden("PageCount")%>
	<%=Html.Hidden("NowPage") %>
	<%=Html.Hidden("EveryPage","10") %>
</fieldset>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
	<script type="text/javascript">
		var DeleteFriend=function(id){
			$.post('<%=Url.Action("Delete","Friend") %>', {'toid':id}, function(r) { 
				alertEx(r);
				var count=0;
				count=$h("#FriendCount");
				if(count>0)
					$h("#FriendCount",count-1);
				$h("#Items"+id,'已经删除');
			});
		};
		var setpage = function(p) {
			$.post('<%=Url.Action("FriendList") %>', {"p":p,"userid":<%=ViewData["UserID"] %>}, function(r) {
				$h("#UserListItems",r);
				pagefun();
			});
		};
		pagefun();
	</script>
</asp:Content>
