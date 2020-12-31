
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
})


