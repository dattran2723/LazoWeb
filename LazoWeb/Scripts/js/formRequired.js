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
            var firstNumber = phone.substring(0, 2);
            if ((firstNumber == '09' || firstNumber == '08' || firstNumber == '03') && phone.length == 10) {
                if (phone.match(/^[0-9]+$/)) {
                    CheckPhone(phone);               
                } else {
                    $("#ValidPhone").html("Số địện thoại không đúng định dạng");
                    $("#btn-submit").attr("disabled", true);
                }
            }
            else {
                if (firstNumber == '01' && phone.length == 11) {
                    if (phone.match(/^[0-9]+$/)) {
                        CheckPhone(phone);
                    } else {
                        $("#ValidPhone").html("Số địện thoại không đúng định dạng");
                        $("#btn-submit").attr("disabled", true);
                    }
                } else {
                    $("#ValidPhone").html("Số địện thoại không đúng định dạng");
                    $("#btn-submit").attr("disabled", true);
                }
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
                    $("#btn-submit").attr("disabled", false);
                } else {
                    $("#ValidPhone").html("Số địện thoại đã tồn tại");
                    $("#btn-submit").attr("disabled", true);
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
                    $("#btn-submit").attr("disabled", false);
                } else {
                    $("#ValidEmail").html("Email đã tồn tại");
                    $("#btn-submit").attr("disabled", true);
                }
            }
        });
    }
});