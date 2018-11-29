$(function () {
    //绑定上侧数据
    bindTopData();
    //初始化上侧表格
    initialTblTop();
    //上侧刷新按钮单击事件
    $('#TopToolBtnRefresh').click(function () {
        topTblRefresh();
    });
    //上侧编辑按钮单击事件
    $('#TopToolBtnEdit').click(function () {
        topEditClick();
    });
    //上侧添加按钮单击事件
    $('#TopToolBtnAdd').click(function () {
        topAddClick();
    });
    //上侧删除按钮单击事件
    $('#TopToolBtnDelete').click(function () {
        topDeleteClick();
    });
});
//绑定上侧数据
function bindTopData() {
    bindStatusTop3();
    bindFactory();
    bindWorkshop();
    bindLine();
    bindShift();
}
//初始化上侧表格
function initialTblTop() {
    $('#TblTop').datagrid({
        url: '/BackgroundProgram/GetListPage.ashx',
        title: '作业员',
        fitColumns: false,
        idField: 'worker_no',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: { viewNeedOperate: 'mesWorker', orderBy: JSON.stringify({ worker_no: 'desc' }), where: strBase64('') },
        columns: [[
            { field: 'worker_no', title: '作业员编号', align: 'left', width: 140 },
                    { field: 'worker_name', title: '作业员姓名', align: 'left', width: 140 },
                    { field: 'status_no', title: '状态码', align: 'left', width: 140 },
                    { field: 'status_name', title: '状态', align: 'left', width: 140 },
                    { field: 'worker_card_no', title: '作业员卡号', align: 'left', width: 140 },
                    { field: 'worker_card_id', title: '作业员卡ID', align: 'left', width: 140 },
                    { field: 'factory_no', title: '工厂编号', align: 'left', width: 140 },
                    { field: 'workshop_no', title: '车间编号', align: 'left', width: 140 },
                    { field: 'line_no', title: '生产线编号', align: 'left', width: 140 },
                    { field: 'shift_no', title: '班次编号', align: 'left', width: 140 },
                    { field: 'worker_mobile', title: '联系方式', align: 'left', width: 140 },
                    { field: 'in_date', title: '入职日期', align: 'left', width: 140 }
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
    $('#TxtWorkerNo').textbox('setText', row.worker_no);
    $('#TxtWorkerNo').textbox('disable');
    $('#TxtWorkerName').textbox('setText', row.worker_name);
    $('#CmbStatusTop').combobox('select', row.status_no);
    $('#TxtWorkerCardNo').textbox('setText', row.worker_card_no);
    $('#TxtWorkerCardId').textbox('setText', row.worker_card_id);
    $('#CmbFactory').combobox('select', row.factory_no);
    $('#CmbWorkshop').combobox('select', row.workshop_no);
    $('#CmbLine').combobox('select', row.line_no);
    $('#CmbShift').combobox('select', row.shift_no);
    $('#TxtWorkerMobile').textbox('setText', row.worker_mobile);
    $('#DatInDate').datebox('setValue', row.in_date_attach);
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
                row.worker_no = $('#TxtWorkerNo').textbox('getText');
                row.worker_name = $('#TxtWorkerName').textbox('getText');
                row.status_no = $('#CmbStatusTop').combobox('getValue');
                row.status_name = $('#CmbStatusTop').combobox('getText');
                row.worker_card_no = $('#TxtWorkerCardNo').textbox('getText');
                row.worker_card_id = $('#TxtWorkerCardId').textbox('getText');
                row.factory_no = $('#CmbFactory').combobox('getValue');
                row.workshop_no = $('#CmbWorkshop').combobox('getValue');
                row.line_no = $('#CmbLine').combobox('getValue');
                row.shift_no = $('#CmbShift').combobox('getValue');
                row.worker_mobile = $('#TxtWorkerMobile').textbox('getText');
                row.in_date_attach = $('#DatInDate').textbox('getValue');
                $.post('/BackgroundProgram/EditObject.ashx', { viewNeedOperate: 'mesWorker', objNeedOperate: JSON.stringify(row) }, function (data) {
                    if (data === null) {
                        $.messager.alert('提示信息', '无法获取结果！', 'error');
                        return;
                    }
                    var msg = JSON.parse(data).msg;
                    if (msg === 'success') {
                        topTblRefresh();
                        $('#TopEditFrm').dialog('close');
                        $('#TxtWorkerNo').textbox('enable');
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
                $('#TxtWorkerNo').textbox('enable');
            }
        }],
        onClose: function () {
            $('#TxtWorkerNo').textbox('enable');
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
                var worker_no = $('#TxtWorkerNo').textbox('getText');
                var worker_name = $('#TxtWorkerName').textbox('getText');
                var status_no = $('#CmbStatusTop').combobox('getValue');
                var status_name = $('#CmbStatusTop').combobox('getText');
                var worker_card_no = $('#TxtWorkerCardNo').textbox('getText');
                var worker_card_id = $('#TxtWorkerCardId').textbox('getText');
                var factory_no = $('#CmbFactory').combobox('getValue');
                var workshop_no = $('#CmbWorkshop').combobox('getValue');
                var line_no = $('#CmbLine').combobox('getValue');
                var shift_no = $('#CmbShift').combobox('getValue');
                var worker_mobile = $('#TxtWorkerMobile').textbox('getText');
                var in_date_attach = $('#DatInDate').textbox('getValue');
                $.post('/BackgroundProgram/AddObject.ashx', { viewNeedOperate: 'mesWorker', objNeedOperate: JSON.stringify({ worker_no: worker_no, worker_name: worker_name, status_no: status_no, status_name: status_name, worker_card_no: worker_card_no, worker_card_id: worker_card_id, factory_no: factory_no, workshop_no: workshop_no, line_no: line_no, shift_no: shift_no, worker_mobile: worker_mobile, in_date_attach: in_date_attach }) }, function (data) {
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
        $.post('/BackgroundProgram/DeleteObject.ashx', { viewNeedOperate: 'mesWorker', objNeedOperate: JSON.stringify(rows) }, function (data) {
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