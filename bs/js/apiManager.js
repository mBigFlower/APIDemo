var isEditing = false;

$(document).ready(function(){
	GetApis();
});

// 所有的APi数据
var Apis;
var SelectedItem;

function GetApis(){
	// 浏览器地址为了好看，使用detail。 但该页中的ajax使用apis，便于理解。 好吧其实是路由的时候便于区分
	var webUrl = window.location.href;
	var apiUrl = webUrl.replace('detail', 'api/one'); 
	$.get(apiUrl, function(result){
		Apis = result ; 
		if(!Apis || Apis.length == 0){
			NoDataShow();
			return;
		}
		InitList(Apis);
		
		InitBasicParam(Apis[0]);
		InitItemsParam(Apis[0]);
		// 弃用编辑
    	// $(".editable").editable('toggleDisabled');
	});
}
//////////////////////////////////////////////////////
// Init Data
//////////////////////////////////////////////////////
function InitList(data){
	var result = "<li id='"+data[0]._id+"' class='active listItem'><a>"+data[0].name+"</a></li>";
	for (var i = 1; i < data.length; i++) {
		result = result + ("<li id='"+data[i]._id+"' class='listItem'><a>"+data[i].name+"</a></li>");
	}
	$("#ApiNames").html(result);
	
	InitListSelect();
}

function InitBasicParam(oneDetail){
	$("#title").html(oneDetail.name);
	$("#description").html(oneDetail.description);
}

function InitItemsParam(oneDetail){
	var items = oneDetail.items;
	var result = "";
	for (var i = items.length - 1; i >= 0; i--) {
		var lineHtml = "";
		{
			lineHtml = lineHtml + "<tr>";
			lineHtml = lineHtml + "<td>"+items[i].key+"</td>";
			lineHtml = lineHtml + "<td>"+items[i].content+"</td>";
			lineHtml = lineHtml + "<td>"+items[i].isNecessary+"</td>";
			lineHtml = lineHtml + "<td>"+items[i].introduce+"</td>";
			lineHtml = lineHtml + "</tr>";
		}
		result = result + lineHtml;
	}
	$("#detailTable").html(result);
}

function NoDataShow(){
	$("#title").text("Sorry, No Data");
	$("#description").text("There is null in the database.");
	$("#detailTable").html(null);
}


//////////////////////////////////////////////////////
// Init Data End
//////////////////////////////////////////////////////


//////////////////////////////////////////////////////
// Click
//////////////////////////////////////////////////////
function InitListSelect(){
	$(".listItem").click(function(){
		$(this).siblings('li').removeClass('active');  // 删除其他兄弟元素的样式
		$(this).addClass('active'); // 添加当前元素的样式
		
		var itemId = $(this).attr('id');
		SelectedItem = findItemById(itemId);
		if(SelectedItem == null){
			NoDataShow();
		} else {
			InitBasicParam(SelectedItem);
			InitItemsParam(SelectedItem);
		}
	});
}
// 弃用网页版的编辑
// function InitEditClick(){
// 	$("#enableEdit").click(function(){
// 		if(isEditing){
// 			// 发送编辑后的
// 			HttpReviseApi();
// 			isEditing = false;
// 		} else {
// 			$(".editable").editable('toggleDisabled');
// 			isEditing = true;
// 		}
// 	});
// }
//////////////////////////////////////////////////////
// Click End
//////////////////////////////////////////////////////

function HttpReviseApi(){
	var host = window.location.host;
	var apiUrl = host + "/api/revise";

	$.post(apiUrl, {"apiDetail":SelectedItem}, function(result){
		
	});
}


//////////////////////////////////////////////////////
// Other
//////////////////////////////////////////////////////
function findItemByName(name){
	for(var i=0;i<Apis.length;i++){
		if(Apis[i].name == name)
			return Apis[i];
	}
	return null;
}
function findItemById(id){
	for(var i=0;i<Apis.length;i++){
		if(Apis[i]._id == id)
			return Apis[i];
	}
	return null;
}
//////////////////////////////////////////////////////
// Other End
//////////////////////////////////////////////////////




















