Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Globalization.CultureInfo
Imports System.Threading

Public Class u_Contract
    Inherits System.Web.UI.Page

    Dim Query As String
    Dim Clss As New Clss
    Dim Result As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-CA")
        If Not Page.IsPostBack Then
            ddlAuthor.DataBind()
            ddlImprint.DataBind()
            ddlCategory.DataBind()
            ddlSubCategory.DataBind()
            ddlStatus.DataBind()
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
        Dim code As String
        Senarai.CurrentPageIndex = 0
        code = Senarai.SelectedItem.Cells(3).Text
        Result = LoadDetailGridContract(code)
        If Result = True Then
            txtTitle.Enabled = False
            PanelDetail.Visible = True
            btnUpdate.Visible = True
            btnDelete.Visible = True
            PanelGrid.Visible = False
            btnSave.Visible = False
            iBtnSearchTitle.Visible = False
        Else
            txtTitle.Enabled = True
            PanelDetail.Visible = False
            btnUpdate.Visible = False
            btnDelete.Visible = False
            PanelGrid.Visible = True
            btnSave.Visible = True
            iBtnSearchTitle.Visible = True
        End If
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

    Function LoadDetailGridContract(id As String) As Boolean
        Query = "Select * From vw_Joining WHERE ISBN ='" & id & "'"
        Result = Clss.ExecuteNonQuery_Contract(Query)
        If Result = True Then
            Dim StartDate As Object
            Dim EndDate As Object
            Dim PubDate As Object

            lblID.Text = Clss.oIDNo

            StartDate = Clss.oDateStart
            If StartDate Is DBNull.Value Or StartDate = "" Then
                txtStartDate.Text = ""
            Else
                If StartDate = "01/01/1900 12:00:00 AM" Or StartDate = "01/01/1900" Then
                    txtStartDate.Text = ""
                Else
                    txtStartDate.Text = Convert.ToDateTime(StartDate).ToString("dd/MM/yyyy")
                End If
            End If

            EndDate = Clss.oDateEnd
            If EndDate Is DBNull.Value Or EndDate = "" Then
                txtEndDate.Text = ""
            Else
                If EndDate = "01/01/1900 12:00:00 AM" Or EndDate = "01/01/1900" Then
                    txtEndDate.Text = ""
                Else
                    txtEndDate.Text = Convert.ToDateTime(EndDate).ToString("dd/MM/yyyy")
                End If
            End If

            PubDate = Clss.oPubDate
            If EndDate Is DBNull.Value Or EndDate = "" Then
                txtPubDate.Text = ""
            Else
                If PubDate = "01/01/1900 12:00:00 AM" Or PubDate = "01/01/1900" Then
                    txtPubDate.Text = ""
                Else
                    txtPubDate.Text = Convert.ToDateTime(PubDate).ToString("dd/MM/yyyy")
                End If
            End If
            lblISBN.Text = Clss.oISBN
            lblItemCode.Text = Clss.oItemCode
            txtTitle.Text = Clss.oTitle

            If Clss.oIC Is DBNull.Value Or Clss.oIC = "" Then
            Else
                ddlAuthor.SelectedValue = Clss.oIC
            End If

            ddlImprint.SelectedValue = Clss.oImprint
            ddlCategory.SelectedValue = Clss.oCategory
            ddlSubCategory.SelectedValue = Clss.oSubCategory
            ddlStatus.SelectedValue = Clss.oStatus
            Result = True
        Else
            ShowPopUpMsg("ERROR : Load Data" & Clss.oErrMsg & "")
            Result = False
        End If
        Return Result
    End Function

    Protected Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        txtTitle.Enabled = True
        PanelDetail.Visible = True
        PanelGrid.Visible = False
        btnCreate.Visible = True
        btnUpdate.Visible = False
        btnDelete.Visible = False
        btnSave.Visible = True
        iBtnSearchTitle.Visible = True
        ClearDetailContract()
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim SQLQuery As String
        SQLQuery = "INSERT INTO infContract(ItemCode, ISBN, DateStart, DateEnd, AuthorIC) VALUES ('" & _
            lblItemCode.Text & "', '" & lblISBN.Text & "', CONVERT(DATETIME, '" & txtStartDate.Text & "', 103), CONVERT(DATETIME, '" & txtEndDate.Text & "', 103), '" & _
            ddlAuthor.SelectedValue & "') "
        Result = Clss.ExecuteNonQuery(SQLQuery)
        If Result = True Then
            ShowPopUpMsg("Succes : SAVE Data")
            LoadGridContract("", "")
            PanelDetail.Visible = False
            PanelGrid.Visible = True
        Else
            ShowPopUpMsg("Error : SAVE Data " & Clss.oErrMsg & "")
        End If
    End Sub

    Private Sub ShowPopUpMsg(msg As String)
        Dim sb As New StringBuilder()
        sb.Append("alert('")
        sb.Append(msg.Replace(vbLf, "\n").Replace(vbCr, "").Replace("'", "\'"))
        sb.Append("');")
        ScriptManager.RegisterStartupScript(Me.Page, Me.[GetType](), "showalert", sb.ToString(), True)
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        PanelDetail.Visible = False
        PanelGrid.Visible = True
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearDetailContract()
    End Sub

    Sub ClearDetailContract()
        lblID.Text = ""
        lblISBN.Text = ""
        lblItemCode.Text = ""
        txtTitle.Text = ""
        txtStartDate.Text = ""
        txtEndDate.Text = ""
        txtPubDate.Text = ""
        ddlAuthor.DataBind()
        ddlImprint.DataBind()
        ddlCategory.DataBind()
        ddlSubCategory.DataBind()
        ddlStatus.DataBind()

    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim SQLQuery As String
        If lblID.Text = 0 Then
            SQLQuery = "INSERT INTO infContract(ItemCode, ISBN, DateStart, DateEnd, AuthorIC) VALUES ('" & _
            lblItemCode.Text & "', '" & lblISBN.Text & "', CONVERT(DATETIME, '" & txtStartDate.Text & "', 103), CONVERT(DATETIME, '" & txtEndDate.Text & "', 103), '" & _
            ddlAuthor.SelectedValue & "') "
        Else
            SQLQuery = "UPDATE infContract SET ItemCode = '" & lblItemCode.Text & "', ISBN = '" & lblISBN.Text & "', DateStart = CONVERT(DATETIME, '" &
                txtStartDate.Text & "', 103), DateEnd = CONVERT(DATETIME, '" & txtEndDate.Text & "', 103), AuthorIC = '" & _
                ddlAuthor.SelectedValue & "' WHERE ISBN ='" & lblISBN.Text & "'"
        End If

        Result = Clss.ExecuteNonQuery(SQLQuery)
        If Result = True Then
            ShowPopUpMsg("Succes : UPDATE Data")
            LoadGridContract("", "")
            PanelDetail.Visible = False
            PanelGrid.Visible = True
        Else
            ShowPopUpMsg("Error : SAVE Data " & Clss.oErrMsg & "")
        End If
    End Sub

    Protected Sub iBtnSearchTitle_Click(sender As Object, e As EventArgs) Handles iBtnSearchTitle.Click
        Query = "Select * From infTitles WHERE Title like '%" & txtTitle.Text & "%'"
        Result = Clss.ExecuteNonQuery_Title(Query)
        If Result = True Then
            lblISBN.Text = Clss.oISBN
            lblItemCode.Text = Clss.oItemCode
            txtTitle.Text = Clss.oTitle
            ddlImprint.SelectedValue = Clss.oImprint
            ddlCategory.SelectedValue = Clss.oCategory
            ddlSubCategory.SelectedValue = Clss.oSubCategory
            Result = True
        Else
            ShowPopUpMsg("ERROR : Load Data" & Clss.oErrMsg & "")
            Result = False
        End If

    End Sub

    Protected Sub btnAddAuthor_Click(sender As Object, e As EventArgs) Handles btnAddAuthor.Click

        Dim SQLQuery As String
        SQLQuery = "INSERT INTO infTransAuthor(IC, AuthorName, ISBN, ItemCode) VALUES ('" & ddlAuthor.SelectedValue & "', '" & ddlAuthor.SelectedItem.ToString & "', '" & lblISBN.Text & "', '" & lblItemCode.Text & "')"
        Result = Clss.ExecuteNonQuery(SQLQuery)
        If Result = True Then
            gdAuthor.DataBind()
        Else
            ShowPopUpMsg("ERROR : ADD Author " & Clss.oErrMsg & "")
        End If
    End Sub

    Private Sub gdAuthor_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gdAuthor.RowCommand

        If e.CommandName = "DelAuthor" Then
            Dim lblidAuthor As Label
            'Dim lblISBNBook As Label
            'lblISBNBook = CType(e.CommandSource.FindControl("Label30"), Label)
            lblidAuthor = CType(e.CommandSource.FindControl("lblIDTransAuthor"), Label)
            If IsNothing(lblidAuthor) = False Then
                Query = "DELETE infTransAuthor WHERE id=" & lblidAuthor.Text & ""
                Result = Clss.ExecuteNonQuery(Query)
                If Result = True Then
                    gdAuthor.DataBind()
                End If
            End If
        ElseIf e.CommandName = "AddAuthor" Then
            Dim lblidAuthor02 As Label
            Dim ddlAuthorType02 As DropDownList
            Dim txtAuthorPercentage02 As TextBox
            lblidAuthor02 = CType(e.CommandSource.FindControl("lblIDTransAuthor02"), Label)
            ddlAuthorType02 = CType(e.CommandSource.FindControl("ddlAuthorType02"), DropDownList)
            txtAuthorPercentage02 = CType(e.CommandSource.FindControl("txtAuthorPercentage02"), TextBox)
            If IsNothing(lblidAuthor02) = False Then
                Query = "UPDATE infTransAuthor SET Type = '" & ddlAuthorType02.SelectedValue & "', Pecentage = " & txtAuthorPercentage02.Text & "  WHERE (id=" & lblidAuthor02.Text & ")"
                Result = Clss.ExecuteNonQuery(Query)
                If Result = True Then
                    gdAuthor.DataBind()
                End If
            End If
        End If

    End Sub

    Protected Sub iBtnSearch_Click(sender As Object, e As ImageClickEventArgs) Handles iBtnSearch.Click
        Dim Cond As String
        Cond = "WHERE Title like '%" & txtTitleSearch.Text & "%'"
        LoadGridContract("", Cond)
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim SQLQuery As String
        SQLQuery = "DELETE FROM infTransAuthor WHERE ISBN =" & lblISBN.Text & "; DELETE FROM infContract WHERE ISBN='" & lblISBN.Text & "'"
        Result = Clss.ExecuteNonQuery(SQLQuery)
        If Result = True Then
            ShowPopUpMsg("Succes : DELETE Data")
            LoadGridContract("", "")
            PanelDetail.Visible = False
            PanelGrid.Visible = True
        Else
            ShowPopUpMsg("Error : DELETE Data " & Clss.oErrMsg & "")
        End If
    End Sub
End Class