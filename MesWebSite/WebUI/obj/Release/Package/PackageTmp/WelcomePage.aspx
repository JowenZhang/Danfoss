<%@ Page Title="欢迎页" Language="C#" MasterPageFile="~/StructPage.Master" AutoEventWireup="true" CodeBehind="WelcomePage.aspx.cs" Inherits="WebUI.WelcomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="WebSiteScripts/WelcomePage.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentWorkSpace" runat="server">
    <div class="easyui-layout" style="width: 100%; height: 100%">
        <div data-options="region:'north'" style="height: 12%;">
            <h1>欢迎使用PSH生产线MES软件</h1>
        </div>
        <div data-options="region:'center'">
            <table id="Tt"></table>
        </div>
    </div>
</asp:Content>