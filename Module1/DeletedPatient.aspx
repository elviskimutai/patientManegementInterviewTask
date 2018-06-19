<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeletedPatient.aspx.cs" Inherits="Module1_DeletedPatient" %>

<%@ Register assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Deleted Patients</title>
    <style type="text/css">





        .auto-style1 {
            width: 100%;
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


.dxflItemSys
{
    text-align: left;
}


.dxflItem { padding: 2px 0; width: 100%; }


.dxflTextEditItemSys .dxflVATSys.dxflCaptionCell { padding-top: 3px; }

.dxflCLLSys .dxflCaptionCell {
    padding-left: 0px;
    padding-right: 6px;
}

.dxflVATSys { vertical-align: top; }

    .dxflCaptionCell {
    width: 1%;
}

.dxflCaptionCell {
    white-space: nowrap;
    line-height: 16px;
    height: 100%;
}

    .dxflCaptionCellSys { /* Bootstrap correction */
    -webkit-box-sizing: content-box;
    -moz-box-sizing: content-box;
    box-sizing: content-box;
}

.dxflHALSys { text-align: left; }
    </style>
</head>
<body>
   
    <form id="form1" runat="server">
        <dx:ASPxCallbackPanel runat="server" ID="cpDeletedPatients" ClientInstanceName="cpDeletedPatients" OnCallback="cpDeletedPatients_Callback"  >
                     <PanelCollection>
                       <dx:PanelContent>
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>        
    <dx:ASPxMenu runat="server" EnableAdaptivity="True" CssClass="nav" ID="ASPxMenu9" EnableTheming="True" Font-Bold="True" ForeColor="Red" Theme="Office2003Blue">
        <Items>
            <dx:MenuItem Text="Get Funding" Name="Item1">
                <ItemStyle/>
                <Template>
                    <dx:ASPxLabel ID="lblCurrentPage" runat="server" Text="Deleted Loan Applications Inquiry" ForeColor="Blue">
                    </dx:ASPxLabel>
                </Template>
            </dx:MenuItem>
            <dx:MenuItem Text="Deleted Loan Applications Inquiry" Name="Item3">
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

                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter" runat="server" GridViewID="GvPatient">
                    </dx:ASPxGridViewExporter>

                </td>
            </tr>
            <tr>
                <td>        
        <dx:ASPxPanel ID="ASPxPanel2" runat="server" Collapsible="True" Theme="Metropolis" ClientInstanceName="topPanel" CssClass="topPanel" EnableTheming="True">
           
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
	case &quot;mnuFind&quot;:

var FromDate=dtpFromDate.GetDate();
var ToDate=dtpToDate.GetDate();
if(FromDate &gt; ToDate)	{
alert('Fromdate is greater than Todate');
return false;
}		
	
cpDeletedPatients.PerformCallback();


		break;
	case &quot;mnuLinks&quot;:


		break;
case &quot;mnuClose&quot;:
	if (confirm('Are you sure you want to Close?')) {
                       window.history.back();

          }	
     break;


case &quot;mnuHelp&quot;:
		window.open(&quot;/WebHelp/Patient/index.htm&quot;);
	break;

	default:
	break;
}
	
}
" />
        <Items>
            <dx:MenuItem Text="Find" Name="mnuFind">
                <Image Url="~/Images/inquiries.png">
                </Image>
            </dx:MenuItem>
           
            <dx:MenuItem Text="Links" Name="mnuLinks">
                <Image Url="~/Images/links.png">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Text="Close" Name="mnuClose">
                <Image Url="~/Images/close.png">
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
    <dx:ASPxMenu ID="ASPxMenu10" runat="server" EnableAdaptivity="True" Theme="Metropolis" EnableTheming="True" CssClass="nav">
         <ClientSideEvents ItemClick="function(s, e)
 {
	switch(e.item.name)
{
	case &quot;mnuFind&quot;:

var FromDate=dtpFromDate.GetDate();
var ToDate=dtpToDate.GetDate();
if(FromDate &gt; ToDate)	{
alert('Fromdate is greater than Todate');
return false;
}		

cpDeletedPatients.PerformCallback();


		break;
	case &quot;mnuLinks&quot;:

		break;
case &quot;mnuClose&quot;:
	if (confirm('Are you sure you want to Close?')) {
                       window.history.back();

          }	
     break;


case &quot;mnuHelp&quot;:
		window.open(&quot;/WebHelp/Patient/index.htm&quot;);
	break;

	default:
	break;
}
	
}
" />
        <Items>
            <dx:MenuItem Text="Find" Name="mnuFind">
                <Image Url="~/Images/inquiries.png">
                </Image>
            </dx:MenuItem>
           
            <dx:MenuItem Text="Links" Name="mnuLinks">
                <Image Url="~/Images/links.png">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Text="Close" Name="mnuClose">
                <Image Url="~/Images/close.png">
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
                </dx:PanelContent>
</PanelCollection>
            <BackgroundImage HorizontalPosition="right" Repeat="NoRepeat" VerticalPosition="center" />
            <Border BorderStyle="None" />
        </dx:ASPxPanel>
                </td>
            </tr>
            <tr>
                <td>
    
        <dx:ASPxPageControl ID="ASPxPageControl2" runat="server" ActiveTabIndex="0" EnableTabScrolling="True" EnableTheming="True" Theme="Metropolis" Width="100%">
            <TabPages>
                <dx:TabPage Text="Deleted Patients Inquiry">
                    <ContentCollection>
                        <dx:ContentControl runat="server">
                            <dx:ASPxFormLayout ID="ASPxFormLayout7" runat="server" ColCount="2">
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="580" />
                                <Items>

                                    <dx:LayoutItem Caption="FromDate" Name="dtpFromDate" RequiredMarkDisplayMode="Required">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxDateEdit ID="dtpFromDate" runat="server" ClientInstanceName="dtpFromDate" Theme="Metropolis" Width="170px">
                                                </dx:ASPxDateEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                        <CaptionCellStyle>
                                            <Paddings PaddingLeft="0px" />
                                        </CaptionCellStyle>
                                        <NestedControlCellStyle>
                                            <Paddings PaddingLeft="0px" />
                                        </NestedControlCellStyle>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="ToDate" Name="dtpToDate" RequiredMarkDisplayMode="Required">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxDateEdit ID="dtpToDate" runat="server" ClientInstanceName="dtpToDate" Theme="Metropolis" Width="170px">
                                                </dx:ASPxDateEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                        <CaptionCellStyle>
                                            <Paddings PaddingLeft="0px" />
                                        </CaptionCellStyle>
                                        <NestedControlCellStyle>
                                            <Paddings PaddingLeft="0px" />
                                        </NestedControlCellStyle>
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
        
    </div>
 
       <dx:ASPxGridView runat="server" Width="100%" ID="GvPatient" ClientInstanceName="GvPatient" EnableRowsCache="False" EnableTheming="True" Theme="Metropolis"   OnFillContextMenuItems="Grid_FillContextMenuItems"  OnContextMenuItemClick="Grid_ContextMenuItemClick">
            <Settings VerticalScrollBarMode="Visible" ShowFilterBar="Visible" ShowFilterRow="True" ShowFilterRowMenu="True" ShowGroupPanel="True" ShowFooter="True" />
                        <SettingsBehavior AllowSelectByRowClick="True" ColumnResizeMode="Control" />
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                        <EditFormLayoutProperties>
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
            </EditFormLayoutProperties>
           <ClientSideEvents ContextMenuItemClick="function(s, e) {
	OnContextMenuItemClick(s, e);

}"
RowClick="function(s, e) {
             
}"
               
 />
            <SettingsContextMenu Enabled="True">
            </SettingsContextMenu>
            <settingspager numericbuttoncount="6" />
          <%-- <TotalSummary>
                <dx:ASPxSummaryItem DisplayFormat="{0:n2}" FieldName="ApprovedAmount" ShowInColumn="ApprovedAmount" SummaryType="Sum" />
              
            </TotalSummary>--%>
            <Styles>
                <Cell Wrap="False"></Cell>
            </Styles>
        </dx:ASPxGridView>

         <script  type ="text/javascript" src="../Scripts/jquery-3.1.0.min.js"></script>


                            <script>
            function OnContextMenuItemClick(sender, args) {
           
                    if (args.item.name == "ExportToPDF" || args.item.name == "ExportToXLS" || args.item.name == "ExportToCSV" || args.item.name == "ExportToWORD") {

                        args.processOnServer = true;
                        args.usePostBack = true;
                    }
               
            }

        </script>
       
          </dx:PanelContent>
     </PanelCollection>
    </dx:ASPxCallbackPanel>
   </form>

</body>
</html>


