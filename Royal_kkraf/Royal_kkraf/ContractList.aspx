<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ContractList.aspx.vb" Inherits="Royal_kkraf.ContractList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>List of Contract</title>
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
                    <asp:ListItem Value="ContractNo">Contract No</asp:ListItem>
                    <asp:ListItem>Title</asp:ListItem>
                </asp:DropDownList>&nbsp;Value<asp:TextBox ID="txcari" runat="server"></asp:TextBox>
                &nbsp;<asp:Button ID="Button1" runat="server" Text="Find" Width="59px" />

                &nbsp;<%--<input id="cf1" type="text" runat="server" />--%><input type="button" value="Submit" id="GetF" onclick="javascript: return updateParent()" />
                <br />

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                    DataSourceID="SearchContract" BackColor="White"
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" AllowSorting="True">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="ContractNo" HeaderText="ContractNo" SortExpression="ContractNo" />
                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                        <asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN" />
                        <asp:BoundField DataField="DateContract" DataFormatString="{0:d}" HeaderText="DateContract" SortExpression="DateContract" />
                        <asp:BoundField DataField="DateStart" DataFormatString="{0:d}" HeaderText="DateStart" SortExpression="DateStart" />
                        <asp:BoundField DataField="DateEnd" HeaderText="DateEnd" SortExpression="DateEnd" DataFormatString="{0:d}" />
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

                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SearchContract" DataTextField="ContractNo" DataValueField="ContractNo" Enabled="False">
                </asp:DropDownList>

                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SearchContract" DataTextField="Title" DataValueField="Title" Enabled="False">
                </asp:DropDownList>

                <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SearchContract" DataTextField="ISBN" DataValueField="ISBN" Enabled="False">
                </asp:DropDownList>

                <asp:SqlDataSource ID="SearchContract" runat="server"
                    ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>"
                    SelectCommand="SELECT DISTINCT ContractNo, Title, ISBN, DateContract, DateStart, DateEnd FROM vw_infContract_Link"
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
    //function SetName() {
    //    if (window.opener != null && !window.opener.closed) {
    //        var txtTitle = window.opener.document.getElementById("txtTitle");
    //        txtTitle.value = document.getElementById("DropDownList1").value;
    //        var txtISBN = window.opener.document.getElementById("txtISBN");
    //        txtISBN.value = document.getElementById("DropDownList2").value;
    //    }
    //    window.close();
    //}

    function updateParent() {

        var oContractNo = document.getElementById('DropDownList1').value;
        var oTitle = document.getElementById('DropDownList2').value;
        var oISBN = document.getElementById('DropDownList3').value;

        window.opener.setValueContractNo(oContractNo, oTitle, oISBN);

        window.close();

        return false;
    }

</script>
</html>
