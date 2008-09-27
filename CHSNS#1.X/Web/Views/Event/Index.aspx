<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	CodeBehind="Index.aspx.cs" Inherits="CHSNS.Web.Views.Event.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<% EventPagePas ep = ViewData.Model; %>
	<div class="homeright">
		<%if (ep.FriendRequestCount > 0) { %>
		<div id="Request">
			<h4>
				请求</h4>
			<ul id="chRequest">
				<li><a href="<%=Url.Action("request","Friend") %>"><span class="count">
					<%=ep.FriendRequestCount %></span>个人想加你为好友 </a></li>
			</ul>
		</div>
		<%} %>
		<div id="Count">
			<h4>
				统计</h4>
			<ul>
				<li>共<%=ep.ViewCount %>人访问</li>
				<li><a href="/ReplyList.aspx?userid=$userid&amp;">共有<%=ep.ReplyCount %>条留言</a></li>
			</ul>
		</div>
		<div class="notes">
			<a href="/Blog/index.ashx">进入我的博客</a>
		</div>
		<%if (CHUser.IsAdmin) { %>
		<div id="Event_Admin">
			<h4>
				管理员</h4>
			<ul>
				<li><a href="/admin/admin/index.ashx">管理后台</a></li>
			</ul>
		</div>
		<%} %>
	</div>
	<div class="homemain">
		<div class="imgnew">
			<h4>
				谁最近看过我的页面</h4>
			<%--	##最近看过我页面的列表,一行六列,共六人--%>
			<div class="boxcont">
			<%
					Html.RenderPartial("ViewList", ViewData["lastview"]); %>
			</div>
		</div>
		<%--##新回复--%>
<%--		<div id="NewReply">
		<%if (ep.NewReply.Count != 0) {%>
			<h4>
				最新回复</h4>
			<ul id="chNewReply">
				<%
					}
	foreach (DataRow dr in ep.NewReply) {
		string groupid = dr.IsNull("groupid") ? "" : dr["groupid"].ToString();
		string replytext = dr["isreply"].ToString() == "true" ? "回复了您的留言" : "给你留言了";
				%>
				<li>
					<p>
						<%=Html.ActionLink(dr["name"].ToString(),"Index","User",new {userid=dr["userid"].ToString()}) %>
						在
						<%if (dr["type"].ToString() == "0") { %>
						<%=Html.ActionLink("我的页面","Index","User",new {userid=CHUser.UserID}) %>
						<%} else { %>
						<a href="/Note.aspx?id=logid&amp;groupid=$groupid&amp;">
							<%=dr["title"] %></a>
						<%} %>
						<span class="prefix">
							<%if (dr["type"].ToString() == "0") { %>
							<a href="/ReplyList.aspx?userid=$userid&amp;#id">
								<%=replytext %></a>
							<%} else { %>
							<a href="/Note.aspx?id=logid&amp;groupid=$groupid&amp;">
								<%=replytext %></a>
							<%} %>
						</span><span class="sufix">
							<%=Convert.ToDateTime(dr["addtime"]).ToString("MM-dd HH:mm") %></span>
					</p>
				</li>
				<%} %>
			</ul>
		</div>--%>
		<%--	##新回复完毕 新帖子开始--%>
	<%--	<%if (ep.RssSource.Count != 0) {%>
		#if($RssSource.Count!=0)
		<div id="NewRss" class="imgnew">
			<h4>
				群订阅[<a href="/GroupList.aspx?tabs=0&amp;">more</a>]</h4>
		</div>
		<%
			}%>--%>
		<div id="Event_Event">
			<h4>
				我朋友的动向</h4>
				<ul id="evt_list">
					<% 
						Html.RenderPartial("../user/Index/Event", ViewData["event"]); %>
						</ul>
		</div>
		<div class="imgnew">
			<h4>
				新人秀</h4>
			<%--	##新注册的随机列表,一行六列,共六人--%>
			<div class="boxcont">
				<%
					Html.RenderPartial("ViewList", ViewData["newview"]); %>
			</div>
		</div>
	</div>
	<%--
我的事件页
邹健: 2007年12月26
--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
