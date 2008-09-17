<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="body-wrap">
	<h1>
		系统事件管理</h1>
	<div class="description">
		操作:
		<input type="button" id="newTemp" class="x-form-button x-form-field" value="新建"
 onclick="ShowDialog(Ext.get('newTemp'),'添加模板',function(){
$('#win-panel').html('<div id=Addform>'+$h('#AddFormTemplate')+'</div>');
 });"
 /><br />
		说明:
	</div>
	<div class="hr">
	</div>
	<h2>
		模板列表</h2>
	<table cellspacing="0" class="member-table">
		<tr>
			<th class="sig-header" colspan="2">
				模板
			</th>
			<th class="msource-header">
				操作
			</th>
		</tr>
		<%foreach (System.Web.Mvc.ListItem i in ViewData["source"] as List<System.Web.Mvc.ListItem>)
	{%>
		<tr class="method-row alt">
			<td class="micon">
				<a class="exi" href="#expand">&nbsp;</a>
			</td>
			<td class="sig">
				名称:<%=i.Value %>
				<div class="mdesc">
					功能:<%=i.Text %>
				</div>
			</td>
			<td class="msource">
				<input type="button" id="asdf" value="查看" onclick="ShowDialog(Ext.get('asdf'),'<%=i.Value %>',
function(){$.get('<%=Url.Action("GetSystemTemplate","Event") %>',{'name':'<%=i.Value %>'},
function(r){$('#win-panel').html(r);})});" />
			</td>
			<%} %>
		</tr>
	</table>
	<div id="AddFormTemplate" style="display: none">
		模板名:<input id="Value" type="text" class="x-form-text x-form-field"><br>
		模板描述:<input id="Title" type="text" class="x-form-text x-form-field"><br>
		模板内容:<textarea cols="20" id="Content" rows="5" class="x-form-field"></textarea><br>
		<input type="button" onclick="$.post('<%=Url.Action("AddSystemTemplate","Event") %>',
{'v':$v('#Addform > #Value'),'t':$v('#Addform > #Title'),'c':$v('#Addform > #Content')},
function(r){Ext.MessageBox.alert('状态', r);win.hide();});"
value="保存" class="x-form-button x-form-field" />
	</div>
	<input type="button" onclick="debuger;" />
</div>
