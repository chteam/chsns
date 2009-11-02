<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
Inherits="ViewPage<FriendRequest>" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
	<%=Html.Script("PageSet") %>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div id="UserListMsg">
	</div>
	<h2>
		<%=Model.Profile.Name%>的好友</h2>
	(有<span class="count" id="FriendCount"><%=Model.Items.TotalCount%></span>个人请求加你为好友)
	<a href="javascript:IgnoreAllFriend();">忽略所有请求，慎用</a>
	<div class="ch_content">
		<div id="PageUp" class="page">
		</div>
		<ol id="UserListItems" class="userlist">
			<%Html.RenderPartial("RequestList", Model.Items); %>
		</ol>
		<div id="PageDown" class="page">
		</div>
	</div>
	<%=Html.Hidden("PageCount",Model.Items.TotalPages)%>
	<%=Html.Hidden("NowPage",Model.Items.CurrentPage ) %>
	<%=Html.Hidden("EveryPage",Model.Items.PageSize) %>

	<script type="text/javascript">
	function AgreeFriend(id){
	$.post('<%=Url.Action("Agree") %>', {"uid":id}, function(r) {
		alertEx(r);
		var count = 0;
		count = $h("#FriendCount");
		if (count > 0)$h("#FriendCount",count-1);
		$h("#Items" + id,'已经加为好友');
	});
	}
	//忽略好友请求
	function IgnoreFriend(id) {
		if (confirm('确定忽略此请求吗？')) 	
		$.post('<%=Url.Action("Ignore") %>', {"uid":id}, function(r) {
			alertEx(r);
			var count = 0;
			count = $h("#FriendCount");
            if (count > 0)
                $h("#FriendCount",count-1);
            $h("#Items" + id,'已经删除');
		});
	}
	function IgnoreAllFriend() {
		if (confirm('确定忽略所有请求吗？')) 	
		$.post('<%=Url.Action("IgnoreAll") %>', {}, function(r) {
			alertEx(r);
			$h("#UserListItems",'');
		});
	}
	var setpage = function(p) {
		$.post('<%=Url.Action("RequestList") %>', {"p":p,"userid":<%=Model.Profile.UserId %>}, function(r) {
			$h("#UserListItems",r);
			pagefun();
		});
	};
	pagefun();
	</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
