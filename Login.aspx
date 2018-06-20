<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="WebChat_Login"%>
<%@ Register assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<!DOCTYPE html>
<script runat="server">

   
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Palladium|HealthProject </title>
      <link rel="icon" type="image/ico" href="Images/home.png" />
  <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/style.css" rel="stylesheet" />
    <link href="../Content/font-awesome.css" rel="stylesheet" />
    <link href="../Content/icheck-bootstrap.css" rel="stylesheet" />
</head>
<body class="hold-transition login-page">
-
    <form id="form1" runat="server">
                  <dx:ASPxCallbackPanel runat="server" ID="cpFind0" ClientInstanceName="cpFind" OnCallback="cpFind_Callback"  >
                                                     <PanelCollection>
                                                       <dx:PanelContent>
        <div class="login-box">
            <div class="login-logo">
               <%-- <a href="Login.aspx"><b>Simply Travel & Tours</b></a>--%>
            </div>
            <!-- /.login-logo -->
            <div class="login-box-body">
                <p class="login-box-msg">Please Login to Proceed</p>
                <div class="form-group has-feedback">
                    <input type="email" id="txtEmail" class="form-control" placeholder="Email" required="required" runat="server" />
                    <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                </div>
                <div class="form-group has-feedback">
                    <input type="password" id="txtPassword" class="form-control" placeholder="Password" required="required" runat="server" autocomplete="off" />
                    <span class="fa fa-lock form-control-feedback"></span>
                </div>
                <div class="row">
                  
                    <!-- /.col -->
                    <div class="col-xs-4">
                        <dx:ASPxButton ID="btnSignIn" runat="server" Text="Login" CssClass="btn btn-success btn-block btn-flat" >
                                                    <ClientSideEvents click="function(s, e) {
	cpFind.PerformCallback();
}" />
                        </dx:ASPxButton><br />

                    </div>

                      <div class="col-xs-8">
                      
 

                    </div>
                    <!-- /.col -->
                </div>
           
               
            </div>
            <!-- /.login-box-body -->
        </div>
               
                                                           
                                                           
                                                                                  </dx:PanelContent>
                           </PanelCollection>
                           </dx:ASPxCallbackPanel>               
    </form>
    <script src="plugins/jquery-1.9.1.min"></script>
    <script src="plugins/bootstrap.min.js"></script>
    
</body>
</html>
