$(document).ready(function () {
    $(".myBtn").click(function () {
        var id = $(this).attr("data-id");
        $("#myModel-href a").attr('href', '/Admin/Customers/DeleteConfirmed?id=' + id);
        $("#myModal").modal();
    });
});
$(document).ready(function () {
    $(".myBtnUser").click(function () {
        var id = $(this).attr("data-id");
        $("#myModel-href a").attr('href', '/Admin/User/DeleteConfirmed?id=' + id);
        $("#myModal").modal();
    });
});