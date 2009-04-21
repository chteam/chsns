<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
Inherits="System.Web.Mvc.ViewPage<UserPas>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
	<%=Html.CSSLink("Reply")%>
<%--	<%=Html.CSSLink("mypage")%>
	<%=Html.CSSLink("home")%>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<% 
		UserPas up = ViewData.Model;
		if (!up.Exists) {
			Html.RenderPartial("index/noRight", ViewData.Model);
		}
		else {
			if (up.Exists && up.Profile.IsMagicBox) {%>
	<%="<style type=\"text/css\">" + up.Profile.MagicBox + "</style>"%>
	<%
		}
	%>
	<div class="curtain">
	<div id="userUpdates">
		<div id="userStatus">
			<h2>
				<%=up.Profile.Name%></h2>
			<div class="mypage_sta">
				<% Html.RenderPartial("index/mystatus", ViewData.Model);/*状态*/%>
			</div>
		</div>
		<div id="userAccount">
			<div class="box" id="UserInformation">
				<ul id="Profile_Accordion">
					<li>
						<%
							Html.RenderPartial("index/account", ViewData.Model);%></li>
					<%--					<li><%
   	Html.RenderPartial("index/school", ViewData.Model);%></li>
					<li><%
   	Html.RenderPartial("index/contact", ViewData.Model);%></li>
					<li><%
   	Html.RenderPartial("index/personal", ViewData.Model);%></li>--%>
				</ul>
 
				<script type="text/javascript">
					//$("#Profile_Accordion").accordion();
					//	new Accordian().Show('#Profile_Accordion', 3, 'accordionHeaderSelected');
				</script>

				<div class="box">
					<h3>
						<%=up.Profile.Name%>的动向</h3>
					<ul id="evt_list">
						<% 
							Html.RenderPartial("Index/Event", ViewData["event"]); %>
					</ul>
				</div>
			</div>
		</div>
		<%--	<div class="box" id="userBlog">
			<h3>
				<%=up.OwnerName%>的日志</h3>
			<div class="boxcont">
				<ol id="blog">
					##<日志>
					#component(NoteList with "source=$log1source" "template=First") #component(NoteList
					with "source=$log2source" "template=Second")
				</ol>
			</div>
			<p class="more">
				<%if (up.IsMe) {%>
				<a href="/Notebook.aspx?mode=write">写新日志</a>
				<%} %>
				<a href="/Notebook.aspx?userid=<%=up.OwnerID%>">所有日志</a>
			</p>
		</div>
		
	<script type="text/javascript">
		ShoworHide("#userBlog", "blog");
	</script>

		--%>
		<div class="box" id="userTalk">
			<h3>
				<%=up.Profile.Name%>的留言板</h3>
			<%
				Html.RenderPartial("Comment/TextBox", up.OwnerID);
			%>
			<ul id="ReplyItems" class="userlist">
				<%
					Html.RenderPartial("Comment/Item", ViewData["replylist"]);
				%>
			</ul>
			<p class="more"><%=Html.ReplyList(up.OwnerID, "所有留言")%></p>
		</div>
	</div>
	<div id="userRelations">
		<div class="box" id="userInfo">
			<div id="userPicture">
				<div id="userFace">
					<ul>
						<li><a href="#<%=up.OwnerID%>">
							<%=Html.Image(CHSNS.Path.GetFace(up.OwnerID,ThumbType.Big), up.Profile.Name)%>
						</a></li>
					</ul>
				</div>
			</div>
			<%
				Html.RenderPartial("index/Myactions", ViewData.Model);%>
		</div>
		<div class="box">
			<h3>
				用户相关</h3>
			<div class="mypadding">
				<%--
				<a href="/SuperNote.aspx?userid=<%=up.OwnerID%>">视频</a>
				<a href="/Photos.aspx?userid=<%=up.OwnerID%>">相册</a>--%>
				<%=Html.NoteList(up.OwnerID,"日志") %>
			</div>
		</div>
		<div class="box">
			<div id="userViewer">
				<h3>
					最近访问<span class="stat">(共<%=up.Profile.ViewCount%>人看过)</span></h3>
				<%
					Html.RenderPartial("ViewList", ViewData["lastview"]); 
				%>
			</div>
		</div>
		<div class="box">
			<h3>
				<%=up.Profile.Name%>最近登录的好友</h3>
			<%
				Html.RenderPartial("ViewList", ViewData["lastfriend"]); %>
			<span class="more"><a href="/friend.aspx?userid=<%=up.OwnerID%>">more</a></span>
		</div>
		<%--		<div class="box">
			<h3>
				<%=up.OwnerName%>加入的群</h3>
			<div class="mypadding">
				<% Html.RenderAction<GroupController>(c => c.ShowGroupList("ShowProfileLinks", up.OwnerID
		   , 0, 1, 100, 0)); %> 
			</div>
		</div>--%>
	</div>
	</div>
	<%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">

	<script type="text/javascript">
		//reply
		var HideReply = function() { $('#cmt_form2').hide(); $('#cmt_form1').show(); $v('#comment_body', ''); };
		var ShowReply = function(n) { $('#cmt_form1').hide(); $('#cmt_form2').show(); if (!n) n = ''; $('#comment_body').focus().val(n); };
		var Reply = function(ownerid) {
			if (v_empty("#comment_body", '不能为空'))
				$.post('<%=Url.Action("AddReply","Comment") %>',
		{ 'UserID': '<%=ViewData.Model.OwnerID %>', 'Body': $v('#comment_body'), 'ReplyerID': $v('#ReplyerID') },
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
		var init_evt = function() {
			$('#evt_list .evt_del').click(function(event) {
				var id = $(this).attr('href');
				$.post('<%=Url.Action("EventDelete") %>', { 'id': id }, function(r) {
					$("#evt_list").html(r);
					init_evt();
				});
				return false;
			});
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
		init_Replyconfirm();
		init_evt();
	</script>

</asp:Content>
