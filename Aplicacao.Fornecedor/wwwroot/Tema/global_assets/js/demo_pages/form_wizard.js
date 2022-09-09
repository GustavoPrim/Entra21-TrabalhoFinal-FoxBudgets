/* ------------------------------------------------------------------------------
 *
 *  # Steps wizard
 *
 *  Demo JS code for form_wizard.html page
 *
 * ---------------------------------------------------------------------------- */


// Setup module
// ------------------------------

var FormWizard = function() {


    //
    // Setup module components
    //

    // Wizard
    var _componentWizard = function() {
        if (!$().steps) {
            console.warn('Warning - steps.min.js is not loaded.');
            return;
        }

        // Basic wizard setup
        $('.steps-basic').steps({
            headerTag: 'h6',
            bodyTag: 'fieldset',
            transitionEffect: 'fade',
            titleTemplate: '<span class="number">#index#</span> #title#',
            labels: {
                previous: $('html').attr('dir') == 'rtl' ? '<i class="icon-arrow-right8 mr-2"></i> Previous' : '<i class="icon-arrow-left8 mr-2"></i> Previous',
                next: $('html').attr('dir') == 'rtl' ? 'Next <i class="icon-arrow-left8 ml-2"></i>' : 'Next <i class="icon-arrow-right8 ml-2"></i>',
                finish: 'Submit form <i class="icon-paperplane ml-2"></i>'
            },
            onFinished: function (event, currentIndex) {
                alert('Form submitted.');
            }
        });

        // Async content loading
        $('.steps-async').steps({
            headerTag: 'h6',
            bodyTag: 'fieldset',
            transitionEffect: 'fade',
            titleTemplate: '<span class="number">#index#</span> #title#',
            loadingTemplate: '<div class="card-body text-center"><i class="icon-spinner2 spinner mr-2"></i>  #text#</div>',
            labels: {
                previous: $('html').attr('dir') == 'rtl' ? '<i class="icon-arrow-right8 mr-2"></i> Previous' : '<i class="icon-arrow-left8 mr-2"></i> Previous',
                next: $('html').attr('dir') == 'rtl' ? 'Next <i class="icon-arrow-left8 ml-2"></i>' : 'Next <i class="icon-arrow-right8 ml-2"></i>',
                finish: 'Submit form <i class="icon-paperplane ml-2"></i>'
            },
            onContentLoaded: function (event, currentIndex) {
                $(this).find('.card-body').addClass('hide');
            },
            onFinished: function (event, currentIndex) {
                alert('Form submitted.');
            }
        });

        // Saving wizard state
        $('.steps-state-saving').steps({
            headerTag: 'h6',
            bodyTag: 'fieldset',
            titleTemplate: '<span class="number">#index#</span> #title#',
            labels: {
                previous: $('html').attr('dir') == 'rtl' ? '<i class="icon-arrow-right8 mr-2"></i> Previous' : '<i class="icon-arrow-left8 mr-2"></i> Previous',
                next: $('html').attr('dir') == 'rtl' ? 'Next <i class="icon-arrow-left8 ml-2"></i>' : 'Next <i class="icon-arrow-right8 ml-2"></i>',
                finish: 'Submit form <i class="icon-paperplane ml-2"></i>'
            },
            transitionEffect: 'fade',
            saveState: true,
            autoFocus: true,
            onFinished: function (event, currentIndex) {
                alert('Form submitted.');
            }
        });

        // Specify custom starting step
        $('.steps-starting-step').steps({
            headerTag: 'h6',
            bodyTag: 'fieldset',
            titleTemplate: '<span class="number">#index#</span> #title#',
            labels: {
                previous: $('html').attr('dir') == 'rtl' ? '<i class="icon-arrow-right8 mr-2"></i> Previous' : '<i class="icon-arrow-left8 mr-2"></i> Previous',
                next: $('html').attr('dir') == 'rtl' ? 'Next <i class="icon-arrow-left8 ml-2"></i>' : 'Next <i class="icon-arrow-right8 ml-2"></i>',
                finish: 'Submit form <i class="icon-paperplane ml-2"></i>'
            },
            transitionEffect: 'fade',
            startIndex: 2,
            autoFocus: true,
            onFinished: function (event, currentIndex) {
                alert('Form submitted.');
            }
        });

        // Enable all steps and make them clickable
        $('.steps-enable-all').steps({
            headerTag: 'h6',
            bodyTag: 'fieldset',
            transitionEffect: 'fade',
            enableAllSteps: true,
            titleTemplate: '<span class="number">#index#</span> #title#',
            labels: {
                previous: $('html').attr('dir') == 'rtl' ? '<i class="icon-arrow-right8 mr-2"></i> Previous' : '<i class="icon-arrow-left8 mr-2"></i> Previous',
                next: $('html').attr('dir') == 'rtl' ? 'Next <i class="icon-arrow-left8 ml-2"></i>' : 'Next <i class="icon-arrow-right8 ml-2"></i>',
                finish: 'Submit form <i class="icon-paperplane ml-2"></i>'
            },
            onFinished: function (event, currentIndex) {
                alert('Form submitted.');
            }
        });


        //
        // Wizard with validation
        //

        // Stop function if validation is missing
        if (!$().validate) {
            console.warn('Warning - validate.min.js is not loaded.');
            return;
        }

        // Show form
        var form = $('.steps-validation').show();


        // Initialize wizard
        $('.steps-validation').steps({
            headerTag: 'h6',
            bodyTag: 'fieldset',
            titleTemplate: '<span class="number">#index#</span> #title#',
            labels: {
                previous: $('html').attr('dir') == 'rtl' ? '<i class="icon-arrow-right8 mr-2"></i> Previous' : '<i class="icon-arrow-left8 mr-2"></i> Previous',
                next: $('html').attr('dir') == 'rtl' ? 'Next <i class="icon-arrow-left8 ml-2"></i>' : 'Next <i class="icon-arrow-right8 ml-2"></i>',
                finish: 'Submit form <i class="icon-paperplane ml-2"></i>'
            },
            transitionEffect: 'fade',
            autoFocus: true,
            onStepChanging: function (event, currentIndex, newIndex) {

                // Allways allow previous action even if the current form is not valid!
                if (currentIndex > newIndex) {
                    return true;
                }

                // Needed in some cases if the user went back (clean up)
                if (currentIndex < newIndex) {

                    // To remove error styles
                    form.find('.body:eq(' + newIndex + ') label.error').remove();
                    form.find('.body:eq(' + newIndex + ') .error').removeClass('error');
                }

                form.validate().settings.ignore = ':disabled,:hidden';
                return form.valid();
            },
            onFinishing: function (event, currentIndex) {
                form.validate().settings.ignore = ':disabled';
                return form.valid();
            },
            onFinished: function (event, currentIndex) {
                alert('Submitted!');
            }
        });


        // Initialize validation
        $('.steps-validation').validate({
            ignore: 'input[type=hidden], .select2-search__field', // ignore hidden fields
            errorClass: 'validation-invalid-label',
            highlight: function(element, errorClass) {
                $(element).removeClass(errorClass);
            },
            unhighlight: function(element, errorClass) {
                $(element).removeClass(errorClass);
            },

            // Different components require proper error label placement
            errorPlacement: function(error, element) {

                // Unstyled checkboxes, radios
                if (element.parents().hasClass('form-check')) {
                    error.appendTo( element.closest('.form-check').parent() );
                }

                // Input with icons and Select2
                else if (element.parents().hasClass('form-group-feedback') || element.hasClass('select2-hidden-accessible')) {
                    error.appendTo( element.parent() );
                }

                // Input group and custom controls
                else if (element.parent().is('.custom-file, .custom-control') || element.parents().hasClass('input-group')) {
                    error.appendTo( element.parent().parent() );
                }

                // Other elements
                else {
                    error.insertAfter(element);
                }
            },
            rules: {
                email: {
                    email: true
                }
            }
        });
    };


    //
    // Return objects assigned to module
    //

    return {
        init: function() {
            _componentWizard();
        }
    }
}();


// Initialize module
// ------------------------------

document.addEventListener('DOMContentLoaded', function() {
    FormWizard.init();
});
