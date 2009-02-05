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
		<div>人气:{1}</div>
		<div>分类:{9}</div>
	</div>
</li>
<!--
0 $Id$ 帖子的ID
1 回复
2 $Url$URL
//3 $Description$说明
4 addtime
5 url标题
6 faceurl
7编辑与删除
{8} 用户
9 分类
-->
