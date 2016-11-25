<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="u_Payment.aspx.vb" Inherits="Royal_kkraf.u_Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="border-style: solid; border-width: 1px; vertical-align: super; font-family: Andalus; font-size: x-large; font-weight: bold; background-color: #FFFFFF; text-align: center;">
        eRoyalties : Others Payment
    </div>
    <asp:Panel ID="PanelGrid" runat="server">

        <asp:Label ID="SortExp" runat="server"></asp:Label>
        <asp:Label ID="lblErrMsg" runat="server"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlFilter" runat="server">
            <asp:ListItem Value="AuthorName">Author</asp:ListItem>
            <asp:ListItem Value="ContractNo">Contract No</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtSearch" runat="server" BackColor="#FFFF99" ToolTip="SEARCH TITLE" Width="250px"></asp:TextBox>
        <asp:ImageButton ID="iBtnSearch" runat="server" ImageAlign="Top" ImageUrl="~/image/search.png" Width="28px" />
        <asp:DataGrid ID="Senarai" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" GridLines="Horizontal" HeaderStyle-BackColor="Blue" HeaderStyle-ForeColor="White" PagerStyle-Visible="True" Style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" HorizontalAlign="Justify">
            <Columns>
                <asp:ButtonColumn CommandName="Select" Text="Select"></asp:ButtonColumn>
                <asp:BoundColumn DataField="id" HeaderText="S/N" SortExpression="id" Visible="False"></asp:BoundColumn>
                <asp:BoundColumn DataField="ContractNo" HeaderText="Contract No" SortExpression="ContractNo"></asp:BoundColumn>
                <asp:BoundColumn DataField="AuthorName" HeaderText="Author" SortExpression="AuthorName"></asp:BoundColumn>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Justify" VerticalAlign="Middle" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" Mode="NumericPages" VerticalAlign="Middle" />
            <SelectedItemStyle BackColor="Silver" Font-Bold="True" ForeColor="White" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
        </asp:DataGrid>
        <asp:Button ID="btnCreate" runat="server" Text="Create" />
        <asp:Button ID="btnEdit" runat="server" Text="Edit" />
        <asp:HiddenField ID="hfCode" runat="server" />
    </asp:Panel>

</asp:Content>

