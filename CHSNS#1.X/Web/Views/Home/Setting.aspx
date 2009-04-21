<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewPage" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
	<%=Html.CSSLink("mypage") %>
	<%=Html.CSSLink("calendar.css")%>
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
	<div id="as2">
	</div>

	<script type="text/javascript">
		$("#toc > ul").tabs({cache:true,selected:<%=currentnum %>});
	</script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">

	<script type="text/javascript">
	
var ChangeProvince=function(){
	Msg('#CityStatus','Loading...');
	$.postJSON('<%=Url.Action("CityList","Ajax") %>',{"ProvinceID":$("#ProvinceID").val()},function(r){
		BindSelect('#CityID',r,'Name','ID');
	});
	
};
var SBaseInfo=function(){
	if(validate_empty('#Name','姓名为必添项')
	&&validate_regex('#ProvinceID',/[^0]+/,false,'省为必选')
	&&validate_regex('#CityID',/[^0]+/,false,'市为必选')
	&&validate_date('#Birthday','请写入正确日期')
	)
	$.post('<%=Url.Action("AjaxSave","BaseInfo") %>',$("#BasicInfofrm").serialize(),function(r){
if(''==r)
alertEx('成功提交');
	});
};
	</script>

</asp:Content>
