<%@  Page Language="C#" Inherits="System.Web.Mvc.ViewPage<BasicInformation>" MasterPageFile="Edit.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="TabContent" runat="server">
    <form id="BasicInfofrm">
    <div class="notes">
        [*为必填 其它选填] 请完善以下基本信息
    </div>
    <h4>
        基本信息</h4>
    <div>
    <%=Html.LabelFor(c=>c.ShowLevel)%>

<%=Html.DropDownListFor(c => c.ShowLevel, Html.GetSelectList("ShowLevel"))%>

    </div>
    <div class="required">
        <label for="name">
            <em>*</em>姓名：</label>
        <%=Html.TextBoxFor(c=>c.Name) %>
    </div>
    <%--<div class="required">
        <label for="gender">
            <em>*</em>性别：</label>
        <%=Html.DropDownList("请选择","Sex", new { @class = "select" })%>
    </div>
    <div class="required">
        <label for="birthyear">
            *生日：</label>
        <%=Html.TextBoxFor(c=>c.Birthday)%>
    </div>
    <div class="required">
        <label for="homeProvince">
            <em>*</em>家乡：</label>
        <%=Html.DropDownList("请选择","ProvinceID", new {
	@class = "select", onchange = "javascript:ChangeProvince()", id = "ProvinceID"
})%>
        <span id="CityPanel">
            <%=Html.DropDownList("==请选择==", "CityID", new { @class = "select", id = "CityID" })%>
        </span><span id="CityStatus"></span>
    </div>--%>
    <style type="text/css">
        .embed + img
        {
            position: relative;
            left: -21px;
            top: -1px;
        }
    </style>
    <div class="actions">
        <input type="button" value="保存修改" class="subbutton" onclick="SBaseInfo();" />
    </div>
    </form>
</asp:Content>
