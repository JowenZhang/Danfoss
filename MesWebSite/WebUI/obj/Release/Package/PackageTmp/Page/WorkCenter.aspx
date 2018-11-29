<%@ Page Title="工作中心" Language="C#" MasterPageFile="~/StructPage.Master" AutoEventWireup="true" CodeBehind="WorkCenter.aspx.cs" Inherits="WebUI.Page.WorkCenter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/WebSiteScripts/WorkCenter.js"></script>
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
    <div id="TopEditFrm" style="display:none">
        <table>
            <tr>
                <td>
                    <a>工作中心编号:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtWkcNo" class="easyui-textbox" type="text" style="width:200px" />
                </td>
            </tr>
            <tr>
                <td>
                    <a>工作中心名称:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtWkcName" class="easyui-textbox" type="text" style="width:200px" /> 
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
                    <a>工厂:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbFactory" class="easyui-combobox" panelheight="auto" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>车间:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbWorkshop" class="easyui-combobox" panelheight="auto" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>产线:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbLine" class="easyui-combobox" panelheight="auto" style="width: 200px;"></select>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
