
    $(document).ready(function () {
        $("#addCart").click(function () {

            const idBook = document.getElementById("idBook").dataset.id;
            const result = document.getElementById('sst');
            const obj = {
                book_id: idBook,
                count: result.value
            }
            $.ajax({
                url: "/User/createCart",
                data: obj,
                success: function (respone) {
                    if (respone.status == false)
                        notify("Thông Báo", respone.message, "fas fa-exclamation-circle", "warning")
                    else {
                        notify("Thông Báo", respone.message, "fas fa-exclamation-circle", "success")
                    }
                },
                type: "POST",
                dataType: "JSON"
            })
        });
        $(".star").click(function (e) {
            const star = e.currentTarget.dataset.star;
            document.getElementById("id_star").dataset.idStar = star;
            const allStar = $(".star");
            let str = "";
            for (let i = 0; i < 5; i++){
                if (allStar[i].dataset.star <= star)
                    str = "fa fa-star";
                else
                    str = "fa fa-star-o";
                allStar[i].children[0].className = str;
            }
        })
        $("#submit").click(function () {
            const idBook = document.getElementById("idBook").dataset.id;
            const name = $("#name_c").val();
            const email = $("#email_c").val();
            const review = $("#review_c").val();
            const star = document.getElementById("id_star").dataset.idStar;
            if (name === "") {
        notify("Thông Báo", "Nhập họ tên của bạn", "fas fa-exclamation-circle", "warning");
                return;
            }
            if (email === "") {
        notify("Thông Báo", "Nhập họ tên của bạn", "fas fa-exclamation-circle", "warning");
                return;
            }
            if (review === "") {
        notify("Thông Báo", "Nhập nội dung ", "fas fa-exclamation-circle", "warning");
                return;
            }
            if (star === undefined ) {
        notify("Thông Báo", "Chọn đánh giá", "fas fa-exclamation-circle", "warning");
                return;
            }
            const objData = {
        book_id :idBook,
                information_id :email,
                review : review,
                star : star
            }
            $.ajax({
        url: "/User/addReview",
                data: objData,
                success: function (respone) {
                    if (respone.status == false)
                        notify("Thông Báo", respone.message, "fas fa-exclamation-circle", "warning")
                    else {
        //Load lại trang cho lẹ
        notify("Thông Báo", respone.message, "fas fa-exclamation-circle", "success")
                        setTimeout(function () {
        window.location.href = '/' + respone.link.controllerName + '/' + respone.link.actionName + '';
                        }, 3300);
                    }
                },
                type: "POST",
                dataType: "JSON"
            })
        })
    });
