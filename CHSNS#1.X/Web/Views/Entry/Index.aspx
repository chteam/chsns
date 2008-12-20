<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CHSNS.Web.Views.Entry.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
<%=Html.CSSLink("jd") %>
<%=Html.Script("howlking")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<%
	var entry = ViewData["entry"] as Entry ?? new Entry();
	var version = ViewData["version"] as EntryVersion ?? new EntryVersion();
  var ext = ViewData["ext"] as EntryExt;
  if (ext == null) ext = new EntryExt {Tags = new List<string>()};
     %>
<div class="show_JD">
   <h1 style=" font-size:26px;"><%=entry.Title%></h1>
   <div class="nav-tag">
   <ul class="nav">
      <li><%=Html.ActionLink("编辑景点", "Edit", new { id=entry.ID})%>
</li>
      <li><%=Html.ActionLink("历史版本","Historylist", new { id=entry.ID})%>
      <span>(<%=entry.EditCount %>)</span></li>

      <li><a href="#">写游记</a></li>
<%--      <li><a href="#">推荐<span>(10)</span></a></li>
      <li><a href="#">收藏<span>(10)</span></a></li>
      <li><a href="#">评论<span>(10)</span></a></li>--%>
   </ul>

   <ul class="tag">
      <li>
         <span>位于：</span>
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
   <div class="imgs">
      <img src="/images2/img_5.gif" />

      <img src="/images2/img_6.gif" />
      <img src="/images2/img_7.gif" />
      <img src="/images2/img_5.gif" />
      <img src="/images2/img_6.gif" />
      <img src="/images2/img_7.gif" />
      <img src="/images2/img_5.gif" />
      <img src="/images2/img_6.gif" />
   </div>
   
   <div class="leaveMessage">

      <h4>最新评论：<a href="#">更多评论</a></h4>
      <div class="message">
         <a href="#">旅游大侠</a>
         <span>2008-02-05</span>
         <p>很好的景点呀！</p>
      </div>

      
      <div class="message">
         <a href="#">旅游大侠</a>
         <span>2008-02-05</span>
         <p>很好的景点呀！</p>
      </div>
      
      <textarea></textarea>
      <input type="button" value="提 交" />　
      <input type="button" value="重 置" />

   </div>
</div>

<div class="AD_1">
   <div class="otherlines">
   <h5>相关线路</h5>
   <ul>
      <li><a href="#">温泉之乡毛利人的聚集地罗托鲁阿</a></li>
      <li><a href="#">温泉之乡毛利人的聚集地罗托鲁阿</a></li>

       <li><a href=#>游览新西兰北岛千年之都奥克兰，温泉之乡毛利人的聚集地罗托鲁阿</a></li>
   </ul>
   
   <h5>相关景点</h5>
   <ul>
      <li><a href="#">温泉</a><a href=#>西兰北岛千年</a><a href=#>温泉</a><a href=#>西兰北岛千年</a><a href=#>温泉</a><a href=#>西兰北岛千年</a><a href=#>温泉</a><a href=#>西兰北岛千年</a><a href=#>温泉</a><a href=#>西兰北岛千年</a></li>

   </ul>
   
   <h5>相关游记</h5>
   <ul>
      <li><a href="#">温泉之乡毛利人的聚集地罗托鲁阿</a></li>
      <li><a href="#">温泉之乡毛利人的聚集地罗托鲁阿</a></li>
       <li><a href=#>游览新西兰北岛千年之都奥克兰，温泉之乡毛利人的聚集地罗托鲁阿</a></li>
   </ul>

   </div>
   <a href="#"><img src="/images2/ad1.gif" /></a>
   <a href="#"><img src="/images2/ad2.gif" /></a>
</div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FootPlaceHolder" runat="server">

</asp:Content>
