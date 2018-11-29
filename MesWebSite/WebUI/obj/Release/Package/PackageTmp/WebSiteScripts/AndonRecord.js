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
    bindStatusTop5();
    bindEqm();
    bindAndonType();
    bindDept();
}
//初始化上侧表格
function initialTblTop() {
    $('#TblTop').datagrid({
        url: '/BackgroundProgram/GetListPage.ashx',
        title: '安灯历史',
        fitColumns: false,
        idField: 'andon_no',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: { viewNeedOperate: 'adn', orderBy: JSON.stringify({ andon_no: 'desc' }), where: strBase64('') },
        columns: [[
            { field: 'andon_no', title: '记录编号', align: 'left', width: 140 },
                    { field: 'status_no', title: '状态码', align: 'left', width: 140 },
                    { field: 'status_name', title: '状态', align: 'left', width: 140 },
                    { field: 'andon_type_no', title: '呼叫类型编号', align: 'left', width: 140 },
                    { field: 'andon_type_name', title: '呼叫类型名称', align: 'left', width: 140 },
                    { field: 'dept_no', title: '呼叫部门编号', align: 'left', width: 140 },
                    { field: 'andon_music_no', title: '声音文件名', align: 'left', width: 140 },
                    { field: 'eqm_no', title: '来源设备', align: 'left', width: 140 },
                    { field: 'call_time', title: '呼叫时间', align: 'left', width: 140 },
                    { field: 'reply_time', title: '响应时间', align: 'left', width: 140 }
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
    $('#TxtAndonNo').textbox('setText', row.andon_no);
    $('#TxtAndonNo').textbox('disable');
    $('#CmbStatusTop').combobox('select', row.status_no);
    $('#CmbEqm').combobox('select', row.eqm_no);
    $('#CmbAndonType').combobox('select', row.andon_type_no);
    $('#CmbDept').combobox('select', row.dept_no);
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
                row.andon_no = $('#TxtAndonNo').textbox('getText');
                row.status_no = $('#CmbStatusTop').combobox('getValue');
                row.status_name = $('#CmbStatusTop').combobox('getText');
                row.eqm_no = $('#CmbEqm').combobox('getValue');
                row.eqm_name = $('#CmbEqm').combobox('getText');
                row.andon_type_no = $('#CmbAndonType').combobox('getValue');
                row.andon_type_name = $('#CmbAndonType').combobox('getText');
                row.dept_no = $('#CmbDept').combobox('getValue');
                //row.dept_name = $('#CmbDept').combobox('getText');
                $.post('/BackgroundProgram/EditObject.ashx', { viewNeedOperate: 'adn', objNeedOperate: JSON.stringify(row) }, function (data) {
                    if (data === null) {
                        $.messager.alert('提示信息', '无法获取结果！', 'error');
                        return;
                    }
                    var msg = JSON.parse(data).msg;
                    if (msg === 'success') {
                        topTblRefresh();
                        $('#TopEditFrm').dialog('close');
                        $('#TxtAndonNo').textbox('enable');
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
                $('#TxtAndonNo').textbox('enable');
            }
        }],
        onClose: function () {
            $('#TxtAndonNo').textbox('enable');
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
                var andon_no = $('#TxtAndonNo').textbox('getText');
                var status_no = $('#CmbStatusTop').combobox('getValue');
                var status_name = $('#CmbStatusTop').combobox('getText');
                var eqm_no = $('#CmbEqm').combobox('getValue');
                var eqm_name = $('#CmbEqm').combobox('getText');
                var andon_type_no = $('#CmbAndonType').combobox('getValue');
                var andon_type_name = $('#CmbAndonType').combobox('getText');
                var dept_no = $('#CmbDept').combobox('getValue');
                $.post('/BackgroundProgram/AddObject.ashx', { viewNeedOperate: 'adn', objNeedOperate: JSON.stringify({ andon_no: andon_no, status_no: status_no, status_name: status_name, eqm_no: eqm_no, eqm_name: eqm_name, andon_type_no: andon_type_no, andon_type_name: andon_type_name, dept_no: dept_no}) }, function (data) {
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
        $.post('/BackgroundProgram/DeleteObject.ashx', { viewNeedOperate: 'adn', objNeedOperate: JSON.stringify(rows) }, function (data) {
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