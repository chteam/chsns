<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="S.aspx.cs" Inherits="FlexigridMvcDemo.S" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>  	<script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
	<%if (false)
	  {
	%>

	<script src="http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>

	<%
		} %>
	<script src="Scripts/menu/contextmenu.pack.js" type="text/javascript"></script>
	<script src="Scripts/flexigrid/flexigrid.pack.js" type="text/javascript"></script>
	<link href="Content/flexigrid/flexigrid.css" rel="stylesheet" type="text/css" />
	<link href="Content/menu/cm_default/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
  <%= new FlexiGridSettings<FlexigridMvcDemo.Models.UserInfo>()
           .Name("flex1")
           .UpdateAction("/Ajax/GetEntity")
           .Columns(col => 
               {
                   col.Bind(e => e.Id).Title("Id");
                   col.Bind(e => e.Name).Width(180).Title("Name").Sortable().Align(FlexiGridAlign.Left);
                   col.Bind(e => e.Email).Title("email");
                   col.Bind(e => e.Age).Width(180).Title("Age").Sortable().Align(FlexiGridAlign.Right); ;
               })
            .DefaultSortOption("Id", FlexiGridSortOrder.Ascending)
            .UsePager()
            .Title("Employees")
            .RecordsPerPageOption(true, 15)
            .ShowTableToggleButton(false)
            .Width(800)
            .Height(200) %>

    </div>
    </form>
</body>
</html>
