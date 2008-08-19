// JScript 文件
function set_Size(_){//加以控制文本输入大小的功能
	var h=parseInt($('tbody___Frame').height);
	if(_<0&&h<250) return;
	$('tbody___Frame').height=h+_;
} 
