<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%
    string key = Model.Id;
    //string listData=
 %>
<%=Html.Label(key)%>

<%=Html.DropDownList(key, new SelectList(ConfigSerializer.Instance.Load<List<SelectListItem>>(Model.ListKey), "Value", "Text"))%>
