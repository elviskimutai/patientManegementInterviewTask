<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CoreModules.aspx.cs" Inherits="SystemAdministration_CoreModules" %>

<%@ Register assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Core Modules</title>  
    
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
         <dx:ASPxCallbackPanel ID="cpCoremodule" runat="server" ClientInstanceName="cpCoremodule"   Theme="Metropolis" OnCallback="cpCoremodule_Callback" >

                                <PanelCollection>
<dx:PanelContent runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>        
    <dx:ASPxMenu runat="server" EnableAdaptivity="True" CssClass="nav" ID="ASPxMenu4" EnableTheming="True" Font-Bold="True" ForeColor="Red" Theme="Metropolis">
        <Items>
            <dx:MenuItem Text="" Name="Item1">
                <ItemStyle/>
                <Template>
                    <dx:ASPxLabel ID="lblCurrentPage" runat="server" Text="Core Modules" ForeColor="Blue">
                    </dx:ASPxLabel>
                </Template>
            </dx:MenuItem>
            <dx:MenuItem Text="" Name="Item3">
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

                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="GvCoreModules">
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
		ValidateRight2(&quot;Add&quot;,&quot;Modules&quot;)		
		if(validation==true)
{
			SaveCoreModule();
			ClearCachedData();
}

		break;
	case &quot;mnuEdit&quot;:
		ValidateRight2(&quot;Edit&quot;,&quot;Modules&quot;);
if(validation==true)
{
			EnableField();
}

	break;
	case &quot;mnuDelete&quot;:
		ValidateRight2(&quot;Delete&quot;,&quot;Modules&quot;);
if(validation==true)
{
			
}

	break;

	case &quot;mnuLinks&quot;:
		ValidateRight2(&quot;View&quot;,&quot;Modules&quot;);
if(validation==true)
{
		
}
	break;

case &quot;mnuClose&quot;:
	if (confirm('Are you sure you want to Close?')) {
         ClearCachedData();
         window.history.back();

          }	
     break;

case &quot;mnuHelp&quot;:
		window.open(&quot;/WebHelp/CoreModules/index.htm&quot;);
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
           <%-- <dx:MenuItem Text="Delete" Name="mnuDelete">
                <Image Url="~/Images/delete.png">
                </Image>
            </dx:MenuItem>--%>
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
    <dx:ASPxMenu ID="ASPxMenu6" runat="server" EnableAdaptivity="True" Theme="Metropolis" EnableTheming="True" CssClass="nav">
        <ClientSideEvents ItemClick="function(s, e)
 {
	switch(e.item.name)
{
	case &quot;mnuSave&quot;:		
		ValidateRight2(&quot;Add&quot;,&quot;Modules&quot;)		
		if(validation==true)
{
			SaveCoreModule();
			ClearCachedData();
}

		break;
	case &quot;mnuEdit&quot;:
		ValidateRight2(&quot;Edit&quot;,&quot;Modules&quot;);
if(validation==true)
{
			EnableField();
}

	break;
	case &quot;mnuDelete&quot;:
		ValidateRight2(&quot;Delete&quot;,&quot;Modules&quot;);
if(validation==true)
{
			
}

	break;

	case &quot;mnuLinks&quot;:
		ValidateRight2(&quot;View&quot;,&quot;Modules&quot;);
if(validation==true)
{
		
}
	break;

case &quot;mnuClose&quot;:
	if (confirm('Are you sure you want to Close?')) {
         ClearCachedData();
         window.history.back();

          }	
     break;

case &quot;mnuHelp&quot;:
		window.open(&quot;/WebHelp/CoreModules/index.htm&quot;);
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
           <%-- <dx:MenuItem Text="Delete" Name="mnuDelete">
                <Image Url="~/Images/delete.png">
                </Image>
            </dx:MenuItem>--%>
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
    
        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="0" EnableTabScrolling="True" EnableTheming="True" Theme="Default" Width="100%">
            <TabPages>
                <dx:TabPage Text="Core Module Information">
                    <ContentCollection>
                        <dx:ContentControl runat="server">
                            <dx:ASPxFormLayout ID="ASPxFormLayout4" runat="server" ColCount="2">
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="580" />
                                <Items>
                                    <dx:LayoutItem Caption="ModuleCode" RequiredMarkDisplayMode="Required" Name="cmbModuleCode">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxComboBox ID="cmbModuleCode" runat="server" Width="170px" ClientInstanceName="cmbModuleCode" Theme="Metropolis">
                                                    <ClientSideEvents TextChanged="function(s, e) {
	 ModuleCode=cmbModuleCode.GetText();
	 sessionStorage.setItem ('ModuleCode',ModuleCode);
}" />
                                                    <Items>
                                                        
                                                        
                                                        <dx:ListEditItem Text="Human Resource" Value="HR" />
                                                     
                                                    </Items>
                                                    <Paddings PaddingLeft="0px" />
                                                    <ValidationSettings Display="Dynamic" ErrorTextPosition="Bottom">
                                                    </ValidationSettings>
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                        <CaptionCellStyle>
                                            <Paddings PaddingLeft="0px" />
                                        </CaptionCellStyle>
                                        <NestedControlCellStyle>
                                            <Paddings PaddingLeft="0px" />
                                        </NestedControlCellStyle>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="UserName" ColSpan="2" Name="glUserName" RequiredMarkDisplayMode="Required">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxGridLookup ID="glUserName" runat="server" Theme="Metropolis" ClientInstanceName="glUserName" Width="170px">
                                                <GridViewProperties>
                                                    <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                                    <Settings ShowFilterRow="True" ShowFilterRowMenu="True" />
                                                </GridViewProperties>
                                                <ClientSideEvents TextChanged="function(s, e) {
	UserName=glUserName.GetGridView().GetRowKey(glUserName.GetGridView().GetFocusedRowIndex());
	sessionStorage.setItem ('UserName',UserName);
}" />
                                            </dx:ASPxGridLookup>
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

       <dx:ASPxGridView runat="server" Width="100%" ID="GvCoreModules" ClientInstanceName="GvCoreModules" EnableRowsCache="False" EnableTheming="True" Theme="Metropolis" KeyFieldName="ModuleCode;UserName;"  OnFillContextMenuItems="Grid_FillContextMenuItems"
        OnContextMenuItemClick="Grid_ContextMenuItemClick" >
            <Settings VerticalScrollBarMode="Visible" ShowFilterBar="Visible" ShowFilterRow="True" ShowFilterRowMenu="True" ShowGroupPanel="True" />
                        <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ColumnResizeMode="Control" />
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                        <EditFormLayoutProperties>
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
            </EditFormLayoutProperties>
            <ClientSideEvents RowClick="function(s, e) {
	GvCoreModules_RowClick(s, e);
}" ContextMenuItemClick="function(s, e) {
OnContextMenuItemClick(s, e); 	
}" />
            <SettingsContextMenu Enabled="True">
            </SettingsContextMenu>
            <settingspager numericbuttoncount="6" />
            <Styles>
                <Cell Wrap="False"></Cell>
            </Styles>
        </dx:ASPxGridView>
         <script  type ="text/javascript" src="../Scripts/jquery-3.1.0.min.js"></script>
         <script type ="text/javascript" src ="../Scripts/SecurityValidation.js"></script>
         <script type ="text/javascript" src ="../Scripts/CoreModules.js"></script>
    <script type ="text/javascript">
        window.onload = function () {
            CachedData();
        }
    </script>
    </dx:PanelContent>
</PanelCollection>
</dx:ASPxCallbackPanel>   
    </form>

</body>
</html>