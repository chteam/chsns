<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewPage<MessageDetailsPas>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>  
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<fieldset>
<legend><%=ViewData.Model.Message.Title%></legend>
发件人:<%=Html.UserPageLink(ViewData.Model.UserOutbox.Id, ViewData.Model.UserOutbox.Name)%><br />
收件人:<%=Html.UserPageLink(ViewData.Model.UserInbox.Id, ViewData.Model.UserInbox.Name)%><br />
发件时间:<%=ViewData.Model.Message.SendTime.ToString("yyyy-MM-dd hh:mm")%><br />
<b>内容:</b><br />
<div class="text">
<%=ViewData.Model.Message.IsHtml
	                  	? ViewData.Model.Message.Body
	                  	: Html.Encode(ViewData.Model.Message.Body)%>
</div>
<%
	if (ViewData.Model.UserInbox.Id == CH.Context.User.UserId){%>
		<textarea cols="40" id="Body" name="Body" rows="6"></textarea>
		<%=Html.Hidden("ToID", ViewData.Model.UserOutbox.Id.ToString())%><br />
		<input class="subbutton" value="发送" type="button" onclick="sub();" />
		<%
	}

%><br />
<a href="<%=Request.UrlReferrer.ToString() %>">返回</a>

</fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
<script type="text/javascript">	function sub() {
		if (v_empty("#Body", "内容不能为空"))
			$.post('<%=Url.Action("SaveAjax","Message") %>',
			{ 'ToID': $v('#ToID'), 'Body': $v('#Body'), 'Title': 'Re:<%=ViewData.Model.Message.Title%>' },
			function() { location = '<%=Url.Action("Outbox","Message") %>'; }
		);
	}</script>
</asp:Content>
