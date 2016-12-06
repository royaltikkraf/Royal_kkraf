<%@ Page Title="Contract" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="u_Contract.aspx.vb" Inherits="Royal_kkraf.u_Contract" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <h2><%: Title %></h2>   
    <asp:Panel ID="PanelGrid" runat="server">

        <asp:Label ID="SortExp" runat="server"></asp:Label>
        <asp:Label ID="lblErrMsg" runat="server"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlFilter" runat="server">
            <asp:ListItem Value="ContractNo">Contract No</asp:ListItem>
            <asp:ListItem>Title</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtTitleSearch" runat="server" BackColor="#FFFF99" ToolTip="SEARCH TITLE" Width="250px"></asp:TextBox>
        <asp:ImageButton ID="iBtnSearch" runat="server" ImageAlign="Top" ImageUrl="~/image/search.png" Width="28px" />
        <asp:DataGrid ID="Senarai" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" GridLines="Horizontal" HeaderStyle-BackColor="Blue" HeaderStyle-ForeColor="White" PagerStyle-Visible="True" Style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" HorizontalAlign="Justify">
            <Columns>
                <asp:ButtonColumn CommandName="Select" Text="Select"></asp:ButtonColumn>
                <asp:BoundColumn DataField="id" HeaderText="S/N" SortExpression="id" Visible="False"></asp:BoundColumn>
                <asp:BoundColumn DataField="ItemCode" HeaderText="Item Code" SortExpression="ItemCode" Visible="False"></asp:BoundColumn>
                <asp:BoundColumn DataField="ContractNo" HeaderText="Contract No" SortExpression="ContractNo"></asp:BoundColumn>
                <asp:BoundColumn DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN"></asp:BoundColumn>
                <asp:BoundColumn DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundColumn>
                <asp:TemplateColumn HeaderText="Author">
                    <EditItemTemplate>
                        <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Author") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCodePIC" runat="server" Text='<%# bind("ISBN") %>' Visible="False"></asp:Label>
                        <asp:SqlDataSource ID="ListPIC" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT DISTINCT [AuthorName] FROM [infTransAuthor] WHERE ([ISBN] = @ISBN) ORDER BY [AuthorName]">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblCodePIC" Name="ISBN" PropertyName="Text" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ListPIC" ForeColor="#333333" GridLines="None" ShowHeader="False">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="AuthorName" HeaderText="AuthorName" SortExpression="AuthorName" />
                            </Columns>
                            <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                            <SortedAscendingCellStyle BackColor="#FDF5AC" />
                            <SortedAscendingHeaderStyle BackColor="#4D0000" />
                            <SortedDescendingCellStyle BackColor="#FCF6C0" />
                            <SortedDescendingHeaderStyle BackColor="#820000" />
                        </asp:GridView>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="DateStart" HeaderText="Start Date" SortExpression="DateStart" DataFormatString="{0:d}"></asp:BoundColumn>
                <asp:BoundColumn DataField="DateEnd" HeaderText="End Date" SortExpression="DateEnd" DataFormatString="{0:d}"></asp:BoundColumn>
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
