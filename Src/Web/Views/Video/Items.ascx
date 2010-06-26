<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%foreach(var item in ViewData["list"] as PagedList<SuperNote>){       %>

<li id="SuperNoteItem_<%=item.Id %>" class="vlist">
	<div id="showNote_<%=item.Id %>" class="vmedia" style="display:none"></div>
	<div class="vicon">&nbsp;</div>
	<div class="video">
<a href="javascript:void(0)" onclick="ShowNote(<%=item.Id %>,'<%=item.Url %>');">
<img style="width:128px;height:96px;" src="<%=item.FaceURL %>" alt="<%=item.Title %>" id="SuperVideo_<%=item.Id %>"/>
</a>
	</div>
	<div class="vtext">
		<h4><span><%=item.AddTime.Ago() %></span>{7}</h4>
		<div>
			<a href="<%=item.Url %>" target="_blank">[<%=item.Title %>]</a></div><%=item.Description %>
		<div>人气:<%=item.ViewCount %></div>
	</div>
</li>

<%} %>
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
