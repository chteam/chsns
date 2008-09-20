<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Event.ascx.cs" Inherits="CHSNS.Web.Views.User.Event" %>
<% foreach(CHSNS.Models.Event e in ViewData.Model){ %>
<%=e.TemplateName %>
<%=e.EntityKey %>
<%=e.EntityState %>
<%} %>