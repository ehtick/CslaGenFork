using System;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DTO for H09_Region_ReChild type
    /// </summary>
    public partial class H09_Region_ReChildDto
    {
        /// <summary>
        /// Gets or sets the parent Region ID.
        /// </summary>
        /// <value>The Region ID.</value>
        public int Parent_Region_ID { get; set; }

        /// <summary>
        /// Gets or sets the Cities Child Name.
        /// </summary>
        /// <value>The Region Child Name.</value>
        public string Region_Child_Name { get; set; }
    }
}
