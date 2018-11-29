$(function () {
    ////绑定上侧数据
    //bindTopData();
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
    //绑定下侧数据
    //bindBottomData();
    //初始化下侧表格
    //initialTblBottom();
    //下侧刷新按钮单击事件
    $('#BottomToolBtnRefresh').click(function () {
        bottomTblRefresh();
    });
    ////下侧编辑按钮单击事件
    //$('#BottomToolBtnEdit').click(function () {
    //    bottomEditClick();
    //});
    ////下侧添加按钮单击事件
    //$('#BottomToolBtnAdd').click(function () {
    //    bottomAddClick();
    //});
    ////下侧删除按钮单击事件
    //$('#BottomToolBtnDelete').click(function () {
    //    bottomDeleteClick();
    //});
});

//----------------------bindAuthGroup---------------------------------------//
//绑定上侧数据
//function bindTopData() {
//    bindProcedureStatusTop2();
//    bindCommitStatusTop4();
//}
//初始化上侧表格
function initialTblTop() {
    $('#TblTop').datagrid({
        url: '/BackgroundProgram/GetListPage.ashx',
        title: '报工记录',
        fitColumns: false,
        idField: 'fb_no',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: { viewNeedOperate: 'mesFb', orderBy: JSON.stringify({ fb_no: 'desc' }), where: strBase64('') },
        columns: [[
            { field: 'mpo_no', title: '生产单号', align: 'left', width: 140 },
                    { field: 'fb_no', title: '报工编号', align: 'left', width: 140 },
                    { field: 'eqm_no', title: '工站编号', align: 'left', width: 140 },
                    { field: 'eqm_name', title: '工站名称', align: 'left', width: 140 },
                    { field: 'part_no', title: '型号', align: 'left', width: 140 },
                    { field: 'fb_end_qty_ok', title: '合格品数', align: 'left', width: 140 },
                    { field: 'fb_end_qty_ng', title: '不良品数', align: 'left', width: 140 },
                    { field: 'worker_no', title: '作业员编号', align: 'left', width: 140 },
                    { field: 'worker_name', title: '作业员姓名', align: 'left', width: 140 }
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
    $('#TblTop').datagrid('clearSelections').datagrid('clearChecked');
    $('#TblTop').datagrid('reload');
    $('#TblBottom').datagrid('clearSelections').datagrid('clearChecked');
    reloadTblBottom();
}

////上侧编辑按钮单击事件
//function topEditClick() {
//    var rows = $('#TblTop').datagrid('getSelections');
//    if (rows === null || rows.length < 0) {
//        $.messager.alert('警告', '未选中要修改的对象', 'warning');
//        return;
//    }
//    var row = rows[0];
//    $('#TxtMpoNoTop').textbox('setText', row.mpo_no);
//    $('#TxtMpoNoTop').textbox('disable');
//    $('#CmbCommitStatusTop').combobox('select', row.commit_status_no);
//    $('#CmbProcedureStatusTop').combobox('select', row.procedure_status_name);
//    $('#NumMpoQty').numberspinner('setValue', row.mpo_qty);
//    $('#DatMpoHopeStartTime').datebox('setValue', row.mpo_hope_start_datetime);
//    $('#DatMpoHopeEndTime').datebox('setValue', row.mpo_hope_end_datetime);
//    $('#TopEditFrm').dialog({
//        title: '添加/编辑窗口',
//        modal: true,
//        collapsible: true,
//        minizable: true,
//        maxizable: true,
//        resizeable: true,
//        buttons: [{
//            text: '确认',
//            handler: function () {
//                row.mpo_no = $('#TxtMpoNoTop').textbox('getText');
//                row.commit_status_no = $('#CmbCommitStatusTop').combobox('getValue');
//                row.commit_status_name = $('#CmbCommitStatusTop').combobox('getText');
//                row.procedure_status_name = $('#CmbProcedureStatusTop').combobox('getText');
//                row.mpo_qty = $('#NumMpoQty').numberspinner('getValue');
//                row.mpo_hope_start_datetime = $('#DatMpoHopeStartTime').datebox('getValue');
//                row.mpo_hope_end_datetime = $('#DatMpoHopeEndTime').datebox('getValue');
//                $.post('/BackgroundProgram/EditObject.ashx', { viewNeedOperate: 'mpo', objNeedOperate: JSON.stringify(row) }, function (data) {
//                    if (data === null) {
//                        $.messager.alert('提示信息', '无法获取结果！', 'error');
//                        return;
//                    }
//                    var msg = JSON.parse(data).msg;
//                    if (msg === 'success') {
//                        topTblRefresh();
//                        bindBottomData();
//                        $('#TopEditFrm').dialog('close');
//                        $('#TxtMpoNoTop').textbox('enable');
//                    }
//                    else {
//                        $.messager.alert('提示信息', msg, 'error');
//                    }
//                });
//            }
//        }, {
//            text: '取消',
//            handler: function () {
//                $('#TopEditFrm').dialog('close');
//                $('#TxtMpoNoTop').textbox('enable');
//            }
//        }],
//        onClose: function () {
//            $('#TxtMpoNoTop').textbox('enable');
//        }
//    });
//}
////上侧添加按钮单击事件
//function topAddClick() {
//    $('#TopEditFrm').dialog({
//        title: '添加/编辑窗口',
//        modal: true,
//        collapsible: true,
//        minizable: true,
//        maxizable: true,
//        resizeable: true,
//        buttons: [{
//            text: '确认',
//            handler: function () {
//                var mpo_no = $('#TxtMpoNoTop').textbox('getText');
//                var commit_status_no = $('#CmbCommitStatusTop').combobox('getValue');
//                var commit_status_name = $('#CmbCommitStatusTop').combobox('getText');
//                var procedure_status_name = $('#CmbProcedureStatusTop').combobox('getText');
//                var mpo_qty = $('#NumMpoQty').numberspinner('getValue');
//                var mpo_hope_start_datetime = $('#DatMpoHopeStartTime').datebox('getValue');
//                var mpo_hope_end_datetime = $('#DatMpoHopeEndTime').datebox('getValue');
//                $.post('/BackgroundProgram/AddObject.ashx', { viewNeedOperate: 'mpo', objNeedOperate: JSON.stringify({ mpo_no: mpo_no, commit_status_no: commit_status_no, commit_status_name: commit_status_name, procedure_status_name: procedure_status_name, mpo_qty: mpo_qty, mpo_hope_start_datetime: mpo_hope_start_datetime, mpo_hope_end_datetime: mpo_hope_end_datetime }) }, function (data) {
//                    if (data === null) {
//                        $.messager.alert('提示信息', '无法获取结果！', 'error');
//                        return;
//                    }
//                    var msg = JSON.parse(data).msg;
//                    if (msg === 'success') {
//                        topTblRefresh();
//                        bindBottomData();
//                        $('#TopEditFrm').dialog('close');
//                    }
//                    else {
//                        $.messager.alert('提示信息', msg, 'error');
//                    }
//                });
//            }
//        }, {
//            text: '取消',
//            handler: function () {
//                $('#TopEditFrm').dialog('close');
//            }
//        }]
//    });
//}
////上侧删除按钮单击事件
//function topDeleteClick() {
//    var rows = $('#TblTop').datagrid('getSelections');
//    if (rows === null || rows.length <= 0) {
//        $.messager.alert('警告', '未选中要删除的对象', 'warning');
//        return;
//    }
//    $.messager.confirm('确认', '确认要删除这些数据？', function (r) {
//        if (!r) {
//            return;
//        }
//        $.post('/BackgroundProgram/DeleteObject.ashx', { viewNeedOperate: 'mpo', objNeedOperate: JSON.stringify(rows) }, function (data) {
//            if (data === null) {
//                $.messager.alert('提示信息', '无法获取结果！', 'error');
//                return;
//            }
//            var msg = JSON.parse(data).msg;
//            if (msg === 'success') {
//                topTblRefresh();
//                bindBottomData();
//            }
//            else {
//                $.messager.alert('提示信息', msg, 'error');
//            }
//        });
//    });
//}

////----------------------（上半部分）---------------------------------------//
////----------------------（下半部分）---------------------------------------//
////绑定下侧数据
//function bindBottomData() {
//    bindStatusBottom3();
//}

//初始化下侧表格
function initialTblBottom() {
    var where = '';
    var rows = $('#TblTop').datagrid('getSelections');
    if (rows.length > 0) {
        where = "fb_no='" + rows[0].fb_no + "'";
    }
    else {
        rows = $('#TblTop').datagrid('getRows');
        if (rows === null || rows.length <= 0) {
            where = '1<>1';
        }
        else {
            where = "fb_no='" + rows[0].fb_no + "'";
        }
    }
    $('#TblBottom').datagrid({
        url: '/BackgroundProgram/GetListPage.ashx',
        title: '报工详情',
        fitColumns: false,
        idField: 'fb_item_no',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: { viewNeedOperate: 'mesFbItem', orderBy: JSON.stringify({ fb_item_no: 'desc' }), where: strBase64(where) },
        columns: [[
            { field: 'eqm_no', title: '设备编号', align: 'left', width: 140 },
                    { field: 'eqm_name', title: '设备名称', align: 'left', width: 140 },
                    { field: 'fb_item_no', title: '报工子编号', align: 'left', width: 140 },
                    { field: 'part_no', title: '型号', align: 'left', width: 140 },
                    { field: 'quality_no', title: '质量结果编号', align: 'left', width: 140 },
                    { field: 'fb_datetime', title: '报工时间', align: 'left', width: 140 },
                    { field: 'worker_no', title: '报工者编号', align: 'left', width: 140 },
                    { field: 'worker_name', title: '报工者姓名', align: 'left', width: 140 }
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
        where = "fb_no='" + rows[0].fb_no + "'";
    }
    else {
        rows = $('#TblTop').datagrid('getRows');
        if (rows === null || rows.length <= 0) {
            where = '1<>1';
        }
        else {
            where = "fb_no='" + rows[0].fb_no + "'";
        }
    }
    var param = { viewNeedOperate: 'mesFbItem', orderBy: JSON.stringify({ fb_item_no: 'desc' }), where: strBase64(where) };
    $('#TblBottom').datagrid('load', param);
}

////下侧编辑按钮单击事件
//function bottomEditClick() {
//    var row = $('#TblBottom').datagrid('getSelected');
//    if (row === null) {
//        $.messager.alert('警告', '未选中要修改的对象', 'warning');
//        return;
//    }
//    $('#TxtMpoNoBottom').textbox('setText', row.mpo_no);
//    $('#TxtMpoNoBottom').textbox('disable');
//    $('#TxtSerialNo').textbox('setText', row.serial_no);//NumItemQty    
//    $('#CmbStatusBottom').combobox('setValue', row.status_no);
//    $('#NumItemQty').numberspinner('setValue', row.item_qty);
//    $('#TxtPartNo').textbox('setValue', row.part_no);
//    $('#DtmHopeProductTime').datetimebox('setValue', row.hope_product_time);
//    $('#BottomEditFrm').dialog({
//        title: '添加/编辑窗口',
//        modal: true,
//        collapsible: true,
//        minizable: true,
//        maxizable: true,
//        resizeable: true,
//        buttons: [{
//            text: '确认',
//            handler: function () {
//                row.mpo_no = $('#TxtMpoNoBottom').textbox('getText');
//                row.serial_no = $('#TxtSerialNo').textbox('getText');
//                row.status_no = $('#CmbStatusBottom').combobox('getValue');
//                row.status_name = $('#CmbStatusBottom').combobox('getText');
//                row.item_qty = $('#NumItemQty').numberspinner('getValue');
//                row.part_no = $('#TxtPartNo').textbox('getText');
//                row.hope_product_time = $('#DtmHopeProductTime').datetimebox('getValue');
//                $.post('/BackgroundProgram/EditObject.ashx', { viewNeedOperate: 'mpoItem', objNeedOperate: JSON.stringify(row) }, function (data) {
//                    if (data === null) {
//                        $.messager.alert('提示信息', '无法获取结果！', 'error');
//                        return;
//                    }
//                    var msg = JSON.parse(data).msg;
//                    if (msg === 'success') {
//                        bottomTblRefresh();
//                        $('#BottomEditFrm').dialog('close');
//                        $('#TxtMpoNoBottom').textbox('enable');
//                    }
//                    else {
//                        $.messager.alert('提示信息', msg, 'error');
//                    }
//                });
//            }
//        }, {
//            text: '取消',
//            handler: function () {
//                $('#BottomEditFrm').dialog('close');
//                $('#TxtMpoNoBottom').textbox('enable');
//            }
//        }],
//        onClose: function () {
//            $('#TxtMpoNoBottom').textbox('disable');
//        }
//    });
//}

////下侧添加按钮单击事件
//function bottomAddClick() {
//    $('#BottomEditFrm').dialog({
//        title: '添加/编辑窗口',
//        modal: true,
//        collapsible: true,
//        minizable: true,
//        maxizable: true,
//        resizeable: true,
//        buttons: [{
//            text: '确认',
//            handler: function () {
//                var mpo_no = $('#TxtMpoNoBottom').textbox('getText');
//                var serial_no = $('#TxtSerialNo').textbox('getText');
//                var status_no = $('#CmbStatusBottom').combobox('getValue');
//                var status_name = $('#CmbStatusBottom').combobox('getText');
//                var item_qty = $('#NumItemQty').numberspinner('getValue');
//                var part_no = $('#TxtPartNo').textbox('getText');
//                var hope_product_time = $('#DtmHopeProductTime').datetimebox('getValue');
//                $.post('/BackgroundProgram/AddObject.ashx', { viewNeedOperate: 'mpoItem', objNeedOperate: JSON.stringify({ mpo_no: mpo_no, serial_no: serial_no, status_no: status_no, status_name: status_name, item_qty: item_qty, part_no: part_no, hope_product_time: hope_product_time }) }, function (data) {
//                    if (data === null) {
//                        $.messager.alert('提示信息', '无法获取结果！', 'error');
//                        return;
//                    }
//                    var msg = JSON.parse(data).msg;
//                    if (msg === 'success') {
//                        bottomTblRefresh();
//                        $('#BottomEditFrm').dialog('close');
//                    }
//                    else {
//                        $.messager.alert('提示信息', msg, 'error');
//                    }
//                });
//            }
//        }, {
//            text: '取消',
//            handler: function () {
//                $('#BottomEditFrm').dialog('close');
//            }
//        }]
//    });
//}

////下侧删除按钮单击事件
//function bottomDeleteClick() {
//    var rows = $('#TblBottom').datagrid('getSelections');
//    if (rows.length <= 0) {
//        $.messager.alert('警告', '未选中要删除的对象', 'warning');
//        return;
//    }
//    $.messager.confirm('确认', '确认要删除这些数据？', function (r) {
//        if (!r) {
//            return;
//        }
//        $.post('/BackgroundProgram/DeleteObject.ashx', { viewNeedOperate: 'mpoItem', objNeedOperate: JSON.stringify(rows) }, function (data) {
//            if (data === null) {
//                $.messager.alert('提示信息', '无法获取结果！', 'error');
//                return;
//            }
//            var msg = JSON.parse(data).msg;
//            if (msg === 'success') {
//                bottomTblRefresh();
//            }
//            else {
//                $.messager.alert('提示信息', msg, 'error');
//            }
//        });
//    });
//}