﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Event.ascx.cs" Inherits="CHSNS.Web.Views.User.Event" %>
<ul id="evt_list">
	<% foreach (CHSNS.Models.Event e in ViewData.Model)
	{ %>
	<li class="evt_icon " id="evt_<%=e.ID %>">
		<%Html.RenderPartial("EventTemplate/" + e.TemplateName, e);%>
		#showdel( ${id} ${fromid} ) </li>
	<%} %>
</ul>
