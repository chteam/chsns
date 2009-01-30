<%@ Page Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage<CHSNS.ListItem>" %>

<%if (!string.IsNullOrEmpty(ViewData.Model.Value)) { %>
<%=ViewData.Model.Value %>
<%} else { %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>上传</title>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<%=Html.Script("Framework") %>
	<style type="text/css">
		* { margin: 0; padding: 0; }
	</style>
</head>
<body>
	<form id="frmUpload" method="post" action="<%=Url.Action(ViewData.Model.Text) %>"
	enctype="multipart/form-data">
	<input type="file" id="file1" name="file1" onchange="uploadSelect();" />
	</form>

	<script type="text/javascript">
		var uploadSelect = function() {
			var path = $('input[name=file1]').val();
			if (path.indexOf(".jpg") || path.indexOf(".png") || path.indexOf(".gif") || path.indexOf(".jpeg")) {
				parent.uploading($v('#file1'));
				$("#frmUpload").submit();
			} else {
				alert("您选择的文件类型不正确");
			}
		};
	</script>
</body>
</html>
<%}
	/*
	 * 个人头像
	 * 群图
	 * 图片
*/
%>
