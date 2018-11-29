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
    bindQaCause();
    bindQaResult();
}
//初始化上侧表格
function initialTblTop() {
    $('#TblTop').datagrid({
        url: '/BackgroundProgram/GetListPage.ashx',
        title: '质量异常记录',
        fitColumns: false,
        idField: 'qa_record_no',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: { viewNeedOperate: 'qcmQaRecord', orderBy: JSON.stringify({ qa_record_no: 'desc' }), where: strBase64('qa_result_no is not null') },
        columns: [[
            { field: 'qa_record_no', title: '异常编号', align: 'left', width: 140 },
                    { field: 'status_no', title: '状态码', align: 'left', width: 140 },
                    { field: 'status_name', title: '状态', align: 'left', width: 140 },
                    { field: 'qa_cause_no', title: '异常代码', align: 'left', width: 140 },
                    { field: 'qa_cause_name', title: '异常原因', align: 'left', width: 140 },
                    { field: 'part_no', title: '品号', align: 'left', width: 140 },
                    { field: 'eqm_no', title: '设备编号', align: 'left', width: 140 },
                    { field: 'mpo_no', title: '生产单号', align: 'left', width: 140 },
                    { field: 'mpo_item_no', title: '子单编号', align: 'left', width: 140 },
                    { field: 'serial_no', title: '序列号', align: 'left', width: 140 },
                    { field: 'qa_result_no', title: '结果编号', align: 'left', width: 140 },
                    { field: 'qa_result_name', title: '质量结果', align: 'left', width: 140 },
                    //{ field: 'submit_user_no', title: '上报人编号', align: 'left', width: 140 },
                    //{ field: 'submit_user_name', title: '上报人', align: 'left', width: 140 },
                    { field: 'submit_time', title: '上报时间', align: 'left', width: 140 },
                    //{ field: 'solve_user_no', title: '处理人编号', align: 'left', width: 140 },
                    //{ field: 'solve_user_name', title: '处理人', align: 'left', width: 140 },
                    { field: 'solve_time', title: '处理时间', align: 'left', width: 140 }
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
    $('#TxtQaRecordNo').textbox('setText', row.qa_record_no);
    $('#TxtQaRecordNo').textbox('disable');
    $('#CmbStatusTop').combobox('select', row.status_no);
    $('#TxtPartNo').textbox('setText', row.part_no);
    $('#TxtMpoNo').textbox('setText', row.mpo_no);
    $('#TxtMpoItemNo').textbox('setText', row.mpo_item_no);
    $('#TxtSerialNo').textbox('setText', row.serial_no);
    $('#CmbEqm').combobox('select', row.eqm_no);
    $('#CmbQaCause').combobox('select', row.qa_cause_no);
    $('#CmbQaResult').combobox('select', row.qa_result_no);
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
                row.qa_record_no = $('#TxtQaRecordNo').textbox('getText');
                row.status_no = $('#CmbStatusTop').combobox('getValue');
                row.status_name = $('#CmbStatusTop').combobox('getText');
                row.part_no = $('#TxtPartNo').textbox('getText');
                row.mpo_no = $('#TxtMpoNo').textbox('getText');
                row.mpo_item_no = $('#TxtMpoItemNo').textbox('getText');
                row.serial_no=$('#TxtSerialNo').textbox('getText');
                row.eqm_no = $('#CmbEqm').combobox('getValue');
                row.eqm_name= $('#CmbEqm').combobox('getText');
                row.qa_cause_no = $('#CmbQaCause').combobox('getValue');
                row.qa_cause_name = $('#CmbQaCause').combobox('getText');
                row.qa_result_no = $('#CmbQaResult').combobox('getValue');
                row.qa_result_name = $('#CmbQaResult').combobox('getText');
                $.post('/BackgroundProgram/EditObject.ashx', { viewNeedOperate: 'qcmQaRecord', objNeedOperate: JSON.stringify(row) }, function (data) {
                    if (data === null) {
                        $.messager.alert('提示信息', '无法获取结果！', 'error');
                        return;
                    }
                    var msg = JSON.parse(data).msg;
                    if (msg === 'success') {
                        topTblRefresh();
                        $('#TopEditFrm').dialog('close');
                        $('#TxtQaRecordNo').textbox('enable');
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
                $('#TxtQaRecordNo').textbox('enable');
            }
        }],
        onClose: function () {
            $('#TxtQaRecordNo').textbox('enable');
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
                var qa_record_no = $('#TxtQaRecordNo').textbox('getText');
                var status_no = $('#CmbStatusTop').combobox('getValue');
                var status_name = $('#CmbStatusTop').combobox('getText');
                var part_no = $('#TxtPartNo').textbox('getText');
                var mpo_no = $('#TxtMpoNo').textbox('getText');
                var mpo_item_no = $('#TxtMpoItemNo').textbox('getText');
                var serial_no = $('#TxtSerialNo').textbox('getText');
                var eqm_no = $('#CmbEqm').combobox('getValue');
                var eqm_name = $('#CmbEqm').combobox('getText');
                var qa_cause_no = $('#CmbQaCause').combobox('getValue');
                var qa_cause_name = $('#CmbQaCause').combobox('getText');
                var qa_result_no = $('#CmbQaResult').combobox('getValue');
                var qa_result_name = $('#CmbQaResult').combobox('getText');
                $.post('/BackgroundProgram/AddObject.ashx', { viewNeedOperate: 'qcmQaRecord', objNeedOperate: JSON.stringify({ qa_record_no: qa_record_no, status_no: status_no, status_name: status_name, part_no: part_no, mpo_no: mpo_no, mpo_item_no: mpo_item_no, serial_no: serial_no, eqm_no: eqm_no, eqm_name: eqm_name, qa_cause_no: qa_cause_no, qa_cause_name: qa_cause_name, qa_result_no: qa_result_no, qa_result_name: qa_result_name }) }, function (data) {
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
        $.post('/BackgroundProgram/DeleteObject.ashx', { viewNeedOperate: 'qcmQaRecord', objNeedOperate: JSON.stringify(rows) }, function (data) {
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