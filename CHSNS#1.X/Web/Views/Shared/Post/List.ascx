<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="CHSNS.Web.Views.Shared.Post.List" %>
<div>
<%Html.Grid<NotePas>("Model",
	  new Hash(@class => "threadlist", Style => "width:100%"),
	  c => {
		  c.For("主题").Do(p => { %><td>
		  <%--#if($item.get_item("ispost")==1)
<img src="/images/note_top.gif" alt="置顶" />
#end--%>
<a href="<%=Url.GroupPost(p.ID, p.AddTime) %>"><%=p.Title %></a></td><%});
		  c.For("作者").Do(p => { %><td><%=Html.UserPageLink(p.UserID,p.WriteName) %></td><%});
		  c.For(p => p.CommentCount, "回复");
		  c.For(p => p.ViewCount,"阅读");
		  c.For("最后回复");
	  }
	  ); %>

<%--<table id="Subjectlist" class="threadlist" style="">
<thead>
<tr>
<th class="threadTitle">主题</th>
<th class="threadAuthor">作者</th>
<th class="threadStat">回复</th>
<th class="threadStat">阅读</th>
<th class="threadResponder">最后回复</th>
</tr></thead><tbody>
--%>
</div>