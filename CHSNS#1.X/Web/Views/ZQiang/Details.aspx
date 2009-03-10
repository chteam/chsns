<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CHSNS.Web.Question>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <%var c = Model.CurrentUser.Character1; %>
        <%=c.Name %><br />
        <%=c.Race +c.Class %><%=c.Level %>级<br />
        <%=c.RealM %>		<br />		
							
招募内容	<br />
<%=Model.Description %>						
，要求<%=Model.Example %>				
<br />				
							
老板							
<%foreach (var a in Model.Answer)
{
      %>
      <%=a.CurrentUser.Character1.Name %>
      <%=a.CurrentUser.Character1.Level %>级
      <%=a.AddTime %>
      <%
}
 %>
会秘鬼魅	人类法师	70级					
。。。							
<br />
<%
if (Model.ForType==0||Model.ForType==2)
{
    Writer.Write(
        Html.ActionLink("我也当老板",
        "SubmitAnswer",
        new { qid = Model.ID, Role = 0 })
        );
}
if (Model.ForType == 1 || Model.ForType == 2)
{
    Writer.Write(
        Html.ActionLink("我也来应征",
        "SubmitAnswer",
        new { qid = Model.ID, Role =1 })
        );
}
%>	
<br />					
							
评论							
游客：此乃一爽人							
							
发表评论							
							
							
							
							
<%=Html.ActionLink("我的G团招募","Index","GTuan") %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
