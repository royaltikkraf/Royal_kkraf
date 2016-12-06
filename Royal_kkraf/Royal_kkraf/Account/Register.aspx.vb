Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Net


Partial Public Class Register
    Inherits Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub RegisterUser(sender As Object, e As EventArgs)
        Dim userId As Integer = 0
        Dim constr As String = ConfigurationManager.ConnectionStrings("RoyaltiesConn").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("Insert_User")
                Using sda As New SqlDataAdapter()
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim())
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim())
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
                    cmd.Connection = con
                    con.Open()
                    userId = Convert.ToInt32(cmd.ExecuteScalar())
                    con.Close()
                End Using
            End Using
            Dim message As String = String.Empty
            Select Case userId
                Case -1
                    message = "Username already exists.\nPlease choose a different username."
                    Exit Select
                Case -2
                    message = "Supplied email address has already been used."
                    Exit Select
                Case Else
                    message = "Registration successful. Activation email has been sent."
                    SendActivationEmail(userId)
                    Exit Select
            End Select
            ClientScript.RegisterStartupScript([GetType](), "alert", (Convert.ToString("alert('") & message) + "');", True)
        End Using
    End Sub

    Private Sub SendActivationEmail(userId As Integer)
        Dim constr As String = ConfigurationManager.ConnectionStrings("RoyaltiesConn").ConnectionString
        Dim activationCode As String = Guid.NewGuid().ToString()
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("INSERT INTO UserActivation VALUES(@UserId, @ActivationCode)")
                Using sda As New SqlDataAdapter()
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@UserId", userId)
                    cmd.Parameters.AddWithValue("@ActivationCode", activationCode)
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        End Using
        Using mm As New MailMessage("sender@gmail.com", txtEmail.Text)
            mm.Subject = "Account Activation"
            Dim body As String = "Hello " + txtUsername.Text.Trim() + ","
            body += "<br /><br />Please click the following link to activate your account"
            body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("Account/Register", Convert.ToString("VB_Activation.aspx?ActivationCode=") & activationCode) + "'>Click here to activate your account.</a>"
            body += "<br /><br />Thanks"
            mm.Body = body
            mm.IsBodyHtml = True
            Dim smtp As New SmtpClient()
            smtp.Host = "smtp.gmail.com"
            smtp.EnableSsl = True
            Dim NetworkCred As New NetworkCredential("apps.test.3110@gmail.com", "0129322139")
            smtp.UseDefaultCredentials = True
            smtp.Credentials = NetworkCred
            smtp.Port = 587
            smtp.Send(mm)
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

