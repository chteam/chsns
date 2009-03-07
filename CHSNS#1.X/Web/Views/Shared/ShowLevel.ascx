<%@ Control Language="C#" AutoEventWireup="true" 
Inherits="System.Web.Mvc.ViewUserControl<ShowLevelOption>" %>
<%@ Import Namespace="CHSNS" %>
<%
	var model = ViewData.Model;
	if (model != null)
		Writer.Write(Html.DropDownList(model.ID,
		                               new SelectList(
                                           CH.Context.ConfigSerializer.Load<List<CHSNS.ListItem>>("ShowLevel")
		                               	, "Value", "Text", model.SelectedValue)
		                               , new {@class = "select"}));
	%>

