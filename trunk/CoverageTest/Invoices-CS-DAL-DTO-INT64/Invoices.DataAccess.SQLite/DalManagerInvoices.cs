//-----------------------------------------------------------------------
// <copyright file="DalManagerInvoices.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Data.SQLite;
using Csla.Data;

namespace Invoices.DataAccess.SQLite
{
    /// <summary>
    /// Implements <see cref="IDalManagerInvoices"/> interface.
    /// </summary>
    /// <remarks>
    /// To use this DAL:<br/>
    /// 1) name this assembly Invoices.DataAccess.SQLite<br/>
    /// 2) add the following line to the <strong>appSettings</strong>
    /// section of the application .config file: <br/>
    /// &lt;add key="Invoices.DalManagerType" value="Invoices.DataAccess.SQLite.DalManagerInvoices, Invoices.DataAccess.SQLite" /&gt;
    /// </remarks>
    public class DalManagerInvoices : IDalManagerInvoices
    {
        private static readonly string TypeMask = typeof (DalManagerInvoices).FullName.Replace("DalManagerInvoices", @"{0}");
        private const string BaseNamespace = "Invoices.DataAccess";

        /// <summary>
        /// Initializes a new instance of the <see cref="DalManagerInvoices"/> class.
        /// </summary>
        public DalManagerInvoices()
        {
            ConnectionManager = ConnectionManager<SQLiteConnection>.GetManager("InvoicesDatabase");
        }

        /// <summary>
        /// Gets the ADO ConnectionManager object.
        /// </summary>
        /// <value>The ConnectionManager object</value>
        public ConnectionManager<SQLiteConnection> ConnectionManager { get; private set; }

        #region IDalManagerInvoices Members

        /// <summary>
        /// Gets the Invoices DAL provider for a given object Type.
        /// </summary>
        /// <typeparam name="T">Object Type that requires a Invoices DAL provider.</typeparam>
        /// <returns>A new Invoices DAL instance for the given Type.</returns>
        public T GetProvider<T>() where T : class
        {
            string typeName;
            var namespaceDiff = typeof(T).Namespace.Length - BaseNamespace.Length;
            if (namespaceDiff > 0)
                typeName = string.Format(TypeMask, typeof(T).Namespace.Substring(BaseNamespace.Length + 1,
                    namespaceDiff - 1)) + "." + typeof(T).Name.Substring(1);
            else
                typeName = string.Format(TypeMask, typeof(T).Name.Substring(1));

            var type = Type.GetType(typeName);
            if (type != null)
                return Activator.CreateInstance(type) as T;

            throw new NotImplementedException(typeName);
        }

        /// <summary>
        /// Disposes the ConnectionManager.
        /// </summary>
        public void Dispose()
        {
            ConnectionManager.Dispose();
            ConnectionManager = null;
        }

        #endregion

    }
}
