// 创建 邹健 2007 10 1
// 最后修改：2007 10 3
// 
var $Item;
function InitServices(){
	if ($Item==null){
		GetTemplate("Servicesitem",function(r){
			$Item=r;
		//	setpage(1);
		});
	}
}
function GetStatus(_){
	switch(_){
	case 1:case 2:
		return "解决中";
	case 255:case 3:
		return "已解决";
	case 0:
	default:
		return "未解决";
	}
}
function Empty(_){
	if(_)return _;else return '';
}
function SendQuestion(){
	alertEx("正在提交...","");
	Chsword.Services.SendServices($get('Hduserid').value,$get('tbody').value,$get('temail').value,function(r){
		var d=new Date();
				var s=String.format($Item,
						"#",
						"本人",
						GetStatus(0),
						d.format("MM-dd HH:mm:ss fff"),
						$get('tbody').value,
						"",
						"",
						0//"false",//>=100为已经结的状态
						);
				alertEx(r);
				$get("Serviceslist").innerHTML=s+$get("Serviceslist").innerHTML;
				$get('tbody').value="";
				d=null;
				s=null;
	},onfail);
}
function setpage(_){
	$get("HdPage").value=_;
	Chsword.Services.ServicesTable(_,10,0,'',function(r){
	var builder = new Sys.StringBuilder("");
				var rows = r.rows;
				if(!rows) {
				builder.append("没有提问的列表");
					return;
				}
				for (var rowIndex = 0; rowIndex < rows.length; ++ rowIndex) {
					builder.append(
						String.format($Item,
						rows[rowIndex]["userid"]==0?String.format("mailto:{0}",rows[rowIndex]["email"]):String.format("/User.aspx?userid={0}",rows[rowIndex]["userid"]),
						rows[rowIndex]["userid"]==0?rows[rowIndex]["email"]:rows[rowIndex]["name"],
						GetStatus(rows[rowIndex]["status"]),
						rows[rowIndex]["sendtime"].format("MM-dd HH:mm"),
						rows[rowIndex]["body"],
						rows[rowIndex]["status"]>=100?rows[rowIndex]["answer"]:"",
						rows[rowIndex]["status"]>=100?rows[rowIndex]["answertime"].format("MM-dd HH:mm"):"",
						rows[rowIndex]["status"]	//rows[rowIndex]["status"]>=100?"true":"false",//>=100为已经结的状态
						)
					);
				}
				$get("Serviceslist").innerHTML=builder;
				PageSet_chSetPage("PageUp","PageDown","HdPage","HdCount","HdEveryPage");
	},onfail);
}