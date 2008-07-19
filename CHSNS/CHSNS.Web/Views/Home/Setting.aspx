<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	CodeBehind="Setting.aspx.cs" Inherits="CHSNS.Web.Views.Home.Setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">

	<%=Html.CSSLink("mypage") %>
	<%=Html.Script("jquery-ui") %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div id="toc">
		<ul>
			<%		
				int num = 0;
				int currentnum = 0;
				foreach (ISystemApplication ip in UnitySingleton.CurrentSystemApplication) {
					if (ip.ControllerName.ToLower() == ViewData["current"].ToString()) {
						currentnum = num;
					}
			%>
			<li>
				<%=Html.ActionLink(ip.Name,"Setting",ip.ControllerName) %></li>
			<%
				num++;
				}
			%>
			<li class="status"></li>
		</ul>
	</div>

	<script type="text/javascript">


//#if($Tabs==5)
//	uploadcreate($get('uploadfield'),1,"type=userface","upload");
//#end
$("#toc > ul").tabs({cache:true,selected:<%=currentnum %>,select:function(ui) {
                        alert(ui.panel);
                    }
                    });
	</script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
