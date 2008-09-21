<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddNote.ascx.cs" Inherits="CHSNS.Web.Views.Shared.EventTemplate.AddNote" %>
<% Newtonsoft.Json.Linq.JObject e = ViewData.Model.Json.ToJObject(); %>

<%=Html.UserPageLink(ViewData.Model.OwnerID,e.Value<string>("name")) %>
于<%=e.Value<DateTime>("addtime").Ago()%> 发表日志
<%=Html.NoteDetails(e.Value<string>("title"), e.Value<long>("id"), e.Value<DateTime>("addtime"))%>