<%
bool isFirstMethod = true;
bool isFirstDPFDI = true;
foreach (Criteria c in Info.CriteriaObjects)
{
    if (c.GetOptions.DataPortal)
    {
        if (usesDTO)
        {
            if (isFirstDPFDI)
                isFirstDPFDI = false;
            else
                Response.Write(Environment.NewLine);

            isFirstMethod = false;
            %>
        /// <summary>
        /// Loads a <%= Info.ObjectName %> object from the database.
        /// </summary>
        <%
            if (c.Properties.Count > 0)
            {
                %>
        /// <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The fetch criteria.</param>
        <%
            }
            if (c.Properties.Count > 1)
            {
                %>
        /// <returns>A <see cref="<%= Info.ObjectName %>Dto"/> object.</returns>
        <%= Info.ObjectName %>Dto Fetch(I<%= c.Name %> crit);
        <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
        /// <returns>A <see cref="<%= Info.ObjectName %>Dto"/> object.</returns>
        <%= Info.ObjectName %>Dto Fetch(<%= ReceiveSingleCriteria(c, "crit") %>);
        <%
            }
            else
            {
                %>
        /// <returns>A <see cref="<%= Info.ObjectName %>Dto"/> object.</returns>
        <%= Info.ObjectName %>Dto Fetch();
        <%
            }
        }
        else
        {
            string strGetCritParams = string.Empty;
            string strGetComment = string.Empty;
            bool getIsFirst = true;

            for (int i = 0; i < c.Properties.Count; i++)
            {
                if (!getIsFirst)
                    strGetCritParams += ", ";
                else
                    getIsFirst = false;

                TypeCodeEx propType = c.Properties[i].PropertyType;

                strGetCritParams += string.Concat(GetDataTypeGeneric(c.Properties[i], propType), " ", FormatCamel(c.Properties[i].Name));
                strGetComment += "/// <param name=\"" + FormatCamel(c.Properties[i].Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(c.Properties[i].Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
            }
            if (isFirstDPFDI)
                isFirstDPFDI = false;
            else
                Response.Write(Environment.NewLine);

            isFirstMethod = false;
            %>
        /// <summary>
        /// Loads a <%= Info.ObjectName %> object from the database.
        /// </summary>
        <%= strGetComment %>/// <returns>A data reader to the <%= Info.ObjectName %>.</returns>
        IDataReader Fetch(<%= strGetCritParams %>);
        <%
        }
    }
}
%>
