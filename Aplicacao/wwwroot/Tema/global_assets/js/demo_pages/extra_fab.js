/* ------------------------------------------------------------------------------
 *
 *  # Floating action buttons
 *
 *  Demo JS code for extra_fab.html page
 *
 * ---------------------------------------------------------------------------- */


// Setup module
// ------------------------------

var FloatingActionButton = function() {


    //
    // Setup module components
    //

    // FAB
    var _componentFab = function() {

        // Add bottom spacing if reached bottom, to avoid footer overlapping        
        window.addEventListener('scroll', function() {
            var bottomFabs = document.querySelectorAll('.fab-menu-bottom-left, .fab-menu-bottom-right'),
                fabClass = 'reached-bottom';

            for (var i = 0; i < bottomFabs.length; ++i) {
                if(window.pageYOffset + window.innerHeight > document.body.clientHeight - 40) {
                    bottomFabs[i].classList.add(fabClass);
                }
                else {
                    bottomFabs[i].classList.remove(fabClass);
                }
            }
        });
    };


    //
    // Return objects assigned to module
    //

    return {
        init: function() {
            _componentFab();
        }
    }
}();


// Initialize module
// ------------------------------

document.addEventListener('DOMContentLoaded', function() {
    FloatingActionButton.init();
});
