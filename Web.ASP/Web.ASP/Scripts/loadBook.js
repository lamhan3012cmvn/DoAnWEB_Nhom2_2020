const ajax = (cate_id, publishing_id, page) => {
    $.ajax({
        url: "/Category/loadData",
        data: { categoryID: cate_id, publishingHouseID: publishing_id, page: page },
        success: function (response) {
            $("#loadBook").html(response)
        },
        type: "GET",
    })
}
$(document).ready(function () {
    let page = 1;
    let cate_id = "";
    let publishing_id = "";
    $("#category .widgets_inner .list li").click(function (e) {

        const notIsActiveCategory = $("#category .widgets_inner .list li");
        cate_id = e.currentTarget.dataset.categoryid;
        for (let i = 0; i < notIsActiveCategory.length; i++) {
            notIsActiveCategory[i].classList.remove('active')
        }
        e.currentTarget.classList.add('active');
        ajax(cate_id, publishing_id, page);
    });
    $("#publishingHouse .widgets_inner .list li").click(function (e) {
        const notIsActivePublishingHouse = $("#publishingHouse .widgets_inner .list li");
        publishing_id = e.currentTarget.dataset.publishingid;
        console.log(publishing_id);
        for (let i = 0; i < notIsActivePublishingHouse.length; i++) {
            notIsActivePublishingHouse[i].classList.remove('active')
        }
        e.currentTarget.classList.add('active');
        ajax(cate_id, publishing_id, page);
    });
    //$(".cat_page .pagination .page-item").click(function (e) {
    //    const dataSetPage = e.currentTarget.dataset.page;
    //    const list = $(".cat_page .pagination .page-item ");
    //    const max = list[list.length - 2].dataset.page;
    //    if (dataSetPage == "pre") {
    //        page = page==1?1:(page=page--)
    //    } else if (dataSetPage == "next") {
    //        page = page >= max ? max : (page = page++);
    //    } else {
    //        page = dataSetPage;
    //    }
    //    ajax(cate_id, publishing_id, page)
    //});
});