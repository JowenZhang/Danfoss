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
    //bindStatusTop3();
    //bindCompany();
}
//初始化上侧表格
function initialTblTop() {
    $('#TblTop').datagrid({
        url: '/BackgroundProgram/GetListPage.ashx',
        title: '系统设置',
        fitColumns: false,
        idField: 'setting_no',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: { viewNeedOperate: 'sysSetting', orderBy: JSON.stringify({ setting_no: 'desc' }), where: strBase64('') },
        columns: [[
            { field: 'setting_no', title: '参数编号', align: 'left', width: 140 },
                        { field: 'setting_display_name', title: '参数名称', align: 'left', width: 140 },
                        { field: 'setting_value', title: '参数值', align: 'left', width: 140 }
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
    $('#TxtSettingNo').textbox('setText', row.setting_no);
    $('#TxtSettingNo').textbox('disable');
    $('#TxtSettingDisplayName').textbox('setText', row.setting_display_name);
    $('#TxtSettingValue').textbox('setText', row.setting_value);
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
                row.setting_no = $('#TxtSettingNo').textbox('getText');
                row.setting_display_name = $('#TxtSettingDisplayName').textbox('getText');
                row.setting_value = $('#TxtSettingValue').textbox('getText');
                $.post('/BackgroundProgram/EditObject.ashx', { viewNeedOperate: 'sysSetting', objNeedOperate: JSON.stringify( row ) }, function (data) {
                    if (data === null) {
                        $.messager.alert('提示信息', '无法获取结果！', 'error');
                        return;
                    }
                    var msg = JSON.parse(data).msg;
                    if (msg === 'success') {
                        topTblRefresh();
                        $('#TopEditFrm').dialog('close');
                        $('#TxtSettingNo').textbox('enable');
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
                $('#TxtSettingNo').textbox('enable');
            }
        }],
        onClose: function () {
            $('#TxtSettingNo').textbox('enable');
        }
    });
}

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
//                 var setting_no = $('#TxtSettingNo').textbox('getText');
//var setting_display_name = $('#TxtSettingDisplayName').textbox('getText');
//var setting_value = $('#TxtSettingValue').textbox('getText');
//                $.post('/BackgroundProgram/AddObject.ashx', { viewNeedOperate: 'sysSetting', objNeedOperate: JSON.stringify({ setting_no: setting_no, setting_display_name: setting_display_name, setting_value: setting_value }) }, function (data) {
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
//        $.post('/BackgroundProgram/DeleteObject.ashx', { viewNeedOperate: 'sysSetting', objNeedOperate: JSON.stringify(rows) }, function (data) {
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