<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CHSNS.Web.Views.Album.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<fieldset>
		<legend>相册列表</legend>
		<%=Html.ActionLink("新建相册","Edit","Album") %>
		<div class="ch_content">
			<ul class="userlist">
				<%  foreach (Album p in (ViewData.Model as IEnumerable<Album>).ToNotNull()) { %>
				<li id="Items<%=p.ID %>" class="useritem">
					<div class="face face-middle">
						<a href="<%=Url.Action("Details", "Album", new { id=p.ID})%>"
						 title="<%=p.Name %>" style="background-image: url();">
						</a>
						
					</div>
					<div class="info">
						<strong><a href="<%=Url.Action("Details", "Album", new { id=p.ID})%>">
							<%=p.Name %></a></strong>
						<ul>
							<li>[<%=p.Count %>张] 创建于<%=p.AddTime.ToString("yy年MM月dd日") %></li>
							<li>拍摄地点:<%=p.Location %></li>
							<li>相册描述:<%=p.Description %></span></li>
						</ul>
					</div>
					<ul class="actions">
						<li><a href="javascript:ShowEdit(1);">编辑</a> </li>
						<li><a href="javascript:DeleteAlbum(1);">删除</a> </li>
					</ul>
				</li>
				<%} %>
			</ul>
		</div>
	</fieldset>
<%--	<li id="Album_li$item.get_item("id")">
<div class="people">
<p class="image">
<a href="/Album.aspx?albumid=$item.get_item("id")&userid=$item.get_item("ownerid")&">
<img src="$ChHelper.Path.GetThumbPhoto($item.get_item("ownerid"),$item.get_item("faceurl"))" alt="$item.get_item("Albumname")" class="">
</a>
</p>
<div class="info">
<strong>
<a href="/Album.aspx?albumid=$item.get_item("id")&userid=$item.get_item("ownerid")&" id="Album_Name$item.get_item("id")">$item.get_item("Albumname")</a>
</strong>
<a href="/User.aspx?userid=$item.get_item("ownerid")&amp;">$item.get_item("Username")</a>
<ul>
<li>[$item.get_item("count")张] 创建于$item.get_item("Addtime").ToString("yy年MM月dd日")<!--Addtime --></li>
<li>拍摄地点:<span id="Album_Loca$item.get_item("id")">$item.get_item("Location")</span></li>
<li>相册描述:<span id="Album_Desc$item.get_item("id")">$item.get_item("Description")</span></li>
</ul>
</div>
<ul class="actions">
<li><a href="/Album.aspx?albumid=$item.get_item("id")&userid=$item.get_item("ownerid")&">进入相册</a></li>
			#if($isedit)
<li>|</li>
<li>
<a href="javascript:ShowEdit($item.get_item("id"));">编辑</a>
</li><li>|</li><li>
<a href="javascript:DeleteAlbum($item.get_item("id"));">删除</a>
</li>
			#end
</ul>
</div>
</li>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
