<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CHSNS.Web.CurrentUser>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>G����ļ</h2>

    <fieldset>
   <legend>��������</legend><%var c=Model.Character1; %>
   <%=c.Name %><br />
   <%=c.Race +c.Class %><%=c.Level %>��<br />
   <%=c.RealM %>    <p>
    <%=Html.ActionLink("����Ĭ�Ͻ�ɫ","SetRole") %>
    <%=Html.ActionLink("�½���ɫ","EditRole") %>
    </p>
    </fieldset>
    <fieldset>
   <legend>����</legend>
   ���ʲ���<%=Model.GB %><br />
  �����ȣ�<%=Model.Evaluation %><p>
  
  <%=Html.ActionLink("��������", "AddTask")%>  <%=Html.ActionLink("�ҵ�����", "TaskList")%>
  </p><p>
  <%=Html.ActionLink("��Ҫ��", "AddWork")%>  <%=Html.ActionLink("�ҵĴ򹤼ƻ�", "WorkList")%>
   </p>
    </fieldset>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
