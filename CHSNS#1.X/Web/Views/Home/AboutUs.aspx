<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
<%=Html.CSSLink("main") %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		佳木斯大学校友录</h2>
	<fieldset>
		<legend>关于成幻小组</legend>成幻小组是佳木斯大学校友录的研发团队<br />
		在不懈的努力与拼搏中成长,遂渐成为一支技术过硬的研发团队<br />
		成幻小组始终致力于为用户提供更良好的环境,更舒服的体验,并尽力将新的理念带给大家.</fieldset>
	<fieldset>
		<legend>关于佳木斯大学校友录</legend>佳木斯大学校友录,专注于&quot;人&quot;的互动,我们坚信服务上的持续改进,真正关心用户所想所需,不断追求网站可以给用户带来的价值,才能给用户以真正可以有所收益的功能,使同学们可以与佳木斯大学校友录共同成长共同进步.</fieldset>
	<fieldset>
		<legend>合作相关</legend>如果您对我们的网站及建站技术有兴趣,可以通过以下方式联系我们:
		<ol>
			<li>电话:13945457355 联系人:孟先生</li>
			<li><a href="mailto:Email:chsword@126.com">Email:chsword#126.com</a></li>
		</ol>
	</fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
