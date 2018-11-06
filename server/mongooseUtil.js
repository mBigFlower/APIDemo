var mongoose = require('mongoose')
var Api = require('../server/model/ApiModel.js')

// bigflower是库的名字
mongoose.connect('mongodb://localhost/bigflower')



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
// };


// var dataModel = new Api(allData);

// dataModel.save(function(err,doc){
    // if(err){
        // console.log("error :" + err);
    // } else {
        // console.log(doc);
    // }
// });





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

exports.findByCmdNameOrDesc = findByCmdNameOrDesc;

