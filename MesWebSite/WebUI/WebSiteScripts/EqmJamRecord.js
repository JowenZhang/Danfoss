$(function () {
    //绑定上侧数据
    bindTopData();
    //初始化上侧表格
    initialTblTop();
    //上侧刷新按钮单击事件
    $('#TopToolBtnRefresh').click(function () {
        topTblRefresh();
    });
    ////上侧编辑按钮单击事件
    //$('#TopToolBtnEdit').click(function () {
    //    topEditClick();
    //});
    ////上侧添加按钮单击事件
    //$('#TopToolBtnAdd').click(function () {
    //    topAddClick();
    //});
    //上侧删除按钮单击事件
    $('#TopToolBtnDelete').click(function () {
        topDeleteClick();
    });
});
//绑定上侧数据
function bindTopData() {
    bindStatusTop5();
    bindEqm();
    bindEqmJamCause();
}
//初始化上侧表格
function initialTblTop() {
    $('#TblTop').datagrid({
        url: '/BackgroundProgram/GetListPage.ashx',
        title: '工站停机记录',
        fitColumns: false,
        idField: 'jam_record_no',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: { viewNeedOperate: 'eqmJamRecord', orderBy: JSON.stringify({ jam_record_no: 'desc' }), where: strBase64('') },
        columns: [[
            { field: 'jam_record_no', title: '停机记录编号', align: 'left', width: 140 },
                    { field: 'status_no', title: '状态码', align: 'left', width: 140 },
                    { field: 'status_name', title: '状态', align: 'left', width: 140 },
                    { field: 'jam_cause_no', title: '停机代码', align: 'left', width: 140 },
                    { field: 'jam_cause_name', title: '停机原因', align: 'left', width: 140 },
                    { field: 'eqm_no', title: '设备编号', align: 'left', width: 140 },
                    { field: 'submit_time', title: '上报时间', align: 'left', width: 140 },
                    { field: 'reply_time', title: '响应时间', align: 'left', width: 140 }
        ]],
        toolbar: '#ToolbarTop'
    });
}

//上侧数据刷新
function topTblRefresh() {
    $('#TblTop').datagrid('clearSelections').datagrid('clearChecked');
    $('#TblTop').datagrid('reload');
}

//上侧编辑按钮单击事件
function topEditClick() {
    var row = $('#TblTop').datagrid('getSelected');
    if (row === null) {
        $.messager.alert('警告', '未选中要修改的对象', 'warning');
        return;
    }
    $('#TxtJamRecordNo').textbox('setText', row.jam_record_no);
    $('#TxtJamRecordNo').textbox('disable');
    $('#CmbStatusTop').combobox('select', row.status_no);
    $('#CmbEqm').combobox('select', row.eqm_no);
    $('#CmbEqmJamCause').combobox('select', row.jam_cause_no);
    $('#TopEditFrm').dialog({
        title: '添加/编辑窗口',
        modal: true,
        collapsible: true,
        minizable: true,
        maxizable: true,
        resizeable: true,
        buttons: [{
            text: '确认',
            handler: function () {
                row.jam_record_no = $('#TxtJamRecordNo').textbox('getText');
                row.status_no = $('#CmbStatusTop').combobox('getValue');
                row.status_name = $('#CmbStatusTop').combobox('getText');
                row.eqm_no = $('#CmbEqm').combobox('getValue');
                row.jam_cause_no = $('#CmbEqmJamCause').combobox('getValue');
                row.jam_cause_name = $('#CmbEqmJamCause').combobox('getText');
                $.post('/BackgroundProgram/EditObject.ashx', { viewNeedOperate: 'eqmJamRecord', objNeedOperate: JSON.stringify(row) }, function (data) {
                    if (data === null) {
                        $.messager.alert('提示信息', '无法获取结果！', 'error');
                        return;
                    }
                    var msg = JSON.parse(data).msg;
                    if (msg === 'success') {
                        topTblRefresh();
                        $('#TopEditFrm').dialog('close');
                        $('#TxtJamRecordNo').textbox('enable');
                    }
                    else {
                        $.messager.alert('提示信息', msg, 'error');
                    }
                });
            }
        }, {
            text: '取消',
            handler: function () {
                $('#TopEditFrm').dialog('close');
                $('#TxtJamRecordNo').textbox('enable');
            }
        }],
        onClose: function () {
            $('#TxtJamRecordNo').textbox('enable');
        }
    });
}

//上侧添加按钮单击事件
function topAddClick() {
    $('#TopEditFrm').dialog({
        title: '添加/编辑窗口',
        modal: true,
        collapsible: true,
        minizable: true,
        maxizable: true,
        resizeable: true,
        buttons: [{
            text: '确认',
            handler: function () {
                var jam_record_no = $('#TxtJamRecordNo').textbox('getText');
                var status_no = $('#CmbStatusTop').combobox('getValue');
                var status_name = $('#CmbStatusTop').combobox('getText');
                var eqm_no = $('#CmbEqm').combobox('getValue');
                var jam_cause_no = $('#CmbEqmJamCause').combobox('getValue');
                var jam_cause_name = $('#CmbEqmJamCause').combobox('getText');
                $.post('/BackgroundProgram/AddObject.ashx', { viewNeedOperate: 'eqmJamRecord', objNeedOperate: JSON.stringify({ jam_record_no: jam_record_no, status_no: status_no, status_name: status_name, eqm_no:eqm_no,jam_cause_no: jam_cause_no, jam_cause_name: jam_cause_name }) }, function (data) {
                    if (data === null) {
                        $.messager.alert('提示信息', '无法获取结果！', 'error');
                        return;
                    }
                    var msg = JSON.parse(data).msg;
                    if (msg === 'success') {
                        topTblRefresh();
                        $('#TopEditFrm').dialog('close');
                    }
                    else {
                        $.messager.alert('提示信息', msg, 'error');
                    }
                });
            }
        }, {
            text: '取消',
            handler: function () {
                $('#TopEditFrm').dialog('close');
            }
        }]
    });
}
//上侧删除按钮单击事件
function topDeleteClick() {
    var rows = $('#TblTop').datagrid('getSelections');
    if (rows.length <= 0) {
        $.messager.alert('警告', '未选中要删除的对象', 'warning');
        return;
    }
    $.messager.confirm('确认', '确认要删除这些数据？', function (r) {
        if (!r) {
            return;
        }
        $.post('/BackgroundProgram/DeleteObject.ashx', { viewNeedOperate: 'eqmJamRecord', objNeedOperate: JSON.stringify(rows) }, function (data) {
            if (data === null) {
                $.messager.alert('提示信息', '无法获取结果！', 'error');
                return;
            }
            var msg = JSON.parse(data).msg;
            if (msg === 'success') {
                topTblRefresh();
            }
            else {
                $.messager.alert('提示信息', msg, 'error');
            }
        });
    });
}