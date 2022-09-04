/* ------------------------------------------------------------------------------
 *
 *  # Inbox page - Writing
 *
 *  Demo JS code for mail_list_write.html page
 *
 * ---------------------------------------------------------------------------- */


// Setup module
// ------------------------------

var MailListWrite = function() {


    //
    // Setup module components
    //

    // Summernote
    var _componentSummernote = function() {
        if (!$().summernote) {
            console.warn('Warning - summernote.min.js is not loaded.');
            return;
        }

        // Initialize
        $('.summernote').summernote();
    };


    //
    // Return objects assigned to module
    //

    return {
        init: function() {
            _componentSummernote();
        }
    }
}();


// Initialize module
// ------------------------------

document.addEventListener('DOMContentLoaded', function() {
    MailListWrite.init();
});
