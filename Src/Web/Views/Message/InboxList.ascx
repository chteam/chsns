<%@ Control Language="C#" AutoEventWireup="true" 
Inherits="System.Web.Mvc.ViewUserControl" %>
<%foreach (MessageItemPas ip in (ViewData.Model as IEnumerable<MessageItemPas>).ToNotNull())
  {%>
<li id="Items<%=ip.ID%>" class="useritem">
	<div class="face face-middle">
		<a href="<%=Url.UserPage(ip.ID) %>" title="<%=ip.Username %>" style="background-image: url(<%=Path.GetFace(ip.ID,ThumbType.Middle) %>);"></a>
	</div>
	<div class="info">
		<%
			if (ip.IsSee) {%>
		标题:<%=Html.MessageDetails(ip.Title,ip.ID )%>
		<%
			}
			else {%>
		<strong>标题:<%=Html.MessageDetails(ip.Title, ip.ID)%></strong>
		<%
			}%>
		<ul>
			<li>发件人:
				<%=Html.UserPageLink(ip.UserID, ip.Username)%>
			</li>
			<li>时间:
				<%=ip.SendTime.ToString("yyyy-MM-dd hh:mm:ss")%>
			</li>
		</ul>
	</div>
	<ul class="actions">
		<li>
			<%=Html.MessageDetails("查看",ip.ID )%></li>
		<li><a href="javascript:Delete(<%=ip.ID %>)">删除</a></li>
	</ul>
</li>
<%} %>