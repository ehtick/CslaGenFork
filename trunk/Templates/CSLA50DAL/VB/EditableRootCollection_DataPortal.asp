        #region Data Access
<%
if (UseBoth())
{
    %>

#if !SILVERLIGHT
<%
}
if (UseNoSilverlight())
{
    %>
<!-- #include file="CollectionDataPortalFetch.asp" -->
<% %>

        /// <summary>
        /// Updates in the database all changes made to the <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%
        if (Info.TransactionType == TransactionType.EnterpriseServices)
        {
            %>[Transactional(TransactionalTypes.EnterpriseServices)]
        <%
        }
        else if (Info.TransactionType == TransactionType.TransactionScope)
        {
            %>[Transactional(TransactionalTypes.TransactionScope)]
        <%
        }
        if (Info.InsertUpdateRunLocal)
        {
            %>[RunLocal]
        <%
        }
        %>protected override void DataPortal_Update()
        {
            using (var dalManager = DalFactory<%= GetDalNameDot(CurrentUnit) %>GetManager())
            {
                base.Child_Update();
            }
        }
<%
}
if (UseNoSilverlight() && CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>

#else
<%
}
if (CurrentUnit.GenerationParams.TargetIsCsla40)
{
    %>
<!-- #include file="DataPortalFetchServices.asp" -->
<!-- #include file="DataPortalUpdateServices.asp" -->
<%
}
else
{
    %>
<!-- #include file="DataPortalFetchServices-45.asp" -->
<!-- #include file="DataPortalUpdateServices-45.asp" -->
<%
}
if (UseBoth())
{
    %>

#endif
<%
}
%>

        #endregion
