﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OutboxList.ascx.cs" Inherits="CHSNS.Web.Views.Message.OutboxList" %>
<%foreach (MessageItemPas ip in ViewData.Model as IEnumerable<MessageItemPas>) {%>
<li id="Items<%=ip.ID%>" class="useritem">
	<p class="image">
		<a href="<%=Url.UserPage(ip.UserID)%>">
			<%=Html.Image(Url.CH().Path.GetFace_Small(ip.UserID), ip.Username)%></a>
	</p>
	<div class="info">
		标题:<%=Html.MessageDetails(ip.Title,ip.ID )%>
		<ul>
			<li>收件人:
				<%=Html.UserPageLink(ip.UserID, ip.Username)%>
			</li>
						<li>发件时间:
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