<%@ Page Title="看板" Language="C#" MasterPageFile="~/StructPage.Master" AutoEventWireup="true" CodeBehind="Kanpan.aspx.cs" Inherits="WebUI.Page.Kanpan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/WebSiteScripts/Kanpan.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentWorkSpace" runat="server">
    <div id="pnlKanpan" style="width: 100%; height: 100%">
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
                            <td style="width: 23.1%"><span id="eqmNo1" class="kp_data">OP010</span></td>
                        </tr>
                        <tr style="width: 50%">
                            <td style="width: 23.1%"><span class="title_base">停线时间Min</span></td>
                            <td style="width: 9.9%"><span id="stopTime" class="title_data">0</span></td>
                            <td><span class="title_base">实际产量Pcs</span></td>
                            <td><span id="realProduct" class="title_data">123</span></td>
                            <td>
                                <img id="andon1" src="/pic/andon_green.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td><span id="andonCall1" class="kp_data">质量</span></td>
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
                            <td style="width: 23.1%"><span id="eqmNo2" class="kp_data">OP010</span></td>
                            <td style="width: 9.9%">
                                <img id="eqmStatus3" src="/pic/working.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td style="width: 23.1%"><span id="eqmNo3" class="kp_data">OP010</span></td>
                            <td style="width: 9.9%">
                                <img id="eqmStatus4" src="/pic/working.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td style="width: 23.1%"><span id="eqmNo4" class="kp_data">OP010</span></td>
                        </tr>
                        <tr>
                            <td>
                                <img id="andon2" src="/pic/andon_green.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td><span id="andonCall2" class="kp_data">质量</span></td>
                            <td>
                                <img id="andon3" src="/pic/andon_green.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td><span id="andonCall3" class="kp_data">质量</span></td>
                            <td>
                                <img id="andon4" src="/pic/andon_green.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td><span id="andonCall4" class="kp_data">质量</span></td>
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
                            <td style="width: 23.1%"><span id="eqmNo5" class="kp_data">OP010</span></td>
                            <td style="width: 9.9%">
                                <img id="eqmStatus6" src="/pic/working.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td style="width: 23.1%"><span id="eqmNo6" class="kp_data">OP010</span></td>
                            <td style="width: 9.9%">
                                <img id="eqmStatus7" src="/pic/working.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td style="width: 23.1%"><span id="eqmNo7" class="kp_data">OP010</span></td>
                        </tr>
                        <tr>
                            <td>
                                <img id="andon5" src="/pic/andon_green.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td><span id="andonCall5" class="kp_data">质量</span></td>
                            <td>
                                <img id="andon6" src="/pic/andon_green.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td><span id="andonCall6" class="kp_data">质量</span></td>
                            <td>
                                <img id="andon7" src="/pic/andon_green.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td><span id="andonCall7" class="kp_data">质量</span></td>
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
                            <td style="width: 23.1%"><span id="eqmNo8" class="kp_data">OP010</span></td>
                            <td style="width: 9.9%">
                                <img id="eqmStatus9" src="/pic/working.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td style="width: 23.1%"><span id="eqmNo9" class="kp_data">OP010</span></td>
                            <td style="width: 9.9%">
                                <img id="eqmStatus10" src="/pic/working.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td style="width: 23.1%"><span id="eqmNo10" class="kp_data">OP010</span></td>
                        </tr>
                        <tr>
                            <td>
                                <img id="andon8" src="/pic/andon_green.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td><span id="andonCall8" class="kp_data">质量</span></td>
                            <td>
                                <img id="andon9" src="/pic/andon_green.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td><span id="andonCall9" class="kp_data">质量</span></td>
                            <td>
                                <img id="andon10" src="/pic/andon_green.png" style="width: 140px; height: 78.8px" alt="" /></td>
                            <td><span id="andonCall10" class="kp_data">质量</span></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
