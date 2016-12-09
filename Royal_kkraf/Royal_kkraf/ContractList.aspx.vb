Public Class ContractList
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
        If e.CommandName = "Select" Then
            DropDownList1.SelectedValue = GridView1.Rows(rowIndex).Cells(1).Text
            DropDownList2.SelectedValue = GridView1.Rows(rowIndex).Cells(2).Text
            DropDownList3.SelectedValue = GridView1.Rows(rowIndex).Cells(3).Text

        End If
    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound

    End Sub

    Private Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        DropDownList1.SelectedValue = GridView1.SelectedRow.Cells(1).Text
        DropDownList2.SelectedValue = GridView1.SelectedRow.Cells(2).Text
        DropDownList3.SelectedValue = GridView1.SelectedRow.Cells(3).Text

    End Sub

End Class