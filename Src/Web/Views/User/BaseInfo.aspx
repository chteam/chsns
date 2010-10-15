<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<BasicInformation>" MasterPageFile="Edit.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="TabContent" runat="server">
    <%using (Html.BeginForm())
      {%>
    <div class="notes">
        [*为必填 其它选填] 请完善以下基本信息
    </div>
    <div class="fieldset">
              <p>
            <%=Html.LabelFor(c => c.ShowLevel)%>
            <%=Html.DropDownListFor(c => c.ShowLevel,EnumHelper.ToSelectList<ShowLevel>())%>
        </p>
        <p>
            <%=Html.LabelFor(c => c.Name)%>
            <%=Html.TextBoxFor(c => c.Name)%>
        </p>
        <p>
            <%=Html.LabelFor(c => c.Sex)%>
            <%=Html.DropDownListFor(c => c.Sex, EnumHelper.ToSelectList<SexType>())%>
        </p>
        <p>
            <%=Html.LabelFor(c => c.Birthday)%>
            <%=Html.TextBoxFor(c => c.Birthday)%>
        </p>
        <p>
            <%=Html.LabelFor(c => c.ProvinceId)%>
            <%=Html.DropDownListFor(c => c.ProvinceId, null, "请选择", new{
                                                                                     @class = "select",
                                                                                     onchange =
                                                                                 "javascript:ChangeProvince()",
                                                                                     id = "ProvinceID"
                                                                                 })%>
            <span id="CityPanel">
                <%=Html.DropDownListFor(c => c.CityId, null, "==请选择==", new {@class = "select", id = "CityID"})%>
            </span><span id="CityStatus"></span>
        </p>
        <p>
            <input type="submit" value="保存修改" class="subbutton" />
        </p>
    </div>
    <%
        }%>
</asp:Content>
