<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
	<%=Html.CSSLink("calendar")%>
		<%=Html.Script("ui")%>
	<%if (false)        { %>
	<script type="text/javascript" src="../../Scripts/jquery-1.2.6-vsdoc.js"></script>
   <%-- <script type="text/javascript" src="../../Scripts/ui.js"></script>--%>
    <%} %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div id="toc">
		<ul>
			<%
				int current = 0, i = 0;
                foreach (CHSNS.ListItem kv in ViewData["menulist"].ToNotNull<CHSNS.ListItem>())
                {
                    if (ViewData["mode"].ToString().Equals(kv.Value))
                        current = i;
                    i++;
			%>
			<li>
				<%=Html.ActionLink(kv.Text, kv.Value, "User")%></li>
			<%
                }
			%>
			<li class="status"></li>
		</ul>
	</div>
	<div id="as2">
	</div>
	<script type="text/javascript">
		$("#toc > ul").tabs({cache:true,selected:<%=current %>});
	</script>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FootPlaceHolder" runat="server">
	<script type="text/javascript">
		var ChangeProvince = function () {
			showMessage('#CityStatus', 'Loading...');
			$.postJSON('<%=Url.Action("CityList","Ajax") %>', { "ProvinceID": $("#ProvinceID").val() }, function (r) {
				BindSelect('#CityID', r, 'Name', 'ID');
				$('#CityStatus').html('');
			});
		};
		var SBaseInfo = function() {

		if (v_empty('#b_Name', '����Ϊ������') &&
			v_notin('#b_Sex',[0,""],"��ѡ�������Ա�") &&
			 v_regex('#ProvinceID', /[^0]+/, false, 'ʡΪ��ѡ') &&
			  v_regex('#CityID', /[^0]+/, false, '��Ϊ��ѡ') &&
			   v_date('#Birthday', '��д����ȷ����'))
				$.post('<%=Url.Action("SaveBaseInfo","User") %>', $("#BasicInfofrm").serialize(), function(r) {
					$("#b_Name").focus();
					if ('' == r) alertEx('�ɹ��ύ');
				});
		};
		var SMagicBox = function(s) {
			$.post('<%=Url.Action("SaveMagicBox","User") %>', { "magicbox": s }, function(r) {
				if ('' == r) alertEx('�ɹ��ύ');
			});
		};
		var uploadsuccess = function(showul) {
			alertEx("�ļ��ϴ��ɹ�.");
			$("#face_span").html(
			'<img id="Userface" src="' + showul + '?' + Math.random() + '" alt=""/>');
			uploadcreate($('#uploadfield'), '<%=Url.Action("File","Upload") %>', 'face');
		};
		var DeleteFace = function() {
			$.post('<%=Url.Action("DeleteFace","User") %>', {}, function(r) {
				if ('' == r) {
					alertEx('�ɹ�ɾ������ͷ��');
					var f = $("#face_span").html();
					$("#face_span").html("");
					$("#face_span").html(f);
				}
			});
		};
	</script>
</asp:Content>
