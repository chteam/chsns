<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%--	<div class="toc">
		<ul>
			<li><a href="#">订阅</a> </li>
			<li><a href="#">我加入的群</a> </li>
			<li><a href="#">所有群</a> </li>
			<li class="active"><a href="#">新建群</a> </li>
		</ul>
	</div>--%>
	<form action="" method="post" class="ch_content">
		<h3>
			建立群，汇集有相同兴趣爱好的人。</h3>
		<span>群名称：<input type="text" size="25" class="inputtext watermarked" name="Name" />
		</span>
		<%--<p class="note">
			*[建群需要花50积分]，你现在有224积分*</p>--%>
		<input type="submit"  value="确定"/>
	</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
