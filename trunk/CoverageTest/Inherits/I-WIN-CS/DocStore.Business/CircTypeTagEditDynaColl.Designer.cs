//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    CircTypeTagEditDynaColl
// ObjectType:  CircTypeTagEditDynaColl
// CSLAType:    DynamicEditableRootCollection

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
    /// CircTypeTagEditDynaColl (dynamic root list).<br/>
    /// This is a generated base class of <see cref="CircTypeTagEditDynaColl"/> business object.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="CircTypeTagEditDyna"/> objects.
    /// </remarks>
    [Serializable]
    public partial class CircTypeTagEditDynaColl : MyDynamicBindingListBase<CircTypeTagEditDyna>, IHaveInterface, IHaveGenericInterface<CircTypeTagEditDynaColl>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="CircTypeTagEditDyna"/> item from the collection.
        /// </summary>
        /// <param name="circTypeID">The CircTypeID of the item to be removed.</param>
        public void Remove(int circTypeID)
        {
            foreach (var circTypeTagEditDyna in this)
            {
                if (circTypeTagEditDyna.CircTypeID == circTypeID)
                {
                    Remove(circTypeTagEditDyna);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="CircTypeTagEditDyna"/> item is in the collection.
        /// </summary>
        /// <param name="circTypeID">The CircTypeID of the item to search for.</param>
        /// <returns><c>true</c> if the CircTypeTagEditDyna is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int circTypeID)
        {
            foreach (var circTypeTagEditDyna in this)
            {
                if (circTypeTagEditDyna.CircTypeID == circTypeID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="CircTypeTagEditDynaColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="CircTypeTagEditDynaColl"/> collection.</returns>
        public static CircTypeTagEditDynaColl NewCircTypeTagEditDynaColl()
        {
            return DataPortal.Create<CircTypeTagEditDynaColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="CircTypeTagEditDynaColl"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="CircTypeTagEditDynaColl"/> collection.</returns>
        public static CircTypeTagEditDynaColl GetCircTypeTagEditDynaColl()
        {
            return DataPortal.Fetch<CircTypeTagEditDynaColl>();
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="CircTypeTagEditDynaColl"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void NewCircTypeTagEditDynaColl(EventHandler<DataPortalResult<CircTypeTagEditDynaColl>> callback)
        {
            DataPortal.BeginCreate<CircTypeTagEditDynaColl>(callback);
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="CircTypeTagEditDynaColl"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void GetCircTypeTagEditDynaColl(EventHandler<DataPortalResult<CircTypeTagEditDynaColl>> callback)
        {
            DataPortal.BeginFetch<CircTypeTagEditDynaColl>(callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CircTypeTagEditDynaColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public CircTypeTagEditDynaColl()
        {
            // Use factory methods and do not use direct creation.

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = true;
            AllowEdit = true;
            AllowRemove = true;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="CircTypeTagEditDynaColl"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("GetCircTypeTagEditDynaColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var args = new DataPortalHookArgs(cmd);
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
        /// Loads all <see cref="CircTypeTagEditDynaColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(CircTypeTagEditDyna.GetCircTypeTagEditDyna(dr));
            }
            RaiseListChangedEvents = rlce;
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