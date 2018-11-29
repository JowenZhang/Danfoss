<%@ Page Title="设备运行状态" Language="C#" MasterPageFile="~/StructPage.Master" AutoEventWireup="true" CodeBehind="EqmStatus.aspx.cs" Inherits="WebUI.Page.EqmStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/WebSiteScripts/EqmStatus.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentWorkSpace" runat="server">
    <div class="easyui-layout" style="width: 100%; height: 100%">
        <div data-options="region:'center'">
            <table id="TblTop" style="width: 100%; height: 100%"></table>
        </div>
    </div>
    <div id="ToolbarTop">
        <a id="TopToolBtnRefresh" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">刷新</a>
    </div>
</asp:Content>
