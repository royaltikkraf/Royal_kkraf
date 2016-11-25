<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="u_ContractNewUpdate.aspx.vb" Inherits="Royal_kkraf.u_ContractNewUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<style type="text/css">
        table {
            max-width: 100%;
            background-color: transparent;
        }

        table {
            border-collapse: collapse;
            border-spacing: 0;
        }

        *,
        *:before,
        *:after {
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            box-sizing: border-box;
        }

        * {
            color: #000 !important;
            text-shadow: none !important;
            background: transparent !important;
            box-shadow: none !important;
        }

        input[type="text"],
        input[type="password"],
        input[type="email"] {
            max-width: 280px;
        }

        button,
        input,
        select[multiple],
        textarea {
            background-image: none;
        }

        input,
        button,
        select,
        textarea {
            font-family: inherit;
            font-size: inherit;
            line-height: inherit;
        }

        button,
        input {
            line-height: normal;
        }

        button,
        input,
        select,
        textarea {
            margin: 0;
            font-family: inherit;
            font-size: 100%;
        }

        button,
        select {
            text-transform: none;
        }

        a {
            color: #428bca;
            text-decoration: none;
        }

            a,
            a:visited {
                text-decoration: underline;
            }

        th {
            text-align: left;
        }

        button,
        html input[type="button"],
        input[type="reset"],
        input[type="submit"] {
            cursor: pointer;
            -webkit-appearance: button;
        }

        ul,
        ol {
            margin-top: 0;
            margin-bottom: 10px;
        }
    </style>--%>
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
            font-size: small;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div>

            <asp:Panel ID="PanelDetail" runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            <div style="border-style: solid; border-width: 1px; vertical-align: super; font-family: Andalus; font-size: x-large; font-weight: bold; background-color: #FFFFFF; text-align: center;">
                                eRoyalties : Create/Update Contract
                            </div>
                            <asp:FormView ID="FormView1" runat="server" DataKeyNames="id" DataSourceID="FormView" Width="100%">
                                <EditItemTemplate>
                                    Contract No<br />
                                    <asp:Label ID="idLabel2" runat="server" Text='<%# Eval("ContractNo", "{0}") %>' />
                                    <br />
                                    ISBN<br />
                                    <asp:TextBox ID="ISBNTextBox" runat="server" ReadOnly="true" Text='<%# Bind("ISBN", "{0}") %>' Width="100px" />
                                    <br />
                                    Title<br />
                                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="TitleList" DataTextField="Title" DataValueField="ISBN" SelectedValue='<%# Bind("ISBN") %>'>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="TitleList" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT Title, ISBN FROM infTitles WHERE (ISBN = @ISBN)">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ISBNTextBox" Name="ISBN" PropertyName="Text" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <br />
                                    Contract Date<br />
                                    <asp:TextBox ID="DateContractTextbox" runat="server" Width="80px" Text='<%# Bind("DateContract", "{0:d}") %>' />
                                    <cc1:CalendarExtender ID="DateContractTextbox_CalendarExtender" runat="server" BehaviorID="DateContractTextbox_CalendarExtender" TargetControlID="DateContractTextbox" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                    <br />
                                    Start Date<br />
                                    <asp:TextBox ID="DateStartTextBox" runat="server" Width="80px" Text='<%# Bind("DateStart", "{0:d}") %>' />
                                    <cc1:CalendarExtender ID="DateStartTextBox_CalendarExtender" runat="server" BehaviorID="DateStartTextBox_CalendarExtender" TargetControlID="DateStartTextBox" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                    <br />
                                    End Date<br />
                                    <asp:TextBox ID="DateEndTextBox" runat="server" Width="80px" Text='<%# Bind("DateEnd", "{0:d}") %>' />
                                    <cc1:CalendarExtender ID="DateEndTextBox_CalendarExtender" runat="server" BehaviorID="DateEndTextBox_CalendarExtender" TargetControlID="DateEndTextBox" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                    <br />
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    Contract No<br /><span class="auto-style1"><em><strong>NEW</strong></em></span><br />Title<br />
                                    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="ListTitleInsert" DataTextField="Title" DataValueField="ISBN">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="ListTitleInsert" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT DISTINCT [Title], [ISBN] FROM [infTitles] ORDER BY [Title]"></asp:SqlDataSource>
                                    <br />
                                    Contract Date<br />
                                    <asp:TextBox ID="DateContractTextBox" runat="server" Width="80px" Text='<%# Bind("DateContract", "{0:d}")%>' />
                                    <cc1:CalendarExtender ID="DateContractTextBox_CalendarExtender" runat="server" BehaviorID="DateContractTextBox_CalendarExtender" TargetControlID="DateContractTextBox" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                    <br />
                                    Start Date<br />
                                    <asp:TextBox ID="DateStartTextBox" runat="server" Width="80px" Text='<%# Bind("DateStart", "{0:d}") %>' />
                                    <cc1:CalendarExtender ID="DateStartTextBox_CalendarExtender" runat="server" BehaviorID="DateStartTextBox_CalendarExtender" TargetControlID="DateStartTextBox" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                    <br />
                                    End Date<br />
                                    <asp:TextBox ID="DateEndTextBox" runat="server" Width="80px" Text='<%# Bind("DateEnd", "{0:d}")%>' />
                                    <cc1:CalendarExtender ID="DateEndTextBox_CalendarExtender" runat="server" BehaviorID="DateEndTextBox_CalendarExtender" TargetControlID="DateEndTextBox" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                    <br />
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    id:
                            <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                                    <br />
                                    ISBN<br />
                                    <asp:Label ID="ISBNLabel" runat="server" Text='<%# Bind("ISBN") %>' />
                                    <br />
                                    Contract Date<br />
                                    <asp:Label ID="DateContractLabel" runat="server" Text='<%# Bind("DateContract", "{0:d}") %>' />
                                    <br />
                                    Start<br />
                                    <asp:Label ID="DateStartLabel" runat="server" Text='<%# Bind("DateStart", "{0:d}")%>' />
                                    <br />
                                    End<br />
                                    <asp:Label ID="DateEndLabel" runat="server" Text='<%# Bind("DateEnd", "{0:d}") %>' />
                                    <br />
                                    <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                                    &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
                                    &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
                                </ItemTemplate>
                            </asp:FormView>
                            <asp:SqlDataSource ID="FormView" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" DeleteCommand="DELETE FROM [infContract] WHERE [id] = @id" InsertCommand="INSERT INTO infContract(ItemCode, ISBN, DateStart, DateEnd, DateContract) VALUES (@ItemCode, @ISBN, CONVERT (datetime, @DateStart, 103), CONVERT (datetime, @DateEnd, 103), CONVERT (datetime, @DateContract, 103))" SelectCommand="SELECT id, ISBN, DateStart, DateEnd, DateContract, ContractNo FROM infContract WHERE (id = @id)" UpdateCommand="UPDATE infContract SET ItemCode = @ItemCode, ISBN = @ISBN, DateStart = CONVERT (datetime, @DateStart, 103), DateEnd = CONVERT (datetime, @DateEnd, 103), DateContract = CONVERT (datetime, @DateContract, 103) WHERE (id = @id)">
                                <DeleteParameters>
                                    <asp:Parameter Name="id" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="ItemCode" Type="String" />
                                    <asp:Parameter Name="ISBN" Type="String" />
                                    <asp:Parameter Name="DateStart" Type="DateTime" />
                                    <asp:Parameter Name="DateEnd" Type="DateTime" />
                                    <asp:Parameter Name="DateContract" />
                                </InsertParameters>
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="id" QueryStringField="DocNo" Type="Int32" />
                                </SelectParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="ItemCode" Type="String" />
                                    <asp:Parameter Name="ISBN" Type="String" />
                                    <asp:Parameter Name="DateStart" Type="DateTime" />
                                    <asp:Parameter Name="DateEnd" Type="DateTime" />
                                    <asp:Parameter Name="DateContract" />
                                    <asp:Parameter Name="id" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton ID="LinkButton2" runat="server" Visible="False">Get</asp:LinkButton>
                            <asp:GridView ID="gdAuthor0" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CaptionAlign="Top" CellPadding="2" DataSourceID="ListOfAuthor" ForeColor="Black" GridLines="None">
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                <Columns>
                                    <asp:BoundField DataField="AuthorName" HeaderText="Author" SortExpression="AuthorName" />
                                    <asp:BoundField DataField="IC" HeaderText="NRIC" SortExpression="IC" />
                                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN" />
                                    <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                                    <asp:BoundField DataField="Pecentage" HeaderText="Pecentage" SortExpression="Pecentage" />
                                    <asp:BoundField DataField="payto" HeaderText="Pay To" SortExpression="payto" />
                                </Columns>
                                <FooterStyle BackColor="Tan" />
                                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                <RowStyle HorizontalAlign="Justify" VerticalAlign="Top" />
                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                            </asp:GridView>
                            <asp:GridView ID="gdAuthor" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" CaptionAlign="Top">
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Author" SortExpression="AuthorName">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("AuthorName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="Name" runat="server"></asp:TextBox>
                                            <asp:HyperLink ID="hlGet" runat="server">Get</asp:HyperLink>
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
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Book">
                                        <ItemTemplate>
                                            <asp:TextBox ID="Book" runat="server" Width="50px"></asp:TextBox>
                                            %
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="eBook">
                                        <ItemTemplate>
                                            <asp:TextBox ID="eBook" runat="server" Width="50px"></asp:TextBox>
                                            %
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
                            <asp:SqlDataSource ID="ListOfAuthor" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT [AuthorName], [IC], [ISBN], [ItemCode], [Type], [Pecentage], [payto] FROM [infTransAuthor] WHERE ([ISBN] = @ISBN)">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="ISBN" QueryStringField="ISBN" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
            </asp:Panel>

        </div>
    </form>
</body>
</html>
