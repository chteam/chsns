<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MakeFriend.ascx.cs" Inherits="CHSNS.Web.Views.Shared.EventTemplate.MakeFriend" %>
<% Newtonsoft.Json.Linq.JObject  e=ViewData.Model.Json.ToJObject(); %>
<%=Html.UserPageLink(ViewData.Model.OwnerID,e.Value<string>("ownername") ) %>
与<%=Html.UserPageLink(ViewData.Model.ViewerID.Value,e.Value<string>("sendername") ) %>成为好友