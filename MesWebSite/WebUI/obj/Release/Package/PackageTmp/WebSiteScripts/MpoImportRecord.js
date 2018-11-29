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
        title: '计划订单导入记录',
        fitColumns: false,
        idField: 'mpo_no',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: { viewNeedOperate: 'mpo', orderBy: JSON.stringify({ commit_status_no:'desc',mpo_hope_start_datetime:'desc',mpo_no: 'desc' }), where: strBase64('') },
        columns: [[
            { field: 'mpo_no', title: '生产单号', align: 'left', width: 140 },
                    { field: 'commit_status_no', title: '订单状态码', align: 'left', width: 150 },
                    { field: 'commit_status_name', title: '订单状态', align: 'left', width: 150 },
                    { field: 'part_no', title: '产品型号', align: 'left', width: 140 },                    
                    { field: 'mpo_qty', title: '数量', align: 'left', width: 140 },
                    { field: 'mpo_hope_start_datetime', title: '计划开始时间', align: 'left', width: 160 },
                    { field: 'mpo_hope_end_datetime', title: '计划结束时间', align: 'left', width: 160 },
                    { field: 'mpo_type_no', title: '生产类型码', align: 'left', width: 140 },
                    { field: 'mpo_type_name', title: '生产类型', align: 'left', width: 140 }                    
        ]],
        toolbar: '#ToolbarTop'
    });
}

//上侧数据刷新
function topTblRefresh() {
    $('#TblTop').datagrid('clearSelections').datagrid('clearChecked');
    $('#TblTop').datagrid('reload');
}