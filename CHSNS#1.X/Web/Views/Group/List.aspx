﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewPage<PagedList<IGroup>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<fieldset>
		<legend>群列表</legend>
		<%=Html.ActionLink("新建", "Create")%>
		<div class="ch_content">
			<ul class="userlist">
				<%  foreach (IGroup p in ViewData.Model.ToNotNull()) { %>
				<li id="Items<%=p.ID %>" class="useritem">
					<div class="face face-middle">
						<a href="<%=Url.LinkGroupIndex(p.ID) %>"
						title="<%=p.Name %>" style="background-image: url();"></a>
					</div>
					<div class="info">
						<strong><a href="<%=Url.LinkGroupIndex(p.ID) %>"><%=p.Name %></a></strong>
						<ul>
							<li>
							</li>
						</ul>
					</div>
					<ul class="actions">
					</ul>
				</li>
				<%} %>
			</ul>
		</div>
	</fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
