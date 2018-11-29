$(function () {
    //绑定Spc设备同时绑定Spc分析项目
    bindSpcEqm();
    //初始化时间
    initialTime();
    //开始按钮单击事件
    $('#BtnAnalysisData').click(function () {
        //显示图表
        showChart();
    });    
});

//绑定Spc设备同时绑定Spc分析项目
function bindSpcEqm() {
    $('#CmbEqm').combobox({
        url: '/BackgroundProgram/bindData.ashx',
        queryParams: { fields: "eqm_no,eqm_name", table: "pdm_eqm", where: strBase64("status_no='310' order by eqm_no") },
        valueField: 'eqm_no',
        textField: 'eqm_name',
        required: true,
        editable: false,
        onLoadSuccess: function () {  //加载完成后,设置选中第一项
            var val = $('#CmbEqm').combobox("getData");
            if (val.length > 0) {
                //设置第一个值为选中值
                $('#CmbEqm').combobox('select', val[0].eqm_no);
                bindSpcSetting(val[0].eqm_no);
            }
            else {
                var data = [];
                data.push({ eqm_no: 'default', eqm_name: 'default', selected: 'true' });
                $('#CmbEqm').combobox('select', data);
            }
        },
        onChange: function (newValue, oldValue) {
            bindSpcSetting(newValue);
            bindPart(newValue);
        }
    });
}

//绑定SPC分析项目
function bindSpcSetting(eqmNo) {
    $('#CmbSpcSetting').combobox({
        url: '/BackgroundProgram/bindData.ashx',
        queryParams: { fields: "spc_setting_no,spc_setting_name", table: "sys_spc_setting", where: strBase64("eqm_no='" + eqmNo + "'") },
        valueField: 'spc_setting_no',
        textField: 'spc_setting_name',
        required: true,
        editable: false,
        onLoadSuccess: function () {  //加载完成后,设置选中第一项
            var val = $('#CmbSpcSetting').combobox("getData");
            if (val.length > 0) {
                //设置第一个值为选中值
                $('#CmbSpcSetting').combobox('select', val[0].spc_setting_no);
            }
            else {
                var data = [];
                data.push({ spc_setting_no: 'default', spc_setting_name: 'default', selected: 'true' });
                $('#CmbSpcSetting').combobox('loadData', data);
            }
        }
    });
}

//绑定部分项目
function bindPart(eqmNo) {
    $('#CmbPart').combobox({
        url: '/BackgroundProgram/bindData.ashx',
        queryParams: { fields: "distinct part_no", table: "mes_fb_info", where: strBase64("eqm_no='" + eqmNo + "' order by part_no") },//eqm_no='" + eqmNo + "'
        valueField: 'part_no',
        textField: 'part_no',
        required: true,
        editable: false,
        onLoadSuccess: function () {  //加载完成后,设置选中第一项
            var val = $('#CmbPart').combobox("getData");
            if (val.length > 0) {
                //设置第一个值为选中值
                $('#CmbPart').combobox('select', val[0].part_no);
            }
            else {
                var data = [];
                data.push({ part_no: 'default', part_no: 'default', selected: 'true' });
                $('#CmbPart').combobox('loadData', data);
            }
        }
    });
}

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
    var information = $('#CmbSpcSetting').combobox('getText');
    var eqmNo = $('#CmbEqm').combobox('getValue');
    var normalValue = $('#txtNomalValue').textbox('getText');
    var toleranceValue = $('#txtToleranceValue').textbox('getText');
    var startTime = $('#TimStartTime').datetimebox('getValue');
    var endTime = $('#TimEndTime').datetimebox('getValue');
    var partNo = $('#CmbPart').combobox('getValue');
    alert(partNo);
    $.getJSON('/BackgroundProgram/SpcAnalysis.ashx', { eqmNo: eqmNo, information: information, normalValue: normalValue, toleranceValue: toleranceValue, startTime: startTime, endTime: endTime,partNo:partNo }, function (data) {
        console.log(data);
        var myDotChart = echarts.init(document.getElementById('DotChart'));
        var arcLineChart = echarts.init(document.getElementById('ArcLineChart'));
        if (data === null) {
            myDotChart.clear();
            arcLineChart.clear();
            return;
        }
        if (data === '') {
            myDotChart.clear();
            arcLineChart.clear();
            return;
        }
        option = {
            title: [{
                text: data.dotTitle
            }, {
                text: data.tips,
                left: 'center',//'18%',
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
                type: 'category',
                boundaryGap: false,
                data: data.dotxAxisData
            },
            yAxis: {
                type: 'value',
                max: data.yAxisMax,
                min: data.yAxisMin,
                splitLine: {
                    show: false
                }
            },
            series: [
                {
                    name: data.dotTitle,
                    type: 'line',
                    data: data.dotyAxisData,
                    markPoint: {
                        data: [
                            { type: 'max', name: '最大值' },
                            { type: 'min', name: '最小值' }
                        ]
                    },
                    markLine: {
                        data: [
                            {
                                yAxis: data.upLimit, name: '上限值', label: {
                                    show: true,
                                    position: 'end',
                                    formatter: '{b}: {c}'
                                }
                            },
                                            {
                                                type: 'average', name: '平均值', label: {
                                                    show: true,
                                                    position: 'end',
                                                    formatter: '{b}: {c}'
                                                }
                                            },
                                            {
                                                yAxis: data.normal, name: '正常值', label: {
                                                    show: true,
                                                    position: 'middle',
                                                    formatter: '{b}: {c}'
                                                }
                                            },
                                        {
                                            yAxis: data.lowerLimit, name: '下限值', label: {
                                                show: true,
                                                position: 'end',
                                                formatter: '{b}: {c}'
                                            }
                                        }
                        ]
                    }
                }
            ]
        };


        option2 = {
            title: {
                text: data.dotTitle,
            },
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
                    type: 'category',
                    data: data.spcxAxisData
                }
            ],
            yAxis: [
                {
                    type: 'value',
                    name: '样本估计',
                    axisLabel: {
                        formatter: '{value}'
                    },
                    splitLine: {
                        show: false
                    }
                },
                {
                    type: 'value',
                    name: '概率',
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
                    name: '样本统计',
                    type: 'bar',
                    barCategoryGap: '0',
                    data: data.spcyAxisCountData
                },
                {
                    name: '样本概率',
                    type: 'line',
                    smooth: true,
                    yAxisIndex: 1,
                    data: data.spcyAxisCurveData
                }
            ]
        };
        myDotChart.setOption(option);
        arcLineChart.setOption(option2);
    });

}