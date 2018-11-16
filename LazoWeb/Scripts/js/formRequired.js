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
                    $("#ValidPhone").html("");
                    $("#btn-submit").attr("disabled", false);
                } else {
                    $("#ValidPhone").html("Số địện thoại không đúng định dạng");
                    $("#btn-submit").attr("disabled", true);
                }
            }
            else {
                if (firstNumber == '01' && phone.length == 11) {
                    if (phone.match(/^[0-9]+$/)) {
                        $("#ValidPhone").html("");
                        $("#btn-submit").attr("disabled", false);
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
    $("#Email").change(function () {
        var value = $(this).val();
        var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        if (value != "") {
            if (!filter.test(value)) {
                $("#ValidEmail").html("Hãy nhập địa chỉ Email hợp lệ.\nExample@gmail.com");
                $("#Email").focus;
            }
            else {
                $("#ValidEmail").html("");
            }
        }
    });
});