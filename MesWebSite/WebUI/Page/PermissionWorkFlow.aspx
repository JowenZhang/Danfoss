<%@ Page Title="审核流程管理" Language="C#" MasterPageFile="~/StructPage.Master" AutoEventWireup="true" CodeBehind="PermissionWorkFlow.aspx.cs" Inherits="WebUI.Page.PermissionWorkFlow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/WebSiteScripts/PermissionWorkFlow.js"></script>
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
    <div id="TopEditFrm" style="display:none" style="display: none;">
        <table>
            <tr>
                <td>
                    <a>审核流程编号:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtApoNo" class="easyui-textbox" type="text" style="width: 200px;"/>
                </td>
            </tr>
            <tr>
                <td>
                    <a>审核流程名称:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtApoName" class="easyui-textbox" type="text" style="width: 200px;" />
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
                    <a>流程子项编号:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtApoItemNo"  class="easyui-textbox" type="text" style="width: 200px;"/>
                </td>
            </tr>
            <tr>
                <td>
                    <a>流程子项名称:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtApoItemName"  class="easyui-textbox" type="text" style="width: 200px;"/>
                </td>
            </tr>
            <tr>
                <td>
                    <a>审核流程:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbApo" class="easyui-combobox" panelheight="auto" style="width: 200px;"></select>
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
                    <a>顺序号:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtApoIndex"  class="easyui-textbox" type="text" style="width: 200px;"/>
                </td>
            </tr>
            <tr>
                <td>
                    <a>下一流程编号:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtNextItemNo"  class="easyui-textbox" type="text" style="width: 200px;"/>
                </td>
            </tr>
            <tr>
                <td>
                    <a>下一流程审核人:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbUser" class="easyui-combobox" panelheight="400px" style="width: 200px;"></select>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
