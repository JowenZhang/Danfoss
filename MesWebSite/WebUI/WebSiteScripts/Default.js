//变量初始化
var userName;
var userNo;

//页面程序初始化
$(function () {
     if (isLegal()) {
        loadMenu();
        loadPageFunction();
    } else {
        window.location.href = "/LoginForm.aspx";
    }
});

//加载菜单
function loadMenu()
{
    var cookieStr = $.cookie('MesCookie');
    if (cookieStr !== null && cookieStr !== '' && cookieStr !== undefined) {
        var obj = $.parseJSON(cookieStr);
        userName = eval("'" + obj.userName + "'");
        userNo = obj.userNo;
    } else {
        userName = 'userName';
        userNo = 'userNo';
    }
    $.ajax({
        type: 'post',
        dataType: 'json',
        data:{userNo:userNo,userName:userName},
        url: '/BackgroundProgram/GetMenu.ashx',
        success: function (data) {
            console.log(data);
            $.each(data, function (i, n) {
                $('#Menu').accordion('add', {
                    title: n.title,
                    selected: n.selected,
                    content: n.content
                });
            });
        }
    });
}

//菜单按钮单击事件触发
function sendClick(target) {
    if (isLegal()) {
        if (target === null) {
            $('#PageStage').attr('src', '/WelcomePage.aspx');
        }
        else {
            $('#PageStage').attr('src', target.href);
        }        
    }
    else {
        window.location.href = "/LoginForm.aspx";
    }    
    return false;
}

//校验当前登陆人员是否为合法使用人
function isLegal() {
    var cookieStr = $.cookie('MesCookie');
    if (cookieStr!==null&&cookieStr!==''&&cookieStr!==undefined) {
        var obj = $.parseJSON(cookieStr);
        userName = eval("'"+obj.userName+"'");
        userNo = obj.userNo;
        if (userName !== null && userName !== '' && userName !== undefined) {
            $('#LoginUser').text('欢迎：' + userName)
            return true;
        } else {
            return false;
        }
    } else {
        return false;
    }
}

//加载页面独有功能
function loadPageFunction() {
    loadChangePwdCmb();
}

//加载修改密码下拉框
function loadChangePwdCmb() {
    $('#Cc').combobox({
        editable: false,
        onChange: function useAct(newValue, oldValue) {
            if (newValue === '修改密码') {
                changePwd();
            }
            else if (newValue === '注销') {
                window.location.href = '/LoginForm.aspx';
            }
            else { }
        }
    });
}

//密码修改功能
function changePwd() {
    $('#OldPassword').passwordbox({
        showEye: true,
        lastDelay: 10,
        checkInterval: 10
    });
    $('#NewPassword').passwordbox({
        showEye: true,
        lastDelay: 10,
        checkInterval: 10
    });
    $('#AgainPassword').passwordbox({
        showEye: true,
        lastDelay: 10,
        checkInterval: 10
    });
    $('#DwPwdChange').dialog({
        title: '密码修改',
        closed: false,
        cache: false,
        modal: true,
    });
    $('#BtnConfirm').click(function () {
        var oldPwd = $('#OldPassword').passwordbox('getValue');
        var newPwd = $('#NewPassword').passwordbox('getValue');
        var againPwd = $('#AgainPassword').passwordbox('getValue');
        if (newPwd !== againPwd) {
            $.messager.alert("警告", "两次输入的新密码不一致，请重新输入！", "warning");
            return false;
        }
        $.post('/BackgroundProgram/ChangePwd.ashx', { userNo: userNo, oldPwd: oldPwd, newPwd: newPwd }, function (data)
        {
            if (data === 'success') {
                window.location.href = '/LoginForm.aspx';
                userNo = '';
                userName = '';
            }
            else {
                $.messager.alert('警告', data, 'error');
            }
        });
    });
}