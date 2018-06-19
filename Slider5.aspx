<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Slider5.aspx.cs" Inherits="Slide5" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>

<%@ Register assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<%@ Register assembly="DevExpress.XtraScheduler.v15.1.Core, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraScheduler" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

.dxmLite_PlasticBlue
{
	font: 12px Tahoma, Geneva, sans-serif;
}

    .dxisControl
{
    width: 660px;
    height: 505px;
    outline: 0;
    user-select: none;
	-moz-user-select: -moz-none;
	-khtml-user-select: none;
	-webkit-user-select: none;

    font: 12px Tahoma, Geneva, sans-serif;
}
         .SliderCenter
        {
            display:block;
        }
         html,body{
             border:0px;
             margin:0px;
             padding:0px;            
         }
        .dxisDesignMode > tbody > tr > td {
    height: 100%;
}
.dxisDesignMode .dxis-mainLayout,
.dxisDesignMode .dxis-mainLayout .dxis-imageArea,
.dxisDesignMode .dxis-mainLayout .dxis-buttons
 {
	width: 100%;
	height: 100%;
}
.dxisDesignMode .dxis-grayBackground {
	background-color: #eaedf1;
}
.dxisDesignMode .dxis-grayBorder {
	border: 1px solid #adb0b4;
}
.dxisControl .dxis-imageArea
{
    margin: 0 auto;
    position: relative;
    overflow: hidden;
}
.dxisDesignMode .dxis-spacing,
.dxisDesignMode.dxis-navBarHor .dxis-navBar .dxis-itemSpacing {
    padding: 5px 0 0 5px;
	width: 0px;
	height: 0px;
}
.dxisDesignMode.dxis-navBarHor .dxis-dotsNavBarCell .dxis-navBar {
	width: auto;
}
.dxisDesignMode .dxis-dot {
	width: 15px;
    height: 15px;
	background-position: -1px -28px;
}
.dxisDesignMode .dxis-dot.dxis-dotSelected {
	background-position: -18px -28px;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding: 0px"> 
        <table>
            <tr>
                <td>
   <dxwschs:ASPxScheduler ID="ASPxScheduler1" runat="server" AppointmentDataSourceID="SqlDataSource1" ClientIDMode="AutoID" Start="2018-05-18" Theme="Metropolis">
            <Storage>
                <Appointments AutoRetrieveId="True">
                    <Mappings AllDay="AllDay" AppointmentId="UniqueID" Description="Description" End="EndDate" Label="Label" Location="Location" RecurrenceInfo="RecurrenceInfo" ReminderInfo="ReminderInfo" ResourceId="ResourceID" Start="StartDate" Status="Status" Subject="Subject" TimeZoneId="ResourceIDs" Type="Type" />
                </Appointments>
            </Storage>
            <Views>
<DayView><TimeRulers>
<cc1:TimeRuler></cc1:TimeRuler>
</TimeRulers>
</DayView>

<WorkWeekView><TimeRulers>
<cc1:TimeRuler></cc1:TimeRuler>
</TimeRulers>
</WorkWeekView>

                <WeekView Enabled="false"></WeekView>
                <FullWeekView Enabled="true">
                    <TimeRulers>
<cc1:TimeRuler></cc1:TimeRuler>
</TimeRulers>
                </FullWeekView>
            </Views>

        </dxwschs:ASPxScheduler> 
           
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:conStr %>" DeleteCommand="DELETE FROM [Appointments] WHERE [UniqueID] = @UniqueID" InsertCommand="INSERT INTO [Appointments] ([Type], [StartDate], [EndDate], [AllDay], [Subject], [Location], [Description], [Status], [Label], [ResourceID], [ResourceIDs], [ReminderInfo], [RecurrenceInfo], [CustomField1], [CreatedUser], [CompCode]) VALUES (@Type, @StartDate, @EndDate, @AllDay, @Subject, @Location, @Description, @Status, @Label, @ResourceID, @ResourceIDs, @ReminderInfo, @RecurrenceInfo, @CustomField1, @UserName, @CompCode)" SelectCommand="SELECT * FROM [Appointments] where   [CompCode]=@CompCode and CreatedUser= @UserName" UpdateCommand="UPDATE [Appointments] SET [Type] = @Type, [StartDate] = @StartDate, [EndDate] = @EndDate, [AllDay] = @AllDay, [Subject] = @Subject, [Location] = @Location, [Description] = @Description, [Status] = @Status, [Label] = @Label, [ResourceID] = @ResourceID, [ResourceIDs] = @ResourceIDs, [ReminderInfo] = @ReminderInfo, [RecurrenceInfo] = @RecurrenceInfo, [CustomField1] = @CustomField1 WHERE [UniqueID] = @UniqueID">
                        
                        
                         <SelectParameters>
                        <asp:CookieParameter CookieName="UserName" DefaultValue="Anonymous" Name="UserName" Type="String" />
                         <asp:CookieParameter CookieName="CompCode" DefaultValue="CompCode" Name="CompCode" Type="String" />
                         <asp:CookieParameter CookieName="CostcenterCookie" DefaultValue="Anonymous" Name="CostCenter" Type="String" />
                     
                         
                         </SelectParameters>

                        
                        <DeleteParameters>
                            <asp:Parameter Name="UniqueID" Type="Int32" />
                       
                             <asp:CookieParameter CookieName="UserName" DefaultValue="Anonymous" Name="UserName" Type="String" />
                         <asp:CookieParameter CookieName="CompCode" DefaultValue="CompCode" Name="CompCode" Type="String" />
                         <asp:CookieParameter CookieName="CostcenterCookie" DefaultValue="Anonymous" Name="CostCenter" Type="String" />
                             </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Type" Type="Int32" />
                            <asp:Parameter Name="StartDate" Type="DateTime" />
                            <asp:Parameter Name="EndDate" Type="DateTime" />
                            <asp:Parameter Name="AllDay" Type="Boolean" />
                            <asp:Parameter Name="Subject" Type="String" />
                            <asp:Parameter Name="Location" Type="String" />
                            <asp:Parameter Name="Description" Type="String" />
                            <asp:Parameter Name="Status" Type="Int32" />
                            <asp:Parameter Name="Label" Type="Int32" />
                            <asp:Parameter Name="ResourceID" Type="Int32" />
                            <asp:Parameter Name="ResourceIDs" Type="String" />
                            <asp:Parameter Name="ReminderInfo" Type="String" />
                            <asp:Parameter Name="RecurrenceInfo" Type="String" />
                            <asp:Parameter Name="CustomField1" Type="String" />
                             <asp:CookieParameter CookieName="UserName" DefaultValue="Anonymous" Name="UserName" Type="String" />
                         <asp:CookieParameter CookieName="CompCode" DefaultValue="CompCode" Name="CompCode" Type="String" />
                         <asp:CookieParameter CookieName="CostcenterCookie" DefaultValue="Anonymous" Name="CostCenter" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Type" Type="Int32" />
                            <asp:Parameter Name="StartDate" Type="DateTime" />
                            <asp:Parameter Name="EndDate" Type="DateTime" />
                            <asp:Parameter Name="AllDay" Type="Boolean" />
                            <asp:Parameter Name="Subject" Type="String" />
                            <asp:Parameter Name="Location" Type="String" />
                            <asp:Parameter Name="Description" Type="String" />
                            <asp:Parameter Name="Status" Type="Int32" />
                            <asp:Parameter Name="Label" Type="Int32" />
                            <asp:Parameter Name="ResourceID" Type="Int32" />
                            <asp:Parameter Name="ResourceIDs" Type="String" />
                            <asp:Parameter Name="ReminderInfo" Type="String" />
                            <asp:Parameter Name="RecurrenceInfo" Type="String" />
                            <asp:Parameter Name="CustomField1" Type="String" />
                            <asp:Parameter Name="UniqueID" Type="Int32" />
                              <asp:CookieParameter CookieName="UserName" DefaultValue="Anonymous" Name="UserName" Type="String" />
                         <asp:CookieParameter CookieName="CompCode" DefaultValue="CompCode" Name="CompCode" Type="String" />
                         <asp:CookieParameter CookieName="CostcenterCookie" DefaultValue="Anonymous" Name="CostCenter" Type="String" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
           
                </td>
                <td>
                    <dxwschs:ASPxDateNavigator ID="ASPxDateNavigator1" runat="server" ClientIDMode="AutoID" MasterControlID="ASPxScheduler1">
                        <Properties Rows="4">
                        </Properties>
                    </dxwschs:ASPxDateNavigator>
                </td>
            </tr>
        </table>   
                    
    </div>
    </form>
</body>
</html>