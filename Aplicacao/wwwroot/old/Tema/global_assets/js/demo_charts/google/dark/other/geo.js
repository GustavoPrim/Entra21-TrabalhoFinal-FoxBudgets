/* ------------------------------------------------------------------------------
 *
 *  # Google Visualization - geo chart
 *
 *  Google Visualization geo chart demonstration
 *
 * ---------------------------------------------------------------------------- */


// Setup module
// ------------------------------

var GoogleGeoRegion = function() {


    //
    // Setup module components
    //

    // Geo chart
    var _googleGeoRegion = function() {
        if (typeof google == 'undefined') {
            console.warn('Warning - Google Charts library is not loaded.');
            return;
        }

        // Initialize chart
        google.charts.load('current', {
            callback: function () {

                // Draw chart
                drawRegionsMap();

                // Resize on sidebar width change
                var sidebarToggle = document.querySelectorAll('.sidebar-control');
                if (sidebarToggle) {
                    sidebarToggle.forEach(function(togglers) {
                        togglers.addEventListener('click', drawRegionsMap);
                    });
                }

                // Resize on window resize
                var resizeGeoRegion;
                window.addEventListener('resize', function() {
                    clearTimeout(resizeGeoRegion);
                    resizeGeoRegion = setTimeout(function () {
                        drawRegionsMap();
                    }, 200);
                });
            },
            packages: ['geochart']
        });

        // Chart settings
        function drawRegionsMap() {

            // Define charts element
            var geo_region_element = document.getElementById('google-geo-region');

            // Data
            var data = google.visualization.arrayToDataTable([
                ['Country', 'Popularity'],
                ['Germany', 200],
                ['United States', 300],
                ['Brazil', 400],
                ['Canada', 500],
                ['France', 600],
                ['RU', 700]
            ]);

            // Options
            var options = {
                fontName: 'Roboto',
                height: 500,
                width: "100%",
                colorAxis: {
                    colors: ['#fff', '#32d439']
                },
                backgroundColor: 'transparent',
                datalessRegionColor: '#5b667d',
                fontSize: 12,
                tooltip: {
                    textStyle: {
                        fontName: 'Roboto',
                        fontSize: 13
                    }
                }
            };

            // Draw chart
            var chart = new google.visualization.GeoChart(geo_region_element);
            chart.draw(data, options);
        }
    };


    //
    // Return objects assigned to module
    //

    return {
        init: function() {
            _googleGeoRegion();
        }
    }
}();


// Initialize module
// ------------------------------

GoogleGeoRegion.init();
