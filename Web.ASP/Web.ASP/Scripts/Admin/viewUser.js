
    $(document).ready(function () {
        $(".singleBook").click(function (e) {
            const objData = {
                id: e.currentTarget.dataset.id
            }
            ajaxLoadData("/Admin/LoadSingleBook", "#load_form", objData)
        })
    })
