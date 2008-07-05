<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="CHSNS.Web.Views.Shared.Footer" %>
<div id="footer" class="fontlink">
<a href="http://www.eice.com.cn/" target="_blank">什么是成幻SNS?</a>
<%--$url.link("客服","%{controller='Services',action='Index'}")
$url.link("关于我们","%{controller='home',action='AboutUs'}")
$url.link("隐私安全","%{controller='home',action='PrivateClaim'}")--%>
<a href="http://www.eice.com.cn/help.ashx" target="_blank">帮助</a>
<a href="http://www.miibeian.gov.cn/" target="_blank">$ChHelper.ChSite.BaseConfig.Number</a>
<span id="copyright">成幻小组
<span class="c">&nbsp;&nbsp;&nbsp;</span>
<%--$ChHelper.ChSite.BaseConfig.CopyRight--%>
</span>
</div>