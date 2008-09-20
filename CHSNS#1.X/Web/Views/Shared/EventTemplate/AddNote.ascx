<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddNote.ascx.cs" Inherits="CHSNS.Web.Views.Shared.EventTemplate.AddNote" %>
<%
	CHSNS.Models.Event e = ViewData.Model;
	Newtonsoft.Json.JsonReader jr = new Newtonsoft.Json.JsonConverter
	 %>
<a href="/User.aspx?userid=${fromid}">${app}</a>
#showdel( ${id} ${fromid} )
</li>
#elseif(${type}==2)##发表了日志
<li class="icon_note" id="Profile_Event_item${id}">
<a href="/User.aspx?userid=${fromid}">${fromname}</a>
于${time}
发表日志
<a href="/Note.aspx?id=${actionid}">${app}</a>
#showdel( ${id} ${fromid} )
</li>