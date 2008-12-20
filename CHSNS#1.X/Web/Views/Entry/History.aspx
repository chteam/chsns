<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="CHSNS.Web.Views.Entry.History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
<%=Html.CSSLink("jd") %>
<%=Html.Script("howlking")%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ToolbarContent" runat="server">
<%Html.RenderPartial("Toolbar", ViewData); %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<%
   var entry = ViewData["entry"] as Entry;
  var version = ViewData["version"] as EntryVersion;
  var ext = ViewData["ext"] as EntryExt;
  if (ext == null) ext = new EntryExt {Tags = new List<string>()};
     %>
<div id="divide"><span>旅游景点详细信息</span><span class="right">景点名称</span></div><!--分隔条-->
<div class="show_JD">
   <h1 style=" font-size:26px;"><%=entry.Title%>(历史版本: <%=version.AddTime.ToString("yyyy-MM-dd hh:mm:ss")%>)</h1>
   <div class="nav-tag">
   <ul class="nav">

      <li><%=Html.ActionLink("当前版本", "Index", new { title = entry.Title.Trim() })%></span></li>
<%--      <li><%=Html.ActionLink("编辑景点", "Edit", new { title=entry.Title})%></li>
      <li><a href="#">写游记</a></li>
      <li><a href="#">推荐<span>(10)</span></a></li>
      <li><a href="#">收藏<span>(10)</span></a></li>
      <li><a href="#">评论<span>(10)</span></a></li>--%>
   </ul>

   <ul class="tag">
      <li>
         <span>位于：</span>
         <a href="#"><%=AreaList.Load(AreaType.EntryArea).ToDictionary()[version.AreaID].Name %></a>
      </li>
      <li>
         <span>标签：</span>
<%=string.Join(",", ext.Tags.ToArray()) %>
      <%--   <a href="#">太保祠，</a>
         <a href="#">秦家坝，</a>
         <a href="#">秦良玉</a>--%>
      </li>
   </ul>
   </div>
   <img src="/images2/img_4.gif" /> 
   
   <h2>景点介绍</h2>

   <div class="content"><p>
     <%=version.Description %></p>
   </div>

</div>

<div class="AD_1">
广告
</div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FootPlaceHolder" runat="server">
 <script type="text/javascript">
       $(function(){//制定标签块的宽度随着文字变化而变化
          var width1=$(".tag li").eq(0).width();
          var width2=$(".tag li").eq(1).width();
          if(width1>width2){
             $(".tag").width(width1);
          }else{
             $(".tag").width(width2);
          }
       });
    </script>

</asp:Content>