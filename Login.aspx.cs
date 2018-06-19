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
        ASPxPopupControl1.ShowOnPageLoad = false;
    }


    protected void cpFind_Callback(object sender, CallbackEventArgsBase e)
    {


        try
        {
            var _Security = new Security();
            var _User = new Users();
            _Security.UserName = txtEmail.Value;
            _Security.Password = txtPassword.Value;
            // _Security.Usergroup = HttpContext.Current.Request.Cookies["UserName"].Value;
            // return _Security.ValidatePrivilege();
            if (_Security.ValidateUser())
            {
                 ASPxWebControl.RedirectOnCallback(VirtualPathUtility.ToAbsolute("/HomePage.aspx"));
                //  Response.Redirect("/HomePage.aspx");
                //  Server.Transfer("/SystemAdministration/Login.aspx");

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



    protected void cpPopUp_Callback(object sender, CallbackEventArgsBase e)
    {

        try
        {
        



            
            ASPxPopupControl1.ShowOnPageLoad = true;

           
        }
        catch (Exception ex)
        {

            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "performing callback popup";
            _Security.SaveError();
        }
    }

    protected void cpLogin_Callback(object sender, CallbackEventArgsBase e)
    {


        try
        {
            var _User = new User();
            int ExpiresAfter = 90;
            int LockAfter = 90;

            _User.UserName = txtEmailNew.Value.ToString(); 
            _User.EmpNo = txtEmailNew.Value.ToString();
            _User.FullNames = txtFullNames.Value.ToString();
            _User.Password = SkypensionCryptoEngine.Encrypt(txtPassword1.Value.ToString(), true);
            _User.ConfirmPassword = SkypensionCryptoEngine.Encrypt(txtConfirmPassword.Value.ToString(), true);
            if (_User.Password != _User.ConfirmPassword)
            {
               
                cpLogin.JSProperties["cpResult"] = "Password Does Not Much";
                ASPxPopupControl1.ShowOnPageLoad = true;
                return;
            }
                _User.IsActive = true;
            _User.SuperUser = false;
            _User.ExpiresAfter = ExpiresAfter;
            _User.ExpiryDate = DateTime.Now.AddYears(10);
            _User.Narration = "Guest registration";
            _User.Question = "Guest registration";
            _User.Answer = "Guest registration";

            _User.Email = txtEmailNew.Value.ToString() ;
            _User.Telephone = txttelephone.Value.ToString();
            _User.LockAfter = LockAfter;
            _User.ImmediateChange = false;
            _User.BioUserID ="Guest";
            _User.CCCode = "001";
            //_User.SaveUser();
            if (_User.SaveUser())
            {
                ASPxPopupControl1.ShowOnPageLoad = false;
                cpLogin.JSProperties["cpResult"] = " User Registered Successfully";
                
            }
           
                
                else
                {
                cpLogin.JSProperties["cpResult"] = "Fail to  Register User";

                    return;
                }

            
        }
        catch (Exception ex)
        {

            var _Security = new Security();
            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "Initializing user registration Approval";
            _Security.SaveError();
        }
    }









    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        try
        {
            var _Security = new Security();
            var _User = new Users();
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
