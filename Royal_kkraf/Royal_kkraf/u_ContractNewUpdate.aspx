<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="u_ContractNewUpdate.aspx.vb" Inherits="Royal_kkraf.u_ContractNewUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<h2><%: Title %></h2>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Contract</title>
    <style type="text/css">
        #txtTitle {
            width: 400px;
        }

        #txtISBN {
            width: 400px;
        }
    </style>
</head>

<body>

    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div>

            <asp:Panel ID="PanelDetail" runat="server">
                <table>
                    <tr>
                        <td>Contract No</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="txtContract" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Title</td>
                        <td>:</td>
                        <td>
                            <input type="text" id="txtTitle" name="title" readonly="readonly" runat="server" />
                            <input type="button" value="Select Title" id="btnSearch" runat="server" onclick="openTitle()" />
                        </td>
                    </tr>
                    <tr>
                        <td>ISBN</td>
                        <td>:</td>
                        <td>
                            <input type="text" id="txtISBN" name="isbn" readonly="readonly" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>Contract Date</td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtContractDate" runat="server" Width="80px"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtContractDate_CalendarExtender" runat="server" BehaviorID="txtContractDate_CalendarExtender" TargetControlID="txtContractDate" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>Start Date</td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtStartDate" runat="server" Width="80px"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" BehaviorID="txtStartDate_CalendarExtender" TargetControlID="txtStartDate" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>End Date</td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtEndDate" runat="server" Width="80px"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtEndDate_CalendarExtender" runat="server" BehaviorID="txtEndDate_CalendarExtender" TargetControlID="txtEndDate" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>Book</td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtBook" runat="server" Width="80px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>eBook</td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txteBook" runat="server" Width="80px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:LinkButton ID="LinkButton2" runat="server" Visible="False">Get</asp:LinkButton>
                            <asp:GridView ID="gdAuthor" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" CaptionAlign="Top">
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Author" SortExpression="AuthorName">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("AuthorName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="AuthorName" runat="server"></asp:TextBox>
                                            <asp:HyperLink ID="ln" runat="server">Get</asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="NRIC">
                                        <ItemTemplate>
                                            <asp:TextBox ID="IC" runat="server" Width="100px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type" SortExpression="Type">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Type") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:DropDownList ID="Type" runat="server" DataSourceID="ConfAuthorType" DataTextField="Desc" DataValueField="Name" SelectedValue='<%# Bind("Type") %>'>
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="ConfAuthorType" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT DISTINCT [Name], [Desc] FROM [ConfAuthorType] ORDER BY [Desc]"></asp:SqlDataSource>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Benf" SortExpression="Pecentage">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Pecentage") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="Pecentage" runat="server" Width="50px"></asp:TextBox>
                                            %
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pay To">
                                        <ItemTemplate>
                                            <asp:TextBox ID="PayTo" runat="server" Width="150px"></asp:TextBox>
                                            <asp:HyperLink ID="ln02" runat="server">Get</asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="IC">
                                        <ItemTemplate>
                                            <asp:TextBox ID="ICPayTo" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Advance">
                                        <ItemTemplate>
                                            RM<asp:TextBox ID="Advance" runat="server" Width="50px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Delete</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="Tan" />
                                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                            </asp:GridView>
                            <a name="NewComment"></a>
                        </td>
                        <td style="text-align: left; vertical-align: bottom">
                            <asp:Button ID="btnAddAuthor" runat="server" Text="+" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancel" />
                            <asp:Button ID="btnSave" runat="server" Text="Save" />
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" />
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>

        </div>
    </form>
</body>

<script type="text/javascript">
    //var popup;

    //function SelectName() {
    //    popup = window.open("BookList.aspx", "Popup", "width=800,height=600");
    //    popup.focus();
    //}


    function openTitle() {
        childWindow = open('Booklist.aspx', 'u_ContractNewUpdate', 'resizable=no,width=800,height=600');
    }

    function setValueTitle(myVal, myVal02) {
        document.getElementById('txtTitle').value = myVal;
        document.getElementById('txtISBN').value = myVal02;
    }
</script>
</html>
