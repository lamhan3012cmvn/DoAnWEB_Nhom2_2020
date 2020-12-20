
$('select').niceSelect();
$(document).ready(function () {
    $("#formAddCategory").change(function (e) {
        const selectedValue = $(this).val();
        if (selectedValue.toString() === "") {
            $("#modalCreate").show()
        }
    })
    $("#formAddPublishingHouse").change(function (e) {
        const selectedValue = $(this).val();
        if (selectedValue.toString() === "") {
            $("#modalCreatePH").show()
        }
    })
    $("#formAuthor").change(function (e) {
        const selectedValue = $(this).val();
        if (selectedValue.toString() === "") {
            $("#modalCreateAuthor").show()
        }
    })
    $("#submit").click(function () {
        const nameB = $("#name").val()
        const contentB = $("#content").val()
        const priceB = $("#price").val()
        const countB = $("#count").val()
        const category = $("#formAddCategory").val()
        const publishinghouse = $("#formAddPublishingHouse").val()
        const author = $("#formAuthor").val()
        const size = $("#sizeBook").val()
        const numberOfPage = $("#numberOfPage").val()

        //const objData = {
        //    nameBook: nameB,
        //    contentBook: contentB,
        //    priceBook: priceB,
        //    countBook: countB,
        //    categoryBook_ID: category,
        //    publishingHouseBook_ID: publishinghouse,
        //    authorBook_ID: author,
        //    size: size,
        //    numberOfPage: numberOfPage
        //}
        //$.ajax({
        //    url: "/Admin/ValidateBook",
        //    type: "POST",
        //    data: objData,
        //    dataType: "JSON",
        //    success: function (respone) {
        //        if (respone.status == false)
        //            notify("Thông Báo", respone.message, "fas fa-exclamation-circle", "warning")
        //        else {
        //            notify("Thông Báo", respone.message, "fas fa-exclamation-circle", "success")
        //            setTimeout(function () {
        //                window.location.href = '/' + respone.link.controllerName + '/' + respone.link.actionName + '';
        //            }, 3300);
        //        }
        //    }
        //})
    })
})

