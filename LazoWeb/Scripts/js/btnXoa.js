$(document).ready(function () {
    $("#example").on('click', '.myBtn', function () {
        var idUser = $(this).attr("data-id");
        $("#myModal").modal();
        $("#cus-delete a").click(function () {
            $.ajax({
                url: "DeleteConfirmed?id=" + idUser,
                type: "get",
                success: function (result) {
                    if (result > 0) {
                        $("#myModal").hide();
                        $("#myNotifySuccess").modal();
                        $("#btn-close").click(function () {
                            location.reload();
                        });
                    } else {
                        $("#myModal").hide();
                        $("#myNotifyFail").modal();
                    }
                }
            });
        });
    });

});
$(document).ready(function () {
    $("#example").on('click', '.myBtnUser', function () {
        var id = $(this).attr("data-id");
        $("#myModal").modal();
        $("#ConfirmDelete").click(function () {
            $.ajax({
                type: "GET",
                url: '/Admin/User/DeleteConfirmedUser?id=' + id,
                success: function (result) {
                    if (result > 0) {
                        $("#myModal").hide();
                        $("#myModalSuccess").modal();
                    }
                    else {
                        $("#myModal").hide();
                        $("#myModalFail").modal();
                    }
                },
                error: function (erro) {
                    console.debug(erro);
                }
            });
        });
    })
});
