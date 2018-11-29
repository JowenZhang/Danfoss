$(function () {
    loadPageFunction();
});


function loadPageFunction() {
    $('#PnlKanpan').panel({
        tools: [{
            iconCls: 'icon-reload',
            handler: function (){
                dataRefresh();
            }
        }],
        onLoad: dataRefresh()
    }).panel({ title: "工站互锁" });
}

function dataRefresh() {
    $.getJSON('/BackgroundProgram/GetListPage.ashx', { viewNeedOperate: 'eqmLock', orderBy: JSON.stringify({ eqm_index: 'asc' }), where: strBase64(''), timestamp: new Date().getTime() }, function (data) {
        var rows = data.rows;
        for (var i = 1; i <= 10; i++){
            var eqmOriId = "#EqmOrignal" + i;
            var eqmDesId = "#EqmDestiny" + i;
            var imgId = "#Img" + i;
            console.log(rows[i-1].eqm_no);
            $(eqmOriId).text(rows[i-1].eqm_no);
            $(eqmDesId).text(rows[i-1].eqm_lock);
            if (rows[i-1].eqm_lock=="无锁定") {
                $(imgId).attr('src', '/pic/unlock.png');
            }
            else{
                $(imgId).attr('src', '/pic/lock.png');
            }
        }
    });
}