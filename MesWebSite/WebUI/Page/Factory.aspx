<%@ Page Title="工厂" Language="C#" MasterPageFile="~/StructPage.Master" AutoEventWireup="true" CodeBehind="Factory.aspx.cs" Inherits="WebUI.Page.Factory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/WebSiteScripts/Factory.js"></script>
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
    <div id="TopEditFrm" style="display:none" style="display: none;">
        <table>
            <tr>
                <td>
                    <a>工厂编号:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtFactoryNo" class="easyui-textbox" type="text" style="width: 200px;" />
                </td>
            </tr>
            <tr>
                <td>
                    <a>工厂名称:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtFactoryName" class="easyui-textbox" type="text" style="width: 200px;" />
                </td>
            </tr>
            <tr>
                <td>
                    <a>状态:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select class="easyui-combobox" panelheight="auto" id="CmbStatusTop" style="width: 200px;" data-options="valueField:'status_no',textField:'status_name'"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>公司:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select class="easyui-combobox" panelheight="auto" id="CmbCompany" style="width: 200px;"></select>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
