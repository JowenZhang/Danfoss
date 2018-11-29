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

//绑定上侧数据
function bindTopData() {
    bindStatusTop3();
    bindUserGender();
    bindLoginable();
    bindPwdChangeable();
    bindIsWorker();
    bindCompany();
    bindDept();
    bindFactory();
    bindWorkshop();
    bindLine();
}

//初始化上侧表格
function initialTblTop() {
    $('#TblTop').datagrid({
        url: '/BackgroundProgram/GetListPage.ashx',
        title: '用户',
        fitColumns: false,
        idField: 'user_no',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: { viewNeedOperate: 'sysUser', orderBy: JSON.stringify({ user_no: 'desc' }), where: strBase64('') },
        columns: [[
            { field: 'user_no', title: '用户编号', align: 'left', width: 140 },
                    { field: 'user_name', title: '用户名称', align: 'left', width: 140 },
                    { field: 'status_no', title: '状态码', align: 'left', width: 140 },
                    { field: 'status_name', title: '状态', align: 'left', width: 140 },
                    { field: 'user_card_id', title: '用户卡ID', align: 'left', width: 140 },
                    { field: 'user_card_no', title: '用户卡编号', align: 'left', width: 140 },
                    { field: 'user_pwd', title: '用户密码', align: 'left', width: 140 },
                    { field: 'user_gender', title: '性别', align: 'left', width: 140 },
                    { field: 'loginable', title: "允许登陆", align: 'left', width: 70},
                    { field: 'pwd_changeable', title: '允许修改密码', align: 'left', width: 90 },
                    { field: 'user_position', title: '职位', align: 'left', width: 140 },
                    { field: 'user_email', title: '邮箱', align: 'left', width: 140 },
                    { field: 'user_phone', title: '电话', align: 'left', width: 140 },
                    { field: 'user_mobile', title: '手机', align: 'left', width: 140 },
                    { field: 'user_address', title: '地址', align: 'left', width: 140 },
                    { field: 'company_no', title: '公司', align: 'left', width: 140 },
                    { field: 'dept_no', title: '部门', align: 'left', width: 140 },
                    { field: 'factory_no', title: '工厂', align: 'left', width: 140 },
                    { field: 'workshop_no', title: '车间', align: 'left', width: 140 },
                    { field: 'line_no', title: '产线', align: 'left', width: 140 },
                    { field: 'is_worker', title: '是否为操作工', align: 'left', width: 90 }
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

    $('#TxtUserNo').textbox('setText', row.user_no);
    $('#TxtUserNo').textbox('disable');
    $('#TxtUserName').textbox('setText', row.user_name);
    $('#CmbStatusTop').combobox('select', row.status_no);
    $('#TxtUserCardId').textbox('setText', row.user_card_id);
    $('#TxtUserCardNo').textbox('setText', row.user_card_no);
    $('#TxtUserPwd').textbox('setText', row.user_pwd);
    $('#CmbUserGender').combobox('select', row.user_gender);
    $('#CmbLoginable').combobox('select', row.loginable);
    $('#CmbPwdChangeable').combobox('select', row.loginable);
    $('#TxtUserPosition').textbox('setText', row.user_position);
    $('#TxtUserEmail').textbox('setText', row.user_email);
    $('#TxtUserPhone').textbox('setText', row.user_phone);
    $('#TxtUserMobile').textbox('setText', row.user_mobile);
    $('#TxtUserAddress').textbox('setText', row.user_address);
    $('#CmbCompany').combobox('select', row.company_no);
    $('#CmbDept').combobox('select', row.dept_no);
    $('#CmbFactory').combobox('select', row.factory_no);
    $('#CmbWorkshop').combobox('select', row.workshop_no);
    $('#CmbLine').combobox('select', row.line_no);
    $('#CmbIsWorker').combobox('select', row.is_worker);
    $('#TopEditFrm').dialog({
        title: '添加/编辑窗口',
        height:500,
        modal: true,
        collapsible: true,
        minizable: true,
        maxizable: true,
        resizeable: true,
        buttons: [{
            text: '确认',
            handler: function () {
                row.user_no = $('#TxtUserNo').textbox('getText');
                row.user_name = $('#TxtUserName').textbox('getText');
                row.status_no = $('#CmbStatusTop').combobox('getValue');
                row.status_name = $('#CmbStatusTop').combobox('getText');
                row.user_card_id = $('#TxtUserCardId').textbox('getText');
                row.user_card_no = $('#TxtUserCardNo').textbox('getText');
                row.user_pwd = $('#TxtUserPwd').textbox('getText');
                row.user_gender = $('#CmbUserGender').combobox('getValue');
                row.loginable = $('#CmbLoginable').combobox('getValue');
                row.pwd_changeable = $('#CmbPwdChangeable').combobox('getValue');
                row.user_position = $('#TxtUserPosition').textbox('getText');
                row.user_email = $('#TxtUserEmail').textbox('getText');
                row.user_phone = $('#TxtUserPhone').textbox('getText');
                row.user_mobile = $('#TxtUserMobile').textbox('getText');
                row.user_address = $('#TxtUserAddress').textbox('getText');
                row.company_no = $('#CmbCompany').combobox('getValue');
                row.dept_no = $('#CmbDept').combobox('getValue');
                row.factory_no = $('#CmbFactory').combobox('getValue');
                row.workshop_no = $('#CmbWorkshop').combobox('getValue');
                row.line_no = $('#CmbLine').combobox('getValue');
                row.is_worker = $('#CmbIsWorker').combobox('getValue');
                $.post('/BackgroundProgram/EditObject.ashx', { viewNeedOperate: 'sysUser', objNeedOperate: JSON.stringify(row) }, function (data) {
                    if (data === null) {
                        $.messager.alert('提示信息', '无法获取结果！', 'error');
                        return;
                    }
                    var msg = JSON.parse(data).msg;
                    if (msg === 'success') {
                        $('#TblTop').datagrid('clearSelections').datagrid('clearChecked');
                        $('#TblTop').datagrid("reload");
                        $('#TopEditFrm').dialog('close');
                        $('#TxtUserNo').textbox('enable');
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
                $('#TxtUserNo').textbox('enable');
            }
        }],
        onClose: function () {
            $('#TxtUserNo').combobox('enable');
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
                var user_no = $('#TxtUserNo').textbox('getText');
                var user_name = $('#TxtUserName').textbox('getText');
                var status_no = $('#CmbStatusTop').combobox('getValue');
                var status_name = $('#CmbStatusTop').combobox('getText');
                var user_card_id = $('#TxtUserCardId').textbox('getText');
                var user_card_no = $('#TxtUserCardNo').textbox('getText');
                var user_pwd = $('#TxtUserPwd').textbox('getText');
                var user_gender = $('#CmbUserGender').combobox('getValue');
                var loginable = $('#CmbLoginable').combobox('getValue');
                var pwd_changeable = $('#CmbPwdChangeable').combobox('getValue');
                var user_position = $('#TxtUserPosition').textbox('getText');
                var user_email = $('#TxtUserEmail').textbox('getText');
                var user_phone = $('#TxtUserPhone').textbox('getText');
                var user_mobile = $('#TxtUserMobile').textbox('getText');
                var user_address = $('#TxtUserAddress').textbox('getText');
                var company_no = $('#CmbCompany').combobox('getValue');
                var dept_no = $('#CmbDept').combobox('getValue');
                var factory_no = $('#CmbFactory').combobox('getValue');
                var workshop_no = $('#CmbWorkshop').combobox('getValue');
                var line_no = $('#CmbLine').combobox('getValue');
                var is_worker = $('#CmbIsWorker').combobox('getValue');
                $.post('/BackgroundProgram/AddObject.ashx', { viewNeedOperate: 'sysUser', objNeedOperate: JSON.stringify({ user_no: user_no, user_name: user_name, status_no: status_no, status_name: status_name, user_card_id: user_card_id, user_card_no: user_card_no, user_pwd: user_pwd, user_gender: user_gender, loginable: loginable, pwd_changeable: pwd_changeable, user_position: user_position, user_email: user_email, user_phone: user_phone, user_mobile: user_mobile, user_address: user_address, company_no: company_no, dept_no: dept_no, factory_no: factory_no, workshop_no: workshop_no, line_no: line_no, is_worker: is_worker }) }, function (data) {
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
        $.post('/BackgroundProgram/DeleteObject.ashx', { viewNeedOperate: 'sysUser', objNeedOperate: JSON.stringify(rows) }, function (data) {
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
//绑定下侧数据
function bindBottomData() {
    bindUser();
    bindStatusBottom3();
    bindAuthGroup();
}
//初始化下侧表格
function initialTblBottom() {
    var where = '';
    var rows = $('#TblTop').datagrid('getSelections');
    if (rows.length > 0) {
        where = "user_no='" + rows[0].user_no + "'";
    }
    $('#TblBottom').datagrid({
        url: '/BackgroundProgram/GetListPage.ashx',
        title: '用户权限组',
        fitColumns: false,
        idField: 'id',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: { viewNeedOperate: 'sysUserAuthGroup', orderBy: JSON.stringify({ auth_group_no: 'desc' }), where: strBase64(where) },
        columns: [[
           { field: 'user_no', title: '用户编号', align: 'left', width: 140 },
                    { field: 'user_name', title: '用户名称', align: 'left', width: 140 },
                    { field: 'status_no', title: '状态码', align: 'left', width: 140 },
                    { field: 'status_name', title: '状态', align: 'left', width: 140 },
                    { field: 'auth_group_no', title: '权限组编号', align: 'left', width: 140 },
                    { field: 'auth_group_name', title: '权限组名称', align: 'left', width: 140 },
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
        where = "user_no='" + rows[0].user_no + "'";
    }
    var param = { viewNeedOperate: 'sysUserAuthGroup', orderBy: JSON.stringify({ auth_group_no: 'desc' }), where: strBase64(where) };
    $('#TblBottom').datagrid('load', param);
}

//下侧编辑按钮单击事件
function bottomEditClick() {
    var row = $('#TblBottom').datagrid('getSelected');
    if (row === null) {
        $.messager.alert('警告', '未选中要修改的对象', 'warning');
        return;
    }
    $('#CmbUser').combobox('setValue', row.use_no);
    $('#CmbUser').combobox('disable');
    $('#CmbStatusBottom').combobox('setValue', row.status_no);
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
                row.user_no = $('#CmbUser').combobox('getValue');
                row.user_name = $('#CmbUser').combobox('getText');
                row.status_no = $('#CmbStatusBottom').combobox('getValue');
                row.status_name = $('#CmbStatusBottom').combobox('getText');
                row.auth_group_no = $('#CmbAuthGroup').combobox('getValue');
                row.auth_group_name = $('#CmbAuthGroup').combobox('getText');
                $.post('/BackgroundProgram/EditObject.ashx', { viewNeedOperate: 'sysUserAuthGroup', objNeedOperate: JSON.stringify(row) }, function (data) {
                    if (data === null) {
                        $.messager.alert('提示信息', '无法获取结果！', 'error');
                        return;
                    }
                    var msg = JSON.parse(data).msg;
                    if (msg === 'success') {
                        bottomTblRefresh();
                        $('#BottomEditFrm').dialog('close');
                        $('#CmbUser').combobox('enable');
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
                $('#CmbUser').combobox('enable');
            }
        }],
        onClose: function () {
            $('#CmbUser').combobox('enable');
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
                var user_no = $('#CmbUser').combobox('getValue');
                var user_name = $('#CmbUser').combobox('getText');
                var status_no = $('#CmbStatusBottom').combobox('getValue');
                var status_name = $('#CmbStatusBottom').combobox('getText');
                var auth_group_no = $('#CmbAuthGroup').combobox('getValue');
                var auth_group_name = $('#CmbAuthGroup').combobox('getText');
                $.post('/BackgroundProgram/AddObject.ashx', { viewNeedOperate: 'sysUserAuthGroup', objNeedOperate: JSON.stringify({  user_no: user_no, user_name: user_name, status_no: status_no, status_name: status_name, auth_group_no: auth_group_no, auth_group_name: auth_group_name }) }, function (data) {
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
        $.post('/BackgroundProgram/DeleteObject.ashx', { viewNeedOperate: 'sysUserAuthGroup', objNeedOperate: JSON.stringify(rows) }, function (data) {
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