<%@ Page Title="IR分析" Language="C#" MasterPageFile="~/StructPage.Master" AutoEventWireup="true" CodeBehind="IRAnalysis.aspx.cs" Inherits="WebUI.Page.IRAnalysis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/WebSiteScripts/IRAnalysis.js"></script>
    <script src="/Scripts/echarts.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentWorkSpace" runat="server">
    <div class="easyui-layout" style="width: 100%; height: 100%">
        <div data-options="region:'north',title:'IR分析',split:true" style="height:12%;">
            <table border="1" style="width:100%;height:100%">
                        <tr>
                            <td style="width:10%;"><a style="width:100%;display:block;text-align:right;">开始时间：</a></td>
                            <td style="width:25%;"><input id="TimStartTime" class="easyui-datetimebox" name="datStartTime"     
        data-options="showSeconds:false" style="width:100%;margin:0;border:none;padding:0;"/></td>
                            <td style="width:10%;"><a style="width:100%;display:block;text-align:right;">结束时间：</a></td>
                            <td style="width:25%;"><input id="TimEndTime" class="easyui-datetimebox" name="datEndTime"     
        data-options="showSeconds:false"  style="width:100%;margin:0;border:none;padding:0;" /></td>                           
                            <td style="width:30%;">
                                <span style="display:block;text-align:center"><a id="BtnAnalysisData" class="easyui-linkbutton" style="width:200px;text-align:center;">开始分析</a></span>
                            </td>
                        </tr>
                    </table>
            </div>
    <div data-options="region:'center',title:'每日IR'">
            <div id="BarChart" style="width:100%;height:100%;overflow:scroll;"></div>
        </div>
        <div data-options="region:'south',title:'工站IR',split:true" style="height:55%;">
            <table id="BarLineChart" style="width: 100%; height: 100%;overflow:scroll;"></table>
        </div>    
    </div>
</asp:Content>
