/* ------------------------------------------------------------------------------
 *
 *  # Yellow color palette showcase
 *
 *  Demo JS code for colors_yellow.html page
 *
 * ---------------------------------------------------------------------------- */


// Setup module
// ------------------------------

var YellowPalette = function() {


    //
    // Setup module components
    //

    // Select2
    var _componentSelect2 = function() {
        if (!$().select2) {
            console.warn('Warning - select2.min.js is not loaded.');
            return;
        }

        // Initialize
        $('.form-control-select2').select2();
    };

    // Multiselect
    var _componentMultiselect = function() {
        if (!$().multiselect) {
            console.warn('Warning - bootstrap-multiselect.js is not loaded.');
            return;
        }

        // Initialize
        $('.form-control-multiselect').multiselect({
            nonSelectedText: 'Select your state'
        });
    };

    // jGrowl
    var _componentJgrowl = function() {
        if (!$().jGrowl) {
            console.warn('Warning - jgrowl.min.js is not loaded.');
            return;
        }

        // Initialize
        $('.growl-launch').on('click', function () {
            $.jGrowl('Check me out! I\'m a jGrowl notice.', {
                header: 'Well highlighted',
                theme: 'bg-yellow text-black'
            });
        });
    };

    // PNotify
    var _componentPnotify = function() {
        if (typeof PNotify == 'undefined') {
            console.warn('Warning - pnotify.min.js is not loaded.');
            return;
        }

        // Initialize
        $('.pnotify-launch').on('click', function () {
            new PNotify({
                title: 'Notification',
                text: 'Check me out! I\'m a PNotify notice.',
                icon: 'icon-info22',
                addclass: 'bg-yellow border-yellow text-black'
            });
        });
    };

    // Noty
    var _componentNoty = function() {
        if (typeof Noty == 'undefined') {
            console.warn('Warning - noty.min.js is not loaded.');
            return;
        }

        // Initialize
        $('.noty-launch').on('click', function() {
            new Noty({
                layout: 'topRight',
                theme: ' alert bg-yellow text-black p-0',
                text: 'Check me out! I\'m a Noty notice.',
                timeout: 2500
            }).show();
        });
    };

    // Tooltips and popovers
    var _componentPopups = function() {

        // Tooltip
        $('[data-popup=tooltip-custom]').tooltip({
            template: '<div class="tooltip"><div class="arrow border-yellow"></div><div class="tooltip-inner bg-yellow text-black"></div></div>'
        });


        // Popover title
        $('[data-popup=popover-custom]').popover({
            trigger: 'hover',
            template: '<div class="popover border-yellow"><div class="arrow"></div><h3 class="popover-header bg-yellow text-black"></h3><div class="popover-body"></div></div>'
        });


        // Popover background color
        $('[data-popup=popover-solid]').popover({
            trigger: 'hover',
            template: '<div class="popover bg-yellow border-yellow text-black"><div class="arrow"></div><h3 class="popover-header"></h3><div class="popover-body text-black"></div></div>'
        });
    };


    //
    // Return objects assigned to module
    //

    return {
        init: function() {
            _componentSelect2();
            _componentMultiselect();
            _componentJgrowl();
            _componentPnotify();
            _componentNoty();
            _componentPopups();
        }
    }
}();


// Initialize module
// ------------------------------

document.addEventListener('DOMContentLoaded', function() {
    YellowPalette.init();
});
