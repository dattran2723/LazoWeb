$(document).ready(function () {
    $(".captcha a").html('<h4 style="float:left;"><i class="fas fa-sync-alt"></i></h4>');
    $("#CaptchaInputText").attr({
        placeholder: "nhập mã...",
        style: "text-transform: uppercase"
    });
});