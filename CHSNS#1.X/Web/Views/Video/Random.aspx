<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="sbox">
		<div class="vmain">
			<h4>
				������Ƶ</h4>
			<ol id="SuperNoteList">
				$SuperNoteList$</ol>
		</div>
		<div class="vinputpart">
			<h4>
				��Ƶ����</h4>
			<div class="vclass">
				$systemcategorylist$</div>
			<h4>
				��Ƶ���</h4>
			<ul id="SuperNote_Push">
				$Newlist$<!--Note.XML Super_New--></ul>
		</div>
	</div>

	<script type="text/javascript">
		var $supernoteshow;
		var $supernotepic;
		function SuperNote_Remove(id) {
			alertEx('�����ύ...');
			ChAlumna.NoteBook.SuperNote_Remove(id, function(r) {
				if (r) { alertEx('ɾ���ɹ�'); setSuperNotePage(1); } else alertEx('ʧ��');
			}, onfail);
		}
		function ShowNote(id, url) {
			if ($supernoteshow != null && $get("SuperNoteItem_" + $supernoteshow)) {
				hideLayer("showNote_" + $supernoteshow);
				$get("SuperNoteItem_" + $supernoteshow).style.height = "100px";
				$get("SuperVideo_" + $supernoteshow).src = $supernotepic;
			}
			$supernoteshow = id;
			showLayer("showNote_" + $supernoteshow);
			$supernotepic = $get("SuperVideo_" + $supernoteshow).src;
			$get("SuperVideo_" + $supernoteshow).src = "/images/video.png";
			$get("SuperNoteItem_" + $supernoteshow).style.height = "472px";
			$get("showNote_" + id).innerHTML = '<embed mediawrapchecked="true" src="' + url + '" scale="exactfit" play="true" loop="false"	menu="true" wmode="Window" quality="1" type="application/x-shockwave-flash" height="350" width="460"></embed>';
			ChAlumna.NoteBook.SuperNote_See(id, 1, function(r) {
				$get("SuperNote_Push").innerHTML = r;
			}, onfail);
		}
		function showcategory(id, name) {
			$get('SuperNoteList').innerHTML = "��������";
			ChAlumna.NoteBook.SuperNoteRandom_Category(id, function(r) {
				if (r == '') {
					$get('SuperNoteList').innerHTML = '�˷�����û����Ƶ';
				} else
					$get('SuperNoteList').innerHTML = r;
			}, onfail);
		}
	</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
<%=Html.CSSLink("video") %>
<%if (false) { %><script src="../../JavaScript/jquery-1.2.6-vsdoc.js"></script><%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
