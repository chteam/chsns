/// <reference name="MicrosoftAjax.debug.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference path="basic.js" />


 	var currentItemID = 0;  
 	
    //选择文件后的事件,iframe里面调用的
    var uploading = function(imgsrc,itemid){
		var el = $get("uploading"+itemid);
		hideLayer("ifUpload"+itemid);
		el.style.display="block";
		el.innerHTML=("<img src='/images/ajax-loader.gif' align='absmiddle' /> 上传中...请稍候");
	    return el;
    };
    
    //重新上传方法    
    var uploadinit = function(itemid){
		
        hideLayer("uploading"+itemid);
				 showLayer("ifUpload"+itemid);
				hideLayer("panelViewPic"+itemid);
//        });
               
    };
    
    //上传时程序发生错误时，给提示，并返回上传状态
    var uploaderror = function(e){
        alertEx(e);
        uploadinit(currentItemID ++);
    };
    //创建一个上传控件
    var uploadcreate = function(el,itemid,context,page){
        currentItemID ++;
        if(itemid == null)
        {
            itemid = currentItemID;
        }  
        var strContent = new Sys.StringBuilder("<div class='uploadcontrol'><iframe src=\""+page+".aspx?id=");
		strContent.append(itemid);
		strContent.append("&");
		strContent.append(context);
		strContent.append("\" id=\"ifUpload");
		strContent.append(itemid);
		strContent.append("\" frameborder=\"no\" scrolling=\"no\" style=\"width:250px; height:28px;\"></iframe>");
		strContent.append("<div class=\"uploading\" id=\"uploading");
		strContent.append(itemid);
		strContent.append("\" style=\"display:none;\" ></div>");
		strContent.append("<div class=\"image\" id=\"panelViewPic");
		strContent.append(itemid);
		strContent.append("\" style=\"display:none;\"></div></div>");
	    el.innerHTML=strContent.toString();
    };