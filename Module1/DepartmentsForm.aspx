<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepartmentsForm.aspx.cs" Inherits="Module1_DepartmentsForm" %>


<%@ Register assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
    <title>Departments</title>
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
    <div>
     <dx:ASPxCallbackPanel runat="server" ID="cpDepartments" ClientInstanceName="cpDepartments" OnCallback="cpDepartments_Callback"  >
      <PanelCollection>
      <dx:PanelContent>
        <table class="auto-style1">
            <tr>
                <td>        
    <dx:ASPxMenu runat="server" EnableAdaptivity="True" CssClass="nav" ID="ASPxMenu4" EnableTheming="True" Font-Bold="True" ForeColor="Red" Theme="Metropolis">
        <Items>
            <dx:MenuItem Text="Get Funding" Name="Item1">
                <ItemStyle/>
                <Template>
                    <dx:ASPxLabel ID="lblCurrentPage" runat="server" Text="Departments Details" ForeColor="Blue">
                    </dx:ASPxLabel>
                </Template>
            </dx:MenuItem>
            <dx:MenuItem Text="Invest Your Money" Name="Item3">
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

                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="GvDepartments">
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

			saveDepartments();
	


		break;
	case &quot;mnuEdit&quot;:

			EnableField();

	break;

			DeleteDepartments();


	break;



case &quot;mnuClose&quot;:
	if (confirm('Are you sure you want to Close?')) {
         window.location.href = &quot;../Slider.aspx&quot;;

          }	
     break;

case &quot;mnuHelp&quot;:
		window.open(&quot;/WebHelp/Departments&quot;);
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
    <dx:ASPxMenu ID="ASPxMenu8" runat="server" EnableAdaptivity="True" Theme="Metropolis" EnableTheming="True" CssClass="nav">
        <ClientSideEvents ItemClick="function(s, e)
 {
	switch(e.item.name)
{
	case &quot;mnuSave&quot;:		

			saveDepartments();
		


		break;
	case &quot;mnuEdit&quot;:

			EnableField();


	break;
	case &quot;mnuDelete&quot;:

			DeleteDepartments();


	break;

	

case &quot;mnuClose&quot;:
	if (confirm('Are you sure you want to Close?')) {
    
         window.history.back();

          }	
     break;

case &quot;mnuHelp&quot;:
		window.open(&quot;/WebHelp/Departments/index.htm&quot;);
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
                <dx:TabPage Text="Next Of Kin">
                    <ContentCollection>
                        <dx:ContentControl runat="server">
                            <dx:ASPxFormLayout ID="ASPxFormLayout5" runat="server" ColCount="2">
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="580" />
                                <Items>
                                 
                                     
                                     
                                      <dx:LayoutItem Caption="DeptCode" Name="txtDeptCode" RequiredMarkDisplayMode="Required">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxTextBox ID="txtDeptCode" runat="server" Width="170px" Height="30" ClientInstanceName="txtDeptCode" Theme="Metropolis">          
                                                    
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                      <dx:LayoutItem Caption="DepartMentName" Name="txtDepartMentName" RequiredMarkDisplayMode="Required">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxTextBox ID="txtDepartMentName" runat="server" Width="170px" Height="30" ClientInstanceName="txtDepartMentName" Theme="Metropolis">          
                                                    
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                            <dx:LayoutItem Caption="Description" Name="txtDescription" RequiredMarkDisplayMode="Required">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxTextBox ID="txtDescription" runat="server" Width="170px" Height="30" ClientInstanceName="txtDescription" Theme="Metropolis">          
                                                    
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
        </dx:PanelContent>
       </PanelCollection>
     </dx:ASPxCallbackPanel> 
    </div>

       <dx:ASPxGridView runat="server" Width="100%" ID="GvDepartments" ClientInstanceName="GvDepartments" EnableRowsCache="False" EnableTheming="True" Theme="Metropolis" OnFillContextMenuItems="Grid_FillContextMenuItems"
        OnContextMenuItemClick="Grid_ContextMenuItemClick" KeyFieldName="DeptCode;" >
            <Settings VerticalScrollBarMode="Visible" ShowFilterBar="Visible" ShowFilterRow="True" ShowFilterRowMenu="True" ShowGroupPanel="True" />
                        <SettingsBehavior AllowSelectByRowClick="True" ColumnResizeMode="Control" />
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                        <EditFormLayoutProperties>
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
            </EditFormLayoutProperties>
            <ClientSideEvents RowClick="function(s, e) {
	GvDepartments_RowClick(s, e);
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
        <script src="../Scripts/jquery-3.1.0.min.js"></script>
          
        <script src="../Scripts/Departments.js"></script>
     
     
            </form>

</body>
</html>