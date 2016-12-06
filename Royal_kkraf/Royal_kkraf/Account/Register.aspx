<%@ Page Title="Register" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Register.aspx.vb" Inherits="Royal_kkraf.Register" %>

<%@ Import Namespace="Royal_kkraf" %>
<%@ Import Namespace="Microsoft.AspNet.Identity" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
        }

        input[type=text], input[type=password] {
            width: 200px;
        }

        table {
            border: 1px solid #ccc;
        }

            table th {
                background-color: #F7F7F7;
                color: #333;
                font-weight: bold;
            }

            table th, table td {
                padding: 5px;
                border-color: #ccc;
            }
    </style>
    <h2><%: Title %></h2>
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <th colspan="3"></th>
        </tr>
        <tr>
            <td>Username
            </td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtUsername"
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td>Password
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
            </td>
            <td>
                <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPassword"
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td>Confirm Password
            </td>
            <td>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" />
            </td>
            <td>
                <asp:CompareValidator ErrorMessage="Passwords do not match." ForeColor="Red" ControlToCompare="txtPassword"
                    ControlToValidate="txtConfirmPassword" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Email
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red"
                    ControlToValidate="txtEmail" runat="server" />
                <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
            </td>
        </tr>
        <tr>
            <td style="height: 26px"></td>
            <td style="height: 26px">
                <asp:Button Text="Submit" runat="server" OnClick="RegisterUser" />
            </td>
            <td style="height: 26px"></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="0">
                    <ProgressTemplate>
                        <div id="dvProgress" runat="server" class="style2" style="border-left-color: purple; border-bottom-color: purple; border-top-color: purple; border-right-color: purple">
                            <strong>In Progress……..Please Wait!</strong>
                            <asp:Image ID="Image3" runat="server" Height="76px" ImageAlign="Middle" ImageUrl="~/image/update_Progress.gif" Width="77px" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <ajaxToolkit:AlwaysVisibleControlExtender ID="UpdateProgress2_AlwaysVisibleControlExtender" runat="server" BehaviorID="UpdateProgress2_AlwaysVisibleControlExtender" TargetControlID="UpdateProgress2">
                </ajaxToolkit:AlwaysVisibleControlExtender>
            </td>
        </tr>
    </table>

</asp:Content>
