<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CHSNS.Web.Question>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <%var c = Model.CurrentUser.Character1; %>
        <%=c.Name %><br />
        <%=c.Race +c.Class %><%=c.Level %>��<br />
        <%=c.RealM %>		<br />		
							
��ļ����	<br />
<%=Model.Description %>						
��Ҫ��<%=Model.Example %>				
<br />				
							
�ϰ�							
<%foreach (var a in Model.Answer)
{
      %>
      <%=a.CurrentUser.Character1.Name %>
      <%=a.CurrentUser.Character1.Level %>��
      <%=a.AddTime %>
      <%
}
 %>
���ع���	���෨ʦ	70��					
������							
<br />
<%
if (Model.ForType==0||Model.ForType==2)
{
    Writer.Write(
        Html.ActionLink("��Ҳ���ϰ�",
        "SubmitAnswer",
        new { qid = Model.ID, Role = 0 })
        );
}
if (Model.ForType == 1 || Model.ForType == 2)
{
    Writer.Write(
        Html.ActionLink("��Ҳ��Ӧ��",
        "SubmitAnswer",
        new { qid = Model.ID, Role =1 })
        );
}
%>	
<br />					
							
����							
�οͣ�����һˬ��							
							
��������							
							
							
							
							
<%=Html.ActionLink("�ҵ�G����ļ","Index","GTuan") %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
