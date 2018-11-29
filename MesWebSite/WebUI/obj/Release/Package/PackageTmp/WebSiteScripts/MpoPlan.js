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
    ////上侧删除按钮单击事件
    //$('#TopToolBtnDelete').click(function () {
    //    topDeleteClick();
    //});
    //上侧确认开工按钮单击事件
    $('#TopToolBtnConfirmStart').click(function () {
        topConfirmStartClick();
    });
    //上侧检索按钮单击事件
    $('#TopToolBtnSearch').click(function () {
        topSearchClick();
    });
    //绑定下侧数据
    bindBottomData();
    //初始化下侧表格
    //initialTblBottom();
    //下侧刷新按钮单击事件
    $('#BottomToolBtnRefresh').click(function () {
        bottomTblRefresh();
    });
    //下侧编辑按钮单击事件
    $('#BottomToolBtnEdit').click(function () {
        bottomEditClick();
    });
    //下侧添加按钮单击事件
    $('#BottomToolBtnAdd').click(function () {
        bottomAddClick();
    });
    //下侧删除按钮单击事件
    $('#BottomToolBtnDelete').click(function () {
        bottomDeleteClick();
    });
});

//----------------------bindAuthGroup---------------------------------------//
//绑定上侧数据
function bindTopData() {
    bindProcedureStatusTop2();
    bindCommitStatusTop4();
}
//初始化上侧表格
function initialTblTop() {
    $('#TblTop').datagrid({
        url: '/BackgroundProgram/GetListPage.ashx',
        title: '生产计划',
        fitColumns: false,
        idField: 'mpo',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: false,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: { viewNeedOperate: 'mpo', orderBy: JSON.stringify({ mpo_hope_start_datetime: 'desc', mpo_no: 'desc' }), where: strBase64('') },
        columns: [[
            { field: '', checkbox: true, align: 'left', width: 50 },
            { field: 'mpo_no', title: '计划订单', align: 'left', width: 140 },
                    { field: 'part_no', title: '产品型号', align: 'left', width: 140 },
                    { field: 'commit_status_no', title: '订单状态码', align: 'left', width: 150 },
                    { field: 'commit_status_name', title: '订单状态', align: 'left', width: 150 },
                    { field: 'mpo_qty', title: '计划数量', align: 'left', width: 140 },
                    { field: 'mpo_hope_start_datetime', title: '期望开工时间', align: 'left', width: 140 },
                    { field: 'mpo_hope_end_datetime', title: '期望完工时间', align: 'left', width: 140 },
                    { field: 'procedure_finished_qty', title: '完工数量', align: 'left', width: 140 },
                    { field: 'procedure_status_name', title: '生产状态', align: 'left', width: 140 },
        ]],
        toolbar: '#ToolbarTop',
        onClickRow: function (index, row) {
            reloadTblBottom();
        },
        onLoadSuccess: function () {
            initialTblBottom();
        },
    });
}

//上侧数据刷新
function topTblRefresh() {
    var prams= { viewNeedOperate: 'mpo', orderBy: JSON.stringify({ mpo_hope_start_datetime: 'desc', mpo_no: 'desc' }), where: strBase64('') }
    $('#TblTop').datagrid('clearSelections').datagrid('clearChecked');
    $('#TblTop').datagrid('load',prams);
    $('#TblBottom').datagrid('clearSelections').datagrid('clearChecked');
    reloadTblBottom();
}

//上侧编辑按钮单击事件
function topEditClick() {
    var rows = $('#TblTop').datagrid('getSelections');
    if (rows === null || rows.length<0) {
        $.messager.alert('警告', '未选中要修改的对象', 'warning');
        return;
    }
    var row = rows[0];
    $('#TxtMpoNoTop').textbox('setText', row.mpo_no);
    $('#TxtMpoNoTop').textbox('disable');    
    $('#CmbCommitStatusTop').combobox('select', row.commit_status_no);
    $('#CmbProcedureStatusTop').combobox('select', row.procedure_status_name);
    $('#NumMpoQty').numberspinner('setValue', row.mpo_qty);
    $('#DatMpoHopeStartTime').datebox('setValue', row.mpo_hope_start_datetime);
    $('#DatMpoHopeEndTime').datebox('setValue', row.mpo_hope_end_datetime);
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
                row.mpo_no = $('#TxtMpoNoTop').textbox('getText');
                row.commit_status_no = $('#CmbCommitStatusTop').combobox('getValue');
                row.commit_status_name = $('#CmbCommitStatusTop').combobox('getText');
                row.procedure_status_name = $('#CmbProcedureStatusTop').combobox('getText');
                row.mpo_qty = $('#NumMpoQty').numberspinner('getValue');
                row.mpo_hope_start_datetime = $('#DatMpoHopeStartTime').datebox('getValue');
                row.mpo_hope_end_datetime = $('#DatMpoHopeEndTime').datebox('getValue');
                $.post('/BackgroundProgram/EditObject.ashx', { viewNeedOperate: 'mpo', objNeedOperate: JSON.stringify(row) }, function (data) {
                    if (data === null) {
                        $.messager.alert('提示信息', '无法获取结果！', 'error');
                        return;
                    }
                    var msg = JSON.parse(data).msg;
                    if (msg === 'success') {
                        topTblRefresh();
                        bindBottomData();
                        $('#TopEditFrm').dialog('close');
                        $('#TxtMpoNoTop').textbox('enable');
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
                $('#TxtMpoNoTop').textbox('enable');
            }
        }],
        onClose: function () {
            $('#TxtMpoNoTop').textbox('enable');
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
                var mpo_no = $('#TxtMpoNoTop').textbox('getText');
                var commit_status_no = $('#CmbCommitStatusTop').combobox('getValue');
                var commit_status_name = $('#CmbCommitStatusTop').combobox('getText');
                var procedure_status_name = $('#CmbProcedureStatusTop').combobox('getText');
                var mpo_qty = $('#NumMpoQty').numberspinner('getValue');
                var mpo_hope_start_datetime = $('#DatMpoHopeStartTime').datebox('getValue');
                var mpo_hope_end_datetime = $('#DatMpoHopeEndTime').datebox('getValue');
                $.post('/BackgroundProgram/AddObject.ashx', { viewNeedOperate: 'mpo', objNeedOperate: JSON.stringify({ mpo_no: mpo_no, commit_status_no: commit_status_no, commit_status_name: commit_status_name, procedure_status_name: procedure_status_name, mpo_qty: mpo_qty, mpo_hope_start_datetime: mpo_hope_start_datetime, mpo_hope_end_datetime: mpo_hope_end_datetime }) }, function (data) {
                    if (data === null) {
                        $.messager.alert('提示信息', '无法获取结果！', 'error');
                        return;
                    }
                    var msg = JSON.parse(data).msg;
                    if (msg === 'success') {
                        topTblRefresh();
                        bindBottomData();
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
    if (rows===null||rows.length <= 0) {
        $.messager.alert('警告', '未选中要删除的对象', 'warning');
        return;
    }
    $.messager.confirm('确认', '确认要删除这些数据？', function (r) {
        if (!r) {
            return;
        }
        $.post('/BackgroundProgram/DeleteObject.ashx', { viewNeedOperate: 'mpo', objNeedOperate: JSON.stringify(rows) }, function (data) {
            if (data === null) {
                $.messager.alert('提示信息', '无法获取结果！', 'error');
                return;
            }
            var msg = JSON.parse(data).msg;
            if (msg === 'success') {
                topTblRefresh();
                bindBottomData();
            }
            else {
                $.messager.alert('提示信息', msg, 'error');
            }
        });
    });
}
//上侧确认开工按钮单击事件
function topConfirmStartClick(){
    var rows = $('#TblTop').datagrid('getSelections');
    if (rows === null || rows.length < 0) {
        $.messager.alert('警告', '未选中要修改的对象', 'warning');
        return;
    }
    $('#TopConfirmStartFrm').dialog({
        title: '确认开工',
        modal: true,
        collapsible: true,
        minizable: true,
        maxizable: true,
        resizeable: true,
        buttons: [{
            text: '确认',
            handler: function () {
                for (var i = 0; i < rows.length; i++) {
                    rows[i].mpo_hope_start_datetime = $('#NewDatMpoHopeStartTime').datebox('getValue') + ' 08:00:00.000';
                    rows[i].mpo_hope_end_datetime = $('#NewDatMpoHopeEndTime').datebox('getValue') + ' 18:00:00.000';
                    rows[i].commit_status_no = '410';
                    rows[i].commit_status_name = '已下发';
                }
                $.post('/BackgroundProgram/EditObject.ashx', { viewNeedOperate: 'mpo', objNeedOperate: JSON.stringify(rows) }, function (data) {
                    if (data === null) {
                        $.messager.alert('提示信息', '无法获取结果！', 'error');
                        return;
                    }
                    var msg = JSON.parse(data).msg;
                    if (msg === 'success') {
                        topTblRefresh();
                        bindBottomData();
                        $('#TopConfirmStartFrm').dialog('close');
                        $('#TxtMpoNoTop').textbox('enable');
                    }
                    else {
                        $.messager.alert('提示信息', msg, 'error');
                    }
                });
            }
        }, {
            text: '取消',
            handler: function () {
                $('#TopConfirmStartFrm').dialog('close');
            }
        }]
    });
}
//上侧检索按钮单击事件
function topSearchClick() {
    var where = "part_no like '%" + $('#TopToolTxtPartNo').textbox('getText') + "%' and mpo_hope_start_datetime<='" + $('#TopToolDatEndTime').datebox('getValue') + "' and mpo_hope_start_datetime>='" + $('#TopToolDatStartTime').datebox('getValue') + "'";
    var param = { viewNeedOperate: 'mpo', orderBy: JSON.stringify({ mpo_hope_start_datetime: 'desc', mpo_no: 'desc' }), where: strBase64(where) };
    $('#TblTop').datagrid('clearSelections').datagrid('clearChecked');
    $('#TblTop').datagrid('load', param);
    $('#TblBottom').datagrid('clearSelections').datagrid('clearChecked');
    reloadTblBottom();
}
////----------------------（上半部分）---------------------------------------//
////----------------------（下半部分）---------------------------------------//
//绑定下侧数据
function bindBottomData() {
    bindStatusBottom3();
}

//初始化下侧表格
function initialTblBottom() {
    var where = '';
    var rows = $('#TblTop').datagrid('getSelections');
    if (rows.length > 0) {
        where = "mpo_no='" + rows[0].mpo_no + "'";
    }
    else {
        rows = $('#TblTop').datagrid('getRows');
        if (rows === null || rows.length <= 0) {
            where = '1<>1';
        }
        else {
            where = "mpo_no='" + rows[0].mpo_no + "'";
        }
    }
    $('#TblBottom').datagrid({
        url: '/BackgroundProgram/GetListPage.ashx',
        title: '计划详情',
        fitColumns: false,
        idField: 'serial_no',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: { viewNeedOperate: 'mpoItem', orderBy: JSON.stringify({ serial_no: 'desc' }), where: strBase64(where) },
        columns: [[
            { field: 'mpo_no', title: '计划单号', align: 'left', width: 140 },
                    { field: 'item_no', title: '详情单号', align: 'left', width: 140 },
                    { field: 'status_no', title: '状态码', align: 'left', width: 140 },
                    { field: 'status_name', title: '状态', align: 'left', width: 140 },
                    { field: 'serial_no', title: '序列号', align: 'left', width: 140 },
                    { field: 'item_qty', title: '详单数量', align: 'left', width: 140 },
                    { field: 'part_no', title: '型号', align: 'left', width: 140 },
                    { field: 'hope_product_time', title: '期望生产时间', align: 'left', width: 140 }
        ]],
        toolbar: '#ToolbarBottom'
    });
}

//下侧数据刷新
function bottomTblRefresh() {
    $('#TblBottom').datagrid('clearSelections').datagrid('clearChecked');
    reloadTblBottom();
}

//下侧刷新按钮单击事件
function reloadTblBottom() {
    var where = '';
    var rows = $('#TblTop').datagrid('getSelections');
    if (rows.length > 0) {
        where = "mpo_no='" + rows[0].mpo_no + "'";
    }
    else {
        rows = $('#TblTop').datagrid('getRows');
        if (rows === null || rows.length <= 0) {
            where = '1<>1';
        }
        else {
            where = "mpo_no='" + rows[0].mpo_no + "'";
        }
    }
    var param = { viewNeedOperate: 'mpoItem', orderBy: JSON.stringify({ mpo_no: 'desc' }), where: strBase64(where) };
    $('#TblBottom').datagrid('load', param);
}

//下侧编辑按钮单击事件
function bottomEditClick() {
    var row = $('#TblBottom').datagrid('getSelected');
    if (row === null) {
        $.messager.alert('警告', '未选中要修改的对象', 'warning');
        return;
    }
    $('#TxtMpoNoBottom').textbox('setText', row.mpo_no);
    $('#TxtMpoNoBottom').textbox('disable');
    $('#TxtSerialNo').textbox('setText', row.serial_no);//NumItemQty    
    $('#CmbStatusBottom').combobox('setValue', row.status_no);
    $('#NumItemQty').numberspinner('setValue', row.item_qty);
    $('#TxtPartNo').textbox('setValue', row.part_no);
    $('#DtmHopeProductTime').datetimebox('setValue', row.hope_product_time);
    $('#BottomEditFrm').dialog({
        title: '添加/编辑窗口',
        modal: true,
        collapsible: true,
        minizable: true,
        maxizable: true,
        resizeable: true,
        buttons: [{
            text: '确认',
            handler: function () {
                row.mpo_no = $('#TxtMpoNoBottom').textbox('getText');
                row.serial_no = $('#TxtSerialNo').textbox('getText');
                row.status_no = $('#CmbStatusBottom').combobox('getValue');
                row.status_name = $('#CmbStatusBottom').combobox('getText');
                row.item_qty = $('#NumItemQty').numberspinner('getValue');
                row.part_no = $('#TxtPartNo').textbox('getText');
                row.hope_product_time = $('#DtmHopeProductTime').datetimebox('getValue');
                $.post('/BackgroundProgram/EditObject.ashx', { viewNeedOperate: 'mpoItem', objNeedOperate: JSON.stringify(row) }, function (data) {
                    if (data === null) {
                        $.messager.alert('提示信息', '无法获取结果！', 'error');
                        return;
                    }
                    var msg = JSON.parse(data).msg;
                    if (msg === 'success') {
                        bottomTblRefresh();
                        $('#BottomEditFrm').dialog('close');
                        $('#TxtMpoNoBottom').textbox('enable');
                    }
                    else {
                        $.messager.alert('提示信息', msg, 'error');
                    }
                });
            }
        }, {
            text: '取消',
            handler: function () {
                $('#BottomEditFrm').dialog('close');
                $('#TxtMpoNoBottom').textbox('enable');
            }
        }],
        onClose: function () {
            $('#TxtMpoNoBottom').textbox('disable');
        }
    });
}

//下侧添加按钮单击事件
function bottomAddClick() {
    $('#BottomEditFrm').dialog({
        title: '添加/编辑窗口',
        modal: true,
        collapsible: true,
        minizable: true,
        maxizable: true,
        resizeable: true,
        buttons: [{
            text: '确认',
            handler: function () {
                var mpo_no = $('#TxtMpoNoBottom').textbox('getText');
                var serial_no = $('#TxtSerialNo').textbox('getText');
                var status_no = $('#CmbStatusBottom').combobox('getValue');
                var status_name = $('#CmbStatusBottom').combobox('getText');
                var item_qty = $('#NumItemQty').numberspinner('getValue');
                var part_no = $('#TxtPartNo').textbox('getText');
                var hope_product_time = $('#DtmHopeProductTime').datetimebox('getValue');
                $.post('/BackgroundProgram/AddObject.ashx', { viewNeedOperate: 'mpoItem', objNeedOperate: JSON.stringify({ mpo_no: mpo_no, serial_no: serial_no, status_no: status_no, status_name: status_name, item_qty: item_qty, part_no: part_no, hope_product_time: hope_product_time }) }, function (data) {
                    if (data === null) {
                        $.messager.alert('提示信息', '无法获取结果！', 'error');
                        return;
                    }
                    var msg = JSON.parse(data).msg;
                    if (msg === 'success') {
                        bottomTblRefresh();
                        $('#BottomEditFrm').dialog('close');
                    }
                    else {
                        $.messager.alert('提示信息', msg, 'error');
                    }
                });
            }
        }, {
            text: '取消',
            handler: function () {
                $('#BottomEditFrm').dialog('close');
            }
        }]
    });
}

//下侧删除按钮单击事件
function bottomDeleteClick() {
    var rows = $('#TblBottom').datagrid('getSelections');
    if (rows.length <= 0) {
        $.messager.alert('警告', '未选中要删除的对象', 'warning');
        return;
    }
    $.messager.confirm('确认', '确认要删除这些数据？', function (r) {
        if (!r) {
            return;
        }
        $.post('/BackgroundProgram/DeleteObject.ashx', { viewNeedOperate: 'mpoItem', objNeedOperate: JSON.stringify(rows) }, function (data) {
            if (data === null) {
                $.messager.alert('提示信息', '无法获取结果！', 'error');
                return;
            }
            var msg = JSON.parse(data).msg;
            if (msg === 'success') {
                bottomTblRefresh();
            }
            else {
                $.messager.alert('提示信息', msg, 'error');
            }
        });
    });
}