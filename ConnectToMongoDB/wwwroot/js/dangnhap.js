
$(document).ready(function () {
    $("#Login").click(function (e) {
        e.preventDefault();
        var username = $("#Username").val();
        var password = $("#Password").val();
        $.ajax({
            type: 'POST',
            url: '/TaiKhoan/DangNhap',
            data: { username: username, password: password },
            dataType: 'json',
            success: function (response) {
                if (response.success) {
                    window.location.href = '/Home/Index';
                }
                else {
                    alert("Đăng nhập thất bại");
                }
            },
            error: function () {
                alert("Có lỗi trong quá trình đăng nhập");
            }
        })
    })
})