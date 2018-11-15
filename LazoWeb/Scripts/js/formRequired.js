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
    $("#Address").change(function () {
        var value = $(this).val();
        if (value != "") {
            $("#ValidAddress").html("");
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