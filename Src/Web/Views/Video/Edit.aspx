<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<fieldset class="formset">
		<legend>�������Ƶ</legend>
		<form action="" method="post" onsubmit="return sub()">
		<p>
			<label>
				flash��ַ:</label><%=Html.TextBox("v.url") %>
		</p>
		<p>
			<label>
				����:</label><%=Html.TextBox("v.title") %>
		</p>
		<p>
			<label>
				�ɼ���Ⱥ��</label><%
								 Html.RenderShowLevel("v.ShowLevel"); %>
		</p>
		<p>
			<label>
				ϵͳ����</label><select id="f_systemc" class="select">
					<option value="40">����</option>
				</select></p>
		<p>
			<input type="submit" value="�ύ" class="subbutton" />
		</p>
		<p class="discription"><b>С��ʿ��</b> ʹ�÷��� �ڵ�ַ���������Ӧ����Ƶ��ַ���ӣ� Ȼ�����������������Ӧ�ı�����������������Ϳ�����...<br />
				<br />
				<b>��Ƶ��ַ��ȡ������</b> �ڶ�Ӧ����Ƶ��վѡ�� ������Ƶ����Blog��BBS����Ȼ���ƶ�Ӧ�ĵ�ַ���ɡ�</span>
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
			return v_empty("#v_url", "����Ϊ��");
		}</script>

</asp:Content>
