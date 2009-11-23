<%@ Control Language="C#" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewUserControl" %>
内容(每条最多2000字,请不要发表任何与政治相关的内容)
<br />
<textarea id="comment_body" onkeydown="EnterReply(<%=ViewData.Model%>,event);"
cols="70" rows="7" tabindex="1" class="cmtbody"></textarea><br />
<input type="button" value="留言" onclick="Reply(<%=ViewData.Model%>);"
class="subbutton" tabindex="2" />
<span class="error" id="comment_bodymsg"></span>