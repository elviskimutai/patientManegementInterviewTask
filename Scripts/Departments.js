var DeptCode;

function GvDepartments_RowClick(s, e) {

    GvDepartments.GetRowValues(e.visibleIndex, 'DeptCode;', GvDepartments_GetRowValues);
}

function GvDepartments_GetRowValues(values) {

    DeptCode = values[0];
    SelectDepartments();
    //  DisableField();
}

function OnSuccess(response) {

    cpDepartments.PerformCallback();

}
function SelectDepartments() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "DepartmentsForm.aspx/SelectDepartmentsDetails",
        async: false,
        //Pass paramenters to the server side function
        data: JSON.stringify({ DeptCode: DeptCode }),
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
function saveDepartments() {

    var DeptCode = txtDeptCode.GetText();
    var DepartMentName = txtDepartMentName.GetText();
    var Description = txtDescription.GetText();
   
    // checking validation
    var msg = "";

    if (DeptCode === '' || DeptCode == null) {
        msg = "Select DeptCode to proceed";
        alert(msg);
        return false;
    }

    if (DepartMentName === '' || DepartMentName == null) {
        msg = "Select DepartMentName to proceed";
        alert(msg);
        return false;
    }
    if (Description === '' || Description == null) {
        msg = "Select Description to proceed";
        alert(msg);
        return false;
    }

   

    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: "DepartmentsForm.aspx/SaveDepartments",
        //Pass paramenters to the server side function
        async: false,

        data: JSON.stringify({
            DeptCode: DeptCode, DepartMentName: DepartMentName, Description: Description
        }),
        success: function (response) {
            //Success or failure message e.g. Record saved or not saved successfully
            if (response.d === true) {
                //row = row + 1;
                // if (row === rowcount) {
                alert("Departments Saved Successfully");

                GvDepartments.Refresh();
                ClearFields();
                //}
            }
            else {
                alert("Departments could not be saved");
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
function DeleteDepartments() {
    var DeptCode = txtDeptCode.GetText();
    if (confirm('Are you sure you want to delete Departments with DeptCode:  ' + DeptCode + '?')) {
        //Jquery ajax call to server side method
        $.ajax({
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            //Url is the path of our web method (Page name/function name)

            url: "DepartmentsForm.aspx/DeletedDepartmentsDetails",
            //Pass paramenters to the server side function
            async: false,
            //Pass paramenters to the server side function
            data: JSON.stringify({ DeptCode: DeptCode }),
            success: function (response) {
                //Success or failure message e.g. Record saved or not saved successfully
                if (response.d == true) {

                    alert("Departments deleted successfully");
                    //Refresh grid
                    GvDepartments.Refresh();
                    ClearFields();

                }
                else {
                    alert("Departments  not deleted");
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

  
    txtDeptCode.SetEnabled(true);
    txtDepartMentName.SetEnabled(true);
    txtDescription.SetEnabled(true);

   
}
function ClearFields() {
    
    txtDeptCode.SetText(" ");
    txtDepartMentName.SetText(" ");
    txtDescription.SetText(" ");

   
}