$(document).ready(function () {
    var pass;
    $("#email").change(function () {
        var value = $(this).val();
        var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        if (value != "") {
            if (!filter.test(value)) {
                $("#validemail").html("Email nhập vào không hợp lệ.Vui lòng nhập lai !");
            }
            else {
                $("#validemail").html("");
            }
        }
    });
    $("#matkhau").change(function () {
        var value = $(this).val();
        pass = value;
        if (value != "") {
            $("#validpass").hide();
        }
    });
    $("#xacnhanmatkhau").change(function () {
        var value = $(this).val();
        if (value != "") {
            if (value != pass) {
                $("#validxacnhanmatkhau").html("Mật khẩu nhập lại không đúng với mật khẩu");
            }
            else {
                $("#validxacnhanmatkhau").html("");
            }
        }
    });
    $("#ho").change(function () {
        var value = $(this).val();
        //var filter = /@"^(\p{L}+\s?)*$"/;
        if (value != "") {
            //if (!filter.test(value)) {
            //    $("#validho").html("Họ không chứa số và kí tự đặc biệt!");
            //}
            //else {
                $("#validho").hide();
            //}

        }
    });
    $("#ten").change(function () {
        var value = $(this).val();
        //var filter = /@"^(\p{L}+\s?)*$"/;
        if (value != "") {
            //if (!filter.test(value)) {
            //    $("#validten").html("Tên không chứa số và kí tự đặc biệt!");
            //}
            //else {
                $("#validten").html("");
            //}
        }
    });
}
)