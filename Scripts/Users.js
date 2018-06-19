var UserName;
var active = true;
var superuser = false;
var immediatechange = false;
function GvUsers_RowClick(s, e) {
    GvUsers.GetRowValues(e.visibleIndex, 'UserName;', GvUsers_GetRowValues);
}
function GvUsers_GetRowValues(values) {
    UserName = values[0];
    GetUser();
    DisableField();
}
function ResetPassword() {
    var OldPassword = txtOldPassword.GetText();
    var password = txtNewPassword.GetText();
 
    var msg = "";
    if (OldPassword === '') {
        msg = "Enter OldPassword to proceed";
        alert(msg);
        return false;
    }
    if (password === '') {
        msg = "Enter password to proceed";
        alert(msg);
        return false;
    }
 
    //Jquery ajax call to server side method
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        //Url is the path of our web method (Page name/function name)
        url: "PasswordReset.aspx/SaveUserPasswordReset",
        //Pass paramenters to the server side function
        async: false,
        data: JSON.stringify({ OldPassword: OldPassword, password: password }),
        success: function (response) {
            //Success or failure message e.g. Record saved or not saved successfully
            if (response.d == "Success") {

                alert("Pasword Reset Successfully");
            }
            else {
                alert("password could not be be reset");
            }

        },
        error: function (xhr, textStatus, error) {
            //Show error message(if occured)
            alert("Error: " + error);
        }
    });
}
function ApproveUser() {
    var username = UserName;
    var msg = "";
    if (username === '') {
        msg = "Select username to proceed";
        alert(msg);
        return false;
    }
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        //Url is the path of our web method (Page name/function name)
        url: "ApproveSignUps.aspx/ApprovePendingUsers",
        //Pass paramenters to the server side function
        async: false,
        data: JSON.stringify({ UserName: username }),
        success: function (response) {
            //Success or failure message e.g. Record saved or not saved successfully
            if (response.d !== '0') {

                alert("User approved successfully");
                //Refresh grid
                LoadingPanel.Hide();
                GvUsers.Refresh();
                //DeleteSignUpBuffer();
                DeleteSignUpApprovalBuffer();
            }
            else {
                alert("User not approved");
            }

        },
        error: function (xhr, textStatus, error) {
            //Show error message(if occured)
            alert("Error: " + error);
        }
    });
}


function UpdatePUserProfile() {
    var UserName = txtUserName.GetText();
    var fullnames = txtFullNames.GetText();
    var email = txtEmail.GetText();
    var telephone = txtMobile.GetText();
   // var CCCode = glCostCenter.GetGridView().GetRowKey(glCostCenter.GetGridView().GetFocusedRowIndex());
    var msg = "";
    if (fullnames === '') {
        msg = "Enter fullnames to proceed";
        alert(msg);
        return false;
    }
    if (email === '') {
        msg = "Enter email to proceed";
        alert(msg);
        return false;
    }
    if (telephone === '') {
        msg = "Enter telephone to proceed";
        alert(msg);
        return false;
    }
    //if (CCCode === '') {
    //    msg = "Enter Costcenter to proceed";
    //    alert(msg);
    //    return false;
    //}

    //Jquery ajax call to server side method
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        //Url is the path of our web method (Page name/function name)
        url: "EditProfile.aspx/UpdatePUserProfiles",
        //Pass paramenters to the server side function
        async: false,
        data: JSON.stringify({ UserName: UserName, fullnames: fullnames, email: email, telephone: telephone}),
        success: function (response) {
            //Success or failure message e.g. Record saved or not saved successfully
            if (response.d == true) {

                alert("User Profile Updated Successfully");
            }
            else {
                alert("User profile failed to update");
            }

        },
        error: function (xhr, textStatus, error) {
            //Show error message(if occured)
            alert("Error: " + error);
        }
    });
}

function DeleteUser() {
    var username = txtUserName.GetText();
    var msg = "";
    if (username === '') {
        msg = "Select username to proceed";
        alert(msg);
        return false;
    }
    if (confirm('Are you sure you want to delete user with username ' + username + '?')) {
        //Jquery ajax call to server side method
        $.ajax({
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            //Url is the path of our web method (Page name/function name)
            url: "Users.aspx/DeleteUser",
            //Pass paramenters to the server side function
            async: false,
            data: JSON.stringify({ username: username }),
            success: function (response) {
                //Success or failure message e.g. Record saved or not saved successfully
                if (response.d == true) {

                    alert("User deleted successfully");
                    //Refresh grid
                    GvUsers.Refresh();
                    //LoadRecord();
                }
                else {
                    alert("User failed to delete");
                }

            },
            error: function (xhr, textStatus, error) {
                //Show error message(if occured)
                alert("Error: " + error);
            }
        });
    }
}
function GetUser() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Users.aspx/SelectUser",
        async: false,
        data: JSON.stringify({ username: UserName }),
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
function OnSuccess(response) {
    var xmlDoc = $.parseXML(response.d);
    var xml = $(xmlDoc);
    var usersData = xml.find("Users");
    txtUserName.SetText($(usersData).find("UserName").text());
    txtFullNames.SetText($(usersData).find("FullNames").text());
    txtPassword.SetText($(usersData).find("Password").text());
    txtConfirmPassword.SetText($(usersData).find("ConfirmPassword").text());
    txtEmail.SetText($(usersData).find("Email").text());
    txtExpiresAfter.SetText($(usersData).find("ExpiresAfter").text());
    dtpExpiryDate.SetDate(new Date($(usersData).find("ExpiryDate").text()));
    txtNarration.SetText($(usersData).find("Narration").text());
    txtSecQue.SetText($(usersData).find("Question").text());
    txtAnswer.SetText($(usersData).find("Answer").text());
    txtTelephone.SetText($(usersData).find("Telephone").text());
    txtLockAfter.SetText($(usersData).find("LockAfter").text());
    txtBioUserId.SetText($(usersData).find("BioUserID").text());
    if (($(usersData).find("IsActive").text()) === 'false') {
        chkActive.SetChecked(false);
    }
    if (($(usersData).find("IsActive").text()) === 'true') {
        chkActive.SetChecked(true);
    }
    if (($(usersData).find("SuperUser").text()) === 'false') {
        chkSuperuser.SetChecked(false);
    }
    if (($(usersData).find("SuperUser").text()) === 'true') {
        chkSuperuser.SetChecked(true);
    }
    if (($(usersData).find("ImmediateChange").text()) === 'false') {
        chkImmediateChange.SetChecked(false);
    }
    if (($(usersData).find("ImmediateChange").text()) === 'true') {
        chkImmediateChange.SetChecked(true);
    }
    immediatechange = $(usersData).find("ImmediateChange").text();
    active = $(usersData).find("IsActive").text();
    superuser = $(usersData).find("SuperUser").text();
    glCostCenter.SetValue($(usersData).find("CCCode").text());
}
function GetChkActiveValue(s, e) {
    var isactive = s.GetChecked();
    if (isactive == true) {
        active = true;
    }
    else {
        active = false;
    }
}
function GetChkSuperuserValue(s, e) {
    var issuperuser = s.GetChecked();
    if (issuperuser == true) {
        superuser = true;
    }
    else {
        superuser = false;
    }
}
function GetChkImmediatechangeValue(s, e) {
    var immediate = s.GetChecked();
    if (immediate == true) {
        immediatechange = true;
    }
    else {
        immediatechange = false;
    }
}
function DisableField() {
    txtUserName.SetEnabled(false);
    txtFullNames.SetEnabled(false);
    txtPassword.SetEnabled(false);
    txtConfirmPassword.SetEnabled(false);
    chkActive.SetEnabled(false);
    txtEmail.SetEnabled(false);
    //chkSuperuser.SetEnabled(false);
    chkSuperuser.SetEnabled(false);
    txtExpiresAfter.SetEnabled(false);
    dtpExpiryDate.SetEnabled(false);
    txtNarration.SetEnabled(false);
    txtSecQue.SetEnabled(false);
    txtAnswer.SetEnabled(false);
    txtTelephone.SetEnabled(false);
    txtLockAfter.SetEnabled(false);
    chkImmediateChange.SetEnabled(false);
    txtBioUserId.SetEnabled(false);
    glCostCenter.SetEnabled(false);
}
function EnableField() {
    txtUserName.SetEnabled(true);
    txtFullNames.SetEnabled(true);
    txtPassword.SetEnabled(true);
    txtConfirmPassword.SetEnabled(true);
    chkActive.SetEnabled(true);
    txtEmail.SetEnabled(true);
    chkSuperuser.SetEnabled(true);
    txtExpiresAfter.SetEnabled(true);
    dtpExpiryDate.SetEnabled(true);
    txtNarration.SetEnabled(true);
    txtSecQue.SetEnabled(true);
    txtAnswer.SetEnabled(true);
    txtTelephone.SetEnabled(true);
    txtLockAfter.SetEnabled(true);
    chkImmediateChange.SetEnabled(true);
    txtBioUserId.SetEnabled(true);
    glCostCenter.SetEnabled(true);
}

function ClearFields() {
    txtUserName.SetText('');
    txtPassword.SetText('');
    txtConfirmPassword.SetText('');
    txtEmail.SetText('');
    txtConfirmPassword.SetText('');
    txtNarration.SetText('');
    txtSecQue.SetText('');
    txtAnswer.SetText('');
    txtTelephone.SetText('');
    txtLockAfter.SetText('');
    txtBioUserId.SetText('');
    txtExpiresAfter.SetText('');
    dtpExpiryDate.SetDate(new Date);
}
function SaveUser() {
    var username = txtUserName.GetText();
    var fullnames = txtFullNames.GetText();
    var password = txtPassword.GetText();
    var cpassword = txtConfirmPassword.GetText();
    var email = txtEmail.GetText();
    var narration = txtNarration.GetText();
    var question = txtSecQue.GetText();
    var answer = txtAnswer.GetText();
    var telephone = txtTelephone.GetText();
    var lockafter = txtLockAfter.GetText();
    var biouserid = txtBioUserId.GetText();
    var expirydate = dtpExpiryDate.GetText();
    var expiresafter = txtExpiresAfter.GetText();
    var costcenter = glCostCenter.GetGridView().GetRowKey(glCostCenter.GetGridView().GetFocusedRowIndex());
    var msg = "";
    //check for validation
    if (username === '') {
        msg = "Enter username to proceed";
        alert(msg);
        return false;
    }
    if (fullnames === '') {
        msg = "Enter fullnames to proceed";
        alert(msg);
        return false;
    }
    if (password === '') {
        msg = "Enter password to proceed";
        alert(msg);
        return false;
    }
    if (cpassword === '') {
        msg = "Enter confirm password to proceed";
        alert(msg);
        return false;
    }
    if (cpassword != password) {
        msg = "passwords do not match";
        alert(msg);
        return false;
    }
    if (narration === '') {
        narration = "New user";
    }
    if (lockafter === '') {
        lockafter = "3";
    }
    if (email === '') {
        email = "N/A";
    }
    if (question === '') {
        question = "N/A";
    }
    if (answer === '') {
        answer = "N/A";
    }
    if (biouserid === '') {
        biouserid = "0";
    }
    if (costcenter === '') {
        slogan = "001";
    }
    if (expiresafter === '') {
        expiresafter = "30300";
    }
    if (expirydate === '') {
        expirydate = "2099-01-01";
    }
    if (telephone === '') {
        telephone = 'N/A';
    }
    if (msg.length === 0) {
        //Jquery ajax call to server side method
        $.ajax({
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            //Url is the path of our web method (Page name/function name)
            url: "Users.aspx/SaveUser",
            //Pass paramenters to the server side function
            data: JSON.stringify({
                username: username,fullnames: fullnames, password: password, cpassword: cpassword, active: active, superuser: superuser, expiresafter: expiresafter, expirydate: expirydate,
                narration: narration, secque: question, answer: answer, email: email, telephone: telephone, lockafter: lockafter, immediatechange: immediatechange,
                biouserid: biouserid, costcenter: costcenter
            }),
            success: function (response) {
                //Success or failure message e.g. Record saved or not saved successfully
                if (response.d === true) {

                    alert("User saved successfully");
                    //Reset controls                          
                    ClearFields();
                    //Enable some fields
                    txtExpiresAfter.SetEnabled(true);
                    dtpExpiryDate.SetEnabled(true);
                    //clear session storage
                    ClearCachedData();
                    //Refresh grid
                    GvUsers.Refresh();


                }
                else {
                    alert("User failed to save");
                }

            },
            error: function (xhr, textStatus, error) {
                //Show error message(if occured)
                alert("Error: " + error);
            }
        });
    }

}
function UpdateUserProfile() {
    var fullnames = txtFullNames.GetText();
    var email = txtEmail.GetText();
    var telephone = txtMobile.GetText();
    var msg = "";
    if (fullnames === '') {
        msg = "Enter fullnames to proceed";
        alert(msg);
        return false;
    }
    if (email === '') {
        msg = "Enter email to proceed";
        alert(msg);
        return false;
    }
    if (telephone === '') {
        msg = "Enter telephone to proceed";
        alert(msg);
        return false;
    }

    //Jquery ajax call to server side method
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        //Url is the path of our web method (Page name/function name)
        url: "ChangeProfile.aspx/UpdateUser",
        //Pass paramenters to the server side function
        async: false,
        data: JSON.stringify({ fullnames: fullnames, email: email, telephone: telephone }),
        success: function (response) {
            //Success or failure message e.g. Record saved or not saved successfully
            if (response.d == true) {

                alert("User Profile Updated Successfully");
            }
            else {
                alert("User profile failed to update");
            }

        },
        error: function (xhr, textStatus, error) {
            //Show error message(if occured)
            alert("Error: " + error);
        }
    });
}
function ApproveUser() {
    var username = UserName;
    var msg = "";
    if (username === '') {
        msg = "Select username to proceed";
        alert(msg);
        return false;
    }
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        //Url is the path of our web method (Page name/function name)
        url: "ApproveSignUps.aspx/ApprovePendingUsers",
        //Pass paramenters to the server side function
        async: false,
        data: JSON.stringify({ UserName: username }),
        success: function (response) {
            //Success or failure message e.g. Record saved or not saved successfully
            if (response.d !== '0') {

                alert("User approved successfully");
                //Refresh grid
                LoadingPanel.Hide();
                GvUsers.Refresh();
                //DeleteSignUpBuffer();
                DeleteSignUpApprovalBuffer();
            }
            else {
                alert("User not approved");
            }

        },
        error: function (xhr, textStatus, error) {
            //Show error message(if occured)
            alert("Error: " + error);
        }
    });
}

function DeleteSignUpApprovalBuffer() {
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        //Url is the path of our web method (Page name/function name)
        url: "ApproveSignUps.aspx/DeleteSignUpApprovalBuffer",
        //Pass paramenters to the server side function
        async: false,
        data: JSON.stringify({}),
    });
}
function CachedData() {
    var username = sessionStorage.getItem("username");
    var fullnames = sessionStorage.getItem("fullnames");
    var password = sessionStorage.getItem("password");
    var cpassword = sessionStorage.getItem("cpassword");
    var active = sessionStorage.getItem("active");
    var superuser = sessionStorage.getItem("superuser");
    var expiresafter = sessionStorage.getItem("expiresafter");
    var expirydate = sessionStorage.getItem("expirydate");
    var question = sessionStorage.getItem("question");
    var answer = sessionStorage.getItem("answer");
    var telephone = sessionStorage.getItem("telephone");
    var lockafter = sessionStorage.getItem("lockafter");
    var immediatechange = sessionStorage.getItem("immediatechange");
    var biouserid = sessionStorage.getItem("biouserid");
    var costcenter = sessionStorage.getItem("costcenter");
    var narration = sessionStorage.getItem("narration");
    var email = sessionStorage.getItem("email");
    if (!(username == null)) {
        txtUserName.SetText(username);
    }
    if (!(fullnames == null)) {
        txtFullNames.SetText(fullnames);
    }
    if (!(password == null)) {
        txtPassword.SetText(password);
    }
    if (!(cpassword == null)) {
        txtConfirmPassword.SetText(cpassword);
    }
    if (!(email == null)) {
        txtEmail.SetText(email);
    }
    if (!(expiresafter == null)) {
        txtExpiresAfter.SetText(expiresafter);
    }
    if (!(expirydate == null)) {
        dtpExpiryDate.SetDate(new Date(expirydate));
    }
    else {
        dtpExpiryDate.SetDate(new Date("2099-01-01"));
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1; //January is 0!
        var yyyy = today.getFullYear();
        if (dd < 10) {
            dd = '0' + dd;
        }
        if (mm < 10) {
            mm = '0' + mm;
        }
        today = mm + '/' + dd + '/' + yyyy;
        var date1 = new Date(today);
        var date2 = new Date("2099-01-01");
        var timeDiff = Math.abs(date2.getTime() - date1.getTime());
        var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24));
        txtExpiresAfter.SetText(diffDays);

    }
    if (!(narration == null)) {
        txtNarration.SetText(narration);
    }
    if (!(question == null)) {
        txtSecQue.SetText(question);
    }
    if (!(answer == null)) {
        txtAnswer.SetText(answer);
    }
    if (!(telephone == null)) {
        txtTelephone.SetText(telephone);
    }
    if (!(lockafter == null)) {
        txtLockAfter.SetText(lockafter);
    }
    if (!(biouserid == null)) {
        txtBioUserId.SetText(biouserid);
    }
    if (!(active == null)) {
        if (active == 'true') {
            chkActive.SetChecked(true);
        }
        else {
            chkActive.SetChecked(false);
        }
    }
    if (!(superuser == null)) {
        if (superuser == 'true') {
            chkSuperuser.SetChecked(true);
        }
        else {
            chkSuperuser.SetChecked(false);
        }
    }
    if (!(immediatechange == null)) {
        if (immediatechange == 'true') {
            chkImmediateChange.SetChecked(true);
        }
        else {
            chkImmediateChange.SetChecked(false);
        }
    }
    
    if (!(costcenter == null)) {
        glCostCenter.SetValue(costcenter);
    }
    else {
        glCostCenter.SetValue('001');
    }
    //Enable some fields
    txtExpiresAfter.SetEnabled(true);
    dtpExpiryDate.SetEnabled(true);
}
function ClearCachedData() {
    sessionStorage.removeItem('username');
    sessionStorage.removeItem('fullnames');
    sessionStorage.removeItem('password');
    sessionStorage.removeItem('cpassword');
    sessionStorage.removeItem('active');
    sessionStorage.removeItem('email');
    sessionStorage.removeItem('superuser');
    sessionStorage.removeItem('expiresafter');
    sessionStorage.removeItem('expirydate');
    sessionStorage.removeItem('question');
    sessionStorage.removeItem('answer');
    sessionStorage.removeItem('telephone');
    sessionStorage.removeItem('lockafter');
    sessionStorage.removeItem('immediatechange');
    sessionStorage.removeItem('biouserid');
    sessionStorage.removeItem('costcenter');
    sessionStorage.removeItem('narration');
}

