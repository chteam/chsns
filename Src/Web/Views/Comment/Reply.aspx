<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewPage<UserCountPas>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
	<%=Html.Script("PageSet") %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<fieldset>
		<legend>
			<%=ViewData.Model.Name %></legend>
		<%
			Html.RenderPartial("Comment/TextBox", ViewData.Model.ID);
		%>
		(共有<span id="FriendCount" class="count"><%=ViewData.Model.Count%></span>条回复)
		<div class="ch_content">
			<div id="PageUp" class="page">
			</div>
			<ul id="ReplyItems" class="userlist">
				<%
					Html.RenderPartial("Comment/Item", ViewData["replylist"]);
				%>
			</ul>
			<div id="PageDown" class="page">
			</div>
			<%=Html.Hidden("PageCount")%>
			<%=Html.Hidden("NowPage") %>
			<%=Html.Hidden("EveryPage","10") %>
		</div>
	</fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">

	<script type="text/javascript">
		var HideReply = function() { $('#cmt_form2').hide(); $('#cmt_form1').show(); $v('#comment_body', ''); };
		var ShowReply = function(n) { $('#cmt_form1').hide(); $('#cmt_form2').show(); if (!n) n = ''; $('#comment_body').focus().val(n); };
		var Reply = function(ownerid) {
			if (v_empty("#comment_body", '不能为空'))
				$.post('<%=Url.Action("AddReply","Comment") %>',
		{ 'UserID': '<%=ViewData.Model.ID %>',
		'Body': $v('#comment_body'), 'ReplyerID': $v('#ReplyerID') },
		function(r) {
			$('#ReplyItems').prepend(r);
			HideReply();
			init_Replyconfirm();
		});
		};
		//init
		var init_Replyconfirm = function() {
			$('.delete').click(function(event) {
				var id = $(this).attr('href');
				$.post('<%=Url.Action("DeleteReply","Comment") %>', { 'id': id }, function(r) {
					showMessage("#Item" + id, '已经删除', 1000);
				});
			}).confirm();
		};
		var WillReply = function(n, senderid) {
			ShowReply('@' + n + '\n');
			$v('#ReplyerID', senderid);
		};
		var EnterReply = function(ownerid, event) {
			if ((event.ctrlKey && event.keyCode == 13) || (event.altKey && event.keyCode == 83)) {
				Reply(ownerid);
			}
		};
		
		var setpage = function(p) {
			$.post('<%=Url.Action("ReplyList") %>', {"p":p,"userid":<%=ViewData.Model.ID %>}, function(r) {
				$h("#ReplyItems",r);
				pagefun();
				init_Replyconfirm();
			});
		};
		pagefun();
		init_Replyconfirm();
	</script>

</asp:Content>
