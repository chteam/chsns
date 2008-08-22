<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="CHSNS.Web.Views.Shared.Footer" %>
<div id="footer" class="fontlink">
<a href="http://www.eice.com.cn/" target="_blank">什么是成幻SNS?</a>
<%=Html.ActionLink("客服", "Index", "Services")%>
<%=Html.ActionLink("关于我们", "AboutUs", "Home")%>
<%=Html.ActionLink("隐私安全", "PrivateClaim", "Home")%>
<a href="http://www.eice.com.cn/help.ashx" target="_blank">帮助</a>
<a href="http://www.miibeian.gov.cn/" target="_blank">黑ICP备07501485号</a>
<span id="copyright">成幻小组
<span class="c">&nbsp;&nbsp;&nbsp;</span>
2005-2008

</span>
</div>