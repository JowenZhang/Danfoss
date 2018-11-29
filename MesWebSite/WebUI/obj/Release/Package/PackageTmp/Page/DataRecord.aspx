<%@ Page Title="数据记录" Language="C#" MasterPageFile="~/StructPage.Master" AutoEventWireup="true" CodeBehind="DataRecord.aspx.cs" Inherits="WebUI.Page.DataRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/WebSiteScripts/DataRecord.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentWorkSpace" runat="server">
    <div class="easyui-layout" style="width: 100%; height: 100%">
        <div data-options="region:'center'">
            <table id="TblTop" style="width: 100%; height: 100%"></table>
        </div>
    </div>
    <div id="ToolbarTop">
        <a id="TopToolBtnRefresh" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">刷新</a>
        <a>工站:</a>
        <input id="TopToolCmbEqm" class="easyui-combobox" style="width: 150px; height: 32px" />
        <a>序列号:</a>
        <input id="TopToolTxtSerialNo" class="easyui-textbox" style="width: 100px; height: 32px" />
        <a>型号:</a>
        <input id="TopToolTxtPartNo" class="easyui-textbox" style="width: 100px; height: 32px" /> 
        <a>开始日期:</a>
        <input id="TopToolDatStartTime" class="easyui-datebox" style="width: 150px" />
        <a>结束日期:</a>
        <input id="TopToolDatEndTime" class="easyui-datebox" style="width: 150px" />
        <a id="TopToolBtnSearch" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">检索</a>
        <a id="TopToolBtnRecord" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">生成跟踪卡</a>
<%--        <a id="TopToolBtnEdit" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">编辑</a>
        <a id="TopToolBtnAdd" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">添加</a>
        <a id="TopToolBtnDelete" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">删除</a>--%>
    </div>
</asp:Content>
