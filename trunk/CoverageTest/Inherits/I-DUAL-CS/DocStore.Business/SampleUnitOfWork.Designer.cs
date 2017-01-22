//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    SampleUnitOfWork
// ObjectType:  SampleUnitOfWork
// CSLAType:    UnitOfWork

using System;
using Csla;
using UsingLibrary;

namespace DocStore.Business
{

    /// <summary>
    /// SampleUnitOfWork (creator and getter unit of work pattern).<br/>
    /// This is a generated base class of <see cref="SampleUnitOfWork"/> business object.
    /// This class is a root object that implements the Unit of Work pattern.
    /// </summary>
    [Serializable]
    public partial class SampleUnitOfWork : MyReadOnlyBase<SampleUnitOfWork>, IHaveInterface, IHaveGenericInterface<SampleUnitOfWork>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about unit of work (child) <see cref="Doc"/> property.
        /// </summary>
        public static readonly PropertyInfo<Doc> DocProperty = RegisterProperty<Doc>(p => p.Doc, "Doc");
        /// <summary>
        /// Gets the Doc object (unit of work child property).
        /// </summary>
        /// <value>The Doc.</value>
        public Doc Doc
        {
            get { return GetProperty(DocProperty); }
            private set { LoadProperty(DocProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about unit of work (child) <see cref="Folder"/> property.
        /// </summary>
        public static readonly PropertyInfo<Folder> FolderProperty = RegisterProperty<Folder>(p => p.Folder, "Folder");
        /// <summary>
        /// Gets the Folder object (unit of work child property).
        /// </summary>
        /// <value>The Folder.</value>
        public Folder Folder
        {
            get { return GetProperty(FolderProperty); }
            private set { LoadProperty(FolderProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about unit of work (child) <see cref="DocList"/> property.
        /// </summary>
        public static readonly PropertyInfo<DocList> DocListProperty = RegisterProperty<DocList>(p => p.DocList, "Doc List");
        /// <summary>
        /// Gets the Doc List object (unit of work child property).
        /// </summary>
        /// <value>The Doc List.</value>
        public DocList DocList
        {
            get { return GetProperty(DocListProperty); }
            private set { LoadProperty(DocListProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="SampleUnitOfWork"/> unit of objects.
        /// </summary>
        /// <returns>A reference to the created <see cref="SampleUnitOfWork"/> unit of objects.</returns>
        public static SampleUnitOfWork NewSampleUnitOfWork()
        {
            // DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            return DataPortal.Fetch<SampleUnitOfWork>(new Criteria1(true, new int(), true, new int()));
        }

        /// <summary>
        /// Factory method. Creates a new <see cref="SampleUnitOfWork"/> unit of objects, based on given parameters.
        /// </summary>
        /// <param name="docListFilteredCriteria">The DocListFilteredCriteria of the SampleUnitOfWork to create.</param>
        /// <returns>A reference to the created <see cref="SampleUnitOfWork"/> unit of objects.</returns>
        public static SampleUnitOfWork NewSampleUnitOfWork(DocListFilteredCriteria docListFilteredCriteria)
        {
            // DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            return DataPortal.Fetch<SampleUnitOfWork>(new Criteria2(true, new int(), true, new int(), docListFilteredCriteria));
        }

        /// <summary>
        /// Factory method. Loads a <see cref="SampleUnitOfWork"/> unit of objects, based on given parameters.
        /// </summary>
        /// <param name="docID">The DocID parameter of the SampleUnitOfWork to fetch.</param>
        /// <param name="folderID">The FolderID parameter of the SampleUnitOfWork to fetch.</param>
        /// <returns>A reference to the fetched <see cref="SampleUnitOfWork"/> unit of objects.</returns>
        public static SampleUnitOfWork GetSampleUnitOfWork(int docID, int folderID)
        {
            return DataPortal.Fetch<SampleUnitOfWork>(new Criteria1(false, docID, false, folderID));
        }

        /// <summary>
        /// Factory method. Loads a <see cref="SampleUnitOfWork"/> unit of objects, based on given parameters.
        /// </summary>
        /// <param name="docID">The DocID parameter of the SampleUnitOfWork to fetch.</param>
        /// <param name="folderID">The FolderID parameter of the SampleUnitOfWork to fetch.</param>
        /// <param name="docListFilteredCriteria">The DocListFilteredCriteria parameter of the SampleUnitOfWork to fetch.</param>
        /// <returns>A reference to the fetched <see cref="SampleUnitOfWork"/> unit of objects.</returns>
        public static SampleUnitOfWork GetSampleUnitOfWork(int docID, int folderID, DocListFilteredCriteria docListFilteredCriteria)
        {
            return DataPortal.Fetch<SampleUnitOfWork>(new Criteria2(false, docID, false, folderID, docListFilteredCriteria));
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="SampleUnitOfWork"/> unit of objects.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void NewSampleUnitOfWork(EventHandler<DataPortalResult<SampleUnitOfWork>> callback)
        {
            // DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            DataPortal.BeginFetch<SampleUnitOfWork>(new Criteria1(true, new int(), true, new int()), (o, e) =>
            {
                if (e.Error != null)
                    throw e.Error;
                callback(o, e);
            });
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="SampleUnitOfWork"/> unit of objects, based on given parameters.
        /// </summary>
        /// <param name="docListFilteredCriteria">The DocListFilteredCriteria of the SampleUnitOfWork to create.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void NewSampleUnitOfWork(DocListFilteredCriteria docListFilteredCriteria, EventHandler<DataPortalResult<SampleUnitOfWork>> callback)
        {
            // DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            DataPortal.BeginFetch<SampleUnitOfWork>(new Criteria2(true, new int(), true, new int(), docListFilteredCriteria), (o, e) =>
            {
                if (e.Error != null)
                    throw e.Error;
                callback(o, e);
            });
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="SampleUnitOfWork"/> unit of objects, based on given parameters.
        /// </summary>
        /// <param name="docID">The DocID parameter of the SampleUnitOfWork to fetch.</param>
        /// <param name="folderID">The FolderID parameter of the SampleUnitOfWork to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetSampleUnitOfWork(int docID, int folderID, EventHandler<DataPortalResult<SampleUnitOfWork>> callback)
        {
            DataPortal.BeginFetch<SampleUnitOfWork>(new Criteria1(false, docID, false, folderID), (o, e) =>
            {
                if (e.Error != null)
                    throw e.Error;
                callback(o, e);
            });
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="SampleUnitOfWork"/> unit of objects, based on given parameters.
        /// </summary>
        /// <param name="docID">The DocID parameter of the SampleUnitOfWork to fetch.</param>
        /// <param name="folderID">The FolderID parameter of the SampleUnitOfWork to fetch.</param>
        /// <param name="docListFilteredCriteria">The DocListFilteredCriteria parameter of the SampleUnitOfWork to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetSampleUnitOfWork(int docID, int folderID, DocListFilteredCriteria docListFilteredCriteria, EventHandler<DataPortalResult<SampleUnitOfWork>> callback)
        {
            DataPortal.BeginFetch<SampleUnitOfWork>(new Criteria2(false, docID, false, folderID, docListFilteredCriteria), (o, e) =>
            {
                if (e.Error != null)
                    throw e.Error;
                callback(o, e);
            });
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SampleUnitOfWork"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Unit of Work. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public SampleUnitOfWork()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Criteria

        /// <summary>
        /// Criteria1 criteria.
        /// </summary>
        [Serializable]
        protected class Criteria1 : CriteriaBase<Criteria1>
        {

            /// <summary>
            /// Maintains metadata about <see cref="CreateDoc"/> property.
            /// </summary>
            public static readonly PropertyInfo<bool> CreateDocProperty = RegisterProperty<bool>(p => p.CreateDoc, "Create Doc");
            /// <summary>
            /// Gets or sets the Create Doc.
            /// </summary>
            /// <value><c>true</c> if Create Doc; otherwise, <c>false</c>.</value>
            public bool CreateDoc
            {
                get { return ReadProperty(CreateDocProperty); }
                set { LoadProperty(CreateDocProperty, value); }
            }

            /// <summary>
            /// Maintains metadata about <see cref="DocID"/> property.
            /// </summary>
            public static readonly PropertyInfo<int> DocIDProperty = RegisterProperty<int>(p => p.DocID, "Doc ID");
            /// <summary>
            /// Gets or sets the Doc ID.
            /// </summary>
            /// <value>The Doc ID.</value>
            public int DocID
            {
                get { return ReadProperty(DocIDProperty); }
                set { LoadProperty(DocIDProperty, value); }
            }

            /// <summary>
            /// Maintains metadata about <see cref="CreateFolder"/> property.
            /// </summary>
            public static readonly PropertyInfo<bool> CreateFolderProperty = RegisterProperty<bool>(p => p.CreateFolder, "Create Folder");
            /// <summary>
            /// Gets or sets the Create Folder.
            /// </summary>
            /// <value><c>true</c> if Create Folder; otherwise, <c>false</c>.</value>
            public bool CreateFolder
            {
                get { return ReadProperty(CreateFolderProperty); }
                set { LoadProperty(CreateFolderProperty, value); }
            }

            /// <summary>
            /// Maintains metadata about <see cref="FolderID"/> property.
            /// </summary>
            public static readonly PropertyInfo<int> FolderIDProperty = RegisterProperty<int>(p => p.FolderID, "Folder ID");
            /// <summary>
            /// Gets or sets the Folder ID.
            /// </summary>
            /// <value>The Folder ID.</value>
            public int FolderID
            {
                get { return ReadProperty(FolderIDProperty); }
                set { LoadProperty(FolderIDProperty, value); }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Criteria1"/> class.
            /// </summary>
            /// <remarks> A parameterless constructor is required by the MobileFormatter.</remarks>
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public Criteria1()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Criteria1"/> class.
            /// </summary>
            /// <param name="createDoc">The CreateDoc.</param>
            /// <param name="docID">The DocID.</param>
            /// <param name="createFolder">The CreateFolder.</param>
            /// <param name="folderID">The FolderID.</param>
            public Criteria1(bool createDoc, int docID, bool createFolder, int folderID)
            {
                CreateDoc = createDoc;
                DocID = docID;
                CreateFolder = createFolder;
                FolderID = folderID;
            }

            /// <summary>
            /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
            /// </summary>
            /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
            /// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
            public override bool Equals(object obj)
            {
                if (obj is Criteria1)
                {
                    var c = (Criteria1) obj;
                    if (!CreateDoc.Equals(c.CreateDoc))
                        return false;
                    if (!DocID.Equals(c.DocID))
                        return false;
                    if (!CreateFolder.Equals(c.CreateFolder))
                        return false;
                    if (!FolderID.Equals(c.FolderID))
                        return false;
                    return true;
                }
                return false;
            }

            /// <summary>
            /// Returns a hash code for this instance.
            /// </summary>
            /// <returns>An hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
            public override int GetHashCode()
            {
                return string.Concat("Criteria1", CreateDoc.ToString(), DocID.ToString(), CreateFolder.ToString(), FolderID.ToString()).GetHashCode();
            }
        }

        /// <summary>
        /// Criteria2 criteria.
        /// </summary>
        [Serializable]
        protected class Criteria2 : CriteriaBase<Criteria2>
        {

            /// <summary>
            /// Maintains metadata about <see cref="CreateDoc"/> property.
            /// </summary>
            public static readonly PropertyInfo<bool> CreateDocProperty = RegisterProperty<bool>(p => p.CreateDoc, "Create Doc");
            /// <summary>
            /// Gets or sets the Create Doc.
            /// </summary>
            /// <value><c>true</c> if Create Doc; otherwise, <c>false</c>.</value>
            public bool CreateDoc
            {
                get { return ReadProperty(CreateDocProperty); }
                set { LoadProperty(CreateDocProperty, value); }
            }

            /// <summary>
            /// Maintains metadata about <see cref="DocID"/> property.
            /// </summary>
            public static readonly PropertyInfo<int> DocIDProperty = RegisterProperty<int>(p => p.DocID, "Doc ID");
            /// <summary>
            /// Gets or sets the Doc ID.
            /// </summary>
            /// <value>The Doc ID.</value>
            public int DocID
            {
                get { return ReadProperty(DocIDProperty); }
                set { LoadProperty(DocIDProperty, value); }
            }

            /// <summary>
            /// Maintains metadata about <see cref="CreateFolder"/> property.
            /// </summary>
            public static readonly PropertyInfo<bool> CreateFolderProperty = RegisterProperty<bool>(p => p.CreateFolder, "Create Folder");
            /// <summary>
            /// Gets or sets the Create Folder.
            /// </summary>
            /// <value><c>true</c> if Create Folder; otherwise, <c>false</c>.</value>
            public bool CreateFolder
            {
                get { return ReadProperty(CreateFolderProperty); }
                set { LoadProperty(CreateFolderProperty, value); }
            }

            /// <summary>
            /// Maintains metadata about <see cref="FolderID"/> property.
            /// </summary>
            public static readonly PropertyInfo<int> FolderIDProperty = RegisterProperty<int>(p => p.FolderID, "Folder ID");
            /// <summary>
            /// Gets or sets the Folder ID.
            /// </summary>
            /// <value>The Folder ID.</value>
            public int FolderID
            {
                get { return ReadProperty(FolderIDProperty); }
                set { LoadProperty(FolderIDProperty, value); }
            }

            /// <summary>
            /// Maintains metadata about <see cref="DocListFilteredCriteria"/> property.
            /// </summary>
            public static readonly PropertyInfo<DocListFilteredCriteria> DocListFilteredCriteriaProperty = RegisterProperty<DocListFilteredCriteria>(p => p.DocListFilteredCriteria, "Doc List Filtered Criteria");
            /// <summary>
            /// Gets or sets the Doc List Filtered Criteria.
            /// </summary>
            /// <value>The Doc List Filtered Criteria.</value>
            public DocListFilteredCriteria DocListFilteredCriteria
            {
                get { return ReadProperty(DocListFilteredCriteriaProperty); }
                set { LoadProperty(DocListFilteredCriteriaProperty, value); }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Criteria2"/> class.
            /// </summary>
            /// <remarks> A parameterless constructor is required by the MobileFormatter.</remarks>
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public Criteria2()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Criteria2"/> class.
            /// </summary>
            /// <param name="createDoc">The CreateDoc.</param>
            /// <param name="docID">The DocID.</param>
            /// <param name="createFolder">The CreateFolder.</param>
            /// <param name="folderID">The FolderID.</param>
            /// <param name="docListFilteredCriteria">The DocListFilteredCriteria.</param>
            public Criteria2(bool createDoc, int docID, bool createFolder, int folderID, DocListFilteredCriteria docListFilteredCriteria)
            {
                CreateDoc = createDoc;
                DocID = docID;
                CreateFolder = createFolder;
                FolderID = folderID;
                DocListFilteredCriteria = docListFilteredCriteria;
            }

            /// <summary>
            /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
            /// </summary>
            /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
            /// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
            public override bool Equals(object obj)
            {
                if (obj is Criteria2)
                {
                    var c = (Criteria2) obj;
                    if (!CreateDoc.Equals(c.CreateDoc))
                        return false;
                    if (!DocID.Equals(c.DocID))
                        return false;
                    if (!CreateFolder.Equals(c.CreateFolder))
                        return false;
                    if (!FolderID.Equals(c.FolderID))
                        return false;
                    if (!DocListFilteredCriteria.Equals(c.DocListFilteredCriteria))
                        return false;
                    return true;
                }
                return false;
            }

            /// <summary>
            /// Returns a hash code for this instance.
            /// </summary>
            /// <returns>An hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
            public override int GetHashCode()
            {
                return string.Concat("Criteria2", CreateDoc.ToString(), DocID.ToString(), CreateFolder.ToString(), FolderID.ToString(), DocListFilteredCriteria.ToString()).GetHashCode();
            }
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Creates or loads a <see cref="SampleUnitOfWork"/> unit of objects, based on given criteria.
        /// </summary>
        /// <param name="crit">The create/fetch criteria.</param>
        protected void DataPortal_Fetch(Criteria1 crit)
        {
            if (crit.CreateDoc)
                LoadProperty(DocProperty, Doc.NewDoc());
            else
                LoadProperty(DocProperty, Doc.GetDoc(crit.DocID));
            if (crit.CreateFolder)
                LoadProperty(FolderProperty, Folder.NewFolder());
            else
                LoadProperty(FolderProperty, Folder.GetFolder(crit.FolderID));
            LoadProperty(DocListProperty, DocList.GetDocList());
        }

        /// <summary>
        /// Creates or loads a <see cref="SampleUnitOfWork"/> unit of objects, based on given criteria.
        /// </summary>
        /// <param name="crit">The create/fetch criteria.</param>
        protected void DataPortal_Fetch(Criteria2 crit)
        {
            if (crit.CreateDoc)
                LoadProperty(DocProperty, Doc.NewDoc());
            else
                LoadProperty(DocProperty, Doc.GetDoc(crit.DocID));
            if (crit.CreateFolder)
                LoadProperty(FolderProperty, Folder.NewFolder());
            else
                LoadProperty(FolderProperty, Folder.GetFolder(crit.FolderID));
            LoadProperty(DocListProperty, DocList.GetDocList(crit.DocListFilteredCriteria));
        }

        #endregion

    }
}
