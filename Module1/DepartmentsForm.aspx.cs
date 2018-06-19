using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Module1_DepartmentsForm : System.Web.UI.Page
{
    Department _Department = new Department();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadDepartmentsDetailsToGrid();
        if (this.Page.IsPostBack.Equals(false))
        {
            LoadDepartmentsDetailsToGrid();
        }
    }
    [WebMethod]
    public static bool SaveDepartments(string DeptCode, String DepartMentName, String Description)
    {
        try
        {

            var _Department = new Department();
            _Department.DeptCode = DeptCode;
            _Department.DepartMentName = DepartMentName;
            _Department.Description = Description;
        

            if (_Department.SaveDepartments())
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.Terminus = Environment.MachineName;
            secs.ErrorModule = "Initializing Save Departments Details";
            secs.SaveError();
            return false;
        }
    }
    [WebMethod]
    public static bool DeletedDepartmentsDetails(string DeptCode)
    {
        try
        {
            var _Department = new Department();

            _Department.DeptCode = DeptCode;



            if (_Department.DeleteDepartments())
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.Terminus = Environment.MachineName;
            secs.ErrorModule = "Initializing Deleted Departments Details";
            secs.SaveError();
            return false;
        }
    }


    public void LoadDepartmentsDetailsToGrid()
    {
        try
        {
            DataSet ds = new DataSet();
            var _Department = new Department();
            ds = _Department.SelectAllDepartments();
            GvDepartments.DataSource = ds.Tables["Departments"];
            GvDepartments.DataBind();
        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.Terminus = Environment.MachineName;
            secs.ErrorModule = "Initializing Selecting All Departments";
            secs.SaveError();
        }
    }
    [WebMethod]
    public static void SelectDepartmentsDetails(string DeptCode)
    {
        try
        {
            System.Web.HttpContext.Current.Session["DeptCode"] = DeptCode;


        }
        catch (Exception ex)
        {

            var _Security = new Security();
            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "Initializing selecting Department";
            _Security.SaveError();
            // return null;
        }
    }
    private void DisableField()
    {
        try
        {
            txtDescription.ClientEnabled = false;

            txtDeptCode.ClientEnabled = false;
            txtDepartMentName.ClientEnabled = false;
           
        }

        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = "Disabling fields";
            secs.SaveError();

        }
    }
    protected void cpDepartments_Callback(object sender, CallbackEventArgsBase e)
    {
        try
        {

            DataSet ds = new DataSet();
            var _Department = new Department();
            _Department.DeptCode = Session["DeptCode"].ToString();


            ds = _Department.SelectDepartments();
            DisableField();
           
            txtDescription.Text = ds.Tables["Departments"].Rows[0]["DeptCode"].ToString();

            txtDepartMentName.Text = ds.Tables["Departments"].Rows[0]["DepartMentName"].ToString();

            txtDeptCode.Text = ds.Tables["Departments"].Rows[0]["Description"].ToString();

       



        }
        catch (Exception ex)
        {
            Security _Security = new Security();
            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "performing callback on form Departments";
            _Security.SaveError();
        }
    }
    protected void Grid_FillContextMenuItems(object sender, ASPxGridViewContextMenuEventArgs e)
    {
        if (e.MenuType == GridViewContextMenuType.Rows)
        {
            var item = e.CreateItem("Export", "Export");
            item.BeginGroup = true;
            e.Items.Insert(e.Items.IndexOfCommand(GridViewContextMenuCommand.Refresh), item);
            AddMenuSubItem(item, "WORD", "ExportToWord", @"Images/ExportToWord.png", true);
            AddMenuSubItem(item, "PDF", "ExportToPDF", @"Images/ExportToPdf.png", true);
            AddMenuSubItem(item, "EXCEL", "ExportToXLS", @"Images/ExportToXls.png", true);
            AddMenuSubItem(item, "CSV", "ExportToCSV", @"Images/ExportToXls.png", true);
        }
    }



    private static void AddMenuSubItem(GridViewContextMenuItem parentItem, string text, string name, string imageUrl, bool isPostBack)
    {
        var exportToXlsItem = parentItem.Items.Add(text, name);
        exportToXlsItem.Image.Url = imageUrl;
    }
    protected void Grid_ContextMenuItemClick(object sender, ASPxGridViewContextMenuItemClickEventArgs e)
    {
        switch (e.Item.Name)
        {
            case "ExportToWord":
                ASPxGridViewExporter1.WriteRtfToResponse();
                break;
            case "ExportToPDF":
                ASPxGridViewExporter1.WritePdfToResponse();
                break;
            case "ExportToXLS":
                ASPxGridViewExporter1.WriteXlsToResponse();
                break;
            case "ExportToCSV":
                ASPxGridViewExporter1.WriteCsvToResponse();
                break;

        }
    }
  

}