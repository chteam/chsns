<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CHSNS.Web.CurrentUser>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>G����ļ</h2>
    <div class="right">
    <div>
    �ҵķ���<br />
    <%foreach (var x in ViewData["isend"].ToNotNull< CHSNS.Web.Question>())
    {%>
    �ҷ����ˣ�<%=Html.ActionLink(x.Description,"Details",new{id=x.ID}) %> ��<%=x.AddTime %><br />
    <%
    }
     %>
    </div>
    
    </div>
    <div class="left">
    <fieldset><legend>��������</legend>
        <%var c = Model.Character1; %>
        <%=c.Name %><br />
        <%=c.Race +c.Class %><%=c.Level %>��<br />
        <%=c.RealM %><br />
        ���ʲ���<%=Model.GB %><br />
        �����ȣ�<%=Model.Evaluation %>
        <p>
            <%=Html.ActionLink("����Ĭ�Ͻ�ɫ","SetRole") %>
            <%=Html.ActionLink("�½���ɫ","EditRole") %>
        </p>
    </fieldset>
    <fieldset class="formset"><legend>����</legend>
    <p><label>����</label><%=Html.TextBox("s") %></p>
    </fieldset>
    <fieldset class="formset"><legend>������</legend>
    	<form action="<%=Url.Action("Submit","GTuan") %>" method="post">
    	��������  <input id="Radio1" type="radio" name="ForType" value=0 />
    	���д� <input id="Radio2" type="radio" name="ForType" value=1 />
    	ȫ��ļ <input id="Radio3" type="radio" name="ForType" value=3 />
    	<br />
       ս��<select name="TaskID">
            <option value=0>���³�</option>
            <option value=1>ս��</option>
            <option value=2>����</option>
        </select>
        ��������<input name="TaskName" type="text" /><br />
        ��ʼʱ��<input name="BeginTime" type="text" /><br />
                ˵��
        <textarea name="Description" cols="20" rows="2"></textarea><br />
                ����   <textarea name="Example" cols="20" rows="2"></textarea>
                <br />
                <input type="submit" value=�ύ />
    	</form>
    </fieldset>
    <fieldset><legend>������</legend>
        <%foreach (var x in ViewData["xfq"].ToNotNull< CHSNS.Web.Question>())
    {%>
    <%=x.CurrentUser.Character1.Name %>�����ˣ�
    <%=Html.ActionLink(x.Description,"Details",new{id=x.ID}) %> ��<%=x.AddTime %><br />
    <%
    }
     %>
    </fieldset>
     <fieldset><legend>����</legend>
        <%foreach (var x in ViewData["dgq"].ToNotNull< CHSNS.Web.Question>())
    {%>
    <%=x.CurrentUser.Character1.Name %>�����ˣ�
   <%=Html.ActionLink(x.Description,"Details",new{id=x.ID}) %> ��<%=x.AddTime %><br />
    <%
    }
     %>
     
     </fieldset>
    <p>
        <%--  <%=Html.ActionLink("����", "Work")%>--%>
        <%=Html.ActionLink("������", "Task")%>
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
