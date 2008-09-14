<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Single.Master" AutoEventWireup="true"
	CodeBehind="Agreement.aspx.cs" Inherits="CHSNS.Web.Views.Account.Agreement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<fieldset class="regagreement">
		<legend>注册协议</legend>
		<div class="regtext">
			<br />
			<p>
				本网站中的内容、文章仅代表作者个人观点，不代表<strong>佳木斯大学校友录</strong>(http://www.cnjmsu.com/，以下简称<strong>本站</strong>)
				的看法。任何通过本网站链接进入而得到的资讯、产品及服务 以及用户自行提供的页面，其所有权归相应的所有者。 与本网站之间，除了提供符合国家法律法规的技术信息交流媒介以外，无任何关系。
				<strong><a href="/Help/AboutUs.aspx">成幻小组</a></strong>不声明或保证上述内容或网站的正确性和可靠性，亦不为此承担法律责任。</p>
			<p>
				用户基于自愿的原则使用本网站 ，<strong><a href="/Help/AboutUs.aspx">成幻小组</a></strong> 仅负责解答软件用户的技术问题，及提供用户间技术交流的媒介，
				不对网站用户及其所拥有网站或论坛上发布的内容负责。
			</p>
			服务条款的确认和接纳：
			<p>
				本站服务的所有权和运作权归本站所有。所提供的服务必须按照其发布的公司章程，服务条款和操作规则严格执行。用户通过完成注册程序并点击一下"我同意"的按钮，这表示用户与本站达成协议并接受所有的服务条款。</p>
			服务修订：
			<p>
				本站保留随时修改或中断服务而不需通知用户的权利。用户接受本站行使修改或中断服务的权利，本站不需对用户或第三方负责。</p>
			用户管理：
			<p>
				用户单独承担发布内容的责任。用户对服务的使用是根据所有适用于服务的地方法律、国家法律和国际法 律标准的。</p>
			<br />
			<strong>用户承诺：</strong>
			<ol style="list-style: none; margin-top: 15px;">
				<li>1.在本站的网页上发布信息或者利用本站的服务时必须符合中国有关法规，不得在本站的网页上或者利用本站的服务制作、复制、发布、传播以下信息：
					<ul style="list-style: none; margin-left: 15px; margin-top: 0px;">
						<li>a.反对宪法所确定的基本原则的；</li>
						<li>b.危害国家安全，泄露国家秘密，颠覆国家政权，破坏国家统一的；</li>
						<li>c.损害国家荣誉和利益的；</li>
						<li>d.煽动民族仇恨、民族歧视，破坏民族团结的；</li>
						<li>e.破坏国家宗教政策，宣扬邪教和封建迷信的；</li>
						<li>f.散布谣言，扰乱社会秩序，破坏社会稳定的；</li>
						<li>g.散布淫秽、色情、赌博、暴力、凶杀、恐怖或者教唆犯罪的；</li>
						<li>h.侮辱或者诽谤他人，侵害他人合法权益的；</li>
						<li>i.含有法律、行政法规禁止的其他内容的。</li>
					</ul>
				</li>
				<li>&nbsp;</li>
				<li>2.在本站的网页上发布信息或者利用本站的服务时还必须符合其他有关国家和地区的法律规定以及国际法的有关规定。</li>
				<li>&nbsp;</li>
				<li>3.不利用本站的服务从事以下活动：
					<ul style="list-style: none; margin-left: 15px; margin-top: 0px;">
						<li>a. 未经允许，进入计算机信息网络或者使用计算机信息网络资源的；</li>
						<li>b. 未经允许，对计算机信息网络功能进行删除、修改或者增加的；</li>
						<li>c. 未经允许，对进入计算机信息网络中存储、处理或者传输的数据和应用程序进行删除、修改或者增加的；</li>
						<li>d. 故意制作、传播计算机病毒等破坏性程序的；</li>
						<li>e. 其他危害计算机信息网络安全的行为。</li>
					</ul>
				</li>
				<li>&nbsp;</li>
				<li>4.以任何方式干扰本站的服务。</li>
				<li>&nbsp;</li>
				<li>5.遵守本站的所有其他规定和程序。用户需对自己在使用本站服务过程中的行为承担法律责任。</li>
				<li>&nbsp;</li>
			</ol>
		</div>
	</fieldset>
	<div class="regagreementsub">
	
		<input type="button" class="subbutton" value="我同意" onclick="javascript:location='<%=Url.Action("RegPage") %>'" />
		<input type="button" value="不同意" onclick="javascript:window.location = '/';" class="subbutton" />
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
