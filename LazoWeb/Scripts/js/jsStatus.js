var customer = {
    
    init: function () {
        customer.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            console.log(id);
            $.ajax({
                url: "ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status == true) {
                        btn.text('Đã liên hệ');
                    }
                    else {
                        btn.text('Chưa liên hệ');
                    }
                }
            }
            );

        });
    }
}
customer.init();