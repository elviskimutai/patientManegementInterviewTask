using DevExpress.Web;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using DevExpress.XtraCharts.Native;
using System.Web.Services;

public partial class WebChat_Login : System.Web.UI.Page
//public partial class Login :Page
{
    Security _Security = new Security();
    //Class Object

    protected void Page_Load(object sender, EventArgs e)
        {
       
    }


    protected void cpFind_Callback(object sender, CallbackEventArgsBase e)
    {


        try
        {
            var _Security = new Security();
            var _User = new User();
            _Security.UserName = txtEmail.Value;
            _Security.Password = txtPassword.Value;
           
            if (_Security.ValidateUser())
            {
                 ASPxWebControl.RedirectOnCallback(VirtualPathUtility.ToAbsolute("/HomePage.aspx"));
               
            }
            {
                txtEmail.Value = "Invalid Email or Password!!";
            }

        }
        catch (Exception ex)
        {
            Security MInsureSecurity = new Security();
            MInsureSecurity.ErrorDesscription = ex.Message;
            MInsureSecurity.ErrorModule = "Validating Privilige on Roles";
            MInsureSecurity.SaveError();

        }
    }



  


    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        try
        {
            var _Security = new Security();
            var _User = new User();
            _Security.UserName = txtEmail.Value;
            _Security.Password = txtPassword.Value;
            // _Security.Usergroup = HttpContext.Current.Request.Cookies["UserName"].Value;
            // return _Security.ValidatePrivilege();
            if (_Security.ValidateUser())
            {
                Response.Redirect("/HomePage.aspx");
           
            }
            {
                txtEmail.Value = "Invalid Email or Password!!";
            }
           
        }
        catch (Exception ex)
        {
            Security MInsureSecurity = new Security();
            MInsureSecurity.ErrorDesscription = ex.Message;
            MInsureSecurity.ErrorModule = "Validating Privilige on Roles";
            MInsureSecurity.SaveError();
          
        }
    }


    }
