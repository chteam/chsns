<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	CodeBehind="Edit.aspx.cs" Inherits="CHSNS.Web.Views.User.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
	<%=Html.CSSLink("mypage") %>
	<%=Html.CSSLink("calendar")%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div id="toc">
		<ul>
			<%
				int current = 0, i = 0;
				foreach (System.Web.Mvc.ListItem kv in (List<System.Web.Mvc.ListItem>) ViewData["menulist"]) {
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
		var ChangeProvince = function() {
			Msg('#CityStatus', 'Loading...');
			$.postJSON('<%=Url.Action("CityList","Ajax") %>', { "ProvinceID": $("#ProvinceID").val() }, function(r) {
				BindSelect('#CityID', r, 'Name', 'ID');
			});
		};
		var SBaseInfo = function() {
			if (v_empty('#Name', '姓名为必添项') &&
			 v_regex('#ProvinceID', /[^0]+/, false, '省为必选') &&
			  v_regex('#CityID', /[^0]+/, false, '市为必选') &&
			   v_date('#Birthday', '请写入正确日期'))
				$.post('<%=Url.Action("SaveBaseInfo","User") %>', $("#BasicInfofrm").serialize(), function(r) {
					if ('' == r)alertEx('成功提交');
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
