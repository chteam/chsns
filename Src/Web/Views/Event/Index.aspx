<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
Inherits="System.Web.Mvc.ViewPage<EventIndexViewModel>" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<% EventPagePas ep = ViewData.Model.Page; %>
	<div class="right">
		<%if (ViewData.Model.Context.User.IsAdmin)
    { %>
		<div id="Event_Admin">
			<h4>
				管理员</h4>
			<ul>
				<li>
				<%=Html.ActionLink("管理后台","Index","Admin")%></li>
			</ul>
		</div>
		<%} %>
		<div class="box">
			<h4>
				谁最近看过我的页面</h4>
			<%
				Html.RenderPartial("ViewList", ViewData.Model.LastViews); %>
		</div>
		<div class="box">
			<h4>
				好友</h4>
			<%
                Html.RenderPartial("ViewList", ViewData.Model.NewViews); %>
		</div>
	</div>
	<div class="left">
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
						<%=Html.ActionLink("我的页面","Index","User",new {userid=CH.Context.User.UserID}) %>
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
		<div class="graybox">
			<h4>
				统计</h4>
			<span>共<%=ep.ViewCount %>人访问</span> 
			<%--<span><a href="/ReplyList.aspx?userid=$userid&amp;">
				共有<%=ep.ReplyCount %>条留言</a></span>--%>
	<%--		<%if (ep.FriendRequestCount > 0) { %>
			<span><a href="<%=Url.Action("request","Friend") %>"><span class="count">
				<%=ep.FriendRequestCount %></span>个人想加你为好友 </a></span>
			<%} %>--%>
		</div>
		<div class="graybox">
			<h4>
				我朋友的动向</h4>
			<ul id="evt_list">
		<%--		<% 
                    Html.RenderPartial("../user/Index/Event", ViewData.Model.Events); %>--%>
			</ul>
		</div>
	</div>
	<%--
我的事件页
邹健: 2007年12月26
--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
