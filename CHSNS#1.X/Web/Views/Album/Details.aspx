<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
<%=Html.CSSLink("photo") %>
<%=Html.CSSLink("photo") %>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%var a = ViewData["album"] as Album;
  IEnumerable<Photo> rows = ViewData["photos"] as PagedList<Photo>;
%>
<%if (a != null && rows.Count() == 0) {%>
			<%if (a.UserID == CHUser.UserID) { %>
<div class="notes">您还没上传照片 , Show出你自己吧
<input type="button" onclick="location='<%=Url.Action("Upload","Album",new{id=a.ID}) %>';" value="Go-&gt;" class="subbutton" />
</div>
			<%} else { %>
<div class="notes">相册内没有照片,或您没有权限查看这些照片</div>
			<%} %>
<%} %>
	<div class="photolist">
		<ul>
<%foreach (Photo p in rows.ToNotNull()) { %>
<li id="photo_li<%=p.ID %>">
<a href="javascript:showPic('<%=Path.Photo(CHUser.UserID,p.AddTime,p.Ext,ThumbType.Middle.ToString() ) %>');">

<img src="<%=Path.Photo(CHUser.UserID,p.AddTime,p.Ext,ThumbType.Middle) %>" 
alt="<%=p.Name %> at <%=p.AddTime.ToString("yy年MM月dd日") %>" style="max-width: 130px;" /></a>
<div class="pedit">
<%if(CHUser.UserID==p.UserID) {%>
<a href="">设为封皮</a> 
<%=Html.ActionLink("删除", "PhotoDel", "Album", new { id=p.ID},null)%>

<%
}%></div>
</li>

<%}%>
</ul>
</div>
<%
  Html.RenderPartial("Pager", rows);
	%>
<div class="formset" >
<p>
<input type="button" onclick="location='<%=Url.Action("Upload","Album",new{id=a.ID}) %>';" value="上传" class="subbutton" />
</p>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
