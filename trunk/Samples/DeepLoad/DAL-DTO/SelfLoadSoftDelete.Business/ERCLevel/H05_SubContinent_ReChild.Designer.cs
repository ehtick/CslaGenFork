using System;
using Csla;
using SelfLoadSoftDelete.DataAccess;
using SelfLoadSoftDelete.DataAccess.ERCLevel;

namespace SelfLoadSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H05_SubContinent_ReChild (editable child object).<br/>
    /// This is a generated base class of <see cref="H05_SubContinent_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="H04_SubContinent"/> collection.
    /// </remarks>
    [Serializable]
    public partial class H05_SubContinent_ReChild : BusinessBase<H05_SubContinent_ReChild>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubContinent_Child_NameProperty = RegisterProperty<string>(p => p.SubContinent_Child_Name, "Countries Child Name");
        /// <summary>
        /// Gets or sets the Countries Child Name.
        /// </summary>
        /// <value>The Countries Child Name.</value>
        public string SubContinent_Child_Name
        {
            get { return GetProperty(SubContinent_Child_NameProperty); }
            set { SetProperty(SubContinent_Child_NameProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="H05_SubContinent_ReChild"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="H05_SubContinent_ReChild"/> object.</returns>
        internal static H05_SubContinent_ReChild NewH05_SubContinent_ReChild()
        {
            return DataPortal.CreateChild<H05_SubContinent_ReChild>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="H05_SubContinent_ReChild"/> object, based on given parameters.
        /// </summary>
        /// <param name="subContinent_ID2">The SubContinent_ID2 parameter of the H05_SubContinent_ReChild to fetch.</param>
        /// <returns>A reference to the fetched <see cref="H05_SubContinent_ReChild"/> object.</returns>
        internal static H05_SubContinent_ReChild GetH05_SubContinent_ReChild(int subContinent_ID2)
        {
            return DataPortal.FetchChild<H05_SubContinent_ReChild>(subContinent_ID2);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H05_SubContinent_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H05_SubContinent_ReChild()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="H05_SubContinent_ReChild"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="H05_SubContinent_ReChild"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="subContinent_ID2">The Sub Continent ID2.</param>
        protected void Child_Fetch(int subContinent_ID2)
        {
            var args = new DataPortalHookArgs(subContinent_ID2);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IH05_SubContinent_ReChildDal>();
                var data = dal.Fetch(subContinent_ID2);
                Fetch(data);
            }
            OnFetchPost(args);
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        /// <summary>
        /// Loads a <see cref="H05_SubContinent_ReChild"/> object from the given <see cref="H05_SubContinent_ReChildDto"/>.
        /// </summary>
        /// <param name="data">The H05_SubContinent_ReChildDto to use.</param>
        private void Fetch(H05_SubContinent_ReChildDto data)
        {
            // Value properties
            LoadProperty(SubContinent_Child_NameProperty, data.SubContinent_Child_Name);
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="H05_SubContinent_ReChild"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(H04_SubContinent parent)
        {
            var dto = new H05_SubContinent_ReChildDto();
            dto.Parent_SubContinent_ID = parent.SubContinent_ID;
            dto.SubContinent_Child_Name = SubContinent_Child_Name;
            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IH05_SubContinent_ReChildDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Insert(dto);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnInsertPost(args);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="H05_SubContinent_ReChild"/> object.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update(H04_SubContinent parent)
        {
            var dto = new H05_SubContinent_ReChildDto();
            dto.Parent_SubContinent_ID = parent.SubContinent_ID;
            dto.SubContinent_Child_Name = SubContinent_Child_Name;
            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IH05_SubContinent_ReChildDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Update(dto);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnUpdatePost(args);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="H05_SubContinent_ReChild"/> object from database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf(H04_SubContinent parent)
        {
            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IH05_SubContinent_ReChildDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(parent.SubContinent_ID);
                }
                OnDeletePost(args);
            }
        }

        #endregion

        #region Pseudo Events

        /// <summary>
        /// Occurs after setting all defaults for object creation.
        /// </summary>
        partial void OnCreate(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after setting query parameters and before the delete operation.
        /// </summary>
        partial void OnDeletePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after the delete operation, before Commit().
        /// </summary>
        partial void OnDeletePost(DataPortalHookArgs args);

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

        /// <summary>
        /// Occurs after setting query parameters and before the update operation.
        /// </summary>
        partial void OnUpdatePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the update operation, before setting back row identifiers (RowVersion) and Commit().
        /// </summary>
        partial void OnUpdatePost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after setting query parameters and before the insert operation.
        /// </summary>
        partial void OnInsertPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the insert operation, before setting back row identifiers (ID and RowVersion) and Commit().
        /// </summary>
        partial void OnInsertPost(DataPortalHookArgs args);

        #endregion

    }
}
