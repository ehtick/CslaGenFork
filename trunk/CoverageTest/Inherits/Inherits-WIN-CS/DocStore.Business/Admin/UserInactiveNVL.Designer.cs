//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    UserInactiveNVL
// ObjectType:  UserInactiveNVL
// CSLAType:    NameValueList

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using DocStore.Business.Util;

namespace DocStore.Business.Admin
{

    /// <summary>
    /// Inactive users (name value list).<br/>
    /// This is a generated <see cref="UserInactiveNVL"/> business object.
    /// </summary>
    [Serializable]
    public partial class UserInactiveNVL : NameValueListBase<int, string>
    {

        #region Private Fields

        private static UserInactiveNVL _list;

        #endregion

        #region Cache Management Methods

        /// <summary>
        /// Clears the in-memory UserInactiveNVL cache so it is reloaded on the next request.
        /// </summary>
        public static void InvalidateCache()
        {
            _list = null;
        }

        /// <summary>
        /// Used by async loaders to load the cache.
        /// </summary>
        /// <param name="list">The list to cache.</param>
        internal static void SetCache(UserInactiveNVL list)
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
        /// Factory method. Loads a <see cref="UserInactiveNVL"/> object.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="UserInactiveNVL"/> object.</returns>
        public static UserInactiveNVL GetUserInactiveNVL()
        {
            if (_list == null)
                _list = DataPortal.Fetch<UserInactiveNVL>(false);

            return _list;
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="UserInactiveNVL"/> object.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void GetUserInactiveNVL(EventHandler<DataPortalResult<UserInactiveNVL>> callback)
        {
            if (_list == null)
                DataPortal.BeginFetch<UserInactiveNVL>(false, (o, e) =>
                    {
                        _list = e.Object;
                        callback(o, e);
                    });
            else
                callback(null, new DataPortalResult<UserInactiveNVL>(_list, null, null));
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UserInactiveNVL"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public UserInactiveNVL()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="UserInactiveNVL"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="isActive">The Is Active.</param>
        protected void DataPortal_Fetch(bool isActive)
        {
            using (var cn = new SqlConnection(Database.DocStoreConnection))
            {
                using (var cmd = new SqlCommand("GetUserInactiveNVL", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IsActive", isActive).DbType = DbType.Boolean;
                    cn.Open();
                    var args = new DataPortalHookArgs(cmd, isActive);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
        }

        private void LoadCollection(SqlCommand cmd)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                while (dr.Read())
                {
                    Add(new NameValuePair(
                        dr.GetInt32("UserID"),
                        dr.GetString("Name")));
                }
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
