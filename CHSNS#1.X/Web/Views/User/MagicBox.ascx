<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="notes">
	<a href="javascript:SMagicBox('backup');" onclick="var bl=confirm('确定要把你的魔法盒内容发送到你的站内信件中吗？'); if(bl){return true} else {return false;}">
		备份魔法盒</a> <a href="javascript:SMagicBox('');$v('#MagicBox','')" id="clear">清空魔法盒</a>
</div>
<div class="required center">
	<%=Html.TextArea("MagicBox",ViewData["magicbox"].ToString(),20,90,new {@class="textarea"} )%>
</div>
<div class="actions">
	<input class="subbutton" type="button" value="保存修改" onclick="SMagicBox($v('#MagicBox'));" />
</div>
