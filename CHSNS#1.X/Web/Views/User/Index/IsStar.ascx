<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IsStar.ascx.cs"
	Inherits="CHSNS.Web.Views.User.Index_IsStar" %>
<%
	if (ViewData.Model.Profile.IsStar) { 
%>
<a href="#" title="实名用户" id="Profile_Isstar" class="s_icon">&nbsp;&nbsp;&nbsp;</a>
<% 
	if (CHUser.IsAdmin) {
%>
<a href="javascript:Admin_Isstar_Remove(<%=ViewData.Model.OwnerID%>);">置为非实名</a>
<%
	}
	} else {

		if (CHUser.IsAdmin) {
%>
<a href="javascript:Admin_Isstar_Add(<%=ViewData.Model.OwnerID%>);">置为实名</a>
<%
	}
	}
%>
