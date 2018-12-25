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

function SendEmail(title, content){
	var options = {
        from        : 'heilongjiang333@126.com',
        to          : ['shenghua.chen@hytera.com', "252565596@qq.com"],
        subject     : title,
        text        : content,
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


//SendEmail("Js", "SendEmail");

exports.SendEmail = SendEmail;