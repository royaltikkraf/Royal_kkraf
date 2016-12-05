<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BookList.aspx.vb" Inherits="Royal_kkraf.BookList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>List of Book</title>
</head>

<body>
    <form id="form1" runat="server">
        <div>

            <div style="border-color: 1; background-color: #C0C0C0">
                <div style="border-style: solid; border-width: 1px; vertical-align: super; font-family: Andalus; font-size: x-large; font-weight: bold; background-color: #FFFFFF; text-align: center;">
                    eRoyalties
                </div>

                Book Listing<br />

                <br />
                &nbsp;Searching By<asp:DropDownList ID="ddlcari" runat="server">
                    <asp:ListItem>Title</asp:ListItem>
                    <asp:ListItem Value="ISBN">ISBN</asp:ListItem>
                </asp:DropDownList>
                &nbsp;Value
    <asp:TextBox ID="txcari" runat="server"></asp:TextBox>
                &nbsp;<asp:Button ID="Button1" runat="server" Text="Find" Width="59px" />

                &nbsp;<input type="button" value="Submit" onclick="SetName();" />

                <br />

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                    DataSourceID="SearchAuthor" BackColor="White"
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" AllowSorting="True">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                        <asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN" />
                        <asp:BoundField DataField="imprint" HeaderText="imprint" SortExpression="imprint" />
                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    </Columns>
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                </asp:GridView>

                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SearchAuthor" DataTextField="Title" DataValueField="Title" Enabled="False">
                </asp:DropDownList>

                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SearchAuthor" DataTextField="ISBN" DataValueField="ISBN" Enabled="False">
                </asp:DropDownList>

                <asp:SqlDataSource ID="SearchAuthor" runat="server"
                    ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>"
                    SelectCommand="SELECT [Title], [ISBN], [imprint], [Status] FROM [infTitles]"
                    FilterExpression="{1} like '%{0}%'">

                    <FilterParameters>
                        <asp:ControlParameter ControlID="txcari" Name="itemcode" PropertyName="Text" />
                        <asp:ControlParameter ControlID="ddlcari" Name="ncari"
                            PropertyName="SelectedValue" />
                    </FilterParameters>
                </asp:SqlDataSource>
            </div>

        </div>
    </form>
</body>
<script type="text/javascript">
    function SetName() {
        if (window.opener != null && !window.opener.closed) {
            var txtTitle = window.opener.document.getElementById("txtTitle");
            txtTitle.value = document.getElementById("DropDownList1").value;
            var txtISBN = window.opener.document.getElementById("txtISBN");
            txtISBN.value = document.getElementById("DropDownList2").value;
        }
        window.close();
    }
</script>
</html>
