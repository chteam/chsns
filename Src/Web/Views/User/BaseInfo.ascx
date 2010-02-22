<%@ Control Language="C#" AutoEventWireup="true"  Inherits="System.Web.Mvc.ViewUserControl" %>
<form id="BasicInfofrm">
<div class="notes">
	[*为必填 其它选填] 请完善以下基本信息
</div>
<h4>
	基本信息</h4>
<div class="required">
	<label for="gender">
		<em>*</em>可见度：</label>
	<%=Html.DropDownList("","b.ShowLevel", new { @class = "select" })%>
</div>
<div class="required">
	<label for="name">
		<em>*</em>姓名：</label>
	<%=Html.TextBox("b.Name") %>
</div>
<div class="required">
	<label for="gender">
		<em>*</em>性别：</label>
	<%=Html.DropDownList("请选择","b.Sex", new { @class = "select" })%>
</div>
<div class="required">
	<label for="birthyear">
		*生日：</label>
	<%=Html.TextBox("b.Birthday", null, new {
	id="Birthday",
	onclick = "$('#Birthday').datepicker();$('#Birthday').datepicker('show');" })%>
</div>
<div class="required">
	<label for="homeProvince">
		<em>*</em>家乡：</label>
	<%=Html.DropDownList("请选择","b.ProvinceID", new {
	@class = "select", onchange = "javascript:ChangeProvince()", id = "ProvinceID"
})%>
	<span id="CityPanel">
	<%=Html.DropDownList("==请选择==", "b.CityID", new { @class = "select", id = "CityID" })%>
	</span><span id="CityStatus"></span>
</div>

<style type="text/css">
	.embed + img { position: relative; left: -21px; top: -1px; }
</style>
<div class="actions">
	<input type="button" value="保存修改" class="subbutton" onclick="SBaseInfo();" />
</div>
</form>
