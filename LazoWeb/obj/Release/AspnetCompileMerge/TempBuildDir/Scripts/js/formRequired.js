$(document).ready(function () {
    $("#Name").change(function () {
        var value = $(this).val();
        if (value != "") {
            $("#ValidName").hide();
        }
    });
    $("#Company").change(function () {
        var value = $(this).val();
        if (value != "") {
            $("#ValidCompany").hide();
        }
    });
    $("#NumberEmployee").change(function () {
        var value = $(this).val();
        if (value != "") {
            $("#ValidNumberEmployee").hide();
        }
    });
    $("#Address").change(function () {
        var value = $(this).val();
        if (value != "") {
            $("#ValidAddress").hide();
        }
    });
    $("#Email").change(function () {
        var value = $(this).val();
        if (value != "") {
            $("#ValidEmail").hide();
        }
    });
});