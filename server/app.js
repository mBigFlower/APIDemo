var express = require('express');
var fs = require('fs');
var path = require('path');
var bodyParser = require('body-parser');
var mongooseUtil = require('./mongooseUtil.js');
var email = require('./mailManager.js');
 
var app = express();
// 创建 application/x-www-form-urlencoded 编码解析
var urlencodedParser = bodyParser.urlencoded({ extended: false })
 
// 获取静态文件
app.use(express.static(path.join(__dirname, '../public')));
app.use(express.static(path.join(__dirname, '../bs'))); // __dirname为硬盘的目录，而非网址的目录
 
app.get('/', function (req, res) {
   var remoteIp = req.connection.remoteAddress;
   console.log('remoteIp:'+remoteIp);
   var filePath = path.join(__dirname, '../bs/html/home.html');
   res.sendFile(filePath);
})
app.get('/home', function (req, res) {
   var filePath = path.join(__dirname, '../bs/html/home.html');
   res.sendFile(filePath);
})
app.get('/login', urlencodedParser, function (req, res) {
	// 输出 JSON 格式
   var response = {
       "result":0,
       "message":"login success"
   };
   console.log(response);
   res.setHeader("Access-Control-Allow-Origin", "*");
   res.end(JSON.stringify(response));
   //var filePath = path.join(__dirname, '../bs/html/login.html');
   //res.sendFile(filePath);
})
app.get('/about', function (req, res) {
   var filePath = path.join(__dirname, '../bs/html/about.html');
   res.sendFile(filePath);
})
app.get('/help', function (req, res) {
   var filePath = path.join(__dirname, '../bs/html/help.html');
   res.sendFile(filePath);
})
app.get('/detail', function (req, res) {
   var filePath = path.join(__dirname, '../bs/html/detail.html');
   res.sendFile(filePath);
})
app.get('/api/all', function (req, res) {
   var keyWord = req.query.key;
   console.log('search keyWord:'+keyWord);
   if(!keyWord){
	  res.send('No Data');
	  return;
   }
   mongooseUtil.findByCmdNameOrDesc(keyWord, function (err, apis) {
	  if (err){
  		console.log(err);
  		res.send(err);
	  }
	  else 
		  res.send(apis);
	 })
})

app.post('/add', urlencodedParser, function (req, res) {
  var api = req.body.apiDetail,
  mongooseUtil.addApi(api, function (err, message) {
    if (err){
      console.log(err);
      res.send(err);
    }else {
      var response = {
       "result":"0",
       "message":"save success."
      };
      res.send(response);
    }
   })
})

app.post('/api/revise', urlencodedParser, function (req, res) {
   var api = req.body.apiDetail,

   mongooseUtil.reviseApi(api, function (err, message) {
    if (err){
      console.log(err);
      res.send(err);
    }else {
      var response = {
       "result":"0",
       "message":"revise success."
      };
      res.send(response);
    }
   })
})

app.post('/login_post', urlencodedParser, function (req, res) {
   // 输出 JSON 格式
   var response = {
       "user name":req.body.first_name,
       "password":req.body.last_name
   };
   console.log(response);
   res.end(JSON.stringify(response));
})





// listen 的时候,加上 0.0.0.0 这样 remoteAddress 收到的是 IPv4
var server = app.listen(8081, '0.0.0.0', function () {
 
  var host = server.address().address
  var port = server.address().port
 
  console.log("应用实例，访问地址为 http://%s:%s", host, port)
 
})


console.log('Server running at http://127.0.0.1:8081/');
