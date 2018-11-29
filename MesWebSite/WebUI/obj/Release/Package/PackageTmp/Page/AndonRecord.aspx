<%@ Page Title="安灯呼叫记录" Language="C#" MasterPageFile="~/StructPage.Master" AutoEventWireup="true" CodeBehind="AndonRecord.aspx.cs" Inherits="WebUI.Page.AndonRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/WebSiteScripts/AndonRecord.js"></script>
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
        <a id="TopToolBtnAdd" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">添加</a>
        <a id="TopToolBtnDelete" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">删除</a>
    </div>
    <div id="TopEditFrm" style="display: none">
        <table>
            <tr>
                <td>
                    <a>记录编号:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtAndonNo" class="easyui-textbox" type="text" style="width:200px"/>
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
                    <a>来源设备:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbEqm" class="easyui-combobox" panelheight="400px" data-options="valueField:'eqm_no',textField:'eqm_name'" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>呼叫类型:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbAndonType" class="easyui-combobox" panelheight="400px" data-options="valueField:'andon_type_no',textField:'andon_type_name'" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>呼叫部门:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbDept" class="easyui-combobox" panelheight="400px" data-options="valueField:'dept_no',textField:'dept_name'" style="width: 200px;"></select>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
