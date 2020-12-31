;(function($){
    "use strict"
	let nav_offset_top = $('header').height() + 50; 
    /*-------------------------------------------------------------------------------
	  Navbar 
	-------------------------------------------------------------------------------*/

	//* Navbar Fixed  
    function navbarFixed(){
        if ( $('.header_area').length ){ 
            $(window).scroll(function() {
                let scroll = $(window).scrollTop();   
                if (scroll >= nav_offset_top ) {
                    $(".header_area").addClass("navbar_fixed");
                } else {
                    $(".header_area").removeClass("navbar_fixed");
                }
            });
        };
    };
    navbarFixed();
	
	
	/*----------------------------------------------------*/
    /*  Parallax Effect js
    /*----------------------------------------------------*/
	function parallaxEffect() {
    	$('.bg-parallax').parallax();
	}
	parallaxEffect();
	
	var dropToggle = $('.widgets_inner .list li').has('ul').children('a');
    dropToggle.on('click', function() {
        dropToggle.not(this).closest('li').find('ul').slideUp(200);
        $(this).closest('li').children('ul').slideToggle(200);
        return false;
    });
	
	/*----------------------------------------------------*/
    /*  Isotope Fillter js
    /*----------------------------------------------------*/
//	function gallery_isotope(){
//        if ( $('.gallery_f_inner').length ){
//            // Activate isotope in container
//			$(".gallery_f_inner").imagesLoaded( function() {
//                $(".gallery_f_inner").isotope({
//                    layoutMode: 'fitRows',
//                    animationOptions: {
//                        duration: 750,
//                        easing: 'linear'
//                    }
//                }); 
//            });
//			
//            // Add isotope click function
//            $(".gallery_filter li").on('click',function(){
//                $(".gallery_filter li").removeClass("active");
//                $(this).addClass("active");
//
//                var selector = $(this).attr("data-filter");
//                $(".gallery_f_inner").isotope({
//                    filter: selector,
//                    animationOptions: {
//                        duration: 450,
//                        easing: "linear",
//                        queue: false,
//                    }
//                });
//                return false;
//            });
//        }
//    }
//    gallery_isotope();
//	
	
	/*----------------------------------------------------*/
    /*  MailChimp Slider
    /*----------------------------------------------------*/
    function mailChimp(){
        $('#mc_embed_signup').find('form').ajaxChimp();
    }
    mailChimp();
	
	$('select').niceSelect();
	
	/*----------------------------------------------------*/
    /*  Simple LightBox js
    /*----------------------------------------------------*/
    $('.imageGallery1 .light').simpleLightbox();
	
	$('.counter').counterUp({
		delay: 10,
		time: 1000
	});
	
	
	/*----------------------------------------------------*/
    /*  Members Slider
    /*----------------------------------------------------*/
//    function members_slider(){
//        if ( $('.member_slider').length ){
//            $('.member_slider').owlCarousel({
//                loop:true,
//                margin: 30,
//                items: 3,
//                nav: false,
//                autoplay: false,
//                smartSpeed: 1500,
//                dots:true, 
//				navContainer: '.testimonials_area',
//                navText: ['<i class="lnr lnr-arrow-up"></i>','<i class="lnr lnr-arrow-down"></i>'],
//                responsiveClass: true,
//                responsive: {
//                    0: {
//                        items: 1,
//                    },
//                    768: {
//                        items: 2,
//                    },
//                    992: {
//                        items: 3,
//                    },
//                }
//            })
//        }
//    }
//    members_slider();
	
	
	/*----------------------------------------------------*/
    /*  Members Slider
    /*----------------------------------------------------*/
    function product_slider(){
        if ( $('.feature_p_slider').length ){
            $('.feature_p_slider').owlCarousel({
                loop:true,
                margin: 30,
                items: 4,
                nav: false,
                autoplay: false,
                smartSpeed: 1500,
                dots:true, 
//				navContainer: '.testimonials_area',
//                navText: ['<i class="lnr lnr-arrow-up"></i>','<i class="lnr lnr-arrow-down"></i>'],
                responsiveClass: true,
                responsive: {
                    0: {
                        items: 1, 
                    },
                    360: {
                        items: 2, 
                    },
                    576: {
                        items: 3,
                    },
                    768: {
                        items: 4,
                    },
                }
            })
        }
    }
    product_slider();
	
	/*----------------------------------------------------*/
    /*  Clients Slider
    /*----------------------------------------------------*/
    function clients_slider(){
        if ( $('.clients_slider').length ){
            $('.clients_slider').owlCarousel({
                loop:true,
                margin: 30,
                items: 5,
                nav: false,
                autoplay: false,
                smartSpeed: 1500,
                dots:false, 
                responsiveClass: true,
                responsive: {
                    0: {
                        items: 1,
                    },
                    400: {
                        items: 2,
                    },
                    575: {
                        items: 3,
                    },
                    768: {
                        items: 4,
                    },
                    992: {
                        items: 5,
                    }
                }
            })
        }
    }
    clients_slider();
	
	/*----------------------------------------------------*/
    /*  Jquery Ui slider js
    /*----------------------------------------------------*/
    $("#slider-range").slider({
        range: true,
        grid: true,
        min: 0,
        max: 500000,
        values: [0, 100],
        step: 10000,
        slide: function (event, ui) {
            start = ui.values[0]
            end = ui.values[1]
            const obj = { categoryID: cate_id, publishingHouseID: publishing_id, page: page, sort: sort, str: strSearch, start, end}
            $.ajax({
                url: "/Category/loadData",
                data: obj,
                success: function (response) {
                    $("#loadBook").html(response)
                },
                type: "GET",
            })
            $("#amount").val(ui.values[0] + "VND" +" - " + ui.values[1] + "VND"  );
        }

    });
    $("#amount").val($("#slider-range").slider("values", 0) + "VNĐ" +
      " - " + $("#slider-range").slider("values", 1) + "VND" );
	

})(jQuery)