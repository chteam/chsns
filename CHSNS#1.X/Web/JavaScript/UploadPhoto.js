// 2007919邹健


var uploadsuccess = function(showul,itemid){
	alertEx("文件上传成功.");
    $get("face_span").innerHTML="<img id=Userface src='"+showul+"?"+Math.random()+"' alt=''/>";
	uploadcreate($get('uploadfield'),1,"type=userface","upload");
};
