var isEditing = false;

$(document).ready(function(){
	GetApis();
});

// 所有的APi数据
var Apis;

function GetApis(){
	// 浏览器地址为了好看，使用detail。 但该页中的ajax使用apis，便于理解。 好吧其实是路由的时候便于区分
	var webUrl = window.location.href;
	var apiUrl = webUrl.replace('detail', 'api/all'); 
	$.get(apiUrl, function(result){
		Apis = result ; 
		if(!Apis || Apis.length == 0){
			NoDataShow();
			return;
		}
		InitList(Apis);
		
		InitBasicParam(Apis[0]);
		InitItemsParam(Apis[0]);
    	$(".editable").editable('toggleDisabled');
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
	// $("#title").text(oneDetail.name);
	$("#title").html('<a class="editable">'+oneDetail.name+'</a>');
	$("#description").html('<a class="editable">'+oneDetail.description+'</a>');

	InitEditClick();
}

function InitItemsParam(oneDetail){
	var items = oneDetail.items;
	var result = "";
	for (var i = items.length - 1; i >= 0; i--) {
		var lineHtml = "";
		{
			lineHtml = lineHtml + "<tr>";
			lineHtml = lineHtml + "<td><a class='editable'>"+items[i].key+"</a></td>";
			lineHtml = lineHtml + "<td><a class='editable'>"+items[i].content+"</a></td>";
			lineHtml = lineHtml + "<td><a class='editable'>"+items[i].isNecessary+"</a></td>";
			lineHtml = lineHtml + "<td><a class='editable'>"+items[i].introduce+"</a></td>";
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
		var selectData = findItemById(itemId);
		if(selectData == null){
			NoDataShow();
		} else {
			InitBasicParam(selectData);
			InitItemsParam(selectData);
		}
	});
}

function InitEditClick(){
	$("#enableEdit").click(function(){
		if(isEditing){
			// 发送编辑后的
			HttpReviseApi();
		} else {
    		$(".editable").editable('toggleDisabled');
		}
	});
}
//////////////////////////////////////////////////////
// Click End
//////////////////////////////////////////////////////

function HttpReviseApi(){

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




















