<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CHSNS.Web.CurrentUser>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>G团招募</h2>
    <div class="right">
    <div>
    我的发布<br />
    <%foreach (var x in ViewData["isend"].ToNotNull< CHSNS.Web.Question>())
    {%>
    我发布了：<%=Html.ActionLink(x.Description,"Details",new{id=x.ID}) %> 于<%=x.AddTime %><br />
    <%
    }
     %>
    </div>
    
    </div>
    <div class="left">
    <fieldset><legend>个人资料</legend>
        <%var c = Model.Character1; %>
        <%=c.Name %><br />
        <%=c.Race +c.Class %><%=c.Level %>级<br />
        <%=c.RealM %><br />
        总资产：<%=Model.GB %><br />
        信誉度：<%=Model.Evaluation %>
        <p>
            <%=Html.ActionLink("设置默认角色","SetRole") %>
            <%=Html.ActionLink("新建角色","EditRole") %>
        </p>
    </fieldset>
    <fieldset class="formset"><legend>搜索</legend>
    <p><label>搜索</label><%=Html.TextBox("s") %></p>
    </fieldset>
    <fieldset class="formset"><legend>发布区</legend>
    	<form action="<%=Url.Action("Submit","GTuan") %>" method="post">
    	仅招消费  <input id="Radio1" type="radio" name="ForType" value=0 />
    	仅招打工 <input id="Radio2" type="radio" name="ForType" value=1 />
    	全招募 <input id="Radio3" type="radio" name="ForType" value=3 />
    	<br />
       战场<select name="TaskID">
            <option value=0>地下城</option>
            <option value=1>战场</option>
            <option value=2>任务</option>
        </select>
        任务名称<input name="TaskName" type="text" /><br />
        开始时间<input name="BeginTime" type="text" /><br />
                说明
        <textarea name="Description" cols="20" rows="2"></textarea><br />
                范例   <textarea name="Example" cols="20" rows="2"></textarea>
                <br />
                <input type="submit" value=提交 />
    	</form>
    </fieldset>
    <fieldset><legend>消费区</legend>
        <%foreach (var x in ViewData["xfq"].ToNotNull< CHSNS.Web.Question>())
    {%>
    <%=x.CurrentUser.Character1.Name %>发布了：
    <%=Html.ActionLink(x.Description,"Details",new{id=x.ID}) %> 于<%=x.AddTime %><br />
    <%
    }
     %>
    </fieldset>
     <fieldset><legend>打工区</legend>
        <%foreach (var x in ViewData["dgq"].ToNotNull< CHSNS.Web.Question>())
    {%>
    <%=x.CurrentUser.Character1.Name %>发布了：
   <%=Html.ActionLink(x.Description,"Details",new{id=x.ID}) %> 于<%=x.AddTime %><br />
    <%
    }
     %>
     
     </fieldset>
    <p>
        <%--  <%=Html.ActionLink("打工区", "Work")%>--%>
        <%=Html.ActionLink("消费区", "Task")%>
    </p>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
	<%=Html.CSSLink("calendar")%></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
<script type="text/javascript">
    $('input[name=BeginTime]').datepicker();
</script>
</asp:Content>
