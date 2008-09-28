<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProText.ascx.cs" Inherits="CHSNS.Web.Views.Shared.EventTemplate.ProText" %>
<% Newtonsoft.Json.Linq.JObject  e=ViewData.Model.Json.ToJObject(); %>
<%=Html.UserPageLink(ViewData.Model.OwnerID,e.Value<string>("name") ) %>
更改了状态：<%=e.Value<string>("text")  %>