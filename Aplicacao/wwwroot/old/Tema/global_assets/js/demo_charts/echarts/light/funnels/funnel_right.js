/* ------------------------------------------------------------------------------
 *
 *  # Echarts - Right aligned funnel example
 *
 *  Demo JS code for right aligned funnel chart [light theme]
 *
 * ---------------------------------------------------------------------------- */


// Setup module
// ------------------------------

var EchartsFunnelRightLight = function() {


    //
    // Setup module components
    //

    // Right aligned funnel chart
    var _funnelRightLightExample = function() {
        if (typeof echarts == 'undefined') {
            console.warn('Warning - echarts.min.js is not loaded.');
            return;
        }

        // Define element
        var funnel_right_element = document.getElementById('funnel_right');


        //
        // Charts configuration
        //

        if (funnel_right_element) {

            // Initialize chart
            var funnel_right = echarts.init(funnel_right_element);


            //
            // Chart config
            //

            // Options
            funnel_right.setOption({

                // Colors
                color: [
                    '#2ec7c9','#b6a2de','#5ab1ef','#ffb980','#d87a80',
                    '#8d98b3','#e5cf0d','#97b552','#95706d','#dc69aa',
                    '#07a2a4','#9a7fd1','#588dd5','#f5994e','#c05050',
                    '#59678c','#c9ab00','#7eb00a','#6f5553','#c14089'
                ],

                // Global text styles
                textStyle: {
                    fontFamily: 'Roboto, Arial, Verdana, sans-serif',
                    fontSize: 13
                },

                // Add title
                title: {
                    text: 'Browser popularity',
                    subtext: 'Open source information',
                    left: 'center',
                    textStyle: {
                        fontSize: 17,
                        fontWeight: 500
                    },
                    subtextStyle: {
                        fontSize: 12
                    }
                },

                // Add tooltip
                tooltip: {
                    trigger: 'item',
                    backgroundColor: 'rgba(0,0,0,0.75)',
                    padding: [10, 15],
                    textStyle: {
                        fontSize: 13,
                        fontFamily: 'Roboto, sans-serif'
                    },
                    formatter: '{a} <br/>{b}: {c}%'
                },

                // Add legend
                legend: {
                    orient: 'vertical',
                    top: 'center',
                    right: 0,
                    data: ['IE','Opera','Safari','Firefox','Chrome'],
                    itemHeight: 8,
                    itemWidth: 8
                },

                // Add series
                series: [
                    {
                        name: 'Statistics',
                        type: 'funnel',
                        left: '25%',
                        right: '25%',
                        top: '16%',
                        height: '84%',
                        funnelAlign: 'right',
                        itemStyle: {
                            normal: {
                                borderColor: '#fff',
                                borderWidth: 1,
                                label: {
                                    position: 'left'
                                }
                            }
                        },
                        data: [
                            {value: 60, name: 'Safari'},
                            {value: 40, name: 'Firefox'},
                            {value: 20, name: 'Chrome'},
                            {value: 80, name: 'Opera'},
                            {value: 100, name: 'IE'}
                        ]
                    }
                ]
            });
        }


        //
        // Resize charts
        //

        // Resize function
        var triggerChartResize = function() {
            funnel_right_element && funnel_right.resize();
        };

        // On sidebar width change
        var sidebarToggle = document.querySelectorAll('.sidebar-control');
        if (sidebarToggle) {
            sidebarToggle.forEach(function(togglers) {
                togglers.addEventListener('click', triggerChartResize);
            });
        }

        // On window resize
        var resizeCharts;
        window.addEventListener('resize', function() {
            clearTimeout(resizeCharts);
            resizeCharts = setTimeout(function () {
                triggerChartResize();
            }, 200);
        });
    };


    //
    // Return objects assigned to module
    //

    return {
        init: function() {
            _funnelRightLightExample();
        }
    }
}();


// Initialize module
// ------------------------------

document.addEventListener('DOMContentLoaded', function() {
    EchartsFunnelRightLight.init();
});
