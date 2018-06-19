using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SystemAdministration_SmtpServer : System.Web.UI.Page
{
    SMTPServer _SMTPServer = new SMTPServer();
    DataSet ds = new DataSet();
    Security _Security = new Security();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!(HttpContext.Current.Request.Cookies["UserName"].Value.ToString().Equals(string.Empty) || HttpContext.Current.Request.Cookies["UserName"].Value.Equals(null)))
            {
                _Security.Right = "View";
                _Security.SecurityModule = "SmtpServers";
                if (_Security.ValidatePrivilege())
                {
                    LoadSmtpServer();

                }
                else
                {
                    Server.Transfer("/SystemAdministration/Login.aspx");

                }

            }
            else
            {
                Server.Transfer("/SystemAdministration/Login.aspx");
            }
         
        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = " initializing page components";
            secs.SaveError();

        }

    }
    public void LoadSmtpServer()
    {
        try
        {
            ds = _SMTPServer.SelectAllSMTPServer();
            GVSmtpServer.DataSource = ds.Tables["SMTPServer"];
            GVSmtpServer.DataBind();

        }
        catch (Exception ex)
        {

            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = " initializing load gridview";
            secs.SaveError();

        }
    }
    [WebMethod]
    public static bool SaveSmtpServer( string ServerName ,string Sender,string Port, string UserName,string Password)
    {
        try
        {
            var _SMTPServer = new SMTPServer();
            _SMTPServer.ServerName = ServerName;
            _SMTPServer.Sender = Sender;
            _SMTPServer.Port = Port;
            _SMTPServer.UserName = UserName;
            _SMTPServer.Password = SkypensionCryptoEngine.Encrypt(Password, true);
            if (_SMTPServer.SaveSMTPServer())
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
            secs.ErrorModule = " initializing save saveSmtserver";
            secs.SaveError();
            return false;
        }
    }
    [WebMethod]
    public static bool DeleteSmtpServer(string ServerName)
    {
        try
        {
            var _SMTPServer = new SMTPServer();
            _SMTPServer.ServerName = ServerName;
            if(_SMTPServer.DeleteSMTPServer())
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
            secs.ErrorModule = " initializing delete saveSmtserver";
            secs.SaveError();
            return false;

        }
    }
    [WebMethod]   
    public static string SelectSmtpServer(string ServerName)
    {
        try
        {
            DataSet ds1 = new DataSet();
            var _SMTPServer = new SMTPServer();
            _SMTPServer.ServerName = ServerName;
            ds1 = _SMTPServer.SelectSMTPServer();
            return ds1.GetXml();

        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = " initializing select saveSmtserver";
            secs.SaveError();
            return null;
        }
    }
    protected void Grid_FillContextMenuItems(object sender, ASPxGridViewContextMenuEventArgs e)
    {
        try
        {
            if (e.MenuType == GridViewContextMenuType.Rows)
            {
                var item = e.CreateItem("Export", "Export");
                item.BeginGroup = true;
                e.Items.Insert(e.Items.IndexOfCommand(GridViewContextMenuCommand.Refresh), item);
                AddMenuSubItem(item, "Csv", "ExportToCSV", @"Images/ExportToCsv.png", true);
                AddMenuSubItem(item, "Excel", "ExportToXLS", @"Images/ExportToXls.png", true);
                AddMenuSubItem(item, "PDF", "ExportToPDF", @"Images/ExportToPdf.png", true);
                AddMenuSubItem(item, "WORD", "ExportToWORD", @"Images/ExportToWord.png", true);

            }
        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = "initializing fill context menu";
            secs.SaveError();

        }
    }
    private static void AddMenuSubItem(GridViewContextMenuItem parentItem, string text, string name, string imageUrl, bool isPostBack)
    {
        try
        {
            var exportToXlsItem = parentItem.Items.Add(text, name);
            exportToXlsItem.Image.Url = imageUrl;
        }
        catch (Exception ex)
        {

            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = "initializin adding submenu items";
            secs.SaveError();
        }
    }
    protected void Grid_ContextMenuItemClick(object sender, ASPxGridViewContextMenuItemClickEventArgs e)
    {
        try
        {
            switch (e.Item.Name)
            {
                case "ExportToCSV":
                    ASPxGridViewExporter1.WriteCsvToResponse();
                    break;
                case "ExportToXLS":
                    ASPxGridViewExporter1.WriteXlsToResponse();
                    break;
                case "ExportToPDF":

                    ASPxGridViewExporter1.WritePdfToResponse();
                    break;
                case "ExportToWORD":
                    ASPxGridViewExporter1.WriteRtfToResponse();
                    break;

            }
        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = "initializing method for exporting userRoles";
            secs.SaveError();

        }
    }
}