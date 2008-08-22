﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Setting.ascx.cs" Inherits="CHSNS.Web.Views.FaceInfo.Setting" %>
<div id="picturenow" class="required">
	<h4>
		当前头像</h4>
	<span id="face_span">
		<img src="$ChHelper.Path.Getface_Big()" alt="头像预览" id="Userface" /></span>
</div>
<div class="narrowform">
	<h3>
		上传头像</h3>
	<div class="notes">
		上传头像后，原先的头像将从系统中删除。<br />
		<em>如果希望成为实名用户，请使用真实写实的照片作为头像。</em><br />
		支持 BMP、JPG、JPEG、GIF和 PNG 文件格式，最大2M。<br />
		头像高度超出宽度1.5倍的部分会被切除。</div>
	<div class="required" id="uploadfield">
	</div>
	<div class="notes">
		<a href="/setting.aspx">设置查看头像权限</a>
	</div>
	<h3>
		删除头像</h3>
	<div class="notes">
		<em>删除头像将会失去星级用户资格。</em><br />
		删除头像后，原先的头像将从系统中删除。</div>
	<div class="actions">
		<input class="subbutton" type="button" value="删除头像" onclick="SubmitInfo('deleteface');" />
	</div>
</div>
