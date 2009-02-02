<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
AutoEventWireup="true" 
Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<fieldset><legend>相册列表</legend>
		<%=Html.ActionLink("[新建相册]","Edit","Album") %>
		<div class="ch_content"> 
			<ul class="userlist">
				<%  foreach (Album p in (ViewData.Model as IEnumerable<Album>).ToNotNull()) { %>
				<li id="Items<%=p.ID %>" class="useritem">
					<div class="face face-middle">
						<a href="<%=Url.Action("Details", "Album", new { id=p.ID})%>"
						 title="<%=p.Name %>" style="background-image: url(<%=Path.AlbumFace(p.FaceUrl) %>);">
						</a>
					</div>
					<div class="info">
						<strong><a href="<%=Url.Action("Details", "Album", new { id=p.ID})%>">
							<%=p.Name %></a></strong>
						<ul>
							<li>[<%=p.Count %>张] 创建于<%=p.AddTime.ToString("yy年MM月dd日") %></li>
							<li>拍摄地点:<%=p.Location %></li>
							<li>相册描述:<%=p.Description %></li>
						</ul>
					</div>
					<ul class="actions">
						<li><%=Html.ActionLink("编辑", "Edit", "Album", new { id=p.ID},null)%></li>
						<li><a href="javascript:DeleteAlbum(1);">删除</a> </li>
					</ul>
				</li>
				<%} %>
			</ul>
		</div>
	</fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
