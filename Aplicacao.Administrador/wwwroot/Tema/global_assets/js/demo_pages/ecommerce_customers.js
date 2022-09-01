/* ------------------------------------------------------------------------------
 *
 *  # ECommerce - Customers
 *
 *  Demo JS code for ecommerce_customers.html page
 *
 * ---------------------------------------------------------------------------- */


// Setup module
// ------------------------------

var EcommerceCustomers = function() {


    //
    // Setup module components
    //

    // Datatable
    var _componentDatatable = function() {
        if (!$().DataTable) {
            console.warn('Warning - datatables.min.js is not loaded.');
            return;
        }

        // Apply custom style to select
        $.extend( $.fn.dataTableExt.oStdClasses, {
            "sLengthSelect": "custom-select"
        });

        // Initialize
        $('.table-customers').DataTable({
            autoWidth: false,
            columnDefs: [
                {
                    targets: 0,
                    width: 400
                },
                { 
                    orderable: false,
                    width: 16,
                    targets: 6
                },
                {
                    className: 'control',
                    orderable: false,
                    targets: -1
                },
            ],
            order: [[ 0, 'asc' ]],
            dom: '<"datatable-header datatable-header-accent"fBl><"datatable-scroll-wrap"t><"datatable-footer"ip>',
            language: {
                search: '<span>Search people:</span> _INPUT_',
                searchPlaceholder: 'Type to filter...',
                lengthMenu: '<span>Show:</span> _MENU_',
                paginate: { 'first': 'First', 'last': 'Last', 'next': $('html').attr('dir') == 'rtl' ? '&larr;' : '&rarr;', 'previous': $('html').attr('dir') == 'rtl' ? '&rarr;' : '&larr;' }
            },
            lengthMenu: [ 25, 50, 75, 100 ],
            displayLength: 50,
            responsive: {
                details: {
                    type: 'column',
                    target: -1
                }
            },
            buttons: [
                {
                    extend: 'pdfHtml5',
                    text: 'Export list <i class="icon-file-pdf ml-2"></i>',
                    className: 'btn btn-primary',
                    orientation: 'landscape',
                    exportOptions: {
                        columns: [ 0, 1, 2, 3, 4, 5 ],
                        stripHtml: true
                    },
                    customize: function (doc) {
                        doc.content[1].table.widths = Array(doc.content[1].table.body[0].length + 1).join('*').split('');
                    }
                }
            ]
        });
    };


    //
    // Return objects assigned to module
    //

    return {
        init: function() {
            _componentDatatable();
        }
    }
}();


// Initialize module
// ------------------------------

document.addEventListener('DOMContentLoaded', function() {
    EcommerceCustomers.init();
});
