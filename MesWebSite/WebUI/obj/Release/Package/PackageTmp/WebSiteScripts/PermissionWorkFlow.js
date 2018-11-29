$(function () {
    //绑定上侧数据
    bindStatusTop3();
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
    //绑定下侧数据
    bindBottomData();
    //初始化下侧表格
    initialTblBottom();
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
//初始化上侧表格
function initialTblTop() {
    $('#TblTop').datagrid({
        url: '/BackgroundProgram/GetListPage.ashx',
        title: '审核流程',
        fitColumns: false,
        idField: 'apo_no',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: { viewNeedOperate: 'apo', orderBy: JSON.stringify({ apo_no: 'desc' }), where: strBase64('') },
        columns: [[
            { field: 'apo_no', title: '审核流程编号', align: 'left', width: 140 },
                    { field: 'apo_name', title: '审核流程姓名', align: 'left', width: 140 },
                    { field: 'status_no', title: '状态码', align: 'left', width: 140 },
                    { field: 'status_name', title: '状态', align: 'left', width: 140 }
        ]],
        toolbar: '#ToolbarTop',
        onClickRow: function (index, row) {
            reloadTblBottom();
        }
    });
}

//上侧数据刷新
function topTblRefresh() {
    $('#TblTop').datagrid('clearSelections').datagrid('clearChecked');
    $('#TblTop').datagrid('reload');
    $('#TblBottom').datagrid('clearSelections').datagrid('clearChecked');
    reloadTblBottom();
}

//上侧编辑按钮单击事件
function topEditClick() {
    var row = $('#TblTop').datagrid('getSelected');
    if (row === null) {
        $.messager.alert('警告', '未选中要修改的对象', 'warning');
        return;
    }
    $('#TxtApoNo').textbox('setText', row.apo_no);
    $('#TxtApoNo').textbox('disable');
    $('#TxtApoName').textbox('setText', row.apo_name);
    $('#CmbStatusTop').combobox('select', row.status_no);
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
                row.apo_no = $('#TxtApoNo').textbox('getText');
                row.apo_name = $('#TxtApoName').textbox('getText');
                row.status_name = $('#CmbStatusTop').combobox('getText');
                row.status_no = $('#CmbStatusTop').combobox('getValue');
                $.post('/BackgroundProgram/EditObject.ashx', { viewNeedOperate: 'apo', objNeedOperate: JSON.stringify(row) }, function (data) {
                    if (data === null) {
                        $.messager.alert('提示信息', '无法获取结果！', 'error');
                        return;
                    }
                    var msg = JSON.parse(data).msg;
                    if (msg === 'success') {
                        $('#TblTop').datagrid('clearSelections').datagrid('clearChecked');
                        $('#TblTop').datagrid("reload");
                        $('#TopEditFrm').dialog('close');
                        $('#TxtApoNo').textbox('enable');
                        bindBottomData();
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
                $('#TxtApoNo').textbox('enable');
            }
        }],
        onClose: function () {
            $('#TxtApoNo').textbox('enable');
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
                var apo_no = $('#TxtApoNo').textbox('getText');
                var apo_name = $('#TxtApoName').textbox('getText');
                var status_name = $('#CmbStatusTop').combobox('getText');
                var status_no = $('#CmbStatusTop').combobox('getValue');
                $.post('/BackgroundProgram/AddObject.ashx', { viewNeedOperate: 'apo', objNeedOperate: JSON.stringify({ apo_no: apo_no, apo_name: apo_name, status_no: status_no, status_name: status_name }) }, function (data) {
                    if (data === null) {
                        $.messager.alert('提示信息', '无法获取结果！', 'error');
                        return;
                    }
                    var msg = JSON.parse(data).msg;
                    if (msg === 'success') {
                        $('#TblTop').datagrid('clearSelections').datagrid('clearChecked');
                        $('#TblTop').datagrid("reload");
                        $('#TopEditFrm').dialog('close');
                        bindBottomData();
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
        $.post('/BackgroundProgram/DeleteObject.ashx', { viewNeedOperate: 'apo', objNeedOperate: JSON.stringify(rows) }, function (data) {
            if (data === null) {
                $.messager.alert('提示信息', '无法获取结果！', 'error');
                return;
            }
            var msg = JSON.parse(data).msg;
            if (msg === 'success') {
                $('#TblTop').datagrid('clearSelections').datagrid('clearChecked');
                $('#TblTop').datagrid("reload");
                bindBottomData();
            }
            else {
                $.messager.alert('提示信息', msg, 'error');
            }
        });
    });
}
////----------------------权限组（上半部分）---------------------------------------//
////----------------------权限（下半部分）---------------------------------------//
//绑定下侧数据
function bindBottomData() {
    bindStatusBottom3();
    bindApo();
    bindUser();
}
//初始化下侧表格
function initialTblBottom() {
    var where = '';
    var rows = $('#TblTop').datagrid('getSelections');
    if (rows.length > 0) {
        where = "apo_no='" + rows[0].apo_no + "'";
    }
    $('#TblBottom').datagrid({
        url: '/BackgroundProgram/GetListPage.ashx',
        title: '审核流',
        fitColumns: false,
        idField: 'apo_item_no',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: { viewNeedOperate: 'apoItem', orderBy: JSON.stringify({ apo_item_no: 'desc' }), where: strBase64(where) },
        columns: [[
            { field: 'apo_item_no', title: '流程子项编号', align: 'left', width: 140 },
                    { field: 'apo_item_name', title: '流程子项名称', align: 'left', width: 140 },
                    { field: 'status_no', title: '状态码', align: 'left', width: 140 },
                    { field: 'status_name', title: '状态', align: 'left', width: 140 },
                    { field: 'apo_no', title: '审核流程编号', align: 'left', width: 140 },
                    { field: 'next_item_no', title: '下一子项编号', align: 'left', width: 140 },
                    { field: 'apo_index', title: '顺序号', align: 'left', width: 140 },
                    { field: 'apo_user_no', title: '当前子项处理人', align: 'left', width: 140 },
                    { field: 'apo_user_name', title: '当前子项处理人姓名', align: 'left', width: 170 }
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
        where = "apo_no='" + rows[0].apo_no + "'";
    }
    var param = { viewNeedOperate: 'apoItem', orderBy: JSON.stringify({ apo_item_no: 'desc' }), where: strBase64(where) };
    $('#TblBottom').datagrid('load', param);
}

//下侧编辑按钮单击事件
function bottomEditClick() {
    var row = $('#TblBottom').datagrid('getSelected');
    if (row === null) {
        $.messager.alert('警告', '未选中要修改的对象', 'warning');
        return;
    }
    $('#TxtApoItemNo').textbox('setText', row.apo_item_no);
    $('#TxtApoItemNo').textbox('disable');
    $('#TxtApoItemName').textbox('setText', row.apo_item_name);    
    $('#CmbApo').combobox('setValue', row.apo_no);
    $('#CmbStatusBottom').combobox('setValue', row.status_no);
    $('#TxtApoIndex').textbox('setText', row.apo_index);
    $('#TxtNextItemNo').textbox('setText', row.next_item_no);
    $('#CmbUser').combobox('setValue', row.apo_user_no);
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
                row.auth_no = $('#TxtApoItemNo').textbox('getText');
                row.auth_name = $('#TxtAuthName').textbox('getText');
                row.apo_no = $('#CmbApo').combobox('getValue');
                row.apo_name = $('#CmbApo').combobox('getText');
                row.status_no = $('#CmbStatusBottom').combobox('getValue');
                row.status_name = $('#CmbStatusBottom').combobox('getText');
                row.apo_index = $('#TxtApoIndex').textbox('getText');
                row.next_item_no = $('#TxtNextItemNo').textbox('getText');
                row.apo_user_no = $('#CmbUser').combobox('getValue');
                row.apo_user_name = $('#CmbUser').combobox('getText');
                $.post('/BackgroundProgram/EditObject.ashx', { viewNeedOperate: 'apoItem', objNeedOperate: JSON.stringify(row) }, function (data) {
                    if (data === null) {
                        $.messager.alert('提示信息', '无法获取结果！', 'error');
                        return;
                    }
                    var msg = JSON.parse(data).msg;
                    if (msg === 'success') {
                        bottomTblRefresh();
                        $('#BottomEditFrm').dialog('close');
                        $('#TxtApoItemNo').textbox('enable');
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
                $('#TxtApoItemNo').textbox('enable');
            }
        }],
        onClose:function (){
            $('#TxtApoItemNo').textbox('enable');
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
                var auth_no = $('#TxtApoItemNo').textbox('getText');
                var auth_name = $('#TxtAuthName').textbox('getText');
                var apo_no = $('#CmbApo').combobox('getValue');
                var apo_name = $('#CmbApo').combobox('getText');
                var status_no = $('#CmbStatusBottom').combobox('getValue');
                var status_name = $('#CmbStatusBottom').combobox('getText');
                var apo_index = $('#TxtApoIndex').textbox('getText');
                var next_item_no = $('#TxtNextItemNo').textbox('getText');
                var apo_user_no = $('#CmbUser').combobox('getValue');
                var apo_user_name = $('#CmbUser').combobox('getText');
                $.post('/BackgroundProgram/AddObject.ashx', { viewNeedOperate: 'apoItem', objNeedOperate: JSON.stringify({ id: row.id, auth_no: auth_no, auth_name: auth_name, apo_no: apo_no, apo_name: apo_name, status_no: status_no, status_name: status_name, apo_index: apo_index, next_item_no: next_item_no, apo_user_no: apo_user_no, apo_user_name: apo_user_name }) }, function (data) {
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
        $.post('/BackgroundProgram/DeleteObject.ashx', { viewNeedOperate: 'apoItem', objNeedOperate: JSON.stringify(rows) }, function (data) {
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