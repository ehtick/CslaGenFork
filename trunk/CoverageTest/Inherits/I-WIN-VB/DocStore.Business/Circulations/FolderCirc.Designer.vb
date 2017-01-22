'  This file was generated by CSLA Object Generator - CslaGenFork v4.5
'
' Filename:    FolderCirc
' ObjectType:  FolderCirc
' CSLAType:    EditableChild

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports DocStore.Business.Util
Imports Csla.Rules
Imports Csla.Rules.CommonRules
Imports DocStore.Business.Admin
Imports DocStore.Business.Security

Namespace DocStore.Business.Circulations

    ''' <summary>
    ''' Circulation of this folder (editable child object).<br/>
    ''' This is a generated base class of <see cref="FolderCirc"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="FolderCircColl"/> collection.
    ''' </remarks>
    <Serializable()>
    Partial Public Class FolderCirc
    Inherits BusinessBase(Of FolderCirc)

        #Region " Static Fields "

            Private Shared _lastID As Integer

        #End Region

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="CircID"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly CircIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.CircID, "Circ ID")
        ''' <summary>
        ''' Gets the Circ ID.
        ''' </summary>
        ''' <value>The Circ ID.</value>
        Public ReadOnly Property CircID As Integer
            Get
                Return GetProperty(CircIDProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="NeedsReply"/> property.
        ''' </summary>
        Public Shared ReadOnly NeedsReplyProperty As PropertyInfo(Of Boolean) = RegisterProperty(Of Boolean)(Function(p) p.NeedsReply, "Needs Reply")
        ''' <summary>
        ''' Gets or sets the Needs Reply.
        ''' </summary>
        ''' <value><c>True</c> if Needs Reply; otherwise, <c>false</c>.</value>
        Public Property NeedsReply As Boolean
            Get
                Return GetProperty(NeedsReplyProperty)
            End Get
            Set(ByVal value As Boolean)
                SetProperty(NeedsReplyProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="NeedsReplyDecision"/> property.
        ''' </summary>
        Public Shared ReadOnly NeedsReplyDecisionProperty As PropertyInfo(Of Boolean) = RegisterProperty(Of Boolean)(Function(p) p.NeedsReplyDecision, "Needs Reply Decision")
        ''' <summary>
        ''' Gets or sets the Needs Reply Decision.
        ''' </summary>
        ''' <value><c>True</c> if Needs Reply Decision; otherwise, <c>false</c>.</value>
        Public Property NeedsReplyDecision As Boolean
            Get
                Return GetProperty(NeedsReplyDecisionProperty)
            End Get
            Set(ByVal value As Boolean)
                SetProperty(NeedsReplyDecisionProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="CircTypeTag"/> property.
        ''' </summary>
        Public Shared ReadOnly CircTypeTagProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.CircTypeTag, "Circ Type Tag")
        ''' <summary>
        ''' Gets or sets the Circ Type Tag.
        ''' </summary>
        ''' <value>The Circ Type Tag.</value>
        Public Property CircTypeTag As String
            Get
                Return GetProperty(CircTypeTagProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(CircTypeTagProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="Notes"/> property.
        ''' </summary>
        Public Shared ReadOnly NotesProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.Notes, "Notes")
        ''' <summary>
        ''' Gets or sets the Notes.
        ''' </summary>
        ''' <value>The Notes.</value>
        Public Property Notes As String
            Get
                Return GetProperty(NotesProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(NotesProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="TagNotesCert"/> property.
        ''' </summary>
        Public Shared ReadOnly TagNotesCertProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.TagNotesCert, "Tag Notes Cert")
        ''' <summary>
        ''' Gets or sets the Tag Notes Cert.
        ''' </summary>
        ''' <value>The Tag Notes Cert.</value>
        Public Property TagNotesCert As String
            Get
                Return GetProperty(TagNotesCertProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(TagNotesCertProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="SenderEntityID"/> property.
        ''' </summary>
        Public Shared ReadOnly SenderEntityIDProperty As PropertyInfo(Of Integer?) = RegisterProperty(Of Integer?)(Function(p) p.SenderEntityID, "Sender Entity ID")
        ''' <summary>
        ''' Gets or sets the Sender Entity ID.
        ''' </summary>
        ''' <value>The Sender Entity ID.</value>
        Public Property SenderEntityID As Integer?
            Get
                Return GetProperty(SenderEntityIDProperty)
            End Get
            Set(ByVal value As Integer?)
                SetProperty(SenderEntityIDProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="SentDateTime"/> property.
        ''' </summary>
        Public Shared ReadOnly SentDateTimeProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.SentDateTime, "Sent Date Time")
        ''' <summary>
        ''' Gets or sets the Sent Date Time.
        ''' </summary>
        ''' <value>The Sent Date Time.</value>
        Public Property SentDateTime As SmartDate
            Get
                Return GetProperty(SentDateTimeProperty)
            End Get
            Set(ByVal value As SmartDate)
                SetProperty(SentDateTimeProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DaysToReply"/> property.
        ''' </summary>
        Public Shared ReadOnly DaysToReplyProperty As PropertyInfo(Of Short) = RegisterProperty(Of Short)(Function(p) p.DaysToReply, "Days To Reply")
        ''' <summary>
        ''' Gets or sets the Days To Reply.
        ''' </summary>
        ''' <value>The Days To Reply.</value>
        Public Property DaysToReply As Short
            Get
                Return GetProperty(DaysToReplyProperty)
            End Get
            Set(ByVal value As Short)
                SetProperty(DaysToReplyProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DaysToLive"/> property.
        ''' </summary>
        Public Shared ReadOnly DaysToLiveProperty As PropertyInfo(Of Short) = RegisterProperty(Of Short)(Function(p) p.DaysToLive, "Days To Live")
        ''' <summary>
        ''' Gets or sets the Days To Live.
        ''' </summary>
        ''' <value>The Days To Live.</value>
        Public Property DaysToLive As Short
            Get
                Return GetProperty(DaysToLiveProperty)
            End Get
            Set(ByVal value As Short)
                SetProperty(DaysToLiveProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="CreateDate"/> property.
        ''' </summary>
        Public Shared ReadOnly CreateDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.CreateDate, "Create Date")
        ''' <summary>
        ''' Gets the Create Date.
        ''' </summary>
        ''' <value>The Create Date.</value>
        Public ReadOnly Property CreateDate As SmartDate
            Get
                Return GetProperty(CreateDateProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="CreateUserID"/> property.
        ''' </summary>
        Public Shared ReadOnly CreateUserIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.CreateUserID, "Create User ID")
        ''' <summary>
        ''' Gets the Create User ID.
        ''' </summary>
        ''' <value>The Create User ID.</value>
        Public ReadOnly Property CreateUserID As Integer
            Get
                Return GetProperty(CreateUserIDProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="ChangeDate"/> property.
        ''' </summary>
        Public Shared ReadOnly ChangeDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.ChangeDate, "Change Date")
        ''' <summary>
        ''' Gets the Change Date.
        ''' </summary>
        ''' <value>The Change Date.</value>
        Public ReadOnly Property ChangeDate As SmartDate
            Get
                Return GetProperty(ChangeDateProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="ChangeUserID"/> property.
        ''' </summary>
        Public Shared ReadOnly ChangeUserIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.ChangeUserID, "Change User ID")
        ''' <summary>
        ''' Gets the Change User ID.
        ''' </summary>
        ''' <value>The Change User ID.</value>
        Public ReadOnly Property ChangeUserID As Integer
            Get
                Return GetProperty(ChangeUserIDProperty)
            End Get
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
                If UserNVL.GetUserNVL().ContainsKey(CreateUserID) Then
                    result = UserNVL.GetUserNVL().GetItemByKey(CreateUserID).Value
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
                If UserNVL.GetUserNVL().ContainsKey(ChangeUserID) Then
                    result = UserNVL.GetUserNVL().GetItemByKey(ChangeUserID).Value
                End If
                Return result
            End Get
        End Property

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="FolderCirc"/> object.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="FolderCirc"/> object.</returns>
        Friend Shared Function NewFolderCirc() As FolderCirc
            Return DataPortal.CreateChild(Of FolderCirc)()
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="FolderCirc"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        ''' <returns>A reference to the fetched <see cref="FolderCirc"/> object.</returns>
        Friend Shared Function GetFolderCirc(dr As SafeDataReader) As FolderCirc
            Dim obj As FolderCirc = New FolderCirc()
            ' show the framework that this is a child object
            obj.MarkAsChild()
            obj.Fetch(dr)
            obj.MarkOld()
            ' check all object rules and property rules
            obj.BusinessRules.CheckRules()
            Return obj
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="FolderCirc"/> object.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Friend Shared Sub NewFolderCirc(callback As EventHandler(Of DataPortalResult(Of FolderCirc)))
            DataPortal.BeginCreate(Of FolderCirc)(callback)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="FolderCirc"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.

            ' show the framework that this is a child object
            MarkAsChild()
        End Sub

        #End Region

        #Region " Object Authorization "

        ''' <summary>
        ''' Adds the object authorization rules.
        ''' </summary>
        Protected Shared Sub AddObjectAuthorizationRules()
            BusinessRules.AddRule(GetType(FolderCirc), New IsInRole(AuthorizationActions.GetObject, "User"))

            AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Allows the set up of custom object authorization rules.
        ''' </summary>
        Partial Private Shared Sub AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Checks if the current user can create a new FolderCirc object.
        ''' </summary>
        ''' <returns><c>True</c> if the user can create a new object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanAddObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.CreateObject, GetType(FolderCirc))
        End Function

        ''' <summary>
        ''' Checks if the current user can retrieve FolderCirc's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanGetObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, GetType(FolderCirc))
        End Function

        ''' <summary>
        ''' Checks if the current user can change FolderCirc's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can update the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanEditObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.EditObject, GetType(FolderCirc))
        End Function

        ''' <summary>
        ''' Checks if the current user can delete a FolderCirc object.
        ''' </summary>
        ''' <returns><c>True</c> if the user can delete the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanDeleteObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.DeleteObject, GetType(FolderCirc))
        End Function

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads default values for the <see cref="FolderCirc"/> object properties.
        ''' </summary>
        <Csla.RunLocal()>
        Protected Overrides Sub Child_Create()
            LoadProperty(CircIDProperty, System.Threading.Interlocked.Decrement(_lastID))
            LoadProperty(CreateDateProperty, new SmartDate(Date.Now))
            LoadProperty(CreateUserIDProperty, UserInformation.UserId)
            LoadProperty(ChangeDateProperty, ReadProperty(CreateDateProperty))
            LoadProperty(ChangeUserIDProperty, ReadProperty(CreateUserIDProperty))
            Dim args As New DataPortalHookArgs()
            OnCreate(args)
            MyBase.Child_Create()
        End Sub

        ''' <summary>
        ''' Loads a <see cref="FolderCirc"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(CircIDProperty, dr.GetInt32("CircID"))
            LoadProperty(NeedsReplyProperty, dr.GetBoolean("NeedsReply"))
            LoadProperty(NeedsReplyDecisionProperty, dr.GetBoolean("NeedsReplyDecision"))
            LoadProperty(CircTypeTagProperty, dr.GetString("CircTypeTag"))
            LoadProperty(NotesProperty, dr.GetString("Notes"))
            LoadProperty(TagNotesCertProperty, dr.GetString("TagNotesCert"))
            LoadProperty(SenderEntityIDProperty, DirectCast(dr.GetValue("SenderEntityID"), Integer?))
            LoadProperty(SentDateTimeProperty, dr.GetSmartDate("SentDateTime", True))
            LoadProperty(DaysToReplyProperty, dr.GetInt16("DaysToReply"))
            LoadProperty(DaysToLiveProperty, dr.GetInt16("DaysToLive"))
            LoadProperty(CreateDateProperty, dr.GetSmartDate("CreateDate", True))
            LoadProperty(CreateUserIDProperty, dr.GetInt32("CreateUserID"))
            LoadProperty(ChangeDateProperty, dr.GetSmartDate("ChangeDate", True))
            LoadProperty(ChangeUserIDProperty, dr.GetInt32("ChangeUserID"))
            LoadProperty(RowVersionProperty, TryCast(dr.GetValue("RowVersion"), Byte()))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
        End Sub

        ''' <summary>
        ''' Inserts a new <see cref="FolderCirc"/> object in the database.
        ''' </summary>
        ''' <param name="parent">The parent object.</param>
        Private Sub Child_Insert(parent As Folder)
            SimpleAuditTrail()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.DocStoreConnection, False)
                Using cmd = New SqlCommand("AddFolderCirc", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@FolderID", parent.FolderID).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@CircID", ReadProperty(CircIDProperty)).Direction = ParameterDirection.Output
                    cmd.Parameters.AddWithValue("@NeedsReply", ReadProperty(NeedsReplyProperty)).DbType = DbType.Boolean
                    cmd.Parameters.AddWithValue("@NeedsReplyDecision", ReadProperty(NeedsReplyDecisionProperty)).DbType = DbType.Boolean
                    cmd.Parameters.AddWithValue("@CircTypeTag", ReadProperty(CircTypeTagProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@Notes", ReadProperty(NotesProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@TagNotesCert", ReadProperty(TagNotesCertProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@SenderEntityID", If(ReadProperty(SenderEntityIDProperty) Is Nothing, DBNull.Value, ReadProperty(SenderEntityIDProperty).Value)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@SentDateTime", ReadProperty(SentDateTimeProperty).DBValue).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@DaysToReply", ReadProperty(DaysToReplyProperty)).DbType = DbType.Int16
                    cmd.Parameters.AddWithValue("@DaysToLive", ReadProperty(DaysToLiveProperty)).DbType = DbType.Int16
                    cmd.Parameters.AddWithValue("@CreateDate", ReadProperty(CreateDateProperty).DBValue).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@CreateUserID", ReadProperty(CreateUserIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output
                    Dim args As New DataPortalHookArgs(cmd)
                    OnInsertPre(args)
                    cmd.ExecuteNonQuery()
                    OnInsertPost(args)
                    LoadProperty(CircIDProperty, DirectCast(cmd.Parameters("@CircID").Value, Integer))
                    LoadProperty(RowVersionProperty, DirectCast(cmd.Parameters("@NewRowVersion").Value, Byte()))
                End Using
            End Using
        End Sub

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="FolderCirc"/> object.
        ''' </summary>
        Private Sub Child_Update()
            If Not IsDirty
                return
            End If

            SimpleAuditTrail()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.DocStoreConnection, False)
                Using cmd = New SqlCommand("UpdateFolderCirc", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@CircID", ReadProperty(CircIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@NeedsReply", ReadProperty(NeedsReplyProperty)).DbType = DbType.Boolean
                    cmd.Parameters.AddWithValue("@NeedsReplyDecision", ReadProperty(NeedsReplyDecisionProperty)).DbType = DbType.Boolean
                    cmd.Parameters.AddWithValue("@CircTypeTag", ReadProperty(CircTypeTagProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@Notes", ReadProperty(NotesProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@TagNotesCert", ReadProperty(TagNotesCertProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@SenderEntityID", If(ReadProperty(SenderEntityIDProperty) Is Nothing, DBNull.Value, ReadProperty(SenderEntityIDProperty).Value)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@SentDateTime", ReadProperty(SentDateTimeProperty).DBValue).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@DaysToReply", ReadProperty(DaysToReplyProperty)).DbType = DbType.Int16
                    cmd.Parameters.AddWithValue("@DaysToLive", ReadProperty(DaysToLiveProperty)).DbType = DbType.Int16
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@RowVersion", ReadProperty(RowVersionProperty)).DbType = DbType.Binary
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output
                    Dim args As New DataPortalHookArgs(cmd)
                    OnUpdatePre(args)
                    cmd.ExecuteNonQuery()
                    OnUpdatePost(args)
                    LoadProperty(RowVersionProperty, DirectCast(cmd.Parameters("@NewRowVersion").Value, Byte()))
                End Using
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

        ''' <summary>
        ''' Self deletes the <see cref="FolderCirc"/> object from database.
        ''' </summary>
        Private Sub Child_DeleteSelf()
            ' audit the object, just in case soft delete is used on this object
            SimpleAuditTrail()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.DocStoreConnection, False)
                Using cmd = New SqlCommand("DeleteFolderCirc", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@CircID", ReadProperty(CircIDProperty)).DbType = DbType.Int32
                    Dim args As New DataPortalHookArgs(cmd)
                    OnDeletePre(args)
                    cmd.ExecuteNonQuery()
                    OnDeletePost(args)
                End Using
            End Using
        End Sub

        #End Region

        #Region " DataPortal Hooks "

        ''' <summary>
        ''' Occurs after setting all defaults for object creation.
        ''' </summary>
        Partial Private Sub OnCreate(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Delete, after setting query parameters and before the delete operation.
        ''' </summary>
        Partial Private Sub OnDeletePre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Delete, after the delete operation, before Commit().
        ''' </summary>
        Partial Private Sub OnDeletePost(args As DataPortalHookArgs)
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
