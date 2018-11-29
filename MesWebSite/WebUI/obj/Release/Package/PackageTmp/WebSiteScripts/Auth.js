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
//绑定上侧数据
function bindTopData() {
    bindStatusTop3();
}
//初始化上侧表格
function initialTblTop() {
    $('#TblTop').datagrid({
        url: '/BackgroundProgram/GetListPage.ashx',
        title: '权限组',
        fitColumns: false,
        idField: 'auth_group_no',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: { viewNeedOperate: 'sysAuthGroup', orderBy: JSON.stringify({ auth_group_no: 'desc' }), where: strBase64('') },
        columns: [[
            { field: 'auth_group_no', title: '权限组编号', align: 'left', width: 140 },
            { field: 'auth_group_name', title: '权限组名称', align: 'left', width: 140 },
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
    $('#TxtAuthGroupNo').textbox('setText', row.auth_group_no);
    $('#TxtAuthGroupNo').textbox('disable');
    $('#TxtAuthGroupName').textbox('setText', row.auth_group_name);
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
                row.auth_group_no = $('#TxtAuthGroupNo').textbox('getText');
                row.auth_group_name = $('#TxtAuthGroupName').textbox('getText');
                row.status_name = $('#CmbStatusTop').combobox('getText');
                row.status_no = $('#CmbStatusTop').combobox('getValue');
                $.post('/BackgroundProgram/EditObject.ashx', { viewNeedOperate: 'sysAuthGroup', objNeedOperate: JSON.stringify(row) }, function (data) {
                    if (data === null) {
                        $.messager.alert('提示信息', '无法获取结果！', 'error');
                        return;
                    }
                    var msg = JSON.parse(data).msg;
                    if (msg === 'success') {
                        $('#TblTop').datagrid('clearSelections').datagrid('clearChecked');
                        $('#TblTop').datagrid("reload");
                        $('#TopEditFrm').dialog('close');
                        $('#TxtAuthGroupNo').textbox('enable');
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
                $('#TxtAuthGroupNo').textbox('enable');
            }
        }],
        onClose: function () {
            $('#TxtAuthGroupNo').textbox('enable');
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
                var auth_group_no = $('#TxtAuthGroupNo').textbox('getText');
                var auth_group_name = $('#TxtAuthGroupName').textbox('getText');
                var status_name = $('#CmbStatusTop').combobox('getText');
                var status_no = $('#CmbStatusTop').combobox('getValue');
                $.post('/BackgroundProgram/AddObject.ashx', { viewNeedOperate: 'sysAuthGroup', objNeedOperate: JSON.stringify({ auth_group_no: auth_group_no, auth_group_name: auth_group_name, status_no: status_no, status_name: status_name }) }, function (data) {
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
        $.post('/BackgroundProgram/DeleteObject.ashx', { viewNeedOperate: 'sysAuthGroup', objNeedOperate: JSON.stringify(rows) }, function (data) {
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
    bindAuthGroup();
    bindMenu();
    bindStatusBottom3();
}

//初始化下侧表格
function initialTblBottom() {
    var where = '';
    var rows = $('#TblTop').datagrid('getSelections');
    if (rows.length > 0) {
        where = "auth_group_no='" + rows[0].auth_group_no + "'";
    }
    $('#TblBottom').datagrid({
        url: '/BackgroundProgram/GetListPage.ashx',
        title: '权限',
        fitColumns: false,
        idField: 'auth_no',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: { viewNeedOperate: 'sysAuth', orderBy: JSON.stringify({ auth_no: 'desc' }), where: strBase64(where) },
        columns: [[
            { field: 'auth_no', title: '权限编号', align: 'left', width: 140 },
            { field: 'auth_name', title: '权限名称', align: 'left', width: 140 },
            { field: 'status_no', title: '状态码', align: 'left', width: 140 },
            { field: 'status_name', title: '状态', align: 'left', width: 140 },
            { field: 'auth_group_no', title: '权限组编号', align: 'left', width: 140 },
            { field: 'auth_group_name', title: '权限组名称', align: 'left', width: 140 },
            { field: 'menu_no', title: '菜单编号', align: 'left', width: 140 }
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
        where = "auth_group_no='" + rows[0].auth_group_no + "'";
    }
    var param = { viewNeedOperate: 'sysAuth', orderBy: JSON.stringify({ auth_no: 'desc' }), where: strBase64(where) };
    $('#TblBottom').datagrid('load', param);
}

//下侧编辑按钮单击事件
function bottomEditClick() {
    var row = $('#TblBottom').datagrid('getSelected');
    if (row === null) {
        $.messager.alert('警告', '未选中要修改的对象', 'warning');
        return;
    }
    $('#TxtAuthNo').textbox('setText', row.auth_no);
    $('#TxtAuthNo').textbox('disable');
    $('#TxtAuthName').textbox('setText', row.auth_name);
    $('#CmbStatusBottom').combobox('setValue', row.status_no);
    $('#CmbMenu').combobox('setValue', row.menu_no);
    $('#CmbAuthGroup').combobox('setValue', row.auth_group_no);
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
                row.auth_no = $('#TxtAuthNo').textbox('getText');
                row.auth_name = $('#TxtAuthName').textbox('getText');
                row.status_no = $('#CmbStatusBottom').combobox('getValue');
                row.status_name = $('#CmbStatusBottom').combobox('getText');
                row.auth_group_no = $('#CmbAuthGroup').combobox('getValue');
                row.auth_group_name = $('#CmbAuthGroup').combobox('getText');
                row.menu_no = $('#CmbMenu').combobox('getValue');
                $.post('/BackgroundProgram/EditObject.ashx', { viewNeedOperate: 'sysAuth', objNeedOperate: JSON.stringify(row) }, function (data) {
                    if (data === null) {
                        $.messager.alert('提示信息', '无法获取结果！', 'error');
                        return;
                    }
                    var msg = JSON.parse(data).msg;
                    if (msg === 'success') {
                        bottomTblRefresh();
                        $('#BottomEditFrm').dialog('close');
                        $('#TxtAuthNo').textbox('enable');
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
                $('#TxtAuthNo').textbox('enable');
            }
        }],
        onClose: function () {
            $('#TxtAuthNo').textbox('disable');
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
                var auth_no = $('#TxtAuthNo').textbox('getText');
                var auth_name = $('#TxtAuthName').textbox('getText');
                var status_no = $('#CmbStatusBottom').combobox('getValue');
                var status_name = $('#CmbStatusBottom').combobox('getText');
                var auth_group_no = $('#CmbAuthGroup').combobox('getValue');
                var auth_group_name = $('#CmbAuthGroup').combobox('getText');
                var menu_no = $('#CmbMenu').combobox('getValue');
                $.post('/BackgroundProgram/AddObject.ashx', { viewNeedOperate: 'sysAuth', objNeedOperate: JSON.stringify({ auth_no: auth_no, auth_name: auth_name, status_no: status_no, status_name: status_name, auth_group_no: auth_group_no, auth_group_name: auth_group_name, menu_no: menu_no }) }, function (data) {
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
        $.post('/BackgroundProgram/DeleteObject.ashx', { viewNeedOperate: 'sysAuth', objNeedOperate: JSON.stringify(rows) }, function (data) {
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