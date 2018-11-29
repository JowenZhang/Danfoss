$(function () {
    //初始化时间
    initialTime();
    //开始按钮单击事件
    $('#BtnAnalysisData').click(function () {
        //显示图表
        showChart();
    });
});

//初始化时间
function initialTime() {
    var time = new Date();
    var dateStart = (time.getMonth()) + '/' + time.getDate() + '/' + time.getFullYear() + ' ' + time.getHours() + ':' + time.getMinutes() + ':' + time.getSeconds();
    var dateEnd = (time.getMonth() + 1) + '/' + time.getDate() + '/' + time.getFullYear() + ' ' + time.getHours() + ':' + time.getMinutes() + ':' + time.getSeconds();
    $('#TimStartTime').datetimebox('setValue', dateStart);
    $('#TimEndTime').datetimebox('setValue', dateEnd);
}

//显示图表
function showChart() {
    var startTime = $('#TimStartTime').datetimebox('getValue');
    var endTime = $('#TimEndTime').datetimebox('getValue');
    $.getJSON('/BackgroundProgram/IRAnalysis.ashx', { startTime: startTime, endTime: endTime }, function (data) {
        console.log(data);
        if (data === null) {
            return;
        }
        if (data === '') {
            return;
        }
        var myBarChart = echarts.init(document.getElementById('BarChart'));
        option = {
            title: {
                text: data.dailyIrTitle
            },
            tooltip: {
                trigger: 'axis'
            },
            toolbox: {
                show: true,
                feature: {
                    dataZoom: {
                        yAxisIndex: 'none'
                    },
                    dataView: { readOnly: false },
                    magicType: { type: ['line', 'bar'] },
                    restore: {},
                    saveAsImage: {}
                }
            },
            xAxis: {
                name:data.dailyIrxAxisName,
                type: 'category',
                boundaryGap: false,
                data: data.dailyxAxisValue
            },
            yAxis: {
                name: data.dailyIryAxisName,
                type: 'value',
                //max: data.yAxisMax,
                //min: data.yAxisMin,
                splitLine: {
                    show: false
                }
            },
            series: [
                {
                    name: data.dailyIrTitle,
                    type: 'bar',
                    data: data.dailyyAxisValue,
                    markPoint: {
                        data: [
                            { type: 'max', name: '最大值' },
                            { type: 'min', name: '最小值' }
                        ]
                    }
                }
            ]
        };
        myBarChart.setOption(option);
        var barLineChart = echarts.init(document.getElementById('BarLineChart'));
        option2 = {
            title: [{
                text: data.eqmIrTitle,
            }, {
                text: data.eqmIrBottomTitle,
                left: 'left',//'18%',
                bottom: '2%',
                textStyle: {
                    color: 'black',
                    fontStyle: 'normal',
                    fontWeight: '300',
                    fontFamily: 'Microsoft YaHei',
                    fontSize: 12
                }
            }],
            tooltip: {
                trigger: 'axis'
            },
            toolbox: {
                show: true,
                feature: {
                    mark: { show: true },
                    dataView: { show: true, readOnly: false },
                    magicType: { show: true, type: ['line', 'bar'] },
                    restore: { show: true },
                    saveAsImage: { show: true }
                }
            },
            calculable: false,
            xAxis: [
                {
                    name:data.eqmIrxAxisName,
                    type: 'category',
                    data: data.eqmxAxisValue,
                    axisLabel: {
                        interval: 0,
                        rotate: -20,                       
                    }
                }],
                grid: {
            left: '10%',
            bottom:'25%'
                },
            
            yAxis: [
                {
                    type: 'value',
                    name: data.eqmIryAxisSingleName,
                    axisLabel: {
                        formatter: '{value}'
                    },
                    splitLine: {
                        show: false
                    }
                },
                {
                    type: 'value',
                    name: data.eqmIryAxisGainName,
                    axisLabel: {
                        formatter: '{value}'
                    },
                    splitLine: {
                        show: false
                    }
                }
            ],
            series: [
                {
                    name: data.eqmIryAxisSingleName,
                    type: 'bar',
                    //barCategoryGap: '0',
                    data: data.eqmyAxisSingleValue
                },
                {
                    name: data.eqmIryAxisGainName,
                    type: 'line',
                    smooth: true,
                    yAxisIndex: 1,
                    data: data.eqmyAxisGainValue
                }
            ]
        };
        barLineChart.setOption(option2);
    });

}