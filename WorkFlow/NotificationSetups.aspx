<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NotificationSetups.aspx.cs" Inherits="SystemAdministration_NotificationSetups" %>

<%@ Register assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Notification setup</title>
      
     
    <style type="text/css">


        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            padding-left: 15px;
        }

                        .nav
                        {
                            width:100%;
                            padding-left:15px;
                        }
                        html,body{
                            margin:0px;
                            border:0px;
                            padding:0px;
                        }
 
                        .dxflFormLayout {
    display: table;
    font: 12px Tahoma, Geneva, sans-serif;
}

.dxflGroup { padding: 6px 5px; width: 100%;}
.dxflGroupCell { padding: 0 8px; }

.dxflItem { padding: 2px 0; width: 100%; }


.dxflItemSys
{
    text-align: left;
}

.dxflTextEditItemSys .dxflVATSys.dxflCaptionCell { padding-top: 3px; }

.dxflCLLSys .dxflCaptionCell {
    padding-left: 0px;
    padding-right: 6px;
}
.dxflHALSys { text-align: left; }
.dxflCaptionCellSys { /* Bootstrap correction */
    -webkit-box-sizing: content-box;
    -moz-box-sizing: content-box;
    box-sizing: content-box;
}
.dxflCaptionCell {
    white-space: nowrap;
    line-height: 16px;
    height: 100%;
}
.dxflCaptionCell {
    width: 1%;
}

.dxflVATSys { vertical-align: top; }

    </style>
</head>
<body>
    
    <form id="form1" runat="server">
    <div>
     <dx:ASPxCallbackPanel ID="cpReminder" runat="server" ClientInstanceName="cpReminder" OnCallback="cpReminder_Callback" >

                        <PanelCollection>
<dx:PanelContent runat="server">
        <table class="auto-style1">
            <tr>
                <td>        
    <dx:ASPxMenu runat="server" EnableAdaptivity="True" CssClass="nav" ID="ASPxMenu4" EnableTheming="True" Font-Bold="True" ForeColor="Red" Theme="Metropolis">
        <Items>
            <dx:MenuItem Text="Get Funding" Name="Item1">
                <ItemStyle/>
                <Template>
                    <dx:ASPxLabel ID="lblCurrentPage" runat="server" Text="Real Pro Solutions" ForeColor="Blue">
                    </dx:ASPxLabel>
                </Template>
            </dx:MenuItem>
            <dx:MenuItem Text="Real Pro Solutions" Name="Item3">
                <ItemStyle/>
                <Template>
                    <dx:ASPxLabel ID="lblStatus" runat="server" Text="          ">
                    </dx:ASPxLabel>
                </Template>
            </dx:MenuItem>
        </Items>
<ItemStyle>
<Border BorderStyle="None"></Border>

<BorderLeft BorderStyle="None"></BorderLeft>

<BorderTop BorderStyle="None"></BorderTop>

<BorderRight BorderStyle="None"></BorderRight>

<BorderBottom BorderStyle="None"></BorderBottom>
</ItemStyle>
</dx:ASPxMenu>

                    <%--<asp:Label ID="Label1" runat="server" Text=""></asp:Label>--%>

                </td>
            </tr>
            <tr>
                <td>        
        <dx:ASPxPanel ID="ASPxPanel1" runat="server" Collapsible="True" Theme="Metropolis" ClientInstanceName="topPanel" CssClass="topPanel" EnableTheming="True">
           
            <SettingsAdaptivity CollapseAtWindowInnerWidth="500" />
            <SettingsCollapsing>
                <ExpandButton GlyphType="Strips" />
            </SettingsCollapsing>
            <ExpandedPanelTemplate>
                <dx:ASPxMenu ID="ASPxMenu3" runat="server" CssClass="nav" EnableAdaptivity="True" Orientation="Vertical">
           <ClientSideEvents ItemClick="function(s, e)
                             {
	                            switch(e.item.name)
                            {
	                            case &quot;mnuSave&quot;:		
		                            ValidateRight2(&quot;Add&quot;,&quot;Notification Setup&quot;);		
		                            if(validation==true)
                            {
                            SaveNotificationSetups();
                            }

		                            break;
	                            case &quot;mnuEdit&quot;:
		                            ValidateRight2(&quot;Edit&quot;,&quot;Notification Setup&quot;);
                                                       if(validation==true)
                            {
                            EnableField();
                            }

	                            break;
	                            case &quot;mnuDelete&quot;:
		                            ValidateRight2(&quot;Delete&quot;,&quot;Notification Setup&quot;);
                                                           if(validation==true)
                            {
                            DeleteNotificationSetups();
                            }

	                            break;
	                            case &quot;mnuClose&quot;:
		                            if(confirm(&quot;Are you sure you want to close?&quot;)){
                                                           window.history.back();
                                                        }
	                            break;
	                            case &quot;mnuLinks&quot;:
		                            ValidateRight2(&quot;Add&quot;,&quot;Notification Setup&quot;);
	                            break;
                            case &quot;mnuHelp&quot;:
		                            window.open(&quot;/WebHelp/  NotificationSetups/index.htm&quot;);
	                            break;

	                            default:
	                            break;
                            }
	
                            }" />
        <Items>
            <dx:MenuItem Text="Save" Name="mnuSave">
                <Image Url="~/Images/database.png">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Text="Edit" Name="mnuEdit">
                <Image Url="~/Images/edit5.png">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Text="Delete" Name="mnuDelete">
                <Image Url="~/Images/delete.png">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Text="Close" Name="Close">
                <Image Url="~/Images/close.png">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Text="Links" Name="mnuLinks">
                <Image Url="~/Images/links.png">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Text="Help" Name="mnuHelp">
                <Image Url="~/Images/help.png">
                </Image>
            </dx:MenuItem>
        </Items>
                    <ItemStyle>
                    <Border BorderStyle="None" />
                    <BorderLeft BorderStyle="None" />
                    <BorderTop BorderStyle="None" />
                    <BorderRight BorderStyle="None" />
                    <BorderBottom BorderStyle="None" />
                    </ItemStyle>
                </dx:ASPxMenu>
            </ExpandedPanelTemplate>
           
            <ClientSideEvents Init="function(s, e) {
	var collapseAtWindowInnerWidth = 500;
function OnInit(s, e) {
    ASPxClientControl.GetControlCollection().BrowserWindowResized.AddHandler(function (ge, ea) {
        if(window.document.documentElement.clientWidth &lt;= collapseAtWindowInnerWidth) {
      	 s.Collapse();
        } else {
                 s.Expand();  
        }
    });
}
}
" />
           
            <PanelCollection>
<dx:PanelContent runat="server">
    <dx:ASPxMenu ID="ASPxMenu6" runat="server" EnableAdaptivity="True" Theme="Metropolis" EnableTheming="True" CssClass="nav">
         <ClientSideEvents ItemClick="function(s, e)
                             {
	                            switch(e.item.name)
                            {
	                            case &quot;mnuSave&quot;:		
		                            ValidateRight2(&quot;Add&quot;,&quot;Notification Setup&quot;);		
		                            if(validation==true)
                            {
                            SaveNotificationSetups();
                            }

		                            break;
	                            case &quot;mnuEdit&quot;:
		                            ValidateRight2(&quot;Edit&quot;,&quot;Notification Setup&quot;);
                                                       if(validation==true)
                            {
                            EnableField();
                            }

	                            break;
	                            case &quot;mnuDelete&quot;:
		                            ValidateRight2(&quot;Delete&quot;,&quot;Notification Setup&quot;);
                                                           if(validation==true)
                            {
                            DeleteNotificationSetups();
                            }

	                            break;
	                            case &quot;mnuClose&quot;:
		                            if(confirm(&quot;Are you sure you want to close?&quot;)){
                                                           window.history.back();
                                                        }
	                            break;
	                            case &quot;mnuLinks&quot;:
		                            ValidateRight2(&quot;Add&quot;,&quot;Notification Setup&quot;);
	                            break;
                            case &quot;mnuHelp&quot;:
		                            window.open(&quot;/WebHelp/  NotificationSetups/index.htm&quot;);
	                            break;

	                            default:
	                            break;
                            }
	
                            }" />
        <Items>
            <dx:MenuItem Text="Save" Name="mnuSave">
                <Image Url="~/Images/database.png">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Text="Edit" Name="mnuEdit">
                <Image Url="~/Images/edit5.png">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Text="Delete" Name="mnuDelete">
                <Image Url="~/Images/delete.png">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Text="Close" Name="Close">
                <Image Url="~/Images/close.png">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Text="Links" Name="mnuLinks">
                <Image Url="~/Images/links.png">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Text="Help" Name="mnuHelp">
                <Image Url="~/Images/help.png">
                </Image>
            </dx:MenuItem>
        </Items>
        <ItemStyle>
        <Border BorderStyle="None" />
        <BorderLeft BorderStyle="None" />
        <BorderTop BorderStyle="None" />
        <BorderRight BorderStyle="None" />
        <BorderBottom BorderStyle="None" />
        </ItemStyle>
    </dx:ASPxMenu>
                <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="GVNotificationSetups">
    </dx:ASPxGridViewExporter>
                </dx:PanelContent>
</PanelCollection>
            <BackgroundImage HorizontalPosition="right" Repeat="NoRepeat" VerticalPosition="center" />
            <Border BorderStyle="None" />
        </dx:ASPxPanel>
                </td>
            </tr>
            <tr>
                <td>    
                    <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="0" EnableTabScrolling="True" EnableTheming="True" Theme="Metropolis" Width="100%">
                        <TabPages>
                            <dx:TabPage Text="Notification setup">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:ASPxFormLayout ID="ASPxFormLayout4" runat="server" ColCount="2">
                                            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="580" />
                                            <Items>
                                                <dx:LayoutItem Caption=" CostCenter" RequiredMarkDisplayMode="Required" Name="CostCenter">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxGridLookup ID="glCostCenter" runat="server" ClientInstanceName="glCostCenter" KeyFieldName="Costcenter"  Theme="Metropolis" Width="170px">
                                                                <GridViewProperties>
                                                                    <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                                                    <Settings ShowFilterRow="True" />
                                                                </GridViewProperties>
                                                              
                                                                <ValidationSettings>
                                                                    <RequiredField IsRequired="True" />
                                                                </ValidationSettings>
                                                            </dx:ASPxGridLookup>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                    <CaptionCellStyle>
                                                        <Paddings PaddingLeft="0px" />
                                                    </CaptionCellStyle>
                                                    <NestedControlCellStyle>
                                                        <Paddings PaddingLeft="0px" />
                                                    </NestedControlCellStyle>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="DistributionList " RequiredMarkDisplayMode="Required" Name="DistributionList ">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxGridLookup ID="glDistributionList" runat="server" ClientInstanceName="glDistributionList" KeyFieldName="RoleName" Theme="Metropolis"  Width="170px">
                                                                <GridViewProperties>
                                                                    <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                                                    <Settings ShowFilterRow="True" />
                                                                </GridViewProperties>
                                                                
                                                                <ValidationSettings>
                                                                    <RequiredField IsRequired="True" />
                                                                </ValidationSettings>
                                                            </dx:ASPxGridLookup>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                    <CaptionCellStyle>
                                                        <Paddings PaddingLeft="0px" />
                                                    </CaptionCellStyle>
                                                    <NestedControlCellStyle>
                                                        <Paddings PaddingLeft="0px" />
                                                    </NestedControlCellStyle>
                                                </dx:LayoutItem>
                                                 <dx:LayoutItem Caption="Module " RequiredMarkDisplayMode="Required" Name="DistributionList ">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxGridLookup ID="glModule" runat="server" ClientInstanceName="glModule" KeyFieldName="Module" Theme="Metropolis"  Width="170px">
                                                                <GridViewProperties>
                                                                    <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                                                    <Settings ShowFilterRow="True" />
                                                                </GridViewProperties>
                                                                
                                                                <ValidationSettings>
                                                                    <RequiredField IsRequired="True" />
                                                                </ValidationSettings>
                                                            </dx:ASPxGridLookup>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                    <CaptionCellStyle>
                                                        <Paddings PaddingLeft="0px" />
                                                    </CaptionCellStyle>
                                                    <NestedControlCellStyle>
                                                        <Paddings PaddingLeft="0px" />
                                                    </NestedControlCellStyle>
                                                </dx:LayoutItem>
                                               
                                                <dx:LayoutItem Caption="Add" RequiredMarkDisplayMode="Optional" Name="ASPXCBView">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxCheckBox ID="cbAdd" runat="server" CheckState="Unchecked" ClientInstanceName="cbAdd">
                                                          </dx:ASPxCheckBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                    <CaptionCellStyle>
                                                        <Paddings PaddingLeft="0px" />
                                                    </CaptionCellStyle>
                                                    <NestedControlCellStyle>
                                                        <Paddings PaddingLeft="0px" />
                                                    </NestedControlCellStyle>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="Delete" Name="ASPXCBDelete">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxCheckBox ID="CBDelete" runat="server" CheckState="Unchecked" ClientInstanceName="CBDelete">
                                                               
                                                            </dx:ASPxCheckBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="SendSms" Name="SendSms">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxCheckBox ID="CBSendSms" runat="server" CheckState="Unchecked" ClientInstanceName="CBSendSms">
                                                               
                                                            </dx:ASPxCheckBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="SendEmail" Name="ASPxCBImport">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxCheckBox ID="CBSendEmail" runat="server" CheckState="Unchecked" ClientInstanceName="CBSendEmail">
                                                               
                                                            </dx:ASPxCheckBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                            </Items>
                                            <SettingsItemCaptions Location="Left" />
                                        </dx:ASPxFormLayout>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                        </TabPages>

                    </dx:ASPxPageControl>
    
                </td>
            </tr>
        </table>
             </dx:PanelContent>
                                </PanelCollection>

                             </dx:ASPxCallbackPanel>
    </div>

       <dx:ASPxGridView runat="server" Width="100%" ID="GVNotificationSetups" ClientInstanceName="GVNotificationSetups" EnableRowsCache="False" EnableTheming="True" Theme="Metropolis" KeyFieldName="CompCode;CostCenter;DistributionList;Module" OnFillContextMenuItems="Grid_FillContextMenuItems" OnContextMenuItemClick="Grid_ContextMenuItemClick">
            <Settings VerticalScrollBarMode="Visible" ShowFilterBar="Visible" ShowFilterRow="True" ShowFilterRowMenu="True" ShowGroupPanel="True" />
                       <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ColumnResizeMode="Control" />
           <SettingsContextMenu Enabled="true" />
        <ClientSideEvents ContextMenuItemClick="function(s,e) { OnContextMenuItemClick(s, e); }" />
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                        <EditFormLayoutProperties>
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
            </EditFormLayoutProperties>
            <ClientSideEvents BatchEditConfirmShowing="function(s, e) {
}" RowClick="function(s, e) {
GVNotificationSetups_RowClick(s, e)
	
}" />
            <settingspager numericbuttoncount="6" />
            <Styles>
                <Cell Wrap="False"></Cell>
            </Styles>
        </dx:ASPxGridView>
             <script type="text/javascript" src="../Scripts/jquery-3.1.0.js"></script>
  
    <script type="text/javascript" src="../Scripts/SecurityValidation.js"></script> 
        <script src="../Scripts/NotificationSetup.js"></script>
    <script type="text/javascript">       
        window.onload = function () {
            CacheData();
            
        }
        
    </script>       
    </form>

</body>
</html>