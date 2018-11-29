$(function () {
    //绑定上侧数据
    bindTopData();
    //初始化上侧表格
    initialTblTop();
    //上侧刷新按钮单击事件
    $('#TopToolBtnRefresh').click(function () {
        topTblRefresh();
    });
    //上侧检索按钮单击事件
    $('#TopToolBtnSearch').click(function () {
        topSearchClick();
    });
    //上侧生成跟踪卡按钮单击事件
    $('#TopToolBtnRecord').click(function () {
        topRecordClick();
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
});
//绑定上侧数据
function bindTopData() {
    bindEqmToolBar();
}
////初始化上侧表格
function initialTblTop() {
    $('#TblTop').datagrid({
        url: '/BackgroundProgram/GetListPage.ashx',
        title: '数据记录',
        fitColumns: false,
        idField: 'id',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: { viewNeedOperate: 'mesFbInfo', orderBy: JSON.stringify({ create_time: 'desc', serial_no: 'desc', eqm_no: 'desc', information: 'desc' }), where: strBase64('') },
        columns: [[
            { field: 'create_time', title: '记录日期', align: 'left', width: 140 },
            { field: 'serial_no', title: '序列号', align: 'left', width: 140 },
                            { field: 'eqm_no', title: '工站编号', align: 'left', width: 140 },
                            { field: 'part_no', title: '型号', align: 'left', width: 140 },
                            { field: 'information', title: '记录项', align: 'left', width: 140 },
                            { field: 'information_value', title: '记录值', align: 'left', width: 140 }
        ]],
        toolbar: '#ToolbarTop'
    });
}

//上侧数据刷新
function topTblRefresh() {
    var param = { viewNeedOperate: 'mesFbInfo', orderBy: JSON.stringify({ create_time: 'desc', serial_no: 'desc', eqm_no: 'desc', information: 'desc' }), where: strBase64('') };
    $('#TblTop').datagrid('clearSelections').datagrid('clearChecked');
    $('#TblTop').datagrid('load', param);
}

//上侧检索按钮单击事件
function topSearchClick() {
    var dateStart = $('#TopToolDatStartTime').datebox('getValue');
    var dateEnd = $('#TopToolDatEndTime').datebox('getValue');
    if (dateEnd === null || dateEnd === '') {
        var today = new Date();
        dateEnd = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate() + ' ' + today.getHours() + ':' + today.getMinutes() + ':' + today.getSeconds();
    }
    if (dateStart === null || dateStart === '') {
        var yesterday = new Date((new Date()).getTime() - 24 * 60 * 60 * 1000);
        dateStart = yesterday.getFullYear() + '-' + (yesterday.getMonth() + 1) + '-' + yesterday.getDate() + ' ' + yesterday.getHours() + ':' + yesterday.getMinutes() + ':' + yesterday.getSeconds();
    }
    var where = "serial_no like '%" + $('#TopToolTxtSerialNo').textbox('getText') + "%' and part_no like '%" + $('#TopToolTxtPartNo').textbox('getText') + "%' and eqm_no ='" + $('#TopToolCmbEqm').combobox('getValue') + "' or (create_time<='" + dateEnd + "' and create_time>='" + dateStart + "')";
    console.log(where);
    var param = { viewNeedOperate: 'mesFbInfo', orderBy: JSON.stringify({ create_time: 'desc', serial_no: 'desc', eqm_no: 'desc', information: 'desc' }), where: strBase64(where) };
    $('#TblTop').datagrid('clearSelections').datagrid('clearChecked');
    $('#TblTop').datagrid('load', param);
}

//上侧生成跟踪卡按钮单击事件
function topRecordClick() {
    var row = $('#TblTop').datagrid('getSelected');
    if (row === null || row.length <= 0) {
        $.messager.alert('警告', '请选中一条记录！', 'warning');
        return;
    }
    $.post('/BackgroundProgram/CreateProductRecord.ashx', { serialNo: row.serial_no }, function (data) {
        if (data === null) {
            $.messager.alert('提示信息', '无法获取结果！', 'error');
            return;
        }
        var msg = JSON.parse(data).msg;
        var fileName = JSON.parse(data).fileName;
        if (msg !== 'success') {
            $.messager.alert('提示信息', msg, 'error');
            return;
        } else {
            $('body').append("<a href='/Tmp/" + fileName + "' id='FilePrivew1'>超连接A</a>");
            $('#FilePrivew1').on('click', function () { window.location.href = '/Tmp/' + fileName; });
            $('#FilePrivew1').click();
        }
    });
}
////上侧编辑按钮单击事件
//function topEditClick() {
//    var row = $('#TblTop').datagrid('getSelected');
//    if (row === null) {
//        $.messager.alert('警告', '未选中要修改的对象', 'warning');
//        return;
//    }
//    $('#TxtDeptNo').textbox('setText', row.dept_no);
//    $('#TxtDeptNo').textbox('disable');
//    $('#TxtDeptName').textbox('setText', row.dept_name);
//    $('#CmbStatusTop').combobox('select', row.status_no);
//    $('#CmbCompany').combobox('select', row.company_no);
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
//                row.dept_no = $('#TxtDeptNo').textbox('getText');
//                row.dept_name = $('#TxtDeptName').textbox('getText');
//                row.status_name = $('#CmbStatusTop').combobox('getText');
//                row.status_no = $('#CmbStatusTop').combobox('getValue');
//                row.company_name = $('#CmbCompany').combobox('getText');
//                row.company_no = $('#CmbCompany').combobox('getValue');
//                $.post('/BackgroundProgram/EditObject.ashx', { viewNeedOperate: 'apoAct', objNeedOperate: JSON.stringify(row) }, function (data) {
//                    if (data === null) {
//                        $.messager.alert('提示信息', '无法获取结果！', 'error');
//                        return;
//                    }
//                    var msg = JSON.parse(data).msg;
//                    if (msg === 'success') {
//                        topTblRefresh();
//                        $('#TopEditFrm').dialog('close');
//                        $('#TxtDeptNo').textbox('enable');
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
//                $('#TxtDeptNo').textbox('enable');
//            }
//        }],
//        onClose: function () {
//            $('#TxtDeptNo').textbox('enable');
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
//                var dept_no = $('#TxtDeptNo').textbox('getText');
//                var dept_name = $('#TxtDeptName').textbox('getText');
//                var status_name = $('#CmbStatusTop').combobox('getText');
//                var status_no = $('#CmbStatusTop').combobox('getValue');
//                var company_name = $('#CmbCompany').combobox('getText');
//                var company_no = $('#CmbCompany').combobox('getValue');
//                $.post('/BackgroundProgram/AddObject.ashx', { viewNeedOperate: 'apoAct', objNeedOperate: JSON.stringify({ dept_no: dept_no, dept_name: dept_name, status_no: status_no, status_name: status_name, company_no: company_no, company_name: company_name }) }, function (data) {
//                    if (data === null) {
//                        $.messager.alert('提示信息', '无法获取结果！', 'error');
//                        return;
//                    }
//                    var msg = JSON.parse(data).msg;
//                    if (msg === 'success') {
//                        topTblRefresh();
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
//    if (rows.length <= 0) {
//        $.messager.alert('警告', '未选中要删除的对象', 'warning');
//        return;
//    }
//    $.messager.confirm('确认', '确认要删除这些数据？', function (r) {
//        if (!r) {
//            return;
//        }
//        $.post('/BackgroundProgram/DeleteObject.ashx', { viewNeedOperate: 'apoAct', objNeedOperate: JSON.stringify(rows) }, function (data) {
//            if (data === null) {
//                $.messager.alert('提示信息', '无法获取结果！', 'error');
//                return;
//            }
//            var msg = JSON.parse(data).msg;
//            if (msg === 'success') {
//                topTblRefresh();
//            }
//            else {
//                $.messager.alert('提示信息', msg, 'error');
//            }
//        });
//    });
//}