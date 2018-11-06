$(document).ready(function () {
    $("#matkhaucu").change(function () {
        var value = $(this).val();
        if (value != null) {
            $("#validmatkhaucu").hide();
        }
    });
    $("#matkhaumoi").change(function () {
        var value = $(this).val();
        if (value != null) {
            $("#validmatkhaumoi").hide();
        }
    });
    $("#matkhaunhaplai").change(function () {
        var value = $(this).val();
        if (value != null) {
            $("#validmatkhaunhaplai").hide();
        }
    });
}
)