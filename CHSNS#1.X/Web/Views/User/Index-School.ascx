﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Index_School.ascx.cs"
	Inherits="CHSNS.Web.Views.User.Index_School" %>
<%
	UserPas up = ViewData.Model;
	if (Convert.ToInt16(up.User["Relation"]) >= Convert.ToInt16(up.User["SchoolInfoShowLevel"]) || CHUser.IsAdmin) { 
%>
<div class="accordionHeader" id="school-header">
	学校信息 Schools</div>
<div id="school-content" class="accordionContent">
	<%if (up.IsMe) {%>
	<a href="/EditMyInfo.aspx?mode=School" class="edit">[编辑]</a>
	<%
		}%>
	<ul id="chSchoolInfo">
		<li><span>大　　学：</span><span>
			<%=up.User["University"]%>
			<%--<a href="/Search.aspx?action=show&amp;uid=$user.get_item("University_id")&amp;">
$user.get_item("University")</a>--%>
		</span></li>
		<li><span>院　　系：</span><span>
			<%=Url.CH().DataCache.GetXueyuanName( Convert.ToInt64(up.User["University_id"]),Convert.ToInt64(up.User["Xueyuan_id"]))%>
			<%--<a href="/Search.aspx?action=show&amp;xid=$user.get_item("Xueyuan_id")&amp;">
$ChHelper.DataCache.GetXueyuanName($user.get_item("University_id"),$user.get_item("Xueyuan_id"))</a>
--%>
		</span></li>
		<li><span>入学时间：</span><span>
			<%=up.User["Grade"]%>
			<%--<a href="/Search.aspx?action=show&amp;grade=$user.get_item("Grade")&amp;uid=$user.get_item("University_id")&amp;">
$user.get_item("Grade")</a>--%></span></li>
		<%if (!up.User.IsNull("UniClass_id")) { %>
		<li><span>所在班级：</span><span><%=up.User["UniClass"]%><%--<a href="/Group.aspx?id=$user.get_item("UniClass_id")&amp;">
$user.get_item("UniClass")</a>--%></span></li>
		<%} %>
	</ul>
</div>
<%} %>