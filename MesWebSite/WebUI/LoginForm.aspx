<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="WebUI.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/javascript" src="/EasyUI/jquery.min.js"></script>
    <link href="/EasyUI/themes/icon.css" rel="stylesheet" />
    <script type="text/javascript" src="/EasyUI/locale/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="/EasyUI/jquery.easyui.min.js"></script>
    <script src="/Scripts/jquery.cookie.js"></script>
    <link href="/EasyUI/dfs-red.css" rel="stylesheet" />
    <link href="/MyCSS/MyCSS.css" rel="stylesheet" />
    <script src="/WebSiteScripts/LoginForm.js"></script>
    <title>登录</title>
</head>
<body>
    <div class="bg">
        <div class="easyui-layout" style="width: 100%; height: 100%">
            <div data-options="region:'south'" style="background: none; height: 100px; border: none;">
                <div class="footer">
                    <p style="text-align: center; font-size: x-large;">Copyright &copy; 2016-2018.</p>
                </div>
            </div>
            <div data-options="region:'center'" style="background: none; border: none;">
                <div id="Win" style="background-color: slategrey;">
                    <table>
                        <tr style="padding-bottom: 10px; border-bottom: 10px; margin-bottom: 10px;">
                            <td>
                                <p class="loginTxt">用户编号:&nbsp;&nbsp;</p>
                            </td>
                            <td>
                                <input id="User" class="easyui-textbox" style="width: 280px" />
                            </td>
                        </tr>
                        <tr style="padding-bottom: 10px; border-bottom: 10px; margin-bottom: 10px;">
                        </tr>
                        <tr>
                            <td>
                                <p class="loginTxt">密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码:&nbsp;&nbsp;</p>
                            </td>
                            <td>
                               <input id="Pwd" class="easyui-textbox" iconwidth="0" style="width: 280px" type="password"/>
                            </td>
                        </tr>
                        <tr style="padding-bottom: 10px; border-bottom: 10px; margin-bottom: 10px;">
                            <td colspan="2">
                                <p class="loginTxt">
                                    <a id="Btn" href="#" class="easyui-linkbutton" style="width: 180px; text-align: center">确&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;定</a>
                                </p>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
