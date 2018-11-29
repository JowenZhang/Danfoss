$(function () {
    startHtml();
});
function startHtml() {
    $('#pnlKanpan').panel({
        tools: [{
            iconCls: 'icon-add',
            handler: function () {
                window.open('/Page/FullScreenKanPan.aspx');
            }
        }],
        onLoad: function () {
        }
    }).panel({ title: "看板" });
    dataRefresh();
    setInterval(function () {
        dataRefresh();
    }, 6000);
};

function dataRefresh() {
    $.getJSON('/BackgroundProgram/FetchKanpanData.ashx', { timestamp: new Date().getTime() }, function (data) {
        $('#stopTime').text(data.stopTime);
        $('#planProduct').text(data.planQty);
        $('#realProduct').text(data.productQty);
        for (var i = 1; i <= 10; i++) {
            var adnNum = data.adnList.length;
            if (i <= adnNum) {
                $('#eqmNo' + i).text(data.adnList[i - 1].eqm_no);
                var eqmStatusStr = data.adnList[i - 1].eqm_status;
                var andonTypeName = data.adnList[i - 1].andon_type_name;
                var andonStatus = data.adnList[i - 1].status_no;
                if (eqmStatusStr == '维修') {
                    $('#eqmStatus' + i).attr('src', '/pic/repair.png');
                } else if (eqmStatusStr == '正常') {
                    $('#eqmStatus' + i).attr('src', '/pic/working.png');
                } else {
                    $('#eqmStatus' + i).attr('src', '/pic/broken.png');
                }
                if (andonTypeName != null) {
                    if (andonStatus == '510') {
                        $('#andonCall' + i).text('正常运行');
                        $('#kpTitle' + i).css('background-color', 'transparent');
                        $('#kpAndon' + i).css('background-color', 'transparent');
                        $('#andon' + i).attr('src', '/pic/andon_green.png');

                    }
                    else if (andonStatus == '500') {
                        $('#andonCall' + i).text(andonTypeName);
                        $('#kpTitle' + i).css('background-color', 'red');
                        $('#kpAndon' + i).css('background-color', 'red');
                        $('#andon' + i).attr('src', '/pic/andon_red.png');
                    }
                    else {
                        $('#andonCall' + i).text(andonTypeName);
                        $('#kpTitle' + i).css('background-color', 'yellow');
                        $('#kpAndon' + i).css('background-color', 'yellow');
                        $('#andon' + i).attr('src', '/pic/andon_yellow.png');
                    }
                }
                else {
                    $('#andonCall' + i).text('正常运行');
                    $('#kpTitle' + i).css('background-color', 'transparent');
                    $('#kpAndon' + i).css('background-color', 'transparent');
                    $('#andon' + i).attr('src', '/pic/andon_green.png');
                }
            }
            else {
                $('#eqmNo' + i).text('工站' + i);
                $('#eqmStatus' + i).attr('src', '/pic/working.png');
                $('#andonCall' + i).text('正常运行');
                $('#kpTitle' + i).css('background-color', 'transparent');
                $('#kpAndon' + i).css('background-color', 'transparent');
                $('#andon' + i).attr('src', '/pic/andon_green.png');
            }
        }
    });
};