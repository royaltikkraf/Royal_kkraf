Imports System.Web.Security
Public Class u_ContractNewUpdate
    Inherits System.Web.UI.Page

    Dim ClsAddUpdate As New AddUpdate
    Dim Clss As New Clss

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        End If
        If Not IsPostBack Then
            If Request.QueryString("ope") = "Edit" Then
                Dim DocNo As String = Request.QueryString("docno")
                SetInitialRow()
                ViewState("CurrentTable") = ClsAddUpdate.loaddetail(DocNo)
                SetEditData()
                SetEditDataForm(DocNo)
                btnAddAuthor.Visible = False
                btnSave.Visible = False
                btnSearch.Visible = False
            Else
                txtContract.Text = "NEW"
                btnSearch.Visible = True
                btnUpdate.Visible = False
                btnDelete.Visible = False
                SetInitialRow()
            End If
        Else
        End If
    End Sub

    Private Sub SetInitialRow()
        Dim dt As New DataTable()
        Dim dr As DataRow = Nothing
        dt.Columns.Add(New DataColumn("AuthorName", GetType(String)))
        dt.Columns.Add(New DataColumn("IC", GetType(String)))
        dt.Columns.Add(New DataColumn("Type", GetType(String)))
        dt.Columns.Add(New DataColumn("Pecentage", GetType(String)))
        dt.Columns.Add(New DataColumn("PayTo", GetType(String)))
        dt.Columns.Add(New DataColumn("ICPayTo", GetType(String)))
        dt.Columns.Add(New DataColumn("Advance", GetType(String)))
        dr = dt.NewRow()

        dr("AuthorName") = String.Empty
        dr("IC") = String.Empty
        dr("Type") = String.Empty
        dr("Pecentage") = 0
        dr("PayTo") = String.Empty
        dr("ICPayTo") = String.Empty
        dr("Advance") = String.Empty
        dt.Rows.Add(dr)

        'Store the DataTable in ViewState
        ViewState("CurrentTable") = dt

        gdAuthor.DataSource = dt
        gdAuthor.DataBind()
    End Sub

    Private Sub SetEditData()
        Dim rowIndex As Integer = 0
        If ViewState("CurrentTable") IsNot Nothing Then
            Dim dt As DataTable = DirectCast(ViewState("CurrentTable"), DataTable)
            gdAuthor.DataSource = dt
            gdAuthor.DataBind()
            If dt.Rows.Count > 0 Then

                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim box1 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(0).FindControl("AuthorName"), TextBox)
                    Dim box2 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(1).FindControl("IC"), TextBox)
                    Dim box3 As DropDownList = DirectCast(gdAuthor.Rows(rowIndex).Cells(2).FindControl("Type"), DropDownList)
                    Dim box4 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(3).FindControl("Pecentage"), TextBox)
                    Dim box5 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(4).FindControl("PayTo"), TextBox)
                    Dim box6 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(4).FindControl("ICPayTo"), TextBox)
                    Dim box8 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(5).FindControl("Advance"), TextBox)

                    box1.Text = dt.Rows(i)("AuthorName").ToString()
                    box2.Text = dt.Rows(i)("IC").ToString()
                    box3.Text = dt.Rows(i)("Type").ToString()
                    box4.Text = dt.Rows(i)("Pecentage").ToString()
                    box5.Text = dt.Rows(i)("PayTo").ToString()
                    box6.Text = dt.Rows(i)("ICPayTo").ToString()
                    box8.Text = dt.Rows(i)("Advance").ToString()

                    rowIndex += 1
                Next
            End If
            '  dtCurrentTable.Rows.Add(drCurrentRow)
            '  ViewState("CurrentTable") = dtCurrentTable


        End If
    End Sub

    Private Sub SetEditDataForm(ContractNo As String)
        Dim SqlQuery As String
        Dim Result As Boolean
        SqlQuery = "Select * FROm infContract Where ContractNo ='" & ContractNo & "'"
        Result = Clss.ExecuteNonQuery_Contract(SqlQuery)
        If Result = True Then
            txtContract.Text = Clss.oContractNo
            txtTitle.Value = Clss.oTitle
            txtISBN.Value = Clss.oISBN
            'txtContractDate.Text = Clss.oDateContract
            txtContractDate.Text = Convert.ToDateTime(Clss.oDateContract).ToString("dd/MM/yyyy")
            'txtStartDate.Text = Clss.oDateStart
            txtStartDate.Text = Convert.ToDateTime(Clss.oDateStart).ToString("dd/MM/yyyy")
            'txtEndDate.Text = Clss.oDateEnd
            txtEndDate.Text = Convert.ToDateTime(Clss.oDateEnd).ToString("dd/MM/yyyy")
            txtBook.Text = Clss.oBook
            txteBook.Text = Clss.oeBook
        End If


    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim lb As LinkButton = DirectCast(sender, LinkButton)
        Dim gvRow As GridViewRow = DirectCast(lb.NamingContainer, GridViewRow)
        Dim rowID As Integer = gvRow.RowIndex
        If ViewState("CurrentTable") IsNot Nothing Then

            Dim dt As DataTable = DirectCast(ViewState("CurrentTable"), DataTable)
            If dt.Rows.Count > 1 Then
                If gvRow.RowIndex < dt.Rows.Count - 1 Then
                    'Remove the Selected Row data and reset row number  
                    dt.Rows.Remove(dt.Rows(rowID))
                    ResetRowID(dt)
                End If

            End If
            ViewState("CurrentTable") = dt

            gdAuthor.DataSource = dt
            gdAuthor.DataBind()

        End If
        SetPreviousData()
    End Sub

    Private Sub ResetRowID(ByVal dt As DataTable)
        Dim rowNumber As Integer = 1
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                '     row(0) = rowNumber
                rowNumber += 1
            Next
        End If
    End Sub

    Private Sub SetPreviousData()
        Dim rowIndex As Integer = 0
        If ViewState("CurrentTable") IsNot Nothing Then
            Dim dt As DataTable = DirectCast(ViewState("CurrentTable"), DataTable)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim box1 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(0).FindControl("AuthorName"), TextBox)
                    Dim box2 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(1).FindControl("IC"), TextBox)
                    Dim box3 As DropDownList = DirectCast(gdAuthor.Rows(rowIndex).Cells(2).FindControl("Type"), DropDownList)
                    Dim box4 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(3).FindControl("Pecentage"), TextBox)
                    Dim box5 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(4).FindControl("PayTo"), TextBox)
                    Dim box6 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(4).FindControl("ICPayTo"), TextBox)
                    Dim box8 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(5).FindControl("Advance"), TextBox)

                    box1.Text = dt.Rows(i)("AuthorName").ToString()
                    box2.Text = dt.Rows(i)("IC").ToString()
                    box3.Text = dt.Rows(i)("Type").ToString()
                    box4.Text = dt.Rows(i)("Pecentage").ToString()
                    box5.Text = dt.Rows(i)("PayTo").ToString()
                    box6.Text = dt.Rows(i)("ICPayTo").ToString()
                    box8.Text = dt.Rows(i)("Advance").ToString()

                    rowIndex += 1
                Next
            End If
        End If
    End Sub

    Private Sub btnAddAuthor_Click(sender As Object, e As EventArgs) Handles btnAddAuthor.Click
        AddNewRowToGridBlank()
        Page.ClientScript.RegisterStartupScript(Me.[GetType](), "anchor", "location.hash = '#NewComment';", True)
    End Sub

    Private Sub AddNewRowToGridBlank()
        Dim rowIndex As Integer = 0

        If ViewState("CurrentTable") IsNot Nothing Then
            Dim dtCurrentTable As DataTable = DirectCast(ViewState("CurrentTable"), DataTable)
            Dim drCurrentRow As DataRow = Nothing
            If dtCurrentTable.Rows.Count > 0 Then
                For i As Integer = 1 To dtCurrentTable.Rows.Count
                    'extract the TextBox values
                    Dim box1 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(0).FindControl("AuthorName"), TextBox)
                    Dim box2 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(1).FindControl("IC"), TextBox)
                    Dim box3 As DropDownList = DirectCast(gdAuthor.Rows(rowIndex).Cells(2).FindControl("Type"), DropDownList)
                    Dim box4 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(3).FindControl("Pecentage"), TextBox)
                    Dim box5 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(4).FindControl("PayTo"), TextBox)
                    Dim box6 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(4).FindControl("ICPayTo"), TextBox)
                    Dim box8 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(5).FindControl("Advance"), TextBox)

                    drCurrentRow = dtCurrentTable.NewRow()
                    '  drCurrentRow("RowNumber") = i + 1
                    dtCurrentTable.Rows(i - 1)("AuthorName") = box1.Text
                    dtCurrentTable.Rows(i - 1)("IC") = box2.Text
                    dtCurrentTable.Rows(i - 1)("Type") = box3.SelectedValue
                    dtCurrentTable.Rows(i - 1)("Pecentage") = box4.Text
                    dtCurrentTable.Rows(i - 1)("PayTo") = box5.Text
                    dtCurrentTable.Rows(i - 1)("ICPayTo") = box6.Text
                    dtCurrentTable.Rows(i - 1)("Advance") = box8.Text

                    rowIndex += 1
                Next


                drCurrentRow = dtCurrentTable.NewRow()
                dtCurrentTable.Rows.Add(drCurrentRow)
                ViewState("CurrentTable") = dtCurrentTable

                gdAuthor.DataSource = dtCurrentTable
                gdAuthor.DataBind()
            End If
        Else
            Response.Write("ViewState is null")
        End If

        'Set Previous Data on Postbacks
        SetPreviousData()
    End Sub

    Private Sub gdAuthor_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gdAuthor.RowDataBound

        Dim ln As HyperLink
        Dim ln02 As HyperLink
        Dim IC As String
        Dim ICPayTo As String
        Dim Name As String
        Dim PayTo As String
        If e.Row.RowType = DataControlRowType.DataRow Then
            ln = e.Row.FindControl("ln")
            ln02 = e.Row.FindControl("ln02")

            Name = e.Row.FindControl("AuthorName").ClientID
            IC = e.Row.FindControl("IC").ClientID

            PayTo = e.Row.FindControl("PayTo").ClientID
            ICPayTo = e.Row.FindControl("ICPayTo").ClientID

            If ln.Text = "Get" Then
                ln.NavigateUrl = "javascript:calendar_window=window.open('Authorlist.aspx?Name=" + Name + "&IC=" + IC & "','calendar','width=800,height=700,top=200,left=400');calendar_window.focus()"
            End If
            If ln02.Text = "Get" Then
                ln02.NavigateUrl = "javascript:calendar_window=window.open('Authorlist.aspx?Name=" + PayTo + "&IC=" + ICPayTo + "','calendar','width=800,height=700,top=200,left=400');calendar_window.focus()"
            End If
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        If Not IsNothing(txtTitle.Value) Then
            ClsAddUpdate.pDocNo = "NEW"
            ClsAddUpdate.pDocType = "CNT"
            ClsAddUpdate.Title = txtTitle.Value
            ClsAddUpdate.ISBN = txtISBN.Value
            ClsAddUpdate.ContractDate = txtContractDate.Text
            ClsAddUpdate.StartDate = txtStartDate.Text
            ClsAddUpdate.EndDate = txtEndDate.Text
            ClsAddUpdate.Book = txtBook.Text
            ClsAddUpdate.eBook = txteBook.Text

            If txtBook.Text <> "" Then
                ClsAddUpdate.Book = txtBook.Text
            Else
                ClsAddUpdate.Book = 0
            End If
            If txteBook.Text <> "" Then
                ClsAddUpdate.eBook = txteBook.Text
            Else
                ClsAddUpdate.eBook = 0
            End If

            AddNewRowToGridBlank()
            ClsAddUpdate.Rectable = DirectCast(ViewState("CurrentTable"), DataTable)
            If ClsAddUpdate.savestocktransfer("Update") Then
                Response.Redirect("u_Contract.aspx")
            Else
                'gdAuthor.Rows(ClsAddUpdate.BilRow).BackColor = Drawing.Color.Red
                ShowPopUpMsg(ClsAddUpdate.RetMsg)
            End If
        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim i As Integer
        For i = 0 To gdAuthor.Rows.Count - 1
            gdAuthor.Rows(i).BackColor = Drawing.Color.White
        Next i
        If txtTitle.Value <> "" Then
            ClsAddUpdate.pDocNo = "NEW"
            ClsAddUpdate.pDocType = "CNT"
            ClsAddUpdate.Title = txtTitle.Value
            ClsAddUpdate.ISBN = txtISBN.Value
            ClsAddUpdate.ContractDate = txtContractDate.Text
            ClsAddUpdate.StartDate = txtStartDate.Text
            ClsAddUpdate.EndDate = txtEndDate.Text
            If txtBook.Text <> "" Then
                ClsAddUpdate.Book = txtBook.Text
            Else
                ClsAddUpdate.Book = 0
            End If
            If txteBook.Text <> "" Then
                ClsAddUpdate.eBook = txteBook.Text
            Else
                ClsAddUpdate.eBook = 0
            End If
            AddNewRowToGridBlank()
            ClsAddUpdate.Rectable = DirectCast(ViewState("CurrentTable"), DataTable)
            If ClsAddUpdate.savestocktransfer("Create") Then
                Response.Redirect("u_Contract.aspx")
            Else
                gdAuthor.Rows(ClsAddUpdate.BilRow).BackColor = Drawing.Color.Red
                ShowPopUpMsg(ClsAddUpdate.RetMsg)
            End If
        End If
    End Sub

    'Function checkTitle(ISBN As String) As Boolean
    '    Dim sqlquery As String
    '    Dim Result As Boolean
    '    sqlquery = "SELECT * FROM infTitles Where ISBN ='" & ISBN & "'"
    '    Result = Clss.ExecuteNonQuery_Title(sqlquery)
    '    If Result = True Then
    '        rISBN = Clss.oISBN
    '        rTitle = Clss.oTitle
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function

    Private Sub ShowPopUpMsg(msg As String)
        Dim sb As New StringBuilder()
        sb.Append("alert('")
        sb.Append(msg.Replace(vbLf, "\n").Replace(vbCr, "").Replace("'", "\'"))
        sb.Append("');")
        ScriptManager.RegisterStartupScript(Me.Page, Me.[GetType](), "showalert", sb.ToString(), True)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("u_Contract.aspx")
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim SQLQuery As String
        Dim ContractNo As String = Request.QueryString("docno")
        SQLQuery = "DELETE FROM infContract WHERE ContractNo ='" & ContractNo & "'; Delete FROM infTransAuthor WHERE ContractNo='" & ContractNo & "'"
        Dim Result As Boolean
        Result = Clss.ExecuteNonQuery(SQLQuery)
        If Result = False Then
            ShowPopUpMsg(Clss.oErrMsg)
        Else
            Response.Redirect("u_Contract.aspx")
        End If
    End Sub

End Class