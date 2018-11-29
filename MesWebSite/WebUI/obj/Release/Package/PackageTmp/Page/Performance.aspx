<%@ Page Title="报工记录" Language="C#" MasterPageFile="~/StructPage.Master" AutoEventWireup="true" CodeBehind="Performance.aspx.cs" Inherits="WebUI.Page.Performance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/WebSiteScripts/Performance.js"></script>
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
        <%--<a id="TopToolBtnEdit" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">编辑</a>
        <a id="TopToolBtnAdd" class="easyui-linkbutton"  style="margin: 0px; width: auto; height: auto;">添加</a>
        <a id="TopToolBtnDelete" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">删除</a>--%>
    </div>
    <div id="TopEditFrm" style="display: none">
    </div>
    <div id="ToolbarBottom">
        <a id="BottomToolBtnRefresh" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">刷新</a>
        <%--<a id="BottomToolBtnEdit" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">编辑</a>
        <a id="BottomToolBtnAdd" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">添加</a>
        <a id="BottomToolBtnDelete" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">删除</a>--%>
    </div>
    <div id="BottomEditFrm" style="display: none;">        
    </div>
</asp:Content>
