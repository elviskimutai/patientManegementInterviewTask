<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Approvers.aspx.cs" Inherits="SystemAdministration_Approvers" %>

<%@ Register assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Approvers</title>
   
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

                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="GVApprovers">
                    </dx:ASPxGridViewExporter>

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
		ValidateRight2(&quot;Add&quot;,&quot;Approvers&quot;)		
		if(validation==true)
{
			<%--alert(&quot;Validation succeeded&quot;);--%>
			SaveApprovers();
}

		break;
	case &quot;mnuEdit&quot;:
		ValidateRight2(&quot;Edit&quot;,&quot;Approvers&quot;);
                                         EnableField();
	break;
	case &quot;mnuDelete&quot;:
		ValidateRight2(&quot;Delete&quot;,&quot;Approvers&quot;);
                 DeleteRecord();
	break;
	case &quot;Close&quot;:
		if (confirm(&quot;Are you sure you want to Close?&quot;)) {
                                  ClearCacheData();
                                  window.location.href = &quot;../Slider.aspx&quot;;
                                      }
	break;
	case &quot;mnuLinks&quot;:
		ValidateRight2(&quot;Add&quot;,&quot;Approvers&quot;);
	break;
case &quot;mnuHelp&quot;:
		window.open(&quot;/WebHelp/Approvers.htm&quot;);
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
            <dx:MenuItem Text="Links" Name="mnuLinks">
                <Image Url="~/Images/links.png">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Text="Close" Name="Close">
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
    <dx:ASPxMenu ID="ASPxMenu6" runat="server" EnableAdaptivity="True" Theme="Metropolis" EnableTheming="True" CssClass="nav">
        <ClientSideEvents ItemClick="function(s, e)
 {
	switch(e.item.name)
{
	case &quot;mnuSave&quot;:		
		ValidateRight2(&quot;Add&quot;,&quot;Approvers&quot;)		
		if(validation==true){
			SaveApprovers();
}

		break;
	case &quot;mnuEdit&quot;:
		ValidateRight2(&quot;Edit&quot;,&quot;Approvers&quot;);
                                         EnableField();
	break;
	case &quot;mnuDelete&quot;:
		ValidateRight2(&quot;Delete&quot;,&quot;Approvers&quot;);
                 DeleteRecord();
	break;
	case &quot;Close&quot;:
		if (confirm(&quot;Are you sure you want to Close?&quot;)) {
                                  ClearCacheData();
                                  window.history.back();
                                      }
	break;
	case &quot;mnuLinks&quot;:
		ValidateRight2(&quot;Add&quot;,&quot;Approvers&quot;);
	break;
case &quot;mnuHelp&quot;:
		window.open(&quot;/WebHelp/Approvers.htm&quot;);
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
            <dx:MenuItem Text="Links" Name="mnuLinks">
                <Image Url="~/Images/links.png">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Text="Close" Name="Close">
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
    
        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="0" EnableTabScrolling="True" EnableTheming="True" Theme="Default" Width="100%">
            <TabPages>
                <dx:TabPage Text="Approvers">
                    <ContentCollection>
                        <dx:ContentControl runat="server">
                            <dx:ASPxFormLayout ID="ASPxFormLayout4" runat="server" ColCount="2">
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="580" />
                                <Items>
                                    <dx:LayoutItem Caption="Module" Name="glModule">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxGridLookup ID="glModule" runat="server" ClientInstanceName="glModule" KeyFieldName="ModuleName;" Theme="Metropolis" Width="170px">
                                                    <GridViewProperties>
                                                        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                                        <Settings ShowFilterRow="True" />
                                                    </GridViewProperties>
                                                    <ClientSideEvents TextChanged="function(s, e) {
Module=glModule.GetGridView().GetRowKey(glModule.GetGridView().GetFocusedRowIndex());
	              sessionStorage.setItem ('Module',Module);	
}" />
                                                </dx:ASPxGridLookup>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Approver" Name="glApprover">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxGridLookup ID="glApprovers" runat="server" ClientInstanceName="glApprovers" KeyFieldName="UserName;" Theme="Metropolis" Width="170px">
                                                    <GridViewProperties>
                                                        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                                        <Settings ShowFilterRow="True" />
                                                    </GridViewProperties>
                                                    <ClientSideEvents TextChanged="function(s, e) {
	Approvers=glApprovers.GetGridView().GetRowKey(glApprovers.GetGridView().GetFocusedRowIndex());
	              sessionStorage.setItem ('Approvers',Approvers);
}" />
                                                </dx:ASPxGridLookup>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Allow Email Notification">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxCheckBox ID="chckApprovalStatus" runat="server" CheckState="Unchecked" ClientInstanceName="chckApprovalStatus">
                                                 <ClientSideEvents CheckedChanged="function(s, e) {
	                           GetAllowNotification(s, e);
                                                        if (s.GetChecked())
            {
             sessionStorage.setItem('ApprovalStatus', true);
               }
          
        else
             {
             sessionStorage.setItem('ApprovalStatus', false);
               }
                                }" />
                                                </dx:ASPxCheckBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>


                                     <dx:LayoutItem Caption="Allow sms Notification">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxCheckBox ID="chckAllowSmsNotification" runat="server" CheckState="Unchecked" ClientInstanceName="chckAllowSmsNotification">
                                                 <ClientSideEvents CheckedChanged="function(s, e) {
	                           GetAllowSmsNotification(s, e);
                                                        if (s.GetChecked())
            {
             sessionStorage.setItem('AllowSmsNotification', true);
               }
          
        else
             {
             sessionStorage.setItem('AllowSmsNotification', false);
               }
                               
                                                   
                                                      }" />
                                                </dx:ASPxCheckBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="ApprovalRoute">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxTextBox ID="txtApprovalRoute" runat="server" Width="170px" ClientInstanceName="txtApprovalRoute">
                                                                                           <ClientSideEvents TextChanged="function(s, e) {
	                                                  ApprovalRoute=txtApprovalRoute.GetText();
	                                                  sessionStorage.setItem ('ApprovalRoute',ApprovalRoute)
                                                }" />     
                                                                               </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="ApprovalLevel" Name="txtApprovalLevel">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxTextBox ID="txtApprovalLevel" runat="server" ClientInstanceName="txtApprovalLevel" NullText="Nb.numeric values only accepted" Width="170px">
                                                    <ClientSideEvents KeyPress="function(s, e) {
        var theEvent = e.htmlEvent || window.event;
        var key = theEvent.keyCode || theEvent.which;
         key = String.fromCharCode(key);
          var regex =/[0-9]/;
        if(!regex.test(key))
       {
        theEvent.returnValue = false;
        if(theEvent.preventDefault) 
         theEvent.preventDefault();
        }	
}
" TextChanged="function(s, e) {
        ApprovalLevel=txtApprovalLevel.GetText();
	  sessionStorage.setItem ('ApprovalLevel',ApprovalLevel)	
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Narration" ColSpan="2" Name="txtNarration">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxTextBox ID="txtNarration" runat="server" ClientInstanceName="txtNarration" Width="170px" Theme="Metropolis">
                                                    <ClientSideEvents TextChanged="function(s, e) {
	  Narration=txtNarration.GetText();
	  sessionStorage.setItem ('Narration',Narration)
}" />
                                                </dx:ASPxTextBox>
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
        
    </div>

       <dx:ASPxGridView runat="server" Width="100%" ID="GVApprovers" ClientInstanceName="GVApprovers" EnableRowsCache="False" EnableTheming="True" Theme="Metropolis" KeyFieldName="Module;Approver;ApprovalLevel;ApprovalRoute;" OnFillContextMenuItems="Grid_FillContextMenuItems" OnContextMenuItemClick="Grid_ContextMenuItemClick">
            <Settings VerticalScrollBarMode="Visible" ShowFilterBar="Visible" ShowFilterRow="True" ShowFilterRowMenu="True" ShowGroupPanel="True" />
                        <SettingsBehavior AllowSelectByRowClick="True" ColumnResizeMode="Control"/>
           <SettingsContextMenu Enabled="true" />
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                        <EditFormLayoutProperties>
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
            </EditFormLayoutProperties>
            <ClientSideEvents RowClick="function(s, e) {
GVApprovers_RowClick(s, e);	
}" ContextMenuItemClick="function(s, e) {
OnContextMenuItemClick(s, e);	
}" />
            <settingspager numericbuttoncount="6" />
            <Styles>
                <Cell Wrap="False"></Cell>
            </Styles>
        </dx:ASPxGridView>
             <script type="text/javascript" src="../Scripts/jquery-3.1.0.js"></script>
    <script type="text/javascript" src="../Scripts/Approvers.js"></script>
     <script type="text/javascript" src="../Scripts/SecurityValidation.js"></script>
    <script type="text/javascript">       
        window.onload = function () {
            CacheData();             
            }             
    </script>       
    </form>

</body>
</html>
