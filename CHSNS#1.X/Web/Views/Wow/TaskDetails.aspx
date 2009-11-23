<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CHSNS.Web.Task>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%
    var d = new Dictionary<int, string>();
    d.Add(0, "等待中");
    d.Add(1, "已通过审核");
    d.Add(2, "终止");
     %>
     <%
    var td = new Dictionary<int, string>();
    td.Add(0, "等待中");
    td.Add(1, "已完成");
    td.Add(2, "已结算");
     %>
    <h2>我要参加</h2>

    <fieldset>
        <legend>我要参加</legend>
        <p>
            标题: 
            <%= Html.Encode(Model.Title) %>
        </p>
        <p>
            人数: 
            <%= Html.Encode(Model.PersonCount) %>
        </p>
        <p>
            时间: 
            <%= Html.Encode(Model.BeginTime) %>
        </p>
        <p>
            详细: 
            <%= Html.Encode(Model.Description) %>
        </p>
        <p>
            TaskType: 
            <%= Html.Encode(Model.TaskType) %>
        </p>
        <p>
            GB: 
            <%= Html.Encode(Model.GB) %>
        </p>
        <p>
            Status: 
            <%= Html.Encode(td[Model.Status]) %>
        </p>
    </fieldset>
    <%
        using (var w = new CHSNS.Web.WOWDataContext())
        {
            var ws = w.Worker.Where(t => t.TaskID == Model.ID);
     %>
        <table class="table">
        <tr>
            <th></th>
            <th>
                详细
            </th>
            <th>
                评分
            </th>
            <th>
                状态
            </th>
        </tr>
    <% foreach (var item in ws)
       { %>
        <tr>
            <td>
                <%= Html.ActionLink("查看详细信息", "WorkDetails", new { id = item.ID })%>
            </td>
            <td>
                <%= Html.Encode(item.Description)%><br />
            </td>
            <td>
                <%= Html.Encode(item.EvaluationWork)%>
            </td>
            <td>
                <%= Html.Encode(d[item.Status])%>
            </td>
        </tr>
    
    <% } %>

    </table>
    <%} if (CH.Context.User.UserID != Model.CreateUserID)
      { %>
    <form action="<%=Url.Action("JoinTask") %>" method="post">
    <%=Html.DropDownList("wid")%>
    <%=Html.Hidden("tid", Model.ID)%>
    <input type="submit" value="提交" />
    
    如果您还没有发布打工计划，<%=Html.ActionLink("请点这里", "AddWork", new { taskid = Model.ID })%>
    </form>
<%}else{
      %>
      <%=Html.ActionLink("完成交易", "PayTask", new { id=Model.ID})%>
      <%} %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>

