$(document).ready(function () {
    // Xóa một khách hàng
    $("#example").on('click', '.myBtn', function () {
        $("#myModal").modal();
        $("#cus-delete a").attr("data-id", $(this).attr("data-id"));
    });
    $("#cus-delete button#close").click(function () {
        $("#cus-delete a").removeAttr("data-id");
    });
    $("#cus-delete a").click(function () {
        var idCus = $(this).attr("data-id");
        $("#myModal").modal("hide");
        $.ajax({
            url: "/Admin/Customers/DeleteConfirmed?id=" + idCus,
            type: "get",
            success: function (result) {
                if (result > 0) {
                    $("#myNotifySuccess").modal();
                    $("#btn-close").click(function () {
                        location.reload();
                    });
                } else {
                    $("#myNotifyFail").modal();
                }
            }
        });
    });

    // Xóa một người dùng
    $("#example").on('click', '.myBtnUser', function () {
        $("#myModal").modal();
        $("#ConfirmDelete").attr("data-id", $(this).attr("data-id"));
    });

    $("#myModel-href button#close").click(function () {
        $("#ConfirmDelete").removeAttr("data-id");
    });

    $("#ConfirmDelete").click(function () {
        var idUser = $(this).attr("data-id");
        $("#myModal").modal("hide");

        $.ajax({
            type: "GET",
            url: '/Admin/User/DeleteConfirmedUser?id=' + idUser,
            success: function (result) {
                if (result > 0) {
                    $("#myModalSuccess").modal();
                }
                else {
                    $("#myModalFail").modal();
                }
            },
            error: function (erro) {
                console.debug(erro);
            }
        });
    });
});
