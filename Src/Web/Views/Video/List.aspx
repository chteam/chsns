<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="vmain">
		<h4>��Ƶ�б�</h4>
		<%=Html.ActionLink("���","Edit","Video") %>
		<ol id="SuperNoteList">
		 <%Html.RenderPartial("Items", ViewData["list"]); %>
		</ol>
		<%Html.RenderPartial("Pager", ViewData["list"]); %>
	</div>
<script type="text/javascript">
function SuperNote_Remove(id){
	alertEx('�����ύ...');
	ChAlumna.NoteBook.SuperNote_Remove(id,function(r){
	if(r) {alertEx('ɾ���ɹ�');setSuperNotePage(1);}else alertEx('ʧ��');
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
