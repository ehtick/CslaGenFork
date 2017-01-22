'  This file was generated by CSLA Object Generator - CslaGenFork v4.5
'
' Filename:    Doc
' ObjectType:  Doc
' CSLAType:    EditableRoot

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports DocStore.Business.Util
Imports Csla.Rules
Imports Csla.Rules.CommonRules
Imports CslaGenFork.Rules.AuthorizationRules
Imports CslaGenFork.Rules.DateRules
Imports CslaGenFork.Rules.TransformationRules
Imports DocStore.Business.Circulations
Imports DocStore.Business.Security
Imports System.Collections.Generic
Imports UsingLibrary

Namespace DocStore.Business

    ''' <summary>
    ''' Doc (editable root object).<br/>
    ''' This is a generated base class of <see cref="Doc"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class contains two child collections:<br/>
    ''' - <see cref="Folders"/> of type <see cref="DocFolderColl"/> (M:M relation to <see cref="Folder"/>)<br/>
    ''' - <see cref="Circulations"/> of type <see cref="DocCircColl"/> (1:M relation to <see cref="DocCirc"/>)
    ''' </remarks>
    <Serializable()>
    Partial Public Class Doc
    Inherits BusinessBaseDoc(Of Doc)
        Implements IHaveInterface, IHaveGenericInterface(Of Doc)

        #Region " Static Fields "

            Private Shared _lastID As Integer

        #End Region

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="DocID"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly DocIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.DocID, "Doc ID")
        ''' <summary>
        ''' Gets or sets the Document ID.
        ''' </summary>
        ''' <value>The Doc ID.</value>
        Public Property DocID As Integer
            Get
                Return GetProperty(DocIDProperty)
            End Get
            Private Set(ByVal value As Integer)
                SetProperty(DocIDProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocClassID"/> property.
        ''' </summary>
        Public Shared ReadOnly DocClassIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.DocClassID, "Doc Class ID")
        ''' <summary>
        ''' Gets or sets the Document Class ID.
        ''' </summary>
        ''' <value>The Doc Class ID.</value>
        Public Property DocClassID As Integer
            Get
                Return GetProperty(DocClassIDProperty)
            End Get
            Set(ByVal value As Integer)
                SetProperty(DocClassIDProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocTypeID"/> property.
        ''' </summary>
        Public Shared ReadOnly DocTypeIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.DocTypeID, "Doc Type ID")
        ''' <summary>
        ''' Gets or sets the Document Type ID.
        ''' </summary>
        ''' <value>The Doc Type ID.</value>
        Public Property DocTypeID As Integer
            Get
                Return GetProperty(DocTypeIDProperty)
            End Get
            Set(ByVal value As Integer)
                SetProperty(DocTypeIDProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="SenderID"/> property.
        ''' </summary>
        Public Shared ReadOnly SenderIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.SenderID, "Sender ID")
        ''' <summary>
        ''' Gets or sets the Entity ID of the document sender.
        ''' </summary>
        ''' <value>The Sender ID.</value>
        Public Property SenderID As Integer
            Get
                Return GetProperty(SenderIDProperty)
            End Get
            Set(ByVal value As Integer)
                SetProperty(SenderIDProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="RecipientID"/> property.
        ''' </summary>
        Public Shared ReadOnly RecipientIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.RecipientID, "Recipient ID")
        ''' <summary>
        ''' Gets or sets the Entity ID of the document recipient.
        ''' </summary>
        ''' <value>The Recipient ID.</value>
        Public Property RecipientID As Integer
            Get
                Return GetProperty(RecipientIDProperty)
            End Get
            Set(ByVal value As Integer)
                SetProperty(RecipientIDProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocRef"/> property.
        ''' </summary>
        Public Shared ReadOnly DocRefProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.DocRef, "Doc Ref")
        ''' <summary>
        ''' Gets or sets the Doc Ref.
        ''' </summary>
        ''' <value>The Doc Ref.</value>
        Public Property DocRef As String
            Get
                Return GetProperty(DocRefProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(DocRefProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocDate"/> property.
        ''' </summary>
        Public Shared ReadOnly DocDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.DocDate, "Doc Date")
        ''' <summary>
        ''' Gets or sets the Doc Date.
        ''' </summary>
        ''' <value>The Doc Date.</value>
        <DateNotInFutureAttr("Please pay attention: {0} can't be in the future.")>
        Public Property DocDate As String
            Get
                Return GetPropertyConvert(Of SmartDate, String)(DocDateProperty)
            End Get
            Set(ByVal value As String)
                SetPropertyConvert(Of SmartDate, String)(DocDateProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="Subject"/> property.
        ''' </summary>
        Public Shared ReadOnly SubjectProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.Subject, "Subject")
        ''' <summary>
        ''' Gets or sets the Subject.
        ''' </summary>
        ''' <value>The Subject.</value>
        Public Property Subject As String
            Get
                Return GetProperty(SubjectProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(SubjectProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocStatusID"/> property.
        ''' </summary>
        Public Shared ReadOnly DocStatusIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.DocStatusID, "Doc Status ID")
        ''' <summary>
        ''' Gets or sets the Doc Status ID.
        ''' </summary>
        ''' <value>The Doc Status ID.</value>
        Public Property DocStatusID As Integer
            Get
                Return GetProperty(DocStatusIDProperty)
            End Get
            Set(ByVal value As Integer)
                SetProperty(DocStatusIDProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="CreateDate"/> property.
        ''' </summary>
        Public Shared ReadOnly CreateDateProperty As PropertyInfo(Of Date) = RegisterProperty(Of Date)(Function(p) p.CreateDate, "Create Date")
        ''' <summary>
        ''' Gets or sets the Create Date.
        ''' </summary>
        ''' <value>The Create Date.</value>
        Public Property CreateDate As Date
            Get
                Return GetProperty(CreateDateProperty)
            End Get
            Private Set(ByVal value As Date)
                SetProperty(CreateDateProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="CreateUserID"/> property.
        ''' </summary>
        Public Shared ReadOnly CreateUserIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.CreateUserID, "Create User ID")
        ''' <summary>
        ''' Gets or sets the Create User ID.
        ''' </summary>
        ''' <value>The Create User ID.</value>
        Public Property CreateUserID As Integer
            Get
                Return GetProperty(CreateUserIDProperty)
            End Get
            Private Set(ByVal value As Integer)
                SetProperty(CreateUserIDProperty, value)
                OnPropertyChanged("CreateUserName")
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="ChangeDate"/> property.
        ''' </summary>
        Public Shared ReadOnly ChangeDateProperty As PropertyInfo(Of Date) = RegisterProperty(Of Date)(Function(p) p.ChangeDate, "Change Date")
        ''' <summary>
        ''' Gets or sets the Change Date.
        ''' </summary>
        ''' <value>The Change Date.</value>
        Public Property ChangeDate As Date
            Get
                Return GetProperty(ChangeDateProperty)
            End Get
            Private Set(ByVal value As Date)
                SetProperty(ChangeDateProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="ChangeUserID"/> property.
        ''' </summary>
        Public Shared ReadOnly ChangeUserIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.ChangeUserID, "Change User ID")
        ''' <summary>
        ''' Gets or sets the Change User ID.
        ''' </summary>
        ''' <value>The Change User ID.</value>
        Public Property ChangeUserID As Integer
            Get
                Return GetProperty(ChangeUserIDProperty)
            End Get
            Private Set(ByVal value As Integer)
                SetProperty(ChangeUserIDProperty, value)
                OnPropertyChanged("ChangeUserName")
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="RowVersion"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly RowVersionProperty As PropertyInfo(Of Byte()) = RegisterProperty(Of Byte())(Function(p) p.RowVersion, "Row Version")
        ''' <summary>
        ''' Gets the Row Version.
        ''' </summary>
        ''' <value>The Row Version.</value>
        Public ReadOnly Property RowVersion As Byte()
            Get
                Return GetProperty(RowVersionProperty)
            End Get
        End Property

        ''' <summary>
        ''' Gets the Create User Name.
        ''' </summary>
        ''' <value>The Create User Name.</value>
        Public ReadOnly Property CreateUserName As String
            Get
                Dim result = String.Empty
                If Admin.UserNVL.GetUserNVL().ContainsKey(CreateUserID) Then
                    result = Admin.UserNVL.GetUserNVL().GetItemByKey(CreateUserID).Value
                End If
                Return result
            End Get
        End Property

        ''' <summary>
        ''' Gets the Change User Name.
        ''' </summary>
        ''' <value>The Change User Name.</value>
        Public ReadOnly Property ChangeUserName As String
            Get
                Dim result = String.Empty
                If Admin.UserNVL.GetUserNVL().ContainsKey(ChangeUserID) Then
                    result = Admin.UserNVL.GetUserNVL().GetItemByKey(ChangeUserID).Value
                End If
                Return result
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about child <see cref="EditContent"/> property.
        ''' </summary>
        Public Shared ReadOnly EditContentProperty As PropertyInfo(Of DocContent) = RegisterProperty(Of DocContent)(Function(p) p.EditContent, "Edit Content", RelationshipTypes.Child)
        ''' <summary>
        ''' Gets the Edit Content ("parent load" child property).
        ''' </summary>
        ''' <value>The Edit Content.</value>
        Public Property EditContent As DocContent
            Get
                Return GetProperty(EditContentProperty)
            End Get
            Set(ByVal value As DocContent)
                SetProperty(EditContentProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about child <see cref="Folders"/> property.
        ''' </summary>
        Public Shared ReadOnly FoldersProperty As PropertyInfo(Of DocFolderColl) = RegisterProperty(Of DocFolderColl)(Function(p) p.Folders, "Folders", RelationshipTypes.Child)
        ''' <summary>
        ''' Gets the Folders ("parent load" child property).
        ''' </summary>
        ''' <value>The Folders.</value>
        Public Property Folders As DocFolderColl
            Get
                Return GetProperty(FoldersProperty)
            End Get
            Private Set(ByVal value As DocFolderColl)
                LoadProperty(FoldersProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about child <see cref="Circulations"/> property.
        ''' </summary>
        Public Shared ReadOnly CirculationsProperty As PropertyInfo(Of DocCircColl) = RegisterProperty(Of DocCircColl)(Function(p) p.Circulations, "Circulations", RelationshipTypes.Child)
        ''' <summary>
        ''' Gets the Circulations ("parent load" child property).
        ''' </summary>
        ''' <value>The Circulations.</value>
        Public Property Circulations As DocCircColl
            Get
                Return GetProperty(CirculationsProperty)
            End Get
            Private Set(ByVal value As DocCircColl)
                LoadProperty(CirculationsProperty, value)
            End Set
        End Property

        #End Region

        #Region " BusinessBase(Of T) Overrides "

        ''' <summary>
        ''' Returns a string that represents the current <see cref="Doc"/>
        ''' </summary>
        ''' <returns>A <see cref="System.String"/> that represents this instance.</returns>
        Public Overrides Function ToString() As String
            ' Return the Primary Key as a string
            Return DocID.ToString() + ", " + DocRef.ToString()
        End Function

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="Doc"/> object.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="Doc"/> object.</returns>
        Public Shared Function NewDoc() As Doc
            Return DataPortal.Create(Of Doc)()
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="Doc"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="docID">The DocID parameter of the Doc to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="Doc"/> object.</returns>
        Public Shared Function GetDoc(docID As Integer) As Doc
            Return DataPortal.Fetch(Of Doc)(docID)
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="Doc"/> object.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub NewDoc(callback As EventHandler(Of DataPortalResult(Of Doc)))
            DocEditGetter.NewDocEditGetter(Sub(o, e)
                callback(o, New DataPortalResult(Of Doc)(e.Object.Doc, e.Error, Nothing))
            End Sub)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="Doc"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="docID">The DocID parameter of the Doc to fetch.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetDoc(docID As Integer, ByVal callback As EventHandler(Of DataPortalResult(Of Doc)))
            DocEditGetter.GetDocEditGetter(docID, Sub(o, e)
                callback(o, New DataPortalResult(Of Doc)(e.Object.Doc, e.Error, Nothing))
            End Sub)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="Doc"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
            AddHandler Saved, AddressOf OnDocSaved
        End Sub

        #End Region

        #Region " Object Authorization "

        ''' <summary>
        ''' Adds the object authorization rules.
        ''' </summary>
        Protected Shared Sub AddObjectAuthorizationRules()
            BusinessRules.AddRule(GetType(Doc), New IsInRole(AuthorizationActions.CreateObject, "Author"))
            BusinessRules.AddRule(GetType(Doc), New IsInRole(AuthorizationActions.GetObject, "User"))
            BusinessRules.AddRule(GetType(Doc), New IsInRole(AuthorizationActions.EditObject, "Author"))

            AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Allows the set up of custom object authorization rules.
        ''' </summary>
        Partial Private Shared Sub AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Checks if the current user can create a new Doc object.
        ''' </summary>
        ''' <returns><c>True</c> if the user can create a new object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanAddObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.CreateObject, GetType(Doc))
        End Function

        ''' <summary>
        ''' Checks if the current user can retrieve Doc's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanGetObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, GetType(Doc))
        End Function

        ''' <summary>
        ''' Checks if the current user can change Doc's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can update the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanEditObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.EditObject, GetType(Doc))
        End Function

        ''' <summary>
        ''' Checks if the current user can delete a Doc object.
        ''' </summary>
        ''' <returns><c>True</c> if the user can delete the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanDeleteObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.DeleteObject, GetType(Doc))
        End Function

        #End Region

        #Region " Business Rules and Property Authorization "

        ''' <summary>
        ''' Override this method in your business class to be notified when you need to set up shared business rules.
        ''' </summary>
        ''' <remarks>
        ''' This method is automatically called by CSLA.NET when your object should associate
        ''' per-type validation rules with its properties.
        ''' </remarks>
        Protected Overrides Sub AddBusinessRules()
            MyBase.AddBusinessRules()

            ' Property Business Rules

            ' DocClassID
            BusinessRules.AddRule(New Required(DocClassIDProperty))
            ' DocTypeID
            BusinessRules.AddRule(New Required(DocTypeIDProperty))
            ' SenderID
            BusinessRules.AddRule(New Required(SenderIDProperty))
            ' RecipientID
            BusinessRules.AddRule(New Required(RecipientIDProperty))
            ' DocRef
            BusinessRules.AddRule(New CollapseWhiteSpace(DocRefProperty) With { .Priority = -1 })
            BusinessRules.AddRule(New MaxLength(DocRefProperty, 35))
            ' DocDate
            BusinessRules.AddRule(New Required(DocDateProperty))
            ' Subject
            BusinessRules.AddRule(New CollapseWhiteSpace(SubjectProperty) With { .Priority = -1 })
            BusinessRules.AddRule(New Required(SubjectProperty))
            BusinessRules.AddRule(New MaxLength(SubjectProperty, 255))
            ' DocStatusID
            BusinessRules.AddRule(New Required(DocStatusIDProperty))

            ' Authorization Rules

            ' DocClassID
            BusinessRules.AddRule(New RestrictByStatusOrIsInRole(AuthorizationActions.WriteProperty, DocClassIDProperty, "DocStatusID", New List(Of Integer) From {4}, "Admin"))
            ' DocTypeID
            BusinessRules.AddRule(New IsNewOrIsInRole(AuthorizationActions.WriteProperty, DocTypeIDProperty, "Admin"))
            ' SenderID
            BusinessRules.AddRule(New IsNewOrIsInRole(AuthorizationActions.WriteProperty, SenderIDProperty, "Admin"))
            ' RecipientID
            BusinessRules.AddRule(New IsNewOrIsInRole(AuthorizationActions.WriteProperty, RecipientIDProperty, "Admin"))
            ' DocRef
            BusinessRules.AddRule(New IsEmptyOrIsInRole(AuthorizationActions.WriteProperty, DocRefProperty, "Admin"))
            ' DocDate
            BusinessRules.AddRule(New IsNewOrIsInRole(AuthorizationActions.WriteProperty, DocDateProperty, "Admin"))
            ' Subject
            BusinessRules.AddRule(New RestrictByStatusOrIsInRole(AuthorizationActions.WriteProperty, SubjectProperty, "DocStatusID", New List(Of Integer) From {3, 4}, "Admin"))
            ' DocStatusID
            BusinessRules.AddRule(New RestrictByStatusOrIsInRole(AuthorizationActions.WriteProperty, DocStatusIDProperty, "DocStatusID", New List(Of Integer) From {4}, "Admin"))
            ' Secret
            BusinessRules.AddRule(New IsOwnerOrIsInRole(AuthorizationActions.ReadProperty, SecretProperty, "CreateUserID", Function() UserInformation.UserId, "Admin", "Manager"))
            BusinessRules.AddRule(New IsOwner(AuthorizationActions.WriteProperty, SecretProperty, "CreateUserID", Function() UserInformation.UserId))

            AddBusinessRulesExtend()
        End Sub

        ''' <summary>
        ''' Allows the set up of custom shared business rules.
        ''' </summary>
        Partial Private Sub AddBusinessRulesExtend()
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads default values for the <see cref="Doc"/> object properties.
        ''' </summary>
        <Csla.RunLocal()>
        Protected Overrides Sub DataPortal_Create()
            LoadProperty(DocIDProperty, System.Threading.Interlocked.Decrement(_lastID))
            LoadProperty(DocClassIDProperty, -1)
            LoadProperty(DocTypeIDProperty, -1)
            LoadProperty(SenderIDProperty, -1)
            LoadProperty(DocDateProperty, new SmartDate(Date.Today))
            LoadProperty(DocStatusIDProperty, -1)
            LoadProperty(CreateDateProperty, Date.Now)
            LoadProperty(CreateUserIDProperty, UserInformation.UserId)
            LoadProperty(ChangeDateProperty, ReadProperty(CreateDateProperty))
            LoadProperty(ChangeUserIDProperty, ReadProperty(CreateUserIDProperty))
            LoadProperty(EditContentProperty, DataPortal.CreateChild(Of DocContent)())
            LoadProperty(FoldersProperty, DataPortal.CreateChild(Of DocFolderColl)())
            LoadProperty(CirculationsProperty, DataPortal.CreateChild(Of DocCircColl)())
            Dim args As New DataPortalHookArgs()
            OnCreate(args)
            MyBase.DataPortal_Create()
        End Sub

        ''' <summary>
        ''' Loads a <see cref="Doc"/> object from the database, based on given criteria.
        ''' </summary>
        ''' <param name="docID">The Doc ID.</param>
        Protected Sub DataPortal_Fetch(docID As Integer)
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.DocStoreConnection, False)
                Using cmd = New SqlCommand("GetDoc", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DocID", docID).DbType = DbType.Int32
                    Dim args As New DataPortalHookArgs(cmd, docID)
                    OnFetchPre(args)
                    Fetch(cmd)
                    OnFetchPost(args)
                End Using
            End Using
            ' check all object rules and property rules
            BusinessRules.CheckRules()
        End Sub

        Private Sub Fetch(cmd As SqlCommand)
            Using dr As New SafeDataReader(cmd.ExecuteReader())
                If dr.Read() Then
                    Fetch(dr)
                    FetchChildren(dr)
                End If
            End Using
        End Sub

        ''' <summary>
        ''' Loads a <see cref="Doc"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(DocIDProperty, dr.GetInt32("DocID"))
            LoadProperty(DocClassIDProperty, dr.GetInt32("DocClassID"))
            LoadProperty(DocTypeIDProperty, dr.GetInt32("DocTypeID"))
            LoadProperty(SenderIDProperty, dr.GetInt32("SenderID"))
            LoadProperty(RecipientIDProperty, dr.GetInt32("RecipientID"))
            LoadProperty(DocRefProperty, dr.GetString("DocRef"))
            LoadProperty(DocDateProperty, dr.GetSmartDate("DocDate", True))
            LoadProperty(SubjectProperty, dr.GetString("Subject"))
            LoadProperty(DocStatusIDProperty, dr.GetInt32("DocStatusID"))
            LoadProperty(CreateDateProperty, dr.GetDateTime("CreateDate"))
            LoadProperty(CreateUserIDProperty, dr.GetInt32("CreateUserID"))
            LoadProperty(ChangeDateProperty, dr.GetDateTime("ChangeDate"))
            LoadProperty(ChangeUserIDProperty, dr.GetInt32("ChangeUserID"))
            LoadProperty(RowVersionProperty, TryCast(dr.GetValue("RowVersion"), Byte()))
            LoadProperty(SecretProperty, dr.GetString("Secret"))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
        End Sub

        ''' <summary>
        ''' Loads child objects from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub FetchChildren(dr As SafeDataReader)
            dr.NextResult()
            If dr.Read() Then
                LoadProperty(EditContentProperty, DocContent.GetDocContent(dr))
            End If
            dr.NextResult()
            LoadProperty(FoldersProperty, DocFolderColl.GetDocFolderColl(dr))
            dr.NextResult()
            LoadProperty(CirculationsProperty, DocCircColl.GetDocCircColl(dr))
            dr.NextResult()
            If dr.Read() Then
                LoadProperty(ViewContentProperty, DocContentRO.GetDocContentRO(dr))
            End If
            dr.NextResult()
            LoadProperty(ContentsProperty, DocContentList.GetDocContentList(dr))
        End Sub

        ''' <summary>
        ''' Inserts a new <see cref="Doc"/> object in the database.
        ''' </summary>
        Protected Overrides Sub DataPortal_Insert()
            SimpleAuditTrail()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.DocStoreConnection, False)
                Using cmd = New SqlCommand("AddDoc", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DocID", ReadProperty(DocIDProperty)).Direction = ParameterDirection.Output
                    cmd.Parameters.AddWithValue("@DocClassID", ReadProperty(DocClassIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@DocTypeID", ReadProperty(DocTypeIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@SenderID", ReadProperty(SenderIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@RecipientID", ReadProperty(RecipientIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@DocRef", ReadProperty(DocRefProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@DocDate", ReadProperty(DocDateProperty).DBValue).DbType = DbType.Date
                    cmd.Parameters.AddWithValue("@Subject", ReadProperty(SubjectProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@DocStatusID", ReadProperty(DocStatusIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@CreateDate", ReadProperty(CreateDateProperty)).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@CreateUserID", ReadProperty(CreateUserIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty)).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output
                    cmd.Parameters.AddWithValue("@Secret", ReadProperty(SecretProperty)).DbType = DbType.String
                    Dim args As New DataPortalHookArgs(cmd)
                    OnInsertPre(args)
                    cmd.ExecuteNonQuery()
                    OnInsertPost(args)
                    LoadProperty(DocIDProperty, DirectCast(cmd.Parameters("@DocID").Value, Integer))
                    LoadProperty(RowVersionProperty, DirectCast(cmd.Parameters("@NewRowVersion").Value, Byte()))
                End Using
                ' flushes all pending data operations
                FieldManager.UpdateChildren(Me)
                ctx.Commit()
            End Using
        End Sub

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="Doc"/> object.
        ''' </summary>
        Protected Overrides Sub DataPortal_Update()
            SimpleAuditTrail()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.DocStoreConnection, False)
                Using cmd = New SqlCommand("UpdateDoc", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DocID", ReadProperty(DocIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@DocClassID", ReadProperty(DocClassIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@DocTypeID", ReadProperty(DocTypeIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@SenderID", ReadProperty(SenderIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@RecipientID", ReadProperty(RecipientIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@DocRef", ReadProperty(DocRefProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@DocDate", ReadProperty(DocDateProperty).DBValue).DbType = DbType.Date
                    cmd.Parameters.AddWithValue("@Subject", ReadProperty(SubjectProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@DocStatusID", ReadProperty(DocStatusIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty)).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@RowVersion", ReadProperty(RowVersionProperty)).DbType = DbType.Binary
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output
                    cmd.Parameters.AddWithValue("@Secret", ReadProperty(SecretProperty)).DbType = DbType.String
                    Dim args As New DataPortalHookArgs(cmd)
                    OnUpdatePre(args)
                    cmd.ExecuteNonQuery()
                    OnUpdatePost(args)
                    LoadProperty(RowVersionProperty, DirectCast(cmd.Parameters("@NewRowVersion").Value, Byte()))
                End Using
                ' flushes all pending data operations
                FieldManager.UpdateChildren(Me)
                ctx.Commit()
            End Using
        End Sub

        Private Sub SimpleAuditTrail()
            LoadProperty(ChangeDateProperty, Date.Now)
            LoadProperty(ChangeUserIDProperty, UserInformation.UserId)
            OnPropertyChanged("ChangeUserName")
            If IsNew Then
                LoadProperty(CreateDateProperty, ReadProperty(ChangeDateProperty))
                LoadProperty(CreateUserIDProperty, ReadProperty(ChangeUserIDProperty))
                OnPropertyChanged("CreateUserName")
            End If
        End Sub

        #End Region

        #Region " Saved Event "

        Private Sub OnDocSaved(sender As Object, e As Csla.Core.SavedEventArgs)
                RaiseEvent DocSaved(sender, e)
        End Sub

        ''' <summary> Use this event to signal a <see cref="Doc"/> object was saved.</summary>
        Public Shared Event DocSaved As EventHandler(Of Csla.Core.SavedEventArgs)

        #End Region

        #Region " DataPortal Hooks "

        ''' <summary>
        ''' Occurs after setting all defaults for object creation.
        ''' </summary>
        Partial Private Sub OnCreate(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs after setting query parameters and before the fetch operation.
        ''' </summary>
        Partial Private Sub OnFetchPre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs after the fetch operation (object or collection is fully loaded and set up).
        ''' </summary>
        Partial Private Sub OnFetchPost(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs after the low level fetch operation, before the data reader is destroyed.
        ''' </summary>
        Partial Private Sub OnFetchRead(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs after setting query parameters and before the update operation.
        ''' </summary>
        Partial Private Sub OnUpdatePre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Insert, after the update operation, before setting back row identifiers (RowVersion) and Commit().
        ''' </summary>
        Partial Private Sub OnUpdatePost(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Insert, after setting query parameters and before the insert operation.
        ''' </summary>
        Partial Private Sub OnInsertPre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Insert, after the insert operation, before setting back row identifiers (ID and RowVersion) and Commit().
        ''' </summary>
        Partial Private Sub OnInsertPost(args As DataPortalHookArgs)
        End Sub

        #End Region

    End Class

End Namespace
