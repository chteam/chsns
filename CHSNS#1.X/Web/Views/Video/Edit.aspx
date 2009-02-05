<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="formset">
		<ul>
			<li>
				<h4>
					添加新视频</h4>
			</li>
			<li>
				<label>
					flash地址:<input type="text" id="f_url" /></label></li>
			<li>
				<label>
					标题:<input type="text" id="f_tit" /></label></li>
			<li>
				<label>
					可见人群：$Showlevel$</label></li>
			<li>
				<label>
					系统分类<select id="f_systemc" class="select"><option value="40">其它</option>
						$systemcategory$</select></label></li>
			<li>
				<input type="button" value="提交" id="f_submit" class="subbutton" onclick="SuperNote_Add();" /><br />
				<br />
				<span class="discription">
					<h5>
						小贴士：</h5>
					使用方法 在地址栏中输入对应的视频地址链接， 然后在描述栏中输入对应的标题或其他文字描述就可以了...<br />
					<br />
					<h5>
						视频地址获取方法：</h5>
					在对应的视频网站选择 【把视频贴到Blog或BBS】，然后复制对应的地址即可。</span> </li>
		</ul>
	</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
