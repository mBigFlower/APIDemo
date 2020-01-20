$(document).ready(function(){
	init();
});

function init(){
    $("button").click(function () {
        ShowDialog();
    });
}

async function ShowDialog() {
    const { value: text } = await swal({
      input: 'textarea',
      inputPlaceholder: 'Input cmd_name here...',
      showCancelButton: true,
    })

    if (text) {
        PostNewAPI(text)
    }
}

function PostNewAPI(apiContent){
    var host = window.location.host;
	var apiUrl = "http://10.110.12.22:8089" + "/feedback/addNewRequest";
    $.post(apiUrl, {"content":apiContent}, function(result){
		Swal.fire('Send Over. Thank You For Your Participation.')
	});
}