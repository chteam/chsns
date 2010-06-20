<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <%=Html.Script("wysiwyg") %>
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%Html.RenderPartial("ManageToc"); %>
    <form action="" method="post" id="entryform">
    <%=Html.Hidden("id")%>
    <fieldset class="formset">
        <legend>词条编辑</legend>
        <p>
        <label>词条地址</label>
        <%=Html.TextBox("entry.Url", null, new { style = "width: 50%", onblur = "Has(this);" })%>
        <span class="explanation">最好用英文</span>
        </p>
        <p>
            <label>
                词条名称：</label>
                <%=Html.TextBox("entryversion.Title", null, new { style = "width: 50%", onblur = "Has(this);" })%>
                <%=Html.RadioButton("entry.IsDisplayTitle","true") %>
                <%=Html.RadioButton("entry.IsDisplayTitle","false") %>
        </p>
        <p>
            <label>
                内容：
            </label>
            <%=Html.TextArea("entryversion.description", new {style="width:100%;height:300px;", cols="20", rows="2" })%>
        </p>
        <p>
            <label>
                标签：
            </label>
            <%=Html.TextBox("tags", null, new { style = "width: 100%" })%>
            <span class="explanation">最多五个标签，每个不超过十个字，多个请用逗号隔开</span>
        </p>
        <p>
            <label>
                参考资料：
            </label>
            <%=Html.TextArea("entryversion.reference", new { style = "width: 100%; height: 100px;", cols = "20", rows = "2" })%>
        </p>
        <p>
            <label>
               <%-- <%=ViewData.ContainsKey("exists")?"":" style='display:none'"%>--%>
                修改原因：
            </label>
            <%=Html.TextArea("entryversion.reason","", new { style = "width: 100%; height: 100px;", cols = "20", rows = "2" })%>
        </p>
        <p class="submit">
            <input type="button" value="保存" class="button_2" onclick="sub();" />
        </p>
    </fieldset>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">

    <script type="text/javascript">
    var OldTitle=$("#entryversion_Title").val();
    var Has=function(e){
        if($(e).val()!=OldTitle&&$('#id').val()==''){
            OldTitle=$(e).val();
            $.get('<%=Url.Action("Has","Entry")%>',{'title':$(e).val()},function(r){
                r=eval(r);
               FormMsg("#entryversion_Title", r ? '词条已存在' : '',null,false);
            });
        }
    };
    var sub=function(){
        var r= (v_empty("#entryversion_Title", '必填')
            &&v_notin("#entryversion_areaid",["",0], '必填')
            &&v_empty("#entryversion_description", '必填')
           //  &&v_empty("#tags", '必填')
             <%=ViewData.ContainsKey("exists")?@"&&v_empty('#entryversion_reason', '必填')":"" %>
        );
        if(r) $('#entryform').submit();
        return r;
    };
    </script>

</asp:Content>
