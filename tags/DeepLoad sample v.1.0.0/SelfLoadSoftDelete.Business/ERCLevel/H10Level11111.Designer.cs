using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H10Level11111 (editable child object).<br/>
    /// This is a generated base class of <see cref="H10Level11111"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="H11Level111111Objects"/> of type <see cref="H11Level111111Coll"/> (1:M relation to <see cref="H12Level111111"/>)<br/>
    /// This class is an item of <see cref="H09Level11111Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class H10Level11111 : BusinessBase<H10Level11111>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_1_1_1_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Level_1_1_1_1_1_IDProperty = RegisterProperty<int>(p => p.Level_1_1_1_1_1_ID, "Level_1_1_1_1_1 ID");
        /// <summary>
        /// Gets the Level_1_1_1_1_1 ID.
        /// </summary>
        /// <value>The Level_1_1_1_1_1 ID.</value>
        public int Level_1_1_1_1_1_ID
        {
            get { return GetProperty(Level_1_1_1_1_1_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_1_1_1_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Level_1_1_1_1_1_NameProperty = RegisterProperty<string>(p => p.Level_1_1_1_1_1_Name, "Level_1_1_1_1_1 Name");
        /// <summary>
        /// Gets or sets the Level_1_1_1_1_1 Name.
        /// </summary>
        /// <value>The Level_1_1_1_1_1 Name.</value>
        public string Level_1_1_1_1_1_Name
        {
            get { return GetProperty(Level_1_1_1_1_1_NameProperty); }
            set { SetProperty(Level_1_1_1_1_1_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H11Level111111SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H11Level111111Child> H11Level111111SingleObjectProperty = RegisterProperty<H11Level111111Child>(p => p.H11Level111111SingleObject, "H11 Level111111 Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the H11 Level111111 Single Object ("self load" child property).
        /// </summary>
        /// <value>The H11 Level111111 Single Object.</value>
        public H11Level111111Child H11Level111111SingleObject
        {
            get { return GetProperty(H11Level111111SingleObjectProperty); }
            private set { LoadProperty(H11Level111111SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H11Level111111ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H11Level111111ReChild> H11Level111111ASingleObjectProperty = RegisterProperty<H11Level111111ReChild>(p => p.H11Level111111ASingleObject, "H11 Level111111 ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the H11 Level111111 ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The H11 Level111111 ASingle Object.</value>
        public H11Level111111ReChild H11Level111111ASingleObject
        {
            get { return GetProperty(H11Level111111ASingleObjectProperty); }
            private set { LoadProperty(H11Level111111ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H11Level111111Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<H11Level111111Coll> H11Level111111ObjectsProperty = RegisterProperty<H11Level111111Coll>(p => p.H11Level111111Objects, "H11 Level111111 Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the H11 Level111111 Objects ("self load" child property).
        /// </summary>
        /// <value>The H11 Level111111 Objects.</value>
        public H11Level111111Coll H11Level111111Objects
        {
            get { return GetProperty(H11Level111111ObjectsProperty); }
            private set { LoadProperty(H11Level111111ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="H10Level11111"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="H10Level11111"/> object.</returns>
        internal static H10Level11111 NewH10Level11111()
        {
            return DataPortal.CreateChild<H10Level11111>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="H10Level11111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="H10Level11111"/> object.</returns>
        internal static H10Level11111 GetH10Level11111(SafeDataReader dr)
        {
            H10Level11111 obj = new H10Level11111();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H10Level11111"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H10Level11111()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="H10Level11111"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(Level_1_1_1_1_1_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(H11Level111111SingleObjectProperty, DataPortal.CreateChild<H11Level111111Child>());
            LoadProperty(H11Level111111ASingleObjectProperty, DataPortal.CreateChild<H11Level111111ReChild>());
            LoadProperty(H11Level111111ObjectsProperty, DataPortal.CreateChild<H11Level111111Coll>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="H10Level11111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_1_1_1_1_IDProperty, dr.GetInt32("Level_1_1_1_1_1_ID"));
            LoadProperty(Level_1_1_1_1_1_NameProperty, dr.GetString("Level_1_1_1_1_1_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(H11Level111111SingleObjectProperty, H11Level111111Child.GetH11Level111111Child(Level_1_1_1_1_1_ID));
            LoadProperty(H11Level111111ASingleObjectProperty, H11Level111111ReChild.GetH11Level111111ReChild(Level_1_1_1_1_1_ID));
            LoadProperty(H11Level111111ObjectsProperty, H11Level111111Coll.GetH11Level111111Coll(Level_1_1_1_1_1_ID));
        }

        /// <summary>
        /// Inserts a new <see cref="H10Level11111"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(H08Level1111 parent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddH10Level11111", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_1_1_1_ID", parent.Level_1_1_1_1_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Level_1_1_1_1_1_ID", ReadProperty(Level_1_1_1_1_1_IDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Level_1_1_1_1_1_Name", ReadProperty(Level_1_1_1_1_1_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(Level_1_1_1_1_1_IDProperty, (int) cmd.Parameters["@Level_1_1_1_1_1_ID"].Value);
                }
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="H10Level11111"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateH10Level11111", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_1_1_1_1_ID", ReadProperty(Level_1_1_1_1_1_IDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Level_1_1_1_1_1_Name", ReadProperty(Level_1_1_1_1_1_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="H10Level11111"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                using (var cmd = new SqlCommand("DeleteH10Level11111", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_1_1_1_1_ID", ReadProperty(Level_1_1_1_1_1_IDProperty)).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
            }
            // removes all previous references to children
            LoadProperty(H11Level111111SingleObjectProperty, DataPortal.CreateChild<H11Level111111Child>());
            LoadProperty(H11Level111111ASingleObjectProperty, DataPortal.CreateChild<H11Level111111ReChild>());
            LoadProperty(H11Level111111ObjectsProperty, DataPortal.CreateChild<H11Level111111Coll>());
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
