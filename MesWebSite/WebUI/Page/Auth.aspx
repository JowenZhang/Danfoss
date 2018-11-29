<%@ Page Title="权限管理" Language="C#" MasterPageFile="~/StructPage.Master" AutoEventWireup="true" CodeBehind="Auth.aspx.cs" Inherits="WebUI.Page.Auth" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/WebSiteScripts/Auth.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentWorkSpace" runat="server">
    <div class="easyui-layout" style="width: 100%; height: 100%">
        <div data-options="region:'north'" style="height: 50%;">
            <table id="TblTop" style="width: 100%; height: 100%"></table>
        </div>
        <div data-options="region:'center'">
            <table id="TblBottom" style="width: 100%; height: 100%"></table>
        </div>
    </div>
    <div id="ToolbarTop">
        <a id="TopToolBtnRefresh" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">刷新</a>
        <a id="TopToolBtnEdit" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">编辑</a>
        <a id="TopToolBtnAdd" class="easyui-linkbutton"  style="margin: 0px; width: auto; height: auto;">添加</a>
        <a id="TopToolBtnDelete" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">删除</a>
    </div>
    <div id="TopEditFrm" style="display:none">
        <table>
            <tr>
                <td>
                    <a>权限组编号:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtAuthGroupNo" class="easyui-textbox" type="text" style="width:200px;"/>
                </td>
            </tr>
            <tr>
                <td>
                    <a>权限组名称:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtAuthGroupName" class="easyui-textbox" type="text" style="width:200px;"/>
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
        </table>
    </div>
    <div id="ToolbarBottom">
        <a id="BottomToolBtnRefresh" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">刷新</a>
        <a id="BottomToolBtnEdit" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">编辑</a>
        <a id="BottomToolBtnAdd" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">添加</a>
        <a id="BottomToolBtnDelete" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">删除</a>
    </div>
    <div id="BottomEditFrm" style="display: none;">
        <table>
            <tr>
                <td>
                    <a>权限编号:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtAuthNo" class="easyui-textbox" type="text" style="width:200px;"/>
                    </td>
            </tr>
            <tr>
                <td>
                    <a>权限名称:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtAuthName" class="easyui-textbox" type="text" style="width:200px;"/>
                </td>
            </tr>
            <tr>
                <td>
                    <a>状态:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbStatusBottom" class="easyui-combobox" panelheight="auto" data-options="valueField:'status_no',textField:'status_name'" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>权限组:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbAuthGroup" class="easyui-combobox" panelheight="auto" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>菜单选项:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbMenu" class="easyui-combobox" panelheight="400px" style="width: 200px;"></select>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
