<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebUI.Default" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE10,chrome=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/javascript" src="/EasyUI/jquery.min.js"></script>
    <link href="/EasyUI/themes/icon.css" rel="stylesheet" />
    <script type="text/javascript" src="/EasyUI/locale/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="/EasyUI/jquery.easyui.min.js"></script>
    <script src="/Scripts/jquery.base64.js"></script>
    <script src="/Scripts/jquery.cookie.js"></script>
    <link href="/EasyUI/dfs-red.css" rel="stylesheet" />
    <link href="/MyCSS/MyCSS.css" rel="stylesheet" />
    <link href="/MyCSS/MyKanpan.css" rel="stylesheet" />     
    <script src="/WebSiteScripts/Tools.js"></script>   
    <script src="/WebSiteScripts/Default.js"></script>    
    <title>PSH生产线MES软件</title>
</head>
<body class="easyui-layout">
    <%-- 标题 --%>
    <div id="Headsss" data-options="region:'north'" style="height: 70px; background-color: #C60609;">
        <div>
            <a class="hTitle">PSH生产线MES软件
            </a>
        </div>
        <div class="userLogin">
            <table style="vertical-align: central; font-size: 24px">
                <tr>
                    <td>
                        <a id="LoginUser">欢迎：用户</a>
                    </td>
                    <td>
                        <select id="Cc" class="easyui-combobox" panelheight="auto" name="dept" style="width: 100px; color: #C60609;">
                            <option>已登录</option>
                            <option>修改密码</option>
                            <option>注销</option>
                        </select>
                    </td>
                </tr>
            </table>
        </div>
        <div class="logo"></div>
    </div>
    <%-- 页脚 --%>
    <div data-options="region:'south'" style="height: 30px; background-color: #C60609;">
        <div style="position: absolute; bottom: 0%; right: 0%; height: 100%; color:white;">
            <a>v2.0&nbsp;&nbsp;</a>
        </div>
    </div>
    <%-- 菜单 --%>
    <div id="MenuArea" data-options="region:'west',split:true" title=" " style="width: 240px; background-color: #C60609">
        <div id="Menu" class="easyui-accordion" style="width: 100%; height: 100%;">
        </div>
    </div>
    <%-- 工作区 --%>
    <div data-options="region:'center'" style="padding: 0px; border: none; margin: 0; background: white;">
        <iframe id="PageStage" style="display: block; width: 100%; height: 100%; border: none" src="\WelcomePage.aspx"></iframe>
    </div>
    <div id="DwPwdChange" style="display: none">
        <table>
            <tr>
                <td><span>原始密码:&nbsp;&nbsp;</span></td>
                <td><input id="OldPassword" class="easyui-textbox" style="width: 200px; height: 34px; padding: 10px" iconwidth="0" type="password"/></td>
            </tr>
            <tr>
                <td><span>新建密码:&nbsp;&nbsp;</span></td>
                <td><input id="NewPassword" class="easyui-textbox" style="width: 200px; height: 34px; padding: 10px" iconwidth="0" type="password"/></td>
            </tr>
            <tr>
                <td><span>重复密码:&nbsp;&nbsp;</span></td>
                <td><input id="AgainPassword" class="easyui-textbox" style="width: 200px; height: 34px; padding: 10px" iconwidth="0" type="password"/></td>
            </tr>
            <tr>
                <td colspan="2">
                    <a id="BtnConfirm" class="easyui-linkbutton" style=" height: 34px;">确认</a>
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
