using System;
using System.Data;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.Business
{

    /// <summary>
    /// LoggerBusinessListBase (base class).<br/>
    /// This is a generated base class of <see cref="LoggerBusinessListBase{T, C}"/> business object.
    /// </summary>
    [Serializable]
    public abstract partial class LoggerBusinessListBase<T, C> : BusinessListBase<T, C>, IListLog
        where T : LoggerBusinessListBase<T, C>, IListLog
        where C : LoggerBusinessBase<C>
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerBusinessListBase"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public LoggerBusinessListBase()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

    }
}
