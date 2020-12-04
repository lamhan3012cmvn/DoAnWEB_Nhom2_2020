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
const ajaxLoadData = (url, element, objData) => {
    $.ajax({
        url: url,
        data: objData,
        success: function (response) {
           $(element).html(response)
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

const price = (a, b) => {
    return (a * b) + " VND";
}
const totalPrice = () => {
    const products = $(".price");
    const arr = [];
    for (let i = 0; i < products.length; i++) {
        arr.push(products[i].innerText.split(" ")[0])
    }
    const total = arr.reduce((a, b) => parseInt(a) + parseInt(b), 0);
    return total + " VND";
}