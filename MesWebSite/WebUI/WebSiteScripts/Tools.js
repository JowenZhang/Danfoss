/// <reference path="../Scripts/jquery.base64.js" />
//64位格式转换
function strBase64(orignalStr) {
    $.base64.utf8encode = true;
    return $.base64.btoa(orignalStr);
};


//64位格式转换
function strBase64Reverse(orignalStr) {
    $.base64.utf8decode = true;
    return $.base64.atob(orignalStr);
};