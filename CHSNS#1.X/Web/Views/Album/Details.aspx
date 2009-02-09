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
		您还没上传照片 , Show出你自己吧
		<input type="button" onclick="location='<%=Url.Action("Upload","Album",new{id=a.ID}) %>';"
			value="Go-&gt;" class="subbutton" />
	</div>
	<%} else { %>
	<div class="notes">
		相册内没有照片,或您没有权限查看这些照片</div>
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
				<img src="<%=Path.Photo(CH.Context.User.UserID,p.AddTime,p.Ext,ThumbType.Middle) %>" alt="<%=p.Name %> at <%=p.AddTime.ToString("yy年MM月dd日") %>"
					style="max-width: 130px;" /></a>
				<div class="pedit">
					<%if (CH.Context.User.UserID == p.UserID) {%>
					<a href="javascript:void(0)" onclick="SetFace(<%=p.ID %>)">设为封皮</a>
					<a href="javascript:void(0)" onclick="DeletePhoto(<%=p.ID %>)">删除</a>
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
				value="上传" class="subbutton" />
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
			if (confirm("您要删除这个照片吗?")) {
				$.get('<%=Url.Action("PhotoDel","Album") %>', { 'id': id }, function() {
					$("#photo_li" + id).hide();
				});
			}
		};
		var SetFace = function(id) {
			$.get('<%=Url.Action("SetFace","Album") %>', { 'id': id }, function() {
				alertEx('设置成功');
			});

		};
	</script>

</asp:Content>
