var nodemailer  = require('nodemailer');

var mailTransport = nodemailer.createTransport({
    host : 'smtp.126.com',  // 妈蛋，这里是host，而不是server。坑惨了
    secureConnection: true, // 使用SSL方式（安全方式，防止被窃取信息）
    port: 465, // SMTP 端口
    auth : {
        user : 'heilongjiang333@126.com',
        pass : 'aijiang2shi'
    },
});

function SendEmail(){
	var options = {
        from        : 'heilongjiang333@126.com',
        to          : '252565596@qq.com',
        // cc         : ''  //抄送
        // bcc      : ''    //密送
        subject        : '一封来自126网易333的邮件',
        text          : '你好我是text',
    };
    
	console.log('即将发送邮件');
    mailTransport.sendMail(options, function(err, msg){
        if(err){
            console.log(err);
        }
        else {
            console.log(msg);
        }
    });
}

exports.SendEmail = SendEmail;

SendEmail()
