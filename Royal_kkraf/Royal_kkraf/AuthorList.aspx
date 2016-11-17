<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AuthorList.aspx.vb" Inherits="Royal_kkraf.AuthorList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script type="text/javascript">
    function SetName() {
        if (window.opener != null && !window.opener.closed) {
            var itemcode = window.opener.document.getElementById("<%= Request.QueryString("IC")%>");
            itemcode.value = document.getElementById("hfIC").value;
            var itemdesc = window.opener.document.getElementById("<%= request.querystring("Name") %>");
            itemdesc.value = document.getElementById("hfName").value;
            var PayTo = window.opener.document.getElementById("<%= Request.QueryString("PayTo")%>");
            PayTo.value = document.getElementById("hfPayTo").value;
        }
        window.close();
    }
</script>
<body>
    <form id="form1" runat="server">
        <div>

            <div style="border-color: 1; background-color: #C0C0C0">
                <div style="border-style: solid; border-width: 1px; vertical-align: super; font-family: Andalus; font-size: x-large; font-weight: bold; background-color: #FFFFFF; text-align: center;">
                    eRoyalties</div>

                Author Listing<br />

                <br />
                &nbsp;Searching By<asp:DropDownList ID="ddlcari" runat="server">
                    <asp:ListItem>Name</asp:ListItem>
                    <asp:ListItem Value="IC">NRIC</asp:ListItem>
                </asp:DropDownList>
                &nbsp;Value
    <asp:TextBox ID="txcari" runat="server"></asp:TextBox>
                &nbsp;<asp:Button ID="Button1" runat="server" Text="Find" Width="59px" />

                &nbsp;<asp:Button ID="Button2" runat="server" Text="Submit" Width="59px"
                    OnClientClick="SetName()" />

                <br />

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                    DataSourceID="SearchAuthor" BackColor="White"
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" AllowSorting="True">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                        <asp:BoundField DataField="IC" HeaderText="IC" SortExpression="IC" />
                        <asp:BoundField DataField="nickname" HeaderText="nickname" SortExpression="nickname" />
                        <asp:BoundField DataField="DateJoin" HeaderText="DateJoin" DataFormatString="{0:d}" SortExpression="DateJoin" />
                        <asp:TemplateField HeaderText="Pay To">
                            <ItemTemplate>
                                <asp:HiddenField ID="hfPayToAuthor" runat="server" Value='<%# Eval("IC") %>' />
                                <asp:SqlDataSource ID="AuthorPayTo" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT DISTINCT [PayTo], [AuthorIC] FROM [infAuthorPayTo] WHERE ([AuthorIC] = @AuthorIC) ORDER BY [PayTo]">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hfPayToAuthor" Name="AuthorIC" PropertyName="Value" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:DropDownList ID="ddlPayTo" runat="server" DataSourceID="AuthorPayTo" DataTextField="PayTo" DataValueField="PayTo">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
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
                <asp:SqlDataSource ID="SearchAuthor" runat="server"
                    ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>"
                    SelectCommand="SELECT DISTINCT name, nickname, DateJoin, Status, IC FROM infAuthor ORDER BY name"
                    FilterExpression="{1} like '%{0}%'">

                    <FilterParameters>
                        <asp:ControlParameter ControlID="txcari" Name="itemcode" PropertyName="Text" />
                        <asp:ControlParameter ControlID="ddlcari" Name="ncari"
                            PropertyName="SelectedValue" />
                    </FilterParameters>                    
                </asp:SqlDataSource>

                <asp:HiddenField ID="hfIC" runat="server" />

                <asp:HiddenField ID="hfName" runat="server" />

                <asp:HiddenField ID="hfPayTo" runat="server" />

            </div>

        </div>
    </form>
</body>
</html>
