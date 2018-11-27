$(document).ready(function () {
    $("#manage-customers").addClass("active");
    $("#manage-customers #list-customers").addClass("active");

    var counter = 0;
    $('#example').DataTable({
        responsive: true,
        stateSave: true,
        ajax: "/api/customers",
        columns: [
            {
                data: null,
                "render": function () {
                    return ++counter;
                }
            },
            { data: "Name" },
            { data: "Company" },
            { data: "Phone" },
            {
                data: "Email"
            },
            {
                data: "RegisterDate",
                "render": function (data) {
                    var today = new Date(data);
                    return today.toLocaleDateString('en-GB');
                }
            },
            {
                data: "Status",
                "render": function (data) {
                    return data ? "Đã liên hệ" : "Chưa liên hệ";
                }
            },
            {
                data: null,
            }
        ],
        "rowCallback": function (row, data, index) {
            $('td:eq(1)', row).html(
                '<a href="/admin/customers/details?id=' + data.ID + '" >' + data.Name + '</a > '
            );
            $('td:eq(7)', row).html(
                '<a data-toggle="tooltip" title="Sửa" href="/admin/customers/edit?id=' + data.ID + '" > <i class="fas fa-edit"></i></a > ' + ' ' +
                '<a data-toggle="tooltip" title="Chi tiết" href="/admin/customers/details?id=' + data.ID + '"><i class="fas fa-info-circle"></i></a>' + ' ' +
                '<a data-toggle="tooltip" class="myBtn" title="Xóa" href="javascript:;" data-id="' + data.ID + '"><i class="fas fa-trash-alt text-danger"></i></a>'
            );
        },
    });
});