//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    UserAllNVL
// ObjectType:  UserAllNVL
// CSLAType:    NameValueList

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using DocStore.Business.Util;
using Csla.Rules;
using Csla.Rules.CommonRules;

namespace DocStore.Business.Admin
{

    /// <summary>
    /// All users (regardless of active status) (name value list).<br/>
    /// This is a generated base class of <see cref="UserAllNVL"/> business object.
    /// </summary>
    [Serializable]
    public partial class UserAllNVL : NameValueListBase<int, string>
    {

        #region Private Fields

        private static UserAllNVL _list;

        #endregion

        #region Cache Management Methods

        /// <summary>
        /// Clears the in-memory UserAllNVL cache so it is reloaded on the next request.
        /// </summary>
        public static void InvalidateCache()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to load a UserAllNVL.");

            _list = null;
        }

        /// <summary>
        /// Used by async loaders to load the cache.
        /// </summary>
        /// <param name="list">The list to cache.</param>
        internal static void SetCache(UserAllNVL list)
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
        /// Factory method. Loads a <see cref="UserAllNVL"/> object.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="UserAllNVL"/> object.</returns>
        public static UserAllNVL GetUserAllNVL()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to load a UserAllNVL.");

            if (_list == null)
                _list = DataPortal.Fetch<UserAllNVL>();

            return _list;
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="UserAllNVL"/> object.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void GetUserAllNVL(EventHandler<DataPortalResult<UserAllNVL>> callback)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to load a UserAllNVL.");

            if (_list == null)
                DataPortal.BeginFetch<UserAllNVL>((o, e) =>
                    {
                        _list = e.Object;
                        callback(o, e);
                    });
            else
                callback(null, new DataPortalResult<UserAllNVL>(_list, null, null));
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAllNVL"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public UserAllNVL()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Object Authorization

        /// <summary>
        /// Adds the object authorization rules.
        /// </summary>
        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof (UserAllNVL), new IsInRole(AuthorizationActions.GetObject, "User"));

            AddObjectAuthorizationRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom object authorization rules.
        /// </summary>
        static partial void AddObjectAuthorizationRulesExtend();

        /// <summary>
        /// Checks if the current user can retrieve UserAllNVL's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        public static bool CanGetObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, typeof(UserAllNVL));
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="UserAllNVL"/> collection from the database or from the cache.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            if (IsCached)
            {
                LoadCachedList();
                return;
            }

            using (var cn = new SqlConnection(Database.DocStoreConnection))
            {
                using (var cmd = new SqlCommand("GetUserAllNVL", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
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
