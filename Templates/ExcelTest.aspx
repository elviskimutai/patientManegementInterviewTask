<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExcelTest.aspx.cs" Inherits="ExcelTest" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxCallbackPanel ID="cpExcelgeneration" runat="server" Width="200px" ClientInstanceName="cpExcelgeneration" OnCallback="cpExcelgeneration_Callback">

            <PanelCollection>
<dx:PanelContent runat="server">
    <dx:ASPxButton ID="ASPxButton1" runat="server"  Text="Generate Excel" Theme="Metropolis" AutoPostBack="False">
        <ClientSideEvents Click="function(s, e) {
cpExcelgeneration.PerformCallback();	
}" />
    </dx:ASPxButton>
   
                </dx:PanelContent>
</PanelCollection>

        </dx:ASPxCallbackPanel>
    </div>
    </form>
</body>
</html>
