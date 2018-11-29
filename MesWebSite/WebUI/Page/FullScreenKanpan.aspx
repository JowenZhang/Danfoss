<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FullScreenKanpan.aspx.cs" Inherits="WebUI.Page.FullScreenKanpan" %>

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
    <script src="/WebSiteScripts/DataBind.js"></script>
    <script src="/WebSiteScripts/Tools.js"></script>
    <link href="/EasyUI/dfs-red.css" rel="stylesheet" />
    <link href="/MyCSS/MyCSS.css" rel="stylesheet" />
    <link href="/MyCSS/MyKanpan.css" rel="stylesheet" />
    <script src="/WebSiteScripts/FullScreenKanpan.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table style="height: 100%; width: 100%; background-color: black;">
            <%--第一行--%>
            <tr style="height: 25%;">
                <td style="width: 100%;">
                    <table style="height: 100%; width: 100%; background-color: black;">
                        <tr style="width: 50%">
                            <td colspan="2">
                                <span class="title_top">NELICO生产线</span>
                            </td>
                            <td style="width: 23.1%"><span class="title_base">计划生产Pcs</span></td>
                            <td style="width: 9.9%"><span id="planProduct" class="title_data">123</span></td>
                            <td style="width: 9.9%">
                                <img id="eqmStatus1" src="/pic/working.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td id="kpTitle1" style="width: 23.1%"><span id="eqmNo1" class="kp_data">OP010</span></td>
                        </tr>
                        <tr style="width: 50%">
                            <td style="width: 23.1%"><span class="title_base">停线时间Min</span></td>
                            <td style="width: 9.9%"><span id="stopTime" class="title_data">0</span></td>
                            <td><span class="title_base">实际产量Pcs</span></td>
                            <td><span id="realProduct" class="title_data">123</span></td>
                            <td>
                                <img id="andon1" src="/pic/andon_green.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td id="kpAndon1"><span id="andonCall1" class="kp_data">质量</span></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <%-- 第二行 --%>
            <tr style="height: 25%;">
                <td style="width: 100%;">
                    <table style="height: 100%; width: 100%; background-color: black;">
                        <tr>
                            <td style="width: 9.9%">
                                <img id="eqmStatus2" src="/pic/working.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td id="kpTitle2" style="width: 23.1%"><span id="eqmNo2" class="kp_data">OP010</span></td>
                            <td style="width: 9.9%">
                                <img id="eqmStatus3" src="/pic/working.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td id="kpTitle3" style="width: 23.1%"><span id="eqmNo3" class="kp_data">OP010</span></td>
                            <td style="width: 9.9%">
                                <img id="eqmStatus4" src="/pic/working.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td id="kpTitle4" style="width: 23.1%"><span id="eqmNo4" class="kp_data">OP010</span></td>
                        </tr>
                        <tr>
                            <td>
                                <img id="andon2" src="/pic/andon_green.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td id="kpAndon2"><span id="andonCall2" class="kp_data">质量</span></td>
                            <td>
                                <img id="andon3" src="/pic/andon_green.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td id="kpAndon3"><span id="andonCall3" class="kp_data">质量</span></td>
                            <td>
                                <img id="andon4" src="/pic/andon_green.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td id="kpAndon4"><span id="andonCall4" class="kp_data">质量</span></td>
                        </tr>
                    </table>
                </td>

            </tr>
            <%-- 第三行 --%>
            <tr style="height: 25%;">
                <td style="width: 100%;">
                    <table style="height: 100%; width: 100%; background-color: black;">
                        <tr>
                            <td style="width: 9.9%">
                                <img id="eqmStatus5" src="/pic/working.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td id="kpTitle5" style="width: 23.1%"><span id="eqmNo5" class="kp_data">OP010</span></td>
                            <td style="width: 9.9%">
                                <img id="eqmStatus6" src="/pic/working.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td id="kpTitle6" style="width: 23.1%"><span id="eqmNo6" class="kp_data">OP010</span></td>
                            <td style="width: 9.9%">
                                <img id="eqmStatus7" src="/pic/working.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td id="kpTitle7" style="width: 23.1%"><span id="eqmNo7" class="kp_data">OP010</span></td>
                        </tr>
                        <tr>
                            <td>
                                <img id="andon5" src="/pic/andon_green.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td id="kpAndon5"><span id="andonCall5" class="kp_data">质量</span></td>
                            <td>
                                <img id="andon6" src="/pic/andon_green.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td id="kpAndon6"><span id="andonCall6" class="kp_data">质量</span></td>
                            <td>
                                <img id="andon7" src="/pic/andon_green.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td id="kpAndon7"><span id="andonCall7" class="kp_data">质量</span></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <%-- 第四行 --%>
            <tr style="height: 25%;">
                <td style="width: 100%;">
                    <table style="height: 100%; width: 100%; background-color: black;">
                        <tr>
                            <td style="width: 9.9%">
                                <img id="eqmStatus8" src="/pic/working.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td id="kpTitle8" style="width: 23.1%"><span id="eqmNo8" class="kp_data">OP010</span></td>
                            <td style="width: 9.9%">
                                <img id="eqmStatus9" src="/pic/working.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td id="kpTitle9" style="width: 23.1%"><span id="eqmNo9" class="kp_data">OP010</span></td>
                            <td style="width: 9.9%">
                                <img id="eqmStatus10" src="/pic/working.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td id="kpTitle10" style="width: 23.1%"><span id="eqmNo10" class="kp_data">OP010</span></td>
                        </tr>
                        <tr>
                            <td>
                                <img id="andon8" src="/pic/andon_green.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td id="kpAndon8"><span id="andonCall8" class="kp_data">质量</span></td>
                            <td>
                                <img id="andon9" src="/pic/andon_green.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td id="kpAndon9"><span id="andonCall9" class="kp_data">质量</span></td>
                            <td>
                                <img id="andon10" src="/pic/andon_green.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td id="kpAndon10"><span id="andonCall10" class="kp_data">质量</span></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
