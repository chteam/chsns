<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	CodeBehind="Index.aspx.cs" Inherits="CHSNS.Web.Views.Home.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
<%=Html.CSSLink("main")%>
</asp:Content>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
	<div class="column main_column">
		<div class="floatl">
			<span class="logo"></span>
			<div class="logtext">
			</div>
			<div class="search">
				查找同学:<input type="text" id="search_username" onkeydown="SearchEnter(event,'search_username')" />
				<input type="button" value="查找" class="subbutton" onclick="HomeSearch('search_username')" /></div>
		</div>
		<div class="text">
			<div class="margintb">
				<br />
				<p>
					CHSNS#是免费的，开源的SNS社区网站程序</p>
				<p>
					使用网站前请详见：<a href="http://www.eice.com.cn/%e4%bd%bf%e7%94%a8%e5%8d%8f%e8%ae%ae.ashx"
						title="CHSNS#使用协议">CHSNS#使用协议</a>
				</p>
				<p>
					CHSNS# Asp.net MVC版本制作中 请见<a href="http://www.codeplex.com/sns">Codeplex源码</a></p>
				<p>
					最新版本请见<a href="http://www.eice.com.cn">CHSNS#官方网站</a></p>
			</div>
			<div class="box">
				<h3>
					${ChHelper.ChSite.BaseConfig.Title} 人气之星</h3>
				<div class="boxcont"> 
				<%
					Html.RenderPartial("ViewList", ViewData["viewlist"]); %>
				
				</div>
				<p class="more">
				</p>
			</div>
		</div>
	</div>
</asp:Content>
