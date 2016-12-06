<%@ Page Title="Others Payment" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="u_Payment.aspx.vb" Inherits="Royal_kkraf.u_Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <h2><%: Title %></h2>   
    <asp:Panel ID="PanelGrid" runat="server">

        <asp:Label ID="SortExp" runat="server"></asp:Label>
        <asp:Label ID="lblErrMsg" runat="server"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlFilter" runat="server">
            <asp:ListItem Value="Author">Author</asp:ListItem>
            <asp:ListItem Value="ContractNo">Contract No</asp:ListItem>
            <asp:ListItem Value="DocNo">Document No</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtSearch" runat="server" BackColor="#FFFF99" ToolTip="SEARCH TITLE" Width="250px"></asp:TextBox>
        <asp:ImageButton ID="iBtnSearch" runat="server" ImageAlign="Top" ImageUrl="~/image/search.png" Width="28px" />
        <asp:DataGrid ID="Senarai" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" GridLines="Horizontal" HeaderStyle-BackColor="Blue" HeaderStyle-ForeColor="White" HorizontalAlign="Justify" PagerStyle-Visible="True" Style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid">
            <Columns>
                <asp:ButtonColumn ButtonType="PushButton" CommandName="Select" Text="&gt;&gt;"></asp:ButtonColumn>
                <asp:BoundColumn DataField="id" HeaderText="S/N" SortExpression="id" Visible="False"></asp:BoundColumn>
                <asp:BoundColumn DataField="Date" DataFormatString="{0:d}" HeaderText="Date" SortExpression="Date"></asp:BoundColumn>
                <asp:BoundColumn DataField="DocNo" HeaderText="Doc No" SortExpression="DocNo"></asp:BoundColumn>
                <asp:BoundColumn DataField="ContractNo" HeaderText="Contract No" SortExpression="ContractNo"></asp:BoundColumn>
                <asp:BoundColumn DataField="Author" HeaderText="Name" SortExpression="Author"></asp:BoundColumn>
                <asp:BoundColumn DataField="TypePayment" HeaderText="Payment Type" SortExpression="TypePayment"></asp:BoundColumn>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Justify" VerticalAlign="Middle" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" Mode="NumericPages" VerticalAlign="Middle" />
            <SelectedItemStyle BackColor="Silver" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="White" />
        </asp:DataGrid>
        <asp:Button ID="btnCreate" runat="server" Text="Create New" />
        <asp:HiddenField ID="hfCode" runat="server" />
    </asp:Panel>
    <asp:Panel ID="PanelDetail" runat="server" Visible="False">
        <table style="width: 100%;">
            <tr>
                <td style="text-align: left; vertical-align: top">Date</td>
                <td style="text-align: center; vertical-align: top">:</td>
                <td style="vertical-align: top; text-align: left">
                    <asp:Label ID="lblDate" runat="server"></asp:Label>
                    <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top">Doc. No</td>
                <td style="text-align: center; vertical-align: top">:</td>
                <td style="vertical-align: top; text-align: left">
                    <asp:Label ID="lblDocNo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top">Contract No</td>
                <td style="text-align: center; vertical-align: top">:</td>
                <td style="vertical-align: top; text-align: left">
                    <asp:TextBox ID="txtContractNo" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top">Title</td>
                <td style="text-align: center; vertical-align: top">:</td>
                <td style="vertical-align: top; text-align: left">
                    <asp:TextBox ID="txtTitle" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top">ISBN</td>
                <td style="text-align: center; vertical-align: top">:</td>
                <td style="vertical-align: top; text-align: left">
                    <asp:TextBox ID="txtISBN" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top">Author</td>
                <td style="text-align: center; vertical-align: top">:</td>
                <td style="vertical-align: top; text-align: left">
                    <asp:DropDownList ID="ddlAuthor" runat="server" DataSourceID="AuthorList" DataTextField="name" DataValueField="IC" Width="285px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top">Pay To</td>
                <td style="text-align: center; vertical-align: top">:</td>
                <td style="vertical-align: top; text-align: left">
                    <asp:DropDownList ID="ddlPayTo" runat="server" DataSourceID="AuthorList" DataTextField="name" DataValueField="IC" Width="285px" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top">Payment Type</td>
                <td style="text-align: center; vertical-align: top">:</td>
                <td style="vertical-align: top; text-align: left">
                    <asp:DropDownList ID="ddlPaymentType" runat="server" DataSourceID="PaymentType" DataTextField="Desc" DataValueField="Name" Width="285px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top">Amount(RM)</td>
                <td style="text-align: center; vertical-align: top">:</td>
                <td style="vertical-align: top; text-align: left">
                    <asp:TextBox ID="txtAmount" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top">Note</td>
                <td style="text-align: center; vertical-align: top">:</td>
                <td style="vertical-align: top; text-align: left">
                    <asp:TextBox ID="txtNote" runat="server" Height="100px" TextMode="MultiLine" Width="285px"></asp:TextBox>
                    <asp:SqlDataSource ID="AuthorList" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT DISTINCT [name], [IC] FROM [infAuthor] ORDER BY [name]"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="PaymentType" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT Name, [Desc] FROM ConfPaymentType ORDER BY [Desc]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top">&nbsp;</td>
                <td style="text-align: center; vertical-align: top">&nbsp;</td>
                <td style="vertical-align: top; text-align: left">
                    <asp:Button ID="btnCancel" runat="server" Text="CANCEL" />
                    <asp:Button ID="btnClear" runat="server" Text="CLEAR" />
                    <asp:Button ID="btnSave" runat="server" Text="SAVE" />
                    <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" />
                    <asp:Button ID="btnDelete" runat="server" Text="DELETE" />
                </td>
            </tr>
        </table>
        <script type="text/javascript">
            var popup;

            function SelectName() {
                popup = window.open("BookList.aspx", "Popup", "width=800,height=600");
                popup.focus();
            }
        </script>
    </asp:Panel>
</asp:Content>

