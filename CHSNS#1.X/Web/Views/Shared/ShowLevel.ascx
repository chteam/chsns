<%@ Control Language="C#" AutoEventWireup="true" 
Inherits="System.Web.Mvc.ViewUserControl" %>
<%
	var model = ViewData.Model as ShowLevelOption;
	if (model != null)
		Writer.Write(Html.DropDownList("", model.ID,
		                               new SelectList(
		                               	ConfigSerializer.GetConfig("ShowLevel")
		                               	, "Value", "Text", model.SelectedValue)
		                               , new {@class = "select"}));
	%>



