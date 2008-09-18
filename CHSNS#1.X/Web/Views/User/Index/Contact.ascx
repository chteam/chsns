<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Contact.ascx.cs"
	Inherits="CHSNS.Web.Views.User.Index_Contact" %>
<% UserPas up = ViewData.Model;
   if (Convert.ToInt16(up.User["Relation"]) >= Convert.ToInt16(up.User["ContactInfoShowLevel"]) || CHUser.IsAdmin) {
%>
<a href='#' class="accordionHeader" id="contact-header">联系方式 Contacts</a>
<%--<div class="accordionHeader" id="contact-header">
	联系方式 Contacts</div>--%>
<div id="contact-content" class="accordionContent">
		<ul id="chContactInfo">
	<%if (up.IsMe) {%>
	<li><a href="/EditMyInfo.aspx?mode=Contact" class="edit">[编辑]</a></li>
	<%
		}
   Dictionary dict = new Dictionary();
   dict.Add("Ｑ　　Ｑ", "QQ");
   dict.Add("固定电话", "TelPhone");
   dict.Add("Ｕ　　Ｃ", "UC");
   dict.Add("网易泡泡", "NeteasePop");
   dict.Add("手　　机", "Mobiephone");
   dict.Add("ＭＳＮ　", "msn");
   dict.Add("网　　站", "WebSite");
	%>

		<% foreach (KeyValuePair<string, object> kv in dict) {
		 if (!up.User.IsNull(kv.Value.ToString()) && !string.IsNullOrEmpty(up.User[kv.Value.ToString()].ToString())) {
		%>
		<li><span>
			<%=kv.Key %>：</span><span><%=up.User[kv.Value.ToString()] %></span></li>
		<%}
	 }%>
	</ul>
</div>
<%} %>