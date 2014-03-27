#Region " Data Access "
<%
bool createRunLocalDp = false;
foreach (Criteria c in Info.CriteriaObjects)
{
    if (c.CreateOptions.DataPortal)
    {
        createRunLocalDp = createRunLocalDp || c.CreateOptions.RunLocal;
    }
}
if (UseNoSilverlight() && CurrentUnit.GenerationParams.TargetIsCsla45 && createRunLocalDp &&
    !CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>
<!-- #include file="DataPortalCreate.asp" -->
<%
}
if (UseBoth())
{
    %>

#If Not SILVERLIGHT Then
<%
}
if (UseNoSilverlight() && (CurrentUnit.GenerationParams.TargetIsCsla40 ||
    (CurrentUnit.GenerationParams.TargetIsCsla45 && (!createRunLocalDp || CurrentUnit.GenerationParams.SilverlightUsingServices))))
{
    %>
<!-- #include file="DataPortalCreate.asp" -->
<%
}
if (UseNoSilverlight())
{
    %>
<!-- #include file="DataPortalFetch.asp" -->
<!-- #include file="InternalInsertUpdateDelete.asp" -->
<%
}
if (UseBoth() &&
    ((CurrentUnit.GenerationParams.TargetIsCsla40 && createRunLocalDp) ||
    ((HasDataPortalGetOrDelete(Info) || Info.GenerateDataPortalUpdate) && CurrentUnit.GenerationParams.SilverlightUsingServices)))
{
    %>

#Else
<%
}
if (CurrentUnit.GenerationParams.TargetIsCsla40)
{
    %>
<!-- #include file="DataPortalCreateServices.asp" -->
<!-- #include file="DataPortalFetchServices.asp" -->
<!-- #include file="InternalInsertUpdateDeleteServices.asp" -->
<%
}
else
{
    %>
<!-- #include file="DataPortalCreateServices-45.asp" -->
<!-- #include file="DataPortalFetchServices-45.asp" -->
<!-- #include file="InternalInsertUpdateDeleteServices-45.asp" -->
<%
}
if (UseBoth())
{
    %>

#End If
<%
}
%>

#End Region
