<%@ Page Title="Others Payment" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="u_PaymentNewUpdate.aspx.vb" Inherits="Royal_kkraf.u_PaymentNewUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="border-style: solid; border-width: 1px; vertical-align: super; font-family: Andalus; font-size: x-large; font-weight: bold; background-color: #FFFFFF; text-align: center;">
        eRoyalties : Others Payment
    </div>
    <table>
        <tr>
            <td>Contract No</td>
            <td>:</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>Doc No</td>
            <td>:</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>Date</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtDate_CalendarExtender" runat="server" BehaviorID="txtDate_CalendarExtender" Format="dd/MM/yyyy" TargetControlID="txtDate">
                </ajaxToolkit:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td>Author</td>
            <td>:</td>
            <td>
                <asp:DropDownList ID="ddlAuthor" runat="server" DataSourceID="AuthorList" DataTextField="name" DataValueField="name">
                </asp:DropDownList>
                <asp:SqlDataSource ID="AuthorList" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT DISTINCT [name], [IC] FROM [infAuthor] ORDER BY [name]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>Pay To</td>
            <td>:</td>
            <td>
                <asp:DropDownList ID="ddlPayTo" runat="server" DataSourceID="AuthorList" DataTextField="name" DataValueField="name">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Payment Type</td>
            <td>:</td>
            <td>
                <asp:DropDownList ID="ddlPayTo0" runat="server" DataSourceID="PaymentType" DataTextField="Category" DataValueField="CatDesc">
                </asp:DropDownList>
                <asp:SqlDataSource ID="PaymentType" runat="server" ConnectionString="<%$ ConnectionStrings:RoyaltiesConn %>" SelectCommand="SELECT [Category], [CatDesc] FROM [ConfCategory] WHERE ([Div] = @Div)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="2" Name="Div" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                            &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:HiddenField ID="hfISBN" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
