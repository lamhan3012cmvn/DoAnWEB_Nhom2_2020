const totalPrice_set = (price_id) => {
    const products = document.getElementById(price_id).children;
    if (products) {
        const arr = [];
        for (let i = 0; i < products.length - 2; i++) {
            arr.push(products[i].children[3].children[0].innerText.split(" ")[0])
        }
        const total = arr.reduce((a, b) => parseInt(a) + parseInt(b), 0);
        return total + " VND";
    }
    return "0 VND"
}
const middleware = (res, element) => {
    if (res.status === false)
        notify("Thông Báo", res.message, "fas fa-exclamation-circle", "warning")
    else {
        const arr = document.getElementById('setPrice')
        if (arr.children.length > 3) {
            arr.removeChild(element)
            console.log(arr)
            $("#totalPrice")[0].innerHTML = totalPrice_set("setPrice");
        } else {
            arr.innerHTML = ''
        }

    }
}
$(document).ready(function () {

    $("#totalPrice")[0].innerHTML = totalPrice_set("setPrice");
    $(".increase").click(function (e) {
        let current = (e.currentTarget);
        let parent = current.parentElement.children[0];
        var id = `${parent.dataset.id}`;
        var result = document.getElementsByClassName(`${id}`);
        var sst = result[1].value;
        const max = parseInt(result[1].dataset.max)
        if (!isNaN(sst) && sst < max) result[1].value++;
        result[2].innerHTML = price(parseInt(result[0].dataset.price), result[1].value);
        $("#totalPrice")[0].innerHTML = totalPrice_set("setPrice");
        const obj = {
            book_id: id,
            count: result[1].value
        }
        $.ajax({
            url: "/User/updateCart",
            data: obj,
            success: function (respone) {
                if (respone.status == false)
                    notify("Thông Báo", respone.message, "fas fa-exclamation-circle", "warning")
            },
            type: "POST",
            dataType: "JSON"
        })
        return false;
    })
    $(".reduced").click(function (e) {
        let current = (e.currentTarget);
        let parent = current.parentElement.children[0];
        var id = `${parent.dataset.id}`;
        var result = document.getElementsByClassName(`${id}`);
        var sst = result[1].value;
        if (!isNaN(sst) && sst > 1) result[1].value--;
        result[2].innerHTML = price(parseInt(result[0].dataset.price), result[1].value);
        $("#totalPrice")[0].innerHTML = totalPrice_set("setPrice");
        const obj = {
            book_id: id,
            count: result[1].value
        }
        $.ajax({
            url: "/User/updateCart",
            data: obj,
            success: function (respone) {
                if (respone.status == false)
                    notify("Thông Báo", respone.message, "fas fa-exclamation-circle", "warning")
            },
            type: "POST",
            dataType: "JSON"
        })
        return false;
    })
    $(".delete").click(function (e) {
        e.preventDefault()
        const currentElement = e.currentTarget
        const element = currentElement.parentElement.parentElement
        const id = currentElement.parentElement.parentElement.children[1].children[0].dataset.id
        const obj = {
            id
        }
        $.ajax({
            url: "/User/deleteCart",
            data: obj,
            success: function (respone) {
                middleware(respone, element)
            },
            type: "POST",
            dataType: "JSON"
        })
    })
})