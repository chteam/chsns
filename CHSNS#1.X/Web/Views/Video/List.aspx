<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="sbox">
	<div class="vmain">
		<h4>
			$Username$的视频</h4>
		<ol id="SuperNoteList">
			$SuperNoteList$</ol>
	</div>
	
</div>
<script type="text/javascript">
var $supernoteshow;

function SuperNote_Remove(id){
	alertEx('正在提交...');
	ChAlumna.NoteBook.SuperNote_Remove(id,function(r){
	if(r) {alertEx('删除成功');setSuperNotePage(1);}else alertEx('失败');
	},onfail);
}
PageSet_chSetPage("PageUp","PageDown","HdPage","HdCount","HdEveryPage","setSuperNotePage");
function setSuperNotePage(page){
	$get("HdPage").value=page;
	ChAlumna.NoteBook.SuperNote_ListString(page,$get("HdOwnerid").value,function(r){
	$get("SuperNoteList").innerHTML=r;
	PageSet_chSetPage("PageUp","PageDown","HdPage","HdCount","HdEveryPage","setSuperNotePage");
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
<%if (false) { %><script src="../../JavaScript/jquery-1.2.6-vsdoc.js"></script><%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
