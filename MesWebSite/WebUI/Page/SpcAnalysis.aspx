<%@ Page Title="SPC分析" Language="C#" MasterPageFile="~/StructPage.Master" AutoEventWireup="true" CodeBehind="SpcAnalysis.aspx.cs" Inherits="WebUI.Page.SpcAnalysis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/WebSiteScripts/SpcAnalysis.js"></script>
    <script src="/Scripts/echarts.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentWorkSpace" runat="server">
    <div class="easyui-layout" style="width: 100%; height: 100%">
        <div data-options="region:'north',title:'SPC',split:true" style="height:20%;">
            <table border="1" style="width:100%;height:100%">
                        <tr>
                            <td style="width:7%;"><a style="width:100%;display:block;text-align:right;">工站：</a></td>
                            <td style="width:13%;"><select id="CmbEqm" class="easyui-combobox" panelheight="auto" style="width:100%;"></select></td>
                            <td style="width:7%;"><a style="width:100%;display:block;text-align:right;">分析目标：</a></td>
                            <td style="width:13%;"><select id="CmbSpcSetting" class="easyui-combobox" name="analysisItem" panelheight="auto"  data-options="valueField:'spc_setting_no',textField:'spc_setting_name'" style="width:100%;"></select></td>
                            <td style="width:7%;"><a style="width:100%;display:block;text-align:right;">开始时间：</a></td>
                            <td style="width:13%;"><input id="TimStartTime" class="easyui-datetimebox" name="datStartTime"     
        data-options="showSeconds:false" style="width:100%;margin:0;border:none;padding:0;"/></td>
                            <td style="width:7%;"><a style="width:100%;display:block;text-align:right;">结束时间：</a></td>
                            <td style="width:13%;"><input id="TimEndTime" class="easyui-datetimebox" name="datEndTime"     
        data-options="showSeconds:false"  style="width:100%;margin:0;border:none;padding:0;" /></td>
                            <td style="width:7%;"><a style="width:100%;display:block;text-align:right;">型号：</a></td>
                            <td style="width:13%;"><select id="CmbPart" class="easyui-combobox" panelheight="auto" style="width:100%;"></select></td>
                        </tr>
                        <tr>
                            <td style="width:7%;"><a style="width:100%;display:block;text-align:right;">正常值：</a></td>
                            <td style="width:13%;"><input id="txtNomalValue" class="easyui-textbox"   style="width:100%;margin:0;border:none;padding:0;" /></td>
                            <td style="width:7%;"><a style="width:100%;display:block;text-align:right;">宽放值：</a></td>
                            <td style="width:13%;"><input id="txtToleranceValue" class="easyui-textbox"  style="width:100%;margin:0;border:none;padding:0;" /></td>
                            <td style="width:7%;"><a style="width:100%;display:block;text-align:right;">上偏差：</a></td>
                            <td style="width:13%;"><input id="txtUppdiffValue" class="easyui-textbox"  style="width:100%;margin:0;border:none;padding:0;" /></td>
                            <td style="width:7%;"><a style="width:100%;display:block;text-align:right;">下偏差：</a></td>
                            <td style="width:13%;"><input id="txtLowerdiffValue" class="easyui-textbox"  style="width:100%;margin:0;border:none;padding:0;" /></td>
                            
                            <td colspan="2" style="width:20%;">
                                <span style="display:block;text-align:center"><a id="BtnAnalysisData" class="easyui-linkbutton" style="width:200px;text-align:center;">开始分析</a></span>
                            </td>
                        </tr>
                    </table>
            </div>
    <div data-options="region:'center',title:'分布拟合曲线图'">
            <div id="ArcLineChart" style="width:100%;height:100%;overflow:scroll;"></div>
        </div>
        <div data-options="region:'south',title:'样本点散图',split:true" style="height:40%;">
            <table id="DotChart" style="width: 100%; height: 100%;overflow:scroll;"></table>
        </div>    
    </div>
</asp:Content>
