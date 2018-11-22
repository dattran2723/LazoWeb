jQuery.validator.setDefaults({
    debug: true,
    success: "valid"
});
$("#form-register-user").validate({
    rules: {
        email: {
            required: true,
            email: true
        },
        matkhau: {
            required: true,
            minlength: 3,
        }
    },
    //messages: {
    //    validpass: "Mật khẩu chứa ít nhất 3 kí tự"
    //}
});