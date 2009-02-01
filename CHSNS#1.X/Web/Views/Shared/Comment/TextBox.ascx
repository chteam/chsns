<%@ Control Language="C#" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewUserControl" %>
<p id="cmt_form1">
	<input class="subbutton" value="我要留言" onclick="ShowReply();" type="button" />
</p>
<div id="cmt_form2" style="display: none;">
	<input type="button" value="留言" onclick="Reply(<%=ViewData.Model%>);" class="subbutton"
		tabindex="2" />
	(每条最多2000字)
	<input value="取消" class="subbutton" onclick="HideReply();" tabindex="3" type="button" />
	<span class="error" id="comment_bodymsg"></span>
	<br />
	<textarea id="comment_body" cols="70" rows="7" onkeydown="EnterReply(<%=ViewData.Model%>,event);" tabindex="1" class="cmtbody"></textarea>
	<input type="hidden" value="0" id="ReplyerID" />
</div>
