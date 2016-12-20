<%@ Page Title="Advance Payment" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="u_Payment.aspx.vb" Inherits="Royal_kkraf.u_Payment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

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
                <td style="text-align: left; vertical-align: top">Payment Date</td>
                <td style="text-align: center; vertical-align: top">:</td>
                <td style="vertical-align: top; text-align: left">
                    <asp:TextBox ID="txtPaymentDate" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPaymentDate" ErrorMessage="Payment Date" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <ajaxToolkit:CalendarExtender ID="txtPaymentDate_CalendarExtender" runat="server" BehaviorID="txtPaymentDate_CalendarExtender" Format="dd/MM/yyyy" TargetControlID="txtPaymentDate">
                    </ajaxToolkit:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top">Contract No</td>
                <td style="text-align: center; vertical-align: top">:</td>
                <td style="vertical-align: top; text-align: left">
                    <input id="txtContractNo" type="text" readonly="readonly" name="ContractNo" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContractNo" ErrorMessage="Contract No" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <button id="btnContract" runat="server" onclick="openContract()">
                        Contract
                    </button>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top">Title</td>
                <td style="text-align: center; vertical-align: top">:</td>
                <td style="vertical-align: top; text-align: left">
                    <input id="txtTitle" type="text" readonly="readonly" name="Title" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top">ISBN</td>
                <td style="text-align: center; vertical-align: top">:</td>
                <td style="vertical-align: top; text-align: left">
                    <input id="txtISBN" type="text" readonly="readonly" name="ISBN" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top">Author</td>
                <td style="text-align: center; vertical-align: top">:</td>
                <td style="vertical-align: top; text-align: left">
                    <input id="txtAuthor" type="text" readonly="readonly" name="Author" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAuthor" ErrorMessage="Author" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <button id="btnAuthor" runat="server" onclick="openAuthor()">
                        Author
                    </button>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top">Author IC</td>
                <td style="text-align: center; vertical-align: top">:</td>
                <td style="vertical-align: top; text-align: left">
                    <input id="txtAuthorIC" runat="server" name="AuthorIC" readonly="readonly" type="text" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top">Pay To</td>
                <td style="text-align: center; vertical-align: top">:</td>
                <td style="vertical-align: top; text-align: left">
                    <input id="txtPayto" type="text" readonly="readonly" name="PayTo" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top">Pay To (IC)</td>
                <td style="text-align: center; vertical-align: top">:</td>
                <td style="vertical-align: top; text-align: left">
                    <input id="txtPaytoIC" type="text" readonly="readonly" name="PayToIC" runat="server" />
                </td>

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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAmount" ErrorMessage="Amount" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top">Note</td>
                <td style="text-align: center; vertical-align: top">:</td>
                <td style="vertical-align: top; text-align: left">
                    <asp:TextBox ID="txtNote" runat="server" Height="100px" TextMode="MultiLine" Width="285px"></asp:TextBox>
                    <asp:SqlDataSource ID="AuthorList" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT DISTINCT [name], [IC] FROM [infAuthor] ORDER BY [name]"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="PaymentType" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT Name, [Desc] FROM ConfPaymentType WHERE Class =@Class ORDER BY [Desc]">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="Class" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top" colspan="3">
                    <asp:DataGrid ID="SenaraiPayment" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" GridLines="Horizontal" HeaderStyle-BackColor="Blue" HeaderStyle-ForeColor="White" HorizontalAlign="Justify" PagerStyle-Visible="True" Style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid">
                        <Columns>
                            <asp:ButtonColumn ButtonType="PushButton" CommandName="Select" Text="&gt;&gt;"></asp:ButtonColumn>
                            <asp:BoundColumn DataField="id" HeaderText="S/N" SortExpression="id" Visible="False"></asp:BoundColumn>
                            <asp:BoundColumn DataField="PaymentDate" DataFormatString="{0:d}" HeaderText="Date" SortExpression="PaymentDate"></asp:BoundColumn>
                            <asp:BoundColumn DataField="TypePayment" HeaderText="Type" SortExpression="TypePayment"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Value" HeaderText="Value" SortExpression="Value"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Note" HeaderText="Note" SortExpression="Note"></asp:BoundColumn>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Justify" VerticalAlign="Middle" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" Mode="NumericPages" VerticalAlign="Middle" />
                        <SelectedItemStyle BackColor="Silver" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="White" />
                    </asp:DataGrid>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top">&nbsp;</td>
                <td style="text-align: center; vertical-align: top">&nbsp;</td>
                <td style="vertical-align: top; text-align: left">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                    <asp:Button ID="btnCancel" runat="server" Text="CANCEL" />
                    <asp:Button ID="btnClear" runat="server" Text="CLEAR" />
                    <asp:Button ID="btnSave" runat="server" Text="SAVE" />
                    <asp:Button ID="btnDelete" runat="server" Text="DELETE" />
                    <asp:Button ID="btnInsert" runat="server" Text="SAVE" />
                </td>
            </tr>
        </table>
        <script type="text/javascript">

            //function openTitle() {
            //    childWindow = open('Booklist.aspx', 'u_Payment', 'resizable=no,width=800,height=600');
            //}

            function openAuthor() {
                childWindow = open('AuthorContList.aspx?Type=Author&Cont=' + document.getElementById("<%=txtContractNo.ClientID%>").value, 'u_Payment', 'resizable=no,width=800,height=600');
            }

            function openContract() {
                childWindow = open('Contractlist.aspx', 'u_Payment', 'resizable=no,width=1200,height=600');
            }

            function setValueAuthor(myVal, myVal02, myVal03, myVal04) {
                document.getElementById("<%=txtAuthor.ClientID%>").value = myVal;
                document.getElementById("<%=txtAuthorIC.ClientID%>").value = myVal02;
                document.getElementById("<%=txtPayto.ClientID%>").value = myVal03;
                document.getElementById("<%=txtPaytoIC.ClientID%>").value = myVal04;
            }



            function setValueContractNo(ContractNo, Title, ISBN) {
                document.getElementById("<%=txtContractNo.ClientID%>").value = ContractNo;
                document.getElementById("<%=txtTitle.ClientID%>").value = Title;
                document.getElementById("<%=txtISBN.ClientID%>").value = ISBN;
            }
        </script>
    </asp:Panel>
</asp:Content>

