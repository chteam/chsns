<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="formset">
		<ul>
			<li>
				<h4>
					�������Ƶ</h4>
			</li>
			<li>
				<label>
					flash��ַ:<input type="text" id="f_url" /></label></li>
			<li>
				<label>
					����:<input type="text" id="f_tit" /></label></li>
			<li>
				<label>
					�ɼ���Ⱥ��$Showlevel$</label></li>
			<li>
				<label>
					ϵͳ����<select id="f_systemc" class="select"><option value="40">����</option>
						$systemcategory$</select></label></li>
			<li>
				<input type="button" value="�ύ" id="f_submit" class="subbutton" onclick="SuperNote_Add();" /><br />
				<br />
				<span class="discription">
					<h5>
						С��ʿ��</h5>
					ʹ�÷��� �ڵ�ַ���������Ӧ����Ƶ��ַ���ӣ� Ȼ�����������������Ӧ�ı�����������������Ϳ�����...<br />
					<br />
					<h5>
						��Ƶ��ַ��ȡ������</h5>
					�ڶ�Ӧ����Ƶ��վѡ�� ������Ƶ����Blog��BBS����Ȼ���ƶ�Ӧ�ĵ�ַ���ɡ�</span> </li>
		</ul>
	</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
