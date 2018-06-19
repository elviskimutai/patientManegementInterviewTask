using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.MasterPage
{
    Navigator _Navigator = new Navigator();
    Security _Security = new Security();
    HttpCookie ModuleCookie = new HttpCookie("ModuleCookie");
    string CoreModule;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //UserName.Value = "Admin";
            //Response.Cookies.Add(UserName);

            ModuleCookie.Value = "Main";
            Response.Cookies.Add(ModuleCookie);
            if (this.Page.IsPostBack.Equals(false))
            {
                if (!Request.Browser.IsMobileDevice)
                {


                    this.ASPxPanel1.SettingsAdaptivity.CollapseAtWindowInnerWidth = 580;
                    this.ASPxPanel3.SettingsAdaptivity.CollapseAtWindowInnerWidth = 580;
                    //  this.lblCompany.Text = HttpContext.Current.Request.Cookies["CompName"].Value.ToString();
                    // this.lblUserName.Text = HttpContext.Current.Request.Cookies["NameCookie"].Value.ToString();
                }


                this.LoadCoreModule();



            }


        }
        catch (Exception ex)
        {

            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "Loading sales and distribution menus on SD.master";
            _Security.SaveError();
        }

    }


    protected void ASPxMenu3_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
    {
        try
        {
            this.LoadModuleMenus(e.Item.Name);
        }
        catch (Exception)
        {

            throw;
        }
    }
    public void LoadCoreModule()
    {
        try
        {
            _Navigator.NavigationBar = this.ASPxNavBar2;
            CoreModule = "D"; //_Security.GetCoreModule();
            switch (CoreModule)
            {
                case "D":
                default:
                    _Navigator.LoadHelpDeskTicketsnMenus(this.ASPxMenu3);
                    _Navigator.LoadSecurityAdmin();
                    //_Navigator.LoadGeneralAccounting();
                    break;

            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }



    public void LoadModuleMenus(string Module)
    {
        try
        {
            _Navigator.NavigationBar = this.ASPxNavBar2;

            switch (Module)
            {
                case "mnuHome":
                    frame1.Attributes.Add("src", "Slider5.aspx");
                    break;
                case "mnuSystemAdministration":
                    _Navigator.LoadSecurityAdmin();
                    break;

                case "mnuSignOut":
                    Response.Cookies["UserName"].Value = string.Empty;

                    Response.Redirect("/Login.aspx");
                    break;
                default:
                    break;
            }

        }
        catch (Exception ex)
        {
            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "Loading sales and distribution menus on SD.master";
            _Security.SaveError();
        }
    }








    protected void cpPopUp_Callback(object sender, CallbackEventArgsBase e)
    {

        try
        {


            System.Threading.Thread.Sleep(100);


        }
        catch (Exception ex)
        {


        }
    }
    protected void cpModules_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {

    }
}
