Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Globalization.CultureInfo
Imports System.Threading

Public Class u_Product
    Inherits System.Web.UI.Page

    Dim Query As String
    Dim Clss As New Clss
    Dim Result As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-CA")
        If Not Page.IsPostBack Then

            ddlCategory.DataBind()
            ddlimprint.DataBind()
            ddlLanguage.DataBind()
            ddlStatus.DataBind()
            ddlSubCategory.DataBind()
            ddlProductType.DataBind()

            If SortExp.Text = "" Then
                LoadGridTitle("", "")
            Else
                LoadGridTitle(SortExp.Text, "")
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
        ViewState.Add("Senarai", dt)
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

    Function LoadGridTitle(ByVal SortField As String, ByVal SQuery As String) As Boolean
        Dim dT As DataTable
        Senarai.CurrentPageIndex = 0
        Query = "Select * From infTitles Order by Title"
        dT = Clss.ExecuteDataTable(Query, "Order")
        If dT Is Nothing Then
            Result = False
            lblErrMsg.Text = String.Format("ERROR : Bind Data ({0})!", Clss.oErrMsg)
        ElseIf Not dT Is Nothing Then
            lblErrMsg.Text = ""
            Senarai.DataSource = dT
            Senarai.DataBind()
            ViewState.Add("Senarai", dT)
            dT.Dispose()
            Result = True
        End If
        Return Result
    End Function

    Private Sub Senarai_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Senarai.SelectedIndexChanged
        Dim code As Integer
        Senarai.CurrentPageIndex = 0
        code = Senarai.SelectedItem.Cells(1).Text
        Result = LoadDetailTitles(code)
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

    Function LoadDetailTitles(id As Integer) As Boolean
        Query = "Select * From infTitles WHERE ID =" & id & ""
        Result = Clss.ExecuteNonQuery_Title(Query)
        If Result = True Then
            Dim PubDate As Object
            Dim FirstPrintDate As Object
            Dim CopyrightDate As Object

            lblID.Text = Clss.oIDNo
            txtItemCode.Text = Clss.oItemCode
            txtISBN.Text = Clss.oISBN
            ddlStatus.SelectedValue = Clss.oStatus
            ddlimprint.SelectedValue = Clss.oImprint
            ddlCategory.SelectedValue = Clss.oCategory
            ddlSubCategory.SelectedValue = Clss.oSubCategory
            ddlLanguage.SelectedValue = Clss.oLanguage
            txtTitle.Text = Clss.oTitle
            ddlProductType.SelectedValue = Clss.oProductType
            txtCoverPrice.Text = Clss.oCoverPrice
            txtCost.Text = Clss.oCost
            txtBarcode.Text = Clss.oBarcode

            PubDate = Clss.oPubDate
            If PubDate Is DBNull.Value Or PubDate = "" Then
                txtPubDate.Text = ""
            Else
                If PubDate = "01/01/1900 12:00:00 AM" Or PubDate = "01/01/1900" Then
                    txtPubDate.Text = ""
                Else
                    txtPubDate.Text = Convert.ToDateTime(PubDate).ToString("dd/MM/yyyy")
                End If
            End If

            FirstPrintDate = Clss.oFirstPrintDate
            If FirstPrintDate Is DBNull.Value Or FirstPrintDate = "" Then
                txtFirstPrintDate.Text = ""
            Else
                If FirstPrintDate = "01/01/1900 12:00:00 AM" Or FirstPrintDate = "01/01/1900" Then
                    txtFirstPrintDate.Text = ""
                Else
                    txtFirstPrintDate.Text = Convert.ToDateTime(FirstPrintDate).ToString("dd/MM/yyyy")
                End If
            End If

            CopyrightDate = Clss.oCopyrightDate
            If CopyrightDate Is DBNull.Value Or CopyrightDate = "" Then
                txtCopyrightDate.Text = ""
            Else
                If CopyrightDate = "01/01/1900 12:00:00 AM" Or CopyrightDate = "01/01/1900" Then
                    txtCopyrightDate.Text = ""
                Else
                    txtCopyrightDate.Text = Convert.ToDateTime(CopyrightDate).ToString("dd/MM/yyyy")
                End If
            End If

        Else

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

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim SQLQuery As String
        SQLQuery = "INSERT INTO infTitles (ItemCode, ISBN, PubDate, FirstPrintDate, Status, CopyrightDate, imprint, language, Catagory1, Catagory2, Title, ProductType, CoverPrice, Cost, Barcode) VALUES ('" & _
            TentukanAksaraCalit(txtItemCode.Text) & "', '" & TentukanAksaraCalit(txtISBN.Text) & "', CONVERT(DATETIME, '" & txtPubDate.Text & "', 103), CONVERT(DATETIME, '" & txtFirstPrintDate.Text & "', 103), '" & _
            ddlStatus.Text & "', CONVERT(DATETIME, '" & txtCopyrightDate.Text & "', 103), '" & ddlimprint.Text & "', '" & ddlLanguage.Text & "', '" & ddlCategory.Text & "', '" & _
            ddlSubCategory.Text & "', '" & TentukanAksaraCalit(txtTitle.Text) & "', '" & ddlProductType.SelectedValue & "', '" & txtCoverPrice.Text & "', '" & txtCost.Text & "', '" & txtBarcode.Text & "') "
        Result = Clss.ExecuteNonQuery(SQLQuery)
        If Result = True Then
            ShowPopUpMsg("Succes : SAVE Data")
            LoadGridTitle("", "")
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

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim SQLQuery As String
        SQLQuery = "DELETE From infTitles WHERE ID =" & lblID.Text & ""
        Result = Clss.ExecuteNonQuery(SQLQuery)
        If Result = True Then
            ShowPopUpMsg("Succes : DELETE Data")
            LoadGridTitle("", "")
            PanelDetail.Visible = False
            PanelGrid.Visible = True
        Else
            ShowPopUpMsg("Error : DELETE Data " & Clss.oErrMsg & "")
        End If
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim SQLQuery As String
        SQLQuery = "UPDATE infTitles SET ItemCode = '" & TentukanAksaraCalit(txtItemCode.Text) & "', ISBN = '" & TentukanAksaraCalit(txtISBN.Text) & "' , PubDate = CONVERT(DATETIME, '" & txtPubDate.Text & "', 103), FirstPrintDate = CONVERT(DATETIME, '" & txtFirstPrintDate.Text & "', 103), Status = '" & _
            ddlStatus.SelectedValue & "', CopyrightDate = CONVERT(DATETIME, '" & txtCopyrightDate.Text & "', 103), imprint = '" & ddlimprint.SelectedValue & "', language = '" & ddlLanguage.SelectedValue & "', Catagory1 = '" & ddlCategory.SelectedValue & "', Catagory2 = '" & _
            ddlSubCategory.SelectedValue & "', Title = '" & TentukanAksaraCalit(txtTitle.Text) & "', ProductType = '" & ddlProductType.SelectedValue & "', CoverPrice = '" & txtCoverPrice.Text & "', Cost = '" & txtCost.Text & "', Barcode = '" & txtBarcode.Text & "' WHERE (id = " & lblID.Text & ")"

        Result = Clss.ExecuteNonQuery(SQLQuery)
        If Result = True Then
            ShowPopUpMsg("Succes : UPDATE Data")
            LoadGridTitle("", "")
            PanelDetail.Visible = False
            PanelGrid.Visible = True
        Else
            ShowPopUpMsg("Error : UPDATE Data " & Clss.oErrMsg & "")
        End If
    End Sub

    Sub ClearDetailTitles()
        lblID.Text = ""
        txtItemCode.Text = ""
        txtISBN.Text = ""
        ddlStatus.DataBind()
        ddlimprint.DataBind()
        ddlCategory.DataBind()
        ddlSubCategory.DataBind()
        ddlLanguage.DataBind()
        txtTitle.Text = ""
        ddlProductType.DataBind()
        txtCoverPrice.Text = ""
        txtCost.Text = ""
        txtBarcode.Text = ""
        txtPubDate.Text = ""
        txtFirstPrintDate.Text = ""
        txtCopyrightDate.Text = ""
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
End Class