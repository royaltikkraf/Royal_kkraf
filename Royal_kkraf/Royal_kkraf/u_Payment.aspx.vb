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
            ddlPaymentType.DataBind()
            ddlAuthor.DataBind()
            ddlPayTo.DataBind()
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

    Private Sub iBtnSearch_Click(sender As Object, e As ImageClickEventArgs) Handles iBtnSearch.Click
        Filter = "WHERE " & ddlFilter.SelectedValue & " like '%" & txtSearch.Text & "%'"
        LoadGridPayment("", Filter)
    End Sub

    Protected Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        PanelDetail.Visible = True
        PanelGrid.Visible = False
        btnCreate.Visible = True
        btnUpdate.Visible = False
        btnDelete.Visible = False
        btnSave.Visible = True
        ClearDetailPayment()
    End Sub

    Function ClearDetailPayment() As Boolean
        lblDate.Text = Today
        lblDocNo.Text = "NEW"
        txtContNo.Text = ""
        ddlAuthor.DataBind()
        ddlPayTo.DataBind()
        ddlPaymentType.DataBind()
        txtAmount.Text = 0
        txtNote.Text = ""
        Return 0
    End Function

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim SQLQuery As String
        Result = Clss.CheckupDocNo("DOCNO", "PAY", "NEW")
        If Result = True Then
            lblDocNo.Text = Clss.oDocNo
            SQLQuery = "INSERT INTO infOthersPayment(Date, Author, PayTo, TypePayment, Value, Note, DocNo, ContractNo, AuthorIC, PayToIC, CodePaymentType)VALUES(convert(datetime,'" & _
                lblDate.Text & "',103), '" & ddlAuthor.SelectedItem.Text & "', '" & ddlPayTo.SelectedItem.Text & "', '" & ddlPaymentType.SelectedItem.Text & "', '" & _
                txtAmount.Text & "', '" & txtNote.Text & "', '" & lblDocNo.Text & "', '" & txtContNo.Text & "', '" & ddlAuthor.SelectedValue & "', '" & ddlPayTo.SelectedValue & "', '" & ddlPaymentType.SelectedValue & "'); UPDATE ConfDocControl set Description='" & Clss.oConCurrNumber & "' where SetupName='DOCNO' and itemname='PAY'"
            Result = Clss.ExecuteNonQuery(SQLQuery)
            If Result = True Then
                ShowPopUpMsg("Succes : SAVE Data")
                LoadGridPayment("", "")
                PanelDetail.Visible = False
                PanelGrid.Visible = True
            Else
                ShowPopUpMsg("Error : SAVE Data " & Clss.oErrMsg & "")
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

    Private Sub Senarai_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Senarai.SelectedIndexChanged
        Dim code As Integer
        Senarai.CurrentPageIndex = 0
        code = Senarai.SelectedItem.Cells(1).Text
        Result = LoadDetailGridPayment(code)
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

    Function LoadDetailGridPayment(id As Integer) As Boolean
        Query = "Select * From infOthersPayment WHERE ID =" & id & ""
        Result = Clss.ExecuteNonQuery_OthersPayment(Query)
        If Result = True Then
            Dim DateDoc As Object
            lblID.Text = Clss.oIDNo
            lblDocNo.Text = Clss.oDocNo
            ddlAuthor.SelectedValue = Clss.oIC
            ddlPayTo.SelectedValue = Clss.oPayTo
            ddlPaymentType.SelectedValue = Clss.oPaymentType
            txtContNo.Text = Clss.oContractNo
            txtAmount.Text = Clss.oAmount
            txtNote.Text = Clss.oNota

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


            Result = True
        Else
            ShowPopUpMsg("ERROR : Load Data" & Clss.oErrMsg & "")
            Result = False
        End If
        Return Result
    End Function

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim SQLQuery As String
        SQLQuery = "UPDATE infOthersPayment SET ContractNo='" & txtContNo.Text & "', Value='" & txtAmount.Text & "', Note='" & txtNote.Text & "' WHERE (id = " & lblID.Text & ")"
        Result = Clss.ExecuteNonQuery(SQLQuery)
        If Result = True Then
            ShowPopUpMsg("Succes : UPDATE Data")
            LoadGridPayment("", "")
            PanelDetail.Visible = False
            PanelGrid.Visible = True
        Else
            ShowPopUpMsg("Error : UPDATE Data " & Clss.oErrMsg & "")
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim SQLQuery As String
        SQLQuery = "DELETE From infOthersPayment WHERE ID =" & lblID.Text & ""
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
End Class