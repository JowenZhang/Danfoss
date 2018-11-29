$(function () {
    //绑定分析项目
    bindAnalysisItem();
    //初始化时间
    initialTime();
    //开关互斥
    swcBtnRepel();
    //开始分析单击事件
    $('#BtnAnalysisData').click(function () {
        //开始分析数据
        startAnalysisData();
    })    
});

//绑定分析项目，同时绑定选定事件和赋予初始值
function bindAnalysisItem() {
    var data = [];
    data.push({ item_no: '001', item_name: '产量分析', selected: 'true' }, { item_no: '002', item_name: '不良分析' }, { item_no: '003', item_name: '停机分析' });
    $('#CmbAnalysisItem').combobox('loadData', data).combobox({
        onChange: function (newValue, oldValue) {
            bindAnalysisDestiny(newValue);
        }
    }).combobox('setValue', '001');
}

//绑定分析维度，同时绑定选定事件和赋予初始值
function bindAnalysisDestiny(value) {
    var data = [];
    if (value === '001' || value === '002') {
        data.push({ destiny_no: 'D001', destiny_name: '时间' }, { destiny_no: 'D002', destiny_name: '型号', selected: 'true' });
        $('#CmbAnalysisDestiny').combobox('loadData', data).combobox({
            onChange: function (newValue, oldValue) {
                initialSwitch(newValue);
            }
        }).combobox('setValue', 'D002');
    } else {
        data.push({ destiny_no: 'D001', destiny_name: '时间' }, { destiny_no: 'D003', destiny_name: '停机原因', selected: 'true' });
        $('#CmbAnalysisDestiny').combobox('loadData', data).combobox({
            onChange: function (newValue, oldValue) {
                initialSwitch(newValue);
            }
        }).combobox('setValue', 'D003');
    }
}

//初始化时间
function initialTime() {
    var time = new Date();
    var dateStart = (time.getMonth()) + '/' + time.getDate() + '/' + time.getFullYear() + ' ' + time.getHours() + ':' + time.getMinutes() + ':' + time.getSeconds();
    var dateEnd = (time.getMonth() + 1) + '/' + time.getDate() + '/' + time.getFullYear() + ' ' + time.getHours() + ':' + time.getMinutes() + ':' + time.getSeconds();
    $('#TimStart').datetimebox('setValue', dateStart);
    $('#TimEnd').datetimebox('setValue', dateEnd);
}

//初始化开关
function initialSwitch(value) {
    if (value === 'D001') {
        $('#SwcBtnMonth').switchbutton('enable');
        $('#SwcBtnDate').switchbutton('enable');
        $('#SwcBtnHour').switchbutton('enable');
        $('#SwcBtnMinute').switchbutton('enable');
    } else {
        $('#SwcBtnMonth').switchbutton('disable');
        $('#SwcBtnDate').switchbutton('disable');
        $('#SwcBtnHour').switchbutton('disable');
        $('#SwcBtnMinute').switchbutton('disable');
    }
}

//开关互斥
function swcBtnRepel() {
    $('#SwcBtnMonth').switchbutton({
        onChange: function (checked) {
            if (checked) {
                $('#SwcBtnDate').switchbutton('uncheck');
                $('#SwcBtnHour').switchbutton('uncheck');
                $('#SwcBtnMinute').switchbutton('uncheck');
            }
        }
    });
    $('#SwcBtnDate').switchbutton({
        onChange: function (checked) {
            if (checked) {
                $('#SwcBtnMonth').switchbutton('uncheck');
                $('#SwcBtnHour').switchbutton('uncheck');
                $('#SwcBtnMinute').switchbutton('uncheck');
            }
        }
    });
    $('#SwcBtnHour').switchbutton({
        onChange: function (checked) {
            if (checked) {
                $('#SwcBtnMonth').switchbutton('uncheck');
                $('#SwcBtnDate').switchbutton('uncheck');
                $('#SwcBtnMinute').switchbutton('uncheck');
            }
        }
    });
    $('#SwcBtnMinute').switchbutton({
        onChange: function (checked) {
            if (checked) {
                $('#SwcBtnMonth').switchbutton('uncheck');
                $('#SwcBtnHour').switchbutton('uncheck');
                $('#SwcBtnDate').switchbutton('uncheck');
            }
        }
    });
}

//初始化数据
function startAnalysisData() {
    var analysisItem = $('#CmbAnalysisItem').combobox('getValue');
    var analysisDestiny = $('#CmbAnalysisDestiny').combobox('getValue');
    var startTime = $('#TimStart').datetimebox('getValue');
    var endTime = $('#TimEnd').datetimebox('getValue');
    var needTime = $('#SwcBtnMonth').switchbutton('options').disabled;
    var timeSpacy = 'month';
    if ($('#SwcBtnMonth').switchbutton('options').checked) {
        timeSpacy = 'month';
    }
    if ($('#SwcBtnDate').switchbutton('options').checked) {
        timeSpacy = 'date';
    }
    if ($('#SwcBtnHour').switchbutton('options').checked) {
        timeSpacy = 'hour';
    }
    if ($('#SwcBtnMinute').switchbutton('options').checked) {
        timeSpacy = 'minute';
    }
    $.get("/BackgroundProgram/DataAnalysis.ashx", { analysisItem: analysisItem, analysisDestiny: analysisDestiny, startTime: startTime, endTime: endTime, needTime: needTime, timeSpacy: timeSpacy }, function (data) {
        var dataObj = JSON.parse(data);
        console.log(dataObj.data);
        $('#TblTop').datagrid({
            fitColumns: false,
            idField: 'xAxis_value',
            loadMsg: '正在获取后台信息...',
            fit: true,
            pagination: false,
            singleSelect: true,
            //pageSize: 10,
            //pageNumber: 1,
            //pageList: [10, 20, 30],
            //queryParams: { analysisItem: analysisItem, analysisDestiny: analysisDestiny, startTime: startTime, endTime: endTime, needTime: needTime, timeSpacy: timeSpacy },
            columns: [[
                { field: 'xAxis_value', title: '横轴值', align: 'left', width: 140 },
                        { field: 'yAxis_value', title: '纵轴值', align: 'left', width: 140 }
            ]],
            data:dataObj.data.Rows
        });
        var myChart = echarts.init(document.getElementById('MyChart'));
        var option = {
            title: {
                x: 'center',
                text: dataObj.data.title_text
            },
            tooltip: {
                trigger: 'item'
            },
            toolbox: {
                show: true,
                feature: {
                    dataView: { show: true, readOnly: false },
                    restore: { show: true },
                    saveAsImage: { show: true }
                }
            },
            calculable: true,
            grid: {
                borderWidth: 0,
                y: 80,
                y2: 60
            },
            xAxis: [
                {
                    type: 'category',
                    show: true,
                    name: dataObj.data.xAxis_name,
                    data: dataObj.data.xAxis_data
                }
            ],
            yAxis: [
                {
                    type: 'value',
                    show: true,
                    name: dataObj.data.yAxis_name,
                }
            ],
            series: [
                {
                    name: dataObj.data.title_text,
                    type: 'bar',
                    itemStyle: {
                        normal: {
                            color: function (params) {
                                // build a color map as your need.
                                var colorList = [
                                  '#C1232B', '#B5C334', '#FCCE10', '#E87C25', '#27727B',
                                   '#FE8463', '#9BCA63', '#FAD860', '#F3A43B', '#60C0DD',
                                   '#D7504B', '#C6E579', '#F4E001', '#F0805A', '#26C0C0'
                                ];
                                return colorList[params.dataIndex % 15]
                            },
                            label: {
                                show: true,
                                position: 'top',
                                formatter: '{c}'
                            }
                        }
                    },
                    data: dataObj.data.yAxis_data
                }
            ]
        };
        myChart.setOption(option);
  });
}