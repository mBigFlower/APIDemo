$(document).ready(function(){
	GetApis();
});

function GetApis(){
	// 浏览器地址为了好看，使用detail。 但该页中的ajax使用apis，便于理解。 好吧其实是路由的时候便于区分
	var webUrl = window.location.href;
	var apiUrl = webUrl.replace('detail', 'apis'); 
	$.get(apiUrl, function(result){
		var data = result ; 
		if(!data || data.Length == 0){
			NoDataShow();
			return;
		}
		InitList(data);
		
		InitBasicParam(data[0]);
		InitItemsParam(data[0]);
	});
}

function InitList(data){
	var result = "<li class='active'><a href='/detail?key="+data[0].name+"'>"+data[0].name+"<span class='sr-only'>(current)</span></a></li>";
	for (var i = data.length - 2; i >= 0; i--) {
		result = result + ("<li><a href='/detail?key="+data[i].name+"'>"+data[i].name+"<span class='sr-only'>(current)</span></a></li>");
	}
	$("#ApiNames").html(result);
}

function InitBasicParam(oneDetail){
	$("#title").text(oneDetail.name);
	// $("#description").text(oneDetail.description);
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
	
}