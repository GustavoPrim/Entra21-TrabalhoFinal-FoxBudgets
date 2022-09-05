/* ------------------------------------------------------------------------------
 *
 *  # Echarts - sortable progress bars example
 *
 *  Demo JS code for sortable progress bar chart [light theme]
 *
 * ---------------------------------------------------------------------------- */


// Setup module
// ------------------------------

var EchartsProgressBarSortedLight = function() {


    //
    // Setup module components
    //

    // Basic bar chart
    var _progressBarSortedExample = function() {
        if (typeof echarts == 'undefined') {
            console.warn('Warning - echarts.min.js is not loaded.');
            return;
        }

        // Define element
        var progress_bar_sorted_element = document.getElementById('progress_bar_sorted');

        // Chart configuration
        if (progress_bar_sorted_element) {

            // Initialize chart
            var progress_bar_sorted = echarts.init(progress_bar_sorted_element);

            //
            // Chart config
            //

            // Data
            var data = [
                {name: 'France', visitors: 200, sales: 12, value: 967},
                {name: 'Netherlands', visitors: 124, sales: 50, value: 856},
                {name: 'Germany', visitors: 84, sales: 35, value: 2558},
                {name: 'Hungary', visitors: 73, sales: 20, value: 412},
                {name: 'Portugal', visitors: 185, sales: 86, value: 2890},
                {name: 'Spain', visitors: 112, sales: 46, value: 1238},
                {name: 'Denmark', visitors: 45, sales: 24, value: 905},
                {name: 'Austria', visitors: 185, sales: 54, value: 1580},
                {name: 'Norway', visitors: 145, sales: 25, value: 785},
                {name: 'Slovenia', visitors: 29, sales: 2, value: 2478}
            ];

            // Sort data
            data = data.sort(function(a, b) {
                return b.value - a.value
            });

            // Main vars
            var nameData = [],
                valueData = [],
                len = data.length,
                foregroundColor = '#268bd2',
                backgroundColor = 'rgba(255,255,255,0.1)',
                barWidth = 5;

            // Bars foreground
            for (var i = 0; i < len; i++) {
                nameData.push(data[i].name);
                valueData.push({
                    name: data[i].name,
                    visitors: data[i].visitors,
                    sales: data[i].sales,
                    value: data[i].value
                });
            }

            // Options
            progress_bar_sorted.setOption({

                // Global text styles
                textStyle: {
                    fontFamily: 'Roboto, Arial, Verdana, sans-serif',
                    fontSize: 14
                },

                // Chart grid
                grid: {
                    top: 0,
                    bottom: -20,
                    right: 0,
                    left: 0,
                    containLabel: true
                },

                // Tooltip
                tooltip: {
                    show: true,
                    trigger: 'item',
                    backgroundColor: '#fff',
                    padding: [10, 15],
                    textStyle: {
                        color: '#222',
                        fontSize: 14,
                        fontFamily: 'Roboto, sans-serif'
                    },
                    formatter: function (params, i) {
                        return 'Visitors: ' + params.data.visitors + '<br>Sales: ' + params.data.sales + '<br>Conversion rate：' + (params.data.visitors / params.data.sales).toFixed(2) + '%';
                    }
                },

                // Horizontal axis
                xAxis: {
                    show: false
                },

                // Vertical axis
                yAxis: [
                    {
                        show: true,
                        inverse: true,
                        data: nameData,
                        axisLine: {
                            show: false
                        },
                        splitLine: {
                            show: false
                        },
                        axisTick: {
                            show: false
                        },
                        axisLabel: {
                            margin: 20,
                            fontSize: 14,
                            color: '#fff'
                        }
                    },
                    {
                        show: true,
                        inverse: true,
                        data: nameData,
                        axisLine: {
                            show: false
                        },
                        splitLine: {
                            show: false
                        },
                        axisTick: {
                            show: false
                        },
                        axisLabel: {
                            align: 'left',
                            margin: 20,
                            fontSize: 14,
                            fontWeight: 500,
                            color: '#fff',
                            formatter: function (value, index) {
                                return '€' + data[index].value.toLocaleString();
                            }
                        }
                    }
                ],

                // Chart series
                series: [
                    {
                        name: 'Foreground',
                        type: 'bar',
                        data: valueData,
                        barWidth: barWidth,
                        itemStyle: {
                            color: foregroundColor,
                            barBorderRadius: 30
                        },
                        z: 10,
                        showBackground: true,
                        backgroundStyle: {
                            barBorderRadius: 30,
                            color: backgroundColor
                        }
                    }
                ]
            });
        }


        //
        // Resize charts
        //

        // Resize function
        var triggerChartResize = function() {
            progress_bar_sorted_element && progress_bar_sorted.resize();
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
            _progressBarSortedExample();
        }
    }
}();


// Initialize module
// ------------------------------

document.addEventListener('DOMContentLoaded', function() {
    EchartsProgressBarSortedLight.init();
});
