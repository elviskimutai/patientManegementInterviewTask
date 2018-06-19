var PatientId;


function GvPatientEnrollMent_RowClick(s, e) {
    GvPatientEnrollMent.GetRowValues(e.visibleIndex, 'PatientId;', GvPatientEnrollMent_GetRowValues);

}
function GvPatientEnrollMent_GetRowValues(values) {
    PatientId = values[0];

    GetGvPatientEnrollMent();


}

function GetGvPatientEnrollMent() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "PatientsEnrollMents.aspx/SelectPatientID",
        async: false,
        data: JSON.stringify({ PatientId: PatientId }),
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            alert("Error: " + response.d);
        },
        error: function (response) {
            var r = jQuery.parseJSON(response.responseText);
            alert("Message: " + r.Message);
            alert("Stackstrace:" + r.StackTrace);
            alert("ExceptionType:" + r.ExceptionType);
        }
    });
}
function OnSuccess(response) {

    cpPatientEnrollMent.PerformCallback();
}


function SavePatientsEnrollment() {

    var PatientId = glPatientId.GetGridView().GetRowKey(glPatientId.GetGridView().GetFocusedRowIndex());
    var EnrollmentNo = txtEnrollmentNo.GetText();
    var EnrollmentDate = dtpEnrollmentDate.GetText();
   
    var msg = "";


    if (PatientId === '' || PatientId === null) {
        msg = "Enter PatientId To Proceed";
        alert(msg);
        return false;
    }
    if (EnrollmentNo === '' || EnrollmentNo === null) {
        msg = "Enter EnrollmentNo To Proceed";
        alert(msg);
        return false;
    }
    if (EnrollmentDate === '' || EnrollmentDate === null) {
        msg = "Enter EnrollmentDate  To Proceed";
        alert(msg);
        return false;
    }
  
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: "PatientsEnrollMents.aspx/SavePatientsEnrolment",
        //Pass paramenters to the server side function
        async: false,

        data: JSON.stringify({ PatientId: PatientId, EnrollmentNo: EnrollmentNo, EnrollmentDate: EnrollmentDate}),

        success: function (response) {
            //Success or failure message e.g. Record saved or not saved successfully
            if (response.d === true) {
                //row = row + 1;
                // if (row === rowcount) {
                alert("PatientsEnrollMent saved successfully");

                GvPatientEnrollMent.Refresh();
                // DefaultFields();
                ClearFields();
                //}
            }
            else {
                alert(" PatientsEnrollMent could not be saved");


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

function DeletePatientsEnrollment() {

    var PatientId = glPatientId.GetGridView().GetRowKey(glPatientId.GetGridView().GetFocusedRowIndex());


    var msg = "";
    if (PatientId === "" || PatientId === null) {
        msg = "Select PatientId to proceed";
        alert(msg);
        return false;

    }


    if (confirm('Are you sure you want to delete PatientId   ' + PatientId + '?')) {
        //Jquery ajax call to server side method
        $.ajax({
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            //Url is the path of our web method (Page name/function name)
            url: "PatientsEnrollMents.aspx/DeletePatientsEnrollments",
            //Pass paramenters to the server side function
            async: false,
            //Pass paramenters to the server side function
            data: JSON.stringify({ PatientId: PatientId }),
            success: function (response) {
                //Success or failure message e.g. Record saved or not saved successfully
                if (response.d === true) {

                    alert("PatientEnrollment deleted successfully");
                    //Refresh grid
                    EnableField()
                    GvPatientEnrollMent.Refresh();
                    ClearFields();
                    // ClearFields.Refresh();
                    //EnableField();

                    // GvInvestmentPrices.Refresh();

                }
                else {
                    alert(" PatientEnrollment not deleted");
                }

            },
            error: function (xhr, textStatus, error) {
                //Show error message(if occured)
                alert("Error: " + error);
            }
        });
    }
}

function EnableField() {


    glPatientId.SetEnabled(true);
    txtEnrollmentNo.SetEnabled(true);
    dtpEnrollmentDate.SetEnabled(true);

}
function ClearFields() {
    glPatientId.SetValue('');
    txtEnrollmentNo.SetText('');
    dtpEnrollmentDate.SetText('DateTime.Now;');
 

}


//function DefaultFields() {
//    glCostCenter.SetValue('');
//    txtRefNo.SetText('0');
//    txtBookNo.SetText('0');
//    glStaffNo.SetValue('EMP-0001');
//    txtFromSerialNo.SetText('0');
//    txtToSerialNo.SetText('0');
//    glIssuedBy.SetValue('');
//}

function OnContextMenuItemClick(sender, args) {
    ValidateRight2("Export", "PatientsEnrollMents");
    if (validation === true) {
        if (args.item.name == "ExportToPDF" || args.item.name == "ExportToXLS" || args.item.name == "ExportToCSV" || args.item.name == "ExportToWord") {
            args.processOnServer = true;
            args.usePostBack = true;
        }
    }
}
