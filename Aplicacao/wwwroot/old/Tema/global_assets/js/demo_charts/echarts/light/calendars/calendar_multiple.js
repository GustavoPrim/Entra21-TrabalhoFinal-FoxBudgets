/* ------------------------------------------------------------------------------
 *
 *  # Echarts - Multiple calendar example
 *
 *  Demo JS code for multiple calendar chart [light theme]
 *
 * ---------------------------------------------------------------------------- */


// Setup module
// ------------------------------

var EchartsCalendarMultipleLight = function() {


    //
    // Setup module components
    //

    // Multiple calendar chart
    var _calendarMultipleLightExample = function() {
        if (typeof echarts == 'undefined') {
            console.warn('Warning - echarts.min.js is not loaded.');
            return;
        }

        // Define element
        var calendar_multiple_element = document.getElementById('calendar_multiple');


        //
        // Charts configuration
        //

        if (calendar_multiple_element) {

            // Initialize chart
            var calendar_multiple = echarts.init(calendar_multiple_element);


            //
            // Chart config
            //

            // Demo data
            function getVirtulData(year) {
                year = year || '2017';
                var date = +echarts.number.parseDate(year + '-01-01');
                var end = +echarts.number.parseDate((+year + 1) + '-01-01');
                var dayTime = 3600 * 24 * 1000;
                var data = [];
                for (var time = date; time < end; time += dayTime) {
                    data.push([
                        echarts.format.formatTime('yyyy-MM-dd', time),
                        Math.floor(Math.random() * 10000)
                    ]);
                }
                return data;
            }

            // Options
            calendar_multiple.setOption({

                // Add title
                title: {
                    text: 'Github commits',
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
                    }
                },

                // Add legend
                legend: {
                    orient: 'vertical',
                    top: 'center',
                    left: 0,
                    data: ['IE', 'Opera', 'Safari', 'Firefox', 'Chrome'],
                    itemHeight: 8,
                    itemWidth: 8
                },

                // Visual map
                visualMap: {
                    min: 0,
                    max: 10000,
                    calculable: true,
                    orient: 'horizontal',
                    left: 'center',
                    text: ['High', 'Low'],
                    textGap: 20,
                    itemHeight: 280,
                    color: ['#4CAF50', '#E8F5E9'],
                    bottom: 0,
                    textStyle: {
                        fontSize: 12
                    }
                },

                // Calendar
                calendar: [
                    {
                        range: ['2011-01-01', '2011-12-31'],
                        cellSize: ['auto', 22],
                        top: 80,
                        left: 70,
                        right: 5,
                        itemStyle: {
                            normal: {
                                borderWidth: 1,
                                borderColor: '#fff'
                            }
                        },
                        splitLine: {
                            lineStyle: {
                                color: '#333',
                                width: 2
                            }
                        },
                        yearLabel: {
                            margin: 50,
                            fontWeight: 500
                        }
                    },
                    {
                        top: 290,
                        range: '2012',
                        cellSize: ['auto', 22],
                        left: 70,
                        right: 5,
                        itemStyle: {
                            normal: {
                                borderWidth: 1,
                                borderColor: '#fff'
                            }
                        },
                        splitLine: {
                            lineStyle: {
                                color: '#333',
                                width: 2
                            }
                        },
                        yearLabel: {
                            margin: 50,
                            fontWeight: 500
                        }
                    },
                    {
                        top: 500,
                        range: '2013',
                        cellSize: ['auto', 22],
                        left: 70,
                        right: 5,
                        itemStyle: {
                            normal: {
                                borderWidth: 1,
                                borderColor: '#fff'
                            }
                        },
                        splitLine: {
                            lineStyle: {
                                color: '#333',
                                width: 2
                            }
                        },
                        yearLabel: {
                            margin: 50,
                            fontWeight: 500
                        }
                    }
                ],

                // Add series
                series: [{
                    type: 'heatmap',
                    coordinateSystem: 'calendar',
                    calendarIndex: 0,
                    data: getVirtulData(2011)
                }, {
                    type: 'heatmap',
                    coordinateSystem: 'calendar',
                    calendarIndex: 1,
                    data: getVirtulData(2012)
                }, {
                    type: 'heatmap',
                    coordinateSystem: 'calendar',
                    calendarIndex: 2,
                    data: getVirtulData(2013)
                }]
            });
        }


        //
        // Resize charts
        //

        // Resize function
        var triggerChartResize = function() {
            calendar_multiple_element && calendar_multiple.resize();
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
            _calendarMultipleLightExample();
        }
    }
}();


// Initialize module
// ------------------------------

document.addEventListener('DOMContentLoaded', function() {
    EchartsCalendarMultipleLight.init();
});
