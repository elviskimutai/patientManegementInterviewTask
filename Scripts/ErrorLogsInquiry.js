function FindErrorLogsInquiry() {
    var Fromdate = dtpFromDate.GetDate();
    var ToDate = dtpToDate.GetDate();
    var Fromdate1 = dtpFromDate.GetText();
    var ToDate1 = dtpToDate.GetText();
    var msg = "";
    if (Fromdate1 === '') {
        msg = "Select From Date to proceed";
        alert(msg);
        return false;
    }
    if (ToDate1 === '') {
        msg = "Select To Date to proceed";
        alert(msg);
        return false;
    }
    if (Fromdate > ToDate) {
        alert("The From  Date is greater than ToDate ");
        return false;
    }
    cpErrorLogsInquiry.PerformCallback();
}
//
function OnContextMenuItemClick(sender, args) {
    ValidateRight2("Export", "Error Logs Inquiry");
    if (validation == true) {
        if (args.item.name == "ExportToPDF" || args.item.name == "ExportToXLS" || args.item.name == "ExportToCSV" || args.item.name == "ExportToWORD") {

            args.processOnServer = true;
            args.usePostBack = true;

        }


    }

}
