﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	CodeBehind="List.aspx.cs" Inherits="CHSNS.Web.Views.Group.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<fieldset>
		<legend>群列表</legend>
		<div class="ch_content">
			<ul class="userlist">
				<%  foreach (CHSNS.Models.Group p in ViewData.Model.ToNotNull()) { %>
				<li id="Items<%=p.ID %>" class="useritem">
					<div class="face face-middle">
						<a href="<%=Url.UserPage(p.ID) %>" title="<%=p.Name %>" style="background-image: url();">
						</a>
					</div>
					<div class="info">
						<strong>
							<%=Html.UserPageLink(p.ID,p.Name) %></strong>
						<ul>
							<li>浏览：
								<%=Html.FriendLink(p.ID) %>
								|
								<%=Html.BlogLink(p.ID) %>
								|
								<%=Html.AlbumLink(p.ID) %>
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
