{#/*============================================================================
    #Specific store JS functions: product variants, cart, shipping, etc
==============================================================================*/#}

{#/*============================================================================
  
  Table of Contents

  	#Lazy load
  	#Notificactions
    #Modals
    #Tabs
  	#Header and nav
        // Nav
        // Search suggestions
	#Sliders
	  	// Home slider
	  	// Banner services slider
	#Social
		// Youtube or Vimeo video
        // Facebook login
	#Product grid
		// Filters
		// Sort by
		// Infinite scroll
  	#Product detail functions
	  	// Installments
	  	// Change Variant
	  	// Product labels on variant change
	  	// Color and size variants change
	  	// Custom mobile variants change
	  	// Submit to contact
	  	// Product slider
	  	// Pinterest sharing
        // Product quantity
  	#Cart
  		// Toggle cart 
  		// Add to cart
  		// Cart quantitiy changes
  		// Empty cart alert
        // Go to checkout
	#Shipping calculator
		// Select and save shipping function
		// Calculate shipping function
		// Calculate shipping by submit
		// Shipping and branch click
		// Select shipping first option on results
		// Toggle branches link
		// Toggle more shipping options
		// Calculate shipping on page load
		// Shipping provinces
		// Change store country
    #Forms
    #Footer

==============================================================================*/#}

{#/*============================================================================
  #Lazy load
==============================================================================*/ #}

document.addEventListener('lazybeforeunveil', function(e){
    if ((e.target.parentElement) && (e.target.nextElementSibling)) {
        var parent = e.target.parentElement;
        var sibling = e.target.nextElementSibling;
        if (sibling.classList.contains('js-lazy-loading-preloader')) {
            sibling.style.display = 'none';
            parent.style.display = 'block';
        }
    }
});


window.lazySizesConfig = window.lazySizesConfig || {};
lazySizesConfig.hFac = 0.4;


$(document).ready(function(){

	{#/*============================================================================
	  #Notifications
	==============================================================================*/ #}

    {# Notifications variables #}

    var $notification_status_page = $(".js-notification-status-page");
    var $notification_order_cancellation = $(".js-notification-order-cancellation");
    var $fixed_bottom_button = $(".js-btn-fixed-bottom");

    {# /* // Close notification */ #}

    $(".js-notification-close").on( "click", function(e) {
        e.preventDefault();
        $(this).closest(".js-notification").hide();
    });

    {# /* // Follow order status notification */ #}

    if ($notification_status_page.size() > 0){
        if (LS.shouldShowOrderStatusNotification($notification_status_page.data('url'))){
            $notification_status_page.show();
        };
        $(".js-notification-status-page-close").on( "click", function(e) {
            e.preventDefault();
            LS.dontShowOrderStatusNotificationAgain($notification_status_page.data('url'));
        });
    }

    {# /* // Follow order cancellation notification */ #}

    if ($notification_order_cancellation.size() > 0){
        if (LS.shouldShowOrderCancellationNotification($notification_order_cancellation.data('url'))){

            {% if not params.preview %}
                {# Show order cancellation notification only if cookie banner is not visible #}

                if (window.cookieNotificationService.isAcknowledged()) {
            {% endif %}
                    $notification_order_cancellation.show();
            {% if not params.preview %}
                }
            {% endif %}
            $fixed_bottom_button.css({"margin-bottom": "40px"});
        };
        $(".js-notification-order-cancellation-close").on( "click", function(e) {
            e.preventDefault();
            LS.dontShowOrderCancellationNotification($notification_order_cancellation.data('url'));
        });
    }

    {% if not settings.head_fix %}

        {# /* // Add to cart notification on non fixed header */ #}

        var headHeight = $(".js-head-main").outerHeight();
        var $addedToCartNotification = $(".js-alert-added-to-cart");

        $addedToCartNotification.css("top" , headHeight);

        $(function () {
            $(window).scroll(function () {
                if ($(this).scrollTop() == 0) {
                    $addedToCartNotification.css("top" , headHeight).addClass("notification-with-arrow");
                } else {
                    $addedToCartNotification.css("top" , 30);
                }
            });
        })

    {% endif %}

    {% if not params.preview %}
        
        {# /* // Cookie banner notification */ #}

        restoreNotifications = function(){

            // Whatsapp button position
            $fixed_bottom_button.css({"margin-bottom": "10px"});

            {# Restore notifications when Cookie Banner is closed #}

            var show_order_cancellation = ($notification_order_cancellation.size() > 0) && (LS.shouldShowOrderCancellationNotification($notification_order_cancellation.data('url')));

            {% if store.country == 'AR' %}
                {# Order cancellation #}
                if (show_order_cancellation){
                    $notification_order_cancellation.show();
                    $fixed_bottom_button.css({"margin-bottom": "40px"});
                }
            {% endif %}
        };

        if (!window.cookieNotificationService.isAcknowledged()) {
            $(".js-notification-cookie-banner").show();

            {# Whatsapp button position #}
            if ($(window).width() < 768) {
                $fixed_bottom_button.css({"margin-bottom": "120px"});
            }else{
                $fixed_bottom_button.css({"margin-bottom": "70px"});
            }
        }

        $(".js-acknowledge-cookies").on( "click", function(e) {
            window.cookieNotificationService.acknowledge();
            restoreNotifications();
        });

    {% endif %}

    {#/*============================================================================
      #Modals
    ==============================================================================*/ #}

    {% if settings.quick_shop %}

        restoreQuickshopForm = function(){

            {# Restore form to item when quickshop closes #}

            {# Clean quickshop modal #}

            $("#quickshop-modal .js-item-product").removeClass("js-swiper-slide-visible js-item-slide");
            $("#quickshop-modal .js-quickshop-container").attr( { 'data-variants' : '' , 'data-quickshop-id': '' } );
            $("#quickshop-modal .js-item-product").attr('data-product-id', '');

            {# Wait for modal to become invisible before removing form #}
            
            setTimeout(function(){
                var $quickshop_form = $("#quickshop-form").find('.js-product-form');
                var $item_form_container = $(".js-quickshop-opened").find(".js-item-variants");
                
                $quickshop_form.detach().appendTo($item_form_container);
                $(".js-quickshop-opened").removeClass("js-quickshop-opened");
            },350);

        };

    {% endif %}
    
    {# Full screen mobile modals back events #}

    if ($(window).width() < 768) {

        {# Clean url hash function #}

        cleanURLHash = function(){
            const uri = window.location.toString();
            const clean_uri = uri.substring(0, uri.indexOf("#"));
            window.history.replaceState({}, document.title, clean_uri);
        };

        {# Go back 1 step on browser history #}

        goBackBrowser = function(){
            cleanURLHash();
            history.back();
        };

        {# Clean url hash on page load: All modals should be closed on load #}

        if(window.location.href.indexOf("modal-fullscreen") > -1) {
            cleanURLHash();
        }

        {# Open full screen modal and url hash #}

        $(document).on("click", ".js-fullscreen-modal-open", function(e) {
            e.preventDefault();
            var modal_url_hash = $(this).data("modal-url");            
            window.location.hash = modal_url_hash;
        });

        {# Close full screen modal: Remove url hash #}

        $(document).on("click", ".js-fullscreen-modal-close", function(e) {
            e.preventDefault();
            goBackBrowser();
        });

        {# Hide panels or modals on browser backbutton #}

        window.onhashchange = function() {
            if(window.location.href.indexOf("modal-fullscreen") <= -1) {

                {# Close opened modal #}

                if($(".js-fullscreen-modal").hasClass("modal-show")){

                    {# Remove body lock only if a single modal is visible on screen #}

                    if($(".js-modal.modal-show").length == 1){
                        $("body").removeClass("overflow-none");
                    }

                    var $opened_modal = $(".js-fullscreen-modal.modal-show");
                    var $opened_modal_overlay = $opened_modal.prev();

                    $opened_modal.removeClass("modal-show").delay(500).hide(0);
                    $opened_modal_overlay.fadeOut(500);

                    {% if settings.quick_shop %}
                        restoreQuickshopForm();
                    {% endif %}
                }
            }
        }

    }
    
    $(document).on("click", ".js-modal-open", function(e) {
        e.preventDefault(); 
        var modal_id = $(this).data('toggle');
        var $overlay_id = $('.js-modal-overlay[data-modal-id="' + modal_id + '"]');
        if ($(modal_id).hasClass("modal-show")) {
            $(modal_id).removeClass("modal-show").delay(500).hide(0);
        } else {

            {# Lock body scroll if there is no modal visible on screen #}
            
            if(!$(".js-modal.modal-show").length){
                $("body").addClass("overflow-none");
            }
            $overlay_id.fadeIn(400);
            $(modal_id).detach().appendTo("body");
            $overlay_id.detach().insertBefore(modal_id);
            $(modal_id).show(0).addClass("modal-show");
        }             
    });

    closeModal = function(element){

        {# Remove body lock only if a single modal is visible on screen #}

        if($(".js-modal.modal-show").length == 1){
            $("body").removeClass("overflow-none");
        }
        var $modal = $('body .js-modal.modal-show:last-child');
        var $overlay = $modal.prev(".js-modal-overlay");
        $modal.removeClass("modal-show").delay(500).hide(0); 
        $overlay.fadeOut(500);

        {# Close full screen modal: Remove url hash #}

        if (($(window).width() < 768) && ($(element).hasClass(".js-fullscreen-modal-close"))) {
            goBackBrowser();
        }

        {% if settings.quick_shop %}
            restoreQuickshopForm();
        {% endif %}
        
    };

    $(document).on("click", ".js-modal-close", function(e) {
        e.preventDefault();  
        closeModal($(this));    
    });

    {# Close modal on ESC keyboard #}

    $(document).keyup(function(e) {
        if (e.keyCode == 27) {
            closeModal($(".js-modal-close"));    
        }
    });

    $(document).on("click", ".js-modal-overlay", function(e) {
        e.preventDefault();
        {# Remove body lock only if a single modal is visible on screen #}

        if($(".js-modal.modal-show").length == 1){
            $("body").removeClass("overflow-none");
        }
        var modal_id = $(this).data('modal-id');
        $(modal_id).removeClass("modal-show").delay(500).hide(0);   
        $(this).fadeOut(500);   
        {% if settings.quick_shop %}
            restoreQuickshopForm();
        {% endif %}

        if ($(this).hasClass("js-fullscreen-overlay") && $(window).width() < 768) {
            cleanURLHash();
        }
    });

    {#/*============================================================================
      #Tabs
    ==============================================================================*/ #}

    var $tab_open = $('.js-tab');

    $tab_open.click(function (e) {
        e.preventDefault(); 
        var $tab_container = $(this).closest(".js-tab-container");
        $tab_container.find(".js-tab, .js-tab-panel").removeClass("active");
        $(this).addClass("active");
        var tab_to_show = $(this).find(".js-tab-link").attr("href");
        $tab_container.find(tab_to_show).addClass("active");    
    });

	{#/*============================================================================
      #Header and nav
    ==============================================================================*/ #}

    {# /* // Header */ #}

    {% if template == 'home' and settings.head_transparent %}
        {% if settings.slider and settings.slider is not empty %}        

            var $swiper_height = $(window).height() - 100;
            
            $(document).scroll(function() {
                if ($(document).scrollTop() > $swiper_height ) {
                    $(".js-head-main").removeClass("head-transparent");
                } else {
                    $(".js-head-main").addClass("head-transparent");
                }
            });

        {% endif %}
    {% endif %}

    {# /* // Nav offset */ #}

    function applyOffset(selector){

        // Get nav height on load
        if ($(window).width() > 768) {
            var head_height = $(".js-head-main").height();
            $(selector).css("padding-top", head_height); 
        }else{

            {# On mobile there is no top padding due to position sticky CSS #}
            var head_height = 0;
        }

        // Apply offset nav height on load

        $(window).resize(function() {

            // Get nav height on resize
            var head_height = $(".js-head-main").height();

            // Apply offset on resize
            if ($(window).width() > 768) {
                $(selector).css("padding-top", head_height);
            }else{

                {# On mobile there is no top padding due to position sticky CSS #}
                $(selector).removeAttr("style");
            }
        });
    }

    {% if settings.head_fix and ((settings.head_transparent and template != 'home') or (not settings.head_transparent)) %}
        applyOffset(".js-head-offset");
    {% endif %}

    {# /* // Nav */ #}

        var $top_nav = $(".js-mobile-nav");
        var $page_main_content = $(".js-main-content");
        var $search_backdrop = $(".js-search-backdrop");

        $top_nav.addClass("move-down").removeClass("move-up");


        {# Nav subitems #}

        $(".js-toggle-page-accordion").click(function (e) {
            e.preventDefault();
            $(this).toggleClass("selected").closest(".js-nav-list-toggle-accordion").next(".js-pages-accordion").slideToggle(300);
        });

        {# Focus search #}

        $(".js-toggle-search").click(function (e) {
            e.preventDefault;
            $(".js-search-input").focus();
        });


    {# /* // Search suggestions */ #}

        LS.search($(".js-search-input"), function (html, count) {
            $search_suggests = $(this).closest(".js-search-container").next(".js-search-suggest");
            if (count > 0) {
                $search_suggests.html(html).show();
            } else {
                $search_suggests.hide();
            }
            if ($(this).val().length == 0) {
                $search_suggests.hide();
            }
        }, {
            snipplet: 'header/header-search-results.tpl'
        });

        if ($(window).width() > 768) {

            {# Hide search suggestions if user click outside results #}

            $("body").click(function () {
                $(".js-search-suggest").hide();
            });

            {# Maintain search suggestions visibility if user click on links inside #}

            $(document).on("click", ".js-search-suggest a", function () {
                $(".js-search-suggest").show();
            });
        }

        $(".js-search-suggest").on("click", ".js-search-suggest-all-link", function (e) {
            e.preventDefault();
            $this_closest_form = $(this).closest(".js-search-suggest").prev(".js-search-form");
            $this_closest_form.submit();
        });


	{#/*============================================================================
	  #Sliders
	==============================================================================*/ #}

	{% if template == 'home' %}

		{# /* // Home slider */ #}

        var width = window.innerWidth;
        if (width > 767) {  
            var slider_autoplay = {delay: 6000,};
        } else {
            var slider_autoplay = false;
        }

        window.homeSlider = {
            getAutoRotation: function() {
                return slider_autoplay;
            },
            updateSlides: function(slides) {
                homeSwiper.removeAllSlides();
                slides.forEach(function(aSlide){
                    homeSwiper.appendSlide(
                        '<div class="swiper-slide slide-container">' +
                            (aSlide.link ? '<a href="' + aSlide.link + '">' : '' ) +
                            '<img src="' + aSlide.src + '" class="slider-image"/>' + +
                            (aSlide.link ? '</a>' : '' ) +
                        '</div>'
                    );
                });
                if(!slides.length){
                    $(".js-home-main-slider-container").addClass("hidden");
                    $(".js-home-empty-slider-container").removeClass("hidden");
                    $(".js-home-mobile-slider-visibility").removeClass("d-md-none");
                    {% if has_mobile_slider %}
                        $(".js-home-main-slider-visibility").removeClass("d-none d-md-block");
                        homeMobileSwiper.update();
                    {% endif %}
                }else{
                    $(".js-home-main-slider-container").removeClass("hidden");
                    $(".js-home-empty-slider-container").addClass("hidden");
                    $(".js-home-mobile-slider-visibility").addClass("d-md-none");
                    {% if has_mobile_slider %}
                        $(".js-home-main-slider-visibility").addClass("d-none d-md-block");
                    {% endif %}
                }
            },
            changeAutoRotation: function(){

            },
        };

        var preloadImagesValue = false;
        var lazyValue = true;
        var loopValue = true;
        var watchOverflowValue = true;
        var paginationClickableValue = true;

        var homeSwiper = new Swiper ('.js-home-slider', {
            lazy: lazyValue,
            preloadImages: preloadImagesValue,
            {% if settings.slider | length > 1 %}
                loop: loopValue,
            {% endif %}
            autoplay: slider_autoplay,
            watchOverflow: watchOverflowValue,
            pagination: {
                el: '.js-swiper-home-pagination',
                clickable: paginationClickableValue,
            },
            navigation: {
                nextEl: '.js-swiper-home-next',
                prevEl: '.js-swiper-home-prev',
            },
        });

        var homeMobileSwiper = new Swiper ('.js-home-slider-mobile', {
            lazy: lazyValue,
            preloadImages: preloadImagesValue,
            {% if settings.slider_mobile | length > 1 %}
                loop: loopValue,
            {% endif %}
            autoplay: slider_autoplay,
            watchOverflow: watchOverflowValue,
            pagination: {
                el: '.js-swiper-home-pagination-mobile',
                clickable: paginationClickableValue,
            },
            navigation: {
                nextEl: '.js-swiper-home-next-mobile',
                prevEl: '.js-swiper-home-prev-mobile',
            },
        });
     
        {% if sections.primary.products %}

            {% if settings.product_color_variants or settings.quick_shop %}

                {# Duplicate cloned slide elements for quickshop or colors forms #}

                updateClonedItemsIDs = function(element){
                    $(element).each(function() {
                        var $this = $(this);
                        var slide_index = $this.attr("data-swiper-slide-index");
                        var clone_quick_id = $this.find(".js-quickshop-container").attr("data-quickshop-id");
                        var clone_product_id = $this.attr("data-product-id");
                        $this.attr("data-product-id" , clone_product_id + "-clone-" + slide_index);
                        $this.find(".js-quickshop-container").attr("data-quickshop-id" , clone_quick_id + "-clone-" + slide_index);
                    });
                };

            {% endif %}

            {% set columns = settings.grid_columns %}
            var featuredSwiper = new Swiper ('.js-swiper-featured', {
                lazy: true,
                loop: true,
                spaceBetween: 30,
                watchSlidesVisibility: true,
                slideVisibleClass: 'js-swiper-slide-visible',
                slidesPerView: {% if columns == 2 %}2{% else %}1{% endif %},
                pagination: {
                    el: '.js-swiper-featured-pagination',
                    clickable: true,
                },
                navigation: {
                    nextEl: '.js-swiper-featured-next',
                    prevEl: '.js-swiper-featured-prev',
                },
                breakpoints: {
                    640: {
                        slidesPerView: {% if columns == 2 %}4{% else %}3{% endif %},
                    }
                },
                {% if settings.product_color_variants or settings.quick_shop %}
                    on: {
                        init: function () {
                            updateClonedItemsIDs(".js-swiper-featured .js-item-slide.swiper-slide-duplicate");
                        },
                    }
                {% endif %}
            });

        {% endif %}

	{% endif %}

    {% if template == 'product' %}

        {# /* // Product Related */ #}

            {% set related_products_ids = product.metafields.related_products.related_products_ids %}
            {% if related_products_ids %}
                {% set related_products = related_products_ids | get_products %}
                {% set show = (related_products | length > 0) %}
            {% endif %}
            {% if not show %}
                {% set related_products = category.products | shuffle | take(8) %}
                {% set show = (related_products | length > 1) %}
            {% endif %}

            {% set columns = settings.grid_columns %}
            var relatedSwiper = new Swiper ('.js-swiper-related', {
                lazy: true,
                {% if related_products | length > 4 %}
                loop: true,
                {% endif %}
                spaceBetween: 30,
                slidesPerView: {% if columns == 2 %}2{% else %}1{% endif %},
                pagination: {
                    el: '.js-swiper-related-pagination',
                    clickable: true,
                },
                navigation: {
                    nextEl: '.js-swiper-related-next',
                    prevEl: '.js-swiper-related-prev',
                },
                breakpoints: {
                    767: {
                        slidesPerView: {% if columns == 2 %}4{% else %}3{% endif %},
                    }
                }
            });

    {% endif %}



	{% set has_banner_services = settings.banner_services %}

	{% if has_banner_services %}

		{# /* // Banner services slider */ #}

        var width = window.innerWidth;
        if (width < 767) {   
            var swiperInformative = new Swiper ('.js-informative-banners', {
                pagination: {
                    el: '.js-informative-banners-pagination',
                    clickable: true,
                },
            });
        }

    {% endif %}

	{#/*============================================================================
	  #Social
	==============================================================================*/ #}

    {% if template == 'home' %}
        {% set video_url = settings.video_embed %}
    {% elseif template == 'product' and product.video_url %}
        {% set video_url = product.video_url %}
    {% endif %}

    {% if video_url %}

        {# /* // Youtube or Vimeo video for home or each product */ #}

        LS.loadVideo('{{ video_url }}');

    {% endif %}

	{#/*============================================================================
	  #Product grid
	==============================================================================*/ #}

    var $category_controls = $(".js-category-controls");
    var mobile_nav_height = $(".js-head-main").outerHeight();

	{% if template == 'category' %}

        {# /* // Fixed category controls */ #}

        if ($(window).width() < 768) {
            {% if settings.head_fix %}
                $(".js-category-controls").css("top" , mobile_nav_height);
            {% else %}
                $(".js-category-controls").css("top" , 0);
            {% endif %}

            {# Detect if category controls are sticky and add css #}

            var observer = new IntersectionObserver(function(entries) {
                if(entries[0].intersectionRatio === 0)
                    document.querySelector(".js-category-controls").classList.add("is-sticky");
                else if(entries[0].intersectionRatio === 1)
                    document.querySelector(".js-category-controls").classList.remove("is-sticky");
                }, { threshold: [0,1] 
            });

            observer.observe(document.querySelector(".js-category-controls-prev"));
        }

        {# /* // Filters */ #}

        $(document).on("click", ".js-apply-filter, .js-remove-filter", function(e) {
            e.preventDefault();
            var filter_name = $(this).data('filter-name');
            var filter_value = $(this).data('filter-value');
            if($(this).hasClass("js-apply-filter")){
                $(this).find("[type=checkbox]").prop("checked", true);
                LS.urlAddParam(
                    filter_name, 
                    filter_value, 
                    true
                );
            }else{
                $(this).find("[type=checkbox]").prop("checked", false);
                LS.urlRemoveParam(
                    filter_name, 
                    filter_value
                );   
            }
            {# Toggle class to avoid adding double parameters in case of double click and show applying changes feedback #}

            if ($(this).hasClass("js-filter-checkbox")){
                if ($(window).width() < 768) {
                    $(".js-filters-overlay").show();
                    if($(this).hasClass("js-apply-filter")){
                        $(".js-applying-filter").show();
                    }else{
                        $(".js-removing-filter").show();
                    }
                }
                $(this).toggleClass("js-apply-filter js-remove-filter");
            }
        });

        $(document).on("click", ".js-remove-all-filters", function(e) {
            e.preventDefault();
            LS.urlRemoveAllParams();
        });

		{# /* //  Accordions */ #}

		$(document).on("click", ".js-accordion-toggle", function(e) {
			e.preventDefault();
			if($(this).hasClass("js-accordion-show-only")){
				$(this).hide();
			}else{
				$(this).find(".js-accordion-toggle-inactive").toggle();
				$(this).find(".js-accordion-toggle-active").toggle();
			}
			$(this).prev(".js-accordion-container").slideToggle();
		});

		{# /* // Sort by */ #}

		$('.js-sort-by').change(function () {
            var params = LS.urlParams;
            params['sort_by'] = $(this).val();
            var sort_params_array = [];
            for (var key in params) {
                if ($.inArray(key, ['results_only', 'page']) == -1) {
                    sort_params_array.push(key + '=' + params[key]);
                }
            }
            var sort_params = sort_params_array.join('&');
            window.location = window.location.pathname + '?' + sort_params;
        });

	{% endif %}

    {% if template == 'category' or template == 'search' %}

        $(function() {

        	{# /* // Infinite scroll */ #}

            {% if pages.current == 1 and not pages.is_last %}
                LS.hybridScroll({
                    productGridSelector: '.js-product-table',
                    spinnerSelector: '#js-infinite-scroll-spinner',
                    loadMoreButtonSelector: '.js-load-more',
                    hideWhileScrollingSelector: ".js-hide-footer-while-scrolling",
                    productsBeforeLoadMoreButton: 50,
                    productsPerPage: 12
                });
            {% endif %}
        });

	{% endif %}

    {#/*============================================================================
	  #Product detail functions
	==============================================================================*/ #}

	{# /* // Installments */ #}

	{# Installments without interest #}

	function get_max_installments_without_interests(number_of_installment, installment_data, max_installments_without_interests) {
	    if (parseInt(number_of_installment) > parseInt(max_installments_without_interests[0])) {
	        if (installment_data.without_interests) {
	            return [number_of_installment, installment_data.installment_value.toFixed(2)];
	        }
	    }
	    return max_installments_without_interests;
	}

	{# Installments with interest #}

	function get_max_installments_with_interests(number_of_installment, installment_data, max_installments_with_interests) {
	    if (parseInt(number_of_installment) > parseInt(max_installments_with_interests[0])) {
	        if (installment_data.without_interests == false) {
	            return [number_of_installment, installment_data.installment_value.toFixed(2)];
	        }
	    }
	    return max_installments_with_interests;
	}

	{# Refresh installments inside detail popup #}

	function refreshInstallmentv2(price){
	    $(".js-modal-installment-price" ).each(function( index ) {
	        const installment = Number($(this).data('installment'));
	        $(this).text(LS.currency.display_short + (price/installment).toLocaleString('de-DE', {maximumFractionDigits: 2, minimumFractionDigits: 2}));
	    });
	}

    {# Refresh price on payments popup with payment discount applied #}

    function refreshPaymentDiscount(price){
        $(".js-price-with-discount" ).each(function( index ) {
            const payment_discount = $(this).data('payment-discount');
            $(this).text(LS.formatToCurrency(price - ((price * payment_discount) / 100)))
        });
    }

	{# /* // Change variant */ #}

	{# Updates price, installments, labels and CTA on variant change #}

	function changeVariant(variant){

	    $(".js-product-detail .js-shipping-calculator-response").hide();
	    $("#shipping-variant-id").val(variant.id);

	    var parent = $("body");
	    if (variant.element){
	        parent = $(variant.element);
	    }

	    var sku = parent.find('#sku');
	    if(sku.length) {
	        sku.text(variant.sku).show();
	    }

	    var installment_helper = function($element, amount, price){
	        $element.find('.js-installment-amount').text(amount);
	        $element.find('.js-installment-price').attr("data-value", price);
	        $element.find('.js-installment-price').text(LS.currency.display_short + parseFloat(price).toLocaleString('de-DE', { minimumFractionDigits: 2 }));
	        if(variant.price_short && Math.abs(variant.price_number - price * amount) < 1) {
	            $element.find('.js-installment-total-price').text((variant.price_short).toLocaleString('de-DE', { minimumFractionDigits: 2 }));
	        } else {
	            $element.find('.js-installment-total-price').text(LS.currency.display_short + (price * amount).toLocaleString('de-DE', { minimumFractionDigits: 2 }));
	        }
	    };

	    if (variant.installments_data) {
	        var variant_installments = JSON.parse(variant.installments_data);
	        var max_installments_without_interests = [0,0];
	        var max_installments_with_interests = [0,0];
	        $.each(variant_installments, function(payment_method, installments) {
	            $.each(installments, function(number_of_installment, installment_data) {
	                max_installments_without_interests = get_max_installments_without_interests(number_of_installment, installment_data, max_installments_without_interests);
	                max_installments_with_interests = get_max_installments_with_interests(number_of_installment, installment_data, max_installments_with_interests);
	                var installment_container_selector = '#installment_' + payment_method + '_' + number_of_installment;

	                if(!parent.hasClass("js-quickshop-container")){
	                    installment_helper($(installment_container_selector), number_of_installment, installment_data.installment_value.toFixed(2));
	                }
	            });
	        });
	        var $installments_container = $(variant.element + ' .js-max-installments-container .js-max-installments');
	        var $installments_modal_link = $(variant.element + ' #btn-installments');
	        var $payments_module = $(variant.element + ' .js-product-payments-container');
	        var $installmens_card_icon = $(variant.element + ' .js-installments-credit-card-icon');

	        {% if product.has_direct_payment_only %}
	        var installments_to_use = max_installments_without_interests[0] >= 1 ? max_installments_without_interests : max_installments_with_interests;

	        if(installments_to_use[0] <= 0 ) {
	        {%  else %}
	        var installments_to_use = max_installments_without_interests[0] > 1 ? max_installments_without_interests : max_installments_with_interests;

	        if(installments_to_use[0] <= 1 ) {
	        {% endif %}
	            $installments_container.hide();
	            $installments_modal_link.hide();
	            $payments_module.hide();
	            $installmens_card_icon.hide();
	        } else {
	            $installments_container.show();
	            $installments_modal_link.show();
	            $payments_module.show();
	            $installmens_card_icon.show();
	            installment_helper($installments_container, installments_to_use[0], installments_to_use[1]);
	        }
	    }

	    if(!parent.hasClass("js-quickshop-container")){
	    	$('#installments-modal .js-installments-one-payment').text(variant.price_short).attr("data-value", variant.price_number);
		}
	    
	    if (variant.price_short){
	        parent.find('.js-price-display').text(variant.price_short).show();
	        parent.find('.js-price-display').attr("content", variant.price_number);
	    } else {
	        parent.find('.js-price-display').hide();
	    }

	    if ((variant.compare_at_price_short) && !(parent.find(".js-price-display").css("display") == "none")) {
	        parent.find('.js-compare-price-display').text(variant.compare_at_price_short).show();
	    } else {
	        parent.find('.js-compare-price-display').hide();
	    }

	    var button = parent.find('.js-addtocart');
	    button.removeClass('cart').removeClass('contact').removeClass('nostock');
	    var $product_shipping_calculator = parent.find("#product-shipping-container");
	    {% if not store.is_catalog %}
	    if (!variant.available){
	        button.val('{{ "Sin stock" | translate }}');
	        button.addClass('nostock');
	        button.attr('disabled', 'disabled');
	        $product_shipping_calculator.hide();
	    } else if (variant.contact) {
	        button.val('{{ "Consultar precio" | translate }}');
	        button.addClass('contact');
	        button.removeAttr('disabled');
	        $product_shipping_calculator.hide();
	    } else {
	        button.val('{{ "Agregar al carrito" | translate }}');
	        button.addClass('cart');
	        button.removeAttr('disabled');
	        $product_shipping_calculator.show();
	    }

	    {% endif %}

        {% if template == 'product' %}
            const base_price = Number($("#price_display").attr("content"));
            refreshInstallmentv2(base_price);
            refreshPaymentDiscount(variant.price_number);

            {% if settings.last_product and product.variations %}
                if(variant.stock == 1) {
                    $('.js-last-product').show();
                } else {
                    $('.js-last-product').hide();
                }
            {% endif %}
        {% endif %}

        {# Update shipping on variant change #}

        LS.updateShippingProduct();

        zipcode_on_changevariant = $("#product-shipping-container .js-shipping-input").val();
        $("#product-shipping-container .js-shipping-calculator-current-zip").text(zipcode_on_changevariant);
	}

	{# /* // Product labels on variant change */ #}

	{# Stock, Offer and discount labels update #}

	$(document).on("change", ".js-variation-option", function(e) {

        var $parent = $(this).closest(".js-product-variants");
        var $variants_group = $(this).closest(".js-product-variants-group");
        var $quickshop_parent_wrapper = $(this).closest(".js-quickshop-container");

        {# If quickshop is used from modal, use quickshop-id from the item that opened it #}
        
        var quick_id = $quickshop_parent_wrapper.attr("data-quickshop-id");

        if($parent.hasClass("js-product-quickshop-variants")){

            var $quickshop_parent = $(this).closest(".js-item-product");

            {# Target visible slider item if necessary #}
            
            if($quickshop_parent.hasClass("js-item-slide")){
                var $quickshop_variant_selector = '.js-swiper-slide-visible .js-quickshop-container[data-quickshop-id="'+quick_id+'"]';
            }else{
                var $quickshop_variant_selector = '.js-quickshop-container[data-quickshop-id="'+quick_id+'"]';
            }
            
            LS.changeVariant(changeVariant, $quickshop_variant_selector);

            {% if settings.product_color_variants %}
                {# Match selected color variant with selected quickshop variant #}

                if(($variants_group).hasClass("js-color-variants-container")){
                    var selected_option_id = $(this).find("option:selected").val();
                    if($quickshop_parent.hasClass("js-item-slide")){
                        var $color_parent_to_update = $('.js-swiper-slide-visible .js-quickshop-container[data-quickshop-id="'+quick_id+'"]');
                    }else{
                        var $color_parent_to_update = $('.js-quickshop-container[data-quickshop-id="'+quick_id+'"]');
                    }
                    $color_parent_to_update.find('.js-color-variant').removeClass("selected");
                    $color_parent_to_update.find('.js-color-variant[data-option="'+selected_option_id+'"]').addClass("selected");
                }
            {% endif %} 
        } else {
            LS.changeVariant(changeVariant, '#single-product');
        }

        {# Offer and discount labels update #}

        var $this_product_container = $(this).closest(".js-product-container");

        if($this_product_container.hasClass("js-quickshop-container")){
            var this_quickshop_id = $this_product_container.attr("data-quickshop-id");
            var $this_product_container = $('.js-product-container[data-quickshop-id="'+this_quickshop_id+'"]');
        }
        var $this_compare_price = $this_product_container.find(".js-compare-price-display");
        var $this_price = $this_product_container.find(".js-price-display");
        var $installment_container = $this_product_container.find(".js-product-payments-container");
        var $installment_text = $this_product_container.find(".js-max-installments-container");
        var $this_add_to_cart = $this_product_container.find(".js-prod-submit-form");

        // Get the current product discount percentage value
        var current_percentage_value = $this_product_container.find(".js-offer-percentage");

        // Get the current product price and promotional price
        var compare_price_value = $this_compare_price.html();
        var price_value = $this_price.html();

        // Calculate new discount percentage based on difference between filtered old and new prices
        const percentageDifference = window.moneyDifferenceCalculator.percentageDifferenceFromString(compare_price_value, price_value);
        if(percentageDifference){
            $this_product_container.find(".js-offer-percentage").text(percentageDifference);
            $this_product_container.find(".js-offer-label").css("display" , "table");
        }

	    if ($this_compare_price.css("display") == "none" || !percentageDifference) {
	        $this_product_container.find(".js-offer-label").hide();
	    }

	    if ($this_add_to_cart.hasClass("nostock")) {
	        $this_product_container.find(".js-stock-label").show();
	    }
	    else {
	        $this_product_container.find(".js-stock-label").hide();
	    }
	    if ($this_price.css('display') == 'none'){
	        $installment_container.hide();
	        $installment_text.hide();
	    }else{
	        $installment_text.show();
	    }
	});

    {% if settings.product_color_variants %}

        {# Product color variations #}

        $(document).on("click", ".js-color-variant", function(e) {
            e.preventDefault();
            $this = $(this);

            var option_id = $this.data('option');
            $selected_option = $this.closest('.js-item-product').find('.js-variation-option option').filter(function() {
                return this.value == option_id;
            });
            $selected_option.prop('selected', true).trigger('change');
            var available_variant = $(this).closest(".js-quickshop-container").data('variants');

            var available_variant_color = $(this).closest('.js-color-variant-active').data('option');

            for (var variant in available_variant) {
                if (option_id == available_variant[variant]['option'+ available_variant_color ]) {

                    if (available_variant[variant]['stock'] == null || available_variant[variant]['stock'] > 0 ) {

                        var otherOptions = getOtherOptionNumbers(available_variant_color);

                        var otherOption = available_variant[variant]['option' + otherOptions[0]];
                        var anotherOption = available_variant[variant]['option' + otherOptions[1]];

                        changeSelect($(this), otherOption, otherOptions[0]);
                        changeSelect($(this), anotherOption, otherOptions[1]);
                        break;

                    }
                }
            }
            $this.siblings().removeClass("selected");
            $this.addClass("selected");
        });

        function getOtherOptionNumbers(selectedOption) {
            switch (selectedOption) {
                case 0:
                    return [1, 2];
                case 1:
                    return [0, 2];
                case 2:
                    return [0, 1];
            }
        }

        function changeSelect(element, optionToSelect, optionIndex) {
            if (optionToSelect != null) {
                var selected_option_parent_id = element.closest('.js-item-product').data("product-id");
                var selected_option_attribute = $('.js-item-product[data-product-id="'+selected_option_parent_id+'"]').find('.js-color-variant-available-' + (optionIndex + 1)).data('value');
                var selected_option = $('.js-item-product[data-product-id="'+selected_option_parent_id+'"]').find('.js-variation-option[data-variant-id="'+selected_option_attribute+'"] option').filter(function() {
                    return this.value == optionToSelect;
                });

                selected_option.prop('selected', true).trigger('change');
            }
        }

    {% endif %}

    {% if settings.product_color_variants or settings.quick_shop %}
    
        {# Product quickshop for color variations #}

        LS.registerOnChangeVariant(function(variant){
            {# Show product image on color change #}
            
            var $item_to_update_image = $('.js-item-product[data-product-id^="'+variant.product_id+'"].js-swiper-slide-visible');
            var $item_to_update_image_cloned = $('.js-item-product[data-product-id^="'+variant.product_id+'"].js-swiper-slide-visible.swiper-slide-duplicate');

            {# If item is cloned from swiper change only cloned item #}

            if($item_to_update_image.hasClass("swiper-slide-duplicate")){
                var slide_item_index = $item_to_update_image_cloned.attr("data-swiper-slide-index");
                var current_image = $('.js-item-image', '.js-item-product[data-product-id="'+variant.product_id+'-clone-'+slide_item_index+'" ]');
            }else{
                var slide_item_index = $item_to_update_image.attr("data-swiper-slide-index");
                var current_image = $('.js-item-image', '.js-item-product[data-product-id="'+variant.product_id+'"]');
            }
            current_image.attr('srcset', variant.image_url);
        });

        
    {% endif %}

    {% if settings.quick_shop %}
        
        $(document).on("click", ".js-quickshop-modal-open", function (e) {
            e.preventDefault();
            var $this = $(this);
            if($this.hasClass("js-quickshop-slide")){
                $("#quickshop-modal .js-item-product").addClass("js-swiper-slide-visible js-item-slide");
            }
            LS.fillQuickshop($this);
        });

        {# Get width of the placeholder button #}
        var productButttonWidth = $(".js-addtocart-placeholder-inline").prev(".js-addtocart").innerWidth();
        $(".js-addtocart-placeholder-inline").width(productButttonWidth-20);
    {% endif %}

	{# /* // Submit to contact */ #}

	{# Submit to contact form when product has no price #}

	$(".js-product-form").submit(function (e) {
	    var button = $(this).find(':submit');
	    button.attr('disabled', 'disabled');
	    if ((button.hasClass('contact')) || (button.hasClass('catalog'))) {
	        e.preventDefault();
	        var product_id = $(this).find("input[name='add_to_cart']").val();
	        window.location = "{{ store.contact_url | escape('js') }}?product=" + product_id;
	    } else if (button.hasClass('cart')) {
	        button.val('{{ "Agregando..." | translate }}');
	    }
	});

	{% if template == 'product' %}

	    {# /* // Product slider */ #}

            {% set has_multiple_slides = product.images_count > 1 or video_url %}

            var productSwiper = new Swiper ('.js-swiper-product', {
                lazy: true,
                loop: false,
                pagination: {
                    el: '.js-swiper-product-pagination',
                    type: 'fraction',
                    clickable: true,
                },
                navigation: {
                    nextEl: '.js-swiper-product-next',
                    prevEl: '.js-swiper-product-prev',
                },
                on: {
                    init: function () {
                      $(".js-product-slider-placeholder").hide();
                      $(".js-swiper-product").css({"visibility" : "visible" , "height" : "auto"});
                        {% if video_url %}
                            productSwiperHeight = $(".js-swiper-product").height();
                            $(".js-product-video-slide").height(productSwiperHeight);
                        {% endif %}
                    },
                    {% if video_url %}
                        slideChangeTransitionEnd: function () {
                            if($(".js-product-video-slide").hasClass("swiper-slide-active")){
                                $(".js-labels-group").fadeOut(100);
                            }else{
                                $(".js-labels-group").fadeIn(100);
                            }
                            $('.js-video').show();
                            $('.js-video-iframe').hide().find("iframe").remove();
                        },
                    {% endif %}
                },
            });

            $().fancybox({
                selector : '[data-fancybox="product-gallery"]',
                toolbar  : false,
                smallBtn : true,
                beforeClose : function(instance) {                    
                    // Update position of the slider
                    productSwiper.slideTo( instance.currIndex, 0 );
                    
                  }
            });

	    {% if has_multiple_slides %}
	        LS.registerOnChangeVariant(function(variant){
	            var liImage = $('.js-swiper-product').find("[data-image='"+variant.image+"']");
	            var selectedPosition = liImage.data('image-position');
	            var slideToGo = parseInt(selectedPosition);
                productSwiper.slideTo(slideToGo);
                $(".js-product-slide-img").removeClass("js-active-variant");
                liImage.find(".js-product-slide-img").addClass("js-active-variant");
	        });
	    {% endif %}

        {# /* // Pinterest sharing */ #}

        $('.js-pinterest-share').click(function(e){
            e.preventDefault();
            $(".pinterest-hidden a")[0].click();
        });

	{% endif %}

    {# Product quantitiy #}

    $(document).on("click", ".js-quantity-up", function () {
        $quantity_input = $(this).closest(".js-quantity").find(".js-quantity-input");
        $quantity_input.val( parseInt($quantity_input.val(), 10) + 1);
    });

    $(document).on("click", ".js-quantity-down", function () {
        $quantity_input = $(this).closest(".js-quantity").find(".js-quantity-input");
        quantity_input_val = $quantity_input.val();
        if (quantity_input_val>1) { 
            $quantity_input.val( parseInt($quantity_input.val(), 10) - 1);
        }
    });

	{#/*============================================================================
	  #Cart
	==============================================================================*/ #}

    {# /* // Position of cart page summary */ #}

    var head_height = $(".js-head-main").outerHeight();

    if ($(window).width() > 768) {
        {% if settings.head_fix %}
            $("#cart-sticky-summary").css("top" , head_height + 10);
        {% else %}
            $("#cart-sticky-summary").css("top" , 10);
        {% endif %}
    }

    {# /* // Add to cart */ #}

	$(document).on("click", ".js-addtocart:not(.js-addtocart-placeholder)", function (e) {

        {# Button variables for transitions on add to cart #}

        var $productContainer = $(this).closest('.js-product-container');
        var $productVariants = $productContainer.find(".js-variation-option");
        var $productButton = $productContainer.find("input[type='submit'].js-addtocart");
        var $productButtonPlaceholder = $productContainer.find(".js-addtocart-placeholder");
        var $productButtonText = $productButtonPlaceholder.find(".js-addtocart-text");
        var $productButtonAdding = $productButtonPlaceholder.find(".js-addtocart-adding");
        var $productButtonSuccess = $productButtonPlaceholder.find(".js-addtocart-success");

        {# Define if event comes from quickshop or product page #}

        var isQuickShop = $productContainer.hasClass('js-quickshop-container');

        if (!isQuickShop) {
            if($(".js-product-slide-img.js-active-variant").length) {
                var imageSrc = $($productContainer.find('.js-product-slide-img.js-active-variant')[0]).data('srcset').split(' ')[0];
            } else {
                var imageSrc = $($productContainer.find('.js-product-slide-img')[0]).attr('srcset').split(' ')[0];
            }
            var name = $productContainer.find('.js-product-name').text();
            var price = $productContainer.find('.js-price-display').text();
        } else {
            var imageSrc = $(this).closest('.js-quickshop-container').find('img').attr('srcset');
            var name = $productContainer.find('.js-item-name').text();
            var price = $productContainer.find('.js-price-display').text().trim(); 
        }

        var quantity = $productContainer.find('.js-quantity-input').val();
        var addedToCartCopy = "{{ 'Agregar al carrito' | translate }}";


        if (!$(this).hasClass('contact')) {

            {% if settings.ajax_cart %}
                e.preventDefault();
            {% endif %}

            {# Hide real button and show button placeholder during event #}

            $productButton.hide();
            $productButtonPlaceholder.show().addClass("active");
            $productButtonText.removeClass("active");
            setTimeout(function(){
                $productButtonAdding.addClass("active");
            },300);

            {% if settings.ajax_cart %}

                var callback_add_to_cart = function(){

                    {# Animate cart amount #}

                    $(".js-cart-widget-amount").addClass("beat");

                    setTimeout(function(){
                        $(".js-cart-widget-amount").removeClass("beat");
                    },4000);

                    {# Fill notification info #}

                    $('.js-cart-notification-item-img').attr('srcset', imageSrc);
                    $('.js-cart-notification-item-name').text(name);
                    $('.js-cart-notification-item-quantity').text(quantity);
                    $('.js-cart-notification-item-price').text(price);

                    if($productVariants.length){
                        var output = [];

                        $productVariants.each( function(){  
                            var variants = $(this);
                            output.push(variants.val());
                        });
                        $(".js-cart-notification-item-variant-container").show();
                        $(".js-cart-notification-item-variant").text(output.join(', '))
                    }else{
                        $(".js-cart-notification-item-variant-container").hide();
                    }

                    {# Set products amount wording visibility #}

                    var cartItemsAmount = $(".js-cart-widget-amount").first().text();

                    if(cartItemsAmount > 1){
                        $(".js-cart-counts-plural").show();
                        $(".js-cart-counts-singular").hide();
                    }else{
                        $(".js-cart-counts-singular").show();
                        $(".js-cart-counts-plural").hide();
                    }

                    {# Show button placeholder with transitions #}

                    $productButtonAdding.removeClass("active");

                    setTimeout(function(){
                        $productButtonSuccess.addClass("active");
                    },300);
                    setTimeout(function(){
                        $productButtonSuccess.removeClass("active");
                        setTimeout(function(){
                            $productButtonText.addClass("active");
                        },300);
                        $productButtonPlaceholder.removeClass("active");
                    },2000);

                    setTimeout(function(){
                        $productButtonPlaceholder.hide();
                        $productButton.css('display' , 'inline-block');
                    },4000);

                    $productContainer.find(".js-added-to-cart-product-message").slideDown();

                    if (isQuickShop) {
                        closeModal($(".js-addtocart:not(.js-addtocart-placeholder)"));
                        if ($(window).width() < 768) {
                            cleanURLHash();
                        }
                    }

                    if ($(window).width() > 768) {
                        $(".js-toggle-cart").click();
                    }else{
                       {# Show notification and hide it only after second added to cart #}

                        setTimeout(function(){
                            $(".js-alert-added-to-cart").show().addClass("notification-visible").removeClass("notification-hidden");
                        },500);

                        if (!cookieService.get('first_product_added_successfully')) {
                            cookieService.set('first_product_added_successfully', 1, 7 ); 
                        } else{
                            setTimeout(function(){
                                $(".js-alert-added-to-cart").removeClass("notification-visible").addClass("notification-hidden");
                                setTimeout(function(){
                                    $('.js-cart-notification-item-img').attr('src', '');
                                    $(".js-alert-added-to-cart").hide();
                                },2000);
                            },8000);
                        }
                    }

                    {# Update shipping input zipcode on add to cart #}

                    {# Use zipcode from input if user is in product page, or use zipcode cookie if is not #}

                    if ($("#product-shipping-container .js-shipping-input").val()) {
                        zipcode_on_addtocart = $("#product-shipping-container .js-shipping-input").val();
                        $("#cart-shipping-container .js-shipping-input").val(zipcode_on_addtocart);
                        $(".js-shipping-calculator-current-zip").text(zipcode_on_addtocart);
                    } else if (cookieService.get('calculator_zipcode')){
                        var zipcode_from_cookie = cookieService.get('calculator_zipcode');
                        $('.js-shipping-input').val(zipcode_from_cookie);
                        $(".js-shipping-calculator-current-zip").text(zipcode_from_cookie);
                    }
                }
                var callback_error = function(){

                    {# Restore real button visibility in case of error #}

                    $productButtonPlaceholder.removeClass("active");
                    $productButtonText.fadeIn("active");
                    $productButtonAdding.removeClass("active");
                    $productButtonPlaceholder.hide();
                    $productButton.css('display' , 'inline-block');
                }
                $prod_form = $(this).closest("form");
                LS.addToCartEnhanced(
                    $prod_form,
                    '{{ "Agregar al carrito" | translate }}',
                    '{{ "Agregando..." | translate }}',
                    '{{ "¡Uy! No tenemos más stock de este producto para agregarlo al carrito." | translate }}',
                    {{ store.editable_ajax_cart_enabled ? 'true' : 'false' }},
                        callback_add_to_cart,
                        callback_error
                );
            {% endif %}
        }
    });


    {# /* // Cart quantitiy changes */ #}

    $(document).on("keypress", ".js-cart-quantity-input", function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    });

    $(document).on("focusout", ".js-cart-quantity-input", function (e) {
        $(".js-shipping-calculator-response").hide().empty();
        $(".js-go-checkout-btn").prop("disabled", true);
        var itemID = $(this).attr("data-item-id");
        var itemVAL = $(this).val();
        if (itemVAL == 0) {
            var r = confirm("{{ '¿Seguro que quieres borrar este artículo?' | translate }}");
            if (r == true) {
                LS.removeItem(itemID, true);
            } else {
                $(this).val(1);
            }
        } else {
            LS.changeQuantity(itemID, itemVAL, true);
        }
    });

    {# /* // Empty cart alert */ #}

    $(".js-trigger-empty-cart-alert").click(function (e) {
        e.preventDefault();
        $(".js-mobile-nav-empty-cart-alert").fadeIn(100).delay(1500).fadeOut(500);
    });

    {# /* // Go to checkout */ #}

    {# Clear cart notification cookie after consumers continues to checkout #}

    $('form[action="{{ store.cart_url | escape('js') }}"]').submit(function() {
        cookieService.remove('first_product_added_successfully');
    }); 

	{#/*============================================================================
	  #Shipping calculator
	==============================================================================*/ #}

	{# /* // Select and save shipping function */ #}

    selectShippingOption = function(elem, save_option) {
        $(".js-shipping-method, .js-branch-method").removeClass('js-selected-shipping-method');
        $(elem).addClass('js-selected-shipping-method');
        if (save_option) {
            LS.saveCalculatedShipping(true);
        }
        var $closest_shipping_container = $(elem).closest(".js-shipping-calculator-container");
        if($(elem).hasClass("js-shipping-method-hidden")){
            $closest_shipping_container.find(".js-shipping-see-more").hide();
            $closest_shipping_container.find(".js-shipping-see-less").show();
            $closest_shipping_container.find(".js-other-shipping-options").show();
        }
    };

    {# Apply zipcode saved by cookie if there is no zipcode saved on cart from backend #}

    if (cookieService.get('calculator_zipcode')) {

        {# If there is a cookie saved based on previous calcualtion, add it to the shipping input to triggert automatic calculation #}

        var zipcode_from_cookie = cookieService.get('calculator_zipcode');
        $('#product-shipping-container .js-shipping-input').val(zipcode_from_cookie);
        $(".js-shipping-calculator-current-zip").text(zipcode_from_cookie);

        {# Hide the shipping calculator and show spinner  #}

        $(".js-shipping-calculator-head").addClass("with-zip").removeClass("with-form");
        $(".js-shipping-calculator-with-zipcode").addClass("transition-up-active");
        $(".js-shipping-calculator-spinner").show();
    } else {

        {# If there is no cookie saved, show calcualtor #}

        $(".js-shipping-calculator-form").addClass("transition-up-active");
    }           

    {# Remove shipping suboptions from DOM to avoid duplicated modals #}

    removeShippingSuboptions = function(){
        var shipping_suboptions_id = $(".js-modal-shipping-suboptions").attr("id");
        $("#" + shipping_suboptions_id).remove();
        $('.js-modal-overlay[data-modal-id="#' + shipping_suboptions_id + '"').remove();
    };

    {# /* // Calculate shipping function */ #}

	$(".js-calculate-shipping").click(function (e) {
        e.preventDefault();

        {# Take the Zip code to all shipping calculators on screen #}
        let shipping_input_val = $(this).closest(".js-shipping-calculator-form").find(".js-shipping-input").val();

        $(".js-shipping-input").val(shipping_input_val);

        {# Calculate on page load for both calculators: Product and Cart #}

        {% if template == 'product' %}
            LS.calculateShippingAjax(
                $('#product-shipping-container').find(".js-shipping-input").val(), 
                '{{store.shipping_calculator_url | escape('js')}}',
                $("#product-shipping-container").closest(".js-shipping-calculator-container") );
        {% endif %}

        if ($(".js-cart-item").length) {
            LS.calculateShippingAjax(
                $('#cart-shipping-container').find(".js-shipping-input").val(), 
                '{{store.shipping_calculator_url | escape('js')}}',
                $("#cart-shipping-container").closest(".js-shipping-calculator-container") );
        }

        $(".js-shipping-calculator-current-zip").html(shipping_input_val);
        removeShippingSuboptions();

    });

	{# /* // Calculate shipping by submit */ #}

	$(".js-shipping-input").keydown(function (e) {
	    var key = e.which ? e.which : e.keyCode;
	    var enterKey = 13;
	    if (key === enterKey) {
	        e.preventDefault();
	        $(this).closest(".js-shipping-calculator-form").find(".js-calculate-shipping").click();
	        if ($(window).width() < 768) {
	            $(this).blur();
	        }
	    }
	});

    {# /* // Shipping and branch click */ #}

    $(document).on("change", ".js-shipping-method, .js-branch-method", function () {
        selectShippingOption(this, true);
        $(".js-shipping-method-unavailable").hide();
    });

    {# /* // Select shipping first option on results */ #}

    $('.js-shipping-method:checked').livequery(function () {
        let shippingPrice = $(this).attr("data-price");
        LS.addToTotal(shippingPrice);

        let total = (LS.data.cart.total / 100) + parseFloat(shippingPrice);
        $(".js-cart-widget-total").html(LS.formatToCurrency(total));

        selectShippingOption(this, false);
    });

    {# /* // Toggle branches link */ #}

    $(document).on("click", ".js-toggle-branches", function (e) {
        e.preventDefault();
        $(".js-store-branches-container").slideToggle("fast");
        $(".js-see-branches, .js-hide-branches").toggle();
    });

    {# /* // Toggle more shipping options */ #}

    $(document).on("click", ".js-toggle-more-shipping-options", function(e) {
        e.preventDefault();

        {# Toggle other options depending if they are pickup or delivery for cart and product at the same time #}

        if($(this).hasClass("js-show-other-pickup-options")){
            $(".js-other-pickup-options").slideToggle(600);
            $(".js-show-other-pickup-options .js-shipping-see-less, .js-show-other-pickup-options .js-shipping-see-more").toggle();
        }else{
            $(".js-other-shipping-options").slideToggle(600);
            $(".js-show-more-shipping-options .js-shipping-see-less, .js-show-more-shipping-options .js-shipping-see-more").toggle();
        }
    });

    {# /* // Calculate shipping on page load */ #}

    {# Only shipping input has value, cart has saved shipping and there is no branch selected #}

    calculateCartShippingOnLoad = function(){
        if($("#cart-shipping-container .js-shipping-input").val()){
       
            // If user already had calculated shipping: recalculate shipping
           
           setTimeout(function() { 
                LS.calculateShippingAjax(
                    $('#cart-shipping-container').find(".js-shipping-input").val(), 
                    '{{store.shipping_calculator_url | escape('js')}}',
                    $("#cart-shipping-container").closest(".js-shipping-calculator-container") );
                    removeShippingSuboptions();
            }, 100);
        } 

        if($(".js-branch-method").hasClass('js-selected-shipping-method')){
            
            {% if store.branches|length > 1 %}
                $(".js-store-branches-container").slideDown("fast");
                $(".js-see-branches").hide();
                $(".js-hide-branches").show();
            {% endif %}
        }
    };
    
    {% if cart.has_shippable_products %}
        calculateCartShippingOnLoad();
    {% endif %}

    {# /* // Calculate product detail shipping on page load */ #}

    {% if template == 'product' %}

        if($('#product-shipping-container').find(".js-shipping-input").val()){
            setTimeout(function() { 
                LS.calculateShippingAjax(
                    $('#product-shipping-container').find(".js-shipping-input").val(), 
                    '{{store.shipping_calculator_url | escape('js')}}',
                    $("#product-shipping-container").closest(".js-shipping-calculator-container") );
                
                removeShippingSuboptions();
            }, 100);
        }

    {% endif %}

    {# /* // Change CP */ #}

    $(document).on("click", ".js-shipping-calculator-change-zipcode", function(e) {
        e.preventDefault();
        $(".js-shipping-calculator-response").fadeOut(100);
        $(".js-shipping-calculator-head").addClass("with-form").removeClass("with-zip");
        $(".js-shipping-calculator-with-zipcode").removeClass("transition-up-active");
        $(".js-shipping-calculator-form").addClass("transition-up-active");
    }); 

	{# /* // Shipping provinces */ #}

	{% if provinces_json %}
		$('select[name="country"]').change(function () {
		    var provinces = {{ provinces_json | default('{}') | raw }};
		    LS.swapProvinces(provinces[$(this).val()]);
		}).change();
	{% endif %}

    {# /* // Change store country: From invalid zipcode message */ #}

    $(document).on("click", ".js-save-shipping-country", function(e) {
        e.preventDefault();
        {# Change shipping country #}

        var selected_country_url = $(this).closest(".js-modal-shipping-country").find(".js-shipping-country-select option:selected").attr("data-country-url");
        location.href = selected_country_url; 

        $(this).text('{{ "Aplicando..." | translate }}').addClass("disabled");
    });

    {#/*============================================================================
      #Forms
    ==============================================================================*/ #}

    $(".js-winnie-pooh-form").submit(function (e) {
        $(this).attr('action', '');
    });

    {# Show the success or error message when resending the validation link #}

    {% if template == 'account.register' or template == 'account.login' %}
        $(".js-resend-validation-link").click(function(e){
            window.accountVerificationService.resendVerificationEmail('{{ customer_email }}');
        });
    {% endif %}

    {% if template == 'account.login' %}
        {% if not result.facebook and result.invalid %}
            $(".js-account-input").addClass("alert-danger");
            $(".js-account-input.alert-danger").focus(function() {
              $(".js-account-input").removeClass("alert-danger");
            });
        {% endif %}
    {% endif %}

    $('.js-password-view').click(function () {
        $(this).toggleClass('password-view');
        if($(this).hasClass('password-view')){
           $(this).parent().find(".js-password-input").attr('type', '');
           $(this).find(".js-eye-open, .js-eye-closed").toggle();
        } else {
           $(this).parent().find(".js-password-input").attr('type', 'password');
           $(this).find(".js-eye-open, .js-eye-closed").toggle();
        }
    });

    {#/*============================================================================
      #Footer
    ==============================================================================*/ #}

    {% if store.afip %}

        {# Add alt attribute to external AFIP logo to improve SEO #}

        $('img[src*="www.afip.gob.ar"]').attr('alt', '{{ "Logo de AFIP" | translate }}');

    {% endif %}

});
