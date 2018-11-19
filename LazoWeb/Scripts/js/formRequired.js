$(document).ready(function () {
    $("#Name").change(function () {
        var value = $(this).val();
        if (value != "") {
            $("#ValidName").html("");
        }
    });
    $("#Company").change(function () {
        var value = $(this).val();
        if (value != "") {
            $("#ValidCompany").html("");
        }
    });
    $("#NumberEmployee").change(function () {
        var value = $(this).val();
        if (value != "") {
            if (value < 1) {
                $("#ValidNumberEmployee").html("Vui lòng nhập số lớn hơn 0");
            }
            else {
                $("#ValidNumberEmployee").html("");
            }
        }
    });
    $("#Phone").change(function () {
        var phone = $(this).val().trim();
        phone = phone.replace('(+84)', '0');
        phone = phone.replace('+84', '0');
        phone = phone.replace('0084', '0');
        phone = phone.replace(/ /g, '');
        if (phone != "") {
            var firstNumber = phone.substring(0, 1);
            if ((firstNumber == '0' && phone.length == 10) || (firstNumber == '0' && phone.length == 11)) {
                if (phone.match(/^[0-9]+$/)) {
                    CheckPhone(phone);               
                } else {
                    $("#ValidPhone").html("Số điên thoại gồm 10-11 ký tự số!");
                }
            }
            else {
                $("#ValidPhone").html("Số điên thoại gồm 10-11 ký tự số!");
            }
        }
    });
    function CheckPhone(phone) {
        $.ajax({
            url: "CheckExistingPhone?phone=" + phone, 
            type: "get",
            dateType: "Boolean", 
            
            success: function (result) {
                if (result == "True") {
                    $("#ValidPhone").html("");
                } else {
                    $("#ValidPhone").html("Số địện thoại đã tồn tại!");
                }
            }
        });
    }
    $("#Email").change(function () {
        var email = $(this).val();
        var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        if (email != "") {
            if (!filter.test(email)) {
                $("#ValidEmail").html("Hãy nhập địa chỉ Email hợp lệ!.\nExample@gmail.com");
            }
            else {
                CheckEmail(email);
            }
        }
    });
    function CheckEmail(email) {
        $.ajax({
            url: "CheckExistingEmail?email=" + email,
            type: "get",
            dateType: "Boolean",

            success: function (result) {
                if (result == "True") {
                    $("#ValidEmail").html("");
                } else {
                    $("#ValidEmail").html("Email đã tồn tại");
                }
            }
        });
    }
    $(".captcha a").html('<h4 style="float:left;"><i class="fas fa-sync-alt"></i></h4>');
    $("#CaptchaInputText").attr("placeholder", "Nhập mã...");
});