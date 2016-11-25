Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Globalization.CultureInfo
Imports System.Threading

Public Class u_Payment
    Inherits System.Web.UI.Page

    Dim Query As String
    Dim Clss As New Clss
    Dim Result As Boolean
    Dim Filter As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-CA")
        If Not Page.IsPostBack Then
            If SortExp.Text = "" Then
                LoadGridPayment("", "")
            Else
                LoadGridPayment(SortExp.Text, "")
            End If

        End If

    End Sub

    Function LoadGridPayment(ByVal SortField As String, ByVal SQuery As String) As Boolean
        Dim dT As DataTable
        Senarai.CurrentPageIndex = 0
        Query = "Select distinct * From infTransAuthor " & SQuery & " Order by ContractNo, AuthorName ASC "
        dT = Clss.ExecuteDataTable(Query, "Senarai")
        If dT Is Nothing Then
            lblErrMsg.Text = String.Format("ERROR : Bind Data ({0})!", Clss.oErrMsg)
        ElseIf Not dT Is Nothing Then
            lblErrMsg.Text = ""
            Senarai.DataSource = dT
            Senarai.DataBind()
            ViewState.Add("Senarai", dT)
            dT.Dispose()
        End If
        Return 0
    End Function

    Private Sub iBtnSearch_Click(sender As Object, e As ImageClickEventArgs) Handles iBtnSearch.Click
        Filter = "WHERE " & ddlFilter.SelectedValue & " like '%" & txtSearch.Text & "%'"
        LoadGridPayment("", Filter)
    End Sub

    Private Sub Senarai_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Senarai.SelectedIndexChanged
        Dim Code As String
        'Dim ISBN As String
        Code = Senarai.SelectedItem.Cells(1).Text
        'ISBN = Senarai.SelectedItem.Cells(3).Text
        EditClick(Code)
    End Sub

    Sub EditClick(Code As String)
        btnEdit.Attributes.Add("onclick", "window.open('u_PaymentNewUpdate.aspx?ope=Edit&DocNo=" & Code & "', 'calendar_window','toolbars=no','location=no','menubar=no','width=800','height=350','resizable=no','top=200','left=250');return false;")
    End Sub
End Class