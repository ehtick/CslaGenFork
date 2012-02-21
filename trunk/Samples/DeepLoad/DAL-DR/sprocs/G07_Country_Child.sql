/****** Object:  StoredProcedure [GetG07_Country_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetG07_Country_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetG07_Country_Child]
GO

CREATE PROCEDURE [GetG07_Country_Child]
    @Country_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G07_Country_Child from table */
        SELECT
            [3_Countries_Child].[Country_Child_Name]
        FROM [3_Countries_Child]
        WHERE
            [3_Countries_Child].[Country_ID1] = @Country_ID1 AND
            [3_Countries_Child].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddG07_Country_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddG07_Country_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddG07_Country_Child]
GO

CREATE PROCEDURE [AddG07_Country_Child]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries_Child */
        INSERT INTO [3_Countries_Child]
        (
            [Country_ID1],
            [Country_Child_Name]
        )
        VALUES
        (
            @Country_ID,
            @Country_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateG07_Country_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateG07_Country_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateG07_Country_Child]
GO

CREATE PROCEDURE [UpdateG07_Country_Child]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries_Child */
        UPDATE [3_Countries_Child]
        SET
            [Country_Child_Name] = @Country_Child_Name
        WHERE
            [Country_ID1] = @Country_ID

    END
GO

/****** Object:  StoredProcedure [DeleteG07_Country_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteG07_Country_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteG07_Country_Child]
GO

CREATE PROCEDURE [DeleteG07_Country_Child]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark G07_Country_Child object as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        WHERE
            [3_Countries_Child].[Country_ID1] = @Country_ID

    END
GO