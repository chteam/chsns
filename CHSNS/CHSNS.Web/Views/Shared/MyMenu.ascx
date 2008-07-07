<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyMenu.ascx.cs" Inherits="CHSNS.Web.Views.Shared.MyMenu" %>
<%if(CHUser.IsLogin){ %>
<div id="lselect">
	<div id="leftmenu" class="mymenu">
	    <ul>
	    	<li class="menusea">
	    		<a href="#" class="menu_title" style="color:#3B5999">查找</a>
	    		<ul class="menu_network">
	    			<li><a href="/Search.aspx">查找同学</a></li>
	    			<li><a href="/Search.aspx?tabs=2">查找班级</a></li>
	    			<li><a href="/Search.aspx?tabs=1">查找群</a></li>
	    			<li><a href="/Random.aspx">随便看看</a></li>
				</ul>
	    	</li>
	    </ul>
    </div>
    <div class="qsearch">
    <span class="glass"><a href="javascript:HomeSearch('MyApp_Search_Username');"><img src="/images/glass.gif" alt=""/></a></span>
	    <input id="MyApp_Search_Username" type="text" onkeydown="SearchEnter(event,'MyApp_Search_Username')" />
	</div>
	<div>
	    <h3><a href="/Application.aspx">编辑</a>菜单</h3>
	    <ul id="MyApplication">
<%--#foreach($item in $ChHelper.Db.MyApplicationRows)
#each
<li id="$item.get_item("id")"><a href="$item.get_item("Folder")">$item.get_item("shortname")</a></li>
#end--%>
	    </ul>
	</div>
</div>

<script type="text/javascript">
chmenu("#leftmenu .menusea");
</script>
<%}else{ %>
<%=Html.RenderUserControl("/Views/Shared/LoginControl.ascx") %>
<%} %>