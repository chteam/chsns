<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="body-wrap">
	<h1>
		系统事件管理</h1>
	<div class="description">
		说明:
	</div>
	<div class="hr">
	</div>
	<h2>
		模板列表</h2>
	<table cellspacing="0" class="member-table">
		<tr>
			<th class="sig-header" colspan="2">
				模板
			</th>
			<th class="msource-header">
				操作
			</th>
		</tr>
		<tr class="method-row expandable">
			<td class="micon">
				<a class="exi" href="#expand">&nbsp;</a>
			</td>
			<td class="sig">
				<a id="Array-indexOf"></a><b>indexOf</b>(&nbsp;<code>Object o</code>&nbsp;) : Number
				<div class="mdesc">
					<div class="short">
						Checks whether or not the specified object exists in the array.</div>
					<div class="long">
						Checks whether or not the specified object exists in the array.
						<div class="mdetail-params">
							<strong>Parameters:</strong>
							<ul>
								<li><code>o</code> : Object<div class="sub-desc">
									The object to check for</div>
								</li>
							</ul>
							<strong>Returns:</strong>
							<ul>
								<li><code>Number</code><div class="sub-desc">
									The index of o in the array (or -1 if it is not found)</div>
								</li>
							</ul>
						</div>
					</div>
				</div>
			</td>
			<td class="msource">
				Array
			</td>
		</tr>
		<tr class="method-row alt expandable">
			<td class="micon">
				<a class="exi" href="#expand">&nbsp;</a>
			</td>
			<td class="sig">
				<a id="Array-remove"></a><b>remove</b>(&nbsp;<code>Object o</code>&nbsp;) : Array
				<div class="mdesc">
					<div class="short">
						Removes the specified object from the array. If the object is not found nothing
						happens.</div>
					<div class="long">
						Removes the specified object from the array. If the object is not found nothing
						happens.
						<div class="mdetail-params">
							<strong>Parameters:</strong>
							<ul>
								<li><code>o</code> : Object<div class="sub-desc">
									The object to remove</div>
								</li>
							</ul>
							<strong>Returns:</strong>
							<ul>
								<li><code>Array</code><div class="sub-desc">
									this array</div>
								</li>
							</ul>
						</div>
					</div>
				</div>
			</td>
			<td class="msource">
				Array
			</td>
		</tr>
	</table>
</div>
