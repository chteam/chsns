<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="sbox">
	<div class="vmain">
		<h4>
			$Username$����Ƶ</h4>
		<ol id="SuperNoteList">
			$SuperNoteList$</ol>
		<div class="page" id="PageDown"></div>
		<input id="HdOwnerid" type="hidden" value="$Ownerid$" />
		<input id="HdPage" type="hidden" value="1" />
		<input id="HdCount" type="hidden" value="$Count$" />
		<input id="HdEveryPage" type="hidden" value="10" />
	</div>
	
</div>
<script type="text/javascript">
var $supernoteshow;
function SuperNote_Add(){
	if(isEmpty("f_url")){
	alertEx('����дҪ�������ַ');
	return;
	}
	if(isEmpty("f_tit")){
	alertEx('����д����');
	return;
	}
	alertEx('�����ύ...');
	$get("f_submit").disabled="disabled";
	ChAlumna.NoteBook.SuperNote_Add($get("f_url").value,$get("f_tit").value,$get("f_showlevel").value,$get('f_systemc').value,function(r){
	if(r) {alertEx('�ύ�ɹ�');setSuperNotePage(1);}else alertEx('�ύ���ݲ��Ϸ�');
	$get("f_submit").disabled="";
	},onfail);
}
function SuperNote_Remove(id){
	alertEx('�����ύ...');
	ChAlumna.NoteBook.SuperNote_Remove(id,function(r){
	if(r) {alertEx('ɾ���ɹ�');setSuperNotePage(1);}else alertEx('ʧ��');
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
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
