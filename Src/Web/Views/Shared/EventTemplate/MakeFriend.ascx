<%@ Control Language="C#" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewUserControl<EventLog>" %>
<% var  e=ViewData.Model.Json.ToJObject(); %>
<%=Html.UserPageLink(ViewData.Model.OwnerId, e["ownername"].ToString())%>
与<%=Html.UserPageLink(ViewData.Model.ViewerId.Value,e["sendername"].ToString() ) %>成为好友