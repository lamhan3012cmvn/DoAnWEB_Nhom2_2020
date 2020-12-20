$('select').niceSelect();
$(document).ready(function () {

    $("#submitInfo").click(function () {
        const objData = {
            nameInformation: $("#nameInformation").val(),
            maleInformation: $("#maleInformation").val(),
            phoneInformation: $("#phoneInformation").val(),
            addressInformation: $("#addressInformation").val(),
            birthday: $("#birthday").val()
        }
        $.ajax({
            url: "/Home/ValidateInfor",
            type: "POST",
            data: objData,
            success: function (respone) {
                if (respone.status == false)
                    notify("Thông Báo", respone.message, "fas fa-exclamation-circle", "warning")
                else {
                    notify("Thông Báo", respone.message, "fas fa-exclamation-circle", "success")
                    setTimeout(function () {
                        window.location.href = '/' + respone.link.controllerName + '/' + respone.link.actionName + '';
                    }, 3300);
                }
            }
        })
    })
})