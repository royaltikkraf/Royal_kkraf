<%@ Page Title="Contract" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="u_Contract.aspx.vb" Inherits="Royal_kkraf.u_Contract" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="PanelGrid" runat="server">
        <asp:Label ID="SortExp" runat="server"></asp:Label>
        <asp:Label ID="lblErrMsg" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="txtTitleSearch" runat="server" BackColor="#FFFF99" ToolTip="SEARCH TITLE" Width="250px"></asp:TextBox>
        <asp:ImageButton ID="iBtnSearch" runat="server" ImageAlign="Top" ImageUrl="~/image/search.png" Width="28px" />
        <asp:DataGrid ID="Senarai" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" GridLines="Horizontal" HeaderStyle-BackColor="Blue" HeaderStyle-ForeColor="White" PagerStyle-Visible="True" Style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" HorizontalAlign="Justify">
            <Columns>
                <asp:ButtonColumn CommandName="Select" Text="&gt;&gt;" ButtonType="PushButton"></asp:ButtonColumn>
                <asp:BoundColumn DataField="id" HeaderText="S/N" SortExpression="id" Visible="False"></asp:BoundColumn>
                <asp:BoundColumn DataField="ItemCode" HeaderText="Item Code" SortExpression="ItemCode"></asp:BoundColumn>
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
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ListPIC" ForeColor="Black" GridLines="None" ShowHeader="False">
                            <Columns>
                                <asp:BoundField DataField="AuthorName" HeaderText="AuthorName" SortExpression="AuthorName" />
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
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
                <td style="vertical-align: top; text-align: left">Imprint</td>
                <td style="vertical-align: top; text-align: left">:</td>
                <td>
                    <asp:DropDownList ID="ddlImprint" runat="server" DataSourceID="Imprint" DataTextField="Desc" DataValueField="Imprint" Enabled="False">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="Imprint" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT [Imprint], [Desc] FROM [ConfImprint] ORDER BY [Desc]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Category</td>
                <td style="vertical-align: top; text-align: left">:</td>
                <td>
                    <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="Category" DataTextField="CatDesc" DataValueField="Category" Enabled="False">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="Category" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT DISTINCT [Category], [CatDesc] FROM [ConfCategory] ORDER BY [CatDesc]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Sub Category</td>
                <td style="vertical-align: top; text-align: left">:</td>
                <td>
                    <asp:DropDownList ID="ddlSubCategory" runat="server" DataSourceID="SubCategory" DataTextField="SubCatDesc" DataValueField="SubCategory" Enabled="False">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SubCategory" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT DISTINCT [SubCategory], [SubCatDesc] FROM [ConfCategory] ORDER BY [SubCatDesc]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Author</td>
                <td style="vertical-align: top; text-align: left">:</td>
                <td>
                    <asp:DropDownList ID="ddlAuthor" runat="server" DataSourceID="Author" DataTextField="name" DataValueField="IC">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="Author" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT DISTINCT [name], [IC] FROM [infAuthor] ORDER BY [name]"></asp:SqlDataSource>
                    <asp:Button ID="btnAddAuthor" runat="server" Text="+" />
                    <asp:GridView ID="gdAuthor" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="AuthorList" ForeColor="Black" GridLines="Horizontal">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="iBtnAddAuthor" runat="server" CommandName="AddAuthor" ImageUrl="~/image/add.png" Width="15px" />
                                    <asp:Label ID="lblIDTransAuthor02" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Type" SortExpression="Type">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Type") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlAuthorType02" runat="server" DataSourceID="ConfAuthorType" DataTextField="Desc" DataValueField="Name" SelectedValue='<%# Bind("Type") %>'>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="ConfAuthorType" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT DISTINCT [Name], [Desc] FROM [ConfAuthorType] ORDER BY [Desc]"></asp:SqlDataSource>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="AuthorName" HeaderText="Author" SortExpression="AuthorName" />
                            <asp:TemplateField HeaderText="%" SortExpression="Pecentage">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Pecentage") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAuthorPercentage02" runat="server" Text='<%# Bind("Pecentage") %>' Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="iBtnDelete" runat="server" CommandName="DelAuthor" ImageUrl="~/image/btnClose.png" Width="15px" />
                                    <asp:Label ID="lblIDTransAuthor" runat="server" Text='<%# Eval("Id") %>' Visible="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="AuthorList" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT DISTINCT [Type], [AuthorName], [Pecentage], [Id] FROM [infTransAuthor] WHERE ([ISBN] = @ISBN) ORDER BY [AuthorName]">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="lblISBN" Name="ISBN" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Start Date</td>
                <td style="vertical-align: top; text-align: left">:</td>
                <td>
                    <asp:TextBox ID="txtStartDate" runat="server" Width="80px"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtStartDate" Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">End Date</td>
                <td style="vertical-align: top; text-align: left">:</td>
                <td>
                    <asp:TextBox ID="txtEndDate" runat="server" Width="80px"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtEndDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtEndDate" Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>

                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Published Date</td>
                <td style="vertical-align: top; text-align: left">:</td>
                <td>
                    <asp:TextBox ID="txtPubDate" runat="server" Width="80px"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtPubDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtPubDate" Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">Status</td>
                <td style="vertical-align: top; text-align: left">:</td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server" DataSourceID="Status" DataTextField="Desc" DataValueField="Status">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="Status" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT DISTINCT [Status], [Desc] FROM [ConfStatus] ORDER BY [Desc]"></asp:SqlDataSource>
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
