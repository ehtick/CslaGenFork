using System;
using Csla;
using SelfLoadRO.DataAccess;
using SelfLoadRO.DataAccess.ERCLevel;

namespace SelfLoadRO.Business.ERCLevel
{

    /// <summary>
    /// D03_Continent_ReChild (read only object).<br/>
    /// This is a generated base class of <see cref="D03_Continent_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="D02_Continent"/> collection.
    /// </remarks>
    [Serializable]
    public partial class D03_Continent_ReChild : ReadOnlyBase<D03_Continent_ReChild>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Continent_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Continent_Child_NameProperty = RegisterProperty<string>(p => p.Continent_Child_Name, "SubContinents Child Name");
        /// <summary>
        /// Gets the SubContinents Child Name.
        /// </summary>
        /// <value>The SubContinents Child Name.</value>
        public string Continent_Child_Name
        {
            get { return GetProperty(Continent_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="D03_Continent_ReChild"/> object, based on given parameters.
        /// </summary>
        /// <param name="continent_ID2">The Continent_ID2 parameter of the D03_Continent_ReChild to fetch.</param>
        /// <returns>A reference to the fetched <see cref="D03_Continent_ReChild"/> object.</returns>
        internal static D03_Continent_ReChild GetD03_Continent_ReChild(int continent_ID2)
        {
            return DataPortal.FetchChild<D03_Continent_ReChild>(continent_ID2);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D03_Continent_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public D03_Continent_ReChild()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="D03_Continent_ReChild"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="continent_ID2">The Continent ID2.</param>
        protected void Child_Fetch(int continent_ID2)
        {
            var args = new DataPortalHookArgs(continent_ID2);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadRO.GetManager())
            {
                var dal = dalManager.GetProvider<ID03_Continent_ReChildDal>();
                var data = dal.Fetch(continent_ID2);
                Fetch(data);
            }
            OnFetchPost(args);
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        /// <summary>
        /// Loads a <see cref="D03_Continent_ReChild"/> object from the given <see cref="D03_Continent_ReChildDto"/>.
        /// </summary>
        /// <param name="data">The D03_Continent_ReChildDto to use.</param>
        private void Fetch(D03_Continent_ReChildDto data)
        {
            // Value properties
            LoadProperty(Continent_Child_NameProperty, data.Continent_Child_Name);
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
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

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
