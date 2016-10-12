<%@ Page Title="Sales" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="u_Sales.aspx.vb" Inherits="Royal_kkraf.u_Sales" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="PanelGrid" runat="server">
        <asp:Label ID="SortExp" runat="server"></asp:Label>
        <asp:Label ID="lblErrMsg" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="txtSalesSearch" runat="server" BackColor="#FFFF99" ToolTip="SEARCH TITLE" Width="250px"></asp:TextBox>
        <asp:ImageButton ID="iBtnSearch" runat="server" ImageAlign="Top" ImageUrl="~/image/search.png" Width="28px" />
        <asp:DataGrid ID="Senarai" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" GridLines="Horizontal" HeaderStyle-BackColor="Blue" HeaderStyle-ForeColor="White" PagerStyle-Visible="True" Style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" HorizontalAlign="Justify">
            <Columns>
                <asp:ButtonColumn CommandName="Select" Text="&gt;&gt;" ButtonType="PushButton"></asp:ButtonColumn>
                <asp:BoundColumn DataField="id" HeaderText="S/N" SortExpression="id"></asp:BoundColumn>
                <asp:BoundColumn DataField="SalesDate" HeaderText="Sales Date" SortExpression="SalesDAte" DataFormatString="{0:d}"></asp:BoundColumn>
                <asp:BoundColumn DataField="CustomerName" HeaderText="Customer" SortExpression="CustomerName"></asp:BoundColumn>
                <asp:BoundColumn DataField="SalesType" HeaderText="Sales Type" SortExpression="SalesType"></asp:BoundColumn>
                <asp:BoundColumn DataField="EntryType" HeaderText="Entry Type" SortExpression="EntryType"></asp:BoundColumn>
                <asp:BoundColumn DataField="Qty" HeaderText="Qty" SortExpression="Qty"></asp:BoundColumn>
                <asp:BoundColumn DataField="InvoiceNo" HeaderText="Invoice No." SortExpression="InvoiceNo"></asp:BoundColumn>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Justify" VerticalAlign="Middle" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" Mode="NumericPages" VerticalAlign="Middle" />
            <SelectedItemStyle BackColor="Silver" Font-Bold="True" ForeColor="White" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
        </asp:DataGrid>
        <asp:FileUpload ID="FileUpload1" runat="server" Visible="False" />
        <asp:Button ID="btnUpload" runat="server" Text="Upload" Visible="False" />
        <asp:Button ID="btnCreate" runat="server" Text="Create" />
    </asp:Panel>
    <asp:Panel ID="PanelDetail" runat="server" Visible="False">
        <table>
            <tr>
                <td style="vertical-align: top; text-align: left">S/N</td>
                <td style="vertical-align: top; text-align: left">:</td>
                <td>
                    <asp:Label ID="lblID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Sales Date</td>
                <td style="vertical-align: top; text-align: left">:</td>
                <td>
                    <asp:TextBox ID="txtSalesDate" runat="server" Width="80px"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtSalesDate_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtSalesDate">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Invoice No</td>
                <td style="vertical-align: top; text-align: left">:</td>
                <td>
                    <asp:TextBox ID="txtInvoiceNo" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">ISBN</td>
                <td style="vertical-align: top; text-align: left">:</td>
                <td>
                    <asp:Label ID="lblISBN" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">ItemCode</td>
                <td style="vertical-align: top; text-align: left">:</td>
                <td>
                    <asp:Label ID="lblItemCode" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Title</td>
                <td style="vertical-align: top; text-align: left">:</td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
                    <asp:ImageButton ID="iBtnSearchTitle" runat="server" ImageAlign="Top" ImageUrl="~/image/search.png" Width="28px" />
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Customer Name</td>
                <td style="vertical-align: top; text-align: left">:</td>
                <td>
                    <asp:TextBox ID="txtCustomerName" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Sales Type</td>
                <td style="vertical-align: top; text-align: left">:</td>
                <td>
                    <asp:DropDownList ID="ddlSalesType" runat="server" DataSourceID="SalesType" DataTextField="Desc" DataValueField="Name">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SalesType" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT [Name], [Desc] FROM [ConfSalesType] ORDER BY [Desc]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Entry Type</td>
                <td style="vertical-align: top; text-align: left">:</td>
                <td>
                    <asp:DropDownList ID="ddlEntryType" runat="server" DataSourceID="EntryType" DataTextField="Desc" DataValueField="Name">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="EntryType" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT [Name], [Desc] FROM [ConfEntryType] ORDER BY [Desc]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Qty</td>
                <td style="vertical-align: top; text-align: left">:</td>
                <td>
                    <asp:TextBox ID="txtQty" runat="server" Width="80px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Retail Price</td>
                <td style="vertical-align: top; text-align: left">:</td>
                <td>
                    <asp:TextBox ID="txtRetailPrice" runat="server" Width="80px"></asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Discount</td>
                <td style="vertical-align: top; text-align: left">:</td>
                <td>
                    <asp:TextBox ID="txtDiscount" runat="server" Width="80px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Channel Type</td>
                <td style="vertical-align: top; text-align: left">:</td>
                <td>
                    <asp:DropDownList ID="ddlChannelType" runat="server" DataSourceID="ChannelType" DataTextField="Desc" DataValueField="Name">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="ChannelType" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT [Name], [Desc] FROM [ConfChannelType] ORDER BY [Desc]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">&nbsp;</td>
                <td style="vertical-align: top; text-align: left">&nbsp;</td>
                <td>
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
