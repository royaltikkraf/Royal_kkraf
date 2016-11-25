Public Class u_ContractNewUpdate
    Inherits System.Web.UI.Page

    Dim ClsAddUpdate As New AddUpdate
    Dim Clss As New Clss

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If Request.QueryString("ope") = "Edit" Then
                FormView1.ChangeMode(FormViewMode.Edit)
                SetInitialRow()
                ViewState("CurrentTable") = ClsAddUpdate.loaddetail(Request.QueryString("docno"))
                SetEditData()
                btnAddAuthor.Visible = False
                btnSave.Visible = False
            Else
                FormView1.ChangeMode(FormViewMode.Insert)
                btnUpdate.Visible = False
                btnDelete.Visible = False
                SetInitialRow()
            End If
        End If
    End Sub

    Private Sub SetInitialRow()
        Dim dt As New DataTable()
        Dim dr As DataRow = Nothing
        dt.Columns.Add(New DataColumn("Name", GetType(String)))
        dt.Columns.Add(New DataColumn("IC", GetType(String)))
        dt.Columns.Add(New DataColumn("Type", GetType(String)))
        dt.Columns.Add(New DataColumn("Pecentage", GetType(String)))
        dt.Columns.Add(New DataColumn("PayTo", GetType(String)))
        dt.Columns.Add(New DataColumn("Book", GetType(String)))
        dt.Columns.Add(New DataColumn("eBook", GetType(String)))
        dt.Columns.Add(New DataColumn("Advance", GetType(String)))
        dr = dt.NewRow()
        dr("Name") = String.Empty
        dr("IC") = String.Empty
        dr("Type") = String.Empty
        dr("Pecentage") = 0
        dr("PayTo") = String.Empty
        dr("Book") = String.Empty
        dr("eBook") = String.Empty
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
                    Dim box1 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(0).FindControl("Name"), TextBox)
                    Dim box2 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(1).FindControl("IC"), TextBox)
                    Dim box3 As DropDownList = DirectCast(gdAuthor.Rows(rowIndex).Cells(2).FindControl("Type"), DropDownList)
                    Dim box4 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(3).FindControl("Pecentage"), TextBox)
                    Dim box5 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(4).FindControl("PayTo"), TextBox)
                    Dim box6 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(5).FindControl("Book"), TextBox)
                    Dim box7 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(5).FindControl("eBook"), TextBox)
                    Dim box8 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(5).FindControl("Advance"), TextBox)

                    box1.Text = dt.Rows(i)("Name").ToString()
                    box2.Text = dt.Rows(i)("IC").ToString()
                    box3.Text = dt.Rows(i)("Type").ToString()
                    box4.Text = dt.Rows(i)("Pecentage").ToString()
                    box5.Text = dt.Rows(i)("PayTo").ToString()
                    box6.Text = dt.Rows(i)("Book").ToString()
                    box7.Text = dt.Rows(i)("eBook").ToString()
                    box8.Text = dt.Rows(i)("Advance").ToString()

                    rowIndex += 1
                Next
            End If
            '  dtCurrentTable.Rows.Add(drCurrentRow)
            '  ViewState("CurrentTable") = dtCurrentTable


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
                    Dim box1 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(0).FindControl("Name"), TextBox)
                    Dim box2 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(1).FindControl("IC"), TextBox)
                    Dim box3 As DropDownList = DirectCast(gdAuthor.Rows(rowIndex).Cells(2).FindControl("Type"), DropDownList)
                    Dim box4 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(3).FindControl("Pecentage"), TextBox)
                    Dim box5 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(4).FindControl("PayTo"), TextBox)
                    Dim box6 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(5).FindControl("Book"), TextBox)
                    Dim box7 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(5).FindControl("eBook"), TextBox)
                    Dim box8 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(5).FindControl("Advance"), TextBox)

                    box1.Text = dt.Rows(i)("Name").ToString()
                    box2.Text = dt.Rows(i)("IC").ToString()
                    box3.Text = dt.Rows(i)("Type").ToString()
                    box4.Text = dt.Rows(i)("Pecentage").ToString()
                    box5.Text = dt.Rows(i)("PayTo").ToString()
                    box6.Text = dt.Rows(i)("Book").ToString()
                    box7.Text = dt.Rows(i)("eBook").ToString()
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
                    Dim box1 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(0).FindControl("Name"), TextBox)
                    Dim box2 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(1).FindControl("IC"), TextBox)
                    Dim box3 As DropDownList = DirectCast(gdAuthor.Rows(rowIndex).Cells(2).FindControl("Type"), DropDownList)
                    Dim box4 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(3).FindControl("Pecentage"), TextBox)
                    Dim box5 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(4).FindControl("PayTo"), TextBox)
                    Dim box6 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(5).FindControl("Book"), TextBox)
                    Dim box7 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(5).FindControl("eBook"), TextBox)
                    Dim box8 As TextBox = DirectCast(gdAuthor.Rows(rowIndex).Cells(5).FindControl("Advance"), TextBox)

                    drCurrentRow = dtCurrentTable.NewRow()
                    '  drCurrentRow("RowNumber") = i + 1
                    dtCurrentTable.Rows(i - 1)("Name") = box1.Text
                    dtCurrentTable.Rows(i - 1)("IC") = box2.Text
                    dtCurrentTable.Rows(i - 1)("Type") = box3.SelectedValue
                    dtCurrentTable.Rows(i - 1)("Pecentage") = box4.Text
                    dtCurrentTable.Rows(i - 1)("PayTo") = box5.Text
                    dtCurrentTable.Rows(i - 1)("Book") = box6.Text
                    dtCurrentTable.Rows(i - 1)("eBook") = box7.Text
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
        Dim IC As String
        Dim Name As String
        Dim PayTo As String
        If e.Row.RowType = DataControlRowType.DataRow Then
            ln = e.Row.FindControl("hlget")
            If Not (IsNothing(ln)) Then
                IC = e.Row.FindControl("IC").ClientID
                Name = e.Row.FindControl("Name").ClientID
                PayTo = e.Row.FindControl("PayTo").ClientID
                ln.NavigateUrl = "javascript:calendar_window=window.open('Authorlist.aspx?Name=" + Name + "&IC=" + IC & "&PayTo=" + PayTo + "','calendar','width=800,height=700,top=200,left=400');calendar_window.focus()"
            End If
        End If
    End Sub


    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click


        Dim ISBN As TextBox
        Dim DateStart As TextBox
        Dim DateEnd As TextBox
        Dim DateContract As TextBox

        ISBN = FormView1.FindControl("ISBNTextbox")
        DateStart = FormView1.FindControl("DateStartTextbox")
        DateEnd = FormView1.FindControl("DateEndTextbox")
        DateContract = FormView1.FindControl("DateContractTextBox")
        If Not IsNothing(ISBN) Then
            ClsAddUpdate.pDocNo = "NEW"
            ClsAddUpdate.pDocType = "CNT"
            ClsAddUpdate.ContractDate = DateContract.Text
            ClsAddUpdate.StartDate = DateEnd.Text
            ClsAddUpdate.EndDate = DateEnd.Text
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

        Dim ISBN As DropDownList
        Dim DateStart As TextBox
        Dim DateEnd As TextBox
        Dim DateContract As TextBox

        Dim i As Integer
        For i = 0 To gdAuthor.Rows.Count - 1
            gdAuthor.Rows(i).BackColor = Drawing.Color.White
        Next i

        ISBN = FormView1.FindControl("Dropdownlist2")
        DateStart = FormView1.FindControl("DateStartTextbox")
        DateEnd = FormView1.FindControl("DateEndTextbox")
        DateContract = FormView1.FindControl("DateContractTextBox")
        If Not IsNothing(ISBN) Then
            ClsAddUpdate.pDocNo = "NEW"
            ClsAddUpdate.pDocType = "CNT"
            ClsAddUpdate.ISBN = ISBN.SelectedValue
            ClsAddUpdate.ContractDate = DateContract.Text
            ClsAddUpdate.StartDate = DateStart.Text
            ClsAddUpdate.EndDate = DateEnd.Text
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
        Dim ISBN As String = Request.QueryString("ISBN")
        SQLQuery = "DELETE FROM infContract WHERE ISBN ='" & ISBN & "'; Delete FROM infTransAuthor WHERE ISBN='" & ISBN & "'"
        Dim Result As Boolean
        Result = Clss.ExecuteNonQuery(SQLQuery)
        If Result = False Then
            ShowPopUpMsg(Clss.oErrMsg)
        Else
            Response.Redirect("u_Contract.aspx")
        End If
    End Sub
End Class