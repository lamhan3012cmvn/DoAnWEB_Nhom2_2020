
const notify = (title, mess, icon, type) => {
    $.notify({
        // options
        title: `<strong>${title}</strong>`,
        message: `<br>${mess}`,
        icon: icon,
        target: "_blank",
    }, {
        // settings
        element: "body",
        type: type,
        showProgressbar: false,
        placement: {
            from: "top",
            align: "right",
        },
        offset: 20,
        spacing: 10,
        z_index: 1031,
        delay: 3300,
        timer: 100,
        url_target: "_blank",
        mouse_over: null,
        animate: {
            enter: "animated fadeInRightBig",
            exit: "animated fadeOutRightBig",
        },
        onShow: null,
        onShown: null,
        onClose: null,
        onClosed: null,
        icon_type: "class",
    });
}