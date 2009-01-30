<%@ Control Language="C#" AutoEventWireup="true" 
Inherits="System.Web.Mvc.ViewUserControl" %>
<%if(TempData.ContainsKey("Page_Message")) {%>
<div class="error message center graybox"><%=TempData["Page_Message"]%></div>
<%} %>