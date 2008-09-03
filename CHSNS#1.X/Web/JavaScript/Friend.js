/// <reference path="jquery-1.2.3-intellisense.js" />


//同意加对方为好友
function AgreeFriend(Toid,id){
	PageMethods.AddFriend(Toid,function(result){
		if (result==""){
			var count=0;
			if($("FriendCount")!=null)
				count=$get("FriendCount").innerHTML;
			if(count>0)
				$("FriendCount").innerHTML=count-1;
			$("Items"+id).innerHTML='<p class="notes">对方已经成为您的好友</p>';
		}else{
			alertEx(result);
		}
	});
	return;
}
//忽略好友请求
function IgnoreFriend(Toid, id) {
    var bl = confirm('确定忽略此请求吗？');
    if (bl) PageMethods.DeleteFriend(Toid, function(result) {
        if (result == "") {
            var count = 0;
            if ($get("FriendCount") != null)
                count = $get("FriendCount").innerHTML;
            if (count > 0)
                $get("FriendCount").innerHTML = count - 1;
            $get("Items" + id).outerHTML = '';
        } else
            alertEx(result);
    });
    return;
}
function IgnoreAllFriend() {
    var bl = confirm('确定忽略所有请求吗？');
    if (bl) PageMethods.DeleteFriend(0, function(result) {
        if (result == "") {
            var count = 0;
            if ($get("FriendCount") != null)
                count = $get("FriendCount").innerHTML;
            if (count > 0)
                $get("FriendCount").innerHTML = 0;
            //alert("忽略请求成功");
            $get("UserListItems").innerHTML = "<li>已经忽略所有请求</li>";
        } else
            alertEx(result);
    });
    return;
}

//解除好友关系
function DeleteFriend(Toid,id){
	var bl=confirm('确定和此好友解除关系吗？');
	if(bl) PageMethods.DeleteFriend(Toid,function(result){
		if (result==""){
			var count=0;
			if($("FriendCount")!=null)
				count=$("FriendCount").innerHTML;
			if(count>0)
				$("FriendCount").innerHTML=count-1;
			alertEx("解除好友关系成功");
			$("Items"+id).outerHTML='';
		}else
			alertEx(result);
	});
	return;
}
