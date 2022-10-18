/* ------------------------------------------------------------------------------
 *
 *  # Progress bars & loaders
 *
 *  Demo JS code for components_progress.html page
 *
 * ---------------------------------------------------------------------------- */


// Setup module
// ------------------------------

var Progress = function() {


    //
    // Setup module components
    //

    // Enhanced progress bars
    var _componentProgress = function() {
        if (!$().progressbar) {
            console.warn('Warning - progressbar.min.js is not loaded.');
            return;
        }


        // Basic progress bar
        // ------------------------------

        // Start
        $('#h-default-basic-start').on('click', function() {
            var $pb = $('#h-default-basic .progress-bar');
            $pb.attr('data-transitiongoal', $pb.attr('data-transitiongoal-backup'));
            $pb.progressbar();
        });

        // Reset
        $('#h-default-basic-reset').on('click', function() {
            $('#h-default-basic .progress-bar').attr('data-transitiongoal', 0).progressbar();
        });


        // Progress bar in right direction
        // ------------------------------

        // Start
        $('#h-right-basic-start').on('click', function() {
            var $pb = $('#h-right-basic .progress-bar');
            $pb.attr('data-transitiongoal', $pb.attr('data-transitiongoal-backup'));
            $pb.progressbar();
        });

        // Reset
        $('#h-right-basic-reset').on('click', function() {
            $('#h-right-basic .progress-bar').attr('data-transitiongoal', 0).progressbar();
        });


        // Progress bar with text fill
        // ------------------------------

        // Start
        $('#h-fill-basic-start').on('click', function() {
            var $pb = $('#h-fill-basic .progress-bar');
            $pb.attr('data-transitiongoal', $pb.attr('data-transitiongoal-backup'));
            $pb.progressbar({display_text: 'fill'});
        });

        // Reset
        $('#h-fill-basic-reset').on('click', function() {
            $('#h-fill-basic .progress-bar').attr('data-transitiongoal', 0).progressbar({display_text: 'fill'});
        });


        // Start
        $('#h-fill-basic-right-start').on('click', function() {
            var $pb = $('#h-fill-basic-right .progress-bar');
            $pb.attr('data-transitiongoal', $pb.attr('data-transitiongoal-backup'));
            $pb.progressbar({display_text: 'fill'});
        });

        // Reset
        $('#h-fill-basic-right-reset').on('click', function() {
            $('#h-fill-basic-right .progress-bar').attr('data-transitiongoal', 0).progressbar({display_text: 'fill'});
        });


        // Progress bar with non-percentage text
        // ------------------------------

        // Start
        $('#h-fill-nonpercentage-basic-start').on('click', function() {
            var $pb = $('#h-fill-nonpercentage-basic .progress-bar');
            $pb.attr('data-transitiongoal', $pb.attr('data-transitiongoal-backup'));
            $pb.progressbar({display_text: 'fill', use_percentage: false});
        });

        // Reset
        $('#h-fill-nonpercentage-basic-reset').on('click', function() {
            $('#h-fill-nonpercentage-basic .progress-bar').attr('data-transitiongoal', 0).progressbar({display_text: 'fill', use_percentage: false});
        });


        // Start
        $('#h-fill-nonpercentage-right-basic-start').on('click', function() {
            var $pb = $('#h-fill-nonpercentage-right-basic .progress-bar');
            $pb.attr('data-transitiongoal', $pb.attr('data-transitiongoal-backup'));
            $pb.progressbar({display_text: 'fill', use_percentage: false});
        });

        // Reset
        $('#h-fill-nonpercentage-right-basic-reset').on('click', function() {
            $('#h-fill-nonpercentage-right-basic .progress-bar').attr('data-transitiongoal', 0).progressbar({display_text: 'fill', use_percentage: false});
        });
            


        // Vertical progress bar
        // ------------------------------

        // Start
        $('#v-default-basic-start').on('click', function() {
            $('#v-default-basic .progress-bar').each(function () {
                var $pb = $(this);
                $pb.attr('data-transitiongoal', $pb.attr('data-transitiongoal-backup'));
                $pb.progressbar();
            });
        });

        // Reset
        $('#v-default-basic-reset').on('click', function() {
            $('#v-default-basic .progress-bar').attr('data-transitiongoal', 0).progressbar();
        });


        // Bottom direction
        // ------------------------------

        // Start
        $('#v-bottom-basic-start').on('click', function() {
            $('#v-bottom-basic .progress-bar').each(function () {
                var $pb = $(this);
                $pb.attr('data-transitiongoal', $pb.attr('data-transitiongoal-backup'));
                $pb.progressbar();
            });
        });

        // Reset
        $('#v-bottom-basic-reset').on('click', function() {
            $('#v-bottom-basic .progress-bar').attr('data-transitiongoal', 0).progressbar();
        });


        // Vertical progress bar with text fill
        // ------------------------------

        // Start
        $('#v-fill-basic-start').on('click', function() {
            $('#v-fill-basic .progress-bar').each(function () {
                var $pb = $(this);
                $pb.attr('data-transitiongoal', $pb.attr('data-transitiongoal-backup'));
                $pb.progressbar({display_text: 'fill'});
            });
        });

        // Reset
        $('#v-fill-basic-reset').on('click', function() {
            $('#v-fill-basic .progress-bar').attr('data-transitiongoal', 0).progressbar();
        });

        // Start
        $('#v-fill-bottom-start').on('click', function() {
            $('#v-fill-bottom .progress-bar').each(function () {
                var $pb = $(this);
                $pb.attr('data-transitiongoal', $pb.attr('data-transitiongoal-backup'));
                $pb.progressbar({display_text: 'fill'});
            });
        });

        // Reset
        $('#v-fill-bottom-reset').on('click', function() {
            $('#v-fill-bottom .progress-bar').attr('data-transitiongoal', 0).progressbar();
        });


        // Vertical progress bar with non-percentage text
        // ------------------------------

        // Start
        $('#v-fill-nonpercentage-basic-start').on('click', function() {
            $('#v-fill-nonpercentage-basic .progress-bar').each(function () {
                var $pb = $(this);
                $pb.attr('data-transitiongoal', $pb.attr('data-transitiongoal-backup'));
                $pb.progressbar({display_text: 'fill', use_percentage: false});
            });
        });

        // Reset
        $('#v-fill-nonpercentage-basic-reset').on('click', function() {
            $('#v-fill-nonpercentage-basic .progress-bar').attr('data-transitiongoal', 0).progressbar();
        });

        // Start
        $('#v-fill-nonpercentage-bottom-start').on('click', function() {
            $('#v-fill-nonpercentage-bottom .progress-bar').each(function () {
                var $pb = $(this);
                $pb.attr('data-transitiongoal', $pb.attr('data-transitiongoal-backup'));
                $pb.progressbar({display_text: 'fill', use_percentage: false});
            });
        });

        // Reset
        $('#v-fill-nonpercentage-bottom-reset').on('click', function() {
            $('#v-fill-nonpercentage-bottom .progress-bar').attr('data-transitiongoal', 0).progressbar();
        });
    };

    // Spinner with overlay
    var _componentOverlay = function() {

        // Elements
        // Change button.getAttribute('data-icon') to your desired icon here. Current
        // config is for demo. Or use this code if you wish
        const buttonClass = 'btn-launch-spinner',
              containerClass = 'card',
              overlayClass = 'card-overlay',
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
                overlayElementIcon.classList.add(button.getAttribute('data-icon'), 'spinner');
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


    //
    // Return objects assigned to module
    //

    return {
        init: function() {
            _componentProgress();
            _componentOverlay();
        }
    }
}();


// Initialize module
// ------------------------------

document.addEventListener('DOMContentLoaded', function() {
    Progress.init();
});
