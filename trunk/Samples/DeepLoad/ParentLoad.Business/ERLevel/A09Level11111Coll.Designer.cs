using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoad.Business.ERLevel
{

    /// <summary>
    /// A09Level11111Coll (editable child list).<br/>
    /// This is a generated base class of <see cref="A09Level11111Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="A08Level1111"/> editable child object.<br/>
    /// The items of the collection are <see cref="A10Level11111"/> objects.
    /// </remarks>
    [Serializable]
    public partial class A09Level11111Coll : BusinessListBase<A09Level11111Coll, A10Level11111>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="A10Level11111"/> item from the collection.
        /// </summary>
        /// <param name="level_1_1_1_1_1_ID">The Level_1_1_1_1_1_ID of the item to be removed.</param>
        public void Remove(int level_1_1_1_1_1_ID)
        {
            foreach (A10Level11111 a10Level11111 in this)
            {
                if (a10Level11111.Level_1_1_1_1_1_ID == level_1_1_1_1_1_ID)
                {
                      Remove(a10Level11111);
                      break;
                }
            }
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="A10Level11111"/> item of the <see cref="A09Level11111Coll"/> collection, based on item key properties.
        /// </summary>
        /// <param name="level_1_1_1_1_1_ID">The Level_1_1_1_1_1_ID.</param>
        /// <returns>A <see cref="A10Level11111"/> object.</returns>
        public A10Level11111 FindA10Level11111ByParentProperties(int level_1_1_1_1_1_ID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].Level_1_1_1_1_1_ID.Equals(level_1_1_1_1_1_ID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="A09Level11111Coll"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="A09Level11111Coll"/> collection.</returns>
        internal static A09Level11111Coll NewA09Level11111Coll()
        {
            return DataPortal.CreateChild<A09Level11111Coll>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="A09Level11111Coll"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="A09Level11111Coll"/> object.</returns>
        internal static A09Level11111Coll GetA09Level11111Coll(SafeDataReader dr)
        {
            A09Level11111Coll obj = new A09Level11111Coll();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A09Level11111Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private A09Level11111Coll()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();

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
        /// Loads all <see cref="A09Level11111Coll"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(dr);
            OnFetchPre(args);
            while (dr.Read())
            {
                Add(A10Level11111.GetA10Level11111(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Loads <see cref="A10Level11111"/> items on the A09Level11111Objects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="A07Level1111Coll"/> collection.</param>
        internal void LoadItems(A07Level1111Coll collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindA08Level1111ByParentProperties(item.narentID1);
                var rlce = obj.A09Level11111Objects.RaiseListChangedEvents;
                obj.A09Level11111Objects.RaiseListChangedEvents = false;
                obj.A09Level11111Objects.Add(item);
                obj.A09Level11111Objects.RaiseListChangedEvents = rlce;
            }
        }

        #endregion

        #region Pseudo Events

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