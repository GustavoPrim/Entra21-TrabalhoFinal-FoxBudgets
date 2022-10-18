/* ------------------------------------------------------------------------------
 *
 *  # Inbox page
 *
 *  Demo JS code for mail_list.html pages
 *
 * ---------------------------------------------------------------------------- */


// Setup module
// ------------------------------

var MailList = function() {


    //
    // Setup module components
    //

    // Inbox table
    var _componentTableInbox = function() {

        // Define variables
        var highlightColorClass = 'table-active';

        // Highlight row when checkbox is checked
        $('.table-inbox').find('tr > td:first-child').find('input[type=checkbox]').on('change', function() {
            if($(this).is(':checked')) {
                $(this).parents('tr').addClass(highlightColorClass);
            }
            else {
                $(this).parents('tr').removeClass(highlightColorClass);
            }
        });

        // Grab first letter and insert to the icon
        $('.table-inbox tr').each(function (i) {

            // Title
            var $title = $(this).find('.letter-icon-title'),
                letter = $title.eq(0).text().charAt(0).toUpperCase();

            // Icon
            var $icon = $(this).find('.letter-icon');
                $icon.eq(0).text(letter);
        });
    };

    // Row link
    var _componentRowLink = function() {
        if (!$().rowlink) {
            console.warn('Warning - rowlink.js is not loaded.');
            return;
        }

        // Initialize
        $('tbody.rowlink').rowlink({
            target: '.table-inbox-name > a'
        });
    };


    //
    // Return objects assigned to module
    //

    return {
        init: function() {
            _componentTableInbox();
            _componentRowLink();
        }
    }
}();


// Initialize module
// ------------------------------

document.addEventListener('DOMContentLoaded', function() {
    MailList.init();
});
