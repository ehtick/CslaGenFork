using System;
using System.Collections.Generic;
using Csla;
using ParentLoadROSoftDelete.DataAccess.ERLevel;

namespace ParentLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E03_SubContinentColl (read only list).<br/>
    /// This is a generated base class of <see cref="E03_SubContinentColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="E02_Continent"/> read only object.<br/>
    /// The items of the collection are <see cref="E04_SubContinent"/> objects.
    /// </remarks>
    [Serializable]
    public partial class E03_SubContinentColl : ReadOnlyListBase<E03_SubContinentColl, E04_SubContinent>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="E04_SubContinent"/> item is in the collection.
        /// </summary>
        /// <param name="subContinent_ID">The SubContinent_ID of the item to search for.</param>
        /// <returns><c>true</c> if the E04_SubContinent is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int subContinent_ID)
        {
            foreach (var e04_SubContinent in this)
            {
                if (e04_SubContinent.SubContinent_ID == subContinent_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="E04_SubContinent"/> item of the <see cref="E03_SubContinentColl"/> collection, based on item key properties.
        /// </summary>
        /// <param name="subContinent_ID">The SubContinent_ID.</param>
        /// <returns>A <see cref="E04_SubContinent"/> object.</returns>
        public E04_SubContinent FindE04_SubContinentByParentProperties(int subContinent_ID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].SubContinent_ID.Equals(subContinent_ID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="E03_SubContinentColl"/> object from the given list of E04_SubContinentDto.
        /// </summary>
        /// <param name="data">The list of <see cref="E04_SubContinentDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="E03_SubContinentColl"/> object.</returns>
        internal static E03_SubContinentColl GetE03_SubContinentColl(List<E04_SubContinentDto> data)
        {
            E03_SubContinentColl obj = new E03_SubContinentColl();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E03_SubContinentColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public E03_SubContinentColl()
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
        /// Loads all <see cref="E03_SubContinentColl"/> collection items from the given list of E04_SubContinentDto.
        /// </summary>
        /// <param name="data">The list of <see cref="E04_SubContinentDto"/>.</param>
        private void Fetch(List<E04_SubContinentDto> data)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(data);
            OnFetchPre(args);
            foreach (var dto in data)
            {
                Add(E04_SubContinent.GetE04_SubContinent(dto));
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
