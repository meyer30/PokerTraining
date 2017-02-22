/// <reference name="MicrosoftAjax.js" />
/// <reference path="jquery-3.1.1.js" />



function CallBtn_Click()
{
    //PageMethods.MyWebService("", OnSuccess, OnFail);
    //WebService1.HelloWorld("", OnSuccess, OnFail);
    

    $.ajax({
        type: "POST",
        url: "Default.aspx/ShouldUserCall",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        success: OnSuccess,
        error: OnFail,
        dataType: "text",
    });
    return false;
};

function FoldBtn_Click() {
    
    //$.ajax({
    //    type: "POST",
    //    url: "Default.aspx/ShouldUserCall",
    //    data: "{}",
    //    contentType: "application/json; charset=utf-8",
    //    success: OnSuccess,
    //    error: OnFail,
    //    dataType: "text",
    //});
    return false;
};


function OnSuccess(result) {
    window.alert(JSON.stringify(result));
}

function OnFail(result) {
    window.alert(JSON.stringify(result));
}