$(document).ready(function () {
    $("#manage-customers").addClass("active");
    $("#manage-customers #list-customers").addClass("active");
});
$(document).ready(function () {
    $('#example').DataTable({
        responsive: true,
        stateSave: true,
        ajax: "/api/customers",
        columns: [
            { data: null },
            { data: "Name" },
            { data: "Company" },
            { data: "Email" },
            {
                data: "Phone"
            },
            {
                data: "RegisterDate",
                "render": function (data) {
                    var today = new Date(data);
                    return today.toLocaleDateString('en-GB');
                }
            },
            { data: "Status" },
            {
                data: null,
            }
        ],
        "createdRow": function (row, data, index) {
            var stt = index + 1
            $('td:eq(0)', row).html(
                stt
            );
        },
        "rowCallback": function (row, data, index) {
            $('td:eq(1)', row).html(
                '<a href="/admin/customers/details?id=' + data.ID + '" >' + data.Name + '</a > '
            );
            $('td:eq(6)', row).html(
                data.Status ? "Đã liên hệ" : "Chưa liên hệ"
            );
            $('td:eq(7)', row).html(
                '<a data-toggle="tooltip" title="Sửa" href="/admin/customers/edit?id=' + data.ID + '" > <i class="fas fa-edit"></i></a > ' + ' ' +
                '<a data-toggle="tooltip" title="Chi tiết" href="/admin/customers/details?id=' + data.ID + '"><i class="fas fa-info-circle"></i></a>' + ' ' +
                '<a data-toggle="tooltip" class="myBtn" title="Xóa" href="javascript:;" data-id="' + data.ID + '"><i class="fas fa-trash-alt text-danger"></i></a>'
            );
        },
    });
});