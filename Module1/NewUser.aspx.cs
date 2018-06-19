using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NewUser : System.Web.UI.Page
{
    DataSet ds;
    User _User = new User();
    Security _Security = new Security();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadUsers();
        if (this.Page.IsPostBack.Equals(false))
        {
            LoadUsers();
        }
    }
    [WebMethod]
    public static bool SaveUser(string username, string fullnames, string password, string secque, string answer, string email, string telephone)
    {
        try
        {
            SkypensionCryptoEngine _SkypensionCryptoEngine = new SkypensionCryptoEngine();
            var _User = new User();
            _User.UserName = username;
           
            _User.FullNames = fullnames;
            _User.Password = SkypensionCryptoEngine.Encrypt(password, true);
         
            _User.Question = secque;
            _User.Answer = answer;

            _User.Email = email;
            _User.Telephone = telephone;
           
            if (_User.SaveUser())
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

            var _Security = new Security();
            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "Intializing saving user";
            _Security.SaveError();
            return false;
        }
    }
    private void LoadUsers()
    {
        try
        {
            ds = _User.SelectAllUsers();
            GvUsers.DataSource = ds.Tables["Users"];
            GvUsers.DataBind();
        }
        catch (Exception ex)
        {
            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "Loading users";
            _Security.SaveError();

        }
    }

    [WebMethod]
    public static void SelectUser(string UserName)
    {
        try
        {
            System.Web.HttpContext.Current.Session["UserName"] = UserName;


        }
        catch (Exception ex)
        {

            var _Security = new Security();
            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "Initializing selecting sacco group";
            _Security.SaveError();
            // return null;
        }
    }
    [WebMethod]
    public static bool DeleteUser(string UserName)
    {
        try
        {
            var _User = new User();
            _User.UserName = UserName;

           

            if (_User.DeleteUser())
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

            var _Security = new Security();
            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "Initializing selecting sacco group";
            _Security.SaveError();
            return false;
        }
    }
    protected void cpUsers_Callback(object sender, CallbackEventArgsBase e)
    {
        try
        {
            DataSet ds = new DataSet();
            var _User = new User();
            _User.UserName = Session["UserName"].ToString();
           

            ds = _User.SelectUser();

            txtUserName.Text = ds.Tables["Users"].Rows[0]["UserName"].ToString();
            txtFullNames.Text = ds.Tables["Users"].Rows[0]["FullNames"].ToString();
            txtPassword.Text = ds.Tables["Users"].Rows[0]["Password"].ToString();
            txtSecQue.Text = ds.Tables["Users"].Rows[0]["Question"].ToString();
            txtAnswer.Text = ds.Tables["Users"].Rows[0]["Answer"].ToString();
            txtEmail.Text = ds.Tables["Users"].Rows[0]["Email"].ToString();
            txtTelephone.Text = ds.Tables["Users"].Rows[0]["Telephone"].ToString();
          
            DisableField();



        }
        catch (Exception ex)
        {

            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "performing callback on form CoverItem";
            _Security.SaveError();
        }
    }
    private void DisableField()
    {
        try
        {
            txtUserName.ClientEnabled = false;

            txtFullNames.ClientEnabled = false;
            txtPassword.ClientEnabled = false;
            txtSecQue.ClientEnabled = false;

            txtAnswer.ClientEnabled = false;
            txtTelephone.ClientEnabled = false;
            txtEmail.ClientEnabled = false;
        }

        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = "Disabling fields";
            secs.SaveError();

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