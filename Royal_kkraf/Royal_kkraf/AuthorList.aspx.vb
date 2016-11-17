Public Class AuthorList
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        hfIC.Value = GridView1.SelectedRow.Cells.Item(2).Text
        hfName.Value = GridView1.SelectedRow.Cells.Item(1).Text
        Dim ddlPayTo As DropDownList = DirectCast(GridView1.SelectedRow.Cells.Item(5).FindControl("ddlPayTo"), DropDownList)
        hfPayTo.Value = ddlPayTo.SelectedValue
    End Sub
End Class