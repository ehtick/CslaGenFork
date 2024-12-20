<%
useInlineQuery = false;
lastCriteria = "";
if (CurrentUnit.GenerationParams.UseInlineQueries == UseInlineQueries.Always)
   useInlineQuery = true;
else if (CurrentUnit.GenerationParams.UseInlineQueries == UseInlineQueries.SpecifyByObject)
{
   foreach (string item in Info.GenerateInlineQueries)
   {
       if (item == "Delete")
       {
           useInlineQuery = true;
           break;
       }
   }
}
if (Info.GenerateDataPortalDelete)
{
    foreach (Criteria c in Info.CriteriaObjects)
    {
        lastCriteria = "";
        if (c.DeleteOptions.DataPortal)
        {
            if (isFirstMethod)
                isFirstMethod = false;
            else
                Response.Write(Environment.NewLine);

            if (usesDTO)
            {
                %>
        /// <summary>
        /// Deletes the <%= Info.ObjectName %> object from database.
        /// </summary>
        <%
                if (c.Properties.Count > 1)
                {
                    foreach (Property prop in c.Properties)
                    {
                        string param = FormatCamel(prop.Name);
                        %>
        /// <param name="<%= param %>">The <%= param %> parameter of the <%= Info.ObjectName %> to delete.</param>
        <%
                    }
                }
                else if (c.Properties.Count > 0)
                {
                    %>
        /// <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The delete criteria.</param>
        <%
                }
                if (c.Properties.Count > 1)
                {
                    lastCriteria = ReceiveMultipleCriteriaTypeless(c, true);
                    if (useInlineQuery)
                        InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.DeleteOptions.ProcedureName, ReceiveMultipleCriteria(c, true)));
                    %>
        public void Delete(<%= ReceiveMultipleCriteria(c) %>)
        <%
                }
                else
                {
                    lastCriteria = ReceiveSingleCriteriaTypeless(c, "crit", true);
                    if (useInlineQuery)
                        InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.DeleteOptions.ProcedureName, ReceiveSingleCriteria(c, "crit", true)));
                    %>
        public void Delete(<%= ReceiveSingleCriteria(c, "crit") %>)
        <%
                }
            }
            else
            {
                string strDeleteCritParams = string.Empty;
                string lastCriteriaTyped = string.Empty;
                string strDeleteComment = string.Empty;
                bool deleteIsFirst = true;

                for (int i = 0; i < c.Properties.Count; i++)
                {
                    if (!deleteIsFirst)
                    {
                       strDeleteCritParams += ", ";
                       lastCriteriaTyped += ", ";
                       lastCriteria += ", ";
                    }
                    else
                        deleteIsFirst = false;

                    strDeleteComment += "/// <param name=\"" + FormatCamel(c.Properties[i].Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(c.Properties[i].Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
                    strDeleteCritParams += string.Concat(GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType), " ", FormatCamel(c.Properties[i].Name));
                    lastCriteriaTyped += string.Concat(AddRefOrOut(c.Properties[i]) + GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType), " ", FormatCamel(c.Properties[i].Name));
                    lastCriteria += AddRefOrOut(c.Properties[i]) + FormatCamel(c.Properties[i].Name);
                }

                if (useInlineQuery)
                    InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.DeleteOptions.ProcedureName, lastCriteriaTyped));
                %>
        /// <summary>
        /// Deletes the <%= Info.ObjectName %> object from database.
        /// </summary>
        <%= strDeleteComment %>public void Delete(<%= strDeleteCritParams %>)
        <%
            }
            %>
        {
            <%= GetConnection(Info, false) %>
            {
                <%= GetCommand(Info, c.DeleteOptions.ProcedureName, useInlineQuery, lastCriteria) %>
                {
                    <%
            if (Info.CommandTimeout != string.Empty)
            {
                %>
                    cmd.CommandTimeout = <%= Info.CommandTimeout %>;
                    <%
            }
            %>
                    cmd.CommandType = CommandType.<%= useInlineQuery ? "Text" : "StoredProcedure" %>;
                    <%
            foreach (CriteriaProperty p in c.Properties)
            {
                if (!usesDTO)
                {
                    %>
                    cmd.Parameters.<%= AddParameterMethod %>("@<%= p.ParameterName %>", <%= GetParameterSet(Info, p, false, true) %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= TemplateHelper.GetDbType(p) %>;
                    <%
                }
                else
                {
                    if (c.Properties.Count > 1)
                    {
                        %>
                    cmd.Parameters.<%= AddParameterMethod %>("@<%= p.ParameterName %>", <%= GetParameterSet(p, false, false, false) %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= TemplateHelper.GetDbType(p) %>;
                    <%
                    }
                    else
                    {
                        %>
                    cmd.Parameters.<%= AddParameterMethod %>("@<%= p.ParameterName %>", <%= AssignSingleCriteria(c, "crit") %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= TemplateHelper.GetDbType(p) %>;
                    <%
                    }
                }
            }
            string hookArgs = string.Empty;
            if (c.Properties.Count > 1)
            {
                hookArgs = ", crit";
            }
            else if (c.Properties.Count > 0)
            {
                hookArgs = ", " + HookSingleCriteria(c, "crit");
            }
            %>
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("<%= Info.ObjectName %>");
                }
            }
        }
    <%
        }
    }
}
%>
