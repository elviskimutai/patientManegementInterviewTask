<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebForm2.aspx.cs" Inherits="WebForm2" %>

<%@ Register assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script  type ="text/javascript" src="Scripts/jquery-3.1.0.min.js"></script>
     <script type ="text/javascript" src ="Scripts/Book.js"></script>
     <script type ="text/javascript" src ="Scripts/SecurityValidation.js"></script>        
    <style type="text/css">
        .nav {
            width: 100%;
            padding-left: 15px;
                    }
 
                        .dxflFormLayout {
    display: table;
    font: 12px Tahoma, Geneva, sans-serif;
}

.dxflGroup { padding: 6px 5px; width: 100%;}
.dxflGroupCell { padding: 0 8px; }

.dxflVATSys { vertical-align: top; }

.dxflGroup tr:first-child > .dxflGroupCell > .dxflGroupBox,
.dxflGroup > .dxflChildInFirstRowSys > .dxflGroupCell > .dxflGroupBox {
    margin-top: 13px;
}

.dxflGroupBox {
    display: table;
    border-collapse: separate;
    width: 100%;
    border: 1px Solid #9F9F9F;
    border-radius: 3px;
    padding: 0 0 12px;
    margin: 10px 0; 
}
.dxflGroupBoxSys
{
    box-sizing: border-box;
    -moz-box-sizing: border-box;
    -webkit-box-sizing: border-box;
}


.dxflItemSys,
.dxflGroupBoxSys
{
    text-align: left;
}

.dxflGroupBoxCaption {
    background-color: White;
    color: #818181;
    display: inline-block;  
    left: 9px;
    line-height: 16px;
    padding: 0px 3px 0px 3px;  
    position: relative;
    top: -9px;
}

.dxflGroupBox > .dxflGroup { margin-top: -9px; padding: 0 4px; }

.dxflGroupBox > .dxflGroup tr:first-child > .dxflGroupCell > .dxflItem,
.dxflGroupBox > .dxflGroup > .dxflChildInFirstRowSys > .dxflGroupCell > .dxflItem { 
    padding-top: 9px;
}

.dxflItem { padding: 2px 0; width: 100%; }
.dxflTextEditItemSys .dxflVATSys.dxflCaptionCell { padding-top: 3px; }

.dxflCLLSys .dxflCaptionCell,
*[dir="rtl"].dxflFormLayout .dxflCLRSys .dxflCaptionCell {
    padding-left: 0px;
    padding-right: 6px;
}
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
td.dxflNestedControlCell {
    height: 0;
}

        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            padding-left: 15px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>        
    <dx:ASPxMenu runat="server" EnableAdaptivity="True" CssClass="auto-style2" ID="ASPxMenu4" EnableTheming="True" Font-Bold="True" ForeColor="Red" Theme="Metropolis">
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

                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server">
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
                    <Items>
                        <dx:MenuItem Text="Save">
                            <Image Url="~/Images/database.png">
                            </Image>
                        </dx:MenuItem>
                        <dx:MenuItem Text="Edit">
                            <Image Url="~/Images/edit5.png">
                            </Image>
                        </dx:MenuItem>
                        <dx:MenuItem Text="Delete">
                            <Image Url="~/Images/delete.png">
                            </Image>
                        </dx:MenuItem>
                        <dx:MenuItem Text="Export">
                            <Image Url="~/Images/excel.png">
                            </Image>
                        </dx:MenuItem>
                        <dx:MenuItem Text="Links">
                            <Image Url="~/Images/links.png">
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
    <dx:ASPxMenu ID="ASPxMenu5" runat="server" EnableAdaptivity="True" Theme="Metropolis" EnableTheming="True" CssClass="nav">
        <ClientSideEvents ItemClick="function(s, e)
 {
	switch(e.item.name)
{
	case &quot;mnuSave&quot;:		
		ValidateRight2(&quot;Add&quot;,&quot;WebForm2&quot;)		
		if(validation==true)
{
			alert(&quot;Validation succeeded&quot;);
			SaveRecord();
}

		break;
	case &quot;mnuEdit&quot;:
		ValidateRight2(&quot;Add&quot;,&quot;WebForm2&quot;);
	break;
	case &quot;mnuDelete&quot;:
		ValidateRight2(&quot;Add&quot;,&quot;WebForm2&quot;);
	break;
	case &quot;mnuExport&quot;:
		ValidateRight2(&quot;Add&quot;,&quot;WebForm2&quot;);
	break;
	case &quot;mnuLinks&quot;:
		ValidateRight2(&quot;Add&quot;,&quot;WebForm2&quot;);
	break;
case &quot;mnuHelp&quot;:
		window.open(&quot;/WebHelp/Index.htm&quot;);
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
            <dx:MenuItem Text="Close">
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
    
        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="0" EnableTabScrolling="True" EnableTheming="True" Theme="Metropolis" Width="100%">
            <TabPages>
                <dx:TabPage Text="Basic Information">
                    <ContentCollection>
                        <dx:ContentControl runat="server">
                            <dx:ASPxFormLayout ID="ASPxFormLayout3" runat="server" ColCount="2">
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="580" />
                                <Items>
                                    <dx:LayoutItem Caption="CustCode  " RequiredMarkDisplayMode="Required" Name="txtCustCode">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxTextBox ID="ASPxFormLayout2_E5" runat="server" Width="170px">
                                                    <Paddings PaddingLeft="0px" />
                                                    <ValidationSettings Display="Dynamic" ErrorTextPosition="Bottom">
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                        <CaptionCellStyle>
                                            <Paddings PaddingLeft="0px" />
                                        </CaptionCellStyle>
                                        <NestedControlCellStyle>
                                            <Paddings PaddingLeft="0px" />
                                        </NestedControlCellStyle>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="CustName " RequiredMarkDisplayMode="Required" Name="txtCustName">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxTextBox ID="ASPxFormLayout2_E6" runat="server" Width="170px">
                                                    <Paddings PaddingLeft="0px" />
                                                    <ValidationSettings Display="Dynamic" ErrorTextPosition="Bottom">
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                        <CaptionCellStyle>
                                            <Paddings PaddingLeft="0px" />
                                        </CaptionCellStyle>
                                        <NestedControlCellStyle>
                                            <Paddings PaddingLeft="0px" />
                                        </NestedControlCellStyle>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Telephone" RequiredMarkDisplayMode="Required">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxTextBox ID="ASPxFormLayout2_E7" runat="server" Width="170px">
                                                    <Paddings PaddingLeft="0px" />
                                                    <ValidationSettings Display="Dynamic" ErrorTextPosition="Bottom">
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                        <CaptionCellStyle>
                                            <Paddings PaddingLeft="0px" />
                                        </CaptionCellStyle>
                                        <NestedControlCellStyle>
                                            <Paddings PaddingLeft="0px" />
                                        </NestedControlCellStyle>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="CreditLimit" RequiredMarkDisplayMode="Required">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxTextBox ID="ASPxFormLayout2_E8" runat="server" Width="170px">
                                                    <Paddings PaddingLeft="0px" />
                                                    <ValidationSettings Display="Dynamic" ErrorTextPosition="Bottom">
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
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
                <dx:TabPage Text="Other Information">
                    <ContentCollection>
                        <dx:ContentControl runat="server">
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
            </TabPages>

        </dx:ASPxPageControl>
    
                </td>
            </tr>
        </table>
        
    </div>

       <dx:ASPxGridView runat="server" Width="100%" ID="ASPxGridView1" ClientInstanceName="ASPxGridView1" DataSourceID="SqlDataSource1" KeyFieldName="CurrCode" EnableRowsCache="False" EnableTheming="True" Theme="Metropolis">
            <Settings VerticalScrollBarMode="Visible" ShowFilterBar="Visible" ShowFilterRow="True" ShowFilterRowMenu="True" ShowGroupPanel="True" />
                        <SettingsBehavior AllowSelectByRowClick="True" />
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                        <EditFormLayoutProperties>
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
            </EditFormLayoutProperties>
            <settingspager numericbuttoncount="6" />
            <Styles>
                <Cell Wrap="False"></Cell>
            </Styles>
        </dx:ASPxGridView>
                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:conStr %>" SelectCommand="SELECT [CurrID], [CurrCode], [CurrDesc], [CurrPrec], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate], [Terminus] FROM [Currencies]"></asp:SqlDataSource>
    </form>

</body>
</html>
