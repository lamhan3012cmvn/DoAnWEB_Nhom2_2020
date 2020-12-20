const ajaxLogin = () => {
    const userName = $("#name").val()
    const pass = $("#pass").val()
    const url = window.location.search.substring(11)
    const objData = {
        C_email_ID: userName,
        password: pass,
        returnUrl: url
    }
    $.ajax({
        url: "/Home/Validate",
        type: "POST",
        data: objData,
        dataType: "JSON",
        success: function (respone) {
            setTimeout(function () {

                if (respone.status == false)
                    notify("Thông Báo", respone.message, "fas fa-exclamation-circle", "warning")
                else {
                    notify("Thông Báo", respone.message, "fas fa-exclamation-circle", "success")
                    if (respone.isInfor == false) {
                        ajax('/' + respone.link.controllerName + '/' + respone.link.actionName + '', "#loadAddInfor");
                    }
                    else {
                        const check = document.getElementById("f-option2").checked;
                        if (check && typeof (Storage) !== "undefined") {
                            localStorage.setItem("username", userName);
                            localStorage.setItem("password", pass);
                        }
                        setTimeout(function () {
                            window.location.href = respone.link.returnUrlChange;
                            loading(false)
                        }, 2000);
                    }
                }
                loading(false)
            }, 1500)

        }
    })
}
$(document).ready(function () {
    if (typeof (Storage) !== "undefined") {
        const user = localStorage.getItem("username");
        const pass = localStorage.getItem("password");
        if (user && pass) {
            document.getElementById("name").value = user
            document.getElementById("pass").value = pass
        }
    }
    $("#btn_register").css("display", "inline-block");
    $('input').keypress(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') {
            loading(true)
            ajaxLogin()
        }
    });
    $("#submit").click(function (e) {
        loading(true)
        ajaxLogin()
    })

})