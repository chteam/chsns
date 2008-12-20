<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" AutoEventWireup="true"
    CodeBehind="Edit.aspx.cs" Inherits="CHSNS.Web.Views.Entry.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <%=Html.Script("wysiwyg") %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form action="" method="post" id="entryform">
    <%=Html.Hidden("id")%>
    <h2>
        景点编辑</h2>
    <h4>
        基本信息</h4>
    <table class="memu_2">
        <tr>
            <th>
                景点名称：
            </th>
            <td>
                <%=Html.TextBox("entry.Title", null, new { style = "width: 50%",onblur="Has(this);" })%>
            </td>
        </tr>
                <tr>
            <th>
                内容：
            </th>
            <td><%=Html.TextArea("entryversion.description", new {style="width:100%;height:300px;", cols="20", rows="2" })%></td>
        </tr>
        <tr>
            <th>
                标签：
            </th>
            <td><%=Html.TextBox("tags", null, new { style = "width: 100%" })%>
                <span class="explanation">最多五个标签，每个不超过十个字，多个请用逗号隔开</span>
            </td>
        </tr>
        <tr>
            <th>
                参考资料：
            </th>
            <td>
                <%=Html.TextArea("entryversion.reference", new { style = "width: 100%; height: 100px;", cols = "20", rows = "2" })%>
            </td>
        </tr>
        
        <tr<%=ViewData.ContainsKey("exists")?"":" style='display:none'"%>>
            <th>
                修改原因：
            </th>
            <td>
                <%=Html.TextArea("entryversion.reason", new { style = "width: 100%; height: 100px;", cols = "20", rows = "2" })%>
            </td>
        </tr>
    </table>
    <div class="submit">
        <input type="button" value="保存" class="button_2" onclick="sub();" />
    </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
<script type="text/javascript">
    var getseldata=function(e,cid,at){//获取城市信息
            if($(e).val()!='')
            $.get('<%=Url.Action("Citys","Ajax")%>',{'id':$(e).val(),'at':at},function(r){
                r=eval(r);
                if(r.length>0)
                    BindSelect(cid,r,"Text","Value");
            });
    };
    var OldTitle=$("#entry\\.Title").val();
    var Has=function(e){
        if($(e).val()!=OldTitle&&$('#id').val()==''){
            OldTitle=$(e).val();
            $.get('<%=Url.Action("Has","Entry")%>',{'title':$(e).val()},function(r){
                r=eval(r);
               FormMsg("#entry\\.Title", r ? '词条已存在' : '',null,false);
            });
        }
    };
    var sub=function(){
        var r= (v_empty("#entry\\.Title", '必填')
            &&v_notin("#entryversion_areaid",["",0], '必填')
            &&v_empty("#entryversion\\.description", '必填')
             &&v_empty("#tags", '必填')
             <%=ViewData.ContainsKey("exists")?@"&&v_empty('#entryversion\\.reason', '必填')":"" %>
        );
        if(r) $('#entryform').submit();
        return r;
    };
</script>
</asp:Content>
