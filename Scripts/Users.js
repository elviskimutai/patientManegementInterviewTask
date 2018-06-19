var username;

function GvUsers_RowClick(s, e) {

    GvUsers.GetRowValues(e.visibleIndex, 'UserName;', GvUsers_GetRowValues);
}

function GvUsers_GetRowValues(values) {

    username = values[0];
    SelectUsers();
    //  DisableField();
}

function OnSuccess(response) {

    cpUsers.PerformCallback();

}
function SelectUsers() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "NewUser.aspx/SelectUser",
        async: false,
        //Pass paramenters to the server side function
        data: JSON.stringify({ UserName: username }),
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            alert("Error: " + response.d);
        },
        error: function (response) {
            alert("Error: " + response.d);
        }
    });
}
function saveUsers() {

    var username = txtUserName.GetText();
    var fullnames = txtFullNames.GetText();
    var password = txtPassword.GetText();

    var secque = txtSecQue.GetText();
    var answer = txtAnswer.GetText();
    var email = txtEmail.GetText();
    var telephone = txtTelephone.GetText();


    // checking validation
    var msg = "";

    if (username === '' || username == null) {
        msg = "Select username to proceed";
        alert(msg);
        return false;
    }
    if (telephone === '' || telephone == null) {
        msg = "Select Telephone to proceed";
        alert(msg);
        return false;
    }
    if (email === '' || email == null) {
        msg = "Select Email to proceed";
        alert(msg);
        return false;
    }
    if (secque === '' || secque == null) {
        msg = "Select secque to proceed";
        alert(msg);
        return false;
    }
    if (answer === '' || answer == null) {
        msg = "Select answer to proceed";
        alert(msg);
        return false;
    }

    if (fullnames === '' || fullnames == null) {
        msg = "Select fullnames to proceed";
        alert(msg);
        return false;
    }
    if (password === '' || password == null) {
        msg = "Select password to proceed";
        alert(msg);
        return false;
    }



    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: "NewUser.aspx/SaveUser",
        //Pass paramenters to the server side function
        async: false,

        data: JSON.stringify({
            username: username, fullnames: fullnames, password: password, secque: secque, answer: answer, email: email, telephone: telephone
        }),
        success: function (response) {
            //Success or failure message e.g. Record saved or not saved successfully
            if (response.d === true) {
                //row = row + 1;
                // if (row === rowcount) {
                alert("Users Saved Successfully");

                GvUsers.Refresh();
                ClearFields();
                //}
            }
            else {
                alert("Users could not be saved");
            }

        },
        error: function (response) {
            var r = jQuery.parseJSON(response.responseText);
            alert("Message: " + r.Message);
            alert("Stackstrace:" + r.StackTrace);
            alert("ExceptionType:" + r.ExceptionType);
        }
    });
}
function DeleteUsers() {
    var username = txtUserName.GetText();
    if (confirm('Are you sure you want to delete Users with username:  ' + username + '?')) {
        //Jquery ajax call to server side method
        $.ajax({
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            //Url is the path of our web method (Page name/function name)

            url: "NewUser.aspx/DeleteUser",
            //Pass paramenters to the server side function
            async: false,
            //Pass paramenters to the server side function
            data: JSON.stringify({ UserName: username }),
            success: function (response) {
                //Success or failure message e.g. Record saved or not saved successfully
                if (response.d == true) {

                    alert("Users deleted successfully");
                    //Refresh grid
                    GvUsers.Refresh();
                    ClearFields();

                }
                else {
                    alert("Users  not deleted");
                }

            },
            error: function (xhr, textStatus, error) {
                //Show error message(if occured)
                alert("Error: " + error);
            }
        });
    }
}
function OnContextMenuItemClick(sender, args) {

    if (args.item.name == "ExportToPDF" || args.item.name == "ExportToXLS" || args.item.name == "ExportToCSV" || args.item.name == "ExportToWord") {
        args.processOnServer = true;
        args.usePostBack = true;
    }

}
function EnableField() {


    txtUserName.SetEnabled(true);
    txtFullNames.SetEnabled(true);
    txtPassword.SetEnabled(true);

    txtSecQue.SetEnabled(true);
   txtAnswer.SetEnabled(true);
    txtEmail.SetEnabled(true);
    txtTelephone.SetEnabled(true);

}
function ClearFields() {

    txtUserName.SetText(" ");
    txtFullNames.SetText(" ");
    txtPassword.SetText(" ");

    txtSecQue.SetText(" ");
    txtAnswer.SetText(" ");
     txtEmail.SetText(" ");
     txtTelephone.SetText(" ");
}