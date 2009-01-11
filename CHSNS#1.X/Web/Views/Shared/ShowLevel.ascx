<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowLevel.ascx.cs" Inherits="CHSNS.Web.Views.Shared.ShowLevel" %>
<%
	var model=ViewData.Model as ShowLevelOption;
	Writer.Write(Html.DropDownList("", model.ID,
				new SelectList(
					ConfigSerializer.GetConfig("ShowLevel")
					, "Value", "Text", model.SelectedValue)
		, new { @class = "select" }));%>



