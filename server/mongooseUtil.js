var mongoose = require('mongoose')
var Api = require('../server/model/ApiModel.js')

// bigflower是库的名字
mongoose.connect('mongodb://localhost/bigflower')

//////////////////////////////////////////////////////////////////////////
// 公共方法
//////////////////////////////////////////////////////////////////////////

function findByCmdNameOrDesc(keyWord, response){
	var filter = {
		$or:[
			{name:{$regex:keyWord}},
			{description:{$regex:keyWord}}
		]
	}
	Api.find(filter, function (err, apis) {
	  response(err, apis);
	});
}
function findAllApis(response){
	Api.find({}, function (err, apis) {
	  response(err, apis);
	});
}

function reviseApi(revisedApi, response){
	Api.findById(revisedApi._id, function (findErr, api) {
	    // 把find到的api，修改后再保存
	    // 修改
	    if(findErr){
	  		response(findErr, "Find Error:"+revisedApi._id);
	    	return;
	    }
	    // 保存
		api.save(function(saveErr, doc){
		    if(saveErr){
		        console.log("error :" + saveErr);
		  		response(saveErr, "Save Error:"+revisedApi._id);
		    } else {
		  		response(saveErr, "Success");
		    }
		});
	});
}

function addApi(newApi, response){
    console.log("addApi newApi:" + newApi);
	var dataModel = new Api(newApi);
    console.log("addApi dataModel:" + dataModel);

	dataModel.save(function(err,doc){
  		response(err, doc);
	});
}

exports.findByCmdNameOrDesc = findByCmdNameOrDesc;
exports.findAllApis = findAllApis;
exports.addApi = addApi;
exports.reviseApi = reviseApi;




// var allData = {
	// "items": [{
		// parentName: null,
		// level: 1,
		// key: "cmd_guid",
		// content: "{5a82bb58-94a1-40b6-9090-8cf85730683c}",
		// isNecessary: false,
		// introduce: null,
		// isRevised: false
	// }, {
		// parentName: null,
		// level: 1,
		// key: "cmd_name",
		// content: "region_list_request_ack",
		// isNecessary: false,
		// introduce: null,
		// isRevised: false
	// }, {
		// parentName: null,
		// level: 1,
		// key: "version",
		// content: "10",
		// isNecessary: false,
		// introduce: null,
		// isRevised: false
	// }, {
		// parentName: null,
		// level: 1,
		// key: "product_name",
		// content: "PUC",
		// isNecessary: false,
		// introduce: null,
		// isRevised: false
	// }, {
		// parentName: null,
		// level: 1,
		// key: "user_guid",
		// content: "{ec982fc8-e74c-47b6-9fb8-7b93ae9de4e9}",
		// isNecessary: false,
		// introduce: null,
		// isRevised: false
	// }, {
		// parentName: null,
		// level: 1,
		// key: "user_name",
		// content: "2",
		// isNecessary: false,
		// introduce: null,
		// isRevised: false
	// }, {
		// parentName: null,
		// level: 1,
		// key: "dispatcher_name",
		// content: "踢人测试",
		// isNecessary: false,
		// introduce: null,
		// isRevised: false
	// }, {
		// parentName: null,
		// level: 1,
		// key: "role",
		// content: "1",
		// isNecessary: false,
		// introduce: null,
		// isRevised: false
	// }, {
		// parentName: null,
		// level: 1,
		// key: "permission_list",
		// content: "",
		// isNecessary: false,
		// introduce: null,
		// isRevised: false
	// }, {
		// parentName: null,
		// level: 2,
		// key: "permission",
		// content: "",
		// isNecessary: false,
		// introduce: null,
		// isRevised: false
	// }, {
		// parentName: null,
		// level: 3,
		// key: "permission_name",
		// content: "CallCtrl",
		// isNecessary: false,
		// introduce: null,
		// isRevised: false
	// }, {
		// parentName: null,
		// level: 3,
		// key: "permission_value",
		// content: "1",
		// isNecessary: false,
		// introduce: null,
		// isRevised: false
	// }, {
		// parentName: null,
		// level: 1,
		// key: "result",
		// content: "0",
		// isNecessary: false,
		// introduce: null,
		// isRevised: false
	// }, {
		// parentName: null,
		// level: 1,
		// key: "LoginServerIP",
		// content: "172.16.1.100",
		// isNecessary: false,
		// introduce: null,
		// isRevised: false
	// }],
	// name: "region_list_request_ack",          
	// category: 'Map',      
	// description: "请求越区告警列表",
	// result:[],
	// guid:"HappyYear2019",
	// id:null,
// };

// var allData = {"items":[{"parentName":null,"level":1,"key":"product_name","content":"PUC","isNecessary":false,"introduce":null},{"parentName":null,"level":1,"key":"version","content":"10","isNecessary":false,"introduce":null},{"parentName":null,"level":1,"key":"cmd_name","content":"puc_logout","isNecessary":false,"introduce":null},{"parentName":null,"level":1,"key":"cmd_guid","content":"{e95d1348-6c4d-46ac-8234-20c8b0e3652e}","isNecessary":false,"introduce":null},{"parentName":null,"level":1,"key":"puc_id","content":"00001","isNecessary":false,"introduce":null},{"parentName":null,"level":1,"key":"user_name","content":"2","isNecessary":false,"introduce":null}],"name":"puc_logout","id":null,"guid":"97bf0b0b-cc8d-4772-9d38-9eeaba2ef579","description":null,"results":[]}


// var dataModel = new Api(allData);

// dataModel.save(function(err,doc){
    // if(err){
        // console.log("error :" + err);
    // } else {
        // console.log(doc);
    // }
// });





