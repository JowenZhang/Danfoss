<%@ Page Title="工站互锁" Language="C#" MasterPageFile="~/StructPage.Master" AutoEventWireup="true" CodeBehind="EqmLock.aspx.cs" Inherits="WebUI.Page.EqmLock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/MyCSS/MyCSS.css" rel="stylesheet" />
    <script src="/WebSiteScripts/EqmLock.js"></script>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentWorkSpace" runat="server">
    <div id="PnlKanpan" style="width: 100%; height: 100%">
            <table style="width: 100%; height: 100%; background-color: black;" border="1">
                    <%--<tr class="lock-title-row">
                        <th class="lock-title lock-eqm-title">工站</th>
                        <th class="lock-title lock-eqm-status">互锁状态</th>
                        <th class="lock-title lock-eqm-title">互锁工站</th>
                        <th class="lock-title lock-eqm-title">工站</th>
                        <th class="lock-title lock-eqm-status">互锁状态</th>
                        <th class="lock-title lock-eqm-title">互锁工站</th>                        
                    </tr>
                    <tr class="lock-row">
                        <td id="Td1" class="td-eqm">OP1</td>
                        <td class="td-lock-status"><img id="Img1" class="pic-lock-status" src="/pic/unlock.png" alt="" /></td>
                        <td id="Td2" class="td-eqm">无互锁</td> 
                                               
                        <td id="Td3" class="td-eqm">OP1</td>
                        <td class="td-lock-status"><img id="Img2" class="pic-lock-status" src="/pic/unlock.png" alt="" /></td>
                        <td id="Td4" class="td-eqm">无互锁</td>
                    </tr>
                    <tr class="lock-row">
                        <td id="Td5" class="td-eqm">OP1</td>
                        <td class="td-lock-status"><img id="Img3" class="pic-lock-status" src="/pic/unlock.png" alt="" /></td>
                        <td id="Td6" class="td-eqm">无互锁</td>
                        
                        <td id="Td7" class="td-eqm">OP1</td>
                        <td class="td-lock-status"><img id="Img4" class="pic-lock-status" src="/pic/unlock.png" alt="" /></td>
                        <td id="Td8" class="td-eqm">无互锁</td>
                    </tr>
                    <tr class="lock-row">
                        <td id="Td9" class="td-eqm">OP1</td>
                        <td class="td-lock-status"><img id="Img5" class="pic-lock-status" src="/pic/unlock.png" alt="" /></td>
                        <td id="Td10" class="td-eqm">无互锁</td>
                        
                        <td id="Td11" class="td-eqm">OP1</td>
                        <td class="td-lock-status"><img id="Img6" class="pic-lock-status" src="/pic/unlock.png" alt="" /></td>
                        <td id="Td12" class="td-eqm">无互锁</td>
                    </tr>
                    <tr class="lock-row">
                        <td id="Td13" class="td-eqm">OP1</td>
                        <td class="td-lock-status"><img id="Img7" class="pic-lock-status" src="/pic/unlock.png" alt="" /></td>
                        <td id="Td14" class="td-eqm">无互锁</td>
                        
                        <td id="Td15" class="td-eqm">OP1</td>
                        <td class="td-lock-status"><img id="Img8" class="pic-lock-status" src="/pic/unlock.png" alt="" /></td>
                        <td id="Td16" class="td-eqm">无互锁</td>
                    </tr>
                    <tr class="lock-row">
                        <td id="Td17" class="td-eqm">OP1</td>
                        <td class="td-lock-status"><img id="Img9" class="pic-lock-status" src="/pic/unlock.png" alt="" /></td>
                        <td id="Td18" class="td-eqm">无互锁</td>
                        
                        <td id="Td19" class="td-eqm">OP1</td>
                        <td class="td-lock-status"><img id="Img10" class="pic-lock-status" src="/pic/unlock.png" alt="" /></td>
                        <td id="Td20" class="td-eqm">无互锁</td>
                    </tr>--%>
                <tr style="height:10%;">
                        <th style="font-family:'Microsoft JhengHei';font-size:36px;width:20%;color:white;font-weight:bolder;">工站</th>
                        <th style="font-family:'Microsoft JhengHei';font-size:36px;width:10%;color:white;font-weight:bolder;">互锁状态</th>
                        <th style="font-family:'Microsoft JhengHei';font-size:36px;width:20%;color:white;font-weight:bolder;">互锁工站</th>
                        <th style="font-family:'Microsoft JhengHei';font-size:36px;width:20%;color:white;font-weight:bolder;">工站</th>
                        <th style="font-family:'Microsoft JhengHei';font-size:36px;width:10%;color:white;font-weight:bolder;">互锁状态</th>
                        <th style="font-family:'Microsoft JhengHei';font-size:36px;width:20%;color:white;font-weight:bolder;">互锁工站</th>                        
                    </tr>
                    <tr style="height:18%;">
                        <td id="EqmOrignal1" style="font-family:'Microsoft JhengHei';font-size:48px;width:20%;color:white;font-weight:bolder;">OP1</td>
                        <td class="td-lock-status"><img id="Img1" style="width:180px;height:90px;" src="/pic/unlock.png" alt="" /></td>
                        <td id="EqmDestiny1" style="font-family:'Microsoft JhengHei';font-size:48px;width:20%;color:white;font-weight:bolder;">无互锁</td> 
                                               
                        <td id="EqmOrignal2" style="font-family:'Microsoft JhengHei';font-size:48px;width:20%;color:white;font-weight:bolder;">OP1</td>
                        <td class="td-lock-status"><img id="Img2" style="width:180px;height:90px;" src="/pic/unlock.png" alt="" /></td>
                        <td id="EqmDestiny2" style="font-family:'Microsoft JhengHei';font-size:48px;width:20%;color:white;font-weight:bolder;">无互锁</td>
                    </tr>
                    <tr style="height:18%;">
                        <td id="EqmOrignal3" style="font-family:'Microsoft JhengHei';font-size:48px;width:20%;color:white;font-weight:bolder;">OP1</td>
                        <td class="td-lock-status"><img id="Img3" style="width:180px;height:90px;" src="/pic/unlock.png" alt="" /></td>
                        <td id="EqmDestiny3" style="font-family:'Microsoft JhengHei';font-size:48px;width:20%;color:white;font-weight:bolder;">无互锁</td>
                        
                        <td id="EqmOrignal4" style="font-family:'Microsoft JhengHei';font-size:48px;width:20%;color:white;font-weight:bolder;">OP1</td>
                        <td class="td-lock-status"><img id="Img4" style="width:180px;height:90px;" src="/pic/unlock.png" alt="" /></td>
                        <td id="EqmDestiny4" style="font-family:'Microsoft JhengHei';font-size:48px;width:20%;color:white;font-weight:bolder;">无互锁</td>
                    </tr>
                    <tr style="height:18%;">
                        <td id="EqmOrignal5" style="font-family:'Microsoft JhengHei';font-size:48px;width:20%;color:white;font-weight:bolder;">OP1</td>
                        <td class="td-lock-status"><img id="Img5" style="width:180px;height:90px;" src="/pic/unlock.png" alt="" /></td>
                        <td id="EqmDestiny5" style="font-family:'Microsoft JhengHei';font-size:48px;width:20%;color:white;font-weight:bolder;">无互锁</td>
                        
                        <td id="EqmOrignal6" style="font-family:'Microsoft JhengHei';font-size:48px;width:20%;color:white;font-weight:bolder;">OP1</td>
                        <td class="td-lock-status"><img id="Img6" style="width:180px;height:90px;" src="/pic/unlock.png" alt="" /></td>
                        <td id="EqmDestiny6" style="font-family:'Microsoft JhengHei';font-size:48px;width:20%;color:white;font-weight:bolder;">无互锁</td>
                    </tr>
                    <tr style="height:18%;">
                        <td id="EqmOrignal7" style="font-family:'Microsoft JhengHei';font-size:48px;width:20%;color:white;font-weight:bolder;">OP1</td>
                        <td class="td-lock-status"><img id="Img7" style="width:180px;height:90px;" src="/pic/unlock.png" alt="" /></td>
                        <td id="EqmDestiny7" style="font-family:'Microsoft JhengHei';font-size:48px;width:20%;color:white;font-weight:bolder;">无互锁</td>
                        
                        <td id="EqmOrignal8" style="font-family:'Microsoft JhengHei';font-size:48px;width:20%;color:white;font-weight:bolder;">OP1</td>
                        <td class="td-lock-status"><img id="Img8" style="width:180px;height:90px;" src="/pic/unlock.png" alt="" /></td>
                        <td id="EqmDestiny8" style="font-family:'Microsoft JhengHei';font-size:48px;width:20%;color:white;font-weight:bolder;">无互锁</td>
                    </tr>
                    <tr style="height:18%;">
                        <td id="EqmOrignal9" style="font-family:'Microsoft JhengHei';font-size:48px;width:20%;color:white;font-weight:bolder;">OP1</td>
                        <td class="td-lock-status"><img id="Img9" style="width:180px;height:90px;" src="/pic/unlock.png" alt="" /></td>
                        <td id="EqmDestiny9" style="font-family:'Microsoft JhengHei';font-size:48px;width:20%;color:white;font-weight:bolder;">无互锁</td>
                        
                        <td id="EqmOrignal10" style="font-family:'Microsoft JhengHei';font-size:48px;width:20%;color:white;font-weight:bolder;">OP1</td>
                        <td class="td-lock-status"><img id="Img10" style="width:180px;height:90px;" src="/pic/unlock.png" alt="" /></td>
                        <td id="EqmDestiny10" style="font-family:'Microsoft JhengHei';font-size:48px;width:20%;color:white;font-weight:bolder;">无互锁</td>
                    </tr>
                </table>
    </div>
</asp:Content>
