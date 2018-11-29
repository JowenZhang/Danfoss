﻿<%@ Page Title="" Language="C#" MasterPageFile="~/StructPage.Master" AutoEventWireup="true" CodeBehind="FileImportAndPermission.aspx.cs" Inherits="WebUI.Page.FileImportAndPermission" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/WebSiteScripts/FileImportAndPermission.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentWorkSpace" runat="server">
    <div class="easyui-layout" style="width: 100%; height: 100%">
        <div data-options="region:'center'">
            <table id="TblTop" style="width: 100%; height: 100%"></table>
        </div>
    </div>
    <div id="ToolbarTop">
        <a id="TopToolBtnRefresh" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">刷新</a>
        <a id="TopToolBtnAdd" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">新建上传</a><%--添加--%>
        <a id="TopToolBtnApprove" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">审核</a>
        <a id="TopToolBtnView" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">预览</a><%--预览--%>
        <a id="TopToolBtnDelete" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">删除</a>
    </div>
    <div id="TopEditFrm" style="display: none">
        <table>
            <tr>
                <td>
                    <a>选择目标工站：&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbEqm" class="easyui-combobox" panelheight="auto" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>文件类型：&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbFileType" class="easyui-combobox" panelheight="auto" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>选择要上传的文件：&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="FilFile" class="easyui-filebox" name="addFiles" style="width: 200px;" buttontext="选择..." />
                </td>
            </tr>
            <tr>
                <td>
                    <a>描述：&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtFileDesc" class="easyui-textbox" type="text" style="height: 180px; width: 200px" />
                </td>
            </tr>
        </table>
    </div>
    <div id="AssistApproveFrm" style="display: none;">
        <table id="TblAssist" style="width: 100%; height: 70%"></table>
        <table style="width: 100%; height: 30%;" border="1">
            <tr>
                <td>
                    <a>记录</a>
                </td>
                <td>
                    <input id="TxtHistory" class="easyui-textbox" style="width: 100%; height: 100%;" disabled="disabled" />
                </td>
            </tr>
            <tr>
                <td>
                    <a>描述</a>
                </td>
                <td>
                    <input id="TxtDesc" class="easyui-textbox" style="width: 100%; height: 100%;" />
                </td>
            </tr>
        </table>
        <div id="ToolbarAssist">
            <a id="AssistToolBtnApprove" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">通过</a><%--编辑--%>
            <a id="AssistToolBtnAlter" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">修改</a><%--预览--%>
            <a id="AssistToolBtnCancel" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">取消</a><%--编辑--%>
            <a id="AssistToolBtnReject" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">驳回</a><%--编辑--%>
        </div>
    </div>
</asp:Content>
