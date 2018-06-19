using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using DevExpress.Web;
using DevExpress.Utils.Menu;

public partial class WebForm2 : System.Web.UI.Page
{
    Security _Security = new Security();
    
    DXMenuItem itemEdit = new DXMenuItem("Edit", ItemEdit_Click);
    DXMenuItem itemDelete = new DXMenuItem("Delete", ItemDelete_Click);
    DXMenuItem[] menuItems;
    public static DXMenuItemPriority ItemEdit_Click { get; private set; }
    public static DXMenuItemPriority ItemDelete_Click { get; private set; }

   
    protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            menuItems = new DXMenuItem[] { itemEdit, itemDelete };           
            ASPxLabel lblCurrentPage = (ASPxLabel)ASPxMenu4.Items[0].FindControl("lblCurrentPage");
                ASPxLabel lblStatus = (ASPxLabel)ASPxMenu4.Items[1].FindControl("lblStatus");
                lblCurrentPage.Text = "Customer Master";
            lblStatus.Text = "Customer Successfully saved";
        }
            catch (Exception ex)
            {        
            
                _Security.ErrorDesscription = ex.Message;
                _Security.ErrorModule = "Initializing User Role validation";
                _Security.SaveError();           

            }
    }
    
   [WebMethod]
    public static bool ValidateRight(string Right,string SecurityModule)
    {
        try
        {
            var _Security = new Security();
            _Security.SecurityModule =  SecurityModule;
            _Security.Right = Right;
            //_Security.Usergroup =  HttpContext.Current.Request.Cookies["UserName"].Value;
            return _Security.ValidatePrivilege();
        }
        catch (Exception ex)
        {
            Security MInsureSecurity = new Security();
            MInsureSecurity.ErrorDesscription = ex.Message;
            MInsureSecurity.ErrorModule = "Validating Privilige on WebForm2";
            MInsureSecurity.SaveError();
            return false;
        }
    }
    [WebMethod]
    public static bool SaveBookDetails(string BookName, string Author, Int32 BookTypeId, decimal Price)
    {
        try
        {
            var _Book = new Book();
            _Book.BookName = BookName;
            _Book.Author = Author;
            _Book.BookTypeId = BookTypeId;
            _Book.Price = Price;
            if (_Book.addBookDetails())
            {             
                return true;
            }
            else
            {
                return false;
            }

        }
        catch (Exception)
        {

            throw;
        }
    }

}
