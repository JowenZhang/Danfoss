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
    bindStatusTop3();
    bindFactory();
    bindWorkshop();
    bindLine();
}
//初始化上侧表格
function initialTblTop() {
    $('#TblTop').datagrid({
        url: '/BackgroundProgram/GetListPage.ashx',
        title: '工站设备',
        fitColumns: false,
        idField: 'eqm_no',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: { viewNeedOperate: 'pdmEqm', orderBy: JSON.stringify({ eqm_no: 'desc' }), where: strBase64('') },
        columns: [[
            { field: 'eqm_no', title: '设备编号', align: 'left', width: 140 },
                    { field: 'eqm_name', title: '设备名称', align: 'left', width: 140 },
                    { field: 'status_no', title: '状态码', align: 'left', width: 140 },
                    { field: 'status_name', title: '状态', align: 'left', width: 140 },
                    { field: 'eqm_index', title: '设备序号', align: 'left', width: 140 },
                    { field: 'wkc_no', title: '工作中心编号', align: 'left', width: 140 }
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
    $('#TxtEqmNo').textbox('setText', row.eqm_no);
    $('#TxtEqmNo').textbox('disable');
    $('#TxtEqmName').textbox('setText', row.eqm_name);
    $('#CmbStatusTop').combobox('select', row.status_no);
    $('#NumEqmIndex').numberspinner('setValue', row.eqm_index);
    $('#CmbWkc').combobox('select', row.wkc_no);
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
                row.eqm_no = $('#TxtEqmNo').textbox('getText');
                row.eqm_name = $('#TxtEqmName').textbox('getText');
                row.status_no = $('#CmbStatusTop').combobox('getValue');
                row.status_name = $('#CmbStatusTop').combobox('getText');
                row.eqm_index = $('#NumEqmIndex').numberspinner('getValue');
                row.wkc_no = $('#CmbWkc').combobox('getValue');
                $.post('/BackgroundProgram/EditObject.ashx', { viewNeedOperate: 'pdmEqm', objNeedOperate: JSON.stringify(row) }, function (data) {
                    if (data === null) {
                        $.messager.alert('提示信息', '无法获取结果！', 'error');
                        return;
                    }
                    var msg = JSON.parse(data).msg;
                    if (msg === 'success') {
                        topTblRefresh();
                        $('#TopEditFrm').dialog('close');
                        $('#TxtEqmNo').textbox('enable');
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
                $('#TxtEqmNo').textbox('enable');
            }
        }],
        onClose: function () {
            $('#TxtEqmNo').textbox('enable');
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
                var eqm_no = $('#TxtEqmNo').textbox('getText');
                var eqm_name = $('#TxtEqmName').textbox('getText');
                var status_no = $('#CmbStatusTop').combobox('getValue');
                var status_name = $('#CmbStatusTop').combobox('getText');
                var eqm_index = $('#NumEqmIndex').numberspinner('getValue');
                var wkc_no = $('#CmbWkc').combobox('getValue');
                $.post('/BackgroundProgram/AddObject.ashx', { viewNeedOperate: 'pdmEqm', objNeedOperate: JSON.stringify({ eqm_no: eqm_no, eqm_name: eqm_name, status_no: status_no, status_name: status_name, eqm_index: eqm_index, wkc_no: wkc_no }) }, function (data) {
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
        $.post('/BackgroundProgram/DeleteObject.ashx', { viewNeedOperate: 'pdmEqm', objNeedOperate: JSON.stringify(rows) }, function (data) {
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