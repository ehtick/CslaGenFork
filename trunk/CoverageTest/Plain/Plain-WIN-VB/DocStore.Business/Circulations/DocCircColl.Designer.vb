'  This file was generated by CSLA Object Generator - CslaGenFork v4.5
'
' Filename:    DocCircColl
' ObjectType:  DocCircColl
' CSLAType:    EditableChildCollection

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports DocStore.Business.Util
Imports Csla.Rules
Imports Csla.Rules.CommonRules

Namespace DocStore.Business.Circulations

    ''' <summary>
    ''' Collection of circulations of this document (editable child list).<br/>
    ''' This is a generated base class of <see cref="DocCircColl"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is child of <see cref="Doc"/> editable root object.<br/>
    ''' The items of the collection are <see cref="DocCirc"/> objects.
    ''' </remarks>
    <Serializable()>
    Partial Public Class DocCircColl
#If WINFORMS Then
        Inherits BusinessBindingListBase(Of DocCircColl, DocCirc)
#Else
        Inherits BusinessListBase(Of DocCircColl, DocCirc)
#End If
    
        #Region " Collection Business Methods "

        ''' <summary>
        ''' Adds a new <see cref="DocCirc"/> item to the collection.
        ''' </summary>
        ''' <param name="item">The item to add.</param>
        ''' <exception cref="ArgumentException">if the item already exists in the collection.</exception>
        Public Overloads Sub Add(item As DocCirc)
            If Contains(item.CircID) Then
                Throw New ArgumentException("DocCirc already exists.")
            End If

            Add(item)
        End Sub

        ''' <summary>
        ''' Adds a new <see cref="DocCirc"/> item to the collection.
        ''' </summary>
        ''' <returns>The new DocCirc item added to the collection.</returns>
        Public Overloads Function Add() As DocCirc
            Dim item = DocCirc.NewDocCirc()
            Add(item)
            Return item
        End Function

        ''' <summary>
        ''' Asynchronously adds a new <see cref="DocCirc"/> item to the collection.
        ''' </summary>
        Public Sub BeginAdd()
            Dim docCirc As DocCirc = Nothing
            DocCirc.NewDocCirc(Sub(o, e)
                    If e.Error IsNot Nothing Then
                        Throw e.Error
                    Else
                        docCirc = e.Object
                    End If
                End Sub)
            Add(docCirc)
        End Sub

        ''' <summary>
        ''' Removes a <see cref="DocCirc"/> item from the collection.
        ''' </summary>
        ''' <param name="circID">The CircID of the item to be removed.</param>
        Public Overloads Sub Remove(circID As Integer)
            For Each item As DocCirc In Me
                If item.CircID = circID Then
                    MyBase.Remove(item)
                    Exit For
                End If
            Next
        End Sub

        ''' <summary>
        ''' Determines whether a <see cref="DocCirc"/> item is in the collection.
        ''' </summary>
        ''' <param name="circID">The CircID of the item to search for.</param>
        ''' <returns><c>True</c> if the DocCirc is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(circID As Integer) As Boolean
            For Each item As DocCirc In Me
                If item.CircID = circID Then
                    Return True
                End If
            Next
            Return False
        End Function

        ''' <summary>
        ''' Determines whether a <see cref="DocCirc"/> item is in the collection's DeletedList.
        ''' </summary>
        ''' <param name="circID">The CircID of the item to search for.</param>
        ''' <returns><c>True</c> if the DocCirc is a deleted collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function ContainsDeleted(circID As Integer) As Boolean
            For Each item As DocCirc In DeletedList
                If item.CircID = circID Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="DocCircColl"/> collection.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="DocCircColl"/> collection.</returns>
        Friend Shared Function NewDocCircColl() As DocCircColl
            Return DataPortal.CreateChild(Of DocCircColl)()
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="DocCircColl"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        ''' <returns>A reference to the fetched <see cref="DocCircColl"/> object.</returns>
        Friend Shared Function GetDocCircColl(dr As SafeDataReader) As DocCircColl
            If Not CanGetObject()
                Throw New System.Security.SecurityException("User not authorized to load a DocCircColl.")
        End If

            Dim obj As DocCircColl = New DocCircColl()
            ' show the framework that this is a child object
            obj.MarkAsChild()
            obj.Fetch(dr)
            Return obj
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="DocCircColl"/> collection.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Friend Shared Sub NewDocCircColl(callback As EventHandler(Of DataPortalResult(Of DocCircColl)))
            DataPortal.BeginCreate(Of DocCircColl)(callback)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocCircColl"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.

            ' show the framework that this is a child object
            MarkAsChild()

            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            AllowNew = True
            AllowEdit = True
            AllowRemove = True
            RaiseListChangedEvents = rlce
        End Sub

        #End Region

        #Region " Object Authorization "

        ''' <summary>
        ''' Adds the object authorization rules.
        ''' </summary>
        Protected Shared Sub AddObjectAuthorizationRules()
            BusinessRules.AddRule(GetType(DocCircColl), New IsInRole(AuthorizationActions.GetObject, "User"))

            AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Allows the set up of custom object authorization rules.
        ''' </summary>
        Partial Private Shared Sub AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Checks if the current user can create a new DocCircColl object.
        ''' </summary>
        ''' <returns><c>True</c> if the user can create a new object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanAddObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.CreateObject, GetType(DocCircColl))
        End Function

        ''' <summary>
        ''' Checks if the current user can retrieve DocCircColl's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanGetObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, GetType(DocCircColl))
        End Function

        ''' <summary>
        ''' Checks if the current user can change DocCircColl's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can update the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanEditObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.EditObject, GetType(DocCircColl))
        End Function

        ''' <summary>
        ''' Checks if the current user can delete a DocCircColl object.
        ''' </summary>
        ''' <returns><c>True</c> if the user can delete the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanDeleteObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.DeleteObject, GetType(DocCircColl))
        End Function

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads all <see cref="DocCircColl"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            Dim args As New DataPortalHookArgs(dr)
            OnFetchPre(args)
            While dr.Read()
                Add(DocCirc.GetDocCirc(dr))
            End While
            OnFetchPost(args)
            RaiseListChangedEvents = rlce
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