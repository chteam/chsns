﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    Inherits="System.Web.Mvc.ViewPage<CHSNS.Models.RegisterModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <script src="/Scripts/jquery.validate.min.js" type="text/javascript"></script>
    <script src="/Scripts/MicrosoftMvcJQueryValidation.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        Html.EnableClientValidation();
        using (Html.BeginForm())
        {  %>
    <div class="formset centerform">
        <p>
            <%: Html.LabelFor(model => model.UserName) %>
            <%: Html.TextBoxFor(model => model.UserName) %>
            <%: Html.ValidationMessageFor(model => model.UserName) %>
            - 例如：chsword
        </p>
        <p>
            <%: Html.LabelFor(model => model.Password) %>
            <%: Html.PasswordFor(model => model.Password) %>
            <%: Html.ValidationMessageFor(model => model.Password) %>
            - 由6-20字母或数字组成
        </p>
        <p>
            <%: Html.LabelFor(model => model.RePassword) %>
            <%: Html.PasswordFor(model => model.RePassword)%>
            <%: Html.ValidationMessageFor(model => model.RePassword)%>
            - 请在输入一遍</p>
        <p>
            <%: Html.LabelFor(model => model.Nickname) %>
            <%: Html.TextBoxFor(model => model.Nickname)%>
            <%: Html.ValidationMessageFor(model => model.Nickname)%>
            - 请填写昵称，用于在网站上显示</p>
        <p>
            我同意以下条款 并
            <input type="submit" value=" 注 册 " />
        </p>
    </div>
    <%} %>
    <fieldset class="regagreement">
        <legend>注册协议</legend>
        <div class="regtext">
            <br />
        </div>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
    <script type="text/javascript">
        (function () {
            var _dict = new Array();
            var un = $("#username");
            var _msg = function (r) { un.valiMsg(r ? '可以使用' : '用户名已经有人使用', null, !r); };
            un.blur(function () {
                var _v = _dict[un.val()];
                if (_v) {
                    _msg(_v);
                } else {
                    $.post('<%=Url.Action("UsernameCanUse") %>', { 'username': un.val() }, function (r) {
                        _dict[un.val()] = r;
                        _msg(r);
                    });
                }
            }).focus();
        })();
    </script>
</asp:Content>
