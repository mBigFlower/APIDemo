## Mongoose 基本用法

有必要做一下记录



### 查找

Model.find(conditions, [projection], [options], [callback])
Model.findOne([conditions], [projection], [options], [callback])
Model.findById(id, [projection], [options], [callback])

- conditions : 查询条件
- projection : 控制返回的字段（比如我一个 User，有 name 和 age 两个字段，我查找只关心 name，那 age 就可以不返回）
- options : 控制选项（新手用不到，有需要的可以自己搜）
- callback : 没啥说的，查找的返回

#### 基本查找

查找名字为 'Big666' 的，条件写法为：

	var conditions = {name:'Big666'}
	
具体代码为：
	
	var conditions = {name:'Big666'}
	YourModel.find(conditions, function(err, docs){
		if(err)
			console.log(err);
		else
			console.log('查询结果：' + docs);
	})

等价为

	YourModel.find({name:'Big666'}, function(err, docs){
		if(err)
			console.log(err);
		else
			console.log('查询结果：' + docs);
	})	

#### 模糊查找

查找名字里含有 '张三' 的

	var conditions = {name:{$regex:'张三'}}

#### 复杂条件

比如我想查找姓名包含“张三”或别名包含“张三”的

	//$or 表示或语句
	// $regex 模糊查找
	var conditions = {
		$or:[
			{name:{$regex:'张三'}},
			{alias:{$regex:'张三'}}
		]
	}

	
	
	
	
	
	