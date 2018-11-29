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
        title: '工站设备状态',
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
            { field: 'eqm_index', title: '设备序号', align: 'left', width: 140 },
            { field: 'eqm_status', title: '设备运行状态', align: 'left', width: 140 }//,
            //{ field: 'eqm_lock', title: '互锁状态', align: 'left', width: 140 }
        ]],
        toolbar: '#ToolbarTop',
        onLoadSuccess: function () {
            var a = document.getElementById("TblTop");
            var aP = a.parentNode;
            var view1 = aP.childNodes[1];
            var datagridBody = view1.childNodes[1];
            var tableNodes = datagridBody.childNodes[0];
            var tbodyNodes = tableNodes.childNodes[0];
            for (var i = 0; i < tbodyNodes.childNodes.length; i++) {
                var tdNode = tbodyNodes.childNodes[i].getElementsByTagName('td')[3].innerText.replace(/[\r\n]/g, "");
                if (tdNode == "正常") {
                    tbodyNodes.childNodes[i].getElementsByTagName('td')[3].style.backgroundColor = "green";
                } else if (tdNode == "维修") {
                    tbodyNodes.childNodes[i].getElementsByTagName('td')[3].style.backgroundColor = "yellow";
                } else {
                    tbodyNodes.childNodes[i].getElementsByTagName('td')[3].style.backgroundColor = "red";
                }

            }
        }
    });
}

//上侧数据刷新
function topTblRefresh() {
    $('#TblTop').datagrid('clearSelections').datagrid('clearChecked');
    $('#TblTop').datagrid('reload');
}