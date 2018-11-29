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
        title: '工作中心',
        fitColumns: false,
        idField: 'wkc_no',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: { viewNeedOperate: 'pdmWkc', orderBy: JSON.stringify({ wkc_no: 'desc' }), where: strBase64('') },
        columns: [[
            { field: 'wkc_no', title: '工作中心编号', align: 'left', width: 140 },
                    { field: 'wkc_name', title: '工作中心名称', align: 'left', width: 140 },
                    { field: 'status_no', title: '状态码', align: 'left', width: 140 },
                    { field: 'status_name', title: '状态', align: 'left', width: 140 },
                    { field: 'factory_no', title: '工厂编号', align: 'left', width: 140 },
                    { field: 'workshop_no', title: '车间编号', align: 'left', width: 140 },
                    { field: 'line_no', title: '产线编号', align: 'left', width: 140 }
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
    $('#TxtWkcNo').textbox('setText', row.wkc_no);
    $('#TxtWkcNo').textbox('disable');
    $('#TxtWkcName').textbox('setText', row.wkc_name);
    $('#CmbStatusTop').combobox('select', row.status_no);
    $('#CmbFactory').combobox('select', row.factory_no);
    $('#CmbWorkshop').combobox('select', row.workshop_no);
    $('#CmbLine').combobox('select', row.line_no);
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
                row.wkc_no = $('#TxtWkcNo').textbox('getText');
                row.wkc_name = $('#TxtWkcName').textbox('getText');
                row.status_no = $('#CmbStatusTop').combobox('getValue');
                row.status_name = $('#CmbStatusTop').combobox('getText');
                row.factory_no = $('#CmbFactory').combobox('getValue');
                row.workshop_no = $('#CmbWorkshop').combobox('getValue');
                row.line_no = $('#CmbLine').combobox('getValue');
                $.post('/BackgroundProgram/EditObject.ashx', { viewNeedOperate: 'pdmWkc', objNeedOperate: JSON.stringify(row) }, function (data) {
                    if (data === null) {
                        $.messager.alert('提示信息', '无法获取结果！', 'error');
                        return;
                    }
                    var msg = JSON.parse(data).msg;
                    if (msg === 'success') {
                        topTblRefresh();
                        $('#TopEditFrm').dialog('close');
                        $('#TxtWkcNo').textbox('enable');
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
                $('#TxtWkcNo').textbox('enable');
            }
        }],
        onClose: function () {
            $('#TxtWkcNo').textbox('enable');
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
                var wkc_no = $('#TxtWkcNo').textbox('getText');
                var wkc_name = $('#TxtWkcName').textbox('getText');
                var status_no = $('#CmbStatusTop').combobox('getValue');
                var status_name = $('#CmbStatusTop').combobox('getText');
                var factory_no = $('#CmbFactory').combobox('getValue');
                var workshop_no = $('#CmbWorkshop').combobox('getValue');
                var line_no = $('#CmbLine').combobox('getValue');
                $.post('/BackgroundProgram/AddObject.ashx', { viewNeedOperate: 'pdmWkc', objNeedOperate: JSON.stringify({ wkc_no: wkc_no, wkc_name: wkc_name, status_no: status_no, status_name: status_name, factory_no: factory_no, workshop_no: workshop_no, line_no: line_no }) }, function (data) {
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
        $.post('/BackgroundProgram/DeleteObject.ashx', { viewNeedOperate: 'pdmWkc', objNeedOperate: JSON.stringify(rows) }, function (data) {
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