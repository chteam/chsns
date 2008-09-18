<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyStatus.ascx.cs"
	Inherits="CHSNS.Web.Views.User.Index_MyStatus" %>
<div>
	<%if (ViewData.Model.IsOnline) { %>
	<a href="#" title="用户在线">在线</a>
	<%} %>
	<span id="Profile_ShowTextTime">
		<%=(!ViewData.Model.Profile.ShowTextTime.HasValue|| string.IsNullOrEmpty(ViewData.Model.Profile.ShowText))?"":
						Url.CH().Str.DateDiv(ViewData.Model.Profile.ShowTextTime.Value)%>
	</span>在 <span id="Profile_ShowText">
		<%if (!ViewData.Model.Profile.ShowTextTime.HasValue || string.IsNullOrEmpty(ViewData.Model.Profile.ShowText)) { %>
		什么也没有做
		<%}else{ %>
		<%=ViewData.Model.Profile.ShowText %>
		<% }%>
	</span>
	<%if(ViewData.Model.IsMe){ %>
	<input type="text" id="Profile_ShowText_Edit" maxlength="12" style="display: none" />
	<%} %>
</div>
