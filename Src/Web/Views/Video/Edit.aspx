<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<fieldset class="formset">
		<legend>添加新视频</legend>
		<form action="" method="post" onsubmit="return sub()">
		<p>
			<label>
				flash地址:</label><%=Html.TextBox("v.url") %>
		</p>
		<p>
			<label>
				标题:</label><%=Html.TextBox("v.title") %>
		</p>
		<p>
			<label>
				可见人群：</label><%
								 Html.RenderShowLevel("v.ShowLevel"); %>
		</p>
		<p>
			<label>
				系统分类</label><select id="f_systemc" class="select">
					<option value="40">其它</option>
				</select></p>
		<p>
			<input type="submit" value="提交" class="subbutton" />
		</p>
		<p class="discription"><b>小贴士：</b> 使用方法 在地址栏中输入对应的视频地址链接， 然后在描述栏中输入对应的标题或其他文字描述就可以了...<br />
				<br />
				<b>视频地址获取方法：</b> 在对应的视频网站选择 【把视频贴到Blog或BBS】，然后复制对应的地址即可。</span>
		</p>
		</form>
	</fieldset>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
	<%if (false) { %><script src="../../Scripts/jquery-1.2.6-vsdoc.js"></script><%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">

	<script type="text/javascript">
		function sub() {
			return v_empty("#v_url", "不能为空");
		}</script>

</asp:Content>
