﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CHSNS.Models.Account>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    
    
    <script src="/Scripts/jquery.validate.min.js" type="text/javascript"></script>
    <script src="/Scripts/MicrosoftMvcJQueryValidation.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div  class="centerform">
        <%
            Html.EnableClientValidation();
            using (Html.BeginForm())
            {%>
        <%: Html.ValidationSummary(true) %>
        <div id="loginForm" class="formset">
            <p>
                <%: Html.LabelFor(model => model.UserName) %>
                <%: Html.TextBoxFor(model => model.UserName) %>
                <%: Html.ValidationMessageFor(model => model.UserName) %>
            </p>
            <p>
                <%: Html.LabelFor(model => model.Password) %>
                <%: Html.PasswordFor(model => model.Password) %>
                <%: Html.ValidationMessageFor(model => model.Password) %>
            </p>
            <p>
                <%:Html.Hidden("ReturnUrl")%>
                <%:Html.CheckBox("autoLogOn") %>
                &nbsp;下次自动登录
            </p>
            <p>
                <input type="submit" value="登录" />
                <a href="/help/getcode.aspx">忘了密码?</a></p>
        </div>
        <% } %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
