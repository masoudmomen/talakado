(function($) {
    "use strict";
    /* -------------------------------------
               Prealoder
    -------------------------------------- */
    $(window).on('load', function(event) {
        $('.js-preloader').delay(500).fadeOut(500);
    });

    /*-------------------------------------
               Prealoder
    -------------------------------------- */
    $('.shopcart').on('click', function() {
        $('.cart-popup').addClass('open');
        $('.body_overlay').addClass('open');
    });
    $('.close-popup, .body_overlay').on('click', function() {
        $('.cart-popup').removeClass('open');
        $('.body_overlay').removeClass('open');
    });

    $('.user-account').on('click', function() {
        $(this).toggleClass('open');
        
    });

     /*-------------------------------------
              Product Slider With Zoom
    -------------------------------------- */
    var galleryThumbs = new Swiper('.gallery-thumbs', {
        spaceBetween: 5,
        freeMode: true,
        watchSlidesVisibility: true,
        watchSlidesProgress: true,
        breakpoints: {
            0: {
                slidesPerView: 3,
            },

            992: {
                slidesPerView: 4,
            },
        }
    });
    var galleryTop = new Swiper('.gallery-top', {
        spaceBetween: 10,
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        },
        thumbs: {
            swiper: galleryThumbs
        },
    });
    // gallery-top
    let productCarouselTopWidth = $('.gallery-top').outerWidth();
    $('.gallery-top').css('height', productCarouselTopWidth);

    // gallery-thumbs
    let productCarouselThumbsItemWith = $('.gallery-thumbs .swiper-slide').outerWidth();
    $('.gallery-thumbs').css('height', productCarouselThumbsItemWith);

    // activation zoom plugin
    var $easyzoom = $('.easyzoom').easyZoom();


    /* -------------------------------------
            Open Search box
      -------------------------------------- */
    $('.searchBtn').on("click", function() {
        $('.search-box-full').addClass('open');
        $('#search_field').focus();

    });
    $('.close-search_box').on("click", function() {
        $('.search-box-full').removeClass('open');
    });
 

    /*--------------------------
                 Count Down Timer
      ----------------------------*/
    $('[data-countdown]').each(function() {
        var $this = $(this),
            finalDate = $(this).data('countdown');
        $this.countdown(finalDate, function(event) {
            $this.html(event.strftime(' <div class="cdown day"><p class="time-count">%-D</p><span>روز</span></div><div class="cdown hour"><p class="time-count">%-H</p><span>ساعت</span></div><div class="cdown minutes"><p class="time-count">%M</p><span>دقیقه</span></div><div class="cdown second"><p class="time-count">%S</p><span>ثانیه</span></div>'));
        });
    });
   
    /* -------------------------------------
          Product Quantity
    -------------------------------------- */
    var minVal = 1,
        maxVal = 20;
    $(".increaseQty").on('click', function() {
        var $parentElm = $(this).parents(".qtySelector");
        $(this).addClass("clicked");
        setTimeout(function() {
            $(".clicked").removeClass("clicked");
        }, 100);
        var value = $parentElm.find(".qtyValue").val();
        if (value < maxVal) {
            value++;
        }
        $parentElm.find(".qtyValue").val(value);
    });
    // Decrease product quantity on cart page
    $(".decreaseQty").on('click', function() {
        var $parentElm = $(this).parents(".qtySelector");
        $(this).addClass("clicked");
        setTimeout(function() {
            $(".clicked").removeClass("clicked");
        }, 100);
        var value = $parentElm.find(".qtyValue").val();
        if (value > 1) {
            value--;
        }
        $parentElm.find(".qtyValue").val(value);
    });


    /* -------------------------------------
          Language Selector
    -------------------------------------- */

    $('.mobile-top-bar').on('click', function() {
        $('.header-top-right').addClass('open')
    });
    $('.close-header-top').on('click', function() {
        $('.header-top-right').removeClass('open')
    });
    /* -------------------------------------
          sticky Header
    -------------------------------------- */
    var wind = $(window);
    var sticky = $('.header-wrap');
    wind.on('scroll', function() {
        var scroll = wind.scrollTop();
        if (scroll < 100) {
            sticky.removeClass('sticky');
        } else {
            sticky.addClass('sticky');
        }
    });
    /*---------------------------------
        Responsive mmenu
    ---------------------------------*/
    $('.mobile-menu a').on('click', function() {
        $('.main-menu-wrap').addClass('open');
        $('.mobile-bar-wrap.style2 .mobile-menu').addClass('open');
    });

    $('.mobile_menu a').on('click', function() {
        $(this).parent().toggleClass('open');
        $('.main-menu-wrap').toggleClass('open');
    });

    $('.menu-close').on('click', function() {
        $('.main-menu-wrap').removeClass('open')
    });
    $('.mobile-top-bar').on('click', function() {
        $('.header-top').addClass('open')
    });
    $('.close-header-top button').on('click', function() {
        $('.header-top').removeClass('open')
    });
    var $offcanvasNav = $('.main-menu'),
        $offcanvasNavSubMenu = $offcanvasNav.find('.sub-menu');
    $offcanvasNavSubMenu.parent().prepend('<span class="menu-expand"><i class="las la-angle-down"></i></span>');

    $offcanvasNavSubMenu.slideUp();

    $offcanvasNav.on('click', 'li a, li .menu-expand', function(e) {
        var $this = $(this);
        if (($this.parent().attr('class').match(/\b(has-children|sub-menu)\b/)) && ($this.attr('href') === '#' || $this.hasClass('menu-expand'))) {
            e.preventDefault();
            if ($this.siblings('ul:visible').length) {
                $this.siblings('ul').slideUp('slow');
            } else {
                $this.closest('li').siblings('li').find('ul:visible').slideUp('slow');
                $this.siblings('ul').slideDown('slow');
            }
        }
        if ($this.is('a') || $this.is('span') || $this.attr('class').match(/\b(menu-expand)\b/)) {
            $this.parent().toggleClass('menu-open');
        } else if ($this.is('li') && $this.attr('class').match(/\b('has-children')\b/)) {
            $this.toggleClass('menu-open');
        }
    });
     /* ----------------------------------------
           Responsive Mega Menu
     ------------------------------------------*/

    // function startsMmenu() {
    //     $('#menu').mmenu();
    // }
    // $(document).ready(function() {
    //     if ($(window).width() < 992) {
    //         startsMmenu();
    //     }
    // });

    // $(window).resize(function() {
    //     if ($(window).width() < 992) {
    //         startsMmenu();
    //     }
    // });
    
    // $('#menu').mmenu({}, {
    //     offCanvas: {
    //         clone: true
    //     }
    // });
    // $('#ham-menu').mmenu();

    /* -------------------------------------
                Category Dropdown
    -------------------------------------- */
    $('.has-subcat').on('click', function() {
        $(this).toggleClass('open');
        $(this).find('.subcategory').slideToggle(500);
        $(this).siblings().find('.subcategory').slideUp(500);
        $(this).siblings().removeClass('open');
    })
    /* -------------------------------------
                 range slider
        -------------------------------------- */
    $("#slider-range_one").slider({
        range: true,
        min: 0,
        max: 400,
        values: [10, 300],
        slide: function(event, ui) {
            $("#amount_one").val("$" + ui.values[0] + " - " + "$" + ui.values[1]);
        }
    });
    $(" #amount_one").val("$" + $("#slider-range_one").slider("values", 0) +
        " - " + "$" + $("#slider-range_one").slider("values", 1));

    /*---------------------------------
           Hero Slider
    ---------------------------------*/
    var hero_slider_one = new Swiper('.hero-slider-one', {
        spaceBetween: 0,
        slidesPerView: 1,
        loop: true,
        autoHeight: true,
        autoplay: {
            delay: 9000,
            disableOnInteraction: true,
        },
        speed: 1500,
        pagination: {
            el: ".hero-one-pagination",
            clickable: true,
        },

    });
     var hero_slider_two = new Swiper('.hero-slider-two', {
        spaceBetween: 0,
        slidesPerView: 1,
        loop: true,
        autoHeight: true,
        // autoplay: {
        //     delay: 9000,
        //     disableOnInteraction: true,
        // },
        speed: 1500,
        pagination: {
            el: ".hero-two-pagination",
            clickable: true,
        },

    });
     var hero_slider_three = new Swiper('.hero-slider-three', {
        spaceBetween: 0,
        slidesPerView: 1,
        loop: true,
        autoHeight: true,
        // autoplay: {
        //     delay: 9000,
        //     disableOnInteraction: true,
        // },
        speed: 1500,
        pagination: {
            el: ".hero-pagination-three",
            clickable: true,
        },

    });
      /*---------------------------------
           Feature Product  Slider
    ---------------------------------*/
    var feature_slider_one = new Swiper('.feature-product-slider', {
        spaceBetween: 0,
        slidesPerView: 1,
        loop: true,
        autoHeight: true,
        autoplay: {
            delay: 9000,
            disableOnInteraction: true,
        },
        speed: 1500,
        effect: "fade",
        fadeEffect: { 
            crossFade: true 
        },
        pagination: {
            el: ".featured-pagination",
            clickable: true,
        },

    });
  
    /*---------------------------------
            Product  Slider
    ---------------------------------*/
    var product_slider_one = new Swiper('.product-slider-one', {
        spaceBetween: 0,
        slidesPerView: 1,
        loop: true,
        autoHeight: true,
        autoplay: {
            delay: 9000,
            disableOnInteraction: true,
        },
        speed: 1500,
         navigation: {
          nextEl: ".product-next-one",
          prevEl: ".product-prev-one",
        },
         breakpoints: {
            0: {
                slidesPerView: 1,
                spaceBetween: 30,

            },
            768: {
                slidesPerView: 2,
                spaceBetween: 20,

            },
            992: {
                slidesPerView: 3,
                spaceBetween: 25,

            },

            1200: {
                slidesPerView: 4,
                spaceBetween: 25,

            }
        }

    });
     var product_slider_two = new Swiper('.product-slider-two', {
        spaceBetween: 0,
        slidesPerView: 1,
        loop: true,
        autoHeight: true,
        autoplay: {
            delay: 9000,
            disableOnInteraction: true,
        },
        speed: 1500,
         navigation: {
          nextEl: ".product-next-two",
          prevEl: ".product-prev-two",
        },
         breakpoints: {
            0: {
                slidesPerView: 1,
                spaceBetween: 30,

            },
            768: {
                slidesPerView: 2,
                spaceBetween: 20,

            },
            992: {
                slidesPerView: 3,
                spaceBetween: 25,

            },

            1200: {
                slidesPerView: 4,
                spaceBetween: 25,

            }
        }

    });
    /*---------------------------------
           Flash Sale  Slider
    ---------------------------------*/
    var flash_slider_one = new Swiper('.flash-sale-slider', {
        spaceBetween: 25,
        autoplay: {
            delay: 3000,
            disableOnInteraction: true,
        },
        speed: 1500,
        loop: true,
        pagination: {
            el: '.flash-pagination',
            clickable: true,
        },
        breakpoints: {
            0: {
                slidesPerView: 1,
                spaceBetween: 30,

            },
            768: {
                slidesPerView: 2,
                spaceBetween: 20,

            },
            992: {
                slidesPerView: 3,
                spaceBetween: 25,

            },

            1200: {
                slidesPerView: 3,
                spaceBetween: 25,

            }
        }
    });
   
    /*---------------------------------
            Testimonial  Slider
    ---------------------------------*/

    var testimonial_one = new Swiper(".testimonial-slider-one", {
        slidesPerView: 1,
        loop: true,
        speed: 1500,
        autoHeight:true,
         spaceBetween: 25,
        autoplay: {
            delay: 4000,
            disableOnInteraction: true,
        },
        pagination: {
            el: ".testimonial-one-pagination",
            clickable: true,
        },
       
    });


    var testimonial_two = new Swiper('.testimonial-slider-two', {
        slidesPerView: 1,
        spaceBetween: 30,
        loop: true,
        autoHeight:true,
        speed: 1500,
         effect: "fade",
        fadeEffect: { 
            crossFade: true 
        },
        pagination: {
            el: ".testimonial-pagination-two",
            clickable: true,
        },
    });
    var testimonial_three = new Swiper('.testimonial-slider-three', {
        slidesPerView: 1,
        spaceBetween: 30,
        loop: true,
        autoHeight:true,
        effect: "fade",
        fadeEffect: { 
            crossFade: true 
        },
        speed: 1500,
        pagination: {
            el: ".testimonial-three-pagination",
            clickable: true,
        },
    });
    
    /*-------------------------------------
         Scroll to top
    ----------------------------------*/

    // Show or hide the  button
    $(window).on('scroll', function(event) {
        if ($(this).scrollTop() > 600) {
            $('.back-to-top').fadeIn(200)
        } else {
            $('.back-to-top').fadeOut(200)
        }
    });


    //Animate the scroll to top
    $('.back-to-top').on('click', function(event) {
        event.preventDefault();

        $('html, body').animate({
            scrollTop: 0,
        }, 1500);
    });


})(jQuery);


// function to set a given theme/color-scheme
function setTheme(themeName) {
    localStorage.setItem('hancy_rtl_theme', themeName);
    document.documentElement.className = themeName;
}

// function to toggle between light and dark theme
function toggleTheme() {
    if (localStorage.getItem('hancy_rtl_theme') === 'theme-dark') {
        setTheme('theme-light');
    } else {
        setTheme('theme-dark');
    }
}

// Immediately invoked function to set the theme on initial load
(function () {
    if (localStorage.getItem('hancy_rtl_theme') === 'theme-dark') {
        setTheme('theme-dark');
        document.getElementById('slider').checked = false;
    } else {
        setTheme('theme-light');
        document.getElementById('slider').checked = true;
    }
})();