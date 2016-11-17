Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class AddUpdate

    Dim ConnString As String = ConfigurationManager.ConnectionStrings("RoyaltiesConn").ConnectionString
    Dim Conn As New SqlConnection(ConnString)
    Dim Trans As SqlTransaction
    Dim Comm As SqlCommand
    Dim dr As SqlDataReader
    Dim ds As DataSet
    Dim da As SqlDataAdapter
    Public Rectable As DataTable
    Public getresultdata As DataTable

    Dim SQLQuery As String
    Public RetMsg As String
    Public BilRow As Integer
    Public currno As String
    Public ISBN As String
    Public ContractDate As String
    Public StartDate As String
    Public EndDate As String
    Public indxNum As Integer
    Public pDocNo As String
    Public pDocType As String

    Public Name As String
    Public IC As String
    Public TypeP As String
    Public Pecentage As Integer
    Public PayTo As String
    Public Book As Integer
    Public eBook As Integer
    Public Advance As Integer



    Function savestocktransfer(Type As String) As Boolean
        Try
            'If Not checktablelocation(Rectable) Then
            '    RetMsg = "Location Error.Other Item Already Register or Location Doesn't Exist"
            '    Return False
            '    Exit Function
            'End If
            If UCase(pDocNo) = "NEW" Then
                If setdocno("DOCNO", pDocType) Then
                    pDocNo = pDocNo
                End If
            End If

            If type = "Create" Then
                SQLQuery = "INSERT INTO infContract(ISBN, DateStart, DateEnd, DateContract) Values ('" & _
                    ISBN & "', Convert(Datetime,'" & StartDate & "',103), Convert(Datetime,'" & EndDate & "',103), Convert(Datetime,'" & ContractDate & "',103))"
            ElseIf type = "Edit" Then
                SQLQuery = ""
            End If

            If Conn.State = ConnectionState.Closed Then Conn.Open()

            Trans = Conn.BeginTransaction("pinsertrec")

            Comm = New SqlCommand(SQLQuery, Conn)

            Comm.Transaction = Trans
            Comm.ExecuteNonQuery()

            For Each row As DataRow In Rectable.Rows
                Name = row.Item("Name").ToString
                If Name <> "" Then
                    IC = row.Item("IC").ToString
                    TypeP = row.Item("Type").ToString
                    Pecentage = row.Item("Pecentage")
                    PayTo = row.Item("PayTo").ToString
                    Book = row.Item("Book")
                    eBook = row.Item("eBook")
                    Advance = row.Item("Advance")

                    SQLQuery = "INSERT INTO InfTransAuthor(AuthorName, IC, ISBN, Type, Pecentage, PayTo) VALUES ('" & _
                        Name & "', '" & IC & "', '" & ISBN & "', '" & TypeP & "', " & Pecentage & ", '" & PayTo & "')"
                    Comm.CommandText = SQLQuery
                    Comm.ExecuteNonQuery()
                End If
            Next

            'SQLQuery = "update ConfDocControl set Description='" & currno & "' where SetupName='DOCNO' and itemname='" & pDocType & "'"
            'Comm.CommandText = SQLQuery
            'Comm.ExecuteNonQuery()
            'RetMsg = "Record Insert Successfully"
            Trans.Commit()

            Return True
        Catch ex As Exception
            Try
                Trans.Rollback()

            Catch ex2 As Exception
                ' This catch block will handle any errors that may have occurred
                ' on the server that would cause the rollback to fail, such as
                ' a closed connection.
                Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
                Console.WriteLine("  Message: {0}", ex2.Message)
            End Try
            RetMsg = ex.Message
            Return False
        End Try

    End Function

    Function getresult(ByVal sql As String) As Boolean
        Try

            Dim comm = New SqlCommand(sql, Conn)

            If Conn.State = ConnectionState.Closed Then Conn.Open()

            Dim ds = New DataSet
            Dim da = New SqlDataAdapter
            da.SelectCommand = comm
            da.Fill(ds, "getresult")

            getresultdata = ds.Tables(0)
            ds.Dispose()
            comm.Dispose()

            da.Dispose()
            Return True

        Catch ex As Exception
            RetMsg = ex.Message
            Return False
        End Try


    End Function

    Function locexist(ByVal loc As String) As Boolean

        Try

            If getresult("select ic from infTransAuthor where IC='" & loc & "'") Then
                If getresultdata.Rows.Count > 0 Then
                    Return True
                Else
                    If Trim(loc) = "" Then
                        Return True
                    Else
                        Return False
                    End If

                End If

            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Function locexistClash(ByVal loc As String, ByVal itemcode As String) As Boolean
        Try

            If getresult("select itemcode from ras_bay where (locationidalt='" & loc & "' and ITEMCODE IS NULL) OR (locationidalt='" & loc & "' AND itemcode='') or (locationidalt='" & loc & "' AND itemcode='" & itemcode & "') OR  (locationidalt='" & loc & "' AND QTY=0 )") Then
                If getresultdata.Rows.Count > 0 Then
                    Return True
                Else
                    If Trim(loc) = "" Then
                        Return True
                    Else
                        Return False
                    End If

                End If
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Function checktablelocation(ByVal dt As DataTable) As Boolean
        Dim nil As Boolean = True
        Dim i As Integer = 0
        For Each row As DataRow In dt.Rows
            If Not row.Item(0).ToString = "" Then
                If locexist(row.Item("IC")) Then
                    If locexistClash(row.Item("IC"), row.Item("Name")) Then
                        ' Return True
                    Else
                        BilRow = i
                        Return False
                    End If

                Else
                    BilRow = i
                    Return False
                End If
                i = i + 1
            End If
        Next
        Return True
    End Function

    Function TentukanAksaraCalit(ByVal ayat As String) As String

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

    Function setdocno(ByVal jenis As String, ByVal nilai As String) As Boolean
        '  Dim nenilai As String
        '  Dim curnilai As String
        Dim ret As Boolean
        Try
            Select Case jenis
                Case "DOCNO"
                    SQLQuery = "select description from ConfDocControl where setupname='" & jenis & "' and itemname='" & nilai & "'"

            End Select
            Comm = New SqlCommand(SQLQuery, Conn)
            If conn.State = ConnectionState.Closed Then conn.Open()
            dr = comm.ExecuteReader
            If dr.Read Then
                '   curnilai = dr.Item(0).ToString
                pdocno = nilai + "-" + putdocno(dr.Item(0).ToString)
                ret = True
            Else
                RetMsg = "Maintenance DocNo Does Not Exist"
                ret = False
            End If


            dr.Close()
            comm.Dispose()

            Return ret
        Catch ex As Exception
            dr.Close()
            comm.Dispose()
            RetMsg = ex.Message
            Return False
        End Try


    End Function

    Function putdocno(ByVal nil As String) As String
        nil = Trim(Str(Val(nil) + 1))
        currno = nil
        Select Case Len(nil)
            Case 1
                Return "00000" + nil
            Case 2
                Return "0000" + nil
            Case 3
                Return "000" + nil
            Case 4
                Return "00" + nil
            Case 5
                Return "0" + nil
        End Select
    End Function
End Class
