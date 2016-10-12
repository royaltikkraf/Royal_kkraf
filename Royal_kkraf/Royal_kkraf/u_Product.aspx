<%@ Page Title="Product" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="u_Product.aspx.vb" Inherits="Royal_kkraf.u_Product" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="PanelGrid" runat="server">
        <asp:Label ID="lblStaffID" runat="server"></asp:Label>
        <asp:Label ID="SortExp" runat="server"></asp:Label>
        <asp:Label ID="lblErrMsg" runat="server"></asp:Label>
        <asp:DataGrid ID="Senarai" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" GridLines="Horizontal" HeaderStyle-BackColor="Blue" HeaderStyle-ForeColor="White" PagerStyle-Visible="True" Style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" HorizontalAlign="Justify">
            <Columns>
                <asp:ButtonColumn CommandName="Select" Text="&gt;&gt;" ButtonType="PushButton"></asp:ButtonColumn>
                <asp:BoundColumn DataField="id" HeaderText="ID" SortExpression="id"></asp:BoundColumn>
                <asp:BoundColumn DataField="ItemCode" HeaderText="Item Code" SortExpression="ItemCode"></asp:BoundColumn>
                <asp:BoundColumn DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundColumn>
                <asp:BoundColumn DataField="Catagory1" HeaderText="Category" SortExpression="Catagory1"></asp:BoundColumn>
                <asp:BoundColumn DataField="Catagory2" HeaderText="Sub Category" SortExpression="Catagory2"></asp:BoundColumn>
                <asp:BoundColumn DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundColumn>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Justify" VerticalAlign="Middle" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" Mode="NumericPages" VerticalAlign="Middle" />
            <SelectedItemStyle BackColor="Silver" Font-Bold="True" ForeColor="White" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
        </asp:DataGrid>
        <asp:Button ID="btnCreate" runat="server" Text="Create New" />
    </asp:Panel>
    <asp:Panel ID="PanelDetail" runat="server" Visible="False">
        <table>
            <tr>
                <td style="vertical-align: top; text-align: left">S/N</td>
                <td style="vertical-align: top; text-align: center">:</td>
                <td style="text-align: left; vertical-align: top">
                    <asp:Label ID="lblID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Item Code</td>
                <td style="vertical-align: top; text-align: center">:</td>
                <td style="text-align: left; vertical-align: top">
                    <asp:TextBox ID="txtItemCode" runat="server" Width="80px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Title</td>
                <td style="vertical-align: top; text-align: center">:</td>
                <td style="text-align: left; vertical-align: top">
                    <asp:TextBox ID="txtTitle" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">ISBN</td>
                <td style="vertical-align: top; text-align: center">:</td>
                <td style="text-align: left; vertical-align: top">
                    <asp:TextBox ID="txtISBN" runat="server" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Category</td>
                <td style="vertical-align: top; text-align: center">:</td>
                <td style="text-align: left; vertical-align: top">
                    <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="Category" DataTextField="CatDesc" DataValueField="Category" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left; ">Sub Category</td>
                <td style="vertical-align: top; text-align: center; ">:</td>
                <td style="text-align: left; vertical-align: top;">
                    <asp:DropDownList ID="ddlSubCategory" runat="server" DataSourceID="SubCategory" DataTextField="SubCatDesc" DataValueField="SubCategory">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SubCategory" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT DISTINCT [SubCategory], [SubCatDesc] FROM [ConfCategory] WHERE ([Category] = @Category) ORDER BY [SubCatDesc]">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlCategory" Name="Category" PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="Category" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT DISTINCT [Category], [CatDesc] FROM [ConfCategory] ORDER BY [CatDesc]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Imprint</td>
                <td style="vertical-align: top; text-align: center">:</td>
                <td style="text-align: left; vertical-align: top">
                    <asp:DropDownList ID="ddlimprint" runat="server" DataSourceID="Imprint" DataTextField="Desc" DataValueField="Imprint">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="Imprint" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT [Imprint], [Desc] FROM [ConfImprint] ORDER BY [Desc]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Language</td>
                <td style="vertical-align: top; text-align: center">:</td>
                <td style="text-align: left; vertical-align: top">
                    <asp:DropDownList ID="ddlLanguage" runat="server" DataSourceID="Language" DataTextField="Desc" DataValueField="Language">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="Language" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT [Language], [Desc] FROM [ConfLanguage] ORDER BY [Desc]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Pub. Date</td>
                <td style="vertical-align: top; text-align: center">:</td>
                <td style="text-align: left; vertical-align: top">
                    <asp:TextBox ID="txtPubDate" runat="server" Width="80px"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtPubDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtPubDate" Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">First Print</td>
                <td style="vertical-align: top; text-align: center">:</td>
                <td style="text-align: left; vertical-align: top">
                    <asp:TextBox ID="txtFirstPrintDate" runat="server" Width="80px"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtFirstPrintDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtFirstPrintDate" Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Copyright Date</td>
                <td style="vertical-align: top; text-align: center">:</td>
                <td style="text-align: left; vertical-align: top">
                    <asp:TextBox ID="txtCopyrightDate" runat="server" Width="80px"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtCopyrightDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtCopyrightDate" Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Product Type</td>
                <td style="vertical-align: top; text-align: center">:</td>
                <td style="text-align: left; vertical-align: top">
                    <asp:DropDownList ID="ddlProductType" runat="server" DataSourceID="ProductType" DataTextField="Desc" DataValueField="Type">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="ProductType" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT [Type], [Desc] FROM [ConfProductType] ORDER BY [Desc]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Cover Price</td>
                <td style="vertical-align: top; text-align: center">:</td>
                <td style="text-align: left; vertical-align: top">RM
                    <asp:TextBox ID="txtCoverPrice" runat="server" Width="80px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Cost</td>
                <td style="vertical-align: top; text-align: center">:</td>
                <td style="text-align: left; vertical-align: top">RM
                    <asp:TextBox ID="txtCost" runat="server" Width="80px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Barcode</td>
                <td style="vertical-align: top; text-align: center">:</td>
                <td style="text-align: left; vertical-align: top">
                    <asp:TextBox ID="txtBarcode" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Status</td>
                <td style="vertical-align: top; text-align: center">:</td>
                <td style="text-align: left; vertical-align: top">
                    <asp:DropDownList ID="ddlStatus" runat="server" DataSourceID="Status" DataTextField="Desc" DataValueField="Status">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="Status" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT [Status], [Desc] FROM [ConfStatus] ORDER BY [Desc]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">&nbsp;</td>
                <td style="vertical-align: top; text-align: center">&nbsp;</td>
                <td style="text-align: left; vertical-align: top">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" HeaderText="Error - Validation" ShowMessageBox="True" />
                    <asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancel" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" />
                    <asp:Button ID="btnSave" runat="server" Text="Save" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
