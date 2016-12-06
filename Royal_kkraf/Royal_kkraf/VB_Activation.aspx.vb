Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class VB_Activation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim constr As String = ConfigurationManager.ConnectionStrings("RoyaltiesConn").ConnectionString
            Dim activationCode As String = If(Not String.IsNullOrEmpty(Request.QueryString("ActivationCode")), Request.QueryString("ActivationCode"), Guid.Empty.ToString())
            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand("DELETE FROM UserActivation WHERE ActivationCode = @ActivationCode")
                    Using sda As New SqlDataAdapter()
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@ActivationCode", activationCode)
                        cmd.Connection = con
                        con.Open()
                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                        con.Close()
                        If rowsAffected = 1 Then
                            ltMessage.Text = "Activation successful."
                        Else
                            ltMessage.Text = "Invalid Activation code."
                        End If
                    End Using
                End Using
            End Using
        End If
    End Sub

End Class