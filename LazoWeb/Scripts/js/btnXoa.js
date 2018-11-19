$(document).ready(function () {
    $(".myBtn").click(function () {
        var idUser = $(this).attr("data-id");
        $("#myModal").modal();
        $("#cus-delete a").click(function () {
            $.ajax({
                url: "DeleteConfirmed?id="+idUser,
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
    $(".myBtnUser").click(function () {
        var id = $(this).attr("data-id");
        $("#myModel-href a").attr('href', '/Admin/User/DeleteConfirmed?id=' + id);
        $("#myModal").modal();
    });
});
        $("#ConfirmDelete").click(function () {
            $.ajax({
                type: "GET",
                url: '/Admin/User/DeleteConfirmed?id=' + id,
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
