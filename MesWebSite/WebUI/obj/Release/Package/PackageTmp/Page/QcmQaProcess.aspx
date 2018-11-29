<%@ Page Title="质量异常处理" Language="C#" MasterPageFile="~/StructPage.Master" AutoEventWireup="true" CodeBehind="QcmQaProcess.aspx.cs" Inherits="WebUI.Page.QcmQaProcess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/WebSiteScripts/QcmQaProcess.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentWorkSpace" runat="server">
    <div class="easyui-layout" style="width: 100%; height: 100%">
        <div data-options="region:'center'">
            <table id="TblTop" style="width: 100%; height: 100%"></table>
        </div>
    </div>
    <div id="ToolbarTop">
        <a id="TopToolBtnRefresh" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">刷新</a>
        <a id="TopToolBtnEdit" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">编辑</a>
<%--        <a id="TopToolBtnAdd" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">添加</a>
        <a id="TopToolBtnDelete" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">删除</a>--%>
    </div>
    <div id="TopEditFrm" style="display:none">
    <table>
            <tr>
                <td>
                    <a>异常编号:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtQaRecordNo" class="easyui-textbox" type="text" style="width:200px"/>
                </td>
            </tr>
            <tr>
                <td>
                    <a>状态:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbStatusTop" class="easyui-combobox" panelheight="auto" data-options="valueField:'status_no',textField:'status_name'" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>品号:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtPartNo" class="easyui-textbox" type="text" style="width:200px"/>
                </td>
            </tr>
            <tr>
                <td>
                    <a>生产订单:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtMpoNo" class="easyui-textbox" type="text" style="width:200px"/>
                </td>
            </tr>
            <tr>
                <td>
                    <a>子单编号:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtMpoItemNo" class="easyui-textbox" type="text" style="width:200px"/>
                </td>
            </tr>
            <tr>
                <td>
                    <a>序列号:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtSerialNo" class="easyui-textbox" type="text" style="width:200px"/>
                </td>
            </tr>
            <tr>
                <td>
                    <a>设备:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbEqm" class="easyui-combobox" panelheight="400px" data-options="valueField:'eqm_no',textField:'eqm_name'" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>异常代码:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbQaCause" class="easyui-combobox" panelheight="400px" data-options="valueField:'qa_cause_no',textField:'qa_cause_name'" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>质量结果:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbQaResult" class="easyui-combobox" panelheight="auto" data-options="valueField:'quality_no',textField:'quality_name'" style="width: 200px;"></select>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
