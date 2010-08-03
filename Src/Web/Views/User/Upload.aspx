<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="Edit.master"  %>
<asp:Content ID="Content2" ContentPlaceHolderID="TabContent" runat="server">
    <%=Html.Script(Links.Scripts.Upload.swfupload_js)%>
    <%=Html.Script(Links.Scripts.Upload.handlers_js)%>
    <%=Html.Script(Links.Scripts.Upload.MyUploader_js) %>
    <div id="picturenow" class="required" style="width: 240px; float: right">
    <h3>
        当前头像</h3>
    <div id="face_span">
        <%--<%=Html.Image(Path.GetFace(CH.Context.User.UserId, ThumbType.Big), "头像预览", new { id = "Userface" })%>--%>
    </div>
    <div id="spanButtonPlaceholder"></div>
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
<%--	<div class="notes">
        <a href="/setting.aspx">设置查看头像权限</a>
    </div>--%>
</div>
<script type="text/javascript">
    CreateUploader("<%=Url.ActionAbsolute(MVC.Upload.Face()) %>", '<%=Session.SessionID %>', "上传头像");
</script>
</asp:Content>