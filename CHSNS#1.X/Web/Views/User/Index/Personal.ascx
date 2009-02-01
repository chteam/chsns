<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl<UserPas>" %>
<% UserPas up = ViewData.Model;
   if (Convert.ToInt16(up.User["Relation"]) >= Convert.ToInt16(up.User["PersonalInfoShowLevel"]) || CHUser.IsAdmin) {
%>
<a href='#' class="accordionHeader" id="personal-header">个人信息 Interests</a>
<%--<div class="accordionHeader" id="personal-header">
	个人信息 Interests</div>--%>
<div id="personal-content" class="accordionContent">
		<ul id="chPersonalInfo">
	<%if (up.IsMe) {%>
	<li><a href="/EditMyInfo.aspx?mode=Basic" class="edit">[编辑]</a></li>
	<%
		}
   Dictionary dict = new Dictionary();
   dict.Add("兴趣爱好", "lovelike");
   dict.Add("喜欢书籍", "lovebook");
   dict.Add("喜欢音乐", "lovemusic");
   dict.Add("喜欢电影", "lovemovie");
   dict.Add("喜欢动漫", "lovecomic");
   dict.Add("喜欢运动", "lovesports");
   dict.Add("加入社团", "joinsociety");
	%>
		<% foreach (KeyValuePair<string, object> kv in dict) {
		 if (!up.User.IsNull(kv.Value.ToString()) && up.User[kv.Value.ToString()].ToString().Length > 1) {
		%>
		<li class="userProfileItemValue"><span>
			<%=kv.Key %>：</span>
			<%foreach (string s in up.User[kv.Value.ToString()].ToString().Split(',')) { %>
			<a href="/Search.aspx?action=Personal&<%=kv.Value.ToString() %>=<%=Url.Encode(s) %>&University=<%=Url.Encode(up.User["University"].ToString())%>&">
				<%=s %></a>
			<%} %>
		</li>
		<%}
	 }%>
	</ul>
</div>
<%} %>