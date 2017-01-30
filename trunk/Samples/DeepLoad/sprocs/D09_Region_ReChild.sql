/****** Object:  StoredProcedure [GetD09_Region_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetD09_Region_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetD09_Region_ReChild]
GO

CREATE PROCEDURE [GetD09_Region_ReChild]
    @Region_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D09_Region_ReChild from table */
        SELECT
            [4_Regions_ReChild].[Region_Child_Name]
        FROM [4_Regions_ReChild]
        WHERE
            [4_Regions_ReChild].[Region_ID2] = @Region_ID2

    END
GO

/****** Object:  StoredProcedure [AddD09_Region_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddD09_Region_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddD09_Region_ReChild]
GO

CREATE PROCEDURE [AddD09_Region_ReChild]
    @Region_ID2 int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions_ReChild */
        INSERT INTO [4_Regions_ReChild]
        (
            [Region_ID2],
            [Region_Child_Name]
        )
        VALUES
        (
            @Region_ID2,
            @Region_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateD09_Region_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateD09_Region_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateD09_Region_ReChild]
GO

CREATE PROCEDURE [UpdateD09_Region_ReChild]
    @Region_ID2 int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID2
        )
        BEGIN
            RAISERROR ('''D09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_ReChild */
        UPDATE [4_Regions_ReChild]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID2] = @Region_ID2

    END
GO

/****** Object:  StoredProcedure [DeleteD09_Region_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteD09_Region_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteD09_Region_ReChild]
GO

CREATE PROCEDURE [DeleteD09_Region_ReChild]
    @Region_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID2
        )
        BEGIN
            RAISERROR ('''D09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D09_Region_ReChild object from 4_Regions_ReChild */
        DELETE
        FROM [4_Regions_ReChild]
        WHERE
            [4_Regions_ReChild].[Region_ID2] = @Region_ID2

    END
GO
