/* ------------------------------------------------------------------------------
 *
 *  # Template JS core
 *
 *  Includes minimum required JS code for proper template functioning
 *
 * ---------------------------------------------------------------------------- */


// Setup module
// ------------------------------

const App = function () {


    // Utils
    // -------------------------

    //
    // Transitions
    //

    // Disable all transitions
    const transitionsDisabled = function() {
        $('body').addClass('no-transitions');
    };

    // Enable all transitions
    const transitionsEnabled = function() {
        $('body').removeClass('no-transitions');
    };


    //
    // Detect OS to apply custom scrollbars
    //

    // Custom scrollbar style is controlled by CSS. This function is needed to keep default
    // scrollbars on MacOS and avoid usage of extra JS libraries
    const detectOS = function() {
        const platform = window.navigator.platform,
              windowsPlatforms = ['Win32', 'Win64', 'Windows', 'WinCE'],
              customScrollbarsClass = 'custom-scrollbars';

        // Add class if OS is windows
        windowsPlatforms.indexOf(platform) != -1 && $('body').addClass(customScrollbarsClass);
    };


    // Sidebars
    // -------------------------

    //
    // On desktop
    //

    // Resize main sidebar
    const sidebarMainResize = function() {

        // Elements
        const sidebarMainElement = $('.sidebar-main'),
              sidebarMainToggler = $('.sidebar-main-resize'),
              sidebarMobileTogglerClass = 'sidebar-mobile-expanded',
              resizeClass = 'sidebar-main-resized',
              navSubmenuClass = 'nav-group-sub',
              navSubmenuReversedClass = 'nav-group-sub-reversed',
              submenuToggleClass = 'nav-group-sub-visible',
              submenuElement = sidebarMainElement.find('.nav-sidebar > .nav-item-submenu');

        // Flip 2nd level if menu overflows
        // bottom edge of browser window
        const flipSubmenu = function() {

            // When mouse enters
            submenuElement.on('mouseenter', function() {
                $(this).addClass(submenuToggleClass);
                if(($(this).children('.' + navSubmenuClass).offset().top + $(this).find('.' + navSubmenuClass).filter(':visible').outerHeight()) > document.body.clientHeight) {
                    $(this).children('.' + navSubmenuClass).addClass(navSubmenuReversedClass)
                }
            });

            // When mouse leaves
            submenuElement.on('mouseleave', function() {
                $(this).removeClass(submenuToggleClass);
                $(this).children('.' + navSubmenuClass).removeClass(navSubmenuReversedClass);
            });
        }

        // Toggle classes on click
        sidebarMainToggler.on('click', function(e) {
            e.preventDefault();

            // Toggle class on sidebar
            if(!sidebarMainElement.hasClass(resizeClass)) {
                sidebarMainElement.addClass(resizeClass);
                sidebarMainElement.removeClass(sidebarMobileTogglerClass);
                flipSubmenu();
            }
            else {
                sidebarMainElement.removeClass(resizeClass + ' ' + sidebarMobileTogglerClass);
                submenuElement.off('mouseenter mouseleave');
            }
        });

        // If main sidebar is resized by default
        if(sidebarMainElement.hasClass(resizeClass)) {
            flipSubmenu();
        }
    };

    // Toggle main sidebar
    const sidebarMainToggle = function() {

        // Elements
        const sidebarMainElement = $('.sidebar-main'),
              sidebarMainRestElements = $('.sidebar:not(.sidebar-main)'),
              sidebarMainDesktopToggler = $('.sidebar-main-toggle'),
              sidebarMainMobileToggler = $('.sidebar-mobile-main-toggle'),
              sidebarCollapsedClass = 'sidebar-collapsed',
              sidebarMobileExpandedClass = 'sidebar-mobile-expanded';

        // On desktop
        sidebarMainDesktopToggler.on('click', function(e) {
            e.preventDefault();
            sidebarMainElement.toggleClass(sidebarCollapsedClass);
        });                

        // On mobile
        sidebarMainMobileToggler.on('click', function(e) {
            e.preventDefault();
            sidebarMainElement.toggleClass(sidebarMobileExpandedClass);
            sidebarMainRestElements.removeClass(sidebarMobileExpandedClass);
        });                
    };

    // Toggle secondary sidebar
    const sidebarSecondaryToggle = function() {

        // Elements
        const sidebarSecondaryElement = $('.sidebar-secondary'),
              sidebarSecondaryRestElements = $('.sidebar:not(.sidebar-secondary):not(.sidebar-component)'),
              sidebarSecondaryDesktopToggler = $('.sidebar-secondary-toggle'),
              sidebarSecondaryMobileToggler = $('.sidebar-mobile-secondary-toggle'),
              sidebarCollapsedClass = 'sidebar-collapsed',
              sidebarMobileExpandedClass = 'sidebar-mobile-expanded';

        // On desktop
        sidebarSecondaryDesktopToggler.on('click', function(e) {
            e.preventDefault();
            sidebarSecondaryElement.toggleClass(sidebarCollapsedClass);
        });

        // On mobile
        sidebarSecondaryMobileToggler.on('click', function(e) {
            e.preventDefault();
            sidebarSecondaryElement.toggleClass(sidebarMobileExpandedClass);
            sidebarSecondaryRestElements.removeClass(sidebarMobileExpandedClass);
        });
    };

    // Toggle right sidebar
    const sidebarRightToggle = function() {

        // Elements
        const sidebarRightElement = $('.sidebar-right'),
              sidebarRightRestElements = $('.sidebar:not(.sidebar-right):not(.sidebar-component)'),
              sidebarRightDesktopToggler = $('.sidebar-right-toggle'),
              sidebarRightMobileToggler = $('.sidebar-mobile-right-toggle'),
              sidebarCollapsedClass = 'sidebar-collapsed',
              sidebarMobileExpandedClass = 'sidebar-mobile-expanded';

        // On desktop
        sidebarRightDesktopToggler.on('click', function(e) {
            e.preventDefault();
            sidebarRightElement.toggleClass(sidebarCollapsedClass);
        });

        // On mobile
        sidebarRightMobileToggler.on('click', function(e) {
            e.preventDefault();
            sidebarRightElement.toggleClass(sidebarMobileExpandedClass);
            sidebarRightRestElements.removeClass(sidebarMobileExpandedClass);
        });                
    };


    // Navigations
    // -------------------------

    // Sidebar navigation
    const navigationSidebar = function() {

        // Define default class names and options
        var navClass = 'nav-sidebar',
            navItemClass = 'nav-item',
            navItemOpenClass = 'nav-item-open',
            navLinkClass = 'nav-link',
            navSubmenuClass = 'nav-group-sub',
            navSubmenuExpandedClass = 'nav-group-sub-visible',
            navScrollSpyClass = 'nav-scrollspy',
            navSlidingSpeed = 250;

        // Configure collapsible functionality
        $('.' + navClass + ':not(.' + navScrollSpyClass + ')').each(function() {
            $(this).find('.' + navItemClass).has('.' + navSubmenuClass).children('.' + navItemClass + ' > ' + '.' + navLinkClass).not('.disabled').on('click', function (e) {
                e.preventDefault();

                // Simplify stuff
                var $target = $(this);
                var $navSidebarMini = $('.sidebar-main-resized:not(.sidebar-mobile-expanded)').find('.' + navClass).children('.' + navItemClass);

                // Collapsible
                if($target.parent('.' + navItemClass).hasClass(navItemOpenClass)) {
                    $target.parent('.' + navItemClass).not($navSidebarMini).removeClass(navItemOpenClass).children('.' + navSubmenuClass).slideUp(navSlidingSpeed);
                }
                else {
                    $target.parent('.' + navItemClass).not($navSidebarMini).addClass(navItemOpenClass).children('.' + navSubmenuClass).slideDown(navSlidingSpeed);
                }

                // Accordion
                if ($target.parents('.' + navClass).data('nav-type') == 'accordion') {
                    $target.parent('.' + navItemClass).not($navSidebarMini).siblings(':has(.' + navSubmenuClass + ')').removeClass(navItemOpenClass).children('.' + navSubmenuClass).slideUp(navSlidingSpeed);
                }
            });
        });

        // Disable click in disabled navigation items
        $(document).on('click', '.' + navClass + ' .disabled', function(e) {
            e.preventDefault();
        });
    };

    // Navbar navigation
    const navigationNavbar = function() {

        // Prevent dropdown from closing on click
        $(document).on('click', '.dropdown-content', function(e) {
            e.stopPropagation();
        });

        // Disabled links
        $('.navbar-nav .disabled a, .nav-item-levels .disabled').on('click', function(e) {
            e.preventDefault();
            e.stopPropagation();
        });

        // Show tabs inside dropdowns
        $('.dropdown-content a[data-toggle="tab"]').on('click', function() {
            $(this).tab('show');
        });
    };


    // Components
    // -------------------------

    // Tooltip
    const componentTooltip = function() {
        $('[data-popup="tooltip"]').tooltip();
    };

    // Popover
    const componentPopover = function() {
        $('[data-popup="popover"]').popover();
    };

    // "Go to top" button
    const componentToTopButton = function() {

        // Elements
        const toTopContainer = $('body'),
              scrollableContainer = $(window),
              scrollableDistance = 250;


        // Create button
        toTopContainer.append($('<div class="btn-to-top"><button type="button" class="btn btn-dark btn-icon rounded-pill"><i class="icon-arrow-up8"></i></button></div>'));

        // Show and hide on scroll
        const to_top_button = $('.btn-to-top'),
              add_class_on_scroll = function() {
                to_top_button.addClass('btn-to-top-visible');
              },
              remove_class_on_scroll = function() {
                to_top_button.removeClass('btn-to-top-visible');
              };

        scrollableContainer.on('scroll', function() { 
            const scrollpos = scrollableContainer.scrollTop();
            if (scrollpos >= scrollableDistance) {
                add_class_on_scroll();
            }
            else {
                remove_class_on_scroll();
            }
        });

        // Scroll to top on click
        $('.btn-to-top .btn').on('click', function() {
            scrollableContainer.scrollTop(0);
        });
    };


    // Card actions
    // -------------------------

    // Reload card (uses BlockUI extension)
    const cardActionReload = function() {

        // Elements
        const buttonElement = $('[data-action=reload]'),
              overlayContainer = '.card',
              overlayClass = 'card-overlay',
              spinnerClass = 'icon-spinner9 spinner text-body',
              overlayAnimationClass = 'card-overlay-fadeout';


        // Configure
        buttonElement.on('click', function(e) {
            e.preventDefault();

            // Create overlay with spinner
            $(this).parents(overlayContainer).append($('<div class="' + overlayClass + '"><i class="' + spinnerClass + '"></i></div>'));

            // Remove overlay after 2.5s, for demo only
            setTimeout(function() {
                $('.' + overlayClass).addClass(overlayAnimationClass).on('animationend animationcancel', function() {
                    $(this).remove();
                });
            }, 2500);
        });
    };

    // Collapse card
    const cardActionCollapse = function() {

        // Elements
        const buttonElement = $('[data-action=collapse]'),
              cardContainer = '.card',
              cardCollapsedClass = 'card-collapsed';

        // Configure
        buttonElement.on('click', function(e) {
            e.preventDefault();

            const parentContainer = $(this).parents('.card'),
                  collapsibleContainer = parentContainer.find('> .collapse');

            if (parentContainer.hasClass(cardCollapsedClass)) {
                parentContainer.removeClass(cardCollapsedClass);
                collapsibleContainer.collapse('show');
            }
            else {
                parentContainer.addClass(cardCollapsedClass);
                collapsibleContainer.collapse('hide');
            }
        });
    };

    // Remove card
    const cardActionRemove = function() {

        // Elements
        const buttonElement = $('[data-action=remove]'),
              cardContainer = '.card';

        // Configure
        buttonElement.on('click', function(e) {
            e.preventDefault();
            $(this).parents(cardContainer).slideUp(150);
        });
    };

    // Card fullscreen mode
    const cardActionFullscreen = function() {

        // Elements
        const buttonElement = '[data-action=fullscreen]',
              buttonClass = 'list-icons-item',
              buttonContainerClass = 'list-icons',
              cardFullscreenClass = 'card-fullscreen',
              collapsedClass = 'collapsed-in-fullscreen',
              scrollableContainer = 'body',
              fullscreenAttr = 'data-fullscreen';

        // Configure
        $(buttonElement).on('click', function(e) {
            e.preventDefault();
            const button = $(this);

            // Get closest card container
            const cardFullscreen = button.parents('.card');

            // Toggle required classes
            cardFullscreen.toggleClass(cardFullscreenClass);

            // Toggle classes depending on state
            if (!cardFullscreen.hasClass(cardFullscreenClass)) {
                button.removeAttr(fullscreenAttr);
                cardFullscreen.find('.' + collapsedClass).removeClass('show');
                $(scrollableContainer).removeClass('overflow-hidden');
                button.parents('.' + buttonContainerClass).find('.' + buttonClass + ':not(' + buttonElement + ')').removeClass('d-none');
            }
            else {
                button.attr(fullscreenAttr, 'active');
                cardFullscreen.removeAttr('style');
                cardFullscreen.find('.collapse:not(.show)').addClass('show ' + collapsedClass);
                $(scrollableContainer).addClass('overflow-hidden');
                button.parents('.' + buttonContainerClass).find('.' + buttonClass + ':not(' + buttonElement + ')').addClass('d-none');
            }

        });
    };


    // Misc
    // -------------------------

    // Dropdown submenus. Trigger on click
    const dropdownSubmenu = function() {

        // All parent levels require .dropdown-toggle class
        $('.dropdown-menu').find('.dropdown-submenu').not('.disabled').find('.dropdown-toggle').on('click', function(e) {
            e.stopPropagation();
            e.preventDefault();

            const button = $(this);

            // Remove "show" class in all siblings
            button.parent().siblings().removeClass('show').find('.show').removeClass('show');

            // Toggle submenu
            button.parent().toggleClass('show').children('.dropdown-menu').toggleClass('show');

            // Hide all levels when parent dropdown is closed
            button.parents('.show').on('hidden.bs.dropdown', function(e) {
                $('.dropdown-submenu .show, .dropdown-submenu.show').removeClass('show');
            });
        });
    };

    // Header elements toggler
    const componentHeaderElements = function() {

        // Toggle visible state of header elements
        $('.header-elements-toggle').on('click', function(e) {
            e.preventDefault();
            $(this).parents('[class*=header-elements-]:not(.header-elements-toggle)').find('.header-elements').toggleClass('d-none');
        });

        // Toggle visible state of footer elements
        $('.footer-elements-toggle').on('click', function(e) {
            e.preventDefault();
            $(this).parents('.card-footer').find('.footer-elements').toggleClass('d-none');
        });
    };


    //
    // Return objects assigned to module
    //

    return {

        // Disable transitions before page is fully loaded
        initBeforeLoad: function() {
            detectOS();
            transitionsDisabled();
        },

        // Enable transitions when page is fully loaded
        initAfterLoad: function() {
            transitionsEnabled();
        },
        // Initialize all components
        initComponents: function() {
            componentTooltip();
            componentPopover();
            componentToTopButton();
            componentHeaderElements();
        },

        // Initialize all sidebars
        initSidebars: function() {
            sidebarMainResize();
            sidebarMainToggle();
            sidebarSecondaryToggle();
            sidebarRightToggle();
        },

        // Initialize all navigations
        initNavigations: function() {
            navigationSidebar();
            navigationNavbar();
        },

        // Initialize all card actions
        initCardActions: function() {
            cardActionReload();
            cardActionCollapse();
            cardActionRemove();
            cardActionFullscreen();
        },

        // Dropdown submenu
        initDropdowns: function() {
            dropdownSubmenu();
        },

        // Initialize core
        initCore: function() {
            App.initBeforeLoad();
            App.initSidebars();
            App.initNavigations();
            App.initComponents();
            App.initCardActions();
            App.initDropdowns();
        }
    }
}();


// Initialize module
// ------------------------------

// When content is loaded
document.addEventListener('DOMContentLoaded', function() {
    App.initCore();
});

// When page is fully loaded
window.addEventListener('load', function() {
    App.initAfterLoad();
});
