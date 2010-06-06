<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="vmain">
		<h4>视频列表</h4>
		<%=Html.ActionLink("添加","Edit","Video") %>
		<ol id="SuperNoteList">
		 <%Html.RenderPartial("Items", ViewData["list"]); %>
		</ol>
		<%Html.RenderPartial("Pager", ViewData["list"]); %>
	</div>
<script type="text/javascript">
function SuperNote_Remove(id){
	alertEx('正在提交...');
	ChAlumna.NoteBook.SuperNote_Remove(id,function(r){
	if(r) {alertEx('删除成功');setSuperNotePage(1);}else alertEx('失败');
	},onfail);
}
function ShowNote(id,url){
	if($supernoteshow!=null){
	hideLayer("showNote_"+$supernoteshow);
	$get("SuperNoteItem_"+$supernoteshow).style.height="100px";
	$get("SuperVideo_"+$supernoteshow).src=$supernotepic;
	}
	$supernoteshow=id;
	showLayer("showNote_"+$supernoteshow);
	$supernotepic=$get("SuperVideo_"+$supernoteshow).src;
	$get("SuperVideo_"+$supernoteshow).src="/images/video.png";
	$get("SuperNoteItem_"+$supernoteshow).style.height="472px";
	
	$get("showNote_"+id).innerHTML='<embed mediawrapchecked="true" src="'+url+'" scale="exactfit" play="true" loop="false"	menu="true" wmode="Window" quality="1" type="application/x-shockwave-flash" height="350" width="460"></embed>';
	ChAlumna.NoteBook.SuperNote_See(id,0,function(r){
	},onfail);
}
</script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
<%=Html.CSSLink("video") %>
<%if (false) { %><script src="../../Scripts/vsdoc.js" type="text/javascript"></script><%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
