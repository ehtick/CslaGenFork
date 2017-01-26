'  This file was generated by CSLA Object Generator - CslaGenFork v4.5
'
' Filename:    DocClassEditColl
' ObjectType:  DocClassEditColl
' CSLAType:    EditableRootCollection

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports DocStore.Business.Util
Imports UsingLibrary

Namespace DocStore.Business

    ''' <summary>
    ''' DocClassEditColl (editable root list).<br/>
    ''' This is a generated base class of <see cref="DocClassEditColl"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' The items of the collection are <see cref="DocClassEdit"/> objects.
    ''' </remarks>
    <Serializable()>
    Partial Public Class DocClassEditColl
        Inherits MyBusinessListBase(Of DocClassEditColl, DocClassEdit)
        Implements IHaveInterface, IHaveGenericInterface(Of DocClassEditColl)
    
        #Region " Collection Business Methods "

        ''' <summary>
        ''' Removes a <see cref="DocClassEdit"/> item from the collection.
        ''' </summary>
        ''' <param name="docClassID">The DocClassID of the item to be removed.</param>
        Public Overloads Sub Remove(docClassID As Integer)
            For Each item As DocClassEdit In Me
                If item.DocClassID = docClassID Then
                    MyBase.Remove(item)
                    Exit For
                End If
            Next
        End Sub

        ''' <summary>
        ''' Determines whether a <see cref="DocClassEdit"/> item is in the collection.
        ''' </summary>
        ''' <param name="docClassID">The DocClassID of the item to search for.</param>
        ''' <returns><c>True</c> if the DocClassEdit is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(docClassID As Integer) As Boolean
            For Each item As DocClassEdit In Me
                If item.DocClassID = docClassID Then
                    Return True
                End If
            Next
            Return False
        End Function

        ''' <summary>
        ''' Determines whether a <see cref="DocClassEdit"/> item is in the collection's DeletedList.
        ''' </summary>
        ''' <param name="docClassID">The DocClassID of the item to search for.</param>
        ''' <returns><c>True</c> if the DocClassEdit is a deleted collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function ContainsDeleted(docClassID As Integer) As Boolean
            For Each item As DocClassEdit In DeletedList
                If item.DocClassID = docClassID Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="DocClassEditColl"/> collection.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="DocClassEditColl"/> collection.</returns>
        Public Shared Function NewDocClassEditColl() As DocClassEditColl
            Return DataPortal.Create(Of DocClassEditColl)()
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="DocClassEditColl"/> collection.
        ''' </summary>
        ''' <returns>A reference to the fetched <see cref="DocClassEditColl"/> collection.</returns>
        Public Shared Function GetDocClassEditColl() As DocClassEditColl
            Return DataPortal.Fetch(Of DocClassEditColl)()
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="DocClassEditColl"/> collection.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub NewDocClassEditColl(callback As EventHandler(Of DataPortalResult(Of DocClassEditColl)))
            DocClassEditCollGetter.NewDocClassEditCollGetter(Sub(o, e)
                callback(o, New DataPortalResult(Of DocClassEditColl)(e.Object.DocClassEditColl, e.Error, Nothing))
            End Sub)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="DocClassEditColl"/> collection.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetDocClassEditColl(ByVal callback As EventHandler(Of DataPortalResult(Of DocClassEditColl)))
            DocClassEditCollGetter.GetDocClassEditCollGetter(Sub(o, e)
                callback(o, New DataPortalResult(Of DocClassEditColl)(e.Object.DocClassEditColl, e.Error, Nothing))
            End Sub)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocClassEditColl"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.

            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            AllowNew = True
            AllowEdit = True
            AllowRemove = True
            RaiseListChangedEvents = rlce
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="DocClassEditColl"/> collection from the database.
        ''' </summary>
        Protected Overloads Sub DataPortal_Fetch()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.DocStoreConnection, False)
                Using cmd = New SqlCommand("GetDocClassEditColl", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    Dim args As New DataPortalHookArgs(cmd)
                    OnFetchPre(args)
                    LoadCollection(cmd)
                    OnFetchPost(args)
                End Using
            End Using
        End Sub

        Private Sub LoadCollection(cmd As SqlCommand)
            Using dr As New SafeDataReader(cmd.ExecuteReader())
                Fetch(dr)
            End Using
        End Sub

        ''' <summary>
        ''' Loads all <see cref="DocClassEditColl"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            While dr.Read()
                Add(DocClassEdit.GetDocClassEdit(dr))
            End While
            RaiseListChangedEvents = rlce
        End Sub

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="DocClassEditColl"/> object.
        ''' </summary>
        Protected Overrides Sub DataPortal_Update()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.DocStoreConnection, False)
                Child_Update()
                ctx.Commit()
            End Using
        End Sub

        #End Region

        #Region " DataPortal Hooks "

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

        #End Region

    End Class
End Namespace