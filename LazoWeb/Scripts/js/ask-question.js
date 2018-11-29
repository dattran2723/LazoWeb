$(document).ready(function () {
    $("#btn-first").click(function () {
        $("#question-second, #question-third").collapse("hide");
        $(this).toggleClass("open");
        $("#btn-second, #btn-third").removeClass("open");
    });
    $("#btn-second").click(function () {
        $("#question-first, #question-third").collapse("hide");
        $(this).toggleClass("open");
        $("#btn-first, #btn-third").removeClass("open");
    });
    $("#btn-third").click(function () {
        $("#question-second, #question-first").collapse("hide");
        $(this).toggleClass("open");
        $("#btn-second, #btn-first").removeClass("open");
    });

    var arrQuestion = [
        {
            question: "Nên lựa chọn phần mềm quản lý nhân viên phục vụ cho lĩnh vực kinh doanh nào?",
            answer:"Để chọn lựa được phần mềm quản lý phù hợp, khách hàng cần phải xác định phần mềm mình đang tìm cần sở hữu tính năng nào sao cho phù hợp với mô hình, quy mô kinh doanh… Ngoài ra, bạn cũng nên chú ý đến uy tín nhà cung cấp, dịch vụ tư vấn, đào tạo, công nghệ ứng dụng."
        },
        {
            question: "Sử dụng phần mềm Quản lý nhân viên Lazo có phức tạp không?",
            answer: "IOTLink sẽ hỗ trợ đào tạo cách sử dụng phần mềm đồng thời trong quá trình hoạt động sẽ hỗ trợ kỹ thuật. Ngoài ra các nhà cung cấp hiện nay đều tối ưu hóa giao diện thiết kế và những tính năng rất thân thiện với người sử dụng."
        },
        {
            question: "Lazo có luôn được cập nhật những tính năng mới?",
            answer: "Hệ thống Lazo sẽ luôn được cập nhật những tính năng mới, tiện ích và đặc biệt là nền tảng công nghệ bản đồ 3D theo thời gian thực."
        }
    ];
    for (i = 0; i < arrQuestion.length; i++) {
        $('#question' + (i + 1)).html((i + 1) + ". " + arrQuestion[i].question);
        $('#answer' + (i+1)).html(arrQuestion[i].answer);
    }
})