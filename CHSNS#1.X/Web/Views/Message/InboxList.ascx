<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InboxList.ascx.cs" Inherits="CHSNS.Web.Views.Message.InboxList" %>
<%foreach (MessageItemPas ip in ViewData.Model as IEnumerable<MessageItemPas>) {%>
<li id="Items<%=ip.ID%>" class="useritem">
	<p class="image">
		<a href="<%=Url.UserPage(ip.UserID)%>">
			<%=Html.Image(Url.CH().Path.GetFace_Small(ip.UserID), ip.Username)%></a>
	</p>
	<div class="info">
		<%
			if (ip.IsSee) {%>
		标题:<%=Html.MessageDetails(ip.Title,ip.ID )%>
		<%
			} else {%>
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