﻿<%
if (Info.GenerateDataPortalInsert)
{
    bool propInsertPropertyInfo = false;
    string strInsertPK = string.Empty;
    string strInsertResultPK = string.Empty;
    string strInsertParams = string.Empty;
    string strInsertDto = string.Empty;
    string strInsertResult = string.Empty;
    string strInsertResultTS = string.Empty;
	string strInsertResultOP = string.Empty;
    bool insertIsFirst = true;

    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (!prop.IsDatabaseBound)
            continue;

        if (prop.DbBindColumn.NativeType == "timestamp")
        {
            if ((prop.DeclarationMode == PropertyDeclaration.Managed && !prop.ReadOnly) ||
                prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                if (usesDTO)
                {
                    strInsertResultTS = FormatPascal(prop.Name) + " = resultDto." + FormatPascal(prop.Name) +";";
                }
                else
                {
                    strInsertResult = FormatPascal(prop.Name) + " = ";
                }
            }
            else if ((prop.DeclarationMode == PropertyDeclaration.Managed && prop.ReadOnly) ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
            {
                if (usesDTO)
                {
                    strInsertResultTS = "LoadProperty(" + FormatPropertyInfoName(prop.Name) + ", resultDto." + FormatPascal(prop.Name) +");";
                }
                else
                {
                    propInsertPropertyInfo = true;
                    strInsertResult = "LoadProperty(" + FormatPropertyInfoName(prop.Name) + ", ";
                }
            }
            else //Unmanaged, ClassicProperty, ClassicPropertyWithTypeConversion
            {
                if (usesDTO)
                {
                    strInsertResultTS = FormatFieldName(prop.Name) + " = resultDto." + FormatPascal(prop.Name) +";";
                }
                else
                {
                    strInsertResult = FormatFieldName(prop.Name) + " = ";
                }
            }
        }
        if (//prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
            prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
            prop.DbBindColumn.NativeType != "timestamp" &&
            (prop.DataAccess != ValueProperty.DataAccessBehaviour.UpdateOnly || prop.DbBindColumn.NativeType == "timestamp"))
        {
            if (!usesDTO)
            {
                if (!insertIsFirst)
                    strInsertParams += ",";
                else
                    insertIsFirst = false;

                strInsertParams += Environment.NewLine + new string(' ', 24);
            }

            if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK)
            {
                if (!usesDTO)
                {
                    strInsertPK = GetDataTypeGeneric(prop, TemplateHelper.GetBackingFieldType(prop)) + " " + FormatCamel(prop.Name) + " = -1;" + Environment.NewLine + new string(' ', 20);
                    strInsertParams += "out " + FormatCamel(prop.Name);
                }

                strInsertResultPK = Environment.NewLine + new string(' ', 16);
                if (prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                    prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion ||
                    prop.ReadOnly)
                {
                    strInsertResultPK += "LoadProperty(" + FormatPropertyInfoName(prop.Name) + ", ";
                    if (usesDTO)
                    {
                        strInsertResultPK += "resultDto." + FormatPascal(prop.Name) +");";
                    }
                    else
                    {
                        strInsertResultPK += FormatCamel(prop.Name) +");";
                    }
                }
                else if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                    prop.DeclarationMode == PropertyDeclaration.AutoProperty)
                {
                    strInsertResultPK += FormatPascal(prop.Name) + " = ";
                    if (usesDTO)
                    {
                        strInsertResultPK += "resultDto." + FormatPascal(prop.Name) +";";
                    }
                    else
                    {
                        strInsertResultPK += FormatCamel(prop.Name) +";";
                    }
                }
                else //Unmanaged, ClassicProperty, ClassicPropertyWithTypeConversion
                {
                    strInsertResultPK += FormatFieldName(prop.Name) + " = ";
                    if (usesDTO)
                    {
                        strInsertResultPK += "resultDto." + FormatPascal(prop.Name) +";";
                    }
                    else
                    {
                        strInsertResultPK += FormatCamel(prop.Name) +";";
                    }
                }
            }
            else
            {
                if (usesDTO)
                {
                    strInsertDto += Environment.NewLine + new string(' ', 16) + "dto." + FormatPascal(prop.Name) + " = ";
                }
                if (prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                    prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
                {
                    if (usesDTO)
                    {
                        strInsertDto += GetFieldReaderStatement(prop) + ";";
                    }
                    else
                        strInsertParams += GetFieldReaderStatement(prop);
                }
                else if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                    prop.DeclarationMode == PropertyDeclaration.AutoProperty)
                {
                    if (usesDTO)
                    {
                        strInsertDto += FormatPascal(prop.Name) + ";";
                    }
                    else
                        strInsertParams += FormatPascal(prop.Name);
                }
                else //Unmanaged, ClassicProperty, ClassicPropertyWithTypeConversion
                {
                    if (usesDTO)
                    {
                        strInsertDto += FormatFieldName(prop.Name) + ";";
                    }
                    else
                        strInsertParams += FormatFieldName(prop.Name);
                }
            }
        }
		if (prop.DataAccess == ValueProperty.DataAccessBehaviour.ReadOnly &&
            prop.DbBindColumn.NativeType != "timestamp" &&
            (prop.DataAccess != ValueProperty.DataAccessBehaviour.UpdateOnly || prop.DbBindColumn.NativeType == "timestamp"))
        {
			if (prop.OutputParameter == ValueProperty.OutputParameterBehaviour.InsertOnly
				|| prop.OutputParameter == ValueProperty.OutputParameterBehaviour.InsertAndUpdate)
            {
                strInsertResultOP += Environment.NewLine + new string(' ', 16);
                if (prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                    prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion ||
                    prop.ReadOnly)
                {
                    strInsertResultOP += "LoadProperty(" + FormatPropertyInfoName(prop.Name) + ", ";
                    if (usesDTO)
                    {
                        strInsertResultOP += "resultDto." + FormatPascal(prop.Name) +");";
                    }
                    else
                    {
                        strInsertResultOP += FormatCamel(prop.Name) +");";
                    }
                }
                else if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                    prop.DeclarationMode == PropertyDeclaration.AutoProperty)
                {
                    strInsertResultOP += FormatPascal(prop.Name) + " = ";
                    if (usesDTO)
                    {
                        strInsertResultOP += "resultDto." + FormatPascal(prop.Name) +";";
                    }
                    else
                    {
                        strInsertResultOP += FormatCamel(prop.Name) +";";
                    }
                }
                else //Unmanaged, ClassicProperty, ClassicPropertyWithTypeConversion
                {
                    strInsertResultOP += FormatFieldName(prop.Name) + " = ";
                    if (usesDTO)
                    {
                        strInsertResultOP += "resultDto." + FormatPascal(prop.Name) +";";
                    }
                    else
                    {
                        strInsertResultOP += FormatCamel(prop.Name) +";";
                    }
                }
            }
		}
    }
    if (usesDTO)
    {
        strInsertResult += "var resultDto = ";
        strInsertParams += "dto";
        if (strInsertResultTS != string.Empty)
            strInsertResultTS = Environment.NewLine + new string(' ', 16) + strInsertResultTS;
    }
    else
        strInsertParams += Environment.NewLine + new string(' ', 24);
    %>

        /// <summary>
        /// Inserts a new <see cref="<%= Info.ObjectName %>"/> object in the database.
        /// </summary>
        [Insert]
        <%
    if (Info.TransactionType == TransactionType.EnterpriseServices)
    {
        %>[Transactional(TransactionalTypes.EnterpriseServices)]
        <%
    }
    else if (Info.TransactionType == TransactionType.TransactionScope || Info.TransactionType == TransactionType.TransactionScope)
    {
        %>[Transactional(TransactionalTypes.TransactionScope)]
        <%
    }    
    if (Info.InsertUpdateRunLocal)
    {
        %>[RunLocal]
        <%
    }
        %>protected void Insert([Inject] I<%= Info.ObjectName %>Dal dal)
        {
            <%
    if (TemplateHelper.UseSimpleAuditTrail(Info))
    {
        %>SimpleAuditTrail();
            <%
    }%>using (BypassPropertyChecks)
            {    
    <%if (usesDTO)
    {
        %>
                var dto = new <%= Info.ObjectName %>Dto();<%= strInsertDto %>
            <%
    }
    %>
                var args = new DataPortalHookArgs(<%= usesDTO ? "dto" : "" %>);
                OnInsertPre(args);
                <%= strInsertPK %><%= strInsertResult %>dal.Insert(<%= strInsertParams %>)<%= propInsertPropertyInfo ? ")" : "" %>;<%= strInsertResultPK %><%= strInsertResultTS %><%= strInsertResultOP %>
                <%
                if (usesDTO)
                {
                    %>
                args = new DataPortalHookArgs(resultDto);
                <%
                }
                %>
                OnInsertPost(args);
            }
            <%
    if (Info.GetMyChildReadWriteProperties().Count > 0)
    {
        string ucpSpacer = new string(' ', 4);
        %>
<!-- #include file="UpdateChildProperties.asp" -->
                <%
    }
    %>
        }
    <%
}
%>