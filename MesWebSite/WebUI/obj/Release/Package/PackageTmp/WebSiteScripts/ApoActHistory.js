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
});
//绑定上侧数据
//function bindTopData() {
//    bindStatusTop3();
//    bindCompany();
//}
////初始化上侧表格
function initialTblTop() {
    $('#TblTop').datagrid({
        url: '/BackgroundProgram/GetListPage.ashx',
        title: '审核历史',
        fitColumns: false,
        idField: 'apo_act',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: { viewNeedOperate: 'apoAct', orderBy: JSON.stringify({ act_no: 'desc', ralate_no: 'desc', act_time: 'desc' }), where: strBase64('') },
        columns: [[
            { field: 'apo_item_no', title: '审核内容编号', align: 'left', width: 140 },
                            { field: 'apo_item_name', title: '审核内容名称', align: 'left', width: 140 },
                            { field: 'ralate_no', title: '文件编号', align: 'left', width: 140 },
                            { field: 'ralate_file_name', title: '文件名称', align: 'left', width: 140 },
                            { field: 'ralate_file_extension', title: '文件拓展名', align: 'left', width: 140 },
                            { field: 'act_user_no', title: '审核人编号', align: 'left', width: 140 },
                            { field: 'act_user_name', title: '审核人姓名', align: 'left', width: 140 },
                            { field: 'act_result', title: '审核结果', align: 'left', width: 140 },
                            { field: 'act_time', title: '审核时间', align: 'left', width: 140 },
                            { field: 'act_desc', title: '描述', align: 'left', width: 140 },
                            { field: 'next_item_no', title: '下一审核编号', align: 'left', width: 140 },
                            { field: 'next_item_name', title: '下一审核名称', align: 'left', width: 140 },
                            { field: 'status_no', title: '状态码', align: 'left', width: 140 },
                            { field: 'status_name', title: '状态', align: 'left', width: 140 },
                            { field: 'act_no', title: '审核记录编号', align: 'left', width: 140 },
                            { field: 'apo_no', title: '审核类型', align: 'left', width: 140 },
                            { field: 'step_finished', title: '当前是否完成', align: 'left', width: 140 },
                            { field: 'apo_finished', title: '流程是否完成', align: 'left', width: 140 }
        ]],
        toolbar: '#ToolbarTop'
    });
}

//上侧数据刷新
function topTblRefresh() {
    $('#TblTop').datagrid('clearSelections').datagrid('clearChecked');
    $('#TblTop').datagrid('reload');
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