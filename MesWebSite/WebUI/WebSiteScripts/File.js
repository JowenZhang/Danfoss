$(function () {
    //////绑定上侧数据
    //bindTopData();
    //初始化上侧表格
    initialTblTop();
    //上侧刷新按钮单击事件
    $('#TopToolBtnRefresh').click(function () {
        topTblRefresh();
    });
    //上侧版本更新单击事件
    $('#TopToolBtnVerisonUpdate').click(function () {
        topVerisonUpdateClick();
    });
    ////上侧编辑按钮单击事件
    //$('#TopToolBtnEdit').click(function () {
    //    topEditClick();
    //});
    //上侧新建上传按钮单击事件
    //$('#TopToolBtnAdd').click(function () {
    //    topAddClick();
    //});

    ////上侧审核按钮单击事件
    //$('#TopToolBtnApprove').click(function () {
    //    topApproveClick();
    //});

    ////辅助区通过按钮单击事件
    //$('#AssistToolBtnApprove').click(function () {
    //    assistantApproveClick();
    //});

    ////辅助区驳回按钮单击事件
    //$('#AssistToolBtnReject').click(function () {
    //    assistantRejectClick();
    //});

    ////辅助区取消按钮单击事件
    //$('#AssistToolBtnCancel').click(function () {
    //    assistantCancelClick();
    //});
    //上侧停用按钮单击事件
    $('#TopToolBtnAbort').click(function () {
        topAbortClick();
    });
    //上侧预览按钮单击事件
    $('#TopToolBtnView').click(function () {
        topViewClick();
    });
    //上侧添加附件单击事件
    $('#TopToolBtnAddTrainFile').click(function () {
        topAddTrainFileClick();
    });
    //上侧设定生效日期单击事件
    $('#TopToolBtnSetValidDate').click(function () {
        topSetValidDateClick();
    });
    //上侧删除按钮单击事件
    $('#TopToolBtnDelete').click(function () {
        topDeleteClick();
    });
});

//----------------------上侧---------------------------------------//
////绑定上侧数据
//function bindTopData() {
//    bindEqm();
//    bindFileType();
//}
//初始化上侧表格
function initialTblTop() {
    $('#TblTop').datagrid({
        url: '/BackgroundProgram/GetListPage.ashx',
        title: '文件BOM和参数',
        fitColumns: false,
        idField: 'file_no',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: { viewNeedOperate: 'dmsFile', orderBy: JSON.stringify({ eqm_no: 'desc' ,file_type_no: 'desc' }), where: strBase64("file_status!='未确认'") },
        columns: [[
                    { field: 'file_no', title: '文件编号', align: 'left', width: 140 },
                    { field: 'file_status', title: '文件状态', align: 'left', width: 140 },
                    { field: 'file_name', title: '文件名称', align: 'left', width: 140 },
                    { field: 'file_extension', title: '文件拓展名', align: 'left', width: 140 },
                    { field: 'file_type_name', title: '文件类型', align: 'left', width: 140 },
                    { field: 'eqm_no', title: '工站', align: 'left', width: 140 },
                    { field: 'valid_date_start', title: '生效日期', align: 'left', width: 140 },
                    { field: 'ralate_file_name', title: '培训文件', align: 'left', width: 140 }
        ]],
        toolbar: '#ToolbarTop'
    });
}
//上侧数据刷新
function topTblRefresh() {
    var queryParams = { viewNeedOperate: 'dmsFile', orderBy: JSON.stringify({ file_type_no: 'desc', eqm_no: 'desc' }), where: strBase64("file_status!='未确认'") }
    $('#TblTop').datagrid('clearSelections').datagrid('clearChecked');
    $('#TblTop').datagrid('load', queryParams);
}

////上侧标准编辑按钮单击事件
//function topEditClick() {
//    var row = $('#TblTop').datagrid('getSelected');
//    console.log(row);
//    if (row === null || row.length < 0) {
//        $.messager.alert('警告', '未选中要修改的对象', 'warning');
//        return;
//    }
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
//                $.post('/BackgroundProgram/EditObject.ashx', { viewNeedOperate: 'dmdFile', objNeedOperate: JSON.stringify(row) }, function (data) {
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
////上侧新建上传按钮单击事件
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
//                var eqm_no = $('#CmbEqm').combobox('getValue');
//                var file_type_no = $('#CmbFileType').combobox('getValue');
//                var file_type_name = $('#CmbFileType').combobox('getText');
//                var file_info = $('#FilFile').filebox('getText');
//                var file_desc = $('#TxtFileDesc').textbox('getText');
//                if (file_desc === null || file_desc.length <= 0) {
//                    $.messager.alert('提示信息', '描述必须输入！', 'error');
//                    return;
//                }
//                var file = document.getElementById("filebox_file_id_1").files[0];
//                var row = JSON.stringify({ eqm_no: eqm_no, file_type_no: file_type_no, file_type_name: file_type_name, file_info: file_info, file_desc: file_desc });
//                var fd = new FormData();
//                fd.append('row', row);
//                fd.append('operate', "add");
//                fd.append('files', file);
//                $.ajax({
//                    type: "post",
//                    url: '/BackgroundProgram/ImportFile.ashx',
//                    data: fd,
//                    processData: false,  //tell jQuery not to process the data
//                    contentType: false,  //tell jQuery not to set contentType
//                    //这儿的三个参数其实就是XMLHttpRequest里面带的信息。
//                    success: function (arg, a1, a2) {
//                        msg = JSON.parse(arg).msg;
//                        if (msg === 'success') {
//                            topTblRefresh();
//                            $('#FilFile').filebox('setValue', null);
//                            $('#TopEditFrm').dialog('close');
//                        }
//                        else {
//                            $.messager.alert('提示信息', msg, 'error');
//                        }
//                    },
//                    error: function () {
//                        $.messager.alert('提示信息', "文件导入请求失败！", 'error');
//                    }
//                });
//            }
//        }, {
//            text: '取消',
//            handler: function () {
//                $('#FilFile').filebox('setValue', null);
//                $('#TopEditFrm').dialog('close');
//            }
//        }],
//        onClose: function () {
//            $('#FilFile').filebox('setValue', null);
//            $('#TopEditFrm').dialog('close');
//        }
//    });
//}

////上侧审核按钮单击事件
//function topApproveClick() {
//    var row = $('#TblTop').datagrid('getSelected');
//    if (row === null || row.length < 0) {
//        $.messager.alert('警告', '未选中要审核的对象', 'warning');
//        return;
//    }
//    $('#AssistApproveFrm').dialog({
//        title: '审核文件',
//        width: 700,
//        height: 500,
//        modal: true
//    });
//    $('#TblAssist').datagrid({
//        url: '/BackgroundProgram/GetListApprove.ashx',
//        fitColumns: false,
//        idField: 'apo_item_no',
//        loadMsg: '正在获取后台信息...',
//        fit: false,
//        pagination: false,
//        singleSelect: true,
//        pageSize: 10,
//        pageNumber: 1,
//        pageList: [10, 20, 30],
//        queryParams: { ralateNo: row.file_no, apoNo: row.file_type_no },
//        columns: [[
//                    { field: 'apo_no', title: '审核类型', align: 'left', width: 140 },
//            { field: 'apo_item_no', title: '审核流程编号', align: 'left', width: 140 },
//            { field: 'apo_item_name', title: '审核流程名称', align: 'left', width: 140 },
//            { field: 'act_user_no', title: '审核人编号', align: 'left', width: 140 },
//            { field: 'act_user_name', title: '审核人姓名', align: 'left', width: 140 },
//            { field: 'dept_name', title: '人员部门', align: 'left', width: 140 },
//            { field: 'act_time', title: '审核时间', align: 'left', width: 140 },
//            { field: 'act_result', title: '审核结果', align: 'left', width: 140 }
//        ]],
//        onClickRow: function (index, row) {
//            if (row.act_desc !== null) {
//                $('#TxtHistory').textbox('setValue', row.act_desc);
//            }
//        },
//        toolbar: '#ToolbarAssist'
//    });
//}

////上侧辅助区通过按钮事件
//function assistantApproveClick() {
//    approve('通过');
//}

////上侧辅助区驳回按钮事件
//function assistantRejectClick(){
//    approve('驳回');
//}

////上侧辅助区取消按钮事件
//function assistantCancelClick() {
//    $('#AssistApproveFrm').dialog('close');
//}




//上侧版本更新按钮单击事件
function topVerisonUpdateClick() {
    var oldRow = $('#TblTop').datagrid('getSelected');
    if (oldRow === null || oldRow.length < 0) {
        $.messager.alert('警告', '未选中要修改的对象', 'warning');
        return;
    }
    $('#TopVersionUpdateFrm').dialog({
        title: '版本更新',
        modal: true,
        collapsible: true,
        minizable: true,
        maxizable: true,
        resizeable: true,
        buttons: [{
            text: '确认',
            handler: function () {
                var file_info = $('#NewFilFile').filebox('getText');
                var file_desc = $('#NewTxtFileDesc').textbox('getText');
                if (file_desc === null || file_desc.length <= 0) {
                    $.messager.alert('提示信息', '描述必须输入！', 'error');
                    return;
                }
                var file = document.getElementById("filebox_file_id_1").files[0];
                var row = JSON.stringify({ eqm_no: oldRow.eqm_no, file_type_no: oldRow.file_type_no, file_type_name: oldRow.file_type_name, file_info: file_info, file_desc: file_desc });
                var fd = new FormData();
                fd.append('row', row);
                fd.append('operate', "add");
                fd.append('files', file);
                $.ajax({
                    type: "post",
                    url: '/BackgroundProgram/ImportFile.ashx',
                    data: fd,
                    processData: false,  //tell jQuery not to process the data
                    contentType: false,  //tell jQuery not to set contentType
                    //这儿的三个参数其实就是XMLHttpRequest里面带的信息。
                    success: function (arg, a1, a2) {
                        msg = JSON.parse(arg).msg;
                        if (msg === 'success') {
                            topTblRefresh();
                            $('#NewFilFile').filebox('setValue', null);
                            $('#TopVersionUpdateFrm').dialog('close');
                        }
                        else {
                            $.messager.alert('提示信息', msg, 'error');
                        }
                    },
                    error: function () {
                        $.messager.alert('提示信息', "文件导入请求失败！", 'error');
                    }
                });
            }
        }, {
            text: '取消',
            handler: function () {
                $('#NewFilFile').filebox('setValue', null);
                $('#TopVersionUpdateFrm').dialog('close');
            }
        }],
        onClose: function () {
            $('#NewFilFile').filebox('setValue', null);
            $('#TopVersionUpdateFrm').dialog('close');
        }
    });
}

//上侧文件停用按钮单击事件
function topAbortClick() {
    var row = $('#TblTop').datagrid('getSelected');
    if (row === null || row.length < 0) {
        $.messager.alert('警告', '未选中要修改的对象', 'warning');
        return;
    }
    row.file_status = '停止使用';
    $.post('/BackgroundProgram/EditObject.ashx', { viewNeedOperate: 'dmsFile', objNeedOperate: JSON.stringify(row) }, function (data) {
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
}


//上侧文件预览按钮单击事件
function topViewClick() {
    var row = $('#TblTop').datagrid('getSelected');
    if (row === null || row.length < 0) {
        $.messager.alert('警告', '未选中要修改的对象', 'warning');
        return;
    }
    $.get('/BackgroundProgram/FileView.ashx', { objNeedOperate: JSON.stringify(row) }, function (data) {
        if (data === null) {
            $.messager.alert('提示信息', '无法获取结果！', 'error');
            return;
        }
        var msg = JSON.parse(data).msg;
        if (msg!=='success') {
            $.messager.alert('提示信息', msg, 'error');
            return;
        }else {
            $('body').append("<a href='/Tmp/" + row.file_name + row.file_extension + "' id='FilePrivew1'>超连接A</a>");
            $('#FilePrivew1').on('click', function () { window.location.href = '/Tmp/' + row.file_name + row.file_extension; });
            $('#FilePrivew1').click();
        }
    });
}

//上侧添加培训文件按钮单击事件
function topAddTrainFileClick() {
    var row = $('#TblTop').datagrid('getSelected');
    if (row === null || row.length < 0) {
        $.messager.alert('警告', '未选中要修改的对象', 'warning');
        return;
    }
    $('#TopAddTrainFileFrm').dialog({
        title: '上传培训文件',
        modal: true,
        collapsible: true,
        minizable: true,
        maxizable: true,
        resizeable: true,
        buttons: [{
            text: '确认',
            handler: function () {
                var file_info = $('#FilRalateFileName').filebox('getText');
                var file = document.getElementById("filebox_file_id_2").files[0];
                var fd = new FormData();
                fd.append('row', JSON.stringify(row));
                fd.append('fileInfo', file_info);
                fd.append('files', file);
                $.ajax({
                    type: "post",
                    url: '/BackgroundProgram/AttachFile.ashx',
                    data: fd,
                    processData: false,  //tell jQuery not to process the data
                    contentType: false,  //tell jQuery not to set contentType
                    //这儿的三个参数其实就是XMLHttpRequest里面带的信息。
                    success: function (arg, a1, a2) {
                        msg = JSON.parse(arg).msg;
                        if (msg === 'success') {
                            topTblRefresh();
                            $('#FilRalateFileName').filebox('setValue', null);
                            $('#TopAddTrainFileFrm').dialog('close');
                        }
                        else {
                            $.messager.alert('提示信息', msg, 'error');
                        }
                    },
                    error: function () {
                        $.messager.alert('提示信息', "文件导入请求失败！", 'error');
                    }
                });
            }
        }, {
            text: '取消',
            handler: function () {
                $('#FilRalateFileName').filebox('setValue', null);
                $('#TopAddTrainFileFrm').dialog('close');
            }
        }],
        onClose: function () {
            $('#FilRalateFileName').filebox('setValue', null);
        }
    });
}

//上侧设定生效日期单击事件
function topSetValidDateClick() {
    var row = $('#TblTop').datagrid('getSelected');
    if (row === null || row.length < 0) {
        $.messager.alert('警告', '未选中要修改的对象', 'warning');
        return;
    }
    $('#TopSetValidDateFrm').dialog({
        title: '设定生效日期',
        modal: true,
        collapsible: true,
        minizable: true,
        maxizable: true,
        resizeable: true,
        buttons: [{
            text: '确认',
            handler: function () {
                var validStartDate = $('#DatValidDateStart').datebox('getValue');
                $.post('/BackgroundProgram/SetValidDate.ashx', { validStartDate: validStartDate, row: JSON.stringify(row) }, function (data) {
                    if (data === null) {
                        $.messager.alert('提示信息', '无法获取结果！', 'error');
                        return;
                    }
                    var msg = JSON.parse(data).msg;
                    if (msg === 'success') {
                        $('#TopSetValidDateFrm').dialog('close');
                        topTblRefresh();
                    }
                    else {
                        $.messager.alert('提示信息', msg, 'error');
                    }
                });
            }
        }, {
            text: '取消',
            handler: function () {
                $('#TopSetValidDateFrm').dialog('close');
            }
        }]
    });
}

//文件审核，通过或驳回
//function approve(result) {
//    var rowFile = $('#TblTop').datagrid('getSelected');
//    if (rowFile === null || rowFile.length <= 0) {
//        $.messager.alert('警告', '未选中要修改的对象', 'warning');
//        return;
//    }
//    var rowApoActs = $('#TblAssist').datagrid('getRows');
//    if (rowApoActs === null || rowApoActs.length <= 0) {
//        $.messager.alert('警告', '未找到审核动作', 'warning');
//        return;
//    }
//    var txtDesc = $('#TxtDesc').textbox('getText');
//    if (txtDesc === null || txtDesc.length <= 0) {
//        $.messager.alert('警告', '描述不可为空！', 'warning');
//        return;
//    }
//    var rowApoAct = null;
//    var step = 0;
//    var rowsTmp;
//    for (var i = 0; i < rowApoActs.length-1; i++) {
//        if ((rowApoActs[i].act_result === null || rowApoActs[i].act_result === '')) {
//            if ((rowApoActs[i + 1].act_result !== null || rowApoActs[i + 1].act_result !== '')) {
//                rowApoAct = rowApoActs[i];
//                break;
//            }
//            else {
//                continue;
//            }
//        }
//        else {
//            if ((rowApoActs[i+1].act_result === null || rowApoActs[i+1].act_result === '')) {
//                rowApoAct = rowApoActs[i];
//                break;
//            }
//            else {
//                continue;
//            }
//        }
//    }
//    if (rowApoAct === null || rowApoAct.length <= 0) {
//        $.messager.alert('警告', '未选中要修改的对象', 'warning');
//        return;
//    }
//    rowApoAct.act_desc = txtDesc;
//    $.post('/BackgroundProgram/Approve.ashx', { rowFile: JSON.stringify(rowFile), rowApoAct: JSON.stringify(rowApoAct), approveResult: result }, function (data) {
//        if (data === null) {
//            $.messager.alert('提示信息', '无法获取结果！', 'error');
//            return;
//        }
//        var msg = JSON.parse(data).msg;
//        if (msg === 'success') {

//            topTblRefresh();
//            $('#AssistApproveFrm').dialog('close');
//        }
//        else {
//            $.messager.alert('提示信息', msg, 'error');
//        }
//    });
//}
//上侧删除按钮单击事件
function topDeleteClick() {
    var row = $('#TblTop').datagrid('getSelected');
    if (row === null || row.length <= 0) {
        $.messager.alert('警告', '未选中要删除的对象', 'warning');
        return;
    }
    $.messager.confirm('确认', '确认要删除这些数据？', function (r) {
        if (!r) {
            return;
        }
        $.post('/BackgroundProgram/DeleteFile.ashx', { dmsFile: JSON.stringify(row) }, function (data) {
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
//----------------------（上半部分）---------------------------------------//
