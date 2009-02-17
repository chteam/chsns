<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CHSNS.Web.CurrentUser>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>G团招募</h2>

    <fieldset>
   <legend>个人资料</legend><%var c=Model.Character1; %>
   <%=c.Name %><br />
   <%=c.Race +c.Class %><%=c.Level %>级<br />
   <%=c.RealM %>    <p>
    <%=Html.ActionLink("设置默认角色","SetRole") %>
    <%=Html.ActionLink("新建角色","EditRole") %>
    </p>
    </fieldset>
    <fieldset>
   <legend>资料</legend>
   总资产：<%=Model.GB %><br />
  信誉度：<%=Model.Evaluation %><p>
  
  <%=Html.ActionLink("发起悬赏", "AddTask")%>  <%=Html.ActionLink("我的悬赏", "TaskList")%>
  </p><p>
  <%=Html.ActionLink("我要打工", "AddWork")%>  <%=Html.ActionLink("我的打工计划", "WorkList")%>
   </p>
    </fieldset>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
