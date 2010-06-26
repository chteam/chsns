<%@ Control Language="C#" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewUserControl<Event>" %>
<% Hashtable e = ViewData.Model.Json.ToJObject(); %>

<%=Html.UserPageLink(ViewData.Model.OwnerId,e["name"].ToString()) %>
于<%=Convert.ToDateTime(e["addtime"]).Ago()%> 发表日志
<%=Html.NoteDetails(e["title"].ToString(), Convert.ToInt64(e["id"]), Convert.ToDateTime(e["addtime"]))%>