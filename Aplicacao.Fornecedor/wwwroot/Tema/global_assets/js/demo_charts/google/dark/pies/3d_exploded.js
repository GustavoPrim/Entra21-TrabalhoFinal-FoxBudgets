/* ------------------------------------------------------------------------------
 *
 *  # Google Visualization - sliced 3D donut
 *
 *  Google Visualization sliced 3D donut chart demonstration
 *
 * ---------------------------------------------------------------------------- */


// Setup module
// ------------------------------

var GoogleDonut3dExploded = function() {


    //
    // Setup module components
    //

    // 3D donut chart
    var _googleDonut3dExploded = function() {
        if (typeof google == 'undefined') {
            console.warn('Warning - Google Charts library is not loaded.');
            return;
        }

        // Initialize chart
        google.charts.load('current', {
            callback: function () {

                // Draw chart
                drawDonut3dExploded();

                // Resize on sidebar width change
                var sidebarToggle = document.querySelectorAll('.sidebar-control');
                if (sidebarToggle) {
                    sidebarToggle.forEach(function(togglers) {
                        togglers.addEventListener('click', drawDonut3dExploded);
                    });
                }

                // Resize on window resize
                var resizeDonut3dExploded;
                window.addEventListener('resize', function() {
                    clearTimeout(resizeDonut3dExploded);
                    resizeDonut3dExploded = setTimeout(function () {
                        drawDonut3dExploded();
                    }, 200);
                });
            },
            packages: ['corechart']
        });

        // Chart settings
        function drawDonut3dExploded() {

            // Define charts element
            var donut_3d_exploded_element = document.getElementById('google-3d-exploded');

            // Data
            var data = google.visualization.arrayToDataTable([
                ['Language', 'Speakers (in millions)'],
                ['Assamese', 13],
                ['Bengali', 83],
                ['Gujarati', 46],
                ['Hindi', 90],
                ['Kannada', 38],
                ['Maithili', 20],
                ['Malayalam', 33],
                ['Marathi', 72],
                ['Oriya', 33],
                ['Punjabi', 29],
                ['Tamil', 61],
                ['Telugu', 74],
                ['Urdu', 52]
            ]);

            // Options
            var options = {
                fontName: 'Roboto',
                height: 300,
                width: 540,
                backgroundColor: 'transparent',
                colors: [
                    '#2ec7c9','#b6a2de','#5ab1ef','#ffb980','#d87a80',
                    '#8d98b3','#e5cf0d','#97b552','#95706d','#dc69aa',
                    '#07a2a4','#9a7fd1','#588dd5','#f5994e','#c05050',
                    '#59678c','#c9ab00','#7eb00a','#6f5553','#c14089'
                ],
                pieSliceBorderColor: '#353f53',
                chartArea: {
                    left: 50,
                    width: '95%',
                    height: '95%'
                },
                is3D: true,
                pieSliceText: 'label',
                slices: {  
                    2: {offset: 0.15},
                    8: {offset: 0.1},
                    10: {offset: 0.15},
                    11: {offset: 0.1}
                },
                legend: {
                    textStyle: {
                        color: '#fff'
                    }
                }
            };

            // Instantiate and draw our chart, passing in some options.
            var pie_3d_exploded = new google.visualization.PieChart(donut_3d_exploded_element);
            pie_3d_exploded.draw(data, options);
        }
    };


    //
    // Return objects assigned to module
    //

    return {
        init: function() {
            _googleDonut3dExploded();
        }
    }
}();


// Initialize module
// ------------------------------

GoogleDonut3dExploded.init();
