Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Globalization.CultureInfo
Imports System.Threading

Public Class u_Contract
    Inherits System.Web.UI.Page

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
        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-CA")
        If Not Page.IsPostBack Then
            If SortExp.Text = "" Then
                LoadGridContract("", "")
            Else
                LoadGridContract(SortExp.Text, "")
            End If

        End If
    End Sub

    Function SortOrder(ByVal Field As String) As String
        Dim so As String = SortExp.Text
        If Field = so Then
            SortOrder = Replace(Field, "asc", "desc")
        Else
            SortOrder = Replace(Field, "desc", "asc")
        End If
    End Function

    Private Sub Status_PageChange(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Senarai.PageIndexChanged
        Senarai.CurrentPageIndex = e.NewPageIndex
        Dim dt As DataTable = TryCast(ViewState("Senarai"), DataTable)
        dt.DefaultView.Sort = ViewState("sorting")
        Senarai.DataSource = ViewState("Senarai")
        Senarai.DataBind()

    End Sub

    Private Sub Senarai_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Senarai.SelectedIndexChanged
        Dim Code As String
        'Dim ISBN As String
        Code = Senarai.SelectedItem.Cells(3).Text
        'ISBN = Senarai.SelectedItem.Cells(4).Text
        EditClick(Code)
    End Sub

    Private Sub Status_Sort(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles Senarai.SortCommand
        Senarai.CurrentPageIndex = 0
        Dim dt As DataTable
        dt = TryCast(ViewState("Senarai"), DataTable)
        dt.DefaultView.Sort = String.Format("{0} {1}", e.SortExpression, GetSortDirection(e.SortExpression)) 'a_Exec ASC
        ViewState.Add("sorting", dt.DefaultView.Sort)
        Senarai.DataSource = ViewState("Senarai")
        'dt = ViewState("data")
        Senarai.DataBind()
        ViewState.Add("data", dt)
    End Sub

    Private Function GetSortDirection(ByVal column As String) As String
        ' By default, set the sort direction to ascending.
        Dim sortDirection = "ASC"
        ' Retrieve the last column that was sorted.
        Dim sortExpression = TryCast(ViewState("SortExpression"), String)
        If sortExpression IsNot Nothing Then
            ' Check if the same column is being sorted.
            ' Otherwise, the default value can be returned.
            If sortExpression = column Then
                Dim lastDirection = TryCast(ViewState("SortDirection"), String)
                If lastDirection IsNot Nothing _
                  AndAlso lastDirection = "ASC" Then

                    sortDirection = "DESC"

                End If
            End If
        End If
        ' Save new values in ViewState.
        ViewState("SortDirection") = sortDirection
        ViewState("SortExpression") = column
        Return sortDirection
    End Function

    Function LoadGridContract(ByVal SortField As String, ByVal SQuery As String) As Boolean
        Dim dT As DataTable
        Senarai.CurrentPageIndex = 0
        Query = "Select distinct * From vw_Joining " & SQuery & " Order by Title ASC"
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

    Private Sub ShowPopUpMsg(msg As String)
        Dim sb As New StringBuilder()
        sb.Append("alert('")
        sb.Append(msg.Replace(vbLf, "\n").Replace(vbCr, "").Replace("'", "\'"))
        sb.Append("');")
        ScriptManager.RegisterStartupScript(Me.Page, Me.[GetType](), "showalert", sb.ToString(), True)
    End Sub
    Sub EditClick(Code As String)
        btnEdit.Attributes.Add("onclick", "window.open('u_ContractNewUpdate.aspx?ope=Edit&DocNo=" & Code & "', 'calendar_window','toolbars=no','location=no','menubar=no','width=800','height=350','resizable=no','top=200','left=250');return false;")
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        btnCreate.Attributes.Add("onclick", "window.open('u_ContractNewUpdate.aspx', 'calendar_window','toolbars=no','location=no','menubar=no','width=800','height=350','resizable=no','top=200','left=250');return false;")
    End Sub

    Protected Sub iBtnSearch_Click(sender As Object, e As ImageClickEventArgs) Handles iBtnSearch.Click
        Filter = "WHERE Title like '%" & txtTitleSearch.Text & "%'"
        LoadGridContract("", Filter)
    End Sub
End Class