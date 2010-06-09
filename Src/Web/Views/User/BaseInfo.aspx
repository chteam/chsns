<%@  Page Language="C#" Inherits="System.Web.Mvc.ViewPage<BasicInformation>" MasterPageFile="Edit.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="TabContent" runat="server">
<%using (Html.BeginForm())
  { %>
	<div class="notes">
		[*为必填 其它选填] 请完善以下基本信息
	</div>
	<h4>
		基本信息</h4>
	<p>
	<%=Html.LabelFor(c => c.ShowLevel)%>

<%=Html.DropDownListFor(c => c.ShowLevel, Html.GetSelectList("ShowLevel"))%>

	</p>
	<p>
		<label for="name">
			<em>*</em>姓名：</label>
		<%=Html.TextBoxFor(c => c.Name)%>
	</p>
   <p>
		<label for="gender">
			<em>*</em>性别：</label>
		<%=Html.DropDownListFor(c => c.Sex, Html.GetSelectList("Sex"))%>
	</p>
	<p>
		<label for="birthyear">
			*生日：</label>
		<%=Html.TextBoxFor(c => c.Birthday)%>
	</p>
   <p>
		<label for="homeProvince">
			<em>*</em>家乡：</label>
		<%=Html.DropDownListFor(c => c.ProvinceId, null, "请选择", new
{
    @class = "select",
    onchange = "javascript:ChangeProvince()",
    id = "ProvinceID"
})%>
		<span id="CityPanel">
			<%=Html.DropDownList("==请选择==", "CityID", new { @class = "select", id = "CityID" })%>
		</span><span id="CityStatus"></span>
	</p>
	<style type="text/css">
		.embed + img
		{
			position: relative;
			left: -21px;
			top: -1px;
		}
	</style>
	<div class="actions">
		<input type="submit" value="保存修改" class="subbutton" />
        <%--onclick="SBaseInfo();" --%>
	</div>
<%} %>
</asp:Content>
