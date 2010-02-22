﻿<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>
<div id="picturenow" class="required" style="width: 240px; float: right">
	<h3>
		当前头像</h3>
	<div id="face_span">
		<%=Html.Image(CHSNS.Path.GetFace(CH.Context.User.UserId, ThumbType.Big), "头像预览", new { id = "Userface" })%>
	</div>
	<div class="required" id="uploadfield">
		<input class="subbutton" type="button" value="上传" onclick="uploadcreate($('#uploadfield'),'<%=Url.Action("File","Upload") %>','face');" />
	</div>
</div>
<div class="narrowform" style="width: 60%; height: 100%">
	<h3>
		上传头像</h3>
	<div class="notes">
		上传头像后，原先的头像将从系统中删除。<br />
		<em>如果希望成为实名用户，请使用真实写实的照片作为头像。</em><br />
		支持 BMP、JPG、JPEG、GIF和 PNG 文件格式，最大2M。<br />
		头像高度超出宽度1.5倍的部分会被切除。</div>
	<%if (!CHSNS.Path.GetFace(CH.Context.User.UserId,ThumbType.Big).Contains("no_")) {%>
	<h3>
		删除头像</h3>
	<div class="notes">
		<em>删除头像将会失去星级用户资格。</em><br />
		删除头像后，原先的头像将从系统中删除。
	</div>
	<div class="actions">
		<input class="subbutton" type="button" value="删除头像" onclick="DeleteFace();" />
	</div>
	<%
		}%>
<%--	<div class="notes">
		<a href="/setting.aspx">设置查看头像权限</a>
	</div>--%>
</div>
