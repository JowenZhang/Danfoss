<%@ Page Title="用户管理" Language="C#" MasterPageFile="~/StructPage.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="WebUI.Page.User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/WebSiteScripts/User.js"></script>
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
        <a id="TopToolBtnEdit" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">编辑</a>
        <a id="TopToolBtnAdd" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">添加</a>
        <a id="TopToolBtnDelete" class="easyui-linkbutton" style="margin: 0px; width: auto; height: auto;">删除</a>
    </div>
    <div id="TopEditFrm" style="display:none" style="display: none;">
        <table>
            <tr>
                <td>
                    <a>用户编号:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtUserNo" class="easyui-textbox" type="text" style="width: 200px;" />
                </td>
            </tr>
            <tr>
                <td>
                    <a>用户名称:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtUserName" class="easyui-textbox" type="text" style="width: 200px;" />
                </td>
            </tr>
            <tr>
                <td>
                    <a>状态:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbStatusTop" class="easyui-combobox" panelheight="auto" data-options="valueField:'status_no',textField:'status_name'" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>用户卡ID:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtUserCardId" class="easyui-textbox" type="text" style="width: 200px;" />
                </td>
            </tr>
            <tr>
                <td>
                    <a>用户卡号:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtUserCardNo" class="easyui-textbox" type="text" style="width: 200px;" />
                </td>
            </tr>
            <tr>
                <td>
                    <a>密码:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtUserPwd" class="easyui-textbox" type="password" style="width: 200px;" />
                </td>
            </tr>
            <tr>
                <td>
                    <a>性别:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbUserGender" class="easyui-combobox" panelheight="auto" data-options="valueField:'gender_no',textField:'gender_name'" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>允许登陆:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbLoginable" class="easyui-combobox" panelheight="auto" data-options="valueField:'bool_value',textField:'bool_mask'" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>允许修改密码:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbPwdChangeable" class="easyui-combobox" panelheight="auto" data-options="valueField:'bool_value',textField:'bool_mask'" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>职位:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtUserPosition" class="easyui-textbox" type="text" style="width: 200px;" />
                </td>
            </tr>
            <tr>
                <td>
                    <a>邮箱:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtUserEmail" class="easyui-textbox" type="text" style="width: 200px;" />
                </td>
            </tr>
            <tr>
                <td>
                    <a>电话:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtUserPhone" class="easyui-textbox" type="text" style="width: 200px;" />
                </td>
            </tr>
            <tr>
                <td>
                    <a>手机:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtUserMobile" class="easyui-textbox" type="text" style="width: 200px;" />
                </td>
            </tr>
            <tr>
                <td>
                    <a>地址:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <input id="TxtUserAddress" class="easyui-textbox" type="text" style="width: 200px;" />
                </td>
            </tr>
            <tr>
                <td>
                    <a>公司:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbCompany" class="easyui-combobox" panelheight="auto" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>部门:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbDept" class="easyui-combobox" panelheight="auto" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>工厂:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbFactory" class="easyui-combobox" panelheight="auto" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>车间:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbWorkshop" class="easyui-combobox" panelheight="auto" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>产线:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbLine" class="easyui-combobox" panelheight="auto" style="width: 200px;"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <a>是否为作业员:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbIsWorker" class="easyui-combobox" panelheight="auto" data-options="valueField:'bool_value',textField:'bool_mask'" style="width: 200px;"></select>
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
                    <a>用户:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbUser" class="easyui-combobox" panelheight="400px" style="width: 200px;"></select>
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
                    <a>权限组:&nbsp;&nbsp;</a>
                </td>
                <td>
                    <select id="CmbAuthGroup" class="easyui-combobox" panelheight="auto" style="width: 200px;"></select>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
