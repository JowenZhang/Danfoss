<%@ Page Title="日计划数量" Language="C#" MasterPageFile="~/StructPage.Master" AutoEventWireup="true" CodeBehind="DaliyPlanQty.aspx.cs" Inherits="WebUI.Page.DaliyPlanQty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/WebSiteScripts/DaliyPlanQty.js"></script>
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
                    <a>日期:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="DatPlanDate" class="easyui-datebox" type="text" style="width: 200px;" />
                </td>
            </tr>
            <tr>
                <td>
                    <a>数量:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="NumPlanQty" class="easyui-numberspinner" style="width:200px;" data-options="editable:true" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
