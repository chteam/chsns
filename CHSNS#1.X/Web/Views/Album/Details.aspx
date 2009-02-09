<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
	<%=Html.CSSLink("photo") %>
	<%=Html.CSSLink("photo") %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<%
		var a = ViewData["album"] as Album;
		IEnumerable<Photo> rows = ViewData["photos"] as PagedList<Photo>;
	%>
	<%if (a != null && (rows == null || rows.Count() == 0)) {%>
	<%if (a.UserID == CH.Context.User.UserID) { %>
	<div class="notes">
		����û�ϴ���Ƭ , Show�����Լ���
		<input type="button" onclick="location='<%=Url.Action("Upload","Album",new{id=a.ID}) %>';"
			value="Go-&gt;" class="subbutton" />
	</div>
	<%} else { %>
	<div class="notes">
		�����û����Ƭ,����û��Ȩ�޲鿴��Щ��Ƭ</div>
	<%} %>
	<%} %>
	<div id="c_photo" style="display: none">
		<a href="javascript:void(0)" onclick="showPic()">
			<img src="" /></a>
	</div>
<div id="c_list">
	<div class="photolist">
		<ul>
			<%foreach (Photo p in rows.ToNotNull()) { %>
			<li id="photo_li<%=p.ID %>">
<a href="javascript:showPic('<%=Path.Photo(CH.Context.User.UserID,p.AddTime,p.Ext,ThumbType.Big) %>');">
				<img src="<%=Path.Photo(CH.Context.User.UserID,p.AddTime,p.Ext,ThumbType.Middle) %>" alt="<%=p.Name %> at <%=p.AddTime.ToString("yy��MM��dd��") %>"
					style="max-width: 130px;" /></a>
				<div class="pedit">
					<%if (CH.Context.User.UserID == p.UserID) {%>
					<a href="javascript:void(0)" onclick="SetFace(<%=p.ID %>)">��Ϊ��Ƥ</a>
					<a href="javascript:void(0)" onclick="DeletePhoto(<%=p.ID %>)">ɾ��</a>
					<%
						}%></div>
			</li>
			<%}%>
		</ul>
	</div>
	<%
		Html.RenderPartial("Pager", rows);
	%>
	<div class="formset">
		<p>
			<input type="button" onclick="location='<%=Url.Action("Upload","Album",new{id=a.ID}) %>';"
				value="�ϴ�" class="subbutton" />
			<%=Html.ActionLink(a.Name,"Index","Album",new{uid=a.UserID},null) %>
		</p>
	</div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">

	<script type="text/javascript">
		function showPic(fn) {
			$('#c_photo').toggle();
			$('#c_list').toggle();
			$('#c_photo img').attr('src', fn);
		}
		var DeletePhoto = function(id) {
			if (confirm("��Ҫɾ�������Ƭ��?")) {
				$.get('<%=Url.Action("PhotoDel","Album") %>', { 'id': id }, function() {
					$("#photo_li" + id).hide();
				});
			}
		};
		var SetFace = function(id) {
			$.get('<%=Url.Action("SetFace","Album") %>', { 'id': id }, function() {
				alertEx('���óɹ�');
			});

		};
	</script>

</asp:Content>
