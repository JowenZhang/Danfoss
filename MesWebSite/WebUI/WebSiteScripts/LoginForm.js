$(function () {
    $('#Win').window({
        title: '登录',
        width: 400,
        height: 240,
        collapsible: false,
        closable: false,
        resizable: false,
        modal: false,
        maximizable: false,
        minimizable: false
    });
    $('#Pwd').passwordbox({
        showEye: true,
        lastDelay: 10,
        checkInterval: 10
    });
    $('#Win').window('center');
    $('#Win').window('open');
    $("#Btn").click(function () {
        login();
    });
});
function login() {
    var userNo = $.trim($("#User").textbox('getValue'));
    var password = $.trim($("#Pwd").passwordbox('getValue'));
    if (userNo === "") {
        $.messager.alert('警告', '请输入用户编号！', 'warning');
    } else if (password === "") {
        $.messager.alert('警告', '请输入密码！', 'warning');
        return;
    }
    //ajax去服务器端校验
    $.post('/BackgroundProgram/UserLoginValid.ashx', { 'userNo': userNo, 'password': password }, function (msg) {
        if (msg === "false") {
            $.messager.alert('警告', '用户名或密码错误！', 'warning');
        }
        else {
            window.location.href = "/Default.aspx";
        }
    });
}