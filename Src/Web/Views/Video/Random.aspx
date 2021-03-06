<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="sbox">
		<div class="vmain">
			<h4>
				最新视频</h4>
			<ol id="SuperNoteList">
				$SuperNoteList$</ol>
		</div>
		<div class="vinputpart">
			<h4>
				视频分类</h4>
			<div class="vclass">
				$systemcategorylist$</div>
			<h4>
				视频相关</h4>
			<ul id="SuperNote_Push">
				$Newlist$<!--Note.XML Super_New--></ul>
		</div>
	</div>

	<script type="text/javascript">
		var $supernoteshow;
		var $supernotepic;
		function SuperNote_Remove(id) {
			alertEx('正在提交...');
			ChAlumna.NoteBook.SuperNote_Remove(id, function(r) {
				if (r) { alertEx('删除成功'); setSuperNotePage(1); } else alertEx('失败');
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
			$get('SuperNoteList').innerHTML = "正在载入";
			ChAlumna.NoteBook.SuperNoteRandom_Category(id, function(r) {
				if (r == '') {
					$get('SuperNoteList').innerHTML = '此分类下没有视频';
				} else
					$get('SuperNoteList').innerHTML = r;
			}, onfail);
		}
	</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
<%=Html.CSSLink("video") %>
<%if (false) { %><script src="../../Scripts/jquery-1.2.6-vsdoc.js"></script><%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
