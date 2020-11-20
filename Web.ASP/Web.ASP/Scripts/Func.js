const ajax = (url, element) => {
    $.ajax({
        url: url,
        success: function (response) {
            $(element).slideUp("2000", function () {
                $(element).html(response).slideDown("2000")
            })
        },
        type: "GET",
    })
}
const selectChange = (element, url, elementchange) => {
    $(element).change(function (e) {
        const selectedValue = $(this).val();
        if (selectedValue.toString() === "") {
            ajax(url, elementchange)
        }
    })
}
