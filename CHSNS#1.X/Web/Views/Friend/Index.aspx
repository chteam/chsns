﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CHSNS.Web.Views.Friend.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
#capturefor(css)
<link href="${ChHelper.ChSite.StylePath}/friend.css" rel="stylesheet" type="text/css" />
#end
#capturefor(javascript)
<script src="/JavaScript/PageSet.js" type="text/javascript"></script>
<script src="/javascript/friend.js" type="text/javascript"></script>
#end
#capturefor(title)好友#end

#if(!$user)
用户不存在
#else
#capturefor(title) $user.get_item("name")的#end

<form>
<div id="UserListMsg"></div>
<div style="height: 100%">
<div id="toc">
<ul id="tabs">
<li class="status">(共有<span id="FriendCount" class="count">$Count</span>个好友)</li>
<li class="status"><a href="/Invite.aspx">邀请朋友加入</a></li>
<li class="activetab"><a>$user.get_item("name")的好友</a></li>
</ul>
</div>
<div class="ch_content">
<div id="PageUp" class="page">
</div>
<ol id="UserListItems" class="peoplelist infolist">
#parse("$siteroot/Html/UserList-Friend.vm")
</ol>
<div id="PageDown" class="page">
</div>
</div>
</div>
<input id="HdPage" type="hidden" value="$NowPage" />
<input id="HdCount" type="hidden" value="$Count" />
<input id="HdEveryPage" type="hidden" value="10" />
<script type="text/javascript">
pagefun();
</script>
##没有的话显示Friend.Xml None_Friend
</form>
#end
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>