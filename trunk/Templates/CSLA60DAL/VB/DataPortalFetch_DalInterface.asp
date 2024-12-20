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

            %>
        /// <summary>
        /// Loads a <%= Info.ObjectName %> object from the database.
        /// </summary>
        <%
            if (c.Properties.Count > 1)
            {
                foreach (Property prop in c.Properties)
                {
                    string param = FormatCamel(prop.Name);
                    %>
        /// <param name="<%= param %>">The <%= param %> parameter of the <%= Info.ObjectName %> to fetch.</param>
        <%
                }
            }
            else if (c.Properties.Count > 0)
            {
                %>
        /// <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The fetch criteria.</param>
        <%
            }
            if (c.Properties.Count > 1)
            {
                %>
        /// <returns>A <see cref="<%= Info.ObjectName %>Dto"/> object.</returns>
        <%= Info.ObjectName %>Dto Fetch(<%= ReceiveMultipleCriteria(c) %>);
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

                strGetCritParams += string.Concat(GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType), " ", FormatCamel(c.Properties[i].Name));
                strGetComment += "/// <param name=\"" + FormatCamel(c.Properties[i].Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(c.Properties[i].Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
            }
            if (isFirstDPFDI)
                isFirstDPFDI = false;
            else
                Response.Write(Environment.NewLine);

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
isFirstMethod = isFirstDPFDI;
%>
