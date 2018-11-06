$(document).ready(function () {
    $("#email").change(function () {
        var value = $(this).val();
        if (value != null) {
            $("#validemail").hide();
        }
    });
    $("#matkhau").change(function () {
        var value = $(this).val();
        if (value != null) {
            $("#validpass").hide();
        }
    });
    $("#xacnhanmatkhau").change(function () {
        var value = $(this).val();
        if (value != null) {
            $("#validxacnhanmatkhau").hide();
        }
    });
    $("#ho").change(function () {
        var value = $(this).val();
        if (value != null) {
            $("#validho").hide();
        }
    });
    $("#ten").change(function () {
        var value = $(this).val();
        if (value != null) {
            $("#validten").hide();
        }
    });
}
)