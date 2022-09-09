/* ------------------------------------------------------------------------------
 *
 *  # Columns Visibility (Buttons) extension for Datatables
 *
 *  Demo JS code for datatable_extension_colvis.html page
 *
 * ---------------------------------------------------------------------------- */


// Setup module
// ------------------------------

var DatatableColumnVisibility = function() {


    //
    // Setup module components
    //

    // Basic Datatable examples
    var _componentDatatableColumnVisibility = function() {
        if (!$().DataTable) {
            console.warn('Warning - datatables.min.js is not loaded.');
            return;
        }

        // Setting datatable defaults
        $.extend( $.fn.dataTable.defaults, {
            autoWidth: false,
            dom: '<"datatable-header"fBl><"datatable-scroll-wrap"t><"datatable-footer"ip>',
            language: {
                search: '<span>Filter:</span> _INPUT_',
                searchPlaceholder: 'Type to filter...',
                lengthMenu: '<span>Show:</span> _MENU_',
                paginate: { 'first': 'First', 'last': 'Last', 'next': $('html').attr('dir') == 'rtl' ? '&larr;' : '&rarr;', 'previous': $('html').attr('dir') == 'rtl' ? '&rarr;' : '&larr;' }
            }
        });

        // Apply custom style to select
        $.extend( $.fn.dataTableExt.oStdClasses, {
            "sLengthSelect": "custom-select"
        });

        
        // Basic example
        $('.datatable-colvis-basic').DataTable({
            buttons: [
                {
                    extend: 'colvis',
                    className: 'btn btn-light dropdown-toggle'
                }
            ]
        });


        // Multi-column layout
        $('.datatable-colvis-multi').DataTable({
            buttons: [
                {
                    extend: 'colvis',
                    text: '<i class="icon-three-bars"></i>',
                    className: 'btn btn-primary btn-icon dropdown-toggle',
                    collectionLayout: 'fixed two-column'
                }
            ]
        });


        // Restore column visibility
        $('.datatable-colvis-restore').DataTable({
            buttons: [
                {
                    extend: 'colvis',
                    text: '<i class="icon-grid7"></i>',
                    className: 'btn btn-teal btn-icon dropdown-toggle',
                    postfixButtons: [ 'colvisRestore' ]
                }
            ],
            columnDefs: [
                {
                    targets: -1,
                    visible: false
                }
            ]
        });


        // State saving
        $('.datatable-colvis-state').DataTable({
            buttons: [
                {
                    extend: 'colvis',
                    text: '<i class="icon-grid3"></i>',
                    className: 'btn btn-indigo btn-icon dropdown-toggle'
                }
            ],
            stateSave: true,
            columnDefs: [
                {
                    targets: -1,
                    visible: false
                }
            ]
        });


        // Column groups
        $('.datatable-colvis-group').DataTable({
            buttons: {
                buttons: [
                    {
                        extend: 'colvisGroup',
                        text: 'Office info',
                        className: 'btn btn-light',
                        show: [0, 1, 2],
                        hide: [3, 4, 5]
                    },
                    {
                        extend: 'colvisGroup',
                        className: 'btn btn-light',
                        text: 'HR info',
                        show: [3, 4, 5],
                        hide: [0, 1, 2]
                    },
                    {
                        extend: 'colvisGroup',
                        className: 'btn btn-light',
                        text: 'Show all',
                        show: ':hidden'
                    }
                ]
            }
        });
    };


    //
    // Return objects assigned to module
    //

    return {
        init: function() {
            _componentDatatableColumnVisibility();
        }
    }
}();


// Initialize module
// ------------------------------

document.addEventListener('DOMContentLoaded', function() {
    DatatableColumnVisibility.init();
});
