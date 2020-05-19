
$(document).ready(function () {

});

$("#btnEnter").click(function () {
    $('#AjaxLoader').show();
    $.ajax({
        type: "POST",
        url: "/Home/Login",
        data: JSON.stringify({ login: $('#login').val(), password: $('#password').val() }),
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (location) {
            window.location.href = location;
            $('#AjaxLoader').hide();
        },
        error: function (response) {
            alert("Логин или пароль введен неверно! Повторите ввод!")
            $('#AjaxLoader').hide();
        }
    });
});

$("#btnRegistration").click(function () {
    $('#AjaxLoader').show();
    $.ajax({
        url: "/Home/Registration",
        type: "POST",
        data: $('#registerForm').serialize(),
        dataType: 'json',
        success: function (location) {
            window.location.href = location;
            $('#AjaxLoader').hide();
        },
        error: function (response) {
            alert("Пользователь с таким ником уже создан!");
            $('#AjaxLoader').hide();
        }
    });

});