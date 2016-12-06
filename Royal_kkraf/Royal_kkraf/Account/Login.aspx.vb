Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Security

Partial Public Class Login
    Inherits Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub ValidateUser(sender As Object, e As EventArgs)
        Dim userId As Integer = 0
        Dim constr As String = ConfigurationManager.ConnectionStrings("RoyaltiesConn").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("Validate_User")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Username", Login1.UserName)
                cmd.Parameters.AddWithValue("@Password", Login1.Password)
                cmd.Connection = con
                con.Open()
                userId = Convert.ToInt32(cmd.ExecuteScalar())
                con.Close()
            End Using
            Select Case userId
                Case -1
                    Login1.FailureText = "Username and/or password is incorrect."
                    Exit Select
                Case -2
                    Login1.FailureText = "Account has not been activated."
                    Exit Select
                Case Else
                    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet)
                    Exit Select
            End Select
        End Using
    End Sub

    Private Sub ShowPopUpMsg(msg As String)
        Dim sb As New StringBuilder()
        sb.Append("alert('")
        sb.Append(msg.Replace(vbLf, "\n").Replace(vbCr, "").Replace("'", "\'"))
        sb.Append("');")
        ScriptManager.RegisterStartupScript(Me.Page, Me.[GetType](), "showalert", sb.ToString(), True)
    End Sub
End Class
