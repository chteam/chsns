<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Message_Box.ascx.cs" Inherits="CHSNS.Web.Views.Shared.Message_Box" %>
<%if(TempData.ContainsKey("Page_Message")) {%>
<div class="error message center graybox"><%=TempData["Page_Message"]%></div>
<%} %>