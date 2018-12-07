$(document).ready(function () {
    var IdUserLogin = $('#btn-changePass').attr('data-id');
    $("#manage-accounts").addClass("active");
    $("#manage-accounts #list-accounts").addClass("active");
    var counter = 0;

    $('#example').DataTable({
        responsive: true,
        stateSave: true,
        ajax: "/api/users",
        columns: [
            {
                data: null,
                render: function () {
                    return ++counter;
                }
            },
            { data: "Email" },
            { data: "LastName" },
            {
                data: "CreatedDate",
                render: function (data) {
                    var date = new Date(data);
                    return date.toLocaleDateString('en-GB');
                }
            },
            {
                data: "EmailConfirmed",
                render: function (data) {
                    return data ? "Đã liên hệ" : "Chưa liên hệ";
                }
            },
            {
                data: "Id",
                render: function (data) {
                    if (data != IdUserLogin)
                        return '<a data-toggle="tooltip" title="Sửa" href="/admin/user/edit?id=' + data + '" > <i class="fas fa-edit"></i></a > ' + ' ' +
                            '<a data-toggle="tooltip" title="Chi tiết" href="/admin/user/details?id=' + data + '"><i class="fas fa-info-circle"></i></a>' + ' ' +
                            '<a data - toggle="tooltip" class="myBtnUser" title="Xóa" href="javascript:;" data-id="' + data + '"><i class="fas fa-trash-alt text-danger"></i></a>'
                    return '<a data-toggle="tooltip" title="Sửa" href="/admin/user/edit?id=' + data + '" > <i class="fas fa-edit"></i></a > ' + ' ' +
                        '<a data-toggle="tooltip" title="Chi tiết" href="/admin/user/details?id=' + data + '"><i class="fas fa-info-circle"></i></a>'
                }
            }
        ],
        "rowCallback": function (row, data, index) {
            $('td:eq(1)', row).html(
                '<a style="text-decoration: none;" href = "/Admin/User/Details?id=' + data.Id + '">' + data.Email + '</a>'
            );
            $('td:eq(2)', row).html(
                data.LastName + ' ' + data.FirstName
            );
        },
    });
});