﻿<%
if (CurrentUnit.GenerationParams.GenerateAsynchronous)
{
    if (!Info.UseCustomLoading)
    {
        foreach (Criteria c in Info.CriteriaObjects)
        {
            if (Info.IsUnitOfWork() && Info.IsCreatorGetter && c.Properties.Count == 0)
                continue;
            if (c.GetOptions.Factory)
            {
                if (!isChild && !c.NestedClass && c.Properties.Count > 1 && c.CriteriaClassMode != CriteriaMode.MultiplePrimatives && Info.IsNotEditableSwitchable())
                {
                    %>

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="<%= Info.ObjectName %>"/> <%= TypeHelper.IsCollectionType(Info.ObjectType) ? "collection" : "object" %>, based on given parameters.
        /// </summary>
        /// <param name="crit">The fetch criteria.</param>
        /// <returns>A reference to the fetched <see cref="<%= Info.ObjectName %>"/> <%= TypeHelper.IsCollectionType(Info.ObjectType) ? "collection" : "object" %>.</returns>
        public async static Task<<%= Info.ObjectName %>> Get<%= Info.ObjectName %><%= c.GetOptions.FactorySuffix %>Async(<%= c.Name %> crit)
        {
            return await DataPortal.FetchAsync<<%= Info.ObjectName %>>(crit);
        }
        <%
                }
                %>

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="<%= Info.ObjectName %>"/> <%= TypeHelper.IsCollectionType(Info.ObjectType) ? "collection" : "object" %><%= c.Properties.Count > 0 ? ", based on given parameters" : "" %>.
        /// </summary>
        <%
                string strGetParams = string.Empty;
                string strGetCritParams = string.Empty;
                bool firstParam = true;
                for (int i = 0; i < c.Properties.Count; i++)
                {
                    if (string.IsNullOrEmpty(c.Properties[i].ParameterValue))
                    {
                        %>
        /// <param name="<%= FormatCamel(c.Properties[i].Name) %>">The <%= FormatProperty(c.Properties[i].Name) %> parameter of the <%= Info.ObjectName %> to fetch.</param>
        <%
                        if (firstParam)
                        {
                            firstParam = false;
                        }
                        else
                        {
                            strGetParams += ", ";
                            strGetCritParams += ", ";
                        }
                        strGetParams += string.Concat(GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType), " ", FormatCamel(c.Properties[i].Name));
                        strGetCritParams += FormatCamel(c.Properties[i].Name);
                    }
                    else
                    {
                        if (!isCriteriaClassNeeded)
						{
							if (firstParam)
							{
								firstParam = false;
							}
							else
							{
								strGetCritParams += ", ";
							}
							strGetCritParams += c.Properties[i].ParameterValue;
						}
                    }
                }
            %>
        /// <returns>A reference to the fetched <see cref="<%= Info.ObjectName %>"/> <%= TypeHelper.IsCollectionType(Info.ObjectType) ? "collection" : "object" %>.</returns>
        <%= Info.ParentType == string.Empty ? "public" : "internal" %> async static Task<<%= Info.ObjectName %>> Get<%= Info.ObjectName %><%= c.GetOptions.FactorySuffix %>Async(<%= strGetParams %>)
        {
            <%
                if (Info.IsEditableSwitchable())
                {
                    strGetCritParams = "false, " + strGetCritParams;
                }
                if (c.Properties.Count > 1 || (Info.IsEditableSwitchable() && c.Properties.Count == 1))
                {
                    if (c.CriteriaClassMode != CriteriaMode.MultiplePrimatives)
                    {%>
            return await DataPortal.Fetch<%= isChildNotLazyLoaded ? "Child" : "" %>Async<<%= Info.ObjectName %>>(new <%= c.Name %>(<%= strGetCritParams %>));
            <%
                    }
                    else
                    {%>
            return await DataPortal.Fetch<%= isChildNotLazyLoaded ? "Child" : "" %>Async<<%= Info.ObjectName %>>(<%= strGetCritParams %>);
            <%
                    }
                }
                else if (c.Properties.Count > 0)
                {
                    %>
            return await DataPortal.Fetch<%= isChildNotLazyLoaded ? "Child" : "" %>Async<<%= Info.ObjectName %>>(<%= SendSingleCriteria(c, strGetCritParams) %>);
            <%
                }
                else
                {
                    if (Info.SimpleCacheOptions != SimpleCacheResults.None)
                    {
                        %>
            if (_list == null)
                _list = DataPortal.Fetch<%= isChildNotLazyLoaded ? "Child" : "" %>Async<<%= Info.ObjectName %>>().Result;

            return Task.FromResult(_list);
            <%
                    }
                    else
                    {
                        %>
            return await DataPortal.Fetch<%= isChildNotLazyLoaded ? "Child" : "" %>Async<<%= Info.ObjectName %>>();
        <%
                    }
                }
                %>
        }
<%
            }
        }
    }
}
%>
