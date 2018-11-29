<%@ Page Title="系统设定" Language="C#" MasterPageFile="~/StructPage.Master" AutoEventWireup="true" CodeBehind="SysSetting.aspx.cs" Inherits="WebUI.Page.SysSetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/WebSiteScripts/SysSetting.js"></script>
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
                    <a>参数编号:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtSettingNo" class="easyui-textbox" type="text" style="width:200px" />
                </td>
            </tr>
            <tr>
                <td>
                    <a>参数名称:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtSettingDisplayName" class="easyui-textbox" type="text" style="width:200px" />
                </td>
            </tr>
            <tr>
                <td>
                    <a>参数值:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtSettingValue" class="easyui-textbox" type="text" style="width:200px" /> 
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
