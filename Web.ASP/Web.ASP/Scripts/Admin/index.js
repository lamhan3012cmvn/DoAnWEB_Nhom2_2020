$(document).ready(function () {
    const load = "#load_form"
    $("#createBook").click(function () {
        ajaxLoadData("/Admin/AddBook", load, {})
    })
    $("#viewBook").click(function () {

        ajax("/Admin/viewBook", load)
    })
    $("#chartJs").click(function () {
        ajax("/Admin/LoadChartJs", load)
    })
    $("#statisticalUser").click(function () {
        ajax("/Admin/LoadChartJsOfUser", load)
    })
    $("#statisticalBook").click(() => {
        ajax("/Admin/LoadChartJs", load)
    })
    $("#viewUser").click(function () {
        ajaxLoadData("/Admin/viewUser", load, {})
    })
    $("#exit").click(function () {
        $.ajax({
            url: "/Home/Logout",
            type: "GET",
            dataType: "JSON",
            success: function (response) {
                if (response.status == false)
                    notify("Thông Báo", response.message, "fas fa-exclamation-circle", "warning")
                else {
                    notify("Thông Báo", response.message, "fas fa-exclamation-circle", "success")
                    setTimeout(function () {
                        window.location.href = '/' + response.link.controllerName + '/' + response.link.actionName + '';
                    }, 3300);
                }
            },

        })
    })
});