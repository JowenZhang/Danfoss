$(function () {
    //初始化上侧表格
    initialTblTop();
    //上侧刷新按钮单击事件
    $('#TopToolBtnRefresh').click(function () {
        topTblRefresh();
    });
});
//初始化上侧表格
function initialTblTop() {
    $('#TblTop').datagrid({
        url: '/BackgroundProgram/GetListPage.ashx',
        title: '工站保养记录',
        fitColumns: false,
        idField: 'AutoID',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: { viewNeedOperate: 'dstblMaintainBasic', orderBy: JSON.stringify({ AutoId: 'desc' }), where: strBase64('') },
        columns: [[
                    { field: 'AutoID', title: 'AutoID', align: 'left', width: 140 },
                    { field: 'Workshop', title: 'Workshop', align: 'left', width: 140 },
                    { field: 'SubLine', title: 'SubLine', align: 'left', width: 140 },
                    { field: 'DeviceName', title: 'DeviceName', align: 'left', width: 140 },
                    { field: 'DeviceXh', title: 'DeviceXh', align: 'left', width: 140 },
                    { field: 'Part', title: 'Part', align: 'left', width: 140 },
                    { field: 'Item', title: 'Item', align: 'left', width: 140 },
                    { field: 'PartCode', title: 'PartCode', align: 'left', width: 140 },
                    { field: 'TaskInfomation', title: 'TaskInfomation', align: 'left', width: 140 },
                    { field: 'Basicresquest', title: 'Basicresquest', align: 'left', width: 140 },
                    { field: 'Notice', title: 'Notice', align: 'left', width: 140 },
                    { field: 'Detectcondition', title: 'Detectcondition', align: 'left', width: 140 },
                    { field: 'BeginMonth', title: 'BeginMonth', align: 'left', width: 140 },
                    { field: 'Periord', title: 'Periord', align: 'left', width: 140 },
                    { field: 'Aftermaintain', title: 'Aftermaintain', align: 'left', width: 140 },
                    { field: 'compel', title: 'compel', align: 'left', width: 140 },
                    { field: 'make_date', title: 'make_date', align: 'left', width: 140 },
                    { field: 'w_man_hour', title: 'w_man_hour', align: 'left', width: 140 }
        ]],
        toolbar: '#ToolbarTop'
    });
}

//上侧数据刷新
function topTblRefresh() {
    $('#TblTop').datagrid('clearSelections').datagrid('clearChecked');
    $('#TblTop').datagrid('reload');
}
