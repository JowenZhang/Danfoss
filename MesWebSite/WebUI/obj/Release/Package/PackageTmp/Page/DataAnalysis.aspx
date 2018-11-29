<%@ Page Title="数据分析" Language="C#" MasterPageFile="~/StructPage.Master" AutoEventWireup="true" CodeBehind="DataAnalysis.aspx.cs" Inherits="WebUI.Page.DataAnalysis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/WebSiteScripts/DataAnalysis.js"></script>
    <script src="/Scripts/echarts.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentWorkSpace" runat="server">
    <div class="easyui-layout" style="width: 100%; height: 100%">
        <div data-options="region:'north',title:'数据分析',split:true" style="height:25%;">
            <div class="easyui-layout" style="width: 100%; height: 100%">                 
                <div data-options="region:'west'" style="width:40%;padding:0;border:none;margin:0;background-color:white;">
                    <table border="1" style="width:100%;height:100%">
                        <tr>
                            <td style="width:50%;"><a style="width:100%;display:block;text-align:right;">分析项目：</a></td>
                            <td style="width:50%;"><select id="CmbAnalysisItem" class="easyui-combobox" name="analysisItem" panelheight="auto"  data-options="valueField:'item_no',textField:'item_name'" style="width:100%;"></select></td>                        </tr>
                        <tr>
                            <td style="width:50%;"><a style="width:100%;display:block;text-align:right;">分析维度：</a></td>
                            <td style="width:50%;"><select id="CmbAnalysisDestiny" class="easyui-combobox" name="analysisDestiny" panelheight="auto"  data-options="valueField:'destiny_no',textField:'destiny_name'" style="width:100%;"></select></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="width:100%;">
                                <span style="display:block;text-align:center"><a id="BtnAnalysisData" class="easyui-linkbutton" style="width:200px;text-align:center;">开始分析</a></span>
                            </td>
                        </tr>
                    </table>
                </div>   
                <div data-options="region:'center'" style="padding:0;border:none;margin:0;background:white;">
                    <table border="1" style="width:100%;height:100%">
                        <tr>
                            <td style="width:25%;"><a style="width:100%;display:block;text-align:right;">开始时间：</a></td>
                            <td style="width:25%;"><input id="TimStart" class="easyui-datetimebox" name="datStartTime"     
        data-options="showSeconds:false" style="width:auto;margin:0;border:none;padding:0;"/></td>
                            <td style="width:25%;"><a style="width:100%;display:block;text-align:right;">结束时间：</a></td>
                            <td style="width:25%;"><input id="TimEnd" class="easyui-datetimebox" name="datEndTime"     
        data-options="showSeconds:false"  style="width:auto;margin:0;border:none;padding:0;" /></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="width:100%;"><a style="width:100%;display:block;text-align:center;">时间粒度</a></td>
                        </tr>
                        <tr>
                            <td style="width:25%;"><span style="display:block;text-align:center">月： <input id="SwcBtnMonth" class="easyui-switchbutton" style="height:24px;" /> </span></td>
                            <td style="width:25%;"><span style="display:block;text-align:center">日：<input id="SwcBtnDate" class="easyui-switchbutton" style="height:24px;" /></span></td>
                            <td style="width:25%;"><span style="display:block;text-align:center">小时：<input id="SwcBtnHour" class="easyui-switchbutton" style="height:24px;" /></span></td>
                            <td style="width:25%;"><span style="display:block;text-align:center">分钟：<input id="SwcBtnMinute" class="easyui-switchbutton" style="height:24px;" /></span></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>  
        <div data-options="region:'west',title:'数据区',split:true" style="width:25%;">
            <table id="TblTop" style="width: 100%; height: 100%;overflow:scroll;"></table>
        </div>
        <div data-options="region:'center',title:'图表区'" style="padding:0;background:white;">
            <div id="MyChart" style="width:100%;height:100%;overflow:scroll;"></div>
        </div>   
    </div>
</asp:Content>
