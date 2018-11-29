var loginUserNo='';
$(function () {
    startHtml();
});
function startHtml() {
    initTable();
}
function initTable() {
    $('#Tt').datagrid({
        url: '/BackgroundProgram/msgContent.ashx',
        title: '您的消息列表...',
        fitColumns: false,
        idField: 'msg_no',
        loadMsg: '正在获取后台信息...',
        fit: true,
        pagination: true,
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: {loginUserNo:loginUserNo},
        columns: [[                    
            { field: 'No', title: '编号', align: 'left', width: 140 },
            { field: 'MsgTxt', title: '消息内容', align: 'left', width: 400 }
        ]]
    });
}