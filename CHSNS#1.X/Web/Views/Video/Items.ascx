<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<li id="SuperNoteItem_{0}" class="vlist">
	<div id="showNote_{0}" class="vmedia" style="display:none"></div>
	<div class="vicon">&nbsp;</div>
	<div class="video">
		<a href="javascript:ShowNote({0},'{2}');"><img style="width:128px;height:96px;" src="{6}" alt="{5}" id="SuperVideo_{0}"/></a>
	</div>
	<div class="vtext">
		<h4><span>{4}{8}</span>{7}</h4>
		<div>
			<a href="{2}" target="_blank">[{5}]</a></div>{3}
		<div>����:{1}</div>
		<div>����:{9}</div>
	</div>
</li>
<!--
0 $Id$ ���ӵ�ID
1 �ظ�
2 $Url$URL
//3 $Description$˵��
4 addtime
5 url����
6 faceurl
7�༭��ɾ��
{8} �û�
9 ����
-->
