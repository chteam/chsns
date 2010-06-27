<%@ Control Language="C#" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewUserControl<Event>" %>
<%var  e=ViewData.Model.Json.ToJObject(); %>
<%=Html.UserPageLink(ViewData.Model.OwnerId,e["name"].ToString() ) %>
更改了状态：<%= e["text"].ToString() %>