$('#carouselExample').on('slide.bs.carousel', function (e) {

    /*
 
    CC 2.0 License Iatek LLC 2018
    Attribution required
    
    */

    var $e = $(e.relatedTarget);
    var idx = $e.index();
    var itemsPerSlide = 3;
    var totalItems = $('#customers-feedback .carousel-item').length;

    if (idx >= totalItems - (itemsPerSlide - 1)) {
        var it = itemsPerSlide - (totalItems - idx);
        for (var i = 0; i < it; i++) {
            // append slides to end
            if (e.direction == "left") {
                $('#customers-feedback .carousel-item').eq(i).appendTo('#customers-feedback .carousel-inner');
            }
            else {
                $('#customers-feedback .carousel-item').eq(0).appendTo('#customers-feedback .carousel-inner');
            }
        }
    }
});
$(document).ready(function () {
    var arrComment = [
        {
            ID: 0 , 
            Name: "ĐẶNG VĂN LINH",
            Company: "", //"GOOGLE",
            Avatar: "~/Content/img/Customer1.png",
            Comment: "Tôi rất hài hài lòng về quy trình làm việc của công ty. Hệ thống Lazo rất hữu dụng và nhiều tính năng. Tôi thực sự đánh giá cao về ứng dụng này."
        },
        {
            ID: 1,
            Name: "TRẦN BẢO CHÂU",
            Company: "", //"GOOGLE",
            Avatar: "~/Content/img/Customer2.png",
            Comment: "Giải pháp quản lý nhân viên của hệ thống Lazo rất dễ sử dụng. Đặc biệt tôi ấn tượng với công nghệ bản đồ 3D theo thời gian thực của IOTlink."
        },
        {
            ID: 2,
            Name: "ĐINH VĂN THÀNH",
            Company: "", //"GOOGLE",
            Avatar: "~/Content/img/Customer3.png",
            Comment: "Tôi rất tin tưởng vào những giải pháp mà IOTLink cung cấp cho chúng tôi. Hi vọng chúng tôi sẽ được hợp tác nhiều hơn với công ty ở những dự án khác trong thời gian tới."
        },
        {
            ID: 3,
            Name: "TRẦN NGUYỄN ANH THƯ",
            Company: "", // "GOOGLE",
            Avatar: "~/Content/img/Customer4.png",
            Comment: "Hệ thống quản lý nhân viên của Lazo rất chuyên nghiệp, đặc biệt nổi bật bởi nền tảng công nghệ bản đồ 3D."
        }
    ];
    $('#feedback-content h4').html(arrComment[0].Name + arrComment[0].Company);
    $('#feedback-content p').html(arrComment[0].Comment);

    $('#customers-feedback a.carousel-control-prev').click(function () {
        var id = $('#carouselExample .carousel-inner .active').attr('data-id');
        var Name;
        var Company;
        var Comment;
        var number = arrComment.length;
        for (i = 0; i < number; i++) {
            if (id == arrComment[i].ID) {
                if (i == 0) {
                    number--;
                    Name = arrComment[number].Name;
                    Company = arrComment[number].Company;
                    Comment = arrComment[number].Comment;
                    break;
                }
                else {
                    console.log(i);
                    i--;
                    console.log(i);
                    Name = arrComment[i].Name;
                    Company = arrComment[i].Company;
                    Comment = arrComment[i].Comment;
                    break;
                }
            }
        }
        $('#feedback-content h4').html(Name + Company);
        $('#feedback-content p').html(Comment);
    });
    $('#customers-feedback a.carousel-control-next').click(function () {
        var id = $('#carouselExample .carousel-inner .active').attr('data-id');
        var Name;
        var Company;
        var Comment;
        var number = arrComment.length;
        for (i = 0; i < number; i++) {
            if (id == arrComment[i].ID) {
                if (i == 3) {
                    i = 0;
                    Name = arrComment[i].Name;
                    Company = arrComment[i].Company;
                    Comment = arrComment[i].Comment;
                    break;
                }
                else {
                    i++;
                    Name = arrComment[i].Name;
                    Company = arrComment[i].Company;
                    Comment = arrComment[i].Comment;
                    break;
                }
            }
        }
        $('#feedback-content h4').html(Name+ Company);
        $('#feedback-content p').html(Comment);
    });
})


