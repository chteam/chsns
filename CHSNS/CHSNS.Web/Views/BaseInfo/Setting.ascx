<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Setting.ascx.cs" Inherits="CHSNS.Web.Views.BaseInfo.Setting" %>
<%--#if($Source.isNull("Birthday"))
	#set( $birthday = "1986-01-01" )
#else
	#set( $birthday = $Source.get_item("Birthday").ToString("yyyy-MM-dd") )
#end--%>
<div class="notes">
	[*为必填 其它选填] 请完善以下基本信息 </div>
<h4>基本信息</h4>
<div class="required">
	<label for="gender">
		<em>*</em>可见度：</label>
	<div style="padding-left:160px">
<span id="basic_slider_BoundControl"></span><input type="text" value="${Source.get_item("BasicInfoShowLevel")}" id="basic_slider"/>
    </div>
</div>
<div class="required">
	<label for="name"><em>*</em>姓名：</label><input type="text" id="Name" value="$ChHelper.ChUser.Username" />
</div>
<div class="required">
	<label for="gender">
		<em>*</em>性别：</label>
		<select id="Sex" class="select">
		<option value="true">男生</option>
		<option value="false" #if(!$Source.get_item("Sex")) selected="selected" #end>女生</option>
		</select>
</div>

<%--#if(!$source.isNull("Province"))
	#set( $province = $source.get_item('Province') )
#else
	#set( $province = 0 )
#end
#if(!$source.isNull("City"))
	#set( $city = ${Source.get_item("city")} )
#else
	#set( $city = 0 )
#end
#set( $provincerows = $ChHelper.DataCache.ProvinceRows() )
#set( $cityrows = $ChHelper.DataCache.CityRows($province) )--%>
<div class="required">
	<label for="homeProvince">
		<em>*</em>家乡：</label>
		<select id="Province" class="select" onchange="javascript:ChangeProvince()">
#component( OptionList with "Source=$provincerows" "selected=$province")
		</select>
	<span id="CityPanel">
<select id="City" class="select">
#if($source.isNull("city"))
<option value="0" selected="selected">请选择</option>
#else
	#if(!$source.isNull("Province"))
#component(OptionList with "Source=$cityrows" "selected=$city")
	#end
#end
</select></span>
	<span id="CityStatus"></span>
</div>
<div class="optional">
	<label for="birthyear">*生日：</label>
	<input id="Birthday" type="text" value="${birthday}" autocomplete="off" />
	<input type="image" id="Birthdaybut" src="/images/Calendar_scheduleHS.png" alt="Click to show calendar" style="border-width:0px;" onclick="return false;" />
</div>

<div class="actions">
	<input type="button" value="保存修改" class="subbutton" onclick="SubmitInfo('basic');" />
</div>