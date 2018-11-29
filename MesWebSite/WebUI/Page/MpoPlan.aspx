<%@ Page Title="生产计划" Language="C#" MasterPageFile="~/StructPage.Master" AutoEventWireup="true" CodeBehind="MpoPlan.aspx.cs" Inherits="WebUI.Page.MpoPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/WebSiteScripts/MpoPlan.js"></script>
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
        <a id="TopToolBtnConfirmStart" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">确认下发</a>
        <a>型号:</a>
        <input id="TopToolTxtPartNo" class="easyui-textbox" style="width: 150px; height: 32px" />
        <a>开始日期:</a>
        <input id="TopToolDatStartTime" class="easyui-datebox" style="width: 150px" />
        <a>结束日期:</a>
        <input id="TopToolDatEndTime" class="easyui-datebox" style="width: 150px" />
        <a id="TopToolBtnSearch" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">检索</a>
        <%--<a id="TopToolBtnEdit" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">编辑</a>
        <a id="TopToolBtnAdd" class="easyui-linkbutton"  style="margin: 0px; width: auto; height: auto;">添加</a>
        <a id="TopToolBtnDelete" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">删除</a>--%>
    </div>
    <div id="TopEditFrm" style="display: none">
        <table>
            <tr>
                <td>
                    <a>计划单号:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtMpoNoTop" class="easyui-textbox" type="text" style="width: 200px" />
                </td>
            </tr>
            <tr>
                <td>
                    <a>订单状态:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbCommitStatusTop" class="easyui-combobox" panelheight="auto" data-options="valueField:'status_no',textField:'status_name'" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>生产状态:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbProcedureStatusTop" class="easyui-combobox" panelheight="auto" data-options="valueField:'status_no',textField:'status_name'" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>订单数量:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="NumMpoQty" class="easyui-numberspinner" style="width: 200px" />
                </td>
            </tr>
            <tr>
                <td>
                    <a>期望开工时间:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="DatMpoHopeStartTime" class="easyui-datebox" style="width: 200px" />
                </td>
            </tr>
            <tr>
                <td>
                    <a>期望完工时间:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="DatMpoHopeEndTime" class="easyui-datebox" style="width: 200px" />
                </td>
            </tr>
        </table>
    </div>
    <div id="TopConfirmStartFrm" style="display: none">
        <table>
            <tr>
                <td>
                    <a>计划开工时间:&nbsp;&nbsp</a>
                </td>
                <td>
                    <input id="NewDatMpoHopeStartTime" class="easyui-datebox" style="width: 150px" />
                </td>
                <td>
                    <a>计划完工时间:&nbsp;&nbsp</a>
                </td>
                <td>
                    <input id="NewDatMpoHopeEndTime" class="easyui-datebox" style="width: 150px" />
                </td>
            </tr>
        </table>
    </div>
    <div id="ToolbarBottom">
        <a id="BottomToolBtnRefresh" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">刷新</a>
        <a id="BottomToolBtnEdit" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">编辑</a>
        <a id="BottomToolBtnAdd" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">添加</a>
        <a id="BottomToolBtnDelete" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">删除</a>
    </div>
    <div id="BottomEditFrm" style="display: none;">
        <table>
            <tr>
                <td>
                    <a>计划单号:&nbsp;&nbsp</a>
                </td>
                <td>
                    <input id="TxtMpoNoBottom" class="easyui-textbox" type="text"  style="width:200px;"/>
                </td>
            </tr>
            <tr>
                <td>
                    <a>序列号:&nbsp;&nbsp</a>
                </td>
                <td>
                    <input id="TxtSerialNo" class="easyui-textbox" type="text" style="width:200px;"/>
                </td>
            </tr>
            <tr>
                <td>
                    <a>状态:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbStatusBottom" class="easyui-combobox" panelheight="auto" data-options="valueField:'status_no',textField:'status_name'" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>件数:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="NumItemQty" class="easyui-numberspinner" type="number" style="width: 200px;" />
                </td>
            </tr>
            <tr>
                <td>
                    <a>型号:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtPartNo" class="easyui-textbox" type="text" style="width: 200px;" />
                </td>
            </tr>
            <tr>
                <td>
                    <a>期望生产时间:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="DtmHopeProductTime" class="easyui-datetimebox" style="width: 200px"  />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
