Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class Clss

    Dim ConnString As String = ConfigurationManager.ConnectionStrings("RoyaltiesConn").ConnectionString
    Dim Conn As New SqlConnection(ConnString)

    Dim Comm As New SqlCommand
    Dim dt As New DataTable
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dr As SqlDataReader

    Public pDocNo As String
    Public pDocType As String
    Public currno As String
    Dim SQLQuery As String
    Dim ErrMsg As String

    Public Property oErrMsg() As String
        Get
            oErrMsg = ErrMsg
        End Get
        Set(ByVal value As String)
            ErrMsg = value
        End Set
    End Property

    Dim IDNo As Integer
    Dim Name As String
    Dim NickName As String
    Dim IC As String
    Dim HPhone As String
    Dim Fax As String
    Dim addMailing As String
    Dim addPermanent As String
    Dim eMail As String
    Dim DateJoin As String
    Dim WebSite As String
    Dim Facebook As String
    Dim Twitter As String
    Dim Status As String
    Dim BankNo As String
    Dim BankName As String
    Dim PaymentType As String
    Dim AuthorType As String
    Dim PayTo As String


    Public Property oIDNo() As Integer
        Get
            oIDNo = IDNo
        End Get
        Set(ByVal value As Integer)
            IDNo = value
        End Set
    End Property

    Public Property oName() As String
        Get
            oName = Name
        End Get
        Set(ByVal value As String)
            Name = value
        End Set
    End Property

    Public Property oNickname() As String
        Get
            oNickname = NickName
        End Get
        Set(ByVal value As String)
            NickName = value
        End Set
    End Property

    Public Property oIC() As String
        Get
            oIC = IC
        End Get
        Set(ByVal value As String)
            IC = value
        End Set
    End Property

    Public Property oHPhone() As String
        Get
            oHPhone = HPhone
        End Get
        Set(ByVal value As String)
            HPhone = value
        End Set
    End Property

    Public Property oFax() As String
        Get
            oFax = Fax
        End Get
        Set(ByVal value As String)
            Fax = value
        End Set
    End Property

    Public Property oAddmailing() As String
        Get
            oAddmailing = addMailing
        End Get
        Set(ByVal value As String)
            addMailing = value
        End Set
    End Property

    Public Property oAddPermanent() As String
        Get
            oAddPermanent = addPermanent
        End Get
        Set(ByVal value As String)
            addPermanent = value
        End Set
    End Property

    Public Property oEmail() As String
        Get
            oEmail = eMail
        End Get
        Set(ByVal value As String)
            eMail = value
        End Set
    End Property

    Public Property oDateJoin() As String
        Get
            oDateJoin = DateJoin
        End Get
        Set(ByVal value As String)
            DateJoin = value
        End Set
    End Property

    Public Property oWebsite() As String
        Get
            oWebsite = WebSite
        End Get
        Set(ByVal value As String)
            WebSite = value
        End Set
    End Property

    Public Property oFacebook() As String
        Get
            oFacebook = Facebook
        End Get
        Set(ByVal value As String)
            Facebook = value
        End Set
    End Property

    Public Property oTwitter() As String
        Get
            oTwitter = Twitter
        End Get
        Set(ByVal value As String)
            Twitter = value
        End Set
    End Property

    Public Property oStatus() As String
        Get
            oStatus = Status
        End Get
        Set(ByVal value As String)
            Status = value
        End Set
    End Property

    Public Property oBankNo() As String
        Get
            oBankNo = BankNo
        End Get
        Set(ByVal value As String)
            BankNo = value
        End Set
    End Property

    Public Property oBankName() As String
        Get
            oBankName = BankName
        End Get
        Set(ByVal value As String)
            BankName = value
        End Set
    End Property

    Public Property oPaymentType() As String
        Get
            oPaymentType = PaymentType
        End Get
        Set(ByVal value As String)
            PaymentType = value
        End Set
    End Property

    Public Property oAuthorType() As String
        Get
            oAuthorType = AuthorType
        End Get
        Set(ByVal value As String)
            AuthorType = value
        End Set
    End Property

    Public Property oPayTo() As String
        Get
            oPayTo = PayTo
        End Get
        Set(ByVal value As String)
            PayTo = value
        End Set
    End Property

    Dim ItemCode As String
    Dim Title As String
    Dim ISBN As String
    Dim Imprint As String
    Dim Language As String
    Dim Category As String
    Dim SubCategory As String
    Dim PubDate As String
    Dim FirstPrintDate As String
    Dim CopyrightDate As String
    Dim ProductType As String
    Dim CoverPrice As String
    Dim Cost As String
    Dim Barcode As String


    Public Property oItemCode() As String
        Get
            oItemCode = ItemCode
        End Get
        Set(ByVal value As String)
            ItemCode = value
        End Set
    End Property

    Public Property oTitle() As String
        Get
            oTitle = Title
        End Get
        Set(ByVal value As String)
            Title = value
        End Set
    End Property

    Public Property oISBN() As String
        Get
            oISBN = ISBN
        End Get
        Set(ByVal value As String)
            ISBN = value
        End Set
    End Property

    Public Property oImprint() As String
        Get
            oImprint = Imprint
        End Get
        Set(ByVal value As String)
            Imprint = value
        End Set
    End Property

    Public Property oLanguage() As String
        Get
            oLanguage = Language
        End Get
        Set(ByVal value As String)
            Language = value
        End Set
    End Property

    Public Property oCategory() As String
        Get
            oCategory = Category
        End Get
        Set(ByVal value As String)
            Category = value
        End Set
    End Property

    Public Property oSubCategory() As String
        Get
            oSubCategory = SubCategory
        End Get
        Set(ByVal value As String)
            SubCategory = value
        End Set
    End Property

    Public Property oPubDate() As String
        Get
            oPubDate = PubDate
        End Get
        Set(ByVal value As String)
            PubDate = value
        End Set
    End Property

    Public Property oFirstPrintDate() As String
        Get
            oFirstPrintDate = FirstPrintDate
        End Get
        Set(ByVal value As String)
            FirstPrintDate = value
        End Set
    End Property

    Public Property oCopyrightDate() As String
        Get
            oCopyrightDate = CopyrightDate
        End Get
        Set(ByVal value As String)
            CopyrightDate = value
        End Set
    End Property

    Public Property oProductType() As String
        Get
            oProductType = ProductType
        End Get
        Set(ByVal value As String)
            ProductType = value
        End Set
    End Property

    Public Property oCoverPrice() As String
        Get
            oCoverPrice = CoverPrice
        End Get
        Set(ByVal value As String)
            CoverPrice = value
        End Set
    End Property

    Public Property oCost() As String
        Get
            oCost = Cost
        End Get
        Set(ByVal value As String)
            Cost = value
        End Set
    End Property

    Public Property oBarcode() As String
        Get
            oBarcode = Barcode
        End Get
        Set(ByVal value As String)
            Barcode = value
        End Set
    End Property

    Dim SalesDate As String
    Dim InvoiceNo As String
    Dim CustomerCode As String
    Dim CustomerName As String
    Dim SalesType As String
    Dim EntryType As String
    Dim Qty As String
    Dim RetailPrice As String
    Dim Discount As String
    Dim Channeltype As String

    Public Property oSalesDate() As String
        Get
            oSalesDate = SalesDate
        End Get
        Set(ByVal value As String)
            SalesDate = value
        End Set
    End Property

    Public Property oInvoiceNo() As String
        Get
            oInvoiceNo = InvoiceNo
        End Get
        Set(ByVal value As String)
            InvoiceNo = value
        End Set
    End Property

    Public Property oCustomerCode() As String
        Get
            oCustomerCode = CustomerCode
        End Get
        Set(ByVal value As String)
            CustomerCode = value
        End Set
    End Property

    Public Property oCustomerName() As String
        Get
            oCustomerName = CustomerName
        End Get
        Set(ByVal value As String)
            CustomerName = value
        End Set
    End Property

    Public Property oSalesType() As String
        Get
            oSalesType = SalesType
        End Get
        Set(ByVal value As String)
            SalesType = value
        End Set
    End Property

    Public Property oEntryType() As String
        Get
            oEntryType = EntryType
        End Get
        Set(ByVal value As String)
            EntryType = value
        End Set
    End Property

    Public Property oQty() As String
        Get
            oQty = Qty
        End Get
        Set(ByVal value As String)
            Qty = value
        End Set
    End Property

    Public Property oRetailPrice() As String
        Get
            oRetailPrice = RetailPrice
        End Get
        Set(ByVal value As String)
            RetailPrice = value
        End Set
    End Property

    Public Property oDiscount() As String
        Get
            oDiscount = Discount
        End Get
        Set(ByVal value As String)
            Discount = value
        End Set
    End Property

    Public Property oChanneltype() As String
        Get
            oChanneltype = Channeltype
        End Get
        Set(ByVal value As String)
            Channeltype = value
        End Set
    End Property

    Dim DateStart As String
    Dim DateEnd As String
    Dim DateContract As String
    Dim ContractNo As String


    Public Property oDateStart() As String
        Get
            oDateStart = DateStart
        End Get
        Set(ByVal value As String)
            DateStart = value
        End Set
    End Property

    Public Property oDateEnd() As String
        Get
            oDateEnd = DateEnd
        End Get
        Set(ByVal value As String)
            DateEnd = value
        End Set
    End Property

    Public Property oDateContract() As String
        Get
            oDateContract = DateContract
        End Get
        Set(ByVal value As String)
            DateContract = value
        End Set
    End Property

    Public Property oContractNo() As String
        Get
            oContractNo = ContractNo
        End Get
        Set(ByVal value As String)
            ContractNo = value
        End Set
    End Property

    Function ExecuteNonQuery(ByVal Query) As Boolean
        Dim result As Boolean
        If Conn.State = ConnectionState.Closed Then Conn.Open()
        Comm = New SqlCommand(Query, Conn)
        Try
            Comm.ExecuteNonQuery()
            result = True
        Catch ex As Exception
            ErrMsg = ex.Message
            result = False
        End Try
        Comm.Dispose()
        Return result
    End Function

    Function ExecuteNonQuery_Read(ByVal Query) As Boolean
        Dim result As Boolean
        If Conn.State = ConnectionState.Closed Then Conn.Open()
        Dim comm As New SqlCommand(Query, Conn)
        Try
            dr = comm.ExecuteReader()
            If dr.HasRows Then
                result = True
            End If
        Catch ex As Exception
            ErrMsg = ex.Message
            result = False
        End Try
        dr.Close()
        Return result
    End Function

    Function ExecuteDataTable(ByVal Query As String, ByVal Contains As Object) As DataTable
        Dim result As DataTable = Nothing
        'dr.Close()
        If Conn.State = ConnectionState.Closed Then Conn.Open()
        Try
            da = New SqlDataAdapter(Query, Conn)
            da.Fill(ds, Contains)
            result = ds.Tables(Contains)
        Catch ex As Exception
            ErrMsg = ex.Message
        End Try
        Return result
    End Function


    Function ExecuteNonQuery_Author(ByVal Query) As Boolean
        Dim result As Boolean
        If Conn.State = ConnectionState.Closed Then Conn.Open()
        Dim comm As New SqlCommand(Query, Conn)
        Try
            dr = comm.ExecuteReader()
            If dr.Read Then
                IDNo = dr(0).ToString
                Name = dr(1).ToString
                NickName = dr(2).ToString
                IC = dr(3).ToString
                HPhone = dr(4).ToString
                Fax = dr(5).ToString
                addMailing = dr(6).ToString
                addPermanent = dr(7).ToString
                eMail = dr(8).ToString
                DateJoin = dr(9).ToString
                WebSite = dr(10).ToString
                Facebook = dr(11).ToString
                Twitter = dr(12).ToString
                Status = dr(13).ToString
                BankNo = dr(14).ToString
                BankName = dr(15).ToString
                PaymentType = dr(16).ToString
                AuthorType = dr(17).ToString
                result = True
            ElseIf Not dr.Read Then

            End If
        Catch ex As Exception
            ErrMsg = ex.Message
            result = False
        End Try
        dr.Close()
        Return result
    End Function

    Function ExecuteNonQuery_Title(ByVal Query) As Boolean
        Dim result As Boolean
        If Conn.State = ConnectionState.Closed Then Conn.Open()
        Dim comm As New SqlCommand(Query, Conn)
        Try
            dr = comm.ExecuteReader()
            If dr.Read Then
                IDNo = dr(0).ToString
                ItemCode = dr(1).ToString
                ISBN = dr(2).ToString
                PubDate = dr(3).ToString
                FirstPrintDate = dr(4).ToString
                Status = dr(5).ToString
                CopyrightDate = dr(6).ToString
                Imprint = dr(7).ToString
                Language = dr(8).ToString
                Category = dr(9).ToString
                SubCategory = dr(10).ToString
                Title = dr(11).ToString
                ProductType = dr(12).ToString
                CoverPrice = dr(13).ToString
                Cost = dr(14).ToString
                Barcode = dr(15).ToString

                result = True
            ElseIf Not dr.Read Then

            End If
        Catch ex As Exception
            ErrMsg = ex.Message
            result = False
        End Try
        dr.Close()
        Return result
    End Function

    Function ExecuteNonQuery_Sales(ByVal Query) As Boolean
        Dim result As Boolean
        If Conn.State = ConnectionState.Closed Then Conn.Open()
        Dim comm As New SqlCommand(Query, Conn)
        Try
            dr = comm.ExecuteReader()
            If dr.Read Then
                IDNo = dr(0).ToString
                SalesDate = dr(1).ToString
                InvoiceNo = dr(2).ToString
                ISBN = dr(3).ToString
                ItemCode = dr(4).ToString
                Title = dr(5).ToString
                CustomerCode = dr(6).ToString
                CustomerName = dr(7).ToString
                SalesType = dr(8).ToString
                EntryType = dr(9).ToString
                Qty = dr(10).ToString
                RetailPrice = dr(11).ToString
                Discount = dr(12).ToString
                Channeltype = dr(13).ToString

                result = True
            ElseIf Not dr.Read Then

            End If
        Catch ex As Exception
            ErrMsg = ex.Message
            result = False
        End Try
        dr.Close()
        Return result
    End Function

    Function ExecuteNonQuery_Contract(ByVal Query) As Boolean
        Dim result As Boolean
        If Conn.State = ConnectionState.Closed Then Conn.Open()
        Dim comm As New SqlCommand(Query, Conn)
        Try
            dr = comm.ExecuteReader()
            If dr.Read Then
                'Imprint = dr("imprint").ToString
                ItemCode = dr("ItemCode").ToString
                ISBN = dr("ISBN").ToString
                'Title = dr("Title").ToString
                'Category = dr("Catagory1").ToString
                'SubCategory = dr("Catagory2").ToString
                'CoverPrice = dr("CoverPrice").ToString
                'PubDate = dr("PubDate").ToString
                'Status = dr("Status").ToString
                If dr("id").ToString Is DBNull.Value Or dr("id").ToString = "" Then
                    IDNo = 0
                Else
                    IDNo = dr("id").ToString
                End If

                DateStart = dr("DateStart").ToString
                DateEnd = dr("DateEnd").ToString
                DateContract = dr("DateContract").ToString
                IC = dr("AuthorIC").ToString
                result = True
            ElseIf Not dr.Read Then

            End If
        Catch ex As Exception
            ErrMsg = ex.Message
            result = False
        End Try
        'dr.Close()
        Return result
    End Function

    Function ExecuteNonQuery_AuthorPayment(ByVal Query) As Boolean
        Dim result As Boolean
        If Conn.State = ConnectionState.Closed Then Conn.Open()
        Dim comm As New SqlCommand(Query, Conn)
        Try
            dr = comm.ExecuteReader()
            If dr.Read Then
                ContractNo = dr("ContractNo").ToString
                ItemCode = dr("ItemCode").ToString
                ISBN = dr("ISBN").ToString
                Name = dr("AuthorName").ToString
                PayTo = dr("PayTo").ToString
                If dr("id").ToString Is DBNull.Value Or dr("id").ToString = "" Then
                    IDNo = 0
                Else
                    IDNo = dr("id").ToString
                End If
                IC = dr("IC").ToString
                result = True
            ElseIf Not dr.Read Then

            End If
        Catch ex As Exception
            ErrMsg = ex.Message
            result = False
        End Try
        'dr.Close()
        Return result
    End Function

    Function CheckupDocNo(Type, Val) As Boolean
        If UCase(pDocNo) = "NEW" Then
            If setdocno("DOCNO", pDocType) Then
                pDocNo = pDocNo
            End If
        End If

        If checkexist(pDocNo, "pdocno") Then
            ErrMsg = "Doc No Already Exist"
            Return False
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
                ErrMsg = "Maintenance DocNo Does Not Exist"
                ret = False
            End If


            dr.Close()
            comm.Dispose()

            Return ret
        Catch ex As Exception
            dr.Close()
            comm.Dispose()
            ErrMsg = ex.Message
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

    Function checkexist(ByVal nil As String, ByVal jenis As String) As Boolean
        Dim ret As Boolean
        Try
            Select Case jenis
                Case "pdocno"
                    SQLQuery = "select ContractNo from infContract where ContractNo='" & nil & "'"
            End Select
            Comm = New SqlCommand(SQLQuery, Conn)
            If conn.State = ConnectionState.Closed Then conn.Open()
            dr = comm.ExecuteReader
            If dr.Read Then
                ret = True
            Else
                ret = False
            End If
            dr.Close()
            comm.Dispose()
            Return ret
        Catch ex As Exception
            dr.Close()
            comm.Dispose()
            ErrMsg = ex.Message
            Return False
        End Try
    End Function
End Class
