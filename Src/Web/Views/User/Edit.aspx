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

		if (v_empty('#b_Name', '姓名为必添项') &&
			v_notin('#b_Sex',[0,""],"请选择您的性别") &&
			 v_regex('#ProvinceID', /[^0]+/, false, '省为必选') &&
			  v_regex('#CityID', /[^0]+/, false, '市为必选') &&
			   v_date('#Birthday', '请写入正确日期'))
				$.post('<%=Url.Action("SaveBaseInfo","User") %>', $("#BasicInfofrm").serialize(), function(r) {
					$("#b_Name").focus();
					if ('' == r) alertEx('成功提交');
				});
		};
		var SMagicBox = function(s) {
			$.post('<%=Url.Action("SaveMagicBox","User") %>', { "magicbox": s }, function(r) {
				if ('' == r) alertEx('成功提交');
			});
		};
		var uploadsuccess = function(showul) {
			alertEx("文件上传成功.");
			$("#face_span").html(
			'<img id="Userface" src="' + showul + '?' + Math.random() + '" alt=""/>');
			uploadcreate($('#uploadfield'), '<%=Url.Action("File","Upload") %>', 'face');
		};
		var DeleteFace = function() {
			$.post('<%=Url.Action("DeleteFace","User") %>', {}, function(r) {
				if ('' == r) {
					alertEx('成功删除您的头像');
					var f = $("#face_span").html();
					$("#face_span").html("");
					$("#face_span").html(f);
				}
			});
		};
	</script>
</asp:Content>
