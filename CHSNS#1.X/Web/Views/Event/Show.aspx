<%@ Page Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>

<%
	long UserID = Convert.ToInt64(ViewData["UserID"]);
	//byte type = Convert.ToByte(ViewData["Type"]);
	
%>
<%--#macro(showdel $id $uid )
	#if($uid==$session.get_item("userid"))
		<a class="icon_close" href="javascript:Event_Remove(<%=dr["id"]%>);">&nbsp;&nbsp;</a>
	#end
#end--%>
<%
	foreach (DataRow dr in ViewData["eventrows"] as DataRowCollection) {

		if (Convert.ToByte(dr["type"]) == 1) { %>
<li class="icon_showtext" id="Profile_Event_item<%=dr["id"]%>"><a href="/User.aspx?userid=<%=dr["fromid"]%>">
	<%=dr["fromname"]%></a> 于<%=Convert.ToDateTime(dr["addtime"]).ToString("MM-dd HH:mm")%>
	更改了状态 <a href="/User.aspx?userid=<%=dr["fromid"]%>">
		<%=dr["application"]%></a>
	<%} else if (Convert.ToByte(dr["type"]) == 2) { %>
	<li class="icon_note" id="Profile_Event_item<%=dr["id"]%>"><a href="/User.aspx?userid=<%=dr["fromid"]%>">
		<%=dr["fromname"]%></a> 于<%=Convert.ToDateTime(dr["addtime"]).ToString("MM-dd HH:mm")%>
		发表日志 <a href="/Note.aspx?id=<%=dr["actionid"]%>">
			<%=dr["application"]%></a>
		<%} else if (Convert.ToByte(dr["type"]) == 3) { %><%--##建立了相册--%>
		<li class="icon_album" id="Profile_Event_item<%=dr["id"]%>"><a href="/User.aspx?userid=<%=dr["fromid"]%>&amp;">
			<%=dr["fromname"]%></a> 于<%=Convert.ToDateTime(dr["addtime"]).ToString("MM-dd HH:mm")%>
			建立像册 <a href="/Album.aspx?albumid=<%=dr["actionid"]%>&amp;userid=<%=dr["fromid"]%>&amp;">
				<%=dr["application"]%></a>
			<%} else if (Convert.ToByte(dr["type"]) == 4) { %><%--##创建群--%>
			<li class="icon_group" id="Profile_Event_item<%=dr["id"]%>"><a href="/User.aspx?userid=<%=dr["fromid"]%>&amp;">
				<%=dr["fromname"]%></a> 于
				<%=Convert.ToDateTime(dr["addtime"]).ToString("MM-dd HH:mm")%>
				建立群 <a href="/group.aspx?id=<%=dr["actionid"]%>&amp;">
					<%=dr["application"]%></a>
				<%} else if (Convert.ToByte(dr["type"]) == 5) { %><%--##发布了视频--%>
				<li class="icon_supernote" id="Profile_Event_item<%=dr["id"]%>"><a href="/User.aspx?userid=<%=dr["fromid"]%>&amp;">
					<%=dr["fromname"]%></a> 于
					<%=Convert.ToDateTime(dr["addtime"]).ToString("MM-dd HH:mm")%>
					发布视频 <a href="/SuperNote.aspx?userid=<%=dr["fromid"]%>&amp;">
						<%=dr["application"]%></a>
					<%} else if (Convert.ToByte(dr["type"]) == 6) { %>
					<li class="icon_groupuser" id="Profile_Event_item<%=dr["id"]%>"><a href="/User.aspx?userid=<%=dr["fromid"]%>&amp;">
						<%=dr["fromname"]%></a> 于<%=Convert.ToDateTime(dr["addtime"]).ToString("MM-dd HH:mm")%>
						加入群 <a href="/Group.aspx?id=<%=dr["actionid"]%>&amp;">
							<%=dr["application"]%></a>
						<%}
	if (CHUser.UserID == UserID) {
						%>
						<a class="icon_close" href="javascript:Event_Remove(<%=dr["id"]%>);">&nbsp;&nbsp;</a>
						<%
							}
						%>
					</li>
					<%
						}%>