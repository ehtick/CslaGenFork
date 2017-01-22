//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    DocContentList
// ObjectType:  DocContentList
// CSLAType:    ReadOnlyCollection

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using DocStore.Business.Util;
using UsingLibrary;

namespace DocStore.Business
{

    /// <summary>
    /// Collection of contents of this document (read only list).<br/>
    /// This is a generated base class of <see cref="DocContentList"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="Doc"/> editable root object.<br/>
    /// The items of the collection are <see cref="DocContentInfo"/> objects.
    /// </remarks>
    [Serializable]
    public partial class DocContentList : ReadOnlyBindingListBase<DocContentList, DocContentInfo>, IHaveInterface, IHaveGenericInterface<DocContentList>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="DocContentInfo"/> item is in the collection.
        /// </summary>
        /// <param name="docContentID">The DocContentID of the item to search for.</param>
        /// <returns><c>true</c> if the DocContentInfo is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int docContentID)
        {
            foreach (var docContentInfo in this)
            {
                if (docContentInfo.DocContentID == docContentID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="DocContentList"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="DocContentList"/> object.</returns>
        internal static DocContentList GetDocContentList(SafeDataReader dr)
        {
            DocContentList obj = new DocContentList();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocContentList"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocContentList()
        {
            // Use factory methods and do not use direct creation.

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = false;
            AllowEdit = false;
            AllowRemove = false;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads all <see cref="DocContentList"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(dr);
            OnFetchPre(args);
            while (dr.Read())
            {
                Add(DocContentInfo.GetDocContentInfo(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        #endregion

    }
}
