<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
 AutoEventWireup="true" 
 Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%Album a = ViewData["album"] as Album;
  IEnumerable<Photo> rows = ViewData["photos"].ToNotNull<Photo>();
%>
<%if (a != null && rows.Count() == 0) {%>
			<%if (a.UserID == CHUser.UserID) { %>
<div class="notes">您还没上传照片 , Show出你自己吧
<input type="button" onclick="location='<%=Url.Action("Upload","Album") %>';" value="Go-&gt;" class="subbutton" />
</div>
			<%} else { %>
<div class="notes">相册内没有照片,或您没有权限查看这些照片</div>
			<%} %>
<%} %>
<%foreach (Photo p in rows) { %>
<li id="photo_li<%=p.ID %>">
<a href="javascript:showPic('$ChHelper.Path.GetPhoto($Ownerid,$photo.get_item("path"))');">
<img src="$ChHelper.Path.GetThumbPhoto($Ownerid,$photo.get_item("path"))" alt="$photo.get_item("Photoname") at $photo.get_item("Addtime").ToString("yy年MM月dd日")" style="max-width: 130px;" /></a>
<div class="pedit">
#if($ChHelper.ChUser.Userid==$Ownerid)
<a href="javascript:Photo_Cover($photo.get_item("id"));">设为封皮</a>
<a href="javascript:DeletePhoto($photo.get_item("id"),'$ChHelper.Path.GetPhoto($Ownerid,$photo.get_item("path"))');">删除</a>
	    #end</div>
</li>
#end
<%} %>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
