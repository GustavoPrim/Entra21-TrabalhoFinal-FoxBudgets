/* ------------------------------------------------------------------------------
 *
 *  # Input groups
 *
 *  Demo JS code for form_input_groups.html page
 *
 * ---------------------------------------------------------------------------- */


// Setup module
// ------------------------------

var InputGroups = function() {


    //
    // Setup module components
    //

    // Touchspin
    var _componentTouchspin = function() {
        if (!$().TouchSpin) {
            console.warn('Warning - touchspin.min.js is not loaded.');
            return;
        }

        // Basic example
        $('.touchspin-basic').TouchSpin({
            postfix: '<i class="icon-paragraph-justify3"></i>'
        });

        // Postfix
        $('.touchspin-postfix').TouchSpin({
            min: 0,
            max: 100,
            step: 0.1,
            decimals: 2,
            postfix: '%'
        });

        // Prefix
        $('.touchspin-prefix').TouchSpin({
            min: 0,
            max: 100,
            step: 0.1,
            decimals: 2,
            prefix: '$'
        });

        // Init with empty values
        $('.touchspin-empty').TouchSpin();

        // Disable mousewheel
        $('.touchspin-no-mousewheel').TouchSpin({
            mousewheel: false
        });

        // Incremental/decremental steps
        $('.touchspin-step').TouchSpin({
            step: 10
        });

        // Set value
        $('.touchspin-set-value').TouchSpin({
            initval: 40
        });

        // Inside button group
        $('.touchspin-button-group').TouchSpin({
            prefix: 'pre',
            postfix: 'post'
        });

        // Vertical spinners
        $('.touchspin-vertical').TouchSpin({
            verticalbuttons: true,
            verticalup: '<i class="icon-arrow-up12"></i>',
            verticaldown: '<i class="icon-arrow-down12"></i>'
        });
    };


    //
    // Return objects assigned to module
    //

    return {
        init: function() {
            _componentTouchspin();
        }
    }
}();


// Initialize module
// ------------------------------

document.addEventListener('DOMContentLoaded', function() {
    InputGroups.init();
});
