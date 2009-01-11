<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="CHSNS.Web.Views.Group.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
<%=Html.Script("PageSet")%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<%
		Note n = ViewData.Model.Note;
		UserCountPas u = ViewData.Model.User;
	%>
	<div class="ch_content">
		<div class="title">
			<%=Html.NoteDetails(n.Title,n.ID ,n.AddTime) %></div>
		<div class="text">
			<%=n.Body %>
			<hr />
			<div class="right option">
				<span class="time">
					<%=n.AddTime .ToString("yyyy-MM-dd hh:mm") %>
				</span>
				<%=Html.NoteList( u.ID,u.Name+"的日志") %>
				<%=Html.UserPageLink(u.ID,u.Name) %>
				阅读(<%=n.ViewCount %>) 评论(<%=n.CommentCount %>)<%-- 推荐(<%=n.PushCount %>)--%>
				<%
					if (n.UserID == CHUser.UserID) {
				%>
				<%=Html.NoteEdit(n.ID, "编辑")%>
				<%
					}
				%></div>
		</div>
		<div>
			<%Html.RenderPartial("CommentList"); %></div>
			<%Html.RenderPartial("Comment/DirectTextBox", n.ID); %>
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">

	<script type="text/javascript">
		var Reply = function(showerid) {
			if (v_empty("#comment_body", '不能为空'))
				$.post('<%=this.Url.Action("Add","Comment") %>',
				{ 'ShowerID': showerid, 'OwnerID': '<%=ViewData.Model.Note.UserID %>',
					'Body': $v('#comment_body'), 'type': 0
				}, function(r) {
					$('#ReplyItems').append(r);
					$("#comment_body").val('');
					init_Replyconfirm();
				});
		};
		//init
		var init_Replyconfirm = function() {
			$('.delete').click(function(event) {
				var id = $(this).attr('href');
				$.post('<%=Url.Action("Delete","Comment") %>', { 'id': id }, function(r) {
					showMessage("#Item" + id, '已经删除', 1000);
				});
			}).confirm();
		};

		var EnterReply = function(ownerid, event) {
			CtrlEnter(event, function() { Reply(ownerid) });
		};

		var setpage = function(p) {
			$.post('<%=Url.Action("List","Comment") %>', { "p": p, "id": '<%=ViewData.Model.Note.ID%>', "type": 0 }, function(r) {
				$h("#ReplyItems", r);
				pagefun();
				init_Replyconfirm();
			});
		};
		pagefun();
		init_Replyconfirm();
	</script>
	
</asp:Content>
