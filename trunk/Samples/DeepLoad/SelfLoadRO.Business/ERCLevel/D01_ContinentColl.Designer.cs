using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadRO.Business.ERCLevel
{

    /// <summary>
    /// D01_ContinentColl (read only list).<br/>
    /// This is a generated base class of <see cref="D01_ContinentColl"/> business object.
    /// This class is a root collection.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="D02_Continent"/> objects.
    /// </remarks>
    [Serializable]
    public partial class D01_ContinentColl : ReadOnlyListBase<D01_ContinentColl, D02_Continent>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="D02_Continent"/> item is in the collection.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID of the item to search for.</param>
        /// <returns><c>true</c> if the D02_Continent is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int continent_ID)
        {
            foreach (var d02_Continent in this)
            {
                if (d02_Continent.Continent_ID == continent_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="D02_Continent"/> item of the <see cref="D01_ContinentColl"/> collection, based on a given Continent_ID.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID.</param>
        /// <returns>A <see cref="D02_Continent"/> object.</returns>
        public D02_Continent FindD02_ContinentByContinent_ID(int continent_ID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].Continent_ID.Equals(continent_ID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="D01_ContinentColl"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="D01_ContinentColl"/> collection.</returns>
        public static D01_ContinentColl GetD01_ContinentColl()
        {
            return DataPortal.Fetch<D01_ContinentColl>();
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D01_ContinentColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public D01_ContinentColl()
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
        /// Loads a <see cref="D01_ContinentColl"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD01_ContinentColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var args = new DataPortalHookArgs(cmd);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
            foreach (var item in this)
            {
                item.FetchChildren();
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
        /// Loads all <see cref="D01_ContinentColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(D02_Continent.GetD02_Continent(dr));
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
