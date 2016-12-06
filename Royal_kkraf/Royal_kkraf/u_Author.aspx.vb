Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Globalization.CultureInfo
Imports System.Threading
Imports System.Web.Security

Public Class u_Author
    Inherits System.Web.UI.Page

    Dim Query As String
    Dim Clss As New Clss
    Dim Result As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-CA")
        If Not Me.Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        End If

        If Not Page.IsPostBack Then

            ddlStatus.DataBind()
            ddlBankName.DataBind()
            ddlPaymentType.DataBind()
            ddlAuthorType.DataBind()

            If SortExp.Text = "" Then
                LoadGridAuthor("", "")
            Else
                LoadGridAuthor(SortExp.Text, "")
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

    Function LoadGridAuthor(ByVal SortField As String, ByVal SQuery As String) As Boolean
        Dim dT As DataTable
        Senarai.CurrentPageIndex = 0
        Query = "Select * From infAuthor " & SQuery & " Order by Name ASC"
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

    Private Sub Senarai_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Senarai.SelectedIndexChanged
        Dim code As Integer
        Senarai.CurrentPageIndex = 0
        code = Senarai.SelectedItem.Cells(1).Text
        Result = LoadDetailGridAuthor(code)
        If Result = True Then
            PanelDetail.Visible = True
            btnUpdate.Visible = True
            btnDelete.Visible = True
            PanelGrid.Visible = False
            btnSave.Visible = False
        Else
            PanelDetail.Visible = False
            btnUpdate.Visible = False
            btnDelete.Visible = False
            PanelGrid.Visible = True
            btnSave.Visible = True
        End If

    End Sub

    Function LoadDetailGridAuthor(id As Integer) As Boolean
        Query = "Select * From infAuthor WHERE ID =" & id & ""
        Result = Clss.ExecuteNonQuery_Author(Query)
        If Result = True Then
            Dim DateJoin As Object
            lblID.Text = Clss.oIDNo
            lblDocNo.Text = Clss.oDocNo
            txtName.Text = Clss.oName
            txtNickname.Text = Clss.oNickname
            txtIC.Text = Clss.oIC
            txtHPhone.Text = Clss.oHPhone
            txtFax.Text = Clss.oFax
            txtAddMailing.Text = Clss.oAddmailing
            txtAddPermanent.Text = Clss.oAddPermanent
            txtEmail.Text = Clss.oEmail

            DateJoin = Clss.oDateJoin
            If DateJoin Is DBNull.Value Or DateJoin = "" Then
                txtDateJoin.Text = ""
            Else
                If DateJoin = "01/01/1900 12:00:00 AM" Or DateJoin = "01/01/1900" Then
                    txtDateJoin.Text = ""
                Else
                    txtDateJoin.Text = Convert.ToDateTime(DateJoin).ToString("dd/MM/yyyy")
                End If
            End If

            txtWebsite.Text = Clss.oWebsite
            txtFacebook.Text = Clss.oFacebook
            txtTwitter.Text = Clss.oTwitter
            ddlStatus.SelectedValue = Clss.oStatus
            ddlAuthorType.SelectedValue = Clss.oAuthorType
            ddlPaymentType.SelectedValue = Clss.oPaymentType
            ddlBankName.SelectedValue = Clss.oBankName
            txtBankNoPayTo.Text = Clss.oBankNo
            Result = True
        Else
            ShowPopUpMsg("ERROR : Load Data" & Clss.oErrMsg & "")
            Result = False
        End If
        Return Result
    End Function


    Protected Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click

        PanelDetail.Visible = True
        PanelGrid.Visible = False
        btnCreate.Visible = True
        btnUpdate.Visible = False
        btnDelete.Visible = False
        btnSave.Visible = True
        ClearDetailTitles()

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        PanelDetail.Visible = False
        PanelGrid.Visible = True
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim SQLQuery As String
        Result = Clss.CheckupDocNo("DOCNO", "AUT", "NEW")
        If Result = True Then
            lblDocNo.Text = Clss.oDocNo
            SQLQuery = "INSERT INTO infAuthor (name, nickname, IC, HPhone, fax, address_mail, address_Permanent, address_email, DateJoin, website, facebook, twitter, Status, BankNo, BankName, PaymentType, AuthorType, DocNo) VALUES ('" & _
                TentukanAksaraCalit(txtName.Text) & "', '" & TentukanAksaraCalit(txtNickname.Text) & "', '" & TentukanAksaraCalit(txtIC.Text) & "', '" & TentukanAksaraCalit(txtHPhone.Text) & "', '" & TentukanAksaraCalit(txtFax.Text) & "', '" & TentukanAksaraCalit(txtAddMailing.Text) & "', '" & TentukanAksaraCalit(txtAddPermanent.Text) & "', '" & _
                TentukanAksaraCalit(txtEmail.Text) & "', CONVERT(DATETIME, '" & TentukanAksaraCalit(txtDateJoin.Text) & "', 103), '" & TentukanAksaraCalit(txtWebsite.Text) & "', '" & TentukanAksaraCalit(txtFacebook.Text) & "', '" & TentukanAksaraCalit(txtTwitter.Text) & "', '" & ddlStatus.SelectedValue & "', '" & TentukanAksaraCalit(txtBankNoPayTo.Text) & "', '" & _
                ddlBankName.SelectedValue & "', '" & ddlPaymentType.SelectedValue & "', '" & ddlAuthorType.SelectedValue & "', '" & lblDocNo.Text & "'); UPDATE ConfDocControl set Description='" & Clss.oConCurrNumber & "' where SetupName='DOCNO' and itemname='AUT'"
            Result = Clss.ExecuteNonQuery(SQLQuery)
            If Result = True Then
                ShowPopUpMsg("Succes : SAVE Data")
                LoadGridAuthor("", "")
                PanelDetail.Visible = False
                PanelGrid.Visible = True
            Else
                ShowPopUpMsg("Error : SAVE Data " & Clss.oErrMsg & "")
            End If
        End If
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim SQLQuery As String
        SQLQuery = "DELETE From infAuthor WHERE ID =" & lblID.Text & ""
        Result = Clss.ExecuteNonQuery(SQLQuery)
        If Result = True Then
            ShowPopUpMsg("Succes : DELETE Data")
            LoadGridAuthor("", "")
            PanelDetail.Visible = False
            PanelGrid.Visible = True
        Else
            ShowPopUpMsg("Error : DELETE Data " & Clss.oErrMsg & "")
        End If
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim SQLQuery As String
        SQLQuery = "UPDATE infAuthor SET name = '" & TentukanAksaraCalit(txtName.Text) & "', nickname = '" & TentukanAksaraCalit(txtNickname.Text) & "', IC = '" & TentukanAksaraCalit(txtIC.Text) & "', HPhone = '" & TentukanAksaraCalit(txtHPhone.Text) & "', fax = '" & TentukanAksaraCalit(txtFax.Text) & "', address_mail = '" & _
            TentukanAksaraCalit(txtAddMailing.Text) & "', address_Permanent = '" & TentukanAksaraCalit(txtAddPermanent.Text) & "', address_email = '" & TentukanAksaraCalit(txtEmail.Text) & "', DateJoin = CONVERT(DATETIME, '" & TentukanAksaraCalit(txtDateJoin.Text) & "', 103), website = '" & TentukanAksaraCalit(txtWebsite.Text) & "', facebook = '" & _
            TentukanAksaraCalit(txtFacebook.Text) & "', twitter = '" & TentukanAksaraCalit(txtTwitter.Text) & "', Status = '" & ddlStatus.SelectedValue & "', BankNo = '" & TentukanAksaraCalit(txtBankNoPayTo.Text) & "', BankName = '" & ddlBankName.SelectedValue & "', PaymentType = '" & _
            ddlPaymentType.SelectedValue & "', AuthorType = '" & ddlAuthorType.SelectedValue & "' WHERE (id = " & lblID.Text & ")"
        Result = Clss.ExecuteNonQuery(SQLQuery)
        If Result = True Then
            ShowPopUpMsg("Succes : UPDATE Data")
            LoadGridAuthor("", "")
            PanelDetail.Visible = False
            PanelGrid.Visible = True
        Else
            ShowPopUpMsg("Error : UPDATE Data " & Clss.oErrMsg & "")
        End If
    End Sub

    Private Sub ShowPopUpMsg(msg As String)
        Dim sb As New StringBuilder()
        sb.Append("alert('")
        sb.Append(msg.Replace(vbLf, "\n").Replace(vbCr, "").Replace("'", "\'"))
        sb.Append("');")
        ScriptManager.RegisterStartupScript(Me.Page, Me.[GetType](), "showalert", sb.ToString(), True)
    End Sub

    Sub ClearDetailTitles()
        lblID.Text = ""
        lblDocNo.Text = "NEW"
        txtName.Text = ""
        txtNickname.Text = ""
        txtIC.Text = ""
        txtHPhone.Text = ""
        txtFax.Text = ""
        txtAddMailing.Text = ""
        txtAddPermanent.Text = ""
        txtEmail.Text = ""
        txtDateJoin.Text = ""
        txtWebsite.Text = ""
        txtFacebook.Text = ""
        txtTwitter.Text = ""
        ddlStatus.DataBind()
        txtBankNoPayTo.Text = ""
        ddlBankName.DataBind()
        ddlPaymentType.DataBind()
        ddlAuthorType.DataBind()
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearDetailTitles()
    End Sub

    Function TentukanAksaraCalit(ByVal ayat As String) As String
        'On Local Error Resume Next
        Dim i As Integer
        Dim adaCalit As String
        Dim ayatbaru As String
        Dim aksara As String

        adaCalit = InStr(1, ayat, "'")

        If adaCalit > 0 Then
            ayatbaru = ""
            For i = 1 To Len(ayat)
                aksara = Mid$(ayat, i, 1)
                If aksara = "'" Then
                    ayatbaru = ayatbaru & "''"
                Else
                    ayatbaru = ayatbaru & aksara
                End If
            Next i

            TentukanAksaraCalit = ayatbaru
        Else
            TentukanAksaraCalit = ayat
        End If

    End Function

    Protected Sub iBtnSearch_Click(sender As Object, e As ImageClickEventArgs) Handles iBtnSearch.Click
        Dim Cond As String
        Cond = "WHERE Name like '%" & txtAuthorSearch.Text & "%' or Nickname like '%" & txtAuthorSearch.Text & "%' "
        LoadGridAuthor("", Cond)
    End Sub

End Class