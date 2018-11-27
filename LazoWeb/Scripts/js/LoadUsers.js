$(document).ready(function () {
    var IdUserLogin = $('#btn-changePass').attr('data-id');
    $("#manage-accounts").addClass("active");
    $("#manage-accounts #list-accounts").addClass("active");
    $('#example').DataTable({
        responsive: true,
        stateSave: true,
        ajax: "/api/users",
        columns: [
            { data: null },
            { data: null },
            { data: null },
            {
                data: "CreatedDate",
                "render": function (data) {
                    var date = new Date(data);
                    return date.toLocaleDateString();
                }
            },
            { data: null },
            { data: null }
        ],
        "createdRow": function (row, data, index) {
            var stt = index + 1
            $('td:eq(0)', row).html(
                '<p>' + stt + '</p>'
            );
        },
        "rowCallback": function (row, data, index) {
            $('td:eq(1)', row).html(
                '<a style="text-decoration: none;" href = "/Admin/User/Details?id=' + data.Id + '">' + data.Email + '</a>'
            );
            $('td:eq(2)', row).html(
                data.LastName + ' ' + data.FirstName
            );
            $('td:eq(4)', row).html(
                data.EmailConfirmed == true ? 'Đã xác nhận' : 'Chưa xác nhân'
            );
            if (data.Id != IdUserLogin) {
                $('td:eq(5)', row).html(
                    '<a data-toggle="tooltip" title="Sửa" href="/admin/user/edit?id=' + data.Id + '" > <i class="fas fa-edit"></i></a > ' + ' ' +
                    '<a data-toggle="tooltip" title="Chi tiết" href="/admin/user/details?id=' + data.Id + '"><i class="fas fa-info-circle"></i></a>' + ' ' +
                    '<a data - toggle="tooltip" class="myBtnUser" title="Xóa" href="javascript:;" data-id="' + data.Id + '"><i class="fas fa-trash-alt text-danger"></i></a>'
                );
            } else {
                $('td:eq(5)', row).html(
                    '<a data-toggle="tooltip" title="Sửa" href="/admin/user/edit?id=' + data.Id + '" > <i class="fas fa-edit"></i></a > ' + ' ' +
                    '<a data-toggle="tooltip" title="Chi tiết" href="/admin/user/details?id=' + data.Id + '"><i class="fas fa-info-circle"></i></a>'
                );
            }
        },
    });
});