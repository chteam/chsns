<%@ Control Language="C#" AutoEventWireup="true" 
Inherits="System.Web.Mvc.ViewUserControl<ShowLevelOption>" %>
<% 
    var model = ViewData.Model;
    if (model != null)
        Writer.Write(Html.DropDownList(model.ID,
                                       new SelectList(
                                           ConfigSerializer.Instance.Load<List<CHSNS.ListItem>>("ShowLevel")
                                        , "Value", "Text", model.SelectedValue)
                                       , new {@class = "select"}));
    %>

