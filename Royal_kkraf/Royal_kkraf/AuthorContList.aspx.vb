Imports System.Web.Security
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Globalization.CultureInfo
Imports System.Threading

Public Class AuthorContList
    Inherits System.Web.UI.Page

    Dim SQLQuery As String

    Dim ConnString As String = ConfigurationManager.ConnectionStrings("RoyaltiesConn").ConnectionString
    Dim Conn As New SqlConnection(ConnString)
    Dim Trans As SqlTransaction
    Dim Comm As SqlCommand
    Dim rectable As DataTable
    Public getresultdata As DataTable
    Public retmesg As String
    Dim BilRow As Integer
    Dim Query As String
    Dim Clss As New Clss
    Dim Result As Boolean
    Dim Filter As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        hfType.Value = Request.QueryString("Type")
        hfCont.Value = Request.QueryString("Cont")

        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-CA")
        If Not Me.Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        End If
        If Not Page.IsPostBack Then
            If SortExp.Text = "" Then
                LoadGridContract("", "")
            Else
                LoadGridContract(SortExp.Text, "")
            End If

        End If
    End Sub

    Function LoadGridContract(ByVal SortField As String, ByVal SQuery As String) As Boolean
        Dim dT As DataTable
        If hfType.Value = "Author" Then
            If SQuery = "" Then
                SQuery = "WHERE ContractNo ='" & hfCont.Value & "'"
            Else
                SQuery = "WHERE ContractNo ='" & hfCont.Value & "' AND " + SQuery
            End If
        Else
            If SQuery <> "" Then
                SQuery = "WHERE ContractNo ='" & hfCont.Value & "' " + SQuery
            End If

        End If

        SQLQuery = "SELECT DISTINCT AuthorName, IC, PayTo, ICPayto, Benefeciary, Advance From vw_infContract_Link " & SQuery & " Order by AuthorName ASC"
        dT = Clss.ExecuteDataTable(SQLQuery, "Senarai")
        If dT Is Nothing Then

        ElseIf Not dT Is Nothing Then

            GridView1.DataSource = dT
            GridView1.DataBind()
            ViewState.Add("Senarai", dT)
            dT.Dispose()
        End If
        Return 0
    End Function

    Private Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        hfName.Value = GridView1.SelectedRow.Cells.Item(1).Text
        hfIC.Value = GridView1.SelectedRow.Cells.Item(2).Text
        hfPayTo.Value = GridView1.SelectedRow.Cells.Item(3).Text
        hfICPayTo.Value = GridView1.SelectedRow.Cells.Item(4).Text
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Dim Query = ddlcari.SelectedValue & " LIKE '%" & txcari.Text & "%'"
        LoadGridContract("", Query)
    End Sub
End Class