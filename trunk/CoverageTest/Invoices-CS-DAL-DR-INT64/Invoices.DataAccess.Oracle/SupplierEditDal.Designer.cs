using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.Oracle
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="ISupplierEditDal"/>
    /// </summary>
    public partial class SupplierEditDal : ISupplierEditDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a SupplierEdit object from the database.
        /// </summary>
        /// <param name="supplierId">The Supplier Id.</param>
        /// <returns>A data reader to the SupplierEdit.</returns>
        public IDataReader Fetch(int supplierId)
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                using (var cmd = new OracleCommand("dbo.GetSupplierEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SupplierId", supplierId).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }

        /// <summary>
        /// Inserts a new SupplierEdit object in the database.
        /// </summary>
        /// <param name="supplierId">The Supplier Id.</param>
        /// <param name="name">The Name.</param>
        /// <param name="addressLine1">The Address Line1.</param>
        /// <param name="addressLine2">The Address Line2.</param>
        /// <param name="zipCode">The Zip Code.</param>
        /// <param name="state">The State.</param>
        /// <param name="country">The Country.</param>
        public void Insert(int supplierId, string name, string addressLine1, string addressLine2, string zipCode, string state, byte? country)
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                using (var cmd = new OracleCommand("dbo.AddSupplierEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SupplierId", supplierId).DbType = DbType.Int32;
                    cmd.Parameters.Add("@Name", name).DbType = DbType.String;
                    cmd.Parameters.Add("@AddressLine1", addressLine1 == null ? (object)DBNull.Value : addressLine1).DbType = DbType.String;
                    cmd.Parameters.Add("@AddressLine2", addressLine2 == null ? (object)DBNull.Value : addressLine2).DbType = DbType.String;
                    cmd.Parameters.Add("@ZipCode", zipCode == null ? (object)DBNull.Value : zipCode).DbType = DbType.String;
                    cmd.Parameters.Add("@State", state == null ? (object)DBNull.Value : state).DbType = DbType.String;
                    cmd.Parameters.Add("@Country", country == null ? (object)DBNull.Value : country.Value).DbType = DbType.Byte;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the SupplierEdit object.
        /// </summary>
        /// <param name="supplierId">The Supplier Id.</param>
        /// <param name="name">The Name.</param>
        /// <param name="addressLine1">The Address Line1.</param>
        /// <param name="addressLine2">The Address Line2.</param>
        /// <param name="zipCode">The Zip Code.</param>
        /// <param name="state">The State.</param>
        /// <param name="country">The Country.</param>
        public void Update(int supplierId, string name, string addressLine1, string addressLine2, string zipCode, string state, byte? country)
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                using (var cmd = new OracleCommand("dbo.UpdateSupplierEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SupplierId", supplierId).DbType = DbType.Int32;
                    cmd.Parameters.Add("@Name", name).DbType = DbType.String;
                    cmd.Parameters.Add("@AddressLine1", addressLine1 == null ? (object)DBNull.Value : addressLine1).DbType = DbType.String;
                    cmd.Parameters.Add("@AddressLine2", addressLine2 == null ? (object)DBNull.Value : addressLine2).DbType = DbType.String;
                    cmd.Parameters.Add("@ZipCode", zipCode == null ? (object)DBNull.Value : zipCode).DbType = DbType.String;
                    cmd.Parameters.Add("@State", state == null ? (object)DBNull.Value : state).DbType = DbType.String;
                    cmd.Parameters.Add("@Country", country == null ? (object)DBNull.Value : country.Value).DbType = DbType.Byte;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("SupplierEdit");
                }
            }
        }

        #endregion

    }
}
