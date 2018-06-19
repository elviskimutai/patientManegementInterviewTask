using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web;
using System.Web.UI;
using System.Data;

/// <summary>
/// Summary description for Navigator
/// </summary>
public class Navigator
{
    HttpCookie rptCookie = new HttpCookie("rptCookie");
    public string Module { get; set; }
    public DevExpress.Web.ASPxNavBar NavigationBar { get; set; }
    Security _Security = new Security();


   
 

   
   
 
   

    public void LoadHelpDeskTicketsnMenus(ASPxMenu menu)
    {
        try
        {
            _Security.Right = "View";

            MenuItem Home = new MenuItem("Home", "mnuHome", "~/Images/home.png");
         
          

            MenuItem SystemAdministration = new MenuItem("Administration", "mnuSystemAdministration", "~/Images/admin-icon.png");
            MenuItem SignOut = new MenuItem("SignOut", "mnuSignOut", "~/Images/signout.png");
            //Add the menu items here 
            menu.Items.Clear();
            

     
                menu.Items.Add(SystemAdministration);
            
                 menu.Items.Add(SignOut);


        }
        catch (Exception ex)
        {

            Security _Security = new Security();
            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "Validating view Privilige on Ticketing system Top Menus";
            _Security.SaveError();
        }
    }


    public void LoadSecurityAdmin()
    {
        _Security.Right = "View";
        //Add groups 
        NavBarGroup Inquiries = new NavBarGroup("Inquiries Analysis", "Inquiries", "~/Images/edit5.png");
        NavBarGroup Processes = new NavBarGroup("Master Operations", "Processes", "~/Images/process2.png");
        NavBarGroup Workflow = new NavBarGroup("Configuration", "Workflow", "~/Images/process2.png");
        NavBarGroup Reports = new NavBarGroup("System Reports ", "Reports", "~/Images/reports2.png");

        //Add Processes
        NavBarItem AuditTrail = new NavBarItem("Audit Trail", "/SystemAdministration/AuditTrailInquiry.aspx");
        NavBarItem ErrorLogs = new NavBarItem("Error Logs", "/SystemAdministration/ErrorLogsInquiry.aspx");
        NavBarItem UserRolesInquiry = new NavBarItem("User Roles Inquiry", "/SystemAdministration/UserRolesInquiry.aspx");

        Inquiries.Items.Add(ErrorLogs);
     
            Inquiries.Items.Add(AuditTrail);
        

      
            Inquiries.Items.Add(UserRolesInquiry);
        
        NavBarItem Departments = new NavBarItem("Departments", "/Module1/DepartmentsForm.aspx");
        NavBarItem Patients = new NavBarItem("Patients Details", "/Module1/PatientForm.aspx");
        NavBarItem NextOfKin = new NavBarItem("Next of Kin", "/Module1/NextOfKinForm.aspx");
    
        NavBarItem Enroll = new NavBarItem("Patients Enrollment", "/SystemAdministration/Roles.aspx");

       
        
            Processes.Items.Add(Departments);
        
            Processes.Items.Add(Patients);
      
            Processes.Items.Add(NextOfKin);
       
            Processes.Items.Add(Enroll);
       
       
      
       
        //Bind Navigation Bar
        NavigationBar.Groups.Clear();
        NavigationBar.Groups.Add(Inquiries);
        NavigationBar.Groups.Add(Processes);
        NavigationBar.Groups.Add(Workflow);
        NavigationBar.Groups.Add(Reports);
        Processes.Expanded = true;
    }




}