using System;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DTO for E10_City type
    /// </summary>
    public partial class E10_CityDto
    {
        /// <summary>
        /// Gets or sets the parent Region ID.
        /// </summary>
        /// <value>The Region ID.</value>
        public int Parent_Region_ID { get; set; }

        /// <summary>
        /// Gets or sets the Cities ID.
        /// </summary>
        /// <value>The City ID.</value>
        public int City_ID { get; set; }

        /// <summary>
        /// Gets or sets the Cities Name.
        /// </summary>
        /// <value>The City Name.</value>
        public string City_Name { get; set; }
    }
}
