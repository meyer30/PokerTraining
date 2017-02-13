/// <reference name="MicrosoftAjax.js" />
/// <reference path="jquery-3.1.1.js" />



function CallBtn_Click()
{
    //window.alert("hello world ");
    PageMethods.MyWebService("", OnSuccess, OnFail);
    //$.ajax({
    //    type: "GET",
    //    url: "Default.aspx/MyWebService",
    //    success: OnSuccess,
    //    error: OnFail
    //});
    

    return false;
};

function OnSuccess(result) {
    window.alert(JSON.stringify(result));
}

function OnFail(result) {
    window.alert(JSON.stringify(result));
}