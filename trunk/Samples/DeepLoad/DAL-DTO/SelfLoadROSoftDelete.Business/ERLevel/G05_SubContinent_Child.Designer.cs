using System;
using Csla;
using SelfLoadROSoftDelete.DataAccess;
using SelfLoadROSoftDelete.DataAccess.ERLevel;

namespace SelfLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G05_SubContinent_Child (read only object).<br/>
    /// This is a generated base class of <see cref="G05_SubContinent_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="G04_SubContinent"/> collection.
    /// </remarks>
    [Serializable]
    public partial class G05_SubContinent_Child : ReadOnlyBase<G05_SubContinent_Child>
    {

        #region State Fields

        [NotUndoable]
        private byte[] _rowVersion = new byte[] {};

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubContinent_Child_NameProperty = RegisterProperty<string>(p => p.SubContinent_Child_Name, "3_Countries Child Name");
        /// <summary>
        /// Gets the 3_Countries Child Name.
        /// </summary>
        /// <value>The 3_Countries Child Name.</value>
        public string SubContinent_Child_Name
        {
            get { return GetProperty(SubContinent_Child_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_ID1"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> SubContinent_ID1Property = RegisterProperty<int>(p => p.SubContinent_ID1, "SubContinent ID1");
        /// <summary>
        /// Gets the SubContinent ID1.
        /// </summary>
        /// <value>The SubContinent ID1.</value>
        public int SubContinent_ID1
        {
            get { return GetProperty(SubContinent_ID1Property); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="G05_SubContinent_Child"/> object, based on given parameters.
        /// </summary>
        /// <param name="subContinent_ID1">The SubContinent_ID1 parameter of the G05_SubContinent_Child to fetch.</param>
        /// <returns>A reference to the fetched <see cref="G05_SubContinent_Child"/> object.</returns>
        internal static G05_SubContinent_Child GetG05_SubContinent_Child(int subContinent_ID1)
        {
            return DataPortal.FetchChild<G05_SubContinent_Child>(subContinent_ID1);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G05_SubContinent_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G05_SubContinent_Child()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="G05_SubContinent_Child"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="subContinent_ID1">The Sub Continent ID1.</param>
        protected void Child_Fetch(int subContinent_ID1)
        {
            var args = new DataPortalHookArgs(subContinent_ID1);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadROSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IG05_SubContinent_ChildDal>();
                var data = dal.Fetch(subContinent_ID1);
                Fetch(data);
            }
            OnFetchPost(args);
        }

        /// <summary>
        /// Loads a <see cref="G05_SubContinent_Child"/> object from the given <see cref="G05_SubContinent_ChildDto"/>.
        /// </summary>
        /// <param name="data">The G05_SubContinent_ChildDto to use.</param>
        private void Fetch(G05_SubContinent_ChildDto data)
        {
            // Value properties
            LoadProperty(SubContinent_Child_NameProperty, data.SubContinent_Child_Name);
            LoadProperty(SubContinent_ID1Property, data.SubContinent_ID1);
            _rowVersion = data.RowVersion;
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
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

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}