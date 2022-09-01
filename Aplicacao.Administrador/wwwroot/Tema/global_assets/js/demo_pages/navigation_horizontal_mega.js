/* ------------------------------------------------------------------------------
 *
 *  # Mega menu component
 *
 *  Demo JS code for navigation_horizontal_mega.html page
 *
 * ---------------------------------------------------------------------------- */


// Setup module
// ------------------------------

var HorizontalMegaMenu = function () {


    //
    // Setup module components
    //

    // Slinky
    var _componentSlinky = function() {
        if (!$().slinky) {
            console.warn('Warning - slinky.min.js is not loaded.');
            return;
        };

        // Attach drill down menu to menu list with child levels
        $('.nav-item-multi').one('shown.bs.dropdown', function () {
            $('.dropdown-item-group').each(function() {
                $(this).slinky({
                    title: true,
                    speed: 200
                });
            });
        });
    };


    //
    // Return objects assigned to module
    //

    return {
        initComponents: function() {
            _componentSlinky();
        }
    }
}();


// Initialize module
// ------------------------------

document.addEventListener('DOMContentLoaded', function() {
    HorizontalMegaMenu.initComponents();
});
