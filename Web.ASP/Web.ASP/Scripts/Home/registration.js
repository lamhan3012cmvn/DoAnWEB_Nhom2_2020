$(document).ready(function () {
    $("#submit").click(function () {
        const userName = $("#email").val()
        const pass = $("#password").val()
        const confirmPass = $("#pass").val()
        const objData = {
            email: userName,
            password: pass,
            confirmpassword: confirmPass
        }
        $.ajax({
            url: "/Home/Register",
            type: "POST",
            data: objData,
            dataType: "JSON",
            success: function (respone) {
                if (respone.status) {
                    notify("Thông Báo", respone.message, "far fa-check-circle", "success")
                    const check = document.getElementById("f-option2").checked;
                    if (check && typeof (Storage) !== "undefined") {
                        localStorage.setItem("username", userName);
                        localStorage.setItem("password", pass);
                    }
                    setTimeout(function () {
                        window.location.href = '/' + respone.link.controllerName + '/' + respone.link.actionName + '';
                    }, 3300);
                }
                else {
                    notify("Thông Báo", respone.message, "fas fa-exclamation-circle", "warning")
                }
            }
        })
    })
})