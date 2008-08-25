<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Index_MyStatus.ascx.cs"
	Inherits="CHSNS.Web.Views.User.Index_MyStatus" %>
<div>
	<%if (ViewData.Model.IsOnline) { %>
	<a href="#" title="用户在线">在线</a>
	<%} %>
	<span id="Profile_ShowTextTime">
		<%=(ViewData.Model.User.IsNull("ShowTextTime") || ViewData.Model.User.IsNull("ShowText"))?"":
			Url.CH().Str.DateDiv(ViewData.Model.User["ShowTextTime"]) %>
	</span>在 <span id="Profile_ShowText">
		<%if (ViewData.Model.User.IsNull("ShowTextTime") || ViewData.Model.User.IsNull("ShowText")){ %>
		什么也没有做
		<%}else{ %>
		<%=ViewData.Model.User["ShowText"] %>
		<% }%>
	</span>
	<%if(ViewData.Model.IsMe){ %>
	<input type="text" id="Profile_ShowText_Edit" maxlength="12" style="display: none" />
	<%} %>
</div>
