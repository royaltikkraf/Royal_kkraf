﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AuthorContList.aspx.vb" Inherits="Royal_kkraf.AuthorContList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script type="text/javascript">


    function updateParent() {
        if (window.opener != null && !window.opener.closed) {

            var sType = document.getElementById("hfType").value;
            var oVal = document.getElementById('hfName').value;
            var oVal02 = document.getElementById('hfIC').value;
            var oVal03 = document.getElementById('hfPayTo').value;
            var oVal04 = document.getElementById('hfICPayTo').value;

            if (sType == "Author") {
                window.opener.setValueAuthor(oVal, oVal02, oVal03, oVal04);
            }
            else if (sType == "Pay") {
                window.opener.setValuePay(oVal, oVal02, oVal03, oVal04);
            }
            window.close();
            return false;
        }
    }

</script>
<body>
    <form id="form1" runat="server">
        <div>

            <div style="border-color: 1; background-color: #C0C0C0">
                <div style="border-style: solid; border-width: 1px; vertical-align: super; font-family: Andalus; font-size: x-large; font-weight: bold; background-color: #FFFFFF; text-align: center;">
                    eRoyalties
                </div>

                Author Listing<br />

                <br />
                &nbsp;Searching By<asp:DropDownList ID="ddlcari" runat="server">
                    <asp:ListItem>Name</asp:ListItem>
                    <asp:ListItem Value="IC">NRIC</asp:ListItem>
                </asp:DropDownList>
                &nbsp;Value
    <asp:TextBox ID="txcari" runat="server"></asp:TextBox>
                &nbsp;<asp:Button ID="btnFind" runat="server" Text="Find" Width="59px" />

                <asp:Button ID="Button3" runat="server" Text="Submit" Width="59px"
                    OnClientClick="updateParent()" />

                <br />

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" AllowSorting="True">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="AuthorName" HeaderText="Name" SortExpression="name" />
                        <asp:BoundField DataField="IC" HeaderText="NRIC" SortExpression="IC" />
                        <asp:BoundField DataField="PayTo" HeaderText="Pay To" SortExpression="PayTo" />
                        <asp:BoundField DataField="ICPayTo" HeaderText="NRIC" SortExpression="ICPayTo" />
                        <asp:BoundField DataField="Benefeciary" HeaderText="Benf." SortExpression="DateJoin" />
                        <asp:BoundField DataField="Advance" HeaderText="Adv. Pay" SortExpression="Status" />
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
                <asp:Label ID="SortExp" runat="server"></asp:Label>
                <asp:SqlDataSource ID="SearchAuthor" runat="server"
                    ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>"
                    SelectCommand="SELECT DISTINCT name, nickname, IC, DateJoin, Status, AuthorType AS Type FROM infAuthor ORDER BY name"
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

                <asp:HiddenField ID="hfICPayTo" runat="server" />

                <asp:HiddenField ID="hfType" runat="server" />

                <asp:HiddenField ID="hfCont" runat="server" />

            </div>

        </div>
    </form>
</body>
</html>
