<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl<UserPas>" %>
<%--<% 
	//实名
	if (ViewData.Model.Profile.Status.Equals(Ro)) { 
%>
<a href="#" title="实名用户" id="Profile_Isstar" class="s_icon">&nbsp;&nbsp;&nbsp;</a>
<% 
	if (CH.Context.User.IsAdmin) {
%>
<a href="javascript:Admin_Isstar_Remove(<%=ViewData.Model.OwnerID%>);">置为非实名</a>
<%
	}
	}
	else {

		if (CH.Context.User.IsAdmin) {
%>
<a href="javascript:Admin_Isstar_Add(<%=ViewData.Model.OwnerID%>);">置为实名</a>
<%
	}
	}%>--%>
	
<%if (ViewData.Model.IsOnline) { %>
<a href="#" title="用户在线">在线</a>
<%} %>
<%--&lt;<span id="pro_text">
	<%if (!ViewData.Model.Profile.ShowTextTime.HasValue || string.IsNullOrEmpty(ViewData.Model.Profile.ShowText)) { %>
	闲着
	<%}
   else { %>
	<%=ViewData.Model.Profile.ShowText %>
	<% }%>
</span>
<%if (ViewData.Model.IsMe) { %>
<input type="text" id="pro_edit" maxlength="12" style="display: none" />

<script type="text/javascript">
	dc_edit('#pro_text', '#pro_edit', '#pro_time', function(t) {
		$.post('<%=Url.Action("SaveText","Profile") %>', { 'text': t });
	});
</script>

<%} %>
&gt; <span id="pro_time">
	<%=(!ViewData.Model.Profile.ShowTextTime.HasValue|| string.IsNullOrEmpty(ViewData.Model.Profile.ShowText))?"":
						ViewData.Model.Profile.ShowTextTime.Value.Ago()%>
</span>更新 --%>