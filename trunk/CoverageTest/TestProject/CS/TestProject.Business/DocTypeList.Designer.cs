using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Rules;
using Csla.Rules.CommonRules;
using UsingLibrary;

namespace TestProject.Business
{

    /// <summary>
    /// Collection of document type's basic information (read only list).<br/>
    /// This is a generated <see cref="DocTypeList"/> business object.
    /// This class is a root collection.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="DocTypeInfo"/> objects.
    /// This is a remark
    /// </remarks>
    [Attributable]
    [Serializable]
    public partial class DocTypeList : ReadOnlyBindingListBase<DocTypeList, DocTypeInfo>, IHaveInterface
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="DocTypeInfo"/> item is in the collection.
        /// </summary>
        /// <param name="docTypeID">The DocTypeID of the item to search for.</param>
        /// <returns><c>true</c> if the DocTypeInfo is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int docTypeID)
        {
            foreach (var docTypeInfo in this)
            {
                if (docTypeInfo.DocTypeID == docTypeID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="DocTypeInfo"/> item of the <see cref="DocTypeList"/> collection, based on a given DocTypeID.
        /// </summary>
        /// <param name="docTypeID">The DocTypeID.</param>
        /// <returns>A <see cref="DocTypeInfo"/> object.</returns>
        public DocTypeInfo FindDocTypeInfoByDocTypeID(int docTypeID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].DocTypeID.Equals(docTypeID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Private Fields

        private static DocTypeList _list;

        #endregion

        #region Cache Management Methods

        /// <summary>
        /// Clears the in-memory DocTypeList cache so it is reloaded on the next request.
        /// </summary>
        public static void InvalidateCache()
        {
            _list = null;
        }

        /// <summary>
        /// Used by async loaders to load the cache.
        /// </summary>
        /// <param name="list">The list to cache.</param>
        internal static void SetCache(DocTypeList list)
        {
            _list = list;
        }

        internal static bool IsCached
        {
            get { return _list != null; }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="DocTypeList"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="DocTypeList"/> collection.</returns>
        public static DocTypeList GetDocTypeList()
        {
            if (_list == null)
                _list = DataPortal.Fetch<DocTypeList>();

            return _list;
        }

        /// <summary>
        /// Factory method. Loads a <see cref="DocTypeList"/> collection, based on given parameters.
        /// </summary>
        /// <param name="docTypeName">The DocTypeName parameter of the DocTypeList to fetch.</param>
        /// <returns>A reference to the fetched <see cref="DocTypeList"/> collection.</returns>
        public static DocTypeList GetDocTypeList(string docTypeName)
        {
            return DataPortal.Fetch<DocTypeList>(docTypeName);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocTypeList"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocTypeList()
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

        #region Object Authorization

        /// <summary>
        /// Adds the object authorization rules.
        /// </summary>
        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof (DocTypeList), new IsInRole(AuthorizationActions.GetObject, "User"));

            AddObjectAuthorizationRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom object authorization rules.
        /// </summary>
        static partial void AddObjectAuthorizationRulesExtend();

        /// <summary>
        /// Checks if the current user can retrieve DocTypeList's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        public static bool CanGetObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, typeof(DocTypeList));
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="DocTypeList"/> collection from the database or from the cache.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            if (IsCached)
            {
                LoadCachedList();
                return;
            }

            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.TestProjectConnection, false))
            {
                using (var cmd = new SqlCommand("GetDocTypeList", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var args = new DataPortalHookArgs(cmd);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
            _list = this;
        }

        private void LoadCachedList()
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AddRange(_list);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        /// <summary>
        /// Loads a <see cref="DocTypeList"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="docTypeName">The Doc Type Name.</param>
        protected void DataPortal_Fetch(string docTypeName)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.TestProjectConnection, false))
            {
                using (var cmd = new SqlCommand("GetDocTypeList", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocTypeName", docTypeName).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd, docTypeName);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
        }

        private void LoadCollection(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                Fetch(dr);
            }
        }

        /// <summary>
        /// Loads all <see cref="DocTypeList"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(DataPortal.FetchChild<DocTypeInfo>(dr));
            }
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
