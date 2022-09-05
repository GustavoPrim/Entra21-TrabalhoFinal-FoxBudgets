/* ------------------------------------------------------------------------------
 *
 *  # Sliding page panels
 *
 *  Demo JS code for content_page_panels.html page
 *
 * ---------------------------------------------------------------------------- */


// Setup module
// ------------------------------

var Panels = function () {


    //
    // Setup module components
    //

    // Load remote content
    var _contentPanelRemote = function() {

        // Load remote source
        function loadRemoteSource(url) {
            var request = new XMLHttpRequest();

            request.onload = function() {
                if (!this.status || (this.status >= 400)) {
                    throw "Request failed. HTTP code " + this.status;
                }

                var response = this.response,
                    targetContainer = document.getElementById('panel_remote').querySelector('.modal-body');

                targetContainer.innerHTML = response;
            }
            request.open('GET', url, true);
            request.send();
        }

        // Execute when show instance method is called
        $('#panel_remote').on('show.bs.modal', function() {
            loadRemoteSource('../../../../global_assets/demo_data/panels/panel_content.html');
        });
    };

    // Modal callbacks
    var _contentPanelCallbacks = function() {

        // onShow callback
        $('#panel_onshow').on('show.bs.modal', function() {
            alert('onShow callback fired.')
        });

        // onShown callback
        $('#panel_onshown').on('shown.bs.modal', function() {
            alert('onShown callback fired.')
        });

        // onHide callback
        $('#panel_onhide').on('hide.bs.modal', function() {
            alert('onHide callback fired.')
        });

        // onHidden callback
        $('#panel_onhidden').on('hidden.bs.modal', function() {
            alert('onHidden callback fired.')
        });
    };


    //
    // Return objects assigned to module
    //

    return {
        initComponents: function() {
            _contentPanelRemote();
            _contentPanelCallbacks();
        }
    }
}();


// Initialize module
// ------------------------------

document.addEventListener('DOMContentLoaded', function() {
    Panels.initComponents();
});
