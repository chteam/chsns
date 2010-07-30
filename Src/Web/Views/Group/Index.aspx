<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewPage<CHSNS.Models.Group>" %>
<%@ Import Namespace="CHSNS.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <%=Html.CSSLink("group") %>
    <%=Html.CSSLink("wysiwyg/wysiwyg")%>
    <%=Html.Script("wysiwyg")%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        var g = ViewData.Model;
        var guser = ViewData["guser"] as GroupUser;
        if (g == null || guser == null) { %>
    <div class="notes">
        您所访问的群不存在</div>
    <%} else {
        bool IsAdmin = guser.Status==(byte)GroupUserStatus.Admin || guser.Status==(byte)GroupUserStatus.Ceater ||
                       User.IsInRole("admin");
        
        int showlevel = int.Parse(ViewData["showlevel"].ToString());
        int applycount = int.Parse(ViewData["Applycount"].ToString());
    %>
    <div class="groupFirstly">
        <div>
<%--			<div id="groupPicture">
                <img src="<%=Path.GetGroupImg(g.ID,ThumbType.Big) %>" alt="css" />
            </div>--%>
            <ul class="adminActions">
            <li>我可以：</li>
                <%if (IsAdmin) {%>
                <li><a href="<%=Url.LinkGroupManage(g.Id)%>">管理员工具箱</a></li>
                <%}
      if (guser.Status==(byte)GroupUserStatus.Common) {%>
                <li><a href="javascript:ApplyAdmin($group.id)">申请做管理员</a></li>
                <%} if (guser.Status == (byte)(GroupUserStatus.Ceater))
      { %>
<%--				#if ($group.UserCount <= 1)
                <li><a href="javascript:DeleteGroup($group.id);">删除本群</a></li>
                #end--%>
                <%} if (guser.Status == (byte)(GroupUserStatus.Common) || guser.Status == (byte)(GroupUserStatus.Admin))
      { %>
                <li><a href="javascript:Leave($group.id)">退出</a></li>
                <%} if (guser.Status != (byte)(GroupUserStatus.Lock))
      {%>
                <li><a href="/Invite.aspx?id=$group.id&">邀请朋友加入</a></li>
                <%--	#if ($user.IsRss)
<li><a id="RssTake" href="javascript:Takeout($group.id);">取消订阅</a></li>
    #else
<li><a id="RssTake" href="javascript:Takein($group.id);">订阅本群</a></li>
    #end--%>
                <%} if (guser.Status == (byte)(GroupUserStatus.Lock) && g.JoinLevel == 8)
      {//不是成员且，可自行申请加入%>
                <li><a href="javascript:Joinin($group.id);">加入本群</a></li>
                <%} %>
            </ul>
        </div>
        <div>
            <ul>
                <li>&nbsp;</li>
                <li>群管理员：</li>
                <%foreach (UserItemPas u in (ViewData["adminlist"] as IEnumerable<UserItemPas>).ToNotNull()) {%>
                <%=Html.UserPageLink(u.Id,u.Name) %>
                <%}%>
                <li>&nbsp;</li>
            </ul>
        </div>
        <div class="box" id="Div1">
            <h4>
                群成员</h4>
            <%Html.RenderPartial("ViewList", ViewData["MemberList"]); %>
        </div>
    </div>
    <div class="groupSecondary">
        <div>
            <h4 class="announce">
                <%=g.Name%>(共<span class="count"><%=g.UserCount%></span>人)</h4>
        </div>
        <div class="div2">
            <h4>
                群公告栏</h4>
            <div class="notes">
                <%if (IsAdmin && applycount > 0) {%>
                有<%=applycount %>位成员等待加入
                <%=Html.ActionLink("去处理", "ManageUser", "Group", new { id=g.Id},null)%>
                <br />
                <%	}%>
                <%=g.Summary %>
            </div>
        </div>
        <div class="box" id="groupVisitor">
            <h4>
                最近访客</h4>
            <%Html.RenderPartial("ViewList", ViewData["viewlist"]); %>
        </div>
        <div>
            <h4>
                群论坛</h4>
            <div>
                <div class="page" id="PageUp">
                </div>
                <div id="Loglist">
                    <%--##<帖子列表>--%>
                    <%
            if (showlevel == 8 || IsAdmin)
       {%>
                    <%Html.RenderPartial(MVC.Shared.Views.Post.List, ViewData["posts"]); %>
                    <%--#component(PostList with "Groupid=$group.id" "EveryPage=20" "nowpage=$nowpage")--%>
                    <%} else { %>
                    <div class="note">
                        <%=g.Name%>
                        是私人群，非成员不能阅读群主题。<a href="javascript:Joinin($group.id);">申请加入群</a>
                    </div>
                    <%} %>
                    <%--##帖子列表--%>
                </div>
                <div class="page" id="PageDown">
                </div>
            </div>
        </div>
        <div>
            <%if (showlevel == 0 || User.IsInRole("admin"))
     {%>
            <h4>
                <a href="#sendsubject">发表新主题</a></h4>
            <form action="<%=Url.Action("Post","Group") %>" method="post" onsubmit="return sub();">
            <%=Html.Hidden("post.ParentId",g.Id) %>
            <ul>
                <li>
                    <label for="subject">
                        新主题：</label>
                    <input name="post.Title" id="title" class="inputtext subject" type="text" />
                </li>
                <li>
                    <textarea cols="80" rows="15" name="post.Body" id="tbody"></textarea>
                </li>
                <li>
                    <input type="submit" value="发表" class="subbutton" />
                </li>
            </ul>
            </form>
            <%} else {
         if (showlevel == 4)
         { %>
            <div class="note">
                <%=g.Name%>是半公开群，非成员可以阅读群主题但不能发表和回复。你可以 <a href="javascript:Joinin($group.id);">申请加入群</a>
            </div>
            <%	}
     }%>
        </div>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
<script type="text/javascript">
    $(function() { $('#tbody').wysiwyg(); });
    function sub() {
        return v_empty('#title', "不能为空") && v_empty('#tbody', "不能为空");
    }
</script>
</asp:Content>
