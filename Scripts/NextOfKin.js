var NextOfKinId;

function GvNextOfKin_RowClick(s, e) {

    GvNextOfKin.GetRowValues(e.visibleIndex, 'NextOfKinId;', GvNextOfKin_GetRowValues);
}

function GvNextOfKin_GetRowValues(values) {

    NextOfKinId = values[0];
    SelectPatientsDetails();
    //  DisableField();
}

function OnSuccess(response) {

    cpNextOfKin.PerformCallback();

}
function SelectPatientsDetails() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "NextOfKinForm.aspx/SelectNextOfKin",
        async: false,
        //Pass paramenters to the server side function
        data: JSON.stringify({ NextOfKinId: NextOfKinId }),
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
function saveNextOfKin() {

    var PatientId = glPatient.GetGridView().GetRowKey(glPatient.GetGridView().GetFocusedRowIndex());
    var NextOfKinId = txtNextOfKinId.GetText();
    var Names = txtNames.GetText();
    var County = txtCounty.GetText();
    var SubCounty = txtSubCounty.GetText();
    var Ward = txtWard.GetText();


    var Village = txtVillage.GetText();
    var CellPhone = txtCellPhone.GetText();
    //  var CertificateAttach=txtCatCode.GetText();
    var Email = txtEmail.GetText();
    var DOB = dtpDOB.GetText();

    // checking validation
    var msg = "";

    if (NextOfKinId === '' || NextOfKinId == null) {
        msg = "Select NextOfKinId to proceed";
        alert(msg);
        return false;
    }

    if (PatientId === '' || PatientId == null) {
        msg = "Select PatientId to proceed";
        alert(msg);
        return false;
    }

    if (Names === '' || Names == null) {
        msg = "Select Names to proceed";
        alert(msg);
        return false;
    }
    if (DOB === '' || DOB == null) {
        msg = "Select DOB to proceed";
        alert(msg);
        return false;
    }
    if (County === '' || County == null) {
        msg = "Select County to proceed";
        alert(msg);
        return false;
    }
    if (SubCounty === '' || SubCounty == null) {
        msg = "Select SubCounty to proceed";
        alert(msg);
        return false;
    }
    if (Ward === '' || Ward == null) {
        msg = "Select Ward to proceed";
        alert(msg);
        return false;
    }
    if (Village === '' || Village == null) {
        msg = "Select Village to proceed";
        alert(msg);
        return false;
    }
    if (CellPhone === '' || CellPhone == null) {
        msg = "Select CellPhone to proceed";
        alert(msg);
        return false;
    }
    if (Email === '' || Email == null) {
        msg = "Select Email to proceed";
        alert(msg);
        return false;
    }


    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: "NextOfKinForm.aspx/SaveNextOfKin",
        //Pass paramenters to the server side function
        async: false,

        data: JSON.stringify({
            PatientId: PatientId, NextOfKinId: NextOfKinId, Names: Names, DOB: DOB,
            County: County, SubCounty: SubCounty, Ward: Ward, Village: Village, CellPhone: CellPhone, Email: Email
        }),
        success: function (response) {
            //Success or failure message e.g. Record saved or not saved successfully
            if (response.d === true) {
                //row = row + 1;
                // if (row === rowcount) {
                alert("Next of Kin Saved Successfully");

                GvNextOfKin.Refresh();
                ClearFields();
                //}
            }
            else {
                alert("Next of Kin could not be saved");
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
function DeleteNextOfKin() {
    var NextOfKinId = txtPatientId.GetText();
    if (confirm('Are you sure you want to delete Next of Kin with NextOfKinId:  ' + NextOfKinId + '?')) {
        //Jquery ajax call to server side method
        $.ajax({
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            //Url is the path of our web method (Page name/function name)

            url: "NextOfKinForm.aspx/DeletednextOfKin",
            //Pass paramenters to the server side function
            async: false,
            //Pass paramenters to the server side function
            data: JSON.stringify({ NextOfKinId: NextOfKinId }),
            success: function (response) {
                //Success or failure message e.g. Record saved or not saved successfully
                if (response.d == true) {

                    alert("Next of Kin deleted successfully");
                    //Refresh grid
                    GvNextOfKin.Refresh();
                    ClearFields();

                }
                else {
                    alert("Next of Kin  not deleted");
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

    dtpDOB.SetEnabled(true);
    txtEmail.SetEnabled(true);
    txtCellPhone.SetEnabled(true);
    txtVillage.SetEnabled(true);

    txtWard.SetEnabled(true);
    txtSubCounty.SetEnabled(true);
    txtCounty.SetEnabled(true);
    txtNames.SetEnabled(true);
    glPatient.SetEnabled(true);
    txtNextOfKinId.SetEnabled(true);

}
function ClearFields() {
    dtpDOB.SetText(" ");
    txtEmail.SetText(" ");
    txtCellPhone.SetText(" ");
    txtVillage.SetText(" ");

    txtWard.SetText(" ");
    txtSubCounty.SetText(" ");
    txtCounty.SetText(" ");
    txtNames.SetText(" ");
    glPatient.SetText(" ");
    txtNextOfKinId.SetText(" ");

}





