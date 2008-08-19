/// <reference name="MicrosoftAjax.js"/>
// Global variables 
var Label_Show=function(){
	return $get('Profile_ShowText');
};
var Edit_Show=function(){
	return $get('Profile_ShowText_Edit');
};
Sys.Application.add_init(AppInit);
function AppInit(sender) {
  if(Label_Show()==null||!Edit_Show())
	return;
  $addHandler(Label_Show(), "dblclick", Label_Show_Click);
  $addHandler(Edit_Show(), "blur", Edit_Show_Blur);
  $addHandler(Edit_Show(), "keydown", Edit_Show_KeyDown);
}

function Label_Show_Click() {
	if(Label_Show().innerHTML=="什么也没做")
		Edit_Show().value = "";
	else
		Edit_Show().value = Label_Show().innerHTML;
	Label_Show().style.display = 'none';
	Edit_Show().style.display = '';
	Edit_Show().focus();
}
function Edit_Show_KeyDown(event) {
  if (event.keyCode == 13) {
    event.preventDefault();
    Edit_Show().blur();
  }
}
function Edit_Show_Blur(){
	var labelUpdated=(Label_Show().innerHTML.trim() != Edit_Show().value.trim());
	Label_Show().innerHTML = Edit_Show().value;
	$get("Profile_ShowTextTime").innerHTML="刚刚";
	if(Label_Show().innerHTML.trim()=='')
		Label_Show().innerHTML="什么也没做";
	Edit_Show().style.display = 'none';
	Label_Show().style.display = '';
	if (labelUpdated)
		ChAlumna.Profile.ShowText_Edit(Edit_Show().value,null,onfail);
}
function Event_Remove(id){
 	ChAlumna.Profile.Event_Remove(id,function(r){
 		if(r){
 			GetVm("/html/myevent.ashx","",function(r){
				$("Profile_Event").innerHTML=r.get_responseData();
				AjaxControlToolkit.Animation.FadeInAnimation.play($("Profile_Event"),
 1, 25, 0.2, 1, false);
			});
 		}
	},onfail);
}