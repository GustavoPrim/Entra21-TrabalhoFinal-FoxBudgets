/* ------------------------------------------------------------------------------
 *
 *  # Sidebar components
 *
 *  Demo JS code for sidebar_components.html page
 *
 * ---------------------------------------------------------------------------- */


// Setup module
// ------------------------------

var SidebarComponents = function () {


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
        $('.form-control-select2').select2({
            minimumResultsForSearch: Infinity
        });
    };

    // Multiselect
    var _componentMultiselect = function() {
        if (!$().multiselect) {
            console.warn('Warning - bootstrap-multiselect.js is not loaded.');
            return;
        }

        // Initialize
        $('.form-control-multiselect').multiselect();
    };

    // Color picker
    var _componentColorPicker = function() {
        if (!$().spectrum) {
            console.warn('Warning - spectrum.js is not loaded.');
            return;
        }

        // Initialize
        $('.colorpicker-flat-full').spectrum({
            flat: true,
            showInitial: true,
            showButtons: false,
            showInput: true,
            showAlpha: true,
            allowEmpty: true
        });
    };

    // Daterange picker
    var _componentDaterange = function() {
        if (!$().daterangepicker) {
            console.warn('Warning - daterangepicker.js is not loaded.');
            return;
        }

        // Initialize
        $('#reportrange').daterangepicker(
            {
                startDate: moment().subtract(29, 'days'),
                endDate: moment(),
                minDate: '01/01/2016',
                maxDate: '12/31/2019',
                dateLimit: { days: 60 },
                parentEl: '.content-wrapper',
                ranges: {
                    'Today': [moment(), moment()],
                    'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                    'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                    'This Month': [moment().startOf('month'), moment().endOf('month')],
                    'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
                },
                opens: $('html').attr('dir') == 'rtl' ? 'left' : 'right',
                buttonClasses: ['btn'],
                applyClass: 'btn-small btn-info btn-block',
                cancelClass: 'btn-small btn-light btn-block',
                locale: {
                    applyLabel: 'Submit',
                    fromLabel: 'From',
                    toLabel: 'To',
                    customRangeLabel: 'Custom Range',
                    daysOfWeek: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr','Sa'],
                    monthNames: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                    firstDay: 1,
                    direction: $('html').attr('dir') == 'rtl' ? 'rtl' : 'ltr'
                }
            },
            function(start, end) {
                $('#reportrange .daterange-custom-display').html(start.format('<i>D</i> <b><i>MMM</i> <i>YYYY</i></b>') + '<em> &#8211; </em>' + end.format('<i>D</i> <b><i>MMM</i> <i>YYYY</i></b>'));
            }
        );

        // Custom date display layout
        $('#reportrange .daterange-custom-display').html(moment().subtract(29, 'days').format('<i>D</i> <b><i>MMM</i> <i>YYYY</i></b>') + '<em> &#8211; </em>' + moment().format('<i>D</i> <b><i>MMM</i> <i>YYYY</i></b>'));
    };

    // jQuery UI components
    var _componentsJqueryUI = function() {
        if (!$().datepicker || !$().slider || !$().sortable) {
            console.warn('Warning - jQuery UI components are not loaded.');
            return;
        }

        // Date picker
        $('.datepicker').datepicker();


        //
        // Sliders
        //

        // Range slider
        $('.ui-slider-range').slider({
            range: true,
            min: 0,
            max: 60,
            values: [ 10, 50 ]
        });


        //
        // Add pips to horizontal slider
        //

        // First we need a slider to work with
        $('.ui-slider-labels').slider({
            max: 9,
            range: true,
            values: [ 2, 7 ]
        });

        // And then we can apply pips to it!
        $('.ui-slider-labels').slider('pips' , {
            rest: 'labels'
        });
        $('.ui-slider-labels').slider('float');


        //
        // Add pips to vertical slider
        //

        // Add options
        $('.ui-slider-vertical-pips > span').each(function() {

            // Read initial values from markup and remove that
            var value = parseInt($(this).text());

            $(this).empty().slider({
                min: 0,
                max: 9,
                value: value,
                animate: true,
                range: 'min',
                orientation: 'vertical'
            });
        });

        // Add pips
        $('.ui-slider-vertical-pips > span').slider('pips');


        //
        // Sortable
        //

        // $('.sortable').sortable({
        //     connectWith: '.sortable',
        //     items: '.sidebar-section',
        //     helper: 'original',
        //     cursor: 'move',
        //     handle: '[data-action=move]',
        //     revert: 100,
        //     containment: '.sidebar-secondary',
        //     forceHelperSize: true,
        //     placeholder: 'sortable-placeholder',
        //     forcePlaceholderSize: true,
        //     tolerance: 'pointer',
        //     start: function(e, ui){
        //         ui.placeholder.height(ui.item.outerHeight());
        //     }
        // });
    };

    // Dragula examples
    var _componentDragula = function() {
        if (typeof dragula == 'undefined') {
            console.warn('Warning - dragula.min.js is not loaded.');
            return;
        }

        // Define containers
        const containers = Array.from(document.querySelectorAll('.tab-pane'));

        // Init dragula
        dragula(containers, {
            mirrorContainer: document.querySelector('.tab-pane'),
            moves: function (el, container, handle) {
                return handle.classList.contains('sidebar-section-sortable-handle');
            }
        });
    };

    // Block UI example
    var _componentReload = function() {

        // Elements
        const buttonClass = 'sidebar-section-update',
              containerClass = 'sidebar-section',
              overlayClass = 'card-overlay',
              spinnerClass = 'icon-spinner9',
              overlayAnimationClass = 'card-overlay-fadeout';

        // Configure
        document.querySelectorAll(`.${buttonClass}`).forEach(function(button) {
            button.addEventListener('click', function(e) {
                e.preventDefault();

                // Elements
                const parentContainer = button.closest(`.${containerClass}`),
                      overlayElement = document.createElement('div'),
                      overlayElementIcon = document.createElement('i');

                // Append overlay with icon
                overlayElement.classList.add(overlayClass);
                parentContainer.appendChild(overlayElement);
                overlayElementIcon.classList.add(spinnerClass, 'spinner');
                overlayElement.appendChild(overlayElementIcon);

                // Remove overlay after 2.5s, for demo only
                setTimeout(function() {
                    overlayElement.classList.add(overlayAnimationClass);
                    ['animationend', 'animationcancel'].forEach(function(e) {
                        overlayElement.addEventListener(e, function() {
                            overlayElement.remove();
                        });
                    });
                }, 2500);
            });
        });
    };

    // Dual listbox
    var _componentDualListbox = function() {
        if (!$().bootstrapDualListbox) {
            console.warn('Warning - duallistbox.min.js is not loaded.');
            return;
        }

        // Initialize
        $('.form-control-listbox').bootstrapDualListbox({
            preserveSelectionOnMove: 'moved',
            moveOnSelect: false
        });
    };

    // Fancytree
    var _componentFancytree = function() {
        if (!$().fancytree) {
            console.warn('Warning - fancytree_all.min.js is not loaded.');
            return;
        }

        // Initialize
        $('.tree-default').fancytree();
    };

    // Lightbox
    var _componentLightbox = function() {
        if (typeof GLightbox == 'undefined') {
            console.warn('Warning - glightbox.min.js is not loaded.');
            return;
        }

        // Image lightbox
        const lightbox = GLightbox({
            selector: '[data-popup="lightbox"]',
            loop: true,
            svg: {
                next: document.dir == "rtl" ? '<svg version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 477.175 477.175" xml:space="preserve"><g><path d="M145.188,238.575l215.5-215.5c5.3-5.3,5.3-13.8,0-19.1s-13.8-5.3-19.1,0l-225.1,225.1c-5.3,5.3-5.3,13.8,0,19.1l225.1,225c2.6,2.6,6.1,4,9.5,4s6.9-1.3,9.5-4c5.3-5.3,5.3-13.8,0-19.1L145.188,238.575z"/></g></svg>' : '<svg version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 477.175 477.175" xml:space="preserve"> <g><path d="M360.731,229.075l-225.1-225.1c-5.3-5.3-13.8-5.3-19.1,0s-5.3,13.8,0,19.1l215.5,215.5l-215.5,215.5c-5.3,5.3-5.3,13.8,0,19.1c2.6,2.6,6.1,4,9.5,4c3.4,0,6.9-1.3,9.5-4l225.1-225.1C365.931,242.875,365.931,234.275,360.731,229.075z"/></g></svg>',
                prev: document.dir == "rtl" ? '<svg version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 477.175 477.175" xml:space="preserve"><g><path d="M360.731,229.075l-225.1-225.1c-5.3-5.3-13.8-5.3-19.1,0s-5.3,13.8,0,19.1l215.5,215.5l-215.5,215.5c-5.3,5.3-5.3,13.8,0,19.1c2.6,2.6,6.1,4,9.5,4c3.4,0,6.9-1.3,9.5-4l225.1-225.1C365.931,242.875,365.931,234.275,360.731,229.075z"/></g></svg>' : '<svg version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 477.175 477.175" xml:space="preserve"><g><path d="M145.188,238.575l215.5-215.5c5.3-5.3,5.3-13.8,0-19.1s-13.8-5.3-19.1,0l-225.1,225.1c-5.3,5.3-5.3,13.8,0,19.1l225.1,225c2.6,2.6,6.1,4,9.5,4s6.9-1.3,9.5-4c5.3-5.3,5.3-13.8,0-19.1L145.188,238.575z"/></g></svg>'
            }
        });
    };


    //
    // Return objects assigned to module
    //

    return {
        initComponents: function() {
            _componentSelect2();
            _componentMultiselect();
            _componentColorPicker();
            _componentDaterange();
            _componentsJqueryUI();
            _componentDragula();
            _componentReload();
            _componentDualListbox();
            _componentFancytree();
            _componentLightbox();
        }
    }
}();


// Initialize module
// ------------------------------

document.addEventListener('DOMContentLoaded', function() {
    SidebarComponents.initComponents();
});
