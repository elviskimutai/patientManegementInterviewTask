using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ExcelTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    

    protected void cpExcelgeneration_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        try
        {
            //
            var list = new System.Collections.Generic.List<string>();
            list.Add("FAT:Furniture and Fitting");
            list.Add("LB:Land Bulding");
            list.Add("MVA:Motor Vehicle and Automobile");
            list.Add("OE:Office Equipment");
            list.Add("PM:Plant and Mechanics");
            var flatList = string.Join(",", list.ToArray());
            //            
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            //test color formatting

            //end

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Cells[1, 1] = "AssetNo";
            xlWorkSheet.Cells[1, 2] = "Installationdate";
            xlWorkSheet.Cells[1, 3] = "Cost Price";
            xlWorkSheet.Cells[1, 4] = "Gender";
            xlWorkSheet.Cells[1, 5] = "AssetCategories";
            Excel.Range formatRange;
            //Heading  data validation
            formatRange = xlWorkSheet.get_Range("A2", "A1500");
            formatRange.NumberFormat = "@";
            formatRange.Validation.Add(Excel.XlDVType.xlValidateInputOnly, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, misValue, misValue);
            formatRange.Validation.InputMessage = "Enter text";
            formatRange.Validation.ErrorTitle = "Error";
            formatRange.Validation.ErrorMessage = "Invalid Text";
            formatRange.Validation.ShowInput = true;
            formatRange.Validation.ShowError = true;

            //Date  data validation
            formatRange = xlWorkSheet.get_Range("B2", "B1500");
            formatRange.NumberFormat = "mm/dd/yyyy";
            formatRange.Validation.Add(Excel.XlDVType.xlValidateDate, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "01/01/1900", "01/01/2099");
            formatRange.Validation.InputMessage = "Enter Date";
            formatRange.Validation.ErrorTitle = "Error";
            formatRange.Validation.ErrorMessage = "Invalid Date";
            formatRange.Validation.ShowInput = true;
            formatRange.Validation.ShowError = true;

            //cost price data validation
            formatRange = xlWorkSheet.get_Range("C2", "C1500");
            formatRange.NumberFormat = "#,###,###.00";
            formatRange.Validation.Add(Excel.XlDVType.xlValidateDecimal, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "0.00", "2000000000.00");
            formatRange.Validation.InputMessage = "Enter Cost Price";
            formatRange.Validation.ErrorTitle = "Error";
            formatRange.Validation.ErrorMessage = "Invalid Number";
            formatRange.Validation.ShowInput = true;
            formatRange.Validation.ShowError = true;
            // Character length data validation
            formatRange = xlWorkSheet.get_Range("D2", "D1500");
            formatRange.NumberFormat = "@";
            formatRange.Validation.Add(Excel.XlDVType.xlValidateTextLength, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "1", "1");
            formatRange.Validation.InputMessage = "Enter Gender";
            formatRange.Validation.ErrorTitle = "Error";
            formatRange.Validation.ErrorMessage = "Invalid Gender";
            formatRange.Validation.ShowInput = true;
            formatRange.Validation.ShowError = true;
            //dropdownlist
            formatRange = xlWorkSheet.get_Range("E2", "E1500");
            formatRange.NumberFormat = "@";
            formatRange.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertInformation, Excel.XlFormatConditionOperator.xlBetween, flatList, Type.Missing);
            formatRange.Validation.InputMessage = "Select Asset to proceed";
            formatRange.Validation.IgnoreBlank = true;
            formatRange.Validation.InCellDropdown = true;
            //formatRange.Validation.ErrorTitle = "Error";
            //formatRange.Validation.ErrorMessage = "Invalid Asset";
            //formatRange.Validation.ShowInput = true;
            //formatRange.Validation.ShowError = true;
            //string filename = "C:\\FAinformations.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue";
            //if (File.Exists(filename))
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('File Name Alread Exist...');", false);
            //    //return false;
            //}
            xlWorkBook.SaveAs("C:\\FAinformations7.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            //releaseObject(xlApp);
            //releaseObject(xlWorkBook);
            //releaseObject(xlWorkSheet);

        }
        catch (Exception)
        {
            throw;
            //Security sec = new Security();
            //sec.ErrorDesscription = ex.Message;
            //sec.ErrorModule = "Creating Excel sheet for contribution imports ";
            //sec.SaveError();
        }
    }
}