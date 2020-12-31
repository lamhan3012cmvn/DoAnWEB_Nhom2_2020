
$(document).ready(function () {
    $("#category .widgets_inner .list li").click(function (e) {
        const notIsActiveCategory = $("#category .widgets_inner .list li");
        cate_id = e.currentTarget.dataset.categoryid;
        for (let i = 0; i < notIsActiveCategory.length; i++) {
            notIsActiveCategory[i].classList.remove('active')
        }
        e.currentTarget.classList.add('active');
        const obj = { categoryID: cate_id, publishingHouseID: publishing_id, page: page, sort: sort, str: strSearch, start, end }
        ajaxLoadData("/Category/loadData", "#loadBook",obj)
    });
    $("#publishingHouse .widgets_inner .list li").click(function (e) {
        const notIsActivePublishingHouse = $("#publishingHouse .widgets_inner .list li");
        publishing_id = e.currentTarget.dataset.publishingid;
        for (let i = 0; i < notIsActivePublishingHouse.length; i++) {
            notIsActivePublishingHouse[i].classList.remove('active')
        }
        e.currentTarget.classList.add('active');
        const obj = { categoryID: cate_id, publishingHouseID: publishing_id, page: page, sort: sort, str: strSearch, start, end }
        ajaxLoadData("/Category/loadData", "#loadBook", obj)
    });
    $(".cat_page .pagination .page-item").click(function (e) {
        const dataSetPage = e.currentTarget.dataset.page;
        const list = $(".cat_page .pagination .page-item ");
        const max = list[list.length - 2].dataset.page;
        if (dataSetPage == "pre") {
            if (page <= 1)
                page = 1;
            else page = parseInt(page) - 1;
        } else if (dataSetPage == "next") {
            if (page >= max)
                page = max;
            else page = parseInt(page) + 1;
        } else {
            page = dataSetPage;
        }
        const obj = { categoryID: cate_id, publishingHouseID: publishing_id, page: page, sort: sort, str: strSearch, start, end }
        $.ajax({
            url: "/Category/loadData",
            data: obj,
            success: function (response) {
                $("#loadBook").html(response)
            },
            type: "GET",
        })
    });
    $("#sort").change(function (e) {
        sort = $(this).val();
        const obj = { categoryID: cate_id, publishingHouseID: publishing_id, page: page, sort: sort, str: strSearch, start, end }
        ajaxLoadData("/Category/loadData", "#loadBook", obj)
    })
    $("#searchBook").keyup(function (e) {
        strSearch = e.currentTarget.value;
        const obj = { categoryID: cate_id, publishingHouseID: publishing_id, page: page, sort: sort, str: strSearch, start, end }
        ajaxLoadData("/Category/loadData", "#loadBook", obj)
    })
    
});