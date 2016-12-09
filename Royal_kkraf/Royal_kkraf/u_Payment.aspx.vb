Imports System.Web.Security
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Globalization.CultureInfo
Imports System.Threading
Imports System.Configuration


Public Class u_Payment
    Inherits System.Web.UI.Page

    Dim Query As String
    Dim Clss As New Clss
    Dim Result As Boolean
    Dim Filter As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-CA")
        If Not Me.Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        End If

        Dim ISBN As String = Request.Form("ISBN")
        Dim Title As String = Request.Form("Title")


        If Not Page.IsPostBack Then
            ddlPaymentType.DataBind()

            If SortExp.Text = "" Then
                LoadGridPayment("", "")
            Else
                LoadGridPayment(SortExp.Text, "")
            End If
        Else

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

    Function LoadGridPayment(ByVal SortField As String, ByVal SQuery As String) As Boolean
        Dim dT As DataTable
        Senarai.CurrentPageIndex = 0
        Query = "Select distinct * From [infOthersPayment] " & SQuery & " Order by ContractNo, Author ASC "
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

    Function LoadGridPaymentDetail() As Boolean
        Dim dT As DataTable
        SenaraiPayment.CurrentPageIndex = 0
        Query = "Select distinct * From [infOthersPaymentDetail] WHERE DocNo='" & lblDocNo.Text & "' Order by PaymentDate DESC "
        dT = Clss.ExecuteDataTable(Query, "SenaraiPayment")
        If dT Is Nothing Then
            lblErrMsg.Text = String.Format("ERROR : Bind Data ({0})!", Clss.oErrMsg)
        ElseIf Not dT Is Nothing Then
            lblErrMsg.Text = ""
            SenaraiPayment.DataSource = dT
            SenaraiPayment.DataBind()
            ViewState.Add("SenaraiPayment", dT)
            dT.Dispose()
        End If
        Return 0
    End Function

    Private Sub iBtnSearch_Click(sender As Object, e As ImageClickEventArgs) Handles iBtnSearch.Click
        Filter = "WHERE " & ddlFilter.SelectedValue & " like '%" & txtSearch.Text & "%'"
        LoadGridPayment("", Filter)
    End Sub

    Protected Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        btnContract.Visible = True
        PanelDetail.Visible = True
        PanelGrid.Visible = False
        btnCreate.Visible = True
        btnUpdate.Visible = False
        btnDelete.Visible = False
        btnInsert.Visible = False
        btnSave.Visible = True
        ClearDetailPayment()
    End Sub

    Function ClearDetailPayment() As Boolean
        lblDate.Text = Today
        lblDocNo.Text = "NEW"
        txtContractNo.Value = ""
        txtTitle.Value = ""
        txtISBN.Value = ""
        txtAuthor.Value = ""
        txtAuthorIC.Value = ""
        txtPayto.Value = ""
        txtPaytoIC.Value = ""
        ddlPaymentType.DataBind()
        txtAmount.Text = 0
        txtNote.Text = ""
        Return 0
    End Function

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim PaymentDate As DateTime = Convert.ToDateTime(txtPaymentDate.Text)
        Dim TodayDate As DateTime = Convert.ToDateTime(lblDate.Text)

        Dim userId As Integer = 0
        Result = Clss.CheckupDocNo("DOCNO", "PAY", "NEW")
        If Result = True Then
            lblDocNo.Text = Clss.oDocNo
            Dim constr As String = ConfigurationManager.ConnectionStrings("RoyaltiesConn").ConnectionString
            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand("Insert_OtherPayment")
                    Using sda As New SqlDataAdapter()
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@Author", txtAuthor.Value.Trim())
                        cmd.Parameters.AddWithValue("@PayTo", txtPayto.Value.Trim())
                        cmd.Parameters.AddWithValue("@Title", txtTitle.Value.Trim())
                        cmd.Parameters.AddWithValue("@ISBN", txtISBN.Value.Trim())
                        cmd.Parameters.AddWithValue("@ContractNo", txtContractNo.Value.Trim())
                        cmd.Parameters.AddWithValue("@PaymentDate", PaymentDate)
                        cmd.Parameters.AddWithValue("@Value", txtAmount.Text.Trim())
                        cmd.Parameters.AddWithValue("@TypePayment", ddlPaymentType.SelectedItem.Text.Trim())
                        cmd.Parameters.AddWithValue("@DocNo", lblDocNo.Text.Trim())
                        cmd.Parameters.AddWithValue("@Date", TodayDate)
                        cmd.Parameters.AddWithValue("@Note", txtNote.Text.Trim())
                        cmd.Parameters.AddWithValue("@AuthorIC", txtAuthorIC.Value.Trim())
                        cmd.Parameters.AddWithValue("@PayToIC", txtPaytoIC.Value.Trim())
                        cmd.Parameters.AddWithValue("@CodePaymentType", ddlPaymentType.SelectedValue.Trim())
                        cmd.Parameters.AddWithValue("@CurNumber", Clss.oConCurrNumber.Trim())
                        cmd.Connection = con
                        con.Open()
                        userId = Convert.ToInt32(cmd.ExecuteScalar())
                        con.Close()
                    End Using
                End Using
                Select Case userId
                    Case -1
                        ShowPopUpMsg("Contract No Already Exists")
                    Case -2
                        ShowPopUpMsg("ISBN Already Exists")
                    Case Else
                        InsertDetails()
                        ShowPopUpMsg("SUCCESFUL!")
                End Select
            End Using
        End If

    End Sub

    Private Sub ShowPopUpMsg(msg As String)
        Dim sb As New StringBuilder()
        sb.Append("alert('")
        sb.Append(msg.Replace(vbLf, "\n").Replace(vbCr, "").Replace("'", "\'"))
        sb.Append("');")
        ScriptManager.RegisterStartupScript(Me.Page, Me.[GetType](), "showalert", sb.ToString(), True)
    End Sub

    Private Sub Senarai_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Senarai.SelectedIndexChanged
        Dim code As Integer
        Senarai.CurrentPageIndex = 0
        code = Senarai.SelectedItem.Cells(1).Text
        Result = LoadDetailGridPayment(code)
        If Result = True Then
            btnContract.Visible = False
            btnInsert.Visible = True
            PanelDetail.Visible = True
            btnUpdate.Visible = True
            btnDelete.Visible = True
            PanelGrid.Visible = False
            btnSave.Visible = False
            LoadGridPaymentDetail()
        Else
            PanelDetail.Visible = False
            btnUpdate.Visible = False
            btnDelete.Visible = False
            PanelGrid.Visible = True
            btnSave.Visible = True
        End If

    End Sub

    Function LoadDetailGridPayment(id As Integer) As Boolean
        Query = "Select * From infOthersPayment WHERE ID =" & id & ""
        Result = Clss.ExecuteNonQuery_OthersPayment(Query)
        If Result = True Then
            Dim DateDoc As Object
            Dim PaymentDate As Object
            lblID.Text = Clss.oIDNo
            lblDocNo.Text = Clss.oDocNo
            'txtTitle.Value = Clss.oTitle
            txtISBN.Value = Clss.oISBN
            txtAuthor.Value = Clss.oName
            txtAuthorIC.Value = Clss.oIC
            txtPayto.Value = Clss.oPayTo
            txtPaytoIC.Value = Clss.oPayToIC
            ddlPaymentType.SelectedValue = Clss.oPaymentType
            txtContractNo.Value = Clss.oContractNo
            txtAmount.Text = Convert.ToDouble(Clss.oAmount)
            txtNote.Text = Clss.oNota
            txtPaymentDate.Text = Clss.oDateJoin
            DateDoc = Clss.oDateStart
            If DateDoc Is DBNull.Value Or DateDoc = "" Then
                lblDate.Text = ""
            Else
                If DateDoc = "01/01/1900 12:00:00 AM" Or DateDoc = "01/01/1900" Then
                    lblDate.Text = ""
                Else
                    lblDate.Text = Convert.ToDateTime(DateDoc).ToString("dd/MM/yyyy")
                End If
            End If

            PaymentDate = Clss.oDateJoin
            If PaymentDate Is DBNull.Value Or PaymentDate = "" Then
                PaymentDate.Text = ""
            Else
                If PaymentDate = "01/01/1900 12:00:00 AM" Or PaymentDate = "01/01/1900" Then
                    PaymentDate.Text = ""
                Else
                    txtPaymentDate.Text = Convert.ToDateTime(PaymentDate).ToString("dd/MM/yyyy")
                End If
            End If

            Result = True
        Else
            ShowPopUpMsg("ERROR : Load Data" & Clss.oErrMsg & "")
            Result = False
        End If
        Return Result
    End Function

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim SQLQuery As String
        SQLQuery = "UPDATE infOthersPayment SET TypePayment='" & ddlPaymentType.SelectedItem.Text & "', CodePaymentType='" & ddlPaymentType.SelectedValue & "', Value='" & txtAmount.Text & "', Note='" & txtNote.Text & "' WHERE (id = " & lblID.Text & ")"
        Result = Clss.ExecuteNonQuery(SQLQuery)
        If Result = True Then
            ShowPopUpMsg("Succes : UPDATE Data")
            LoadGridPayment("", "")
            LoadGridPaymentDetail()
            PanelDetail.Visible = False
            PanelGrid.Visible = True
        Else
            ShowPopUpMsg("Error : UPDATE Data " & Clss.oErrMsg & "")
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim SQLQuery As String
        SQLQuery = "DELETE From infOthersPayment WHERE ID =" & lblID.Text & "; DELETE FROM infOthersPaymentDetail WHERE DocNo ='" & lblDocNo.Text & "'"
        Result = Clss.ExecuteNonQuery(SQLQuery)
        If Result = True Then
            ShowPopUpMsg("Succes : DELETE Data")
            LoadGridPayment("", "")
            PanelDetail.Visible = False
            PanelGrid.Visible = True
        Else
            ShowPopUpMsg("Error : DELETE Data " & Clss.oErrMsg & "")
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        PanelDetail.Visible = False
        PanelGrid.Visible = True
        ClearDetailPayment()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearDetailPayment()
    End Sub

    Private Sub InsertDetails()
        Dim PaymentDate As DateTime = Convert.ToDateTime(txtPaymentDate.Text)
        Dim TodayDate As DateTime = Convert.ToDateTime(lblDate.Text)

        Dim constr As String = ConfigurationManager.ConnectionStrings("RoyaltiesConn").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("Insert_OtherPaymentDetail")
                Using sda As New SqlDataAdapter()
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@Author", txtAuthor.Value.Trim())
                    cmd.Parameters.AddWithValue("@PayTo", txtPayto.Value.Trim())
                    cmd.Parameters.AddWithValue("@Title", txtTitle.Value.Trim())
                    cmd.Parameters.AddWithValue("@ISBN", txtISBN.Value.Trim())
                    cmd.Parameters.AddWithValue("@ContractNo", txtContractNo.Value.Trim())
                    cmd.Parameters.AddWithValue("@PaymentDate", PaymentDate)
                    cmd.Parameters.AddWithValue("@Value", txtAmount.Text.Trim())
                    cmd.Parameters.AddWithValue("@TypePayment", ddlPaymentType.SelectedItem.Text.Trim())
                    cmd.Parameters.AddWithValue("@DocNo", lblDocNo.Text.Trim())
                    cmd.Parameters.AddWithValue("@Date", TodayDate)
                    cmd.Parameters.AddWithValue("@Note", txtNote.Text.Trim())
                    cmd.Parameters.AddWithValue("@AuthorIC", txtAuthorIC.Value.Trim())
                    cmd.Parameters.AddWithValue("@PayToIC", txtPaytoIC.Value.Trim())
                    cmd.Parameters.AddWithValue("@CodePaymentType", ddlPaymentType.SelectedValue.Trim())
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteScalar()
                    con.Close()
                    ShowPopUpMsg("SUCCESFUL!")
                    LoadGridPaymentDetail()
                End Using
            End Using
        End Using
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        InsertDetails()
    End Sub

End Class