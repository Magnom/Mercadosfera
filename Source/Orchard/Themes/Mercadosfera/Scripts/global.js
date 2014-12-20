/* --------------------------------*/
/* - Total Theme
/* -------------------------------*/
jQuery(function($) {
	
	// VARS
	var $window = $(window);
	
	$(document).ready(function (){
		
		// If menu item has classname "nav-no-click" then  return false
		$('li.nav-no-click > a').click( function() {
			return false;
		});
		
		// Main superfish menu without supersubs
		$('ul.sf-menu').superfish({
			delay: 100,
			//animation: {opacity:'show', height:'show'},
			animation: { opacity: 'show' },
			speed: 'fast',
			speedOut: 'fast',
			cssArrows: false,
			disableHI: false
		});
		
		// Search - overlay modal
		$("a.search-overlay-toggle").leanerModal({
			id : '#searchform-overlay',
			top : 100,
			overlay : 0.6
		});

		$("a.search-overlay-toggle").click(function() {
			$('#site-searchform input').focus();
		});
		
		// Search - dropdown
		$("a.search-dropdown-toggle").click(function( event ) {
			$('div#current-shop-items-dropdown').hide();
			$("li.wcmenucart-toggle-dropdown").removeClass('current-menu-item');
			$('#searchform-dropdown').fadeToggle('fast');
			$('#searchform-dropdown input').focus();
			$(this).parent('li').toggleClass('current-menu-item');
			return false;
		});
		
		// Search - header replace
		$("a.search-header-replace-toggle").click(function( event ) {
			$('#searchform-header-replace').fadeToggle('fast');
			$('#searchform-header-replace input').focus();
			return false;
		});
		
		$('#searchform-header-replace-close').click( function(){
			$('#searchform-header-replace').fadeOut('fast');
			return false;
		});
		
		// Close searchforms
		$('#searchform-dropdown, #searchform-header-replace, #toggle-bar-wrap').click(function( event ) {
			event.stopPropagation(); 
		});
		
		$(document).click( function(){
			$('#searchform-dropdown, #searchform-header-replace').fadeOut('fast');
			$('a.search-dropdown-toggle').parent('li').removeClass('current-menu-item');
			$('#toggle-bar-wrap').fadeOut('fast');
			$('a.toggle-bar-btn.fade-toggle').children('.fa').removeClass('fa-minus').addClass('fa-plus');
		});
		
		// Sidebar menu toggle
		function wpexMenuWidget() {
			var submenuParent = $("div#main .widget_nav_menu ul.sub-menu").parent('li');
			submenuParent.addClass('parent');
			$('.parent > a').click( function() {
				$(this).parent('li').children('.sub-menu').stop(true,true).slideToggle('fast');
				$(this).parent('li').toggleClass('active');
				return false;
			});
		} wpexMenuWidget();
		
		// Woo Cart - Modal
		$("li.wcmenucart-toggle-overlay").leanerModal({ 
			id : '#current-shop-items-overlay',
			top : 100,
			overlay : 0.6
		});
		
		// Woo Car - Drop-down
		$("li.wcmenucart-toggle-dropdown").click(function( event ) {
			$('#searchform-dropdown').hide();
			$('a.search-dropdown-toggle').parent('li').removeClass('current-menu-item');
			$('div#current-shop-items-dropdown').fadeToggle('fast');
			$(this).toggleClass('current-menu-item');
			return false;
		});
		
		$('div#current-shop-items-dropdown').click(function( event ) {
			event.stopPropagation(); 
		});
		
		$(document).click( function(){
			$('div#current-shop-items-dropdown').fadeOut('fast');
			$("li.wcmenucart-toggle-dropdown").removeClass('current-menu-item');
		});
		
		// Mobile menu
		if ( $('.header-searchform-wrap').width() ) {
			var sidrSource = '#sidr-close, #site-navigation, .header-searchform-wrap';
		} else {
			var sidrSource = '#sidr-close, #site-navigation';
		}
		$('a.mobile-menu-toggle').sidr({
			name: 'sidr-main',
			source: sidrSource,
			side: 'left',
			displace: false
		});

		// Mobile menu subitem toggle
		$('.sidr-class-menu-item-has-children').each(function (index) {
			$(this).append('<span class="sidr-class-dropdown-toggle"><i class="fa fa-chevron-right"></i></span>');
		});
		$('.sidr-class-dropdown-toggle').on('click touchstart', function () {
			var nextList = $(this).prev('ul');
			var html = nextList.is(':visible') ? '<i class="fa fa-chevron-right"></i>' : '<i class="fa fa-chevron-down"></i>';
			$(this).html(html);
			nextList.toggle();
			$(this).toggleClass('active');
			return false;
		});
		
		// Close sidr on click
		$('a.sidr-class-toggle-sidr-close').click(function() {
			$.sidr('close', 'sidr-main');
			return false;
		});
		
		/* Close sidr on window resize
		$window.resize(function() {
			$.sidr('close', 'sidr-main');
		}); */

		// Back to top scroll
		$scrollTopLink = $( 'a#site-scroll-top' );
		$window.scroll(function () {
			if ($(this).scrollTop() > 100) {
				$scrollTopLink.fadeIn();
			} else {
				$scrollTopLink.fadeOut();
			}
		});
		$scrollTopLink.on('click', function() {
			$( 'html, body' ).animate({scrollTop:0}, 400);
			return false;
		} );

		// Comment scroll
		$( '.single li.comment-scroll a' ).click( function(event) {
			event.preventDefault();
			$( 'html,body' ).animate( {
				scrollTop: $( this.hash ).offset().top -180 }, 'normal');
		} );

		// Lightbox
		$('.wpex-lightbox, .wpb_single_image.image-lightbox a').magnificPopup( { type: 'image' } );
		$('.wpex-gallery-lightbox').each(function() {
			$(this).magnificPopup({
				delegate: 'a',
				type: 'image',
				gallery: {
					enabled: true
				}
			});
		});
		$('.woo-lightbox-gallery').each(function() {
			$(this).magnificPopup({
				delegate: 'a.woo-lightbox',
				type: 'image',
				gallery: {
					enabled: true
				}
			});
		});
		$('.wpex-lightbox-video,.wpb_single_image.video-lightbox a').magnificPopup({
			disableOn: 700,
			type: 'iframe',
			mainClass: 'vcex-mfp-slide-bottom',
			removalDelay: 160,
			preloader: false,
			fixedContentPos: false
		});
		$('.vcex-lightbox').magnificPopup({
			type: 'image',
			mainClass: 'vcex-mfp-slide-bottom',
			gallery: {
				enabled: false
			}
		});
		$('.vcex-gallery-lightbox').each(function() {
			$(this).magnificPopup({
				delegate: 'a',
				type: 'image',
				gallery: {
					enabled:true
				}
			});
		});

		// Tipsy
		$('a.tooltip-left').tipsy({fade: true, gravity: 'e'});
		$('a.tooltip-right').tipsy({fade: true, gravity: 'w'});
		$('a.tooltip-up').tipsy({fade: true, gravity: 's'});
		$('a.tooltip-down').tipsy({fade: true, gravity: 'n'});
		
		// Custom Selects
		$('.woocommerce-ordering .orderby, #dropdown_product_cat, .widget_categories select, .widget_archive select, .shipping-calculator-form select, .single-product .variations select, #bbp_stick_topic_select, #bbp_topic_status_select, #bbp_destination_topic').customSelect({
			customClass: "theme-select"
		});
		
		// Toggle boxed/full-width layouts
		$('li.wpex-boxed-layout-link a').click(function(){
			$('body').toggleClass('full-width-main-layout, boxed-main-layout');
			return false;
		});
		
		// Sociallight sharing buttons
		if ( $('.social-share-buttons.style-counter').width() ) {
			Socialite.load();
		}

		// Parallax Background
		$('.vcex-background-parallax').each(function(){
			var $bgobj = $(this);
			$window = $(window);
			$(window).scroll(function() {
				var yPos = -($window.scrollTop() / '10'); 
				var coords = '50% '+ yPos + 'px';
				$bgobj.css({ backgroundPosition: coords });
			});
		});

		// Toggle bar
		$('a.toggle-bar-btn.fade-toggle').click(function(){
			$(this).find('.fa').toggleClass('fa-plus fa-minus');
			$('#toggle-bar-wrap').fadeToggle('fast');
			return false;
		});

		// Local Scroll
		$('li.local-scroll a').click(function() {
			var topOffset = $('#site-header-sticky-wrapper').outerHeight();
			var target = $(this.hash);
			if (target.length) {
				$('html,body').animate({
					scrollTop: target.offset().top - topOffset
				}, 1000);
				return false;
			}
		});
		
	}); // End doc ready


	$window.load(function(){
		
		// Fixed header on scroll
		$("#site-header.fixed-scroll").sticky({topSpacing:0});
		
		// Fixed nav on scroll
		$(".fixed-nav").sticky({topSpacing:0});
		
		/*
		 Destroy fixed header if hovering over dropdown - needs major tweaking
		if ( $('.is-sticky').length == 0 ) {
			$('ul.sub-menu').hover( function() {
				$("#site-header.fixed-scroll").sticky('destroy');
			}, function() {
				$("#site-header.fixed-scroll").sticky({topSpacing:0});
			});
		} */

		// Woo Image swap
		$('.single-product .thumbnails a').click( function() {
			$('.active-thumb').removeClass('active-thumb');
			$('.single-product .thumbnails a').addClass('woo-lightbox');
			$(this).addClass('active-thumb');
			$(this).removeClass('woo-lightbox');
			var croppedImg = $(this).attr('href');
			var fullImg = $(this).data('mfp-src');
			var mainImgLink = $('.woocommerce-main-image');
			var mainImg = $('.woocommerce-main-image img');
			if ( croppedImg != mainImg ) {
				mainImgLink.attr( 'href', fullImg );
				mainImgLink.attr( 'data-mfp-src', fullImg );
				mainImg.attr( 'src', croppedImg );
			}
			return false;
		});

		// Gallery slider
		$('.gallery-format-post-slider').flexslider({
			animation: 'fade',
			animationSpeed: 500,
			slideshow: true,
			smoothHeight: false,
			controlNav: false,
			directionNav: true,
			controlNav : "thumbnails",
			prevText : '<span class="fa fa-chevron-left"></span>',
			nextText : '<span class="fa fa-chevron-right"></span>'
		});
		
		// Woo Product slider
		$( ".woo-product-entry-slider" ).each( function() {
			var $this = $(this);
			$(this).flexslider({
				animation: 'fade',
				slideshow : false,
				randomize : false,
				controlNav: true,
				directionNav: false,
				smoothHeight: false,
				prevText : '<span class="fa fa-chevron-left"></span>',
				nextText : '<span class="fa fa-chevron-right"></span>',
				start: function(slider) {
				$this.click(function(event){
					event.preventDefault();
						slider.flexAnimate(slider.getTarget("next"));
					});
				}
			});
		});
		
		// Masonry Grids
		/*function wpexBlogIsotope() {
		var $container = $('.blog-masonry-grid');
			$container.isotope({
				itemSelector: '.blog-entry'
			});
		} wpexBlogIsotope();
		var isIE8 = $.browser.msie && +$.browser.version === 8;
		if (isIE8) {
			document.body.onresize = function () {
				wpexBlogIsotope();
			};
		} else {
			$window.resize(function () {
				wpexBlogIsotope();
			});
		}
		window.addEventListener("orientationchange", function() {
			wpexBlogIsotope();
		});*/
		
	}); // End on window load
	
}); // End jQuery(function($)


/* --------------------------------*/
/* - Visual Composer Extension
/* -------------------------------*/
jQuery(function($){
	$(document).ready(function(){
		// Skillbar
		$('.vcex-skillbar').each(function(){
			$(this).find('.vcex-skillbar-bar').animate({ width: $(this).attr('data-percent') }, 800 );
		});
		// Parallax
		$('.style-parallax, .vcex-background-parallax').each(function(){
			var $bgobj = $(this);
			$window = $(window);
			$(window).scroll(function() {
				var yPos = -($window.scrollTop() / '10'); 
				var coords = '50% '+ yPos + 'px';
				$bgobj.css({ backgroundPosition: coords });
			});
		});
		// Milestone
		$('.vcex-animated-milestone').each(function() {
			$(this).appear(function() {
				$(this).find('.vcex-milestone-time').countTo();
			},{accX: 0, accY: 0});
		});
		// Lightbox
		$('.vcex-lightbox').magnificPopup({
			type: 'image',
			mainClass: 'vcex-mfp-slide-bottom',
			gallery: { enabled: false },
		});
		$('.vcex-gallery-lightbox').each(function() {
			$(this).magnificPopup({
				delegate: 'a',
				type: 'image',
				gallery: {
				  enabled:true
				}
			});
		});
		$('.vcex-lightbox-video').magnificPopup({
			disableOn: 700,
			type: 'iframe',
			mainClass: 'vcex-mfp-slide-bottom',
			removalDelay: 160,
			preloader: false,
			fixedContentPos: false
		});
	});
});



function ScaleImage(srcwidth, srcheight, targetwidth, targetheight, fLetterBox) {

    var result = { width: 0, height: 0, fScaleToTargetWidth: true };

    if ((srcwidth <= 0) || (srcheight <= 0) || (targetwidth <= 0) || (targetheight <= 0)) {
        return result;
    }

    // scale to the target width
    var scaleX1 = targetwidth;
    var scaleY1 = (srcheight * targetwidth) / srcwidth;

    // scale to the target height
    var scaleX2 = (srcwidth * targetheight) / srcheight;
    var scaleY2 = targetheight;

    // now figure out which one we should use
    var fScaleOnWidth = (scaleX2 > targetwidth);
    if (fScaleOnWidth) {
        fScaleOnWidth = fLetterBox;
    }
    else {
        fScaleOnWidth = !fLetterBox;
    }

    if (fScaleOnWidth) {
        result.width = Math.floor(scaleX1);
        result.height = Math.floor(scaleY1);
        result.fScaleToTargetWidth = true;
    }
    else {
        result.width = Math.floor(scaleX2);
        result.height = Math.floor(scaleY2);
        result.fScaleToTargetWidth = false;
    }
    result.targetleft = Math.floor((targetwidth - result.width) / 2);
    result.targettop = Math.floor((targetheight - result.height) / 2);

    return result;
}

function OnImageLoad(evt) {

    var img = evt.currentTarget;

    // what's the size of this image and it's parent
    var w = $(img).width();
    var h = $(img).height();
    var tw = $(img).parent().width();
    var th = $(img).parent().height();

    // compute the new size and offsets
    var result = ScaleImage(w, h, tw, th, false);

    // adjust the image coordinates and size
    img.width = result.width;
    img.height = result.height;
    $(img).css("left", result.targetleft);
    $(img).css("top", result.targettop);
}