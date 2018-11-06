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
           ID: 0 , Name: "STEPHEN ROBERTS", Company: "GOOGLE", Avatar: "~/Content/img/Customer1.png", Comment: "Comment 1 Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever."
        },
        {
            ID: 1, Name: "ELIZABETH", Company: "GOOGLE", Avatar: "~/Content/img/Customer2.png", Comment: "Comment 2 Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever."
        },
        {
            ID: 2, Name: "YAREAK", Company: "GOOGLE", Avatar: "~/Content/img/Customer3.png", Comment: "Comment 3 Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever."
        },
        {
            ID: 3, Name: "WAYNNE", Company: "GOOGLE", Avatar: "~/Content/img/Customer4.png", Comment: "Comment 4 Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever."
        }
    ];

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
        $('#feedback-content h4').html(Name + " | " + Company);
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
        $('#feedback-content h4').html(Name + " | " + Company);
        $('#feedback-content p').html(Comment);
    });
})


