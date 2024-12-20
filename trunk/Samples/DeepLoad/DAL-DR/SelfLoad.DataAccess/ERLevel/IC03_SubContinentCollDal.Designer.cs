using System;
using System.Data;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C03_SubContinentColl type
    /// </summary>
    public partial interface IC03_SubContinentCollDal
    {
        /// <summary>
        /// Loads a C03_SubContinentColl collection from the database.
        /// </summary>
        /// <param name="parent_Continent_ID">The Parent Continent ID.</param>
        /// <returns>A data reader to the C03_SubContinentColl.</returns>
        IDataReader Fetch(int parent_Continent_ID);
    }
}
