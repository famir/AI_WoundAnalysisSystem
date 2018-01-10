function AskConfirmation(msg, successURL, MessageType) {
    if (MessageType == "DANGER") {
        BootstrapDialog.confirm({
            title: 'Warning',
            message: msg,
            type: BootstrapDialog.TYPE_DANGER, // <-- Default value is BootstrapDialog.TYPE_PRIMARY
            closable: true, // <-- Default value is false
            draggable: false, // <-- Default value is false
            btnOKLabel: 'Yes', // <-- Default value is 'OK',
            btnCancelLabel: 'No', // <-- Default value is 'Cancel',
            btnCancelClass: 'btn btn-sm btn-cancel',
            btnOKClass: 'btn btn-sm btn-primary', // <-- If you didn't specify it, dialog type will be used,
            callback: function (result) {
                // result will be true if button was click, while it will be false if users close the dialog directly.
                if (result) {
                    window.location.replace(successURL);
                    return true;
                } else {
                    return false;
                }
            }
        });
    }
    else {
        BootstrapDialog.confirm({
            title: 'Information',
            message: msg,
            type: BootstrapDialog.TYPE_INFO, // <-- Default value is BootstrapDialog.TYPE_PRIMARY
            closable: true, // <-- Default value is false
            draggable: false, // <-- Default value is false
            btnOKLabel: 'Yes', // <-- Default value is 'OK',
            btnCancelLabel: 'No', // <-- Default value is 'Cancel',
            btnCancelClass: 'btn btn-sm btn-cancel',
            btnOKClass: 'btn btn-sm btn-primary', // <-- If you didn't specify it, dialog type will be used,
            callback: function (result) {
                // result will be true if button was click, while it will be false if users close the dialog directly.
                if (result) {
                    window.location.replace(successURL);
                    return true;
                } else {
                    return false;
                }
            }
        });
    }
    return false;
}

function SuccesMessage(msg, title) {
    BootstrapDialog.show({
        message: msg,
        title: title,
        type: BootstrapDialog.TYPE_SUCCESS,
        buttons: [{
            label: 'Ok',
            cssClass: 'btn btn-sm btn-primary',
            action: function (dialogItself) {
                dialogItself.close();
            }
        }]
    });
}
function ErrorMessage(msg, title) {
    BootstrapDialog.show({
        message: msg,
        title: title,
        type: BootstrapDialog.TYPE_DANGER,
        buttons: [{
            label: 'Ok',
            cssClass: 'btn btn-sm btn-primary',
            action: function (dialogItself) {
                dialogItself.close();
            }
        }]
    });
}

function AlertMessage(msg, title) {
    BootstrapDialog.show({
        message: msg,
        title: title,
        type: BootstrapDialog.TYPE_INFO,
        buttons: [{
            label: 'Ok',
            action: function (dialogItself) {
                dialogItself.close();
            }
        }]
    });
}


//dialog boxes for ajax calls--
function GetConfirm(strMsg, yesFunction, noFunction) {
    BootstrapDialog.show({
        title: 'Confirm Action',
        type: BootstrapDialog.TYPE_INFO,
        message: strMsg,
        buttons: [{
            label: 'No',
            cssClass: 'btn btn-sm btn-cancel',
            action: function (dialog) {
                if (noFunction) noFunction();
                dialog.close();
            }
        }, {
            label: 'Yes',
            hotkey: 13, // Enter.
            cssClass: 'btn btn-sm btn-primary',
            action: function (dialog) {
                if (yesFunction) yesFunction();
                dialog.close();
            }
        }]
    });
}

function GetAlert(strMsg) {
    BootstrapDialog.show({
        title: 'Information',
        type: BootstrapDialog.TYPE_INFO,
        message: strMsg,
        buttons: [{
            label: 'Ok',
            cssClass: 'btn btn-sm btn-primary',
            action: function (dialog) {
                dialog.close();
            }
        }]
    });
}

/*------ For pathway partial view in Visiyt page---------------------*/
function DeleteConfirmationWithAjaxCall(msg, successURL)
{
    BootstrapDialog.confirm({
        title: 'Warning',
        message: msg,
        type: BootstrapDialog.TYPE_DANGER, // <-- Default value is BootstrapDialog.TYPE_PRIMARY
        closable: true, // <-- Default value is false
        draggable: false, // <-- Default value is false
        btnOKLabel: 'Yes', // <-- Default value is 'OK',
        btnCancelLabel: 'No', // <-- Default value is 'Cancel',
        btnCancelClass: 'btn btn-sm btn-cancel',
        btnOKClass: 'btn btn-sm btn-primary', // <-- If you didn't specify it, dialog type will be used,
        callback: function (result) {
            // result will be true if button was click, while it will be false if users close the dialog directly.
            if (result) {
                // window.location.replace(successURL);
                $.get(successURL,
                          function (data, status) {
                              GetAlert("Deleted successfully");
                              $("#dvPathwayList").html('<div>' + data + '</div>');
                              return false;
                          });
                return false;
            } else {
                return false;
            }
        }
    });
    return false;
}