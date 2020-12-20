
   const ChangeStatus = (element, elementChange, status, action) => {
        $(element).click(function (e) {
            const current = e.currentTarget
            if (!current.disabled) {
                current.disabled = true
                current.classList.add("disabled")
                const order_id = current.parentNode.parentElement.children[0].children[1].innerHTML
                const information_id = current.parentNode.parentElement.children[0].children[0].innerHTML

                const objData = {
                    order_id,
                    information_id,
                    status,
                    actionChange: action
                }
                $.ajax({
                    url: "/Admin/ChangeStatus",
                    type: "GET",
                    data: objData,
                    success: function (res) {
                        $(elementChange).html(res)
                    }
                })
            }
        })
    }
    $(document).ready(function () {
        ChangeStatus(".confirm_product", "#loadWaitingProduct", "Chờ lấy hàng", "LoadWaitingProduct");

        ChangeStatus(".WaitingForDelivery_product", "#OnDelivery_product", "Đang giao", "LoadOnDelivery")
    })
